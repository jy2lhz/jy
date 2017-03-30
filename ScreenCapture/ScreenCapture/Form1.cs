using SevenZip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ScreenCapture
{
    public partial class Form1 : Form
    {
        System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return System.Reflection.Assembly.Load(bytes);
        }
        public int BmpLen;
        public Form1()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            InitializeComponent();
            Rectangle rect = System.Windows.Forms.Screen.GetBounds(this);
            this.MyWid = rect.Width;//屏幕宽
            this.MyHit = rect.Height;//屏幕高
            textBox1.ReadOnly = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            开启截屏ToolStripMenuItem.Enabled = false;
            关闭截屏ToolStripMenuItem.Enabled = false;
            Mybmp[0] = new Bitmap(MyWid, MyHit, PixelFormat.Format24bppRgb);
            Graphics g1 = Graphics.FromImage(Mybmp[0]);
            g1.CopyFromScreen(new Point(0, 0), new Point(0, 0), Mybmp[0].Size);
            MemoryStream ms = new MemoryStream();
            Mybmp[0].Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BmpLen = (int)ms.Length;
            textBox4.Text = "大小:" + (pictureBox1.Width * 100 / MyWid) + "%";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.btnRegist_Click(sender, e); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.btnUnregist_Click(sender, e);
        }

        public byte[] bytes;
        public int ReadNum;
        public int RBmpLen;
        public int Num = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            var jyPath = SelectPath();
            jyPath.Replace("\\\\", "\\");
            if (jyPath == "")
                return;
            string fileName = System.IO.Path.GetFileName(jyPath);
            //char RNum = fileName[19];
            ReadNum = (fileName[19] - '0');
            //Stream ALLBmp = new FileStream(jyPath, FileMode.Open, FileAccess.Read, FileShare.None);
            Stream ALLBmp = new MemoryStream();
            SevenZipExtractor MyExtr = new SevenZipExtractor(jyPath);
            string filename = System.IO.Path.GetFileName(jyPath);
            MyExtr.ExtractFile(0, ALLBmp);
            ALLBmp.Position = 0;
            bytes = new byte[ALLBmp.Length];
            ALLBmp.Read(bytes, 0, (int)ALLBmp.Length);
            //ReadNum =(int) (ALLBmp.Length / BmpLen);
            RBmpLen = (int)(ALLBmp.Length / ReadNum);
            ALLBmp.Close();
            button4.Enabled = true;
            Num = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Bitmap bmp = new Bitmap(MyWid, MyHit, PixelFormat.Format24bppRgb);
            Bitmap bmp;
            using (Stream stream = new MemoryStream(bytes, RBmpLen * Num, RBmpLen))
            {
                bmp = new Bitmap(stream);
            }
            pictureBox1.Image = bmp;
            Num++;
            textBox1.Text = "第" + Num + "张";
            if (Num == ReadNum) Num = 0;
        }

        public string SelectPath()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.jy)|*.jy";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return fileDialog.FileName;
        }

        private void screenshot_Load(object sender, EventArgs e)
        {

        }
        void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) //放大图片
            {
                pictureBox1.Size = new Size(pictureBox1.Width + 96, pictureBox1.Height + 54);
                pictureBox1.Location = new Point(pictureBox1.Location.X - 48, pictureBox1.Location.Y - 27);
            }
            else
            {  //缩小图片
                pictureBox1.Size = new Size(pictureBox1.Width - 96, pictureBox1.Height - 54);
                pictureBox1.Location = new Point(pictureBox1.Location.X + 48, pictureBox1.Location.Y + 27);
            }
            textBox4.Text = "大小:" + (pictureBox1.Width * 100 / MyWid) + "%";
            //设置图片在窗体居中
            //pictureBox1.Location = new Point((this.Width - pictureBox1.Width) / 2, (this.Height - pictureBox1.Height) / 2);
        }

        private void ExitMainForm()
        {
            if (MessageBox.Show("您确定要退出截屏程序吗？", "确认退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                this.MyNotifyIcon.Visible = false;
                this.Close();
                this.Dispose();
                Application.Exit();
            }
        }

        //点最小化按钮时，最小化到托盘
        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HideMainForm();
            }
        }

        //右键菜单处理，显示　隐藏　退出
        private void menuItem_Show_Click(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        private void HideMainForm()
        {
            this.Hide();
        }

        private void ShowMainForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        //窗体关闭提示
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            HideMainForm();
        }

        //双击托盘上图标时，显示窗体
        private void MyNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Minimized;

                    HideMainForm();
                }
                else if (this.WindowState == FormWindowState.Minimized)
                {
                    ShowMainForm();
                }
            }
        }

        private void 开启截屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnRegist_Click(sender, e);
        }

        private void 关闭截屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.btnUnregist_Click(sender, e);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitMainForm();
        }

        private void screenshot_MinimumSizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HideMainForm();
            }
        }

        public int OnLock = 0;
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '1') || (e.KeyChar > '9'))//这是允许输入1-9数字
                {
                    e.Handled = true;
                }
                MyPNum = e.KeyChar - '0';
            }
            if (OnLock == 0)
            {
                button1.Enabled = true;
                开启截屏ToolStripMenuItem.Enabled = true;
            }
            OnLock++;
        }

        public Point mouseDownPoint;
        public bool isSelected;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint.X = Cursor.Position.X;  //注：全局变量mouseDownPoint前面已定义为Point类型

                mouseDownPoint.Y = Cursor.Position.Y;
                isSelected = true;
            }
            if (e.Button == MouseButtons.Right)
            {
                this.pictureBox1.Left = this.ClientSize.Width / 2 - pictureBox1.Width / 2;
                this.pictureBox1.Top = this.ClientSize.Height / 2 - pictureBox1.Height / 2 + 20;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelected )
            {
                this.pictureBox1.Left = this.pictureBox1.Left + (Cursor.Position.X - mouseDownPoint.X);
                this.pictureBox1.Top = this.pictureBox1.Top + (Cursor.Position.Y - mouseDownPoint.Y);
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isSelected = false;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }
    }

}
