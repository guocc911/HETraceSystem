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
using COMM;
using RawInput_dll;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using HETraceSystem.Config;
using MDL;
using DAL;
using HETraceSystem.Control;


namespace HETraceSystem
{
    public partial class ExDeliveryInfoDlg : Form
    {
        #region Fileds

        private COMM.DeviceInfo deviceinfo = null;

        private static RawKeyboard _keyboardDriver;

        private static readonly Guid DeviceInterfaceHid = new Guid("4D1E55B2-F86F-11CF-88CB-001111234530");

        private Queue<RawInput_dll.Win32.KeyAndState> _eventQ = new Queue<RawInput_dll.Win32.KeyAndState>();

        private bool _isMonitoring = true;

        private delegate void ChangePNDelegate(string pnCode);

        private Hashtable inputTable = new Hashtable(); //  创建哈希表

        private DeliveryItemMDL deliveryItem = new DeliveryItemMDL();

        private delegate void UpdateInfoDelegate();

        private HETraceSystem.Control.ProgressBarEx _progressbar = null;

        private delegate void DelegateDoDisplayProgressBar();


        // private delegate void 

        #endregion


        /// <summary>
        /// 扫描枪信息
        /// </summary>
        public COMM.DeviceInfo ScanInfo
        {
            get { return deviceinfo; }

            set { deviceinfo = value; }

        }


        public ExDeliveryInfoDlg()
        {
            InitializeComponent();
        }




        private void btAsmSetting_Click(object sender, EventArgs e)
        {
            DeliveryCfgDlg dlg = new DeliveryCfgDlg();

            dlg.TempDeliveryInfo = this.deliveryItem;
            //    dlg.ProductName = this.asmMDL.PRODUCTID;
            if (dlg.ShowDialog() == DialogResult.Yes)
            {
                this.deliveryItem =dlg.TempDeliveryInfo;
                DoUpdateInfo();

            }
        }

        private void btOutPut_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.lbCompany.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写厂商信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.lbContact.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写联系方式！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.lbAgent.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写货代信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }


                if (this.lbLN.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写货代信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.lbAddress.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写收货地址！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.inputTable.Count <= 0)
                {
                    MessageBox.Show("请扫描添加出库产品！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                OpProgressCtrl(true);

                double div = (double)100 / this.inputTable.Count;

                int pos = 1;


                ExInventoryItemDAL dal = new ExInventoryItemDAL();

                string info = String.Empty;
                ArrayList deliveryKey = new ArrayList();

                foreach (DictionaryEntry de in inputTable)
                {

                    if (DeliveryItem((ExInventoryItemMDL)de.Value, pos))
                    {
                        _progressbar.SetProgerssInfo((int)(pos * div), String.Format("产品SN：{0} 出库成功",
                                                                       Convert.ToString(de.Key)));
                        deliveryKey.Add((string)de.Key);
                    }
                    else
                    {
                        _progressbar.SetProgerssInfo((int)(pos * div), String.Format("产品SN：{0} 出库失败",
                                                                   Convert.ToString(de.Key)));
                    }
                    pos++;

                }

                foreach (string item in deliveryKey)
                {
                    this.inputTable.Remove(item);
                }
    
               
                OpProgressCtrl(false);

                MessageBox.Show(String.Format(" 出货成功{0}个！", pos - 1), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                LoadSNGridInfo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                OpProgressCtrl(false);
            }
        }



        private bool DeliveryItem(ExInventoryItemMDL mdl,int seq)
        {
            try
            {

                DeliveryLogDal deliveryDal = new DeliveryLogDal();

                DeliveryItemMDL item = new DeliveryItemMDL();

                item.SN = mdl.SN;
                item.SEQID = COMM.CodeComm.GetRandomSeqNum("DLV") + String.Format("{0:d6}", seq);
                item.LN = deliveryItem.LN;
                item.FORWARDERDID = deliveryItem.FORWARDERDID;
                item.DIRECTION = deliveryItem.DIRECTION;
                item.CONTACT = deliveryItem.CONTACT;
                item.USERNAME = deliveryItem.USERNAME;
                item.DELIVER_STAUTS = 1;
                item.DELIVER_DATE = DateTime.Now;
                item.SCAN_DATE = DateTime.Now;
                item.LOGINDATE = DateTime.Now;
                item.USERID = "test";
                item.ADDRESS = deliveryItem.ADDRESS;

                if (deliveryDal.InsertDeliveryItem(item)<=0)
                {
                    return false;
                }

                //更新为发货状态
                mdl.DELIVER_STATUS = 1;


                ExInventoryItemDAL dal = new ExInventoryItemDAL();

                if (dal.UpdateDeliverStatus(mdl.SN,mdl.DELIVER_STATUS) >= 0)
                {
                    return true;
                }
                else
                {
                    deliveryDal.DeleteDelivertInfo(item);

                }

                return false;
            }
            catch
            {
                throw;

            }
 
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void ExDeliveryInfoDlg_Load(object sender, EventArgs e)
        {
            try
            {
                _progressbar = new ProgressBarEx();

                InitalUSBDriver();

                IntialDeliveryInfo();
                LoadSNGridInfo();
                InitalScanView();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"系统提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
        }



        private void LoadSNGridInfo()
        {
            InitialDataGridViewHeader();
            IntialDaraGrid();
        }

        private void InitalUSBDriver()
        {
            _keyboardDriver = new RawKeyboard(COMM.User32API.GetCurrentWindowHandle());
            _keyboardDriver.CaptureOnlyIfTopMostWindow = false;
            _keyboardDriver.EnumerateDevices();

        }
        /// <summary>
        /// 初始化数据视图
        /// </summary>
        private void InitialDataGridViewHeader()
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
            delColumn.Width = clounmWidth / 2 - 2;
            delColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(delColumn);

            this.dataGridView1.Rows.Clear();

        }

        /// <summary>
        /// 
        /// </summary>
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
                        ExInventoryItemMDL mdl = (ExInventoryItemMDL)k.Value;

                        this.dataGridView1.Rows.Add(i.ToString(), Convert.ToString(k.Key), mdl.IMEI,"删 除");
                    }

                }


