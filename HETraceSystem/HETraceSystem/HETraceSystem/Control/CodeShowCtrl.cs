using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using COMM;

namespace HETraceSystem.Control
{   
  
    public partial class CodeShowCtrl : UserControl
    {

        /// <summary>
        /// 编码图片
        /// </summary>
        private Bitmap picture=null;



        private string content=string.Empty;



        private int lineSize=0;



        private int marginSize=5;


        private CodeType codeType = CodeType.BarCode;

        private delegate void UpdateViewDelegate();


        /// <summary>
        /// 编码内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public CodeType CodeType
        {
            get { return codeType; }
            set { codeType = value; }
        }
        
        public CodeShowCtrl()
        {
            InitializeComponent();
        }



        public void Update()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateViewDelegate(Update));
            }
            else
            {
                this.Invalidate();
            }
        }

        public Size getPicSize()
        {

            Size picsize = new Size();
            picsize.Width = this.Width - marginSize;
            picsize.Height = this.Height - marginSize;
            return picsize;
        }


        public Point getLocation()
        {
            Point location = new Point();
            int offsetX= getPicSize().Width;
            int offsetY = getPicSize().Height;

            if (offsetX < 0)
                offsetX = this.Width;
            if (offsetY < 0)
                offsetY = this.Height;

            location.X = (this.Width - offsetX) / 2;
            location.Y = (this.Height - offsetY) / 2;

            return location;
        }


        private void CreateBarCode(Graphics graph,Rectangle rect)
        {
            picture = new Bitmap(this.Width-marginSize,
                                 this.Height-marginSize);

            EncodingOptions options = null;

            BarcodeWriter writer = null;

            Size picSize=getPicSize();

            if (codeType == CodeType.BarCode)
            {

                options = new EncodingOptions
                {
                    Width = picSize.Width,
                    Height = picSize.Height
                };

       
               writer = new BarcodeWriter();
               writer.Format = BarcodeFormat.CODE_128;
               writer.Options = options;
               picSize.Width = (int)(picSize.Width * 0.8);
               picSize.Height = (int)(picSize.Height * 0.8);
            }
            else
            {
                options = new QrCodeEncodingOptions
                {
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    Width = picSize.Width,
                    Height = picSize.Height
                };


                writer = new BarcodeWriter();
                writer.Format = BarcodeFormat.QR_CODE;
                writer.Options = options;

                content = CodeComm.EncodeSNToMD5(content);
            }

            picture = writer.Write(content);

           // if(codeType==)
            Rectangle bestFit = GetBestFitRectangle(rect, picSize);

           // Point graphloc= getLocation();
            graph.DrawImage(picture, bestFit);

            graph.DrawRectangle(Pens.Black, bestFit);
            graph.DrawRectangle(Pens.Black, rect);

        }


        // 保持高度比：参数为(打印边界的Rectangularle对象，图像大小的Size对象)
        protected Rectangle GetBestFitRectangle(Rectangle toContain,Size objectSize)
        {
            //检查页面是水平还是竖直的。
            bool containerLandscape =false;
            if(toContain.Width > toContain.Height)
                containerLandscape = true;
 
            //高度比=图像的高/图像的宽
            float aspectRatio = (float)objectSize.Height / (float)objectSize.Width;
            //得到页面左上角的坐标
            int midContainerX = toContain.Left + (toContain.Width / 2);
            int midContainerY = toContain.Top + (toContain.Height / 2);
 
            int x1 = 0, x2 = 0, y1 = 0, y2 = 0;
            if(containerLandscape ==false)
            {
                //竖直图像
                x1 = toContain.Left;
                x2 = toContain.Right;
                //调整之后的height
                int adjustedHeight = (int)((float)toContain.Width * aspectRatio);
 
                y1 = midContainerY -(adjustedHeight / 2);
                y2 = y1 + adjustedHeight;
            }
            else
            {
                y1 = toContain.Top;
                y2 = toContain.Bottom;
                //调整之后的height
                int adjustedWidth = (int)((float)toContain.Height/ aspectRatio);
 
                x1 = midContainerX -(adjustedWidth / 2);
                x2 = x1 + adjustedWidth;
            }
            return new Rectangle(x1,y1, x2 - x1, y2 - y1);
        }
    

        protected override void OnResize(EventArgs e)
        {
            this.Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            if (content == null || content == string.Empty)
                content = "0000";

            CreateBarCode(e.Graphics,e.ClipRectangle);
            base.OnPaint(e);
        }


    }
}
