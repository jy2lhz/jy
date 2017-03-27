using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class screenshot : Form
    {
        public screenshot()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.btnUnregist_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.btnRegist_Click(sender, e);
        }

        private void 截图工具_Load(object sender, EventArgs e)
        {

        }

        public int Num = 0;
        public int MyPNum = 10;
        public byte[] bytes;
        public int SLength;

        private void button3_Click(object sender, EventArgs e)
        {
            //JyFormat f = new JyFormat();
            var jyfPath = SelectPath();
            if (jyfPath == "") 
            return ;
            Stream stream = new FileStream(jyfPath, FileMode.Open, FileAccess.Read, FileShare.None);
            BinaryReader jyfStream = new BinaryReader(stream);
            bytes = jyfStream.ReadBytes((int)stream.Length);
            SLength = (int)stream.Length / MyPNum ;
            stream.Close();
            //f.read("picture.jyf");
            MessageBox.Show("读取成功");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Bitmap [] bmp = new Bitmap[10];
            //Bitmap bmp = new Bitmap(MyLen, MyWid, PixelFormat.Format24bppRgb);
            //using (Stream stream = new FileStream("picture.jyf", FileMode.Open, FileAccess.Read, FileShare.None))
            //using (MemoryStream stream = new MemoryStream(bytes, SLength  * Num, SLength ))
            //{
            //    bmp = new Bitmap(stream);
            //}

            bmp[Num] = Mybmp[Num];

            pictureBox1.Image = bmp[Num];
            Num++;
            if (Num == MyPNum) Num = 0;
            //MessageBox.Show("读取成功");
        }

        public string SelectPath()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.jyf*)|*.jyf*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return fileDialog.FileName;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
