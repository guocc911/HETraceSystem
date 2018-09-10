using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Common;
using System.Text;
using System.Windows.Forms;
using HETraceSystem.Config;
using System.Text.RegularExpressions;
using DAL;
using MDL;

namespace HETraceSystem
{
    public partial class ProductCfgDlg : Form
    {

   
        private List<ProductTypeMDL> appTypes = null;


        private ProductMDL productMDL = null;


        private bool isUpdate = false;

       
        /// <summary>
        /// 产品信息
        /// </summary>
        public  ProductMDL ProductMDL
        {
            get { return productMDL; }
            set { productMDL = value; }
        }


        public bool Modidfy
        {
            get { return isUpdate; }
            set { isUpdate = value; }
        }



        public ProductCfgDlg()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 加载产品信息
        /// </summary>
        private void LoadProductInfo()
        {
            try
            {


                this.txtName.Text = this.productMDL.Name;
      
                this.txtCPCode.Text = this.productMDL.CP_CODE;
                this.txtCPCode.BorderStyle = BorderStyle.None;
                this.txtCPCode.ReadOnly = true;

                this.txtVRCode.Text = Convert.ToString(Convert.ToInt32(this.productMDL.VR_CODE,16));
               
                this.txtVRCode.BorderStyle = BorderStyle.None;
                this.txtVRCode.ReadOnly = true;

                this.txtAppType.Text = this.productMDL.PR_CODE;
                this.txtAppType.BorderStyle = BorderStyle.None;
                this.txtAppType.ReadOnly = true;

                this.txtSubCode.Text = Convert.ToString(Convert.ToInt32(this.productMDL.SB_CODE,16));
                this.txtSubCode.BorderStyle = BorderStyle.None;
                this.txtSubCode.ReadOnly = true;

                this.lbCBCode.Text = this.productMDL.CP_CODE+"-"
                                   + this.productMDL.VR_CODE+"-"
                                   + this.productMDL.PR_CODE+"-"
                                   + this.productMDL.SB_CODE;

                ArrayList ptList = new ArrayList();
                ptList.Add("交流");
                ptList.Add("直流");
                this.cbPileType.DataSource = ptList;
                this.cbPileType.SelectedIndex =(int) this.productMDL.PILETYPE;


                ArrayList atList = new ArrayList();
                atList.Add("国标");
                atList.Add("非国标");
                atList.Add("国标01");
                atList.Add("欧标");
                this.cbAdapterType.DataSource = atList;
                this.cbAdapterType.Text = this.productMDL.ADAPTER_TYPE;

                ArrayList modelList = new ArrayList();
                modelList.Add("合康交流");
                modelList.Add("合康直流");
                modelList.Add("畅的交流");
                modelList.Add("合康双枪直流");

                this.cbModelT.DataSource = modelList;
                this.cbModelT.SelectedIndex = (int)this.productMDL.PT_MODEL;


              //  this.cbPileType.SelectedIndex = (int)this.productMDL.PILETYPE;


                this.txtPortNum.Text = this.productMDL.PORT_NUM.ToString();
                this.txtPower.Text = this.productMDL.CHARGE_POWER.ToString();
                this.txtRemark.Text = this.productMDL.REMARK.ToString();

                if (!this.isUpdate)
                {
                    this.Text = "修改产品信息";
                    this.btModify.Visible = false;
                    this.btModify.Enabled = false;
                }
                else
                {
                    this.Text = "查看产品信息";
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



  

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }



        #region view change


        private void txtPortNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("只能输入数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
        }

        private void txtPower_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
            
                MessageBox.Show("只能输入数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                this.txtPower.Text = String.Empty;
            }
        }

    

        private void ProductRegDlg_Load(object sender, EventArgs e)
        {
            try
            {
                LoadProductInfo();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

     

        private void txtPower_TextChanged(object sender, EventArgs e)
        {
           Match m=   Regex.Match(this.txtPower.Text.Trim(),@"^[0-9]\d*\.\d{0,2}$|^\d*$");
           if(!m.Success)
           {
                 MessageBox.Show("请填写正确的数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
        }


        #endregion

        private void btModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtName.Text == null || this.txtName.Text.Length < 1)
                {
                    MessageBox.Show("请填产品名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.txtPortNum.Text == null || this.txtPortNum.Text.Length < 1)
                {
                    MessageBox.Show("请填写电桩接口数量！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.txtPower.Text == null || this.txtPower.Text.Length < 1)
                {
                    MessageBox.Show("请填写电桩功率！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }


                this.productMDL.Name = this.txtName.Text.Trim();
                this.productMDL.PILETYPE = (COMM.PileType)this.cbPileType.SelectedIndex;
                this.productMDL.CHARGE_POWER = Convert.ToDouble(this.txtPower.Text.Trim());
                this.productMDL.PORT_NUM = Convert.ToInt32(this.txtPortNum.Text.Trim());
                this.productMDL.ADAPTER_TYPE = this.cbAdapterType.Text.Trim();
                this.productMDL.PT_MODEL = (COMM.PtModel)this.cbModelT.SelectedIndex;
                this.productMDL.REMARK = this.txtRemark.Text.Trim();

                ProductDAL dal = new ProductDAL();

                if (dal.UpdateProductItem(this.productMDL) > 0)
                {

                    InventoryItemDAL inventDal = new InventoryItemDAL();
                    
                    if(inventDal.UpdateInventoryPileType(this.productMDL.PCID, (int)this.productMDL.PT_MODEL)>=0)
                    { 

                     MessageBox.Show("修改产品信息成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     this.DialogResult = DialogResult.Yes;
                     this.Close();
                     return;

                    }
                    MessageBox.Show("修改信息失败，请检查数据库连接状态！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("修改信息失败，请检查数据库连接状态！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPower_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void txtPortNum_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
