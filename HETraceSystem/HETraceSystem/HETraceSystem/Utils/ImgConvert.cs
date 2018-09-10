using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Data;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using COMM;
using COMM.Image;

namespace HETraceSystem.Utils
{
    public static class ImgConvert
    {


        public static bool QRCodeConvert(string tempFileName,string destFileName,int nWidth,int nHeight, int offsetX,int offsetY, Bitmap Qrcode )
        {
            try
            {

               Image tempImage= Image.FromFile(tempFileName);

               if (tempImage == null)
                   return false;

               using(Graphics temp = Graphics.FromImage(tempImage))
               {
                    
                   Point pos = new Point(offsetX, offsetY);

                   temp.DrawImage(Qrcode,pos);
               }

               ///文件信息
               FileInfo fInfo = new FileInfo(destFileName);

               if (Directory.Exists(fInfo.DirectoryName))
               {
                   Directory.Delete(fInfo.DirectoryName);
               }

               Directory.CreateDirectory(fInfo.DirectoryName);

               tempImage.Save(destFileName,System.Drawing.Imaging.ImageFormat.Bmp);

               return true;
            }
            catch
            {
                throw;
            }

        }

        private static PixelFormat[] indexedPixelFormats = { PixelFormat.Undefined, PixelFormat.DontCare,
                                                             PixelFormat.Format16bppArgb1555, PixelFormat.Format1bppIndexed, PixelFormat.Format4bppIndexed,
                                                             PixelFormat.Format8bppIndexed};

            /// <summary>
            /// 判断图片的PixelFormat 是否在 引发异常的 PixelFormat 之中
            /// </summary>
            /// <param name="imgPixelFormat">原图片的PixelFormat</param>
            /// <returns></returns>
            private static bool IsPixelFormatIndexed(PixelFormat imgPixelFormat)
            {
                foreach (PixelFormat pf in indexedPixelFormats)
                {
                    if (pf.Equals(imgPixelFormat)) return true;
                }

                return false;
            }

