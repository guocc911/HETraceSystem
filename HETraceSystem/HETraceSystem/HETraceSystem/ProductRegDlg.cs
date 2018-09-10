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
    public partial class ProductRegDlg : Form
    {

        private DataTable products = null;

        private List<ProductTypeMDL> appTypes = null;

        private List<ProductMDL> productList = null;


        private string PCID = string.Empty;

        /// <summary>
        /// 公司编号
        /// </summary>
        private string CP=string.Empty;

        /// <summary>
        /// 版本号
        /// </summary>
        private int VR=-1;

        /// <summary>
        /// 产品型号
        /// </summary>
        private string PR=String.Empty;

        /// <summary>
        /// 小版本号
        /// </summary>
        private int SB = -1;




        public ProductRegDlg()
        {
            InitializeComponent();
        }


        private void LoadProductInfo()
        {
            try
            {
               // string code = string.Empty;
                PCID = String.Empty;

                CP = txtCPCode.Text.Trim().ToUpper();
                PCID += CP + "-";

                if (this.txtVRCode.Text != null && this.txtVRCode.Text.Length > 0)
                {
                    VR = Convert.ToInt32(this.txtVRCode.Text.Trim());
                    PCID += VR.ToString("X2") + "-";
                        //String.Format("{0:X000}", VR) + "-";
                }
                else
                {
                    PCID += "-";
                }

                if (appTypes != null)
                {
                    PR = ((ProductTypeMDL)appTypes[cbAppType.SelectedIndex]).TypeCode;
                    PCID += PR + "-"; ;
                }
                else
                {
                    PCID += "-";
                }


                if (this.txtSubCode.Text != null && this.txtSubCode.Text.Length > 0)
                {
                    SB = Convert.ToInt32(this.txtSubCode.Text.Trim());

                    PCID += SB.ToString("X2") ;
                }



                this.lbCBCode.Text = PCID;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 初始化树列表
        /// </summary>
        private void InitalTreeView()
        {

            try
            {

                if (productList != null)
                {
                   productList.Clear();
                   productList.TrimExcess();
                }

                if(appTypes==null)
                    return;


                ProductDAL dal = new ProductDAL();
                productList = dal.GetProducts();


                this.treeView1.Nodes.Clear();
                this.treeView1.ImageList = this.imageList1;

                foreach(ProductTypeMDL node in appTypes)
                {

                    if (productList != null)
                    {
                        if (node.TypeCode != "PL")
                            continue;

                        TreeNode pcidNode = new TreeNode(node.TypeName);
                        pcidNode.ImageIndex = 1;
                        pcidNode.SelectedImageIndex = 1;


                        int tagIndex = 0;

                      

                        foreach (ProductMDL mdl in productList)
                        {
                            if (node.TypeCode == mdl.PR_CODE)
                            {
                                TreeNode item = new TreeNode(mdl.Name);
                                item.Tag = tagIndex;
                                pcidNode.Nodes.Add(item);
                              
                            }

                            tagIndex++;
                        }

                        for (int i = 0; i < pcidNode.Nodes.Count; i++)
                        {
                            pcidNode.Nodes[i].ImageIndex = 0;
                            pcidNode.Nodes[i].SelectedImageIndex = 0;
                        }

                        this.treeView1.Nodes.Add(pcidNode);

                    }

                }
          

                //TreeNode pcidNode = new TreeNode("产品编号");
                //pcidNode.ImageIndex = 1;
                //pcidNode.SelectedImageIndex = 1;

                //this.treeView1.Nodes.Clear();
                //this.treeView1.ImageList = this.imageList1;
                //this.treeView1.Nodes.Add(pcidNode);


                //TreeNode ctNode = new TreeNode("车机产品");
                //ctNode.ImageIndex = 1;
                //ctNode.SelectedImageIndex = 1;

                //this.treeView1.Nodes.Add(ctNode);

                //foreach (ProductMDL mdl in productList)
                //{
                //    pcidNode.Nodes.Add(mdl.Name);


                //}

                //for (int i = 0; i < pcidNode.Nodes.Count; i++)
                //{
                //    pcidNode.Nodes[i].ImageIndex = 0;
                //    pcidNode.Nodes[i].SelectedImageIndex = 0;
                //}

                   this.treeView1.ExpandAll();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private void ResetProductInfo()
        {
            try
            {
                
                this.lbCBCode.Text = String.Empty;
   
                this.txtCPCode.Text = String.Empty;
                this.txtVRCode.Text = String.Empty;
                this.txtPortNum.Text =  String.Empty;;
                this.txtSubCode.Text = String.Empty;



                ArrayList ptList = new ArrayList();
                ptList.Add("交流");
                ptList.Add("直流");
                this.cbPileType.DataSource = ptList;
                this.cbPileType.SelectedIndex=0;


                ArrayList atList = new ArrayList();
                atList.Add("国标");
                atList.Add("非国标");
                atList.Add("国标01");
                atList.Add("欧标");


                this.cbAdapterType.DataSource = atList;
                this.cbAdapterType.SelectedIndex = 0;


                // Modify model
                // 电桩型号 0:合康交流 1:合康直流 2:畅的交流  3:合康双枪直流


                ArrayList modelList = new ArrayList();
                modelList.Add("合康交流");
                modelList.Add("合康直流");
                modelList.Add("畅的交流");
                modelList.Add("合康双枪直流");

                this.cbModelT.DataSource = modelList;
                this.cbModelT.SelectedIndex = 0;

                ResSetProductType();

                this.lbCBCode.Text = String.Empty;
        
               
            
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        private  List<ProductTypeMDL> GetProductTypes()
        {
            try
            {

                List<ProductTypeMDL>  ret=null;

                ProductTypeDAL ptDal = new ProductTypeDAL();

                ret = ptDal.GetProTypeList();
               

                return ret;

            }
            catch
            {
                throw;
            }


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
                    this.cbAppType.DataSource = applist;

                    this.cbAppType.SelectedIndex = 0;
                }
            }
            catch
            {
                throw;
            }
        }
  

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btConfigInfo_Click(object sender, EventArgs e)
        {
            ProductTypeCfgDlg dlg = new ProductTypeCfgDlg();

            if (dlg.ShowDialog() == DialogResult.OK) 
            {
                ResSetProductType();
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {


            if (this.CP==null || this.CP.Length < 1)
            {
                MessageBox.Show("请填写公司编号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.txtVRCode.Text==null||this.VR <1)
            {
                MessageBox.Show("请填写版本编号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.PR == null || this.PR.Length<1)
            {
                MessageBox.Show("请填写产品编号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            if (this.txtSubCode.Text==null||this.SB<1)
            {
                MessageBox.Show("请填写产品小型号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.txtName.Text == null || this.txtName.Text.Length <1)
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


          
                //封装产品
                ProductMDL mdl=new ProductMDL();
                mdl.PCID = this.PCID.Replace("-","");
                mdl.Name = this.txtName.Text.Trim();
                mdl.CP_CODE = this.CP;
                mdl.VR_CODE = this.VR.ToString("X2");
                mdl.PR_CODE = this.PR;
                mdl.SB_CODE = this.SB.ToString("X2");
                mdl.REG_DATE = DateTime.Now;
                mdl.REG_USER = "TEST";
                mdl.PILETYPE = (COMM.PileType)this.cbPileType.SelectedIndex;
                mdl.CHARGE_POWER = Convert.ToDouble(this.txtPower.Text.Trim());
                mdl.PORT_NUM = Convert.ToInt32(this.txtPortNum.Text.Trim());
                mdl.ADAPTER_TYPE = this.cbAdapterType.Text.Trim();
                mdl.PT_MODEL = (COMM.PtModel)this.cbModelT.SelectedIndex;
                mdl.REMARK = this.txtRemark.Text.Trim();

                ProductDAL dal = new ProductDAL();

                if (dal.ProductIsExited(mdl.PCID)>0)
                {
                    MessageBox.Show("该产品已经登记过。请更换编码！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (dal.InsertProductItem(mdl) > 0)
                {
                    MessageBox.Show("添加产品成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitalTreeView();
                    this.ResetProductInfo();
                    return;
                }
                else
                {
                    MessageBox.Show("", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


        }


        #region view change


        private void txtCPCode_TextChanged(object sender, EventArgs e)
        {
       
            string pat = @"[\u4e00-\u9fff]";
            Regex rg = new Regex(pat);
            Match mch = rg.Match(txtCPCode.Text);
            if (mch.Success)
            {
                MessageBox.Show("不能输入中文字符");

                this.txtCPCode.Text = string.Empty;
                return;
            }

            LoadProductInfo();
        }

        private void txtVRCode_TextChanged(object sender, EventArgs e)
        {

      

            LoadProductInfo();
        }

        private void cbAppType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProductInfo();
        }

        private void txtSubCode_TextChanged(object sender, EventArgs e)
        {
            LoadProductInfo();
        }

        private void cbPileType_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadProductInfo();
        }

        private void txtPortNum_TextChanged(object sender, EventArgs e)
        {
           // LoadProductInfo()
        }

        private void cbAdapterType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

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

        private void txtCPCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("只能输入字符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                this.txtCPCode.Text = String.Empty;
            }
        }

        private void ProductRegDlg_Load(object sender, EventArgs e)
        {
            try
            {
                ResetProductInfo();
                InitalTreeView();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void txtVRCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("只能输入数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                this.txtVRCode.Text = String.Empty;
            }
        }

        private void txtSubCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("只能输入字符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;

                this.txtSubCode.Text = String.Empty;
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

        private void 查看产品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.treeView1.SelectedNode.Tag == null)
                return;


            int index = (int)this.treeView1.SelectedNode.Tag;

            ProductCfgDlg dlg = new ProductCfgDlg();

           
            dlg.ProductMDL = this.productList[index];

            dlg.Modidfy = false;

            if (dlg.ShowDialog() == DialogResult.Yes)
            {
                InitalTreeView();
            }
        }

        private void 修改产品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = this.treeView1.SelectedNode.Index;

            ProductCfgDlg dlg = new ProductCfgDlg();

            dlg.ProductMDL = this.productList[index];
            dlg.Modidfy = true;

            if (dlg.ShowDialog() == DialogResult.Yes)
            {
                InitalTreeView();
            }
        }

        private void 删除产品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                int index = this.treeView1.SelectedNode.Index;

                if (index >= 0)
                {

                    if (MessageBox.Show("确定要删除该产品信息吗？", "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        ProductDAL dal = new ProductDAL();

                        if (dal.DeleteProduct(this.productList[index])>0)
                        {
                            MessageBox.Show("删除成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.InitalTreeView();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)//判断你点的是不是右键
                {
                    Point ClickPoint = new Point(e.X, e.Y);

                    TreeNode CurrentNode = treeView1.GetNodeAt(ClickPoint);

                    CurrentNode.ContextMenuStrip = contextMenuStrip1;

                    treeView1.SelectedNode = CurrentNode;//选中这个节点


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
