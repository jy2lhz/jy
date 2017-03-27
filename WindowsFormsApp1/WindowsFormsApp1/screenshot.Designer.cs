using System.Windows.Forms;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TurboWavelets;

namespace WindowsFormsApp1
{
    partial class screenshot
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "关闭工具";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "开启截屏工具";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(221, 2);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "读取截图";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(959, 533);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(329, 2);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 22);
            this.button4.TabIndex = 4;
            this.button4.Text = "显示图片";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(959, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // screenshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 557);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "screenshot";
            this.Text = "screenshot";
            this.Load += new System.EventHandler(this.截图工具_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        HotKeys h = new HotKeys();
        private void btnRegist_Click(object sender, EventArgs e)
        {
            //这里注册了Ctrl+Alt+E 快捷键
            h.Regist(this.Handle, (int)HotKeys.HotkeyModifiers.Control + (int)HotKeys.HotkeyModifiers.Alt, Keys.E, CallBack);
            MessageBox.Show("开启成功，按ctrl+alt+e开启截屏");
        }

        private void btnUnregist_Click(object sender, EventArgs e)
        {
            h.UnRegist(this.Handle, CallBack);
            MessageBox.Show("截屏工具关闭");
        }

        protected override void WndProc(ref Message m)
        {
            //窗口消息处理函数
            h.ProcessHotKey(m);
            base.WndProc(ref m);
        }

        public const int MyLen = 512;
        public const int MyWid = 512;
        public Bitmap[] Mybmp = new Bitmap[10];


        //按下快捷键时被调用的方法
        public void CallBack()
        {
            //MessageBox.Show("快捷键被调用！");
            DateTime dt = DateTime.Now;
          

            var Stime = dt.ToString("yyyyMMddhhmmssfff");

            for (int k = 0; k < MyPNum; k++)
            {
                Mybmp[k] = new Bitmap(MyLen , MyWid, PixelFormat.Format24bppRgb);
                Graphics g1 = Graphics.FromImage(Mybmp[k]);
                g1.CopyFromScreen(new Point(0, 0), new Point(0, 0), Mybmp[k].Size);

                MemoryStream ms = new MemoryStream();
                Mybmp[k].Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] bytes = ms.GetBuffer();
                Stream stream = new FileStream(Stime + ".jyf", FileMode.Append, FileAccess.Write, FileShare.None);
                BinaryWriter binStream = new BinaryWriter(stream);
                binStream.Write(bytes);
                binStream.Close();
                stream.Close();
                float[,] yArray = new float[Mybmp[k].Width, Mybmp[k].Height];
                float[,] cbArray = new float[Mybmp[k].Width, Mybmp[k].Height];
                float[,] crArray = new float[Mybmp[k].Width, Mybmp[k].Height];
                float[,] aArray = new float[Mybmp[k].Width, Mybmp[k].Height];
                BitmapToAYCbCrArrays(Mybmp[k], aArray, yArray, cbArray, crArray);
                Biorthogonal53Wavelet2D wavelet = new Biorthogonal53Wavelet2D(Mybmp[k].Width, Mybmp[k].Height);

                //System.Threading.Thread.Sleep(100);
            }
            Mybmp[0].Save("BMP.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            MessageBox.Show("截屏SUCCESS");     

        }

        static unsafe public void BitmapToAYCbCrArrays(Bitmap bmp, float[,] outA, float[,] outY, float[,] outCb, float[,] outCr)
        {
            if (bmp == null)
            {
                throw new ArgumentException("bmp cannot be null!");
            }
            if (outA == null)
            {
                throw new ArgumentException("outA cannot be null!");
            }
            if (outY == null)
            {
                throw new ArgumentException("outY cannot be null!");
            }
            if (outCb == null)
            {
                throw new ArgumentException("outCb cannot be null!");
            }
            if (outCr == null)
            {
                throw new ArgumentException("outCr cannot be null!");
            }
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData data = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            for (int y = 0; y < bmp.Height; y++)
            {
                int* srcPtr = (int*)IntPtr.Add(data.Scan0, data.Stride * y);
                for (int x = 0; x < bmp.Width; x++)
                {
                    int colB = (*srcPtr) & 255;
                    int colG = (*srcPtr >> 8) & 255;
                    int colR = (*srcPtr >> 16) & 255;
                    int colA = (*srcPtr >> 24) & 255;

                    outA[x, y] = (int)(colA - 128);
                    outY[x, y] = (int)(0.2500f * colR + 0.5000f * colG + 0.2500f * colB - 128);
                    outCr[x, y] = (int)(colB - colG);
                    outCb[x, y] = (int)(colR - colG);
                    srcPtr++;
                }
            }
            bmp.UnlockBits(data);
        }

        static unsafe public void AYCbCrArraysToBitmap(float[,] inA, float[,] inY, float[,] inCb, float[,] inCr, Bitmap bmp)
        {
            if (inA == null)
            {
                throw new ArgumentException("inA cannot be null!");
            }
            if (inY == null)
            {
                throw new ArgumentException("inY cannot be null!");
            }
            if (inCb == null)
            {
                throw new ArgumentException("inCb cannot be null!");
            }
            if (inCr == null)
            {
                throw new ArgumentException("inCr cannot be null!");
            }
            if (bmp == null)
            {
                throw new ArgumentException("bmp cannot be null!");
            }
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData data = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            for (int posY = 0; posY < bmp.Height; posY++)
            {
                int* dstPtr = (int*)IntPtr.Add(data.Scan0, data.Stride * posY);
                for (int posX = 0; posX < bmp.Width; posX++)
                {
                    float a = inA[posX, posY];
                    float y = inY[posX, posY] + 128;
                    float cb = inCb[posX, posY];
                    float cr = inCr[posX, posY];

                    int aInt = (int)(a + 128);
                    int gInt = (int)(y - 0.2500f * cb - 0.2500f * cr);
                    int rInt = (int)(gInt + cb);
                    int bInt = (int)(gInt + cr);

                    if (aInt < 0)
                    {
                        aInt = 0;
                    }
                    else if (aInt > 255)
                    {
                        aInt = 255;
                    }
                    if (rInt < 0)
                    {
                        rInt = 0;
                    }
                    else if (rInt > 255)
                    {
                        rInt = 255;
                    }
                    if (gInt < 0)
                    {
                        gInt = 0;
                    }
                    else if (gInt > 255)
                    {
                        gInt = 255;
                    }
                    if (bInt < 0)
                    {
                        bInt = 0;
                    }
                    else if (bInt > 255)
                    {
                        bInt = aInt;
                    }
                    *dstPtr = (int)(bInt + (gInt << 8) + (rInt << 16) + (aInt << 24));
                    dstPtr++;
                }
            }
            bmp.UnlockBits(data);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private PictureBox pictureBox1;
        private Button button4;
        private MenuStrip menuStrip1;
    }

    [Serializable]
    public struct JyColor
    {
        public byte r, g, b;
    }

    [Serializable]
    public class JyPicture
    {
        public JyColor[, ] pixels = new JyColor[screenshot.MyLen , screenshot.MyWid ];
    }
    
    public class JyFormat
    {
        public const int MyPNum = 10;
        public JyPicture[] pictures = new JyPicture[MyPNum];

        //public JyFormat() { }

        //public void read(string path)
        //{
        //    Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
        //    BinaryReader binStream = new BinaryReader(stream);
        //    //for (int k = 0; k < MyPNum; k++)
        //    //{
        //        byte [] bytes = binStream.ReadBytes(screenshot.MySize * MyPNum );
        //    //}

        //    //for (int k = 0; k < MyPNum; k++)
        //    //{
        //    //    JyPicture p = new JyPicture();
        //    //    this.pictures[k] = p;
        //    //    //if (binStream.PeekChar() == -1) break;
        //    //    for (int i = 0; i < screenshot.MyLen; i++)
        //    //    {
        //    //        for (int j = 0; j < screenshot.MyWid; j++)
        //    //        {
        //    //            p.pixels[i, j].r = (byte)binStream.ReadByte();
        //    //            p.pixels[i, j].g = (byte)binStream.ReadByte();
        //    //            p.pixels[i, j].b = (byte)binStream.ReadByte();
        //    //        }
        //    //    }
        //    //}
        //    binStream.Close();
        //    stream.Close();
        //} 

        
    }
}

