using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using HETraceSystem.Utils;
using MDL;
using COMM;
using DAL;


namespace HETraceSystem
{
    public partial class OutFileDlg : Form
    {
        #region Fields

        private ProductMDL product = null;

        private CodeType codeType = CodeType.BarCode;

        private List<PrintLogMDL> printLogs = new List<PrintLogMDL>();


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

        private string strOutPath = string.Empty;
        
        #endregion



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





        public OutFileDlg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
                //this.txtCount.Text = "4";
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

            this.progressBar1.Value = _nvalue;
            this.lbPrintStatus.Text = _strInfo;
            this.Refresh();
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

                if (this.pause)
                {

                    if (!StopOutPutThread())
                        return;
                }

                //   this.Close();
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

                if (this.txtPath.Text == null || this.txtPath.Text.Length < 1)
                {
                    MessageBox.Show("请选择导出路径！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    if (!Directory.Exists(this.txtPath.Text))
                    {
                        MessageBox.Show("选择的路径不存在！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
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

                strOutPath = this.txtPath.Text.Trim();
                SetControlButton(true);

                printThread = new Thread(new ThreadStart(DoOutPutThread));
                printThread.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 打印线程
        /// </summary>
        private void DoOutPutThread()
        {
            try
            {

                processed = true;

                startseq = Convert.ToInt32(txtStart.Text.Trim());
                endSeq = Convert.ToInt32(txtEnd.Text.Trim());


                if (startseq > endSeq)
                {
                    MessageBox.Show("结束编号必须大于起始编号，请重新填写。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStart.Text = "";
                    txtStart.Focus();
                    return;
                }

                int count = endSeq - startseq;


                if (printLogs != null)
                {
                    printLogs.Clear();
                    printLogs.TrimExcess();
                    printLogs = new List<PrintLogMDL>();
                }

                printLogs = new List<PrintLogMDL>();


                for (int i = 0; i < count; i++)
                {

                    PrintLogMDL mdl = new PrintLogMDL();


                    mdl.SN = COMM.Utils.GetSN(startseq + i, product.PCID);
                    mdl.PRINT_TYPE = this.codeType;
                    mdl.PRINT_DATE = DateTime.Now;

                    mdl.USERID = "test";
                    mdl.DEVICE_ID = "QRCode";

                    printLogs.Add(mdl);
                }

                if (MessageBox.Show(String.Format("您将导出二维码产品{0},序号{1}-{2}的{3}", product.Name, startseq, endSeq,
                                                  COMM.Utils.GetCodeType(this.codeType)), "提示",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                {
                    return;
                }

                _nvalue = 0;




                this.div = Convert.ToDouble(String.Format("{0:F2}", (double)100 / (double)(endSeq - startseq)));

                PrintLogDAL printLogDal = new PrintLogDAL();

                string tempFile =String.Format("{0}\\img\\{1}", SystemUtils.ApplicationPath,"QRCodeTemp.bmp");

                string destFile = String.Empty;

                for (int l = 0; l < printLogs.Count; l++)
                {

                    if (pause)
                        continue;
           
                    destFile=string.Format("{0}\\{1}\\{2}.bmp",strOutPath,printLogs[l].SN,printLogs[l].SN);


                    Bitmap qrCode = HETraceSystem.Utils.ImgConvert.CreateQRCode(200, 200, printLogs[l].SN);

                    if (!HETraceSystem.Utils.ImgConvert.QRCodeConvert(tempFile, destFile,800,600,
                                                                     300, 220, qrCode))
                    {
                        MessageBox.Show("导出" + printLogs[l].SN + "失败！", "提示",
                                           MessageBoxButtons.OK, MessageBoxIcon.Information);

                        continue;
                    }

                    if (ckBoxRecord.Checked)
                    {
                        Thread.Sleep(100);
                        //插入打印项
                        printLogs[l].SEQID = COMM.CodeComm.GetRandomSeqNum("PRINT") + String.Format("{0:d6}", l);



                        if (printLogDal.InsertPrintItem(printLogs[l]) > 0)
                        {
                            _nvalue = (int)(l * this.div);
                            _strInfo = String.Format(" 导出{0}成功！", printLogs[l].SN);
                            DoRefreshStatusBar();
                        }
                        else
                        {

                            _strInfo = String.Format("导出{0}失败！", printLogs[l].SN);
                            //检查打印机
                        }
                    }
                    else
                    {

                        _nvalue = (int)(l * this.div);
                        _strInfo = String.Format("导出{0}成功！", printLogs[l].SN);
                        DoRefreshStatusBar();

                    }

                }


                _nvalue = 100;
                _strInfo = "导出完成";
                DoRefreshStatusBar();
                processed = false;

                MessageBox.Show(String.Format("您导出二维码{0},序号{1}-{2}的{3}已完成！", product.Name, startseq, endSeq,
                                                  COMM.Utils.GetCodeType(this.codeType)), "提示",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "提示",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {

               SetControlButton(false);

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
                        this.btOutPut.Enabled = false;
                        this.btStop.Enabled = true;
                    }
                    else
                    {
                        this.btOutPut.Enabled = true;
                        this.btStop.Enabled = false;
                    }
                }
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
                DoOutPutThread();
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

            LoadProuctInfo();

        }

        private void btCancel_Click(object sender, EventArgs e)
        {

            if(this.pause)
            {

                if (!StopOutPutThread())
                    return;
            }


            this.Close();
        }




        private bool StopOutPutThread()
        {

            try
            {


                if (this.printThread == null)
                    return  false;

                this.printThread.Suspend();

                if (MessageBox.Show("确定要停止打印吗", "提示",
                                     MessageBoxButtons.OKCancel,
                                     MessageBoxIcon.Information) == DialogResult.OK)
                {
                    pause = true;

                    printLogs.Clear();
                    printLogs.TrimExcess();
                    this.printThread.Abort();

                    return true;

                   
                }

                this.printThread.Resume();

                return false;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message.ToString());

                return false;
            }
            finally
            {
                pause = false;
            }
        }
        private void btStop_Click(object sender, EventArgs e)
        {

            StopOutPutThread();

        }

        private void btSelectFile_Click(object sender, EventArgs e)
        {
            try
            {
                Vista_Api.FolderBrowserDialog dlg = new Vista_Api.FolderBrowserDialog();


                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.txtPath.Text = dlg.SelectedPath;
 
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
