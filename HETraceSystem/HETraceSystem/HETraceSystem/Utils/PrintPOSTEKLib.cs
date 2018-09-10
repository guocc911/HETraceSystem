using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;

namespace HETraceSystem.Utils
{
    public class PrintPOSTEK
    {
        public static double  DotUnit300=0.085;

        public static double  DotUnit203=0.125;


        private  bool pause = false;

        private string deviceName = String.Empty;

        public int lheight;

        public int lwidth;

        public uint lgraph;

        public uint offsetX;

        public uint offsetY;

        public uint barHeight;

        public uint count;


           
            

        public bool Pause
        {
            get { return pause; }
            set { pause = value; }
        }



        public string DeviceName
        {
            get { return deviceName; }
            set { deviceName = value; }
        }


        public PrintPOSTEK(string device)
        {
            this.deviceName = device;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool TestConnection(string deviceName)
        {

            bool ret=false;
            try
            {
              

              int status=  PrintLab.OpenPort(deviceName);

              status=PrintLab.PTK_ClearBuffer();

              PrintLab.ClosePort();


              if (status == 0)
              {
                  
                  ret = true;
              }
              else
              {
                  ret = false;
              }


              return ret;

            }
            catch 
            {
                throw;
            }

           
        }


        public bool OpenPort()
        {

            
            try
            {

                int ret=PrintLab.OpenPort(deviceName);//打开打印机端口

                if (ret == 0)
                    return true;
                else
                    return false;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="labHeight">条形码高度mm</param>
        /// <param name="labWidth">条形码宽度mm</param>
        /// <param name="labgraph">定位间隙mm</param>
        /// <param name="bHeight"> 条形码高度</param>
        /// <param name="dotUnit">换算单位 默认300dpi 0.085</param>
        /// <returns></returns>
        public bool InitalPrintPar(int labHeight, int labWidth, uint labgraph, uint bHeight, double dotUnit)
        {
            try
            {   int ret=-1;

                ret=PrintLab.PTK_ClearBuffer();           //清空缓冲区
                ret=PrintLab.PTK_SetPrintSpeed(4);        //设置打印速度
                ret=PrintLab.PTK_SetDarkness(10);         //设置打印黑度
              //  ret=PrintLab.PTK_SetDirection("B");
                lheight = (int)(labHeight/dotUnit);
                lwidth = (int)(labWidth/dotUnit);
                lgraph = (uint)(labgraph/dotUnit);

                barHeight = bHeight;

                ret = PrintLab.PTK_SetLabelHeight((uint)lheight, lgraph); //设置标签的高度和定位间隙\黑线\穿孔的高度
                ret = PrintLab.PTK_SetLabelWidth((uint)lwidth);      //设置标签的宽度

                if(ret==0)
                    return true;
                else
                    return false;


            }
            catch
            {
                throw;
            }
        }

         

        /// <summary>
        /// 打印1*4 bar code
        /// </summary>
        /// <param name="nStartY"></param>
        /// <param name="content"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool PrintBarCodeX4(uint nStartY,string content, int count)
        {
            try
            {
                int ret = -1;

                uint barOffsetY = 0;

                uint textOffsetY = 0;

                PrintLab.PTK_ClearBuffer();

                ///start Y coord
                //barOffsetY = offsetY+20;
                barOffsetY = offsetY + 15;

                for (int i = 1; i <= count; i++)
                {
                    ret = PrintLab.PTK_DrawBarcode(offsetX, barOffsetY, 0, "1", 3, 3, barHeight, 'N', content);

                    //text Y Coord
                    textOffsetY = barOffsetY + barHeight + 2;

                    //ret = PrintLab.PTK_DrawTextTrueTypeW((int)offsetX, (int)textOffsetY,
                    //                                      22, 0, "Arial", 1, 400,
                    //                                      false, false, false, "A2", 
                    //                                      String.Format("{0}-{1}", content, i));

                    ret = PrintLab.PTK_DrawTextTrueTypeW((int)offsetX, (int)textOffsetY,
                                                          22, 0, "Arial", 1, 400,
                                                          false, false, false, "A2",
                                                          content);
                    //4毫米 11dot约为 1毫米

                    barOffsetY = textOffsetY + 22 + 22;
                }

                ret = PrintLab.PTK_PrintLabel(1, 1);

                if (ret == 0)
                    return true;
                else
                    return false;

            }
            catch
            {
                throw;
            }
        }


        public bool PrintBarCode(uint nStartY, string sn,string imei, string title, int count)
        {
            try
            {
                int ret = -1;

                uint textOffsetY = 0;
                uint snOffsetY = 0;
                uint imeiOffsetY = 0;
                uint barOffsetY = 0;
              



                for (int i = 0; i < count; i++)
               
                {

                    ret = PrintLab.PTK_ClearBuffer();

                textOffsetY = offsetY;// + 2;

                ret = PrintLab.PTK_DrawTextTrueTypeW((int)offsetX, (int)textOffsetY, 28, 0, "Arial", 1, 400,
                                                     false, false, false, "A2", String.Format("{0}", title));

                snOffsetY = textOffsetY + 30;


                ret = PrintLab.PTK_DrawText((uint)offsetX, snOffsetY, 0, 2, 1, 1, 'N', String.Format("SN:{0}", sn));

                imeiOffsetY = snOffsetY + 30;// + 2;


                ret = PrintLab.PTK_DrawText((uint)offsetX, imeiOffsetY, 0, 2, 1, 1, 'N', String.Format("IMEI:{0}", imei));

                barOffsetY = imeiOffsetY + 30;// + 2;

                ret = PrintLab.PTK_DrawBarcode(offsetX, barOffsetY, 0, "1", 3, 3, barHeight, 'N', sn);

                textOffsetY = barOffsetY + barHeight + 2;

                ret = PrintLab.PTK_DrawText((uint)offsetX, textOffsetY, 0, 2, 1, 1, 'N', "畅的科技 版本号V0.1");

                //ret = PrintLab.PTK_DrawTextTrueTypeW((int)offsetX, (int)phoneOffsetY, 28, 0, "Arial", 1, 400,
                //                             false, false, false, "A2", String.Format("PHONE:{0}", phone));

                //ret = PrintLab.PTK_DrawBarcode(offsetX, offsetY, 0, "1", 3, 3, barHeight, 'N', content);

                //textOffsetY = offsetY + barHeight;// + 2;

                //ret = PrintLab.PTK_DrawTextTrueTypeW((int)offsetX, (int)textOffsetY, 28, 0, "Arial", 1, 400,
                //                                     false, false, false, "A2", String.Format("SN:{0}", content));

                //phoneOffsetY = textOffsetY + 30;


                //ret = PrintLab.PTK_DrawText((uint)offsetX, phoneOffsetY, 0, 2, 1, 1, 'N', String.Format("PHONE:{0}", phone));
                ////ret = PrintLab.PTK_DrawTextTrueTypeW((int)offsetX, (int)phoneOffsetY, 28, 0, "Arial", 1, 400,
                ////                             false, false, false, "A2", String.Format("PHONE:{0}", phone));
                ret = PrintLab.PTK_PrintLabel(1, 1);
                }
              

                if (ret == 0)
                    return true;
                else
                    return false;

            }
            catch
            {
                throw;
            }
        }

        public bool PrintBarCode(uint nStartY,string content,int index)
        {
            try
            {
                int ret = -1;

                uint textOffsetY=0;


                ret=PrintLab.PTK_ClearBuffer();

                ret=PrintLab.PTK_DrawBarcode(offsetX, offsetY, 0, "1", 3, 3, barHeight, 'N', content);

                textOffsetY = offsetY + barHeight;// + 2;

                ret = PrintLab.PTK_DrawTextTrueTypeW((int)offsetX, (int)textOffsetY, 22, 0, "Arial", 1, 400,
                                                     false, false, false, "A2", String.Format("{0}-{1}", content, index + 1));

                ret=PrintLab.PTK_PrintLabel(1, 1);

                if (ret == 0)
                    return true;
                else
                    return false;

            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// 绘制PCX文件
        /// </summary>
        /// <param name="location"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool PrintQRCodePXC(Point location, string FileName)
        {
            try
            {
                int ret = -1;

                ret = PrintLab.PTK_ClearBuffer();

                //ret = PrintLab.PTK_DrawTextTrueTypeW((int)offsetX, 20, 22, 0, "Arial", 1, 400,
                //                                     false, false, false, "A2", "test");
                // 打印PCX图片 方式一
                ret = PrintLab.PTK_PcxGraphicsDel("PCXA");
                ret = PrintLab.PTK_BmpGraphicsDownload("PCXA", FileName, 0);
                ret = PrintLab.PTK_DrawPcxGraphics(offsetX, (uint)location.Y, "PCXA");


                ret = PrintLab.PTK_PrintLabel(1, 1);

                if (ret == 0)
                    return true;
                else
                    return false;

            }
            catch
            {
                throw;
            }
        }



        public bool PrintQRCodePXC2(Point location, string FileName)
        {
            try
            {
                int ret = -1;

                ret = PrintLab.PTK_ClearBuffer();

                //ret = PrintLab.PTK_DrawTextTrueTypeW((int)offsetX, 20, 22, 0, "Arial", 1, 400,
                //                                     false, false, false, "A2", "test");
                // 打印PCX图片 方式一
                ret = PrintLab.PTK_PcxGraphicsDel("PCXA");
                ret = PrintLab.PTK_BmpGraphicsDownload("PCXA", FileName, 0);
                ret = PrintLab.PTK_DrawPcxGraphics(offsetX, (uint)location.Y, "PCXA");


                ret = PrintLab.PTK_PrintLabel(1, 1);

                if (ret == 0)
                    return true;
                else
                    return false;

            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 打印条码
        /// </summary>
        /// <param name="deviceName">设备名称</param>
        /// <param name="lanHeight">高度</param>
        /// <param name="labWidth">宽度</param>
        /// <param name="labgraph"></param>
        /// <param name="dotUnit"></param>
        /// <param name="offsetY"></param>
        /// <param name="barHeight"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public  static bool PrintBarCode(string deviceName, int labHeight, int labWidth, uint labgraph,
                                  double dotUnit, uint offsetX,uint offsetY, uint barHeight, 
                                  List<string> codes,uint nCount)
        {

          
            try
            {

                if (codes == null || codes.Count <= 0)
                    return false;


                uint lHeight = 0;
                uint lWidth = 0;
                uint nStartY = 0;

                PrintLab.OpenPort(deviceName);//打开打印机端口

                PrintLab.PTK_ClearBuffer();           //清空缓冲区
                PrintLab.PTK_SetPrintSpeed(4);        //设置打印速度
                PrintLab.PTK_SetDarkness(10);         //设置打印黑度

                lHeight =(uint)(labHeight * dotUnit);
                lWidth = (uint)(labWidth * dotUnit);

                PrintLab.PTK_SetLabelHeight(lWidth, labgraph); //设置标签的高度和定位间隙\黑线\穿孔的高度
                PrintLab.PTK_SetLabelWidth(lHeight);      //设置标签的宽度

                for (int i = 0; i < codes.Count; i++)
                {
                    nStartY = 0;


                    for (int l = 0; l < nCount;l++ )
                    {


                        PrintLab.PTK_DrawBarcode(offsetX, offsetY, 0, "1", 3, 3, barHeight, 'N', codes[i]);

                        nStartY += barHeight + 2;

                        PrintLab.PTK_DrawTextTrueTypeW((int)offsetX, (int)nStartY, 22, 0, "Arial", 1, 400,
                                                             false, false, false, "A2", String.Format("{0}=[{2}]", codes[i], l+1));
                        PrintLab.PTK_PrintLabel(1, 1);
                    }

                }


                PrintLab.ClosePort();//关闭打印机端口


                return true;
            }
            catch
            {

                throw;
 
            }
       
        }



        public void ClosePort()
        {
            try
            {

                PrintLab.ClosePort();//关闭打印机端口

            }
            catch(Exception ex)
            {
               
 
            }
        }

    }


    /// <summary>
    /// 打印库
    /// </summary>
    public class PrintLab
    {
        [DllImport("WINPSK.dll")]
        public static extern int OpenPort(string printname);
        [DllImport("WINPSK.dll")]
        public static extern int PTK_SetPrintSpeed(uint px);
        [DllImport("WINPSK.dll")]
        public static extern int PTK_SetDarkness(uint id);
        [DllImport("WINPSK.dll")]
        public static extern int ClosePort();
        [DllImport("WINPSK.dll")]
        public static extern int PTK_PrintLabel(uint number, uint cpnumber);
        [DllImport("WINPSK.dll")]
        public static extern int PTK_DrawTextTrueTypeW
                                            (int x, int y, int FHeight,
                                            int FWidth, string FType,
                                            int Fspin, int FWeight,
                                            bool FItalic, bool FUnline,
                                            bool FStrikeOut,
                                            string id_name,
                                            string data);
        [DllImport("WINPSK.dll")]
        public static extern int PTK_DrawBarcode(uint px,
                                        uint py,
                                        uint pdirec,
                                        string pCode,
                                        uint pHorizontal,
                                        uint pVertical,
                                        uint pbright,
                                        char ptext,
                                        string pstr);
        [DllImport("WINPSK.dll")]
        public static extern int PTK_DrawBarcodeEx(uint px,
                                        uint py,
                                        uint pdirec,
                                        string pCode,
                                        uint NarrowWidth,
                                        uint pHorizontal,
                                        uint pVertical,
                                        uint pbright,
                                        char ptext,
                                        string pstr);



        [DllImport("WINPSK.dll")]
        public static extern int PTK_SetLabelHeight(uint lheight, uint gapH);
        [DllImport("WINPSK.dll")]
        public static extern int PTK_SetLabelWidth(uint lwidth);
        [DllImport("WINPSK.dll")]
        public static extern int PTK_ClearBuffer();
        [DllImport("WINPSK.dll")]
        public static extern int PTK_DrawRectangle(uint px, uint py, uint thickness, uint pEx, uint pEy);
        [DllImport("WINPSK.dll")]
        public static extern int PTK_DrawLineOr(uint px, uint py, uint pLength, uint pH);
        [DllImport("WINPSK.dll")]
        public static extern int PTK_DrawBar2D_QR(uint x, uint y, uint w, uint v, uint o, uint r, uint m, uint g, uint s, string pstr);
        [DllImport("WINPSK.dll")]
        public static extern int PTK_DrawBar2D_Pdf417(uint x, uint y, uint w, uint v, uint s, uint c, uint px, uint py, uint r, uint l, uint t, uint o, string pstr);
        [DllImport("WINPSK.dll")]
        public static extern int PTK_PcxGraphicsDel(string pid);

        [DllImport("WINPSK.dll")]
        public static extern int PTK_SetDirection(string direct);

        [DllImport("WINPSK.dll")]
        public static extern int PTK_PcxGraphicsDownload(string pcxname, string pcxpath);
        [DllImport("WINPSK.dll")]
        public static extern int PTK_DrawPcxGraphics(uint px, uint py, string gname);

        [DllImport("WINPSK.dll")]
        public static extern int PTK_BmpGraphicsDownload(string pcxname, string pcxpath, int iDire);


        [DllImport("WINPSK.dll")]
        public static extern int PTK_DrawText(uint px, uint py, uint pdirec, uint pFont, uint pHorizontal, uint pVertical, char ptext, string pstr);


    }
}
