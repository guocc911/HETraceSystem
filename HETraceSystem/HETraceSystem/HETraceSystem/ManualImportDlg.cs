using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Text.RegularExpressions;
using HETraceSystem.Control;
using MDL;
using DAL;
using COMM;

namespace HETraceSystem.Config
{
    public partial class ManualImportDlg : Form
    {

        private List<ProductMDL> productList = null;


        private Hashtable inputTable=new Hashtable();


        private PtModel selectedModel;



        private DateTime pickTime ;


        private string strErrorInfo = string.Empty;


       private HETraceSystem.Control.ProgressBarEx _progressbar = null;


       private delegate void DelegateDoDisplayProgressBar();

       private delegate void DelegateShowCode(string nvalue);


        public DateTime ImportTime
        {
            get { return pickTime; }
            set { pickTime = value; }
        }


        public Hashtable InputTable
        {
            get { return inputTable; }
        }


        public ManualImportDlg()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 初始产品信息
        /// </summary>
        private void InitialProductCombox()
        {

            try
            {

                if (productList != null)
                {
                    productList.Clear();
                    productList.TrimExcess();
                }

                ProductDAL dal = new ProductDAL();
                productList = dal.GetProducts();


                if (productList == null || productList.Count < 0)
                    return;
                   
                ArrayList list=new ArrayList();

                foreach (ProductMDL item in productList)
                {
                    list.Add(item.Name);
                }

                this.cbProductList.DataSource = list;
                this.cbProductList.SelectedIndex = 0;
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 初始化数据视图
        /// </summary>
        private void InitialView()
        {
            try
            {
                _progressbar = new ProgressBarEx();

                InitialProductCombox();

                this.txtStart.Text = "0";
                this.txtEnd.Text = "0";
                this.lbCount.Text = "0";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void AddProductToDataGrid(ProductMDL productMDL, int startSeq, int endSeq)
        {
            try
            {

                this.txtErroInfo.Text = string.Empty;

                string pncode = "";

                OpProgressCtrl(true);

                InventoryItemDAL dal = new InventoryItemDAL();

                double div = (double)100 / ((endSeq - startSeq) + 1);

                int pos = 1;


                for (int i = startSeq; i <= endSeq; i++)
                {
                    pncode = String.Format("{0}{1:D6}{2}", productMDL.PCID.Substring(0, 6), i, productMDL.PCID.Substring(6, 2));

                    if (dal.InventoryItemIsExited(pncode) <= 0)
                    {
                        ///加载入库信息
                        InventoryItemMDL mdl = new InventoryItemMDL();
                        mdl.Name = productMDL.Name;
                        mdl.SN = pncode;
                        mdl.MD5 = COMM.MD5EncryptUtils.MD5Encrypt(pncode, System.Text.Encoding.UTF8);
                        mdl.CPCode = pncode.Substring(0, 2);
                        mdl.VRCode = pncode.Substring(2, 2);
                        mdl.PRCode = pncode.Substring(4, 2);
                        mdl.SBCode = pncode.Substring(12, 2);
                        mdl.REGDATE = pickTime;
                        mdl.DELIVER_STATUS = 0;
                        mdl.PRINT_STATUS = 0;
                        mdl.PN = "0";
                        mdl.MODEL = productMDL.PT_MODEL;
                        inputTable.Add(pncode, mdl);

                        _progressbar.SetProgerssInfo((int)(pos * div),
                                           String.Format("SN：{0} 产品添加成功！",
                                           Convert.ToString(pncode)));

                    }
                    else
                    {
                        strErrorInfo += pncode + "：已入库\r\n";
                        _progressbar.SetProgerssInfo((int)(pos * div),
                                           String.Format("SN：{0} 已入库",
                                           Convert.ToString(pncode)));
                
                    }

                    pos++;
                }


                this.txtErroInfo.Text = strErrorInfo;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                OpProgressCtrl(false);
            }
        }



        private void LoadSNGridInfo()
        {
            
            InitialDataGridViewHeader();
            IntialDaraGrid();
        }
        /// <summary>
        /// 初始化数据视图
        /// </summary>
        private void InitialDataGridViewHeader()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns.Clear();


            int clounmWidth = this.dataGridView1.Width / 5 - 1;


            DataGridViewColumn seqColumn = new DataGridViewTextBoxColumn();
            seqColumn.HeaderText = "序号";
            seqColumn.Name = "SEQ";
            seqColumn.Width = 60;// -clounmWidth / 4;
            seqColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(seqColumn);

            DataGridViewColumn codeColumn = new DataGridViewTextBoxColumn();
            codeColumn.HeaderText = "电桩编号";
            codeColumn.Name = "SN";
            codeColumn.Width = 160;// +clounmWidth / 4 + clounmWidth / 3;
            codeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(codeColumn);

            DataGridViewColumn pnColumn = new DataGridViewTextBoxColumn();
            pnColumn.HeaderText = "产品编号";
            pnColumn.Name = "PN";
            pnColumn.Width = 160;// +clounmWidth / 4 + clounmWidth / 3;
            pnColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(pnColumn);

            DataGridViewButtonColumn setColumn = new DataGridViewButtonColumn();
            setColumn.HeaderText = "设置";
            setColumn.Name = "SET";
            setColumn.Width = 60;// +clounmWidth / 4 + clounmWidth / 3;
            setColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(setColumn);


            DataGridViewColumn delColumn = new DataGridViewButtonColumn();
            delColumn.HeaderText = "操作";
            delColumn.Name = "DisNumber";
            delColumn.Width = 60;// / 4 + 7;
            delColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(delColumn);

            this.dataGridView1.Rows.Clear();
             

        }

        private void IntialDaraGrid()
        {
            try
            {
                this.dataGridView1.Rows.Clear();
                dataGridView1.AllowUserToAddRows = false;

                if (inputTable != null && inputTable.Count > 0)
                {

                    int i = 0;

                    foreach (DictionaryEntry k in inputTable)
                    {
                        i++;
                        InventoryItemMDL mdl=(InventoryItemMDL)k.Value;
                        if(mdl!=null)
                            this.dataGridView1.Rows.Add(i.ToString(), mdl.SN, mdl.PN, "设置", "删除");
                    }

                }


                this.dataGridView1.ClearSelection();

            }
            catch
            {
                throw;
            }
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

        private void btApply_Click(object sender, EventArgs e)
        {

            try
            {

                if (this.lbProductCode.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填选择产品类型！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.txtStart.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写起始序号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.txtEnd.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写结束序号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                int startSeq = 0;
                int endseq = 0;

                startSeq = Convert.ToInt32(this.txtStart.Text);
                endseq = Convert.ToInt32(this.txtEnd.Text);

                if (startSeq <= 0 || endseq<=0)
                {
                    MessageBox.Show("填写的序号不能为0！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if ((endseq - startSeq) < 0)
                {
                    MessageBox.Show("输入的结束序号不能小于起始序号！","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    return;
                }


                if ((endseq - startSeq) > 100)
                {
                    MessageBox.Show("输入的产品总数不能大于100！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }



                this.inputTable.Clear();

                pickTime = this.dateTimePicker1.Value;
                ProductMDL mdl=this.productList[this.cbProductList.SelectedIndex];

                AddProductToDataGrid(mdl, startSeq, endseq);
                this.lbCount.Text = this.inputTable.Count.ToString();
                LoadSNGridInfo();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }



        }

        private void cbProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbProductList != null && cbProductList.SelectedIndex < this.productList.Count)
                {
                    this.lbProductCode.Text = this.productList[cbProductList.SelectedIndex].PCID;

                    selectedModel = this.productList[cbProductList.SelectedIndex].PT_MODEL;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btAdd_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Yes;

            this.Close();
        }

        private void txtStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsDigit(e.KeyChar))
            //{

            //    MessageBox.Show("只能输入数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    e.Handled = true;
            //    this.txtStart.Text = String.Empty;
            //}

            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        private void txtEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsDigit(e.KeyChar))
            //{

            //    MessageBox.Show("只能输入数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    e.Handled = true;
            //    this.txtEnd.Text = String.Empty;
            //}

            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        private void ManualImportDlg_Load(object sender, EventArgs e)
        {

            InitialView();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView1_CellContentClick);

            try
            {



                DataGridViewRow rd = null;
                string key = string.Empty;
                DataSet dateset = null;

                switch (e.ColumnIndex)
                {
                    case 3:


                        //ProductDAL productDAL = new ProductDAL();
                        key = string.Empty;

                      //  dateset = (DataSet)dataGridView1.DataSource;

                       // rd =dateset.Tables[0].Rows[e.RowIndex];

                        rd = dataGridView1.Rows[e.RowIndex];
                           // Rows[e.RowIndex];

                        key=Convert.ToString(rd.Cells["SN"].Value);


                        if (key == null || key == string.Empty)
                            break;

                        InventoryInfoDlg dg = new InventoryInfoDlg();
                        dg.InventoryItem = (InventoryItemMDL)this.inputTable[key];

                        if(dg.ShowDialog()==DialogResult.Yes)
                        {
                            this.inputTable[key] = dg.InventoryItem;

                            LoadSNGridInfo();

                            MessageBox.Show("更新产品成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }

                     

                        break;
                    case 4:

                        if (MessageBox.Show("确定要删除该项吗！", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk)==DialogResult.OK)
                        {
                             key = string.Empty;

                             dateset = (DataSet)dataGridView1.DataSource;

                           // rd = dateset.Tables[0].Rows[e.RowIndex];

                          //  key = Convert.ToString(rd["SN"]);


                            if (key == null || key == string.Empty)
                                break;

                            this.inputTable.Remove(key);

                            LoadSNGridInfo();
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.pickTime = this.dateTimePicker1.Value;
        }
    }
}
