using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Windows.Interop;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Input;
using COMM;
using RawInput_dll;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using HETraceSystem.Config;
using MDL;
using MDL.Scan;
using DAL;
using HETraceSystem.Control;

namespace HETraceSystem
{
    public partial class ProductImportDlg : Form
    {

        #region Fileds

        private COMM.DeviceInfo deviceinfo = null;

        private static RawKeyboard _keyboardDriver;

        private static readonly Guid DeviceInterfaceHid = new Guid("4D1E55B2-F86F-11CF-88CB-001111234530");

        private Queue<RawInput_dll.Win32.KeyAndState> _eventQ = new Queue<RawInput_dll.Win32.KeyAndState>();

        private bool _isMonitoring = true;

        private delegate void ChangePNDelegate(string pnCode);

        private Hashtable inputTable = new Hashtable(); //  创建哈希表

        private AssemblageMDL asmMDL = new AssemblageMDL();

        private delegate void UpdateInfoDelegate();

        private HETraceSystem.Control.ProgressBarEx _progressbar = null;

        private delegate void DelegateDoDisplayProgressBar();

        public event EventHandler SCanErrorEvent;

        private List<ProductTypeMDL> appTypes = null;


        private List<string> imeiKeys = null;

       


       // private delegate void 

        #endregion







        public COMM.DeviceInfo DeviceInfo
        {
            get { return deviceinfo; }

            set { deviceinfo = value; }
           
        }

        public ProductImportDlg()
        {
            InitializeComponent();
        }

        private void txtRoadName_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadTestData()
        {
            //CP01PL00000101
            inputTable = new Hashtable();

            string item = String.Empty;

            for (int i = 1; i <= 10; i++)
            {
                InventoryItemMDL mdl = new InventoryItemMDL();
                item = String.Format("{0}{1:D6}{2}", "CD01PL", i,"02");
                mdl.SN = item;
                mdl.MD5 = COMM.MD5EncryptUtils.MD5Encrypt(item, System.Text.Encoding.UTF8);
                mdl.CPCode = item.Substring(0, 2);
                mdl.VRCode = item.Substring(2, 2);
                mdl.PRCode = item.Substring(4, 2);
                mdl.SBCode = item.Substring(12, 2);
                mdl.REGDATE = DateTime.Now;
              //  mdl.MODEL=
                mdl.DELIVER_STATUS = 0;
                mdl.PRINT_STATUS = 0;
                inputTable.Add(item, mdl);
            }
 


        }

        private void DoChangePnCode(string pncode)
        {
            if (!this.InvokeRequired)
            {
                this.lbStatus.ForeColor = Color.Black;

               // string PRCode= this.appTypes[this.cbAppType.SelectedIndex].TypeCode;

                if (this.radioButtonTbox.Checked)
                {
                    try
                    {
                        ScanerQRTbox qrbox = new ScanerQRTbox();
                        qrbox.DeviceName = "QRCodeGan";
                        qrbox.ScanDevicesType = ScanDevicesType.QR230CD;
                        qrbox.load(pncode);
                        pncode = qrbox.ScanData.getIMEICode();

                        int checkCode=0;

                        Int32.TryParse(pncode, out checkCode);

                        if (checkCode <= 0)
                        {
                            MessageBox.Show("解析二维码数据失败！");
                            return;
                        }

                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("解析二维码数据失败！");
                        return;
                    }

                    ProccesCTCodeScan(pncode);

                }
                else
                {
                    ProcessPipeCodeScan(pncode);
                }
                
         
            }
            else
            {
                this.Invoke(new ChangePNDelegate(DoChangePnCode), new object[] { pncode });
            }
        }


