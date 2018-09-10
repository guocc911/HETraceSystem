using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Threading;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MDL;
using COMM;
using DAL;
using HETraceSystem.Utils;


namespace HETraceSystem
{
    public partial class DeliveryDlg : Form
    {
        #region Fields

        private ProductMDL product = null;

        private CodeType codeType = CodeType.BarCode;

        private List<PrintLogMDL> printLogs = new List<PrintLogMDL>();

        private DeviceInfo printerInfo;

        private int linkStatus = 0;

        private int startseq = 1 ;

        private int endSeq = 100;

        private string _strInfo;

        public int _nvalue;

        private double div = 0.0;


        private bool pause = false;


        private bool processed = false;


        private delegate void DelegateSetVlaue();

        private delegate void DelegateChangeProcess(bool stop);


        private Thread printThread = null;


        private object printLock = new object();


        private PrintPOSTEK printBarCode;
        
        #endregion



        public DeviceInfo PrintInfo
        {
            get { return printerInfo; }
            set { printerInfo = value; }
        }


        public ProductMDL ProductInfo
        {
            get { return product; }
            set { product = value; }
        }


        public CodeType CodeType
        {
            get { return codeType; }
            set { codeType = value; }
        }
       
        

        public DeliveryDlg()
        {
            InitializeComponent();
        }



