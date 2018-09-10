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
using RawInput_dll;

namespace HETraceSystem
{
    public partial class SingleImportDlg : Form
    {


        private List<ProductMDL> productList = null;


        private Hashtable inputTable = new Hashtable();

        private static RawKeyboard _keyboardDriver;


        private DateTime pickTime;

        private int isImport=0;

        private PtModel selectModel ;



        private string strErrorInfo = string.Empty;

        private string seqid;


        private InventoryItemMDL mdl;

        private ProductMDL ptMDL;




        public int IsImport
        {
            get { return isImport; }
            set { isImport = value; }
        }

        public InventoryItemMDL InventoryItem
        {
           get { return mdl; }
            set { mdl = value; }
        }

        /// <summary>
        /// 序列号
        /// </summary>
        public string SeqID
        {
            get { return seqid; }
            set { seqid = value; }
        }


        public SingleImportDlg()
        {
            InitializeComponent();
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

                ArrayList list = new ArrayList();

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
            

                InitialProductCombox();

                this.txtSeq.Text = "0";
    
                this.dateTimePicker1.Value=DateTime.Now;
                this.pickTime = DateTime.Now;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


 

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                     InventoryItemDAL dal = new InventoryItemDAL();


                     seqid = String.Format("{0}{1:D6}{2}", lbProductCode.Text.Substring(0, 6),Convert.ToInt32( txtSeq.Text.Trim()),
                                                                          lbProductCode.Text.Substring(6, 2));


                     if (this.isImport > 0)
                     {
                         if (dal.InventoryItemIsExited(seqid) > 0)
                         {
                             MessageBox.Show(seqid + "已入库,请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                             this.txtSeq.Text = "";
                             return;
                         }
                         else
                         {
                            
                             mdl = new InventoryItemMDL();
                             mdl.SN = seqid;
                             mdl.MD5 = COMM.MD5EncryptUtils.MD5Encrypt(seqid, System.Text.Encoding.UTF8);
                             mdl.Name = ptMDL.Name;
                             mdl.CPCode = seqid.Substring(0, 2);
                             mdl.VRCode = seqid.Substring(2, 2);
                             mdl.PRCode = seqid.Substring(4, 2);
                             mdl.SBCode = seqid.Substring(12, 2);
                             mdl.REGDATE = pickTime;
                             mdl.MODEL = ptMDL.PT_MODEL;
                             mdl.DELIVER_STATUS = 0;
                             mdl.PRINT_STATUS = 0;

                             this.DialogResult = DialogResult.Yes;

                             this.Close();
                         }

                     }
                     else
                     {



                         if (dal.InventoryItemIsExited(seqid) <= 0)
                         {
                             MessageBox.Show(seqid + "该产品未入库！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                             return;
                         }

                         //该产品是否发货
                         if (dal.ProductIsDelivery(seqid) <= 0)
                         {

                             ///加载入库信息
                             mdl = new InventoryItemMDL();
                             mdl.SN = seqid;
                             mdl.Name = ptMDL.Name;
                             mdl.MD5 = COMM.MD5EncryptUtils.MD5Encrypt(seqid, System.Text.Encoding.UTF8);
                             mdl.CPCode = seqid.Substring(0, 2);
                             mdl.VRCode = seqid.Substring(2, 2);
                             mdl.PRCode = seqid.Substring(4, 2);
                             mdl.SBCode = seqid.Substring(12, 2);
                             mdl.REGDATE = this.dateTimePicker1.Value;
                             mdl.MODEL = ptMDL.PT_MODEL;
                             mdl.DELIVER_STATUS = 0;
                             mdl.PRINT_STATUS = 0;
                             this.DialogResult = DialogResult.Yes;

                             this.Close();
                         }
                         else
                         {
                             MessageBox.Show(seqid + "该产品已出库！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                             return;
                         }
                     }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }




        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void SingleImportDlg_Load(object sender, EventArgs e)
        {
            try
            {

                if (this.isImport > 0)
                {
                    this.Text = "产品入库";
                }
                else
                {
                    this.Text = "产品出库";
                }
                InitialView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }




        private void txtSeq_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsDigit(e.KeyChar))
            //{
            //    MessageBox.Show("只能输入数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    e.Handled = true;
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

        private void cbProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbProductList != null && cbProductList.SelectedIndex < this.productList.Count)
                {
                    this.lbProductCode.Text = this.productList[cbProductList.SelectedIndex].PCID;
                    ptMDL = this.productList[cbProductList.SelectedIndex];
                }

            }
            catch (Exception ex)
            {

          
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.pickTime = this.dateTimePicker1.Value;
        }
    }
}