        private void ProccesCTCodeScan(string pncode)
        {

            try
            {
             

    
                if(this.dataGridView1!=null&&this.dataGridView1.Columns!=null)
                {

                    if (imeiKeys.Contains(pncode))
                    {
                        this.lbStatus.Text = pncode + "该产品已添加";
                        this.lbStatus.ForeColor = Color.Red;
                        return;
                    }
                }


              

                ExInventoryItemDAL dal = new ExInventoryItemDAL();


                if (dal.IMEIExsited(pncode) <= 0)
                {
                    this.lbStatus.Text = pncode;
                    this.codeShowCtrl1.Content = pncode;
                    this.codeShowCtrl1.CodeType = CodeType.BarCode;
                    int inputCount = this.inputTable.Count + 1;
                    this.lbCount.Text = inputCount.ToString();
                    this.codeShowCtrl1.Update();


                    ///加载入库信息
                    ExInventoryItemMDL mdl = new ExInventoryItemMDL();

                    ProductDAL prdal = new ProductDAL();
                   
                    ProductMDL  productMDL=prdal.GetProductItemByPRcode("CT");

                    int pCount = this.inputTable.Count + 1;

                    string sn = SystemUtils.GetNewTboxSN(productMDL.PCID, pCount);

                    mdl.SN = sn;
                    mdl.IMEI = pncode;
                    mdl.MD5 = COMM.MD5EncryptUtils.MD5Encrypt(sn, System.Text.Encoding.UTF8);
                    mdl.CPCode = sn.Substring(0, 2);
                    mdl.VRCode = sn.Substring(2, 2);
                    mdl.PRCode = sn.Substring(4, 2);
                    mdl.SBCode = sn.Substring(12, 2);
                    mdl.REGDATE = this.dateTimePicker1.Value;
                    mdl.DELIVER_STATUS = 0;
                    mdl.PRINT_STATUS = 0;
                    inputTable.Add(sn, mdl);

            
                    imeiKeys.Add(pncode);

                    ///加载列表
                    LoadSNGridInfo();
                }
                else
                {
                    this.lbStatus.Text = pncode + "该产品已入库";
                    this.lbStatus.ForeColor = Color.Red;
                    return;

                }
            }
            catch
            {
                throw;
            }

        }