        private void InitalPrintInfo(bool hasError)
        {
            this.lbPrintInfo.Text = printerInfo.Name;
            //this.lbCodeType.Text="产品条码";


            switch(codeType)
            {
                case CodeType.QRRcode:
                 this.lbPrintType.Text = COMM.Utils.GetCodeType(codeType);
                label7.Visible = false;
                txtCount.Visible = false;
                this.txtOffset.Text = printerInfo.QROffsetX.ToString();

                this.txtOffsetY.Text = "1";
                    break;
                case CodeType.BarCode:
                    this.lbPrintType.Text = COMM.Utils.GetCodeType(codeType);
                this.txtOffset.Text = printerInfo.BarOffsetX.ToString();

                this.txtOffsetY.Text = "1";
                    break;
                case CodeType.QRRcode2:
                         label7.Visible = false;
                txtCount.Visible = false;
                this.lbPrintType.Text = COMM.Utils.GetCodeType(codeType);
                this.txtOffset.Text = printerInfo.BarOffsetX.ToString();

                this.txtOffsetY.Text = "1";
                    break;
                default:
                    break;


            }
          

            if (hasError)
            {
                this.lbError.Visible = false;

                this.lbError.Text = string.Empty;
            }
            else
            {
                this.lbError.Visible = true;
                this.lbError.Text = "连接打印机失败"; 

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (PrintPOSTEK.TestConnection(printerInfo.Name))
                {

                    MessageBox.Show("打印机已连接！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    linkStatus = 1;
                    InitalPrintInfo(true);
                }
                else
                {
                    MessageBox.Show("连接打印机失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    linkStatus = 0;
                    InitalPrintInfo(false);
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 加载产品信息
        /// </summary>
        private void LoadProuctInfo()
        {
            try
            {
                this.lbSN.Text = this.product.Name;
                this.lbCodeType.Text =COMM.Utils.GetCodeType( codeType);
                this.txtStart.Text =startseq.ToString();
                this.txtEnd.Text = endSeq.ToString();
                this.txtCount.Text = "4";
                double split = 100 / (endSeq - startseq);
                this.div = Convert.ToDouble(String.Format("{0:F}", split)); ;
                processed = false;
            }
            catch 
            {
                throw;
            }
        }


        /// <summary>
        /// 更新状态
        /// </summary>
        private void DoRefreshStatusBar()
        {
            if (this.InvokeRequired)
                this.Invoke(new DelegateSetVlaue(RefreshValue));
            else
            {
                this.progressBar1.Value=_nvalue;
                this.lbPrintStatus.Text = _strInfo;
  
                this.Refresh();
            }
        }



        /// <summary>
        /// 更新进度条数据
        /// </summary>
        private void RefreshValue()
        {
            try
            {
                this.progressBar1.Value = _nvalue;
                this.lbPrintStatus.Text = _strInfo;
                this.Refresh();
            }
            catch { }
        }




        private void PausePrint(bool stop)
        {
            //if(stop)
            //pause = true;
            //this.btStop.Text = "继续";

        }


        private void ContinuePrint()
        {
            pause = false;
            this.btStop.Text = "停止";
        }

        private void lbError_Click(object sender, EventArgs e)
        {

        }

        private void DeliveryDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确实要关闭该窗口吗！", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {

                e.Cancel = false;
                if (codeType == CodeType.BarCode)
                    this.printerInfo.BarOffsetX = Convert.ToDouble(this.txtOffset.Text.Trim());
                else
                {
                    double offsetX =0.0;
                    Double.TryParse(this.txtOffset.Text.Trim(), out offsetX);
                    this.printerInfo.QROffsetX = offsetX;
                }
              
                if (this.pause)
                {

                   if (!StopPrintThread())
                        return;
                }

            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btPrintCOde_Click(object sender, EventArgs e)
        {
            try
            {

                if (linkStatus <1)
                {
                    MessageBox.Show("请连接打印机！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.txtStart.Text == null || this.txtStart.Text.Length < 1)
                {
                    MessageBox.Show("请填写起始编号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.txtEnd.Text == null || this.txtEnd.Text.Length < 1)
                {
                    MessageBox.Show("请填写结束编号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.txtCount.Text == null || this.txtCount.Text.Length < 1)
                {
                    MessageBox.Show("请填编号份数！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                SetControlButton(true);
                //DoPrintThread();
                //SetControlButton(false);

                printThread =  new Thread(new ThreadStart(DoPrintThread));
                printThread.Start();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void SetControlButton(bool bStart)
        {
            try
            {
                if (this.InvokeRequired)
                {

                    this.Invoke(new DelegateChangeProcess(SetControlButton), new object[] { bStart });
                }
                else
                {

                    if (bStart)
                    {
                        this.btPrintCOde.Enabled = false;
                        this.btStop.Enabled = true;
                    }
                    else
                    {
                        this.btPrintCOde.Enabled = true;
                        this.btStop.Enabled = false;
                    }
                }
            }
            catch
            {
                throw;

            }
        }

        /// <summary>
        /// 打印线程
        /// </summary>
        private void DoPrintThread()
        {
            processed = true;

            printBarCode = new PrintPOSTEK(this.printerInfo.Name);

            try
            {
                startseq = Convert.ToInt32(txtStart.Text.Trim());
                endSeq = Convert.ToInt32(txtEnd.Text.Trim());


                if (startseq > endSeq)
                {
                    MessageBox.Show("结束编号必须大于起始编号，请重新填写。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStart.Text = "";
                    txtStart.Focus();
                    return;
                }

                if (printLogs != null)
                {
                    printLogs.Clear();
                    printLogs.TrimExcess();
                    printLogs = new List<PrintLogMDL>();
                }

                printLogs = new List<PrintLogMDL>();


                for (int i = startseq; i <= endSeq; i++)
                {
                    lock (printLock)
                    {
                        if (codeType != CodeType.TboxBarCode)
                        {
                            PrintLogMDL mdl = new PrintLogMDL();
                            mdl.SN = COMM.Utils.GetSN(i, product.PCID);
                            mdl.PRINT_TYPE = this.codeType;
                            mdl.PRINT_DATE = DateTime.Now;
                            mdl.COUNT = Convert.ToInt32(this.txtCount.Text.Trim());
                            mdl.USERID = "test";
                            mdl.DEVICE_ID = "ID";

                            printLogs.Add(mdl);
                        }
                        else
                        {
                            ExInventoryItemDAL dal = new ExInventoryItemDAL();
                            ExInventoryItemMDL ctMdl = dal.GetInventoryItem(COMM.Utils.GetSN(i, product.PCID));

                            if (ctMdl == null)
                                continue;

                            PrintLogMDL mdl = new PrintLogMDL();
                            mdl.SN = ctMdl.SN;
                            mdl.PRINT_TYPE = this.codeType;
                            mdl.PRINT_DATE = DateTime.Now;
                            mdl.COUNT = Convert.ToInt32(this.txtCount.Text.Trim());
                            mdl.USERID = "test";
                            mdl.DEVICE_ID = ctMdl.IMEI;

                            printLogs.Add(mdl);

                        }
                    }

                }

                if (MessageBox.Show(String.Format("您将打印产品{0},序号 {1}---{2}的 {3}", product.Name, startseq, endSeq,
                                                  COMM.Utils.GetCodeType(this.codeType)), "提示",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                {
                    return;
                }

                _nvalue = 0;

                this.div = Convert.ToDouble(String.Format("{0:F2}", (double)100 / (double)(endSeq - startseq)));

                //PrintLogDAL printLogDal = new PrintLogDAL();

            

                if (!printBarCode.OpenPort())
                {
                    MessageBox.Show("打开打印机失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                 ////
                //printBarCode.InitalPrintPar(40, 45, 2, 70, PrintPOSTEK.DotUnit300);

                //printBarCode.offsetX = 22;

                //printBarCode.offsetY = 22;
                int startX = 0;
                int offsetY = 1;
                int startY = offsetY * 4;


                switch (this.codeType)
                {
                    case CodeType.BarCode:
                          InitalBarCode1X4();
                        break;
                    case CodeType.QRRcode:
                          InitialQRCode();
                        break;
                    case CodeType.QRRcode2:
                          InitialQRCode2();
                        break;
                    case CodeType.TboxBarCode:
                          InitalTboxBarCode();

                        break;
                    default:
                        break;
                }


                 //if (this.codeType == CodeType.BarCode)
                 //    InitalBarCode1X4();
                 //else
                 //    IntialQRCode();


                //1毫米起始位置
               // int startY = 11;
      

                Int32.TryParse(this.txtOffsetY.Text.Trim(), out offsetY);

            


                for (int l = 0; l < printLogs.Count; l++)
                {

                    if (pause)
                        continue;

                    lock (printLock)
                    {

                        switch(this.codeType)
                        {

                            case CodeType.TboxBarCode:

                                PrintTboxBarCode(startY, printLogs[l].SN, printLogs[l].DEVICE_ID, "分时租赁控制终端", Convert.ToInt32(this.txtCount.Text.Trim()));

                                break;
                            case CodeType.BarCode:

                                PrintBarCode1X4(startY, printLogs[l], l);

                                break;
                            case CodeType.QRRcode:
                             Thread.Sleep(1000);
                             startX = 90;
                             startY = 880;
                             //startX += Convert.ToInt32(this.txtOffset.Text.Trim());
                             Point qrLoc = new Point(startX, startY);

                              PrintQRCode(qrLoc, printLogs[l], l);
                                break;
                            case CodeType.QRRcode2:
                               
                             Thread.Sleep(1000);

                             startX = 657;
                             startY = 180;

                             Point qr2Loc = new Point(startX, startY);

                             PrintQRCode2(qr2Loc, printLogs[l], l);

                                break;
                            default:
                                break;

                        }


                        //if (this.codeType == CodeType.BarCode)
                        //{
                        //    PrintBarCode1X4(startY, printLogs[l], l);

                        //    // PrintBarCode1X1(startY, printLogs[l], l);
                        //}
                        //else
                        //{
                        //    Thread.Sleep(1000);
                        //    startX = 90;
                        //    startY = 880;
                        //    //startX += Convert.ToInt32(this.txtOffset.Text.Trim());
                        //    Point qrLoc = new Point(startX, startY);

                        //    PrintQRCode(qrLoc, printLogs[l], l);

                        //    //打印类型二条码
                        //  // Point qrLoc = new Point(95, 772);
                        // //   Point qrLoc = new Point(772, 50);
                        ////    PrintQRCode2V(qrLoc, printLogs[l], l);
                        //}

                    }

                }


                _nvalue = 100;
                _strInfo = "打印完成";
                DoRefreshStatusBar();
                processed = false;

                MessageBox.Show(String.Format("您打印产品{0},序号{1}-{2}的{3}已完成！", product.Name, startseq, endSeq,
                                                  COMM.Utils.GetCodeType(this.codeType)), "提示",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch
            {
                throw;
            }
            finally
            {

                pause = false;
                SetControlButton(false);
                printBarCode.ClosePort();
            }

        }


        private void InitalBarCode1X4()
        {
            try
            {
                printBarCode.InitalPrintPar(40, 45, 2, 70, PrintPOSTEK.DotUnit300);

                double offsetX = Convert.ToDouble(txtOffset.Text) / PrintPOSTEK.DotUnit300;

                printBarCode.offsetX = (uint)offsetX;


                double offsetY = Convert.ToDouble(txtOffsetY.Text) / PrintPOSTEK.DotUnit300;
                //int startY = offsetY * 2;
                //0.5毫米
               // printBarCode.offsetY = startY;
                printBarCode.offsetY = (uint)offsetY;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        }


        private void InitalBarCodeTbox01()
        {
            try
            {
                printBarCode.InitalPrintPar(40, 45, 2, 70, PrintPOSTEK.DotUnit300);

                double offsetX = Convert.ToDouble(txtOffset.Text) / PrintPOSTEK.DotUnit300;

                printBarCode.offsetX = (uint)offsetX;


                double offsetY = Convert.ToDouble(txtOffsetY.Text) / PrintPOSTEK.DotUnit300;
                //int startY = offsetY * 2;
                //0.5毫米
                // printBarCode.offsetY = startY;
                printBarCode.offsetY = (uint)offsetY;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        }


        private void InitalTboxBarCode()
        {
            try
            {
                printBarCode.InitalPrintPar(20, 45, 2, 100, PrintPOSTEK.DotUnit300);

                double offsetX = Convert.ToDouble(txtOffset.Text) / PrintPOSTEK.DotUnit300;

                printBarCode.offsetX = (uint)offsetX;


                double offsetY = Convert.ToDouble(txtOffsetY.Text) / PrintPOSTEK.DotUnit300;
                //int startY = offsetY * 2;
                //0.5毫米
                // printBarCode.offsetY = startY;
                printBarCode.offsetY = (uint)offsetY;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        }


        private void InitialQRCode()
        {
            try
            {

                printBarCode.InitalPrintPar(115, 45, 2, 0, PrintPOSTEK.DotUnit300);

                // printBarCode.offsetX = 22;
                double offsetX = Convert.ToDouble(txtOffset.Text) / PrintPOSTEK.DotUnit300;
                //默认372
                printBarCode.offsetX = (uint)offsetX;

               // double offsetY = Convert.ToDouble(txtOffsetY.Text) / PrintPOSTEK.DotUnit300;
               // printBarCode.offsetY = (uint)offsetY;
                //1毫米
                printBarCode.offsetY = 6;
               

            }
            catch(Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        }


        private void InitialQRCode2()
        {
            try
            {

                printBarCode.InitalPrintPar(61, 101, 2, 0, PrintPOSTEK.DotUnit300);

                // printBarCode.offsetX = 22;
                double offsetX = Convert.ToDouble(txtOffset.Text) / PrintPOSTEK.DotUnit300;
                //默认372
                printBarCode.offsetX = (uint)offsetX;

                // double offsetY = Convert.ToDouble(txtOffsetY.Text) / PrintPOSTEK.DotUnit300;
                // printBarCode.offsetY = (uint)offsetY;
                //1毫米
                printBarCode.offsetY = 6;


            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message);
            }
        }



        /// <summary>
        /// 答应1*1条码
        /// </summary>
        /// <param name="startY"></param>
        /// <param name="mdl"></param>
        /// <param name="index"></param>
        private void PrintBarCode1X1(int startY,PrintLogMDL mdl,int index)
        {
            PrintLogDAL printLogDal = new PrintLogDAL();

            for (int t = 0; t < mdl.COUNT; t++)
            {

                if (pause)
                    continue;

                if (printBarCode.PrintBarCode((uint)startY, mdl.SN, t))
                {
                    if (ckBoxRecord.Checked)
                    {


                        //插入打印项
                        mdl.SEQID = COMM.CodeComm.GetRandomSeqNum("PRINT") + String.Format("{0:d6}", index);

                        if (printLogDal.InsertPrintItem(mdl) > 0)
                        {
                            _nvalue = (int)(index * this.div);
                            _strInfo = String.Format("打印{0}成功！", mdl);
                            DoRefreshStatusBar();
                        }
                        else
                        {
                            _strInfo = String.Format("打印{0}失败！", mdl);
                            //检查打印机
                        }
                    }
                    else
                    {

                        _nvalue = (int)(index * this.div);
                        _strInfo = String.Format("打印{0}成功！", mdl);
                        DoRefreshStatusBar();

                    }
                }
                else
                {
                    _strInfo = String.Format("打印{0}失败！", mdl);

                    DoRefreshStatusBar();
                    break;
                }


                Thread.Sleep(3000);
            }
        }

        /// <summary>
        /// 打印1*4 条码
        /// </summary>
        /// <param name="startY"></param>
        /// <param name="mdl"></param>
        /// <param name="index"></param>
        private void  PrintBarCode1X4(int startY,PrintLogMDL mdl,int index)
        {

            try
            {
                PrintLogDAL printLogDal = new PrintLogDAL();

                if (printBarCode.PrintBarCodeX4((uint)startY, mdl.SN, 4))
                {

                    if (ckBoxRecord.Checked)
                    {

                        //插入打印项
                        mdl.SEQID = COMM.CodeComm.GetRandomSeqNum("PRINT") + String.Format("{0:d6}", index);

                        if (printLogDal.InsertPrintItem(mdl) > 0)
                        {
                            _nvalue = (int)(index * this.div);
                            _strInfo = String.Format("打印{0}成功！", mdl.SN);
                            DoRefreshStatusBar();
                        }
                        else
                        {
                            _strInfo = String.Format("打印{0}失败！", mdl.SN);
                          
                            //检查打印机
                        }
                    }
                    else
                    {

                        _nvalue = (int)(index * this.div);
                        _strInfo = String.Format("打印{0}成功！", mdl.SN);
                        DoRefreshStatusBar();

                    }

                  
                }
                else
                {
                    _strInfo = String.Format("打印{0}失败！", mdl.SN);

                    DoRefreshStatusBar();
                 
                }


                Thread.Sleep(3000);
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="mdl"></param>
        /// <param name="index"></param>
         private void PrintTboxQRCode(Point location, PrintLogMDL mdl, int index)
        {
            try
            {

                string logName = "QRCodeTbox.bmp";

                string tempFile = String.Format("{0}\\img\\{1}", SystemUtils.ApplicationPath, "QRCodeTbox.bmp");

                string destFile = string.Format("{0}\\QRCodeTbox.bmp", SystemUtils.ApplicationPath);

                // string destFile = "C:\\Temp\\QR.pcx";

                FileInfo info = new FileInfo(destFile);

                PrintLogDAL printLogDal = new PrintLogDAL();

                if (!Directory.Exists(info.DirectoryName))
                    Directory.CreateDirectory(info.DirectoryName);

                if (File.Exists(destFile))
                    File.Delete(destFile);

                Bitmap qrCode = HETraceSystem.Utils.ImgConvert.CreateQRCode(320, 320, mdl.SN);

                if (!HETraceSystem.Utils.ImgConvert.DrawQRCodeBmp2(tempFile, destFile, qrCode, location, mdl.SN))
                {

                    _nvalue = (int)(index * this.div);
                    _strInfo = String.Format(" 打印{0}失败！", mdl.SN);
                    DoRefreshStatusBar();
                    return;
                }
                else
                {

                    int offsetY = 1;

                    Int32.TryParse(txtOffsetY.Text.Trim(), out offsetY);

                    int destY = offsetY * 6;
                    int destX = 50;

                    destX += Convert.ToInt32(this.txtOffset.Text.Trim());

                    Point pos = new Point(destX, destY);

                    //打印二维码
                    if (!printBarCode.PrintQRCodePXC(pos, logName))
                    {
                        _nvalue = (int)(index * this.div);
                        _strInfo = String.Format(" 打印{0}失败！", mdl.SN);
                        DoRefreshStatusBar();
                        return;
                    }

                    if (ckBoxRecord.Checked)
                    {
                        Thread.Sleep(100);
                        //插入打印项
                        mdl.SEQID = COMM.CodeComm.GetRandomSeqNum("PRINT") + String.Format("{0:d6}", index);


                        if (printLogDal.InsertPrintItem(mdl) > 0)
                        {
                            _nvalue = (int)(index * this.div);
                            _strInfo = String.Format(" 打印{0}成功！", mdl.SN);
                            DoRefreshStatusBar();
                        }
                        else
                        {

                            _strInfo = String.Format("打印{0}失败！", mdl.SN);
                            //检查打印机
                        }
                    }
                    else
                    {

                        _nvalue = (int)(index * this.div);
                        _strInfo = String.Format("打印{0}成功！", mdl.SN);
                        DoRefreshStatusBar();

                    }

                }

                Thread.Sleep(1000);
            }
            catch
            {
                throw;
            }
        }


        private void PrintQRCode2(Point location, PrintLogMDL mdl, int index)
        {
            try
            {

                string logName = "QRCodeTagBig.bmp";

                string tempFile = String.Format("{0}\\img\\{1}", SystemUtils.ApplicationPath, "QRCodeTagBig.bmp");

                string destFile = string.Format("{0}\\QRCodeTagBig.bmp", SystemUtils.ApplicationPath);

                // string destFile = "C:\\Temp\\QR.pcx";

                FileInfo info = new FileInfo(destFile);

                PrintLogDAL printLogDal = new PrintLogDAL();

                if (!Directory.Exists(info.DirectoryName))
                    Directory.CreateDirectory(info.DirectoryName);

                if (File.Exists(destFile))
                    File.Delete(destFile);

                Bitmap qrCode = HETraceSystem.Utils.ImgConvert.CreateQRCode(320, 320, mdl.SN);

                if (!HETraceSystem.Utils.ImgConvert.DrawQRCodeBmp2(tempFile, destFile, qrCode, location, mdl.SN))
                {

                    _nvalue = (int)(index * this.div);
                    _strInfo = String.Format(" 打印{0}失败！", mdl.SN);
                    DoRefreshStatusBar();
                    return;
                }
                else
                {

                    int offsetY = 1;

                    Int32.TryParse(txtOffsetY.Text.Trim(), out offsetY);

                    int destY = offsetY * 6;
                    int destX = 50;

                    destX += Convert.ToInt32(this.txtOffset.Text.Trim());

                    Point pos = new Point(destX, destY);

                    //打印二维码
                    if (!printBarCode.PrintQRCodePXC(pos, logName))
                    {
                        _nvalue = (int)(index * this.div);
                        _strInfo = String.Format(" 打印{0}失败！", mdl.SN);
                        DoRefreshStatusBar();
                        return;
                    }

                    if (ckBoxRecord.Checked)
                    {
                        Thread.Sleep(100);
                        //插入打印项
                        mdl.SEQID = COMM.CodeComm.GetRandomSeqNum("PRINT") + String.Format("{0:d6}", index);


                        if (printLogDal.InsertPrintItem(mdl) > 0)
                        {
                            _nvalue = (int)(index * this.div);
                            _strInfo = String.Format(" 打印{0}成功！", mdl.SN);
                            DoRefreshStatusBar();
                        }
                        else
                        {

                            _strInfo = String.Format("打印{0}失败！", mdl.SN);
                            //检查打印机
                        }
                    }
                    else
                    {

                        _nvalue = (int)(index * this.div);
                        _strInfo = String.Format("打印{0}成功！", mdl.SN);
                        DoRefreshStatusBar();

                    }

                }

                Thread.Sleep(1000);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 打印40*100 二维码标签
        /// </summary>
        /// <param name="location"></param>
        /// <param name="mdl"></param>
        /// <param name="index"></param>
        private void PrintQRCode(Point location ,PrintLogMDL mdl,int index)
        {
            try
            {

                string logName = "QRCodeTag.bmp";

                string tempFile = String.Format("{0}\\img\\{1}", SystemUtils.ApplicationPath, "QRCodeTag.bmp");

                string destFile = string.Format("{0}\\QRCodeTag.bmp", SystemUtils.ApplicationPath);

               // string destFile = "C:\\Temp\\QR.pcx";

                FileInfo info=new FileInfo(destFile);

                PrintLogDAL printLogDal = new PrintLogDAL();

                if(!Directory.Exists(info.DirectoryName))
                  Directory.CreateDirectory(info.DirectoryName);

                if (File.Exists(destFile))
                    File.Delete(destFile);

                Bitmap qrCode = HETraceSystem.Utils.ImgConvert.CreateQRCode(360, 360, mdl.SN);

                if (!HETraceSystem.Utils.ImgConvert.DrawQRCodeBmp(tempFile, destFile, qrCode, location, mdl.SN))
                {

                    _nvalue = (int)(index * this.div);
                    _strInfo = String.Format(" 打印{0}失败！", mdl.SN);
                    DoRefreshStatusBar();
                    return;
                }
                else 
                {

                    int offsetY = 1;

                    Int32.TryParse(txtOffsetY.Text.Trim(), out offsetY);

                    int destY= offsetY * 4;
                    int destX = 23;

                    destX+=Convert.ToInt32(this.txtOffset.Text.Trim());

                    Point pos = new Point(destX, destY);
                   
                    //打印二维码
                    if (!printBarCode.PrintQRCodePXC(pos, logName))
                    {
                        _nvalue = (int)(index * this.div);
                        _strInfo = String.Format(" 打印{0}失败！", mdl.SN);
                        DoRefreshStatusBar();
                        return;
                    }

                     if(ckBoxRecord.Checked)
                       {
                            Thread.Sleep(100);
                            //插入打印项
                            mdl.SEQID = COMM.CodeComm.GetRandomSeqNum("PRINT") + String.Format("{0:d6}", index);


                            if (printLogDal.InsertPrintItem(mdl) > 0)
                            {
                                _nvalue = (int)(index * this.div);
                                _strInfo = String.Format(" 打印{0}成功！", mdl.SN);
                                DoRefreshStatusBar();
                            }
                            else
                            {

                                _strInfo = String.Format("打印{0}失败！", mdl.SN);
                                //检查打印机
                            }
                        }
                        else
                        {

                            _nvalue = (int)(index * this.div);
                            _strInfo = String.Format("打印{0}成功！", mdl.SN);
                            DoRefreshStatusBar();

                        }
                   
                 }

                Thread.Sleep(1000);
              }
              catch
              {
                 throw;
             }
        }

        private void PrintTboxBarCode(int startY, string sn,string imei, string title,int count)
        {
            try
            {

                if (printBarCode.PrintBarCode((uint)startY, sn, imei, title, count))
                {

                    _strInfo = String.Format("打印{0}成功！", sn);
                }
                else
                {
                    _strInfo = String.Format("打印{0}失败！", sn);
                }
                Thread.Sleep(1000);
            }
            catch
            {
                throw;
            }

        }


        /// <summary>
        /// 打印60*100二维码标签
        /// </summary>
        /// <param name="location"></param>
        /// <param name="mdl"></param>
        /// <param name="index"></param>
        private void PrintQRCode2V(Point location, PrintLogMDL mdl, int index)
        {
            try
            {
                string tempFile = String.Format("{0}\\img\\{1}", SystemUtils.ApplicationPath, "QRCodeV.bmp");

                string destFile = string.Format("{0}\\QRCodeTag.bmp", SystemUtils.ApplicationPath);

                // string destFile = "C:\\Temp\\QR.pcx";

                FileInfo info = new FileInfo(destFile);

                PrintLogDAL printLogDal = new PrintLogDAL();

                if (!Directory.Exists(info.DirectoryName))
                    Directory.CreateDirectory(info.DirectoryName);

                if (File.Exists(destFile))
                    File.Delete(destFile);

                Bitmap qrCode = HETraceSystem.Utils.ImgConvert.CreateQRCode(520, 520, mdl.SN);
                
                qrCode.RotateFlip(RotateFlipType.Rotate270FlipXY);

                if (!HETraceSystem.Utils.ImgConvert.DrawQRCodeBmpV(tempFile, destFile, qrCode, location, mdl.SN))
                {

                    _nvalue = (int)(index * this.div);
                    _strInfo = String.Format(" 打印{0}失败！", mdl.SN);
                    DoRefreshStatusBar();
                    return;
                }
                else
                {
                    Point pos = new Point(11, 0);

                    //打印二维码
                    if (!printBarCode.PrintQRCodePXC(pos, destFile))
                    {
                        _nvalue = (int)(index * this.div);
                        _strInfo = String.Format(" 打印{0}失败！", mdl.SN);
                        DoRefreshStatusBar();
                        return;
                    }

                    if (ckBoxRecord.Checked)
                    {
                        Thread.Sleep(100);
                        //插入打印项
                        mdl.SEQID = COMM.CodeComm.GetRandomSeqNum("PRINT") + String.Format("{0:d6}", index);



                        if (printLogDal.InsertPrintItem(mdl) > 0)
                        {
                            _nvalue = (int)(index * this.div);
                            _strInfo = String.Format(" 打印{0}成功！", mdl.SN);
                            DoRefreshStatusBar();
                        }
                        else
                        {

                            _strInfo = String.Format("打印{0}失败！", mdl.SN);
                            //检查打印机
                        }
                    }
                    else
                    {

                        _nvalue = (int)(index * this.div);
                        _strInfo = String.Format("打印{0}成功！", mdl.SN);
                        DoRefreshStatusBar();

                    }

                }

                Thread.Sleep(1000);
            }
            catch
            {
                throw;
            }
        }
        private void StartPrintThread()
        {
            try
            {
                DoPrintThread();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void txtStart_TextChanged(object sender, EventArgs e)
        {
            Match m = Regex.Match(this.txtStart.Text.Trim(), @"^[0-9]\d*\.\d{0,2}$|^\d*$");
            if (!m.Success)
            {

     
                MessageBox.Show("请填写正确的数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


           if (Convert.ToInt32(txtStart.Text.Trim())<0)
           {
                MessageBox.Show("起始编号不能等于或小于0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
        }

        private void txtEnd_TextChanged(object sender, EventArgs e)
        {
            Match m = Regex.Match(this.txtEnd.Text.Trim(), @"^[0-9]\d*\.\d{0,2}$|^\d*$");
            if (!m.Success)
            {
                MessageBox.Show("请填写正确的数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCount_TextChanged(object sender, EventArgs e)
        {
            Match m = Regex.Match(this.txtEnd.Text.Trim(), @"^[0-9]\d*\.\d{0,2}$|^\d*$");
            if (!m.Success)
            {
                MessageBox.Show("请填写正确的数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeliveryDlg_Load(object sender, EventArgs e)
        {
            try
            {


                if (PrintPOSTEK.TestConnection(printerInfo.Name))
                {
                    linkStatus = 1;
                    InitalPrintInfo(true);
                }
                else
                {
                    linkStatus = 0;
                    InitalPrintInfo(false);
                }


                LoadProuctInfo();
                SetControlButton(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (processed)
            {
                StopPrintThread();
                this.Close();
            }
            else
            {
                this.Close();
            }
          
        }




        private bool StopPrintThread()
        {
            try
            {

                if (this.printThread != null && this.printThread.IsAlive == true)
                {
                    this.printThread.Suspend();
                }

                if (MessageBox.Show("确定要停止打印吗", "提示",
                                     MessageBoxButtons.OKCancel,
                                     MessageBoxIcon.Information) == DialogResult.OK)
                {


                    pause = true;
                    Thread.Sleep(1000);
                    printLogs.Clear();
                    printLogs.TrimExcess();
                    if (printThread != null)
                    {
                        this.printThread.Abort();
                        this.printThread = null;
                    }
                    return true;
                }

                this.printThread.Resume();

                return false;
            }
            catch (ThreadAbortException ex)
            {
                return true;
                CLog.WriteErrLog(ex.Message.ToString());
            }
        }


        private void btStop_Click(object sender, EventArgs e)
        {

            try
            {
       
                if(StopPrintThread())
                   SetControlButton(false);
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message.ToString());
            }
            finally
            {
                pause = false;
                SetControlButton(false);
            }

        }

        private void headerPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtOffset_TextChanged(object sender, EventArgs e)
        {
            Match m1 = Regex.Match(this.txtOffset.Text.Trim(), @"^[0-9]\d*\.\d{0,2}$|^\d*$");
            Match m2 = Regex.Match(this.txtOffset.Text.Trim(), @"^-[0-9]*[1-9][0-9]*$");

            if ((m1.Success == false) && (m2.Success==false))
            {


                MessageBox.Show("请填写正确的数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

          

        }

        private void txtOffsetY_TextChanged(object sender, EventArgs e)
        {
            Match m = Regex.Match(this.txtOffsetY.Text.Trim(), @"^[0-9]\d*\.\d{0,2}$|^\d*$");

            if (!m.Success)
            {


                MessageBox.Show("请填写正确的数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