                this.dataGridView1.ClearSelection();

            }
            catch
            {
                throw;
            }
        }


        private void DoChangePnCode(string pncode)
        {
            if (!this.InvokeRequired)
            {
                this.lbStatus.ForeColor = Color.Black;

                if (!inputTable.Contains(pncode))
                {
                    ProductDAL prdal = new ProductDAL();


                    if (prdal.ProductIsExited(ProductMDL.PraseSNCode(pncode)) <= 0)
                    {
                        this.lbStatus.Text = pncode + "该产品不在产品库";
                        this.lbStatus.ForeColor = Color.Red;

                        return;
                    }

                    ExInventoryItemDAL dal = new ExInventoryItemDAL();



                    if (dal.SNIsExited(pncode)<=0)
                    {
                        this.lbStatus.Text = pncode + "该产品未入库";
                        this.lbStatus.ForeColor = Color.Red;
                        return;
                    }

                    //该产品是否发货
                    if (dal.ProductIsDelivery(pncode)<=0)
                    {
                        this.lbStatus.Text = pncode;
                        this.codeShowCtrl1.Content = pncode;
                        this.codeShowCtrl1.CodeType = CodeType.BarCode;
                        int inputCount = this.inputTable.Count + 1;
                        this.lbCount.Text = inputCount.ToString();
                        this.codeShowCtrl1.Update();


                        ///加载入库信息
                        ExInventoryItemMDL mdl = dal.GetInventoryItem(pncode);

                        if (mdl == null)
                            return;

                        inputTable.Add(pncode, mdl);

                        ///加载列表
                        LoadSNGridInfo();
                    }
                    else
                    {
                        this.lbStatus.Text = pncode + "该产品已发货";
                        this.lbStatus.ForeColor = Color.Red;
                    }
                }
                else
                {
                    this.lbStatus.Text = pncode + "该产品已扫描";
                    this.lbStatus.ForeColor = Color.Red;
                }
            }
            else
            {
                this.Invoke(new ChangePNDelegate(DoChangePnCode), new object[] { pncode });
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView1_CellContentClick);

            try
            {

                switch (e.ColumnIndex)
                {
                    case 3:

                        string key = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();



                        if (MessageBox.Show("确定要删除该产品信息吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                        {

                            lock (inputTable.SyncRoot)
                            {

                                this.inputTable.Remove(key);
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

                        if (this.deviceinfo == null || this.deviceinfo.DeviceID == null || this.deviceinfo.DeviceID==string.Empty)
                        {
                            MessageBox.Show("未添加扫描枪！");
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
        
        #region Initial View

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

        private void UpdateAsmInfo()
        {
            this.lbCompany.Text = deliveryItem.USERNAME;
            this.lbContact.Text = deliveryItem.CONTACT;
            this.lbAgent.Text = deliveryItem.FORWARDERDID;
            this.lbLN.Text = deliveryItem.LN;
            this.lbDirect.Text = deliveryItem.DIRECTION.Trim();
            this.lbAddress.Text = deliveryItem.ADDRESS.Trim();

        }

        private void IntialDeliveryInfo()
        {
            deliveryItem.USERNAME = "畅的科技";
            deliveryItem.CONTACT = "13568283234";
            deliveryItem.FORWARDERDID = "顺丰快递";
;           deliveryItem.LN = "0000000";
            deliveryItem.DIRECTION = "武汉";
            deliveryItem.ADDRESS = "合康变频";
            this.lbCompany.Text = deliveryItem.USERNAME;
            this.lbContact.Text = deliveryItem.CONTACT;
            this.lbAgent.Text = deliveryItem.FORWARDERDID;
            this.lbDirect.Text = deliveryItem.DIRECTION.Trim();
            this.lbLN.Text = deliveryItem.LN;
            this.dateTimePicker1.Value = DateTime.Now;
            this.lbAddress.Text = deliveryItem.ADDRESS.Trim();
            this.lbCount.Text = "0";
        }


        private void InitalScanView()
        {
            this.codeShowCtrl1.Content = "HAPPYEV0000001";
            this.lbStatus.Text = "无扫描信息";
        }
        

        #endregion

        private void btManual_Click(object sender, EventArgs e)
        {
            ManualOutPutDlg dlg = new ManualOutPutDlg();
            dlg.PRCode = "CT";

            if (dlg.ShowDialog() == DialogResult.Yes)
            {
         
                //if (this.inputTable != null)
                //    this.inputTable.Clear();

                //this.inputTable = dlg.InputTable;

                if (this.inputTable == null || this.inputTable.Count <= 0)
                    this.inputTable = dlg.InputTable;
                else
                {
                    foreach (string key in dlg.InputTable.Keys)
                    {
                        this.inputTable.Add(key, dlg.InputTable[key]);
                    }
                }
                this.LoadSNGridInfo();
            }
        }

        private void btAddSingle_Click(object sender, EventArgs e)
        {

            SingleImportDlg dlg = new SingleImportDlg();
            dlg.IsImport =0;
            if (dlg.ShowDialog() == DialogResult.Yes)
            {
                this.inputTable.Add(dlg.InventoryItem.SN, dlg.InventoryItem);
            }
            this.LoadSNGridInfo();
        }
    }
}