        private void ProcessPipeCodeScan(string pncode)
        {
            try
            {


                if (!inputTable.Contains(pncode))
                {
                    ProductDAL prdal = new ProductDAL();


                    if (prdal.ProductIsExited(ProductMDL.PraseSNCode(pncode)) <= 0)
                    {
                        this.lbStatus.Text = pncode + "该产品不在产品库";
                        this.lbStatus.ForeColor = Color.Red;

                        return;

                    }

                    InventoryItemDAL dal = new InventoryItemDAL();

                    if (dal.InventoryItemIsExited(pncode) <= 0)
                    {
                        this.lbStatus.Text = pncode;
                        this.codeShowCtrl1.Content = pncode;
                        this.codeShowCtrl1.CodeType = CodeType.BarCode;
                        int inputCount = this.inputTable.Count + 1;
                        this.lbCount.Text = inputCount.ToString();
                        this.codeShowCtrl1.Update();


                        ///加载入库信息
                        InventoryItemMDL mdl = new InventoryItemMDL();
                        mdl.SN = pncode;
                        mdl.MD5 = COMM.MD5EncryptUtils.MD5Encrypt(pncode, System.Text.Encoding.UTF8);
                        mdl.CPCode = pncode.Substring(0, 2);
                        mdl.VRCode = pncode.Substring(2, 2);
                        mdl.PRCode = pncode.Substring(4, 2);
                        mdl.SBCode = pncode.Substring(12, 2);
                        mdl.REGDATE = this.dateTimePicker1.Value;
                        mdl.DELIVER_STATUS = 0;
                        mdl.PRINT_STATUS = 0;
                        inputTable.Add(pncode, mdl);

                        ///加载列表
                        LoadSNGridInfo();
                    }
                }
                else
                {
                    this.lbStatus.Text = pncode + "该产品已入库";
                    this.lbStatus.ForeColor = Color.Red;
                }
            }
            catch
            {
                throw;
            }

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
                        KeyPressEvent keyPressEvent;
                      
                            _keyboardDriver.ProcessRawInput(m.LParam, out keyPressEvent);

                            if (this.deviceinfo == null)
                            {
                                if (SCanErrorEvent!=null)
                                    SCanErrorEvent("未添加扫描枪",EventArgs.Empty);
                                //MessageBox.Show("未添加扫描枪！");
                                return;
                            
                            }

                       // textBox_ScanGunInfoNow.Text = keyPressEvent.DeviceName;

                        //只处理一次事件，不然有按下和弹起事件
                        if (keyPressEvent.KeyPressState == "MAKE" && keyPressEvent.DeviceName == this.deviceinfo.DeviceID && this.deviceinfo.DeviceID != string.Empty)
                        {
                           // textBox_Output.Focus();
                            this.lbStatus.Focus();

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btAdd_Click(object sender, EventArgs e)
        {

            try
            {

                if (this.lbCompany.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写厂商信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.lbPline.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写产线信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.lbContact.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写联系方式！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.inputTable.Count <= 0)
                {
                    MessageBox.Show("请扫描添加入库产品！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                OpProgressCtrl(true);

                double div = (double)100 / this.inputTable.Count;
                
                int pos=1;


                if (this.radioButtonTbox.Checked)
                {
                    ExInventoryItemDAL dal = new ExInventoryItemDAL();

                    string info = String.Empty;

                    foreach (DictionaryEntry de in inputTable)
                    {

                        if (dal.InsertExInventoryItem((ExInventoryItemMDL)de.Value) > 0)
                        {
                            _progressbar.SetProgerssInfo((int)(pos * div), String.Format("产品SN：{0} 入库成功",
                                                                           Convert.ToString(de.Key)));
                        }
                        pos++;

                    }
                }
                else
                {
                    InventoryItemDAL dal = new InventoryItemDAL();

                    string info = String.Empty;

                    foreach (DictionaryEntry de in inputTable)
                    {

                        if (dal.InsertInventoryItem((InventoryItemMDL)de.Value) > 0)
                        {
                            _progressbar.SetProgerssInfo((int)(pos * div), String.Format("产品SN：{0} 入库成功",
                                                                           Convert.ToString(de.Key)));
                        }
                        pos++;

                    }

                }

                this.inputTable.Clear();

                OpProgressCtrl(false);

                MessageBox.Show(String.Format(" 添加产品{0}条成功！",pos -1 ), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                LoadSNGridInfo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void ProductImportDlg_Load(object sender, EventArgs e)
        {
            try
            {
                _progressbar = new ProgressBarEx();

                IntialAsmInfo();
                InitalUSBDriver();
                InitalScanView();
                //LoadTestData();
                ResSetProductType();
                LoadSNGridInfo();

            

              //  ProccesCTCodeScan("11111112");
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btAsmSetting_Click(object sender, EventArgs e)
        {
            AsmConfigDlg dlg = new AsmConfigDlg();

            dlg.Company = this.asmMDL.COMPANY;
            dlg.Pline = this.asmMDL.PLEND_ID;
            dlg.Contact = this.asmMDL.CONTACT;
        //    dlg.ProductName = this.asmMDL.PRODUCTID;
            if (dlg.ShowDialog() == DialogResult.Yes)
            {
                this.asmMDL.COMPANY = dlg.Company;
                this.asmMDL.PLEND_ID = dlg.Pline;
                this.asmMDL.PRODUCTID = dlg.ProductName;
                this.asmMDL.CONTACT = dlg.Contact;
                DoUpdateInfo();

            }
   
        }



        private void LoadSNGridInfo()
        {
            if (imeiKeys == null)
                imeiKeys = new List<string>();

            if (this.radioButtonPile.Checked)
                InitialDataGridViewHeader();
            else
                InitialDataGridViewHeaderWithTbox();

            IntialDaraGrid();
        }
        /// <summary>
        /// 初始化数据视图
        /// </summary>
        private void InitialDataGridViewHeader()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns.Clear();


            int clounmWidth = this.dataGridView1.Width / 3 - 1;

        

            DataGridViewColumn seqColumn = new DataGridViewTextBoxColumn();
            seqColumn.HeaderText = "序号";
            seqColumn.Name = "SEQ";
            seqColumn.Width = clounmWidth - clounmWidth / 2;
            seqColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(seqColumn);

            DataGridViewColumn codeColumn = new DataGridViewTextBoxColumn();
            codeColumn.HeaderText = "产品编号";
            codeColumn.Name = "SN";
            codeColumn.Width = clounmWidth + clounmWidth / 2 + clounmWidth / 3;
            codeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(codeColumn);

            DataGridViewColumn delColumn = new DataGridViewButtonColumn();
            delColumn.HeaderText = "操作";
            delColumn.Name = "DisNumber";
            delColumn.Width = clounmWidth / 2 +7;
            delColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(delColumn);

            this.dataGridView1.Rows.Clear();
    

        }


        private void InitialDataGridViewHeaderWithTbox()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns.Clear();


            int clounmWidth = this.dataGridView1.Width / 4 - 1;



            DataGridViewColumn seqColumn = new DataGridViewTextBoxColumn();
            seqColumn.HeaderText = "序号";
            seqColumn.Name = "SEQ";
            seqColumn.Width = clounmWidth - clounmWidth / 2;
            seqColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(seqColumn);

            DataGridViewColumn codeColumn = new DataGridViewTextBoxColumn();
            codeColumn.HeaderText = "产品编号";
            codeColumn.Name = "SN";
            codeColumn.Width = clounmWidth + clounmWidth / 2 ;
            codeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(codeColumn);

            DataGridViewColumn imeiColumn = new DataGridViewTextBoxColumn();
            imeiColumn.HeaderText = "IMEI";
            imeiColumn.Name = "IMEI";
            imeiColumn.Width = clounmWidth + clounmWidth / 2 ;
            imeiColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(imeiColumn);

            DataGridViewColumn delColumn = new DataGridViewButtonColumn();
            delColumn.HeaderText = "操作";
            delColumn.Name = "DisNumber";
            delColumn.Width = clounmWidth / 2 + 7;
            delColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(delColumn);

            this.dataGridView1.Rows.Clear();


        }

        private void IntialDaraGrid()
        {
            try
            {
                this.dataGridView1.Rows.Clear();

                if (inputTable != null && inputTable.Count > 0)
                {

                    int i = 0;

                    foreach (DictionaryEntry k in inputTable)
                    {
                        i++;

                        if(this.radioButtonTbox.Checked)
                        {
                            ExInventoryItemMDL mdl = (ExInventoryItemMDL)k.Value;

                            this.dataGridView1.Rows.Add(i.ToString(), Convert.ToString(mdl.SN), mdl.IMEI, "删 除");
                        }
                        else
                        this.dataGridView1.Rows.Add(i.ToString(), Convert.ToString(k.Key), "删 除");
                    }
     
                }


                this.dataGridView1.ClearSelection();

            }
            catch
            {
                throw;
            }
        }
        

        private void InitalUSBDriver()
        {
            _keyboardDriver = new RawKeyboard(COMM.User32API.GetCurrentWindowHandle());
            _keyboardDriver.CaptureOnlyIfTopMostWindow = false;
            _keyboardDriver.EnumerateDevices();
 
        }

        private void IntialAsmInfo()
        {
            asmMDL.COMPANY = "畅的科技";
            asmMDL.PLEND_ID = "产线1";
            asmMDL.PRODUCTID = "";
            asmMDL.CONTACT = "4000279965";
            this.lbCompany.Text = asmMDL.COMPANY;
            this.lbContact.Text = asmMDL.CONTACT;
            this.lbPline.Text = asmMDL.PLEND_ID;
            this.dateTimePicker1.Value = DateTime.Now;
            this.lbCount.Text = "0";
        }

        private void UpdateAsmInfo()
        {
            this.lbCompany.Text = asmMDL.COMPANY;
            this.lbContact.Text = asmMDL.CONTACT;
            this.lbPline.Text = asmMDL.PLEND_ID;
        }




        private void OpProgressCtrl(bool isHide)
        {
            try
            {

                if (this.InvokeRequired)
                {
                    if (isHide)
                        this.Invoke(new DelegateDoDisplayProgressBar(AddProgressCtrl));
                    else
                        this.Invoke(new DelegateDoDisplayProgressBar(RomoveProgressCtrl));
                }
                else 
                {
                    if (isHide)
                        AddProgressCtrl();
                    else
                        RomoveProgressCtrl();
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        // 添加加载工程时的进度条
        private void AddProgressCtrl()
        {
            _progressbar.Location = new Point((this.Width - _progressbar.Width) / 2,
                                          (this.Height - _progressbar.Height) / 3);
            this.Controls.Add(_progressbar);
            // (this.Width-_progressBar.Width)/2
            _progressbar.BringToFront();

        }

        //  移除加载工程时的进度条
        private void RomoveProgressCtrl()
        {
            _progressbar.SendToBack();
            this.Controls.Remove(_progressbar);

        }
        /// <summary>
        /// 更新配货信息
        /// </summary>
        public void DoUpdateInfo()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateInfoDelegate(UpdateAsmInfo));
            }
            else 
            {
                UpdateAsmInfo();
            }
        }

        private void InitalScanView()
        {
            this.codeShowCtrl1.Content = "HAPPYEV0000001";
            this.lbStatus.Text = "无扫描信息";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView1_CellContentClick);

            try
            {

                switch (e.ColumnIndex)
                {
                    case 2:

                        if (!radioButtonPile.Checked)
                            return;

                        string key  = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                   
      
                        if (MessageBox.Show("确定要删除该产品信息吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                        {

                             lock(inputTable.SyncRoot)
                             {


                                this.inputTable.Remove(key);

                                MessageBox.Show("删除成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                             }

                             this.LoadSNGridInfo();
                        }

                        break;
                    case 3:

                        if (!radioButtonTbox.Checked)
                            return;

                        string tboxkey  = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        string imei = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
      
                        if (MessageBox.Show("确定要删除该产品信息吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                        {

                             lock(inputTable.SyncRoot)
                             {


                                 this.inputTable.Remove(tboxkey);

                                 if (imeiKeys.Contains(imei))
                                     this.imeiKeys.Remove(imei);

                                 this.imeiKeys.TrimExcess();

                                  MessageBox.Show("删除成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                             }

                             this.LoadSNGridInfo();
                        }
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
        }

        private void ProductImportDlg_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                if (this.inputTable != null && this.inputTable.Count>0)
                {

                    if (MessageBox.Show("您有未处理完的入库信息是否退出？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk)==DialogResult.Cancel)
                    {
                        e.Cancel = true;

                        return;
                    }
                }

                if (this.imeiKeys != null)
                    this.imeiKeys.Clear();

                e.Cancel = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btManual_Click(object sender, EventArgs e)
        {

            ManualImportDlg dlg = new ManualImportDlg();

            if (dlg.ShowDialog() == DialogResult.Yes)
            {
               //if( this.inputTable != null)
               //   this.inputTable.Clear();


               if (this.inputTable == null || this.inputTable.Count <= 0)
                   this.inputTable = dlg.InputTable;
               else
               {
                   foreach (string key in dlg.InputTable.Keys)
                   {

                       if (!this.inputTable.Contains(key))
                       this.inputTable.Add(key, dlg.InputTable[key]); 
                   }
               }
               this.LoadSNGridInfo();

            }
        }

        private void btAddSingle_Click(object sender, EventArgs e)
        {
            

             SingleImportDlg dlg = new SingleImportDlg();
             dlg.IsImport = 1;
             if (dlg.ShowDialog() == DialogResult.Yes)
             {
                 this.inputTable.Add(dlg.InventoryItem.SN, dlg.InventoryItem); 
             }
             this.LoadSNGridInfo();


        }


        private void ResSetProductType()
        {

            try
            {
                //添加应用类型
                ProductTypeDAL ptDal = new ProductTypeDAL();

                appTypes = ptDal.GetProTypeList();

                if (appTypes == null)
                    return;

                ArrayList applist = new ArrayList();

                if (appTypes != null)
                {
                    for (int i = 0; i < appTypes.Count; i++)
                    {

                        if (appTypes[i] != null)
                            applist.Add(appTypes[i].TypeName);

                    }
                    //this.cbAppType.DataSource = applist;

                    //this.cbAppType.SelectedIndex = 0;
                }
            }
            catch
            {
                throw;
            }
        }

        private void cbAppType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReLoadProductType();
        }



        private void ReLoadProductType()
        {

            if(this.InvokeRequired)
            {
                this.Invoke(new UpdateInfoDelegate(ReLoadProductType));
                
            }
            else
            {
                if (this.radioButtonPile.Checked==true)
                {
                    this.btManual.Enabled = true;
                    this.btAddSingle.Enabled = true;
                    this.LoadSNGridInfo();
                }
                else
                {
                    this.btManual.Enabled = false;
                    this.btAddSingle.Enabled = false;
                    this.LoadSNGridInfo();
                }
            }

        }

        private void radioButtonPile_CheckedChanged(object sender, EventArgs e)
        {
            ReLoadProductType();
        }

        private void radioButtonTbox_CheckedChanged(object sender, EventArgs e)
        {
            ReLoadProductType();
        }

    }
}
