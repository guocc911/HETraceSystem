using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Input;
using COMM;
using PileBurner.Utils;
using PileBurner.Config;
using RawInput_dll;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace PileBurner
{
    public partial class MainForm : Form
    {


        private SerialPortPar portPar = null;

        private LocalSerialPort serialPort = null;

        private string strOutPath = @"C:\QRCode\";

        private COMM.DeviceInfo deviceinfo = null;


        private static RawKeyboard _keyboardDriver;

        private static readonly Guid DeviceInterfaceHid = new Guid("4D1E55B2-F86F-11CF-88CB-001111234530");

        private Queue<RawInput_dll.Win32.KeyAndState> _eventQ = new Queue<RawInput_dll.Win32.KeyAndState>();

        private bool _isMonitoring = true;

        public static string deviceid = string.Empty;

        private delegate void UpdateInfoDelegate(string strInfo);


        public static WorkSpace _workSpace = null;

        private string printInfo=string.Empty;

        private string strPnCode = string.Empty;

        private int dockCont = 0;


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            serialPort = new LocalSerialPort();


            LoadConfig();
            InitalConfig();

            InitalUSBDriver();

            ProcessImage(2,"0000000000000");

            this.radioButton3.Checked = true;

          //  LoadPortConfig();

        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {



            switch (m.Msg)
            {
                case Win32.WM_USB_DEVICECHANGE:

                    _keyboardDriver.EnumerateDevices();

                    break;
                case Win32.WM_INPUT:
                    {

                        lbSN.Focus();
                        KeyPressEvent keyPressEvent;

                        _keyboardDriver.ProcessRawInput(m.LParam, out keyPressEvent);

                        // textBox_ScanGunInfoNow.Text = keyPressEvent.DeviceName;

                        //只处理一次事件，不然有按下和弹起事件

                        if (deviceid == null||deviceid==string.Empty)
                        {
           
                            if (KeyInterop.KeyFromVirtualKey(keyPressEvent.VKey) == Key.Enter)
                            {
                                _isMonitoring = false;
                                //  Btn_OK.IsEnabled = true;
                            }

                            // 回车 作为结束标志
                            if (_isMonitoring && keyPressEvent.KeyPressState == "BREAK")
                            {
                                //存储 Win32 按键的int值
                                int key = keyPressEvent.VKey;
                                byte[] state = new byte[256];
                                Win32.GetKeyboardState(state);
                                _eventQ.Enqueue(new RawInput_dll.Win32.KeyAndState(key, state));
                            }

                            if (_isMonitoring == false)
                            {
                                deviceid = keyPressEvent.DeviceName;
                            }
                          //  base.WndProc(ref m);   // 调用基类函数处理其他消息。 
                            break;
                        }

                       
                        if (keyPressEvent.KeyPressState == "MAKE" && keyPressEvent.DeviceName == this.deviceinfo.DeviceID && this.deviceinfo.DeviceID != string.Empty)
                        {
                            // textBox_Output.Focus();
                           // this.lbStatus.Focus();

                            //找到结尾标志的时候，就不加入队列了，然后就发送到界面上赋值
                            if (KeyInterop.KeyFromVirtualKey(keyPressEvent.VKey) == Key.Enter)
                            {
                                _isMonitoring = false;

                                string str_Out = string.Empty;

                                ThreadPool.QueueUserWorkItem((o) =>
                                {
                                    while (_eventQ.Count > 0)
                                    {
                                        RawInput_dll.Win32.KeyAndState keyAndState = _eventQ.Dequeue();

                                        str_Out += COMM.Utils.Chr(keyAndState.Key).Trim();

                                        System.Threading.Thread.Sleep(5); // might need adjustment
                                    }

                                    //Application.Current.Dispatcher.BeginInvoke((Action)(() =>
                                    //{
                                    //    textBox_Output.Text = str_Out;
                                    //}));
                                    //  this.lbStatus.Text = str_Out;

                                    DoChangePnCode(str_Out.Trim());
                                    _eventQ.Clear();

                                    _isMonitoring = true;
                                });
                            }

                            // 回车 作为结束标志
                            if (_isMonitoring)
                            {
                                //存储 Win32 按键的int值
                                int key = keyPressEvent.VKey;
                                byte[] state = new byte[256];
                                Win32.GetKeyboardState(state);
                                _eventQ.Enqueue(new RawInput_dll.Win32.KeyAndState(key, state));
                            }
                        }
                    }
                    break;
                default:
                    base.WndProc(ref m);   // 调用基类函数处理其他消息。   
                    break;
            }

        }

        private void DoChangePnCode(string pncode)
        {
            try
            {

                if (!this.InvokeRequired)
                {
                    if (pncode.Length == 14)
                    {
                        this.progressBar1.Value = 0;
                        this.lbSN.Text = pncode;
                        if (this.serialPort.IsOpen)
                        {
                            Thread.Sleep(100);
                            serialPort.SendSNCode(pncode);
                            this.progressBar1.Value = 30;

                            Thread.Sleep(1100);
                            ///判断是否是本地模式
                            if (radioButton2.Checked)
                                serialPort.SendModeCode(2);
                            else//远程模式
                                serialPort.SendModeCode(1);
                            this.progressBar1.Value = 80;
                            strPnCode = pncode;
                            Thread.Sleep(500);
                            int type = 1;

                            if (!this.radioButton3.Checked)
                                type = 2;

                            ProcessImage(type, pncode);

                            this.progressBar1.Value = 100;
                        }


                    }
                }
                else
                {
                    this.Invoke(new UpdateInfoDelegate(DoChangePnCode), new object[] { pncode });

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
     
          

        /// <summary>
        /// 处理图片
        /// </summary>
        /// <param name="type"></param>
        private void ProcessImage(int type,string pnCode)
        {

            switch(type)
            {
                case 1:
                    SaveImage(pnCode);
                    break;
                case 2:
                    SaveImage2(pnCode);
                    break;
                default:
                    break;
            }
        }
        private void InitalConfig()
        {
           // portPar = new SerialPortPar();
          //  portPar.PortName = "COM3";

            LoadPortConfig();


            if (!Directory.Exists(_workSpace.OutPath))
                Directory.CreateDirectory(_workSpace.OutPath);
               this.lbPath.Text = strOutPath;
            //else
            //   this.lbPath.Text = string.Empty;

            this.lbSN.Text = "000000";

            if (_workSpace.GetDeviceInfo(1) != null && _workSpace.GetDeviceInfo(1).DeviceID!=string.Empty)
                this.lbScanStatus.Text = "已标定";
            else
                this.lbScanStatus.Text = "未标定";

            this.txtburnInfo.Text = string.Empty;
          

        }

        private void InitalUSBDriver()
        {
            _keyboardDriver = new RawKeyboard(COMM.User32API.GetCurrentWindowHandle());
            _keyboardDriver.CaptureOnlyIfTopMostWindow = false;
            _keyboardDriver.EnumerateDevices();
        }


        private void Port_ReceiveResultEvent(object sender,EventArgs args)
        {
            
            if(printInfo.Length>100)
                printInfo=String.Empty;
            
            //if (this.txtburnInfo.Text.Length > 100)
            //    this.txtburnInfo.Text = string.Empty;
            string info = Convert.ToString(sender);
            printInfo +="SN"+strPnCode+ info.Trim('\0') + "\r\n";

            UpdateScanInfo(printInfo);
            
  
      
           
        
        }


        private void UpdateScanInfo(string info)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateInfoDelegate(UpdateScanInfo), new object[] { info });
            }
            else
            {
                this.txtburnInfo.Text = info;
            }
        }
        private bool LoadPortConfig()
        {
            try
            {

                serialPort.Close();

                bool ret = serialPort.OpenPort(_workSpace.SerialPortPar.PortName, _workSpace.SerialPortPar.BaudRate, 
                                               _workSpace.SerialPortPar.Parity, _workSpace.SerialPortPar.DataBits,
                                               _workSpace.SerialPortPar.StopBits, System.IO.Ports.Handshake.None);

                if (ret)
                {
                    serialPort.ReceiveResultEvent += new EventHandler(Port_ReceiveResultEvent);
                   // serialPort.Close();
                }
                else
                {
                    portPar.PortName = string.Empty;
                }

                this.lbPort.Text = _workSpace.SerialPortPar.PortName;
                this.lbBaudRate.Text = _workSpace.SerialPortPar.BaudRate.ToString();
                this.lbDataBits.Text =  _workSpace.SerialPortPar.DataBits.ToString();
                this.lbParity.Text =  _workSpace.SerialPortPar.Parity.ToString();
                this.lbStopBits.Text =  _workSpace.SerialPortPar.StopBits.ToString();
                this.radioButton2.Checked = true;

                if (!ret)
                {
                    this.lbLEDStatus.Text = "未连接串口";
                    this.lbLEDStatus.ForeColor = Color.Red;
                    this.ledBulb1.Status = Contorl.ClientStatus.None;
                }
                else
                {
                    this.lbLEDStatus.ForeColor = Color.Blue;
                    this.lbLEDStatus.Text = "已连接串口";
                    this.ledBulb1.Status = Contorl.ClientStatus.Link;
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
        }

        private void btSelectDir_Click(object sender, EventArgs e)
        {
            try
            {
                Vista_Api.FolderBrowserDialog dlg = new Vista_Api.FolderBrowserDialog();


                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.lbPath.Text = dlg.SelectedPath;
                    this.strOutPath = dlg.SelectedPath;
                    _workSpace.OutPath = this.strOutPath;
                    _workSpace.Save();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btPortConfig_Click(object sender, EventArgs e)
        {
            PortConfigDlg dlg = new PortConfigDlg();
            dlg.SerialPortPar = this.portPar;

            if (dlg.ShowDialog()==DialogResult.OK)
            {
              //  this.portPar = dlg.SerialPortPar;
                _workSpace.SerialPortPar = dlg.SerialPortPar;
                _workSpace.Save();
                LoadPortConfig();
            }

        }

        private void btConnect_Click(object sender, EventArgs e)
        {

            if (LoadPortConfig())
            {
                MessageBox.Show("打开串口成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("打开串口失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btCalibration_Click(object sender, EventArgs e)
        {
            SacnConfigDlg dlg = new SacnConfigDlg();

            dlg.DeviceInfo = _workSpace.GetDeviceInfo(1);

            if (dlg.ShowDialog() == DialogResult.Yes)
            {
             
                _workSpace.SetDeviceInfo(dlg.DeviceInfo);
                _workSpace.Save();
                _workSpace.Load();
              //  this.deviceinfo.DeviceID=
                 InitalConfig();
            }

        }


        /// <summary>
        /// 加载配置
        /// </summary>
        private void LoadConfig()
        {
            try
            {
                _workSpace = new WorkSpace(SystemUtils.ApplicationPath);
                _workSpace.Load();
                deviceinfo = _workSpace.GetDeviceInfo(1);
                portPar = _workSpace.SerialPortPar;
                strOutPath = _workSpace.OutPath;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

        }


        /// <summary>
        /// 保存配置
        /// </summary>
        private void SavaDBConfig()
        {
            try
            {
                _workSpace = new WorkSpace(SystemUtils.ApplicationPath);
                _workSpace.Load();
        

                if (_workSpace.Save())
                {
                 //   MessageBox.Show("");
                }
                else
                {

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }


        private void deleteTmpFiles(string strPath)
        {
            //删除这个目录下的所有子目录
            if (Directory.GetDirectories(strPath).Length > 0)
            {
                foreach (string var in Directory.GetDirectories(strPath))
                {
                    //DeleteDirectory(var);
                    Directory.Delete(var, true);
                    //DeleteDirectory(var);
                }
            }
            //删除这个目录下的所有文件
            if (Directory.GetFiles(strPath).Length > 0)
            {
                foreach (string var in Directory.GetFiles(strPath))
                {
                    File.Delete(var);
                }
            }
        }
        private void SaveImage(string snCode)
        {
            try
            {
                string destFloder = string.Format("{0}\\{1}", _workSpace.OutPath, snCode);

                string tempFile = String.Format("{0}\\img\\{1}", SystemUtils.ApplicationPath, "QRCodeTemp.bmp");

                deleteTmpFiles(_workSpace.OutPath);
                //if (File.Exists(destFloder + "\\01扫码主界面.bmp"))
                //    File.Delete(destFloder + "\\01扫码主界面.bmp");

                Bitmap qrCode = Utils.ImgConvert.CreateQRCode(199, 199, snCode);

                if (!Utils.ImgConvert.QRCodeConvert(tempFile, destFloder, "01扫码主界面.bmp", 800, 600,
                                                                 300, 220, qrCode))
                {
                    printInfo += "扫码主界面 Output Failed!" + "\r\n";

                    UpdateScanInfo(printInfo);
                }
                else
                {
                    printInfo += "扫码主界面 Output Successed!" + "\r\n";

                    UpdateScanInfo(printInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void SaveImage2(string snCode)
        {
            try
            {
                string destFloder = string.Format("{0}\\{1}", _workSpace.OutPath, snCode);

                string tempFile = String.Format("{0}\\img\\{1}", SystemUtils.ApplicationPath, "QRCodeTemp2.bmp");

                deleteTmpFiles(_workSpace.OutPath);
                //if (File.Exists(destFloder + "\\01扫码主界面.bmp"))
                //    File.Delete(destFloder + "\\01扫码主界面.bmp");

                Bitmap qrCode = Utils.ImgConvert.CreateQRCode(140, 140, snCode);

                if (!Utils.ImgConvert.QRCodeConvert(tempFile, destFloder, "01G共享模式-扫码充电.bmp", 480, 272,
                                                                 95, 92, qrCode))
                {
                    printInfo += "扫码主界面 Output Failed!" + "\r\n";

                    UpdateScanInfo(printInfo);
                }
                else
                {
                    printInfo += "扫码主界面 Output Successed!" + "\r\n";

                    UpdateScanInfo(printInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {


            if(MessageBox.Show("确定要退出吗？","系统提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk)==DialogResult.Cancel)
            {

                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