            public static bool DrawQRCodeBmpV(string tempFileName, string destFileName, Bitmap Qrcode, Point location, string sn)
            {
                //  return true;
                try
                {
                    //读取临时文件
                    Image tempImage = Image.FromFile(tempFileName);

                    if (tempImage == null)
                        return false;

                    if (IsPixelFormatIndexed(tempImage.PixelFormat))
                    {
                        Bitmap bmp = new Bitmap(tempImage.Width, tempImage.Height, PixelFormat.Format8bppIndexed);
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                            g.DrawImage(tempImage, 0, 0);
                        }

                        //下面的水印操作，就直接对 bmp 进行了
                        ///回执二维码
                        using (Graphics temp = Graphics.FromImage(bmp))
                        {

                            GraphicsText graphicsText = new GraphicsText();
                            graphicsText.Graphics = temp; 
                            temp.DrawImage(Qrcode, location);

                            string SN = "SN:" + sn;
                            // Create font and brush.
                            Font drawFont = new Font("Arial", 16);
                            SolidBrush drawBrush = new SolidBrush(Color.Black);


                            // Create rectangle for drawing.
                            float x = location.X+50;
                            float y = location.Y + 20;
                            float width = 200.0F;
                            float height = 50.0F;
                            RectangleF drawRect = new RectangleF(x, y, width, height);

                            // Draw rectangle to screen.
                            Pen blackPen = new Pen(Color.Black);
                            temp.DrawRectangle(blackPen, x, y, width, height);

                            // Set format of string.
                            StringFormat drawFormat = new StringFormat();
                            drawFormat.Alignment = StringAlignment.Center;

                            // Draw string to screen.
                            graphicsText.DrawString(sn, drawFont, drawBrush, drawRect, drawFormat,90);

                            //rect.Location += new SizeF(180, 0);
                            //format.LineAlignment = StringAlignment.Center;
                            //e.Graphics.DrawRectangle(_pen, rect.Left, rect.Top, rect.Width, rect.Height);
                          //  graphicsText.DrawString(_text, _font, _brush, rect, format, 90);  


                            FileInfo fInfo = new FileInfo(destFileName);

                            if (!Directory.Exists(fInfo.DirectoryName))
                            {
                                Directory.CreateDirectory(fInfo.DirectoryName);
                            }

                            if (File.Exists(destFileName))
                            {
                                File.Delete(destFileName);
                            }
                            bmp.RotateFlip(RotateFlipType.Rotate90FlipY);
                            bmp.Save(destFileName);

                            return true;

                        }


                    }
                    else //否则直接操作
                    {
                        ///回执二维码
                        using (Graphics temp = Graphics.FromImage(tempImage))
                        {

                            GraphicsText graphicsText = new GraphicsText();
                            graphicsText.Graphics = temp; 
                            temp.DrawImage(Qrcode, location);

                            string SN = "SN:" + sn;

                            int fontSize = 30;
                            // Create font and brush.
                            Font drawFont = new Font("Arial", fontSize);
                            SolidBrush drawBrush = new SolidBrush(Color.Black);


                            // Measure string.
                            SizeF stringSize = new SizeF();
                            //// Create rectangle for drawing.
                            stringSize = temp.MeasureString(SN, drawFont);

                            PointF offset = new PointF();
                            offset.X = (float)(location.X-200 );
                            //offset.Y = (float)(this.Height * 0.45);
                            offset.Y = (float)(location.Y +20);
                          //  offset.Y = 470;

                            RectangleF drawRect = new RectangleF(offset.X, offset.Y, stringSize.Width, stringSize.Height);
                            // Draw string to screen.
                          //  temp.DrawString(SN, drawFont, Brushes.Black, offset);
                            StringFormat drawFormat = new StringFormat();
                            drawFormat.Alignment = StringAlignment.Center;
                            // Draw string to screen.
                            graphicsText.DrawString(SN, drawFont, drawBrush, drawRect, drawFormat, 90);

                            FileInfo fInfo = new FileInfo(destFileName);

                            if (!Directory.Exists(fInfo.DirectoryName))
                            {
                                Directory.CreateDirectory(fInfo.DirectoryName);
                            }

                            if (File.Exists(destFileName))
                            {
                                File.Delete(destFileName);
                            }


                           // tempImage.RotateFlip(RotateFlipType.Rotate90FlipY);

                            tempImage.Save(destFileName);


                            return true;
                        }
                    }

                    return false;
                }
                catch
                {
                    throw;
                }
            }
            public static bool DrawQRCodeBmp(string tempFileName, string destFileName, Bitmap Qrcode, Point location, string sn)
            {
                //  return true;
                try
                {
                    //读取临时文件
                    Image tempImage = Image.FromFile(tempFileName);

                    if (tempImage == null)
                        return false;

                    if (IsPixelFormatIndexed(tempImage.PixelFormat))
                    {
                        Bitmap bmp = new Bitmap(tempImage.Width, tempImage.Height, PixelFormat.Format8bppIndexed);
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                            g.DrawImage(tempImage, 0, 0);
                        }

                        //下面的水印操作，就直接对 bmp 进行了
                        ///回执二维码
                        using (Graphics temp = Graphics.FromImage(bmp))
                        {

                            temp.DrawImage(Qrcode, location);

                            string SN = "SN:" + sn;
                            // Create font and brush.
                            Font drawFont = new Font("Arial", 16);
                            SolidBrush drawBrush = new SolidBrush(Color.Black);


                            // Create rectangle for drawing.
                            float x = 100;
                            float y = location.Y + 100;
                            float width = 200.0F;
                            float height = 50.0F;
                            RectangleF drawRect = new RectangleF(x, y, width, height);

                            // Draw rectangle to screen.
                            Pen blackPen = new Pen(Color.Black);
                            temp.DrawRectangle(blackPen, x, y, width, height);

                            // Set format of string.
                            StringFormat drawFormat = new StringFormat();
                            drawFormat.Alignment = StringAlignment.Center;

                            // Draw string to screen.
                            temp.DrawString(sn, drawFont, drawBrush, drawRect, drawFormat);



                            FileInfo fInfo = new FileInfo(destFileName);

                            if (!Directory.Exists(fInfo.DirectoryName))
                            {
                                Directory.CreateDirectory(fInfo.DirectoryName);
                            }

                            if (File.Exists(destFileName))
                            {
                                File.Delete(destFileName);
                            }

                            bmp.Save(destFileName);

                            return true;

                        }


                    }
                    else //否则直接操作
                    {
                        ///回执二维码
                        using (Graphics temp = Graphics.FromImage(tempImage))
                        {

                            temp.DrawImage(Qrcode, location);

                            string SN = "SN:" + sn;

                            int fontSize =24;
                            // Create font and brush.
                            Font drawFont = new Font("Arial", fontSize);
                            SolidBrush drawBrush = new SolidBrush(Color.Black);


                            // Measure string.
                            SizeF stringSize = new SizeF();
                            //// Create rectangle for drawing.
                            stringSize = temp.MeasureString(SN, drawFont);

                            PointF offset = new PointF();
                            offset.X = (float)(location.X+10);
                            //offset.Y = (float)(this.Height * 0.45);
                            offset.Y = (float)(location.Y + Qrcode.Height + 5);

                            // Draw string to screen.
                            temp.DrawString(SN, drawFont, Brushes.Black, offset);



                            FileInfo fInfo = new FileInfo(destFileName);

                            if (!Directory.Exists(fInfo.DirectoryName))
                            {
                                Directory.CreateDirectory(fInfo.DirectoryName);
                            }

                            if (File.Exists(destFileName))
                            {
                                File.Delete(destFileName);
                            }

                     

                            tempImage.Save(destFileName);
         

                            return true;
                        }
                    }

                    return false;
                }
                catch
                {
                    throw;
                }
            }
            public static bool DrawQRCodeBmp2(string tempFileName, string destFileName, Bitmap Qrcode, Point location, string sn)
            {
                //  return true;
                try
                {
                    //读取临时文件
                    Image tempImage = Image.FromFile(tempFileName);

                    if (tempImage == null)
                        return false;

                    if (IsPixelFormatIndexed(tempImage.PixelFormat))
                    {
                        //Bitmap bmp = new Bitmap(tempImage.Width, tempImage.Height, PixelFormat.Format8bppIndexed);

                        Bitmap bmp = new Bitmap(tempImage.Width, tempImage.Height, PixelFormat.Format24bppRgb);

                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                            g.DrawImage(tempImage, 0, 0);
                        }

                        //下面的水印操作，就直接对 bmp 进行了
                        ///回执二维码
                        using (Graphics temp = Graphics.FromImage(bmp))
                        {

                            temp.DrawImage(Qrcode, location);

                            string SN = "SN:" + sn;
                            // Create font and brush.
                            Font drawFont = new Font("Arial", 14);
                            SolidBrush drawBrush = new SolidBrush(Color.Black);


                            // Create rectangle for drawing.
                            float x = 100;
                            float y = location.Y + 20;
                            float width =100.0F;
                            float height = 20.0F;
                            RectangleF drawRect = new RectangleF(x, y, width, height);

                            // Draw rectangle to screen.
                            Pen blackPen = new Pen(Color.Black);
                            temp.DrawRectangle(blackPen, x, y, width, height);

                            // Set format of string.
                            StringFormat drawFormat = new StringFormat();
                            drawFormat.Alignment = StringAlignment.Center;

                            // Draw string to screen.
                          //  temp.DrawString(sn, drawFont, drawBrush, drawRect, drawFormat);



                            FileInfo fInfo = new FileInfo(destFileName);

                            if (!Directory.Exists(fInfo.DirectoryName))
                            {
                                Directory.CreateDirectory(fInfo.DirectoryName);
                            }

                            if (File.Exists(destFileName))
                            {
                                File.Delete(destFileName);
                            }

                            bmp.Save(destFileName);

                            return true;

                        }


                    }
                    else //否则直接操作
                    {
                        ///回执二维码
                        using (Graphics temp = Graphics.FromImage(tempImage))
                        {

                            temp.DrawImage(Qrcode, location);

                            string SN = "SN:" + sn;

                            int fontSize = 24;
                            // Create font and brush.
                            Font drawFont = new Font("Arial", fontSize);
                            SolidBrush drawBrush = new SolidBrush(Color.Black);


                            // Measure string.
                            SizeF stringSize = new SizeF();
                            //// Create rectangle for drawing.
                            stringSize = temp.MeasureString(SN, drawFont);

                            PointF offset = new PointF();

                            offset.X = (float)(location.X+10);
                            //offset.X = (float)(location.X + 10);
                            //offset.Y = (float)(this.Height * 0.45);
                           offset.Y = (float)(location.Y + Qrcode.Height + 5);
                         //   offset.Y = (float)(location.Y + Qrcode.Height + 240);
                            // Draw string to screen.
                            temp.DrawString(SN, drawFont, Brushes.Black, offset);



                            FileInfo fInfo = new FileInfo(destFileName);

                            if (!Directory.Exists(fInfo.DirectoryName))
                            {
                                Directory.CreateDirectory(fInfo.DirectoryName);
                            }

                            if (File.Exists(destFileName))
                            {
                                File.Delete(destFileName);
                            }



                            tempImage.Save(destFileName);


                            return true;
                        }
                    }

                    return false;
                }
                catch
                {
                    throw;
                }
            }
             public static bool QRCodeConvetPcx(string tempFileName, string destFileName, Bitmap Qrcode, Point location, string sn)
             {

               //  return true;
                  try
                   {
                  //读取临时文件
                            Image tempImage = Image.FromFile(tempFileName);

                            if (tempImage == null)
                                return false;

                            if (IsPixelFormatIndexed(tempImage.PixelFormat))
                            {
                                Bitmap bmp = new Bitmap(tempImage.Width, tempImage.Height, PixelFormat.Format8bppIndexed);
                                using (Graphics g = Graphics.FromImage(bmp))
                                {
                                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                                    g.DrawImage(tempImage, 0, 0);
                                }

                                //下面的水印操作，就直接对 bmp 进行了
                                ///回执二维码
                                using (Graphics temp = Graphics.FromImage(bmp))
                                {

                                    temp.DrawImage(Qrcode, location);

                                    //string SN = "SN:" + sn;
                                    //// Create font and brush.
                                    //Font drawFont = new Font("Arial", 16);
                                    //SolidBrush drawBrush = new SolidBrush(Color.Black);


                                    //// Create rectangle for drawing.
                                    //float x = 100;
                                    //float y = location.Y+100;
                                    //float width = 200.0F;
                                    //float height = 50.0F;
                                    //RectangleF drawRect = new RectangleF(x, y, width, height);

                                    //// Draw rectangle to screen.
                                    //Pen blackPen = new Pen(Color.Black);
                                    //temp.DrawRectangle(blackPen, x, y, width, height);

                                    //// Set format of string.
                                    //StringFormat drawFormat = new StringFormat();
                                    //drawFormat.Alignment = StringAlignment.Center;

                                    //// Draw string to screen.
                                    //temp.DrawString(sn, drawFont, drawBrush, drawRect, drawFormat);



                                    FileInfo fInfo = new FileInfo(destFileName);

                                    if (!Directory.Exists(fInfo.DirectoryName))
                                    {
                                        Directory.CreateDirectory(fInfo.DirectoryName);
                                    }

                                    if (File.Exists(destFileName))
                                    {
                                        File.Delete(destFileName);
                                    }

                                    ImagePcx pcx = new ImagePcx();

                                    pcx.PcxImage = bmp;

                                    pcx.Save(destFileName);

                                    return true;

                                }

                             
                            }
                            else //否则直接操作
                            {
                                ///回执二维码
                                using (Graphics temp = Graphics.FromImage(tempImage))
                                {

                                    temp.DrawImage(Qrcode, location);

                                    //string SN = "SN:" + sn;
                                    //// Create font and brush.
                                    //Font drawFont = new Font("Arial", 16);
                                    //SolidBrush drawBrush = new SolidBrush(Color.Black);


                                    //// Create rectangle for drawing.
                                    //float x = 100;
                                    //float y = location.Y+100;
                                    //float width = 200.0F;
                                    //float height = 50.0F;
                                    //RectangleF drawRect = new RectangleF(x, y, width, height);

                                    //// Draw rectangle to screen.
                                    //Pen blackPen = new Pen(Color.Black);
                                    //temp.DrawRectangle(blackPen, x, y, width, height);

                                    //// Set format of string.
                                    //StringFormat drawFormat = new StringFormat();
                                    //drawFormat.Alignment = StringAlignment.Center;

                                    //// Draw string to screen.
                                    //temp.DrawString(sn, drawFont, drawBrush, drawRect, drawFormat);



                                    FileInfo fInfo = new FileInfo(destFileName);

                                    if (!Directory.Exists(fInfo.DirectoryName))
                                    {
                                        Directory.CreateDirectory(fInfo.DirectoryName);
                                    }

                                    if (File.Exists(destFileName))
                                    {
                                        File.Delete(destFileName);
                                    }

                                    ImagePcx pcx = new ImagePcx();

                                    pcx.PcxImage = (Bitmap)tempImage;

                                    pcx.Save(destFileName);

                                    return true;
                                }
                            }

                            return false;
                 }
                 catch
                 {
                 throw;
                 }
              

        
        }



        public static Bitmap CreateQRCode(int nWidth, int nHeight, string content)
        {
            try
            {
                Bitmap picture = new Bitmap(nWidth,
                                           nHeight);

                EncodingOptions options = null;

                BarcodeWriter writer = null;


                options = new QrCodeEncodingOptions
                {
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    Width = nWidth,
                    Height = nHeight,
                    Margin = 0
                };


                writer = new BarcodeWriter();
                writer.Format = BarcodeFormat.QR_CODE;
                writer.Options = options;

                content = CodeComm.EncodeSNToMD5(content);

                picture = writer.Write(content);

                return picture;

            }
            catch
            {

                throw;
            }

        }




    }
}
