using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Data;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using COMM;
namespace PileBurner.Utils
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

        public static bool QRCodeConvert(string tempFileName,string floderName ,string strFileName, int nWidth, int nHeight, int offsetX, int offsetY, Bitmap Qrcode)
        {
            try
            {

                Image tempImage = Image.FromFile(tempFileName);

                if (tempImage == null)
                    return false;

                using (Graphics temp = Graphics.FromImage(tempImage))
                {

                    Point pos = new Point(offsetX, offsetY);

                    temp.DrawImage(Qrcode, pos);
                }

                ///文件信息
               // FileInfo fInfo = new FileInfo(destFileName);

                if (Directory.Exists(floderName))
                {
                    Directory.Delete(floderName);
                }

                Directory.CreateDirectory(floderName);

                tempImage.Save(floderName + "\\" + strFileName, System.Drawing.Imaging.ImageFormat.Bmp);

                return true;
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
