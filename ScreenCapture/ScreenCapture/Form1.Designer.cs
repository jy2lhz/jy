using SevenZip;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ScreenCapture
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.MyNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.开启截屏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭截屏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(3, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "开启截屏";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(73, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 27);
            this.button2.TabIndex = 1;
            this.button2.Text = "关闭截屏";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(143, 5);
            this.button3.Margin = new System.Windows.Forms.Padding(1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 27);
            this.button3.TabIndex = 2;
            this.button3.Text = "读取图片";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(213, 5);
            this.button4.Margin = new System.Windows.Forms.Padding(1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 27);
            this.button4.TabIndex = 3;
            this.button4.Text = "显示图片";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // MyNotifyIcon
            // 
            this.MyNotifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.MyNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MyNotifyIcon.Icon")));
            this.MyNotifyIcon.Text = "notifyIcon1";
            this.MyNotifyIcon.Visible = true;
            this.MyNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MyNotifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开启截屏ToolStripMenuItem,
            this.关闭截屏ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // 开启截屏ToolStripMenuItem
            // 
            this.开启截屏ToolStripMenuItem.Name = "开启截屏ToolStripMenuItem";
            this.开启截屏ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.开启截屏ToolStripMenuItem.Text = "开启截屏";
            this.开启截屏ToolStripMenuItem.Click += new System.EventHandler(this.开启截屏ToolStripMenuItem_Click);
            // 
            // 关闭截屏ToolStripMenuItem
            // 
            this.关闭截屏ToolStripMenuItem.Name = "关闭截屏ToolStripMenuItem";
            this.关闭截屏ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.关闭截屏ToolStripMenuItem.Text = "关闭截屏";
            this.关闭截屏ToolStripMenuItem.Click += new System.EventHandler(this.关闭截屏ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(430, 5);
            this.textBox2.MaxLength = 1;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(67, 26);
            this.textBox2.TabIndex = 6;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(284, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(150, 26);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "连续截图张数(1-9):";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Location = new System.Drawing.Point(10, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 360);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(503, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(66, 26);
            this.textBox1.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox4.Location = new System.Drawing.Point(575, 5);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(82, 26);
            this.textBox4.TabIndex = 10;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(662, 38);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 418);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ScreenCapture";
            this.MinimumSizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseWheel);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        HotKeys h = new HotKeys();
        private void btnRegist_Click(object sender, EventArgs e)
        {
            //这里注册了Ctrl+Alt+E 快捷键
            h.Regist(this.Handle, (int)HotKeys.HotkeyModifiers.Control + (int)HotKeys.HotkeyModifiers.Alt, Keys.E, CallBack);
            button1.Enabled = false;
            button2.Enabled = true;
            开启截屏ToolStripMenuItem.Enabled = false;
            关闭截屏ToolStripMenuItem.Enabled = true;
            this.MyNotifyIcon.ShowBalloonTip(1, "Tips", "开启成功，按ctrl+alt+e开启截屏", ToolTipIcon.Info);
            System.Threading.Thread.Sleep(500); //Wait 2 second
            MyNotifyIcon.Visible = false; //这样可以控制2秒后其乖乖地消失在人间
            MyNotifyIcon.Visible = true; //只是会闪一下
        }

        private void btnUnregist_Click(object sender, EventArgs e)
        {
            h.UnRegist(this.Handle, CallBack);
            button2.Enabled = false;
            button1.Enabled = true;
            关闭截屏ToolStripMenuItem.Enabled = false;
            开启截屏ToolStripMenuItem.Enabled = true;
            this.MyNotifyIcon.ShowBalloonTip(1, "Tips", "截屏功能已关闭", ToolTipIcon.Info);
            System.Threading.Thread.Sleep(500); //Wait 2 second
            MyNotifyIcon.Visible = false; //这样可以控制2秒后其乖乖地消失在人间
            MyNotifyIcon.Visible = true; //只是会闪一下
        }
        protected override void WndProc(ref Message m)
        {
            //窗口消息处理函数
            h.ProcessHotKey(m);
            base.WndProc(ref m);
        }


        public int MyWid;
        public int MyHit;
        public int MyPNum;
        public Bitmap[] Mybmp = new Bitmap[9];


        public void CallBack()
        {
            //MessageBox.Show("快捷键被调用！");
            DateTime dt = DateTime.Now;


            var Stime = dt.ToString("yyyyMMddhhmmssfff");

            MemoryStream SourceBmp = new MemoryStream();

            for (int k = 0; k < MyPNum; k++)
            {
                Mybmp[k] = new Bitmap(MyWid, MyHit, PixelFormat.Format24bppRgb);
                Graphics g1 = Graphics.FromImage(Mybmp[k]);
                g1.CopyFromScreen(new Point(0, 0), new Point(0, 0), Mybmp[k].Size);
                //MemoryStream ms = new MemoryStream();
                //Mybmp[k].Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                //ms.WriteTo(SourceBmp);
                //ms.Close();
                //byte[] bytes = ms.GetBuffer();
                //Stream stream = new FileStream(Stime + ".jyf", FileMode.Append, FileAccess.Write, FileShare.None);
                //BinaryWriter binStream = new BinaryWriter(stream);
                //binStream.Write(bytes);
                //binStream.Close();
                //stream.Close();
                System.Threading.Thread.Sleep(200); //Wait 0.2 second
            }

            for (int k = 0; k < MyPNum; k++)
            {
                MemoryStream ms = new MemoryStream();
                Mybmp[k].Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                ms.WriteTo(SourceBmp);
                ms.Close();
            }
            //string path1 = System.Threading.Thread.GetDomain().BaseDirectory;
            ////SevenZipCompressor.SetLibraryPath("7z.dll");
            //SevenZipCompressor MyComp = new SevenZipCompressor();
            //MyComp.CompressFiles(@path1 + Stime + ".jy", @path1 + Stime + ".jyf");

            MemoryStream CompBmp = new MemoryStream();
            SevenZipCompressor MyComp = new SevenZipCompressor();
            MyComp.CompressStream(SourceBmp, CompBmp);
            SourceBmp.Close();
            byte[] bytes = CompBmp.GetBuffer();
            Stream stream = new FileStream(Stime + "(共" + MyPNum + "张)" + ".jy", FileMode.Append, FileAccess.Write, FileShare.None);
            BinaryWriter binStream = new BinaryWriter(stream);
            binStream.Write(bytes);
            binStream.Close();
            stream.Close();

            Mybmp[0].Save("BMP.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            this.MyNotifyIcon.ShowBalloonTip(1, "Tips", "截屏成功，文件在软件目录下", ToolTipIcon.Info);
            System.Threading.Thread.Sleep(500); //Wait 2 second
            MyNotifyIcon.Visible = false; //这样可以控制2秒后其乖乖地消失在人间
            MyNotifyIcon.Visible = true; //只是会闪一下
        }
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NotifyIcon MyNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开启截屏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭截屏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private TextBox textBox2;
        private TextBox textBox3;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private TextBox textBox4;
        private Splitter splitter1;
    }
}

