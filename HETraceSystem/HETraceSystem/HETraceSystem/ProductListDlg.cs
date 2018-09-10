using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Text.RegularExpressions;
using MDL;
using DAL;
using COMM;

namespace HETraceSystem
{
    public partial class ProductListDlg : DockContent
    {
       
        private List<ProductMDL> productList = null;

        private int _pageNum = -1;

        private TableInfo tableInfo = null;

        private List<ProductTypeMDL> appTypes = null;

        private string PR_CODE = String.Empty;


        #region table config

        private int selectedIndex = 0;

        private static int defualtRowSize = 30;

        private int columnSize = 10;

        private static int rowCount = 0;

        private int curPage = -1;

        private int rows = 0;

        private string cpid = string.Empty;

        private DataTable inventoryList;



        private delegate void DelegateShowCode(string nvalue);

        #endregion

        // private int 


        public ProductListDlg()
        {
            InitializeComponent();
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

              

            }
            catch
            {
                throw;
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

                if (appTypes == null)
                    return;


                ProductDAL dal = new ProductDAL();
                productList = dal.GetProducts();


                this.treeViewProduct.Nodes.Clear();
                this.treeViewProduct.ImageList = this.imageList1;

                foreach (ProductTypeMDL node in appTypes)
                {

                    if (productList != null)
                    {
       

                        TreeNode pcidNode = new TreeNode(node.TypeName);
                        pcidNode.Tag = null;
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

                        this.treeViewProduct.Nodes.Add(pcidNode);

                    }

                }

                //if (productList != null)
                //{
                //    productList.Clear();
                //    productList.TrimExcess();
                //}


                //ProductDAL dal = new ProductDAL();
                //productList = dal.GetProducts();

                //if (productList != null)
                //{
                //    TreeNode pcidNode = new TreeNode("产品编号");
                //    pcidNode.ImageIndex = 1;
                //    pcidNode.SelectedImageIndex = 1;

                //    this.treeViewProduct.Nodes.Clear();
                //    this.treeViewProduct.ImageList = this.imageList1;
                //    this.treeViewProduct.Nodes.Add(pcidNode);


                //    foreach (ProductMDL mdl in productList)
                //    {
                //        pcidNode.Nodes.Add(mdl.Name);

                //    }

                //    for (int i = 0; i < pcidNode.Nodes.Count; i++)
                //    {
                //        pcidNode.Nodes[i].ImageIndex = 0;
                //        pcidNode.Nodes[i].SelectedImageIndex = 2;
                //    }


                //    this.treeViewProduct.ExpandAll();
                //}
                //else
                //{
                //    TreeNode pcidNode = new TreeNode("产品编号");
                //    pcidNode.ImageIndex = 1;
                //    pcidNode.SelectedImageIndex = 1;


                //    this.treeViewProduct.Nodes.Clear();
                //    this.treeViewProduct.ImageList = this.imageList1;
                //    this.treeViewProduct.Nodes.Add(pcidNode);
                //    this.treeViewProduct.ExpandAll();
                //}

            }
            catch 
            {
                throw;
            }
        }

        private void ProductListDlg_Load(object sender, EventArgs e)
        {
            try
            {
                    ResSetProductType();
                    InitalTreeView();
                    UpdateInventoryInfo();
             
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 打印条形码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeliveryDlg dlg = new DeliveryDlg();
            //dlg.ProductInfo = this.productList[treeViewProduct.SelectedNode.Index];
            int index = Convert.ToInt32(treeViewProduct.SelectedNode.Tag);

            dlg.ProductInfo = this.productList[index];

            dlg.CodeType = CodeType.BarCode;

            dlg.PrintInfo = MainForm._workSpace.GetDeviceInfo(0);


            if (dlg.PrintInfo == null)
            {
                MessageBox.Show("请配置打印机，然后再进行打印！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dlg.ShowDialog() == DialogResult.OK)
            {
 
            }
        }

        private void 打印二维码ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DeliveryDlg dlg = new DeliveryDlg();
            //
           // dlg.ProductInfo = this.productList[treeViewProduct.SelectedNode.Index];
            int index = Convert.ToInt32(treeViewProduct.SelectedNode.Tag);

            dlg.ProductInfo = this.productList[index];
            dlg.PrintInfo = MainForm._workSpace.GetDeviceInfo(0);
            dlg.CodeType = CodeType.QRRcode;

            if (dlg.PrintInfo == null)
            {
                MessageBox.Show("请配置打印机，然后再进行打印！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dlg.ShowDialog() == DialogResult.OK)
            {
           
            }

            MainForm._workSpace.SetDeviceInfo(dlg.PrintInfo);
            MainForm._workSpace.Save();
        }

        private void 导出二维码ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OutFileDlg dlg = new OutFileDlg();
            dlg.ProductInfo = this.productList[treeViewProduct.SelectedNode.Index];

            if (dlg.ShowDialog() == DialogResult.OK)
            {

            }
        }



        private void 查看库存信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(treeViewProduct.SelectedNode.Tag);

                ProductMDL mdl = this.productList[index];

                this.cpid = mdl.PCID;

                this.PR_CODE = mdl.PR_CODE;

                this.curPage = -1;

                UpdateInventoryInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        } 
        private void treeViewProduct_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)//判断你点的是不是右键
                {
                    Point ClickPoint = new Point(e.X, e.Y);

                    TreeNode CurrentNode = treeViewProduct.GetNodeAt(ClickPoint);

                    if (CurrentNode == null)
                        return;

                    if (CurrentNode.Tag==null)
                    {


                        CurrentNode.ContextMenuStrip = contextMenuStrip2;
                        treeViewProduct.SelectedNode = CurrentNode;

 
                    }
                    else
                    {
                        CurrentNode.ContextMenuStrip = contextMenuStrip1;

                        treeViewProduct.SelectedNode = CurrentNode;//选中这个节点

                        int index = Convert.ToInt32(treeViewProduct.SelectedNode.Tag);

                        this.cpid = this.productList[index].PCID;

                        if( this.productList[index].CP_CODE!="CT")
                        {
                            SetMenuItem(true);
                        }
                        else
                        {

                            SetMenuItem(false);

                        }

                    }
                   // UpdateInventoryInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SetMenuItem(bool mType)
        {
            try
            {
                if(mType)
                {
                    打印条形码ToolStripMenuItem.Enabled = false;
                    打印二维码60100ToolStripMenuItem.Enabled = false;
                    打印二维码ToolStripMenuItem.Enabled = false;
                    导出二维码ToolStripMenuItem.Enabled = false;
                }
                else
                {
                    打印车机条码ToolStripMenuItem.Enabled = true;
                }

            }
            catch
            {
                throw;
            }

        }

        private void GeTboxInventoryInfo()
        {
            try
            {
                if (cpid == null || cpid == string.Empty)
                {

                    this.lbSize.Text = "0";
                    this.txtPage.Text = "0";

                    SetPage(-1);
                    return;
                }

                ExInventoryItemDAL dal = new ExInventoryItemDAL();

                this.tableInfo = new TableInfo();
                this.tableInfo.Count = dal.GetCount(cpid);
                this.tableInfo.PageSize = rowCount;
                this.tableInfo.SelectedIndex = this.selectedIndex;

                this.lbSize.Text = (this.tableInfo.PageNum + 1).ToString();
                if (curPage < 0)
                    this.tableInfo.SelectedPage = 0;
                else
                    this.tableInfo.SelectedPage = curPage;
                // _pageNum = 0;

                SetPage(this.tableInfo.SelectedPage);

                LoadTboxInfo();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 获取库存信息
        /// </summary>
        private void GetInventoryInfo()
        {
            try
            {
                if (cpid == null || cpid == string.Empty)
                {

                    this.lbSize.Text = "0";
                    this.txtPage.Text = "0";

                    SetPage(-1);
                    return;
                }

                InventoryItemDAL dal = new InventoryItemDAL();

                this.tableInfo = new TableInfo();
                this.tableInfo.Count = dal.GetCount(cpid);
                this.tableInfo.PageSize = rowCount;
                this.tableInfo.SelectedIndex = this.selectedIndex;

                this.lbSize.Text = (this.tableInfo.PageNum+1).ToString();
                if (curPage < 0)
                    this.tableInfo.SelectedPage = 0;
                else
                    this.tableInfo.SelectedPage = curPage;
               // _pageNum = 0;

                SetPage(this.tableInfo.SelectedPage);

                LoadPileInfo();
            }
            catch
            {
                throw;
            }
 
        }

        /// <summary>
        /// 设置页面
        /// </summary>
        /// <param name="num"></param>
        private void SetPage(int num)
        {
            //判断总页数是否小于零
            if (num < 0)
            {
                this.btPrevious.Enabled = false;
                this.btNext.Enabled = false;
                return; 
            }

            //判断是第一页
            if (num == 0)
            {
                this.txtPage.Text = "1";
                this.btPrevious.Enabled = false;

                if (this.tableInfo.PageNum > 1)
                    this.btNext.Enabled = true;
                else
                    this.btNext.Enabled = false;
            }

            //判断是否是最后一页
            if (num == (this.tableInfo.PageNum))
            {
                this.txtPage.Text = (this.tableInfo.SelectedPage + 1).ToString();
                this.btNext.Enabled = false;
                this.btPrevious.Enabled = true;
            }
            else 
            {
                this.btNext.Enabled = true;
                this.btPrevious.Enabled = true;
                this.txtPage.Text = String.Format("{0}", this.tableInfo.SelectedPage + 1);
                if(num ==0)
                {
                   this.btPrevious.Enabled = false;
                }

            }

 
        }

        /// <summary>
        /// 计算图表的行间距和行数
        /// </summary>
        private void ReloadRowSize()
        {
            //defualtRowSize = 25;

            //if ((this.InventorydataGridView.Height % defualtRowSize) > 0)
            //{
            //    ///分割行数
            //  //  int splicount = (double)this.InventorydataGridView.Height / (double)defualtRowSize;
            //    int splicount = 0;
            //    double divCount = (double)this.InventorydataGridView.Height / (double)defualtRowSize;
            //    splicount = (int)Math.Round(divCount, 2);
            //    rows = splicount;
            //    splicount--;
            //    rowCount = splicount;

            //    ///补齐分割的行数
            //    defualtRowSize = defualtRowSize + (int)((this.InventorydataGridView.Height % defualtRowSize) / splicount);
            //}

            //if ((this.InventorydataGridView.Height % defualtRowSize) > 0)
           // {
                ///分割行数
                //  int splicount = (double)this.InventorydataGridView.Height / (double)defualtRowSize;
                int splicount = 0;
                double divCount = (double)this.InventorydataGridView.Height / (double)defualtRowSize;
                splicount = (int)Math.Round(divCount, 2);
                rows = splicount;
                splicount--;
                rowCount = splicount;

                ///补齐分割的行数
                defualtRowSize = defualtRowSize + (int)((this.InventorydataGridView.Height % defualtRowSize) / splicount);
           // }
        }



        private void LoadPileInfo()
        {
            try
            {
                if (this.tableInfo!=null)
                  this.lbPileCount.Text ="电桩总数:" +this.tableInfo.Count.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadTboxInfo()
        {
            try
            {
                if (this.tableInfo != null)
                    this.lbPileCount.Text = "车机设备总数:" + this.tableInfo.Count.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 初始化库存列表
        /// </summary>
        private void LoadInventoryList()
        {
            try
            {

                InitialinevntoryGridHeader();

                if (cpid == null || cpid == string.Empty)
                    return;

                if (this.tableInfo.Count <= 0)
                    return;

                int[] pras = COMM.Utils.GetSplitPage(this.tableInfo.Count,
                                         this.tableInfo.SelectedPage,
                                         this.tableInfo.PageSize);


                curPage = this.tableInfo.SelectedPage;


                InventoryItemDAL dal = new InventoryItemDAL();

                inventoryList = dal.GetInventoryRecordPage(pras[0], pras[1], cpid);

              
                int seq = pras[0];

                foreach(DataRow item in inventoryList.Rows)
                {
                    DataGridViewRow row = new DataGridViewRow();
               
                    //序号
                    DataGridViewTextBoxCell seqCell = new DataGridViewTextBoxCell();
                    seq++;
                   // int seq = pras[0] + 1;
                    seqCell.Value = seq.ToString();
                    row.Cells.Add(seqCell);

                    //序列号
                    DataGridViewTextBoxCell snCell = new DataGridViewTextBoxCell();
                    snCell.Value = Convert.ToString(item["SN"]);
                    row.Cells.Add(snCell);

                    //
                    DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
                    nameCell.Value =  Convert.ToString(item["NAME"]);
                    row.Cells.Add(nameCell);


                    DataGridViewTextBoxCell pcidCell = new DataGridViewTextBoxCell();
                    pcidCell.Value =  Convert.ToString(item["PN"]);
                    row.Cells.Add(pcidCell);

                    DataGridViewTextBoxCell regCell = new DataGridViewTextBoxCell();
                    regCell.Value = Convert.ToDateTime(item["REG_DATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                    row.Cells.Add(regCell);

                    DataGridViewTextBoxCell statusCell = new DataGridViewTextBoxCell();
                    statusCell.Value = COMM.Utils.GetDeliveryStatus(Convert.ToInt32(item["DELIVER_STATUS"]));
                    row.Cells.Add(statusCell);

                    DataGridViewTextBoxCell typeCell = new DataGridViewTextBoxCell();
                    typeCell.Value = COMM.Utils.GetPileModel(Convert.ToInt32(item["PIPE_MODEL"]));
                    row.Cells.Add(typeCell);

                    DataGridViewTextBoxCell portNumCell = new DataGridViewTextBoxCell();
                    portNumCell.Value = Convert.ToString(item["PORT_NUM"]);
                    row.Cells.Add(portNumCell);

                    DataGridViewTextBoxCell chargeCell = new DataGridViewTextBoxCell();
                    chargeCell.Value = Convert.ToString(item["CHARGE_POWER"]);
                    row.Cells.Add(chargeCell);

                    DataGridViewTextBoxCell adapterCell = new DataGridViewTextBoxCell();
                    adapterCell.Value = Convert.ToString(item["ADAPTER_TYPE"]);
                    row.Cells.Add(adapterCell);

                    DataGridViewButtonCell setCell = new DataGridViewButtonCell();
                    setCell.Value = "设置";
                    row.Cells.Add(setCell);

                    row.Height = defualtRowSize;
                    row.DefaultCellStyle.Font = new Font("黑体", 10, FontStyle.Regular);

                    row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    this.InventorydataGridView.Rows.Add(row);

                    this.InventorydataGridView.ClearSelection();
                    this.InventorydataGridView.Columns[0].Visible = false;
                }

            }
            catch
            {
                throw;
            }

          
        }



        private void LoadExInventoryList()
        {
            try
            {
                InitialExInevntoryGridHeader();

                if (cpid == null || cpid == string.Empty)
                    return;

                if (this.tableInfo.Count <= 0)
                    return;

                int[] pras = COMM.Utils.GetSplitPage(this.tableInfo.Count,
                                         this.tableInfo.SelectedPage,
                                         this.tableInfo.PageSize);


                curPage = this.tableInfo.SelectedPage;


                ExInventoryItemDAL dal = new ExInventoryItemDAL();

                inventoryList = dal.GetInventoryRecordPage(pras[0], pras[1], cpid);


                int seq = pras[0];

                foreach (DataRow item in inventoryList.Rows)
                {
                    DataGridViewRow row = new DataGridViewRow();

                    //序号
                    DataGridViewTextBoxCell seqCell = new DataGridViewTextBoxCell();
                    seq++;
                    // int seq = pras[0] + 1;
                    seqCell.Value = seq.ToString();
                    row.Cells.Add(seqCell);

                    //序列号
                    DataGridViewTextBoxCell snCell = new DataGridViewTextBoxCell();
                    snCell.Value = Convert.ToString(item["SN"]);
                    row.Cells.Add(snCell);

                    //
                    DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
                    nameCell.Value = Convert.ToString(item["NAME"]);
                    row.Cells.Add(nameCell);


                    DataGridViewTextBoxCell pcidCell = new DataGridViewTextBoxCell();
                    pcidCell.Value = Convert.ToString(item["IMEI"]);
                    row.Cells.Add(pcidCell);

                    DataGridViewTextBoxCell regCell = new DataGridViewTextBoxCell();
                    regCell.Value = Convert.ToDateTime(item["REG_DATE"]).ToString("yyyy-MM-dd HH:mm:ss");
                    row.Cells.Add(regCell);

                    DataGridViewTextBoxCell statusCell = new DataGridViewTextBoxCell();
                    statusCell.Value = COMM.Utils.GetDeliveryStatus(Convert.ToInt32(item["DELIVER_STATUS"]));
                    row.Cells.Add(statusCell);

                    DataGridViewTextBoxCell typeCell = new DataGridViewTextBoxCell();
                    typeCell.Value = COMM.Utils.GetTboxModel(Convert.ToInt32(item["MODEL"]));
                    row.Cells.Add(typeCell);


                    DataGridViewButtonCell setCell = new DataGridViewButtonCell();
                    setCell.Value = "设置";
                    row.Cells.Add(setCell);

                    row.Height = defualtRowSize;
                    row.DefaultCellStyle.Font = new Font("黑体", 10, FontStyle.Regular);

                    row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    this.InventorydataGridView.Rows.Add(row);

                    this.InventorydataGridView.ClearSelection();
                    this.InventorydataGridView.Columns[0].Visible = false;
                }
            }
            catch
            {
                throw;
            }

        }

        private void InitialExInevntoryGridHeader()
        {

            InventorydataGridView.RowHeadersVisible = false;
            InventorydataGridView.Columns.Clear();
            //int columnWidth = (this.InventorydataGridView.Width / 11);
            int columnWidth = (this.InventorydataGridView.Width / 10);

            DataGridViewColumn seqColumn = new DataGridViewTextBoxColumn();
            seqColumn.HeaderText = "序号";
            seqColumn.Name = "SEQ";
            seqColumn.Width = columnWidth;
            seqColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(seqColumn);

            DataGridViewColumn snColumn = new DataGridViewTextBoxColumn();
            snColumn.HeaderText = "产品编号";
            snColumn.Name = "SN";
            snColumn.Width = columnWidth + columnWidth/2;
            snColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(snColumn);

            DataGridViewColumn pNameColumn = new DataGridViewTextBoxColumn();
            pNameColumn.HeaderText = "产品名称";
            pNameColumn.Name = "NAME";
            pNameColumn.Width = columnWidth + columnWidth / 2;
            pNameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(pNameColumn);

            DataGridViewColumn pcidColumn = new DataGridViewTextBoxColumn();
            pcidColumn.HeaderText = "IMEI";
            pcidColumn.Name = "IMEI";
            pcidColumn.Width = columnWidth + columnWidth;
            pcidColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(pcidColumn);
            //string strSql = "select tl.SN,tl.NAME,tl.PCID,tl.REG_DATE,tl.PRINT_STATUS,tl.DELIVER_STATUS,p.NAME,p.PILE_TYPE,p.PORT_NUM,p.CHARGE_POWER "
            //                 + " from tlb_inventory_list tl,tlb_product p WHERE  tl.PCID=p.PCID and tl.PCID='{0}'  order by REG_DATE asc limit {1},{2}";

            DataGridViewColumn regDateColumn = new DataGridViewTextBoxColumn();
            regDateColumn.HeaderText = "入库时间";
            regDateColumn.Name = "REG_DATE";
            regDateColumn.Width = columnWidth + columnWidth / 2;
            regDateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(regDateColumn);


            DataGridViewColumn printColumn = new DataGridViewTextBoxColumn();
            printColumn.HeaderText = "出库状态";
            printColumn.Name = "DELIVER_STATUS";
            printColumn.Width = columnWidth;
            printColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(printColumn);

            DataGridViewColumn pileTypeColumn = new DataGridViewTextBoxColumn();
            pileTypeColumn.HeaderText = "通信类型";
            pileTypeColumn.Name = "MODEL";
            pileTypeColumn.Width = columnWidth + columnWidth / 2;
            pileTypeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(pileTypeColumn);

    


            DataGridViewButtonColumn setColumn = new DataGridViewButtonColumn();
            setColumn.HeaderText = "设置";
            setColumn.Name = "SET";
            setColumn.Width = columnWidth;// +clounmWidth / 4 + clounmWidth / 3;
            setColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(setColumn);

            this.InventorydataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

        }
        /// <summary>
        /// 初始化库存数据
        /// </summary>
        private void InitialinevntoryGridHeader()
        {


            InventorydataGridView.RowHeadersVisible = false;
            InventorydataGridView.Columns.Clear();
            //int columnWidth = (this.InventorydataGridView.Width / 11);
            int columnWidth = (this.InventorydataGridView.Width / 10);

            DataGridViewColumn seqColumn = new DataGridViewTextBoxColumn();
            seqColumn.HeaderText = "序号";
            seqColumn.Name = "SEQ";
            seqColumn.Width = columnWidth;
            seqColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(seqColumn);

            DataGridViewColumn snColumn = new DataGridViewTextBoxColumn();
            snColumn.HeaderText = "电桩编号";
            snColumn.Name = "SN";
            snColumn.Width = columnWidth;
            snColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(snColumn);

            DataGridViewColumn pNameColumn = new DataGridViewTextBoxColumn();
            pNameColumn.HeaderText = "产品名称";
            pNameColumn.Name = "NAME";
            pNameColumn.Width = columnWidth;
            pNameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(pNameColumn);

            DataGridViewColumn pcidColumn = new DataGridViewTextBoxColumn();
            pcidColumn.HeaderText = "产品编码";
            pcidColumn.Name = "PN";
            pcidColumn.Width = columnWidth;
            pcidColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(pcidColumn);
            //string strSql = "select tl.SN,tl.NAME,tl.PCID,tl.REG_DATE,tl.PRINT_STATUS,tl.DELIVER_STATUS,p.NAME,p.PILE_TYPE,p.PORT_NUM,p.CHARGE_POWER "
            //                 + " from tlb_inventory_list tl,tlb_product p WHERE  tl.PCID=p.PCID and tl.PCID='{0}'  order by REG_DATE asc limit {1},{2}";

            DataGridViewColumn regDateColumn = new DataGridViewTextBoxColumn();
            regDateColumn.HeaderText = "入库时间";
            regDateColumn.Name = "REG_DATE";
            regDateColumn.Width = columnWidth;
            regDateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(regDateColumn);


            DataGridViewColumn printColumn = new DataGridViewTextBoxColumn();
            printColumn.HeaderText = "出库状态";
            printColumn.Name = "DELIVER_STATUS";
            printColumn.Width = columnWidth;
            printColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(printColumn);

            DataGridViewColumn pileTypeColumn = new DataGridViewTextBoxColumn();
            pileTypeColumn.HeaderText = "电桩类型";
            pileTypeColumn.Name = "PILE_TYPE";
            pileTypeColumn.Width = columnWidth;
            pileTypeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(pileTypeColumn);

            DataGridViewColumn portNumColumn = new DataGridViewTextBoxColumn();
            portNumColumn.HeaderText = "接口数量";
            portNumColumn.Name = "PORT_NUM";
            portNumColumn.Width = columnWidth;
            portNumColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(portNumColumn);

            DataGridViewColumn chargeColumn = new DataGridViewTextBoxColumn();
            chargeColumn.HeaderText = "功率";
            chargeColumn.Name = "CHARGE_POWER";
            chargeColumn.Width = columnWidth;
            chargeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(chargeColumn);

            DataGridViewColumn adapterColumn = new DataGridViewTextBoxColumn();
            adapterColumn.HeaderText = "接口类型";
            adapterColumn.Name = "ADAPTER_TYPE";
            adapterColumn.Width = columnWidth;
            adapterColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(adapterColumn);


            //DataGridViewColumn VersionColumn = new DataGridViewTextBoxColumn();
            //VersionColumn.HeaderText = "接口版本";
            //VersionColumn.Name = "ADAPTER_TYPE";
            //VersionColumn.Width = columnWidth;
            //VersionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.InventorydataGridView.Columns.Add(VersionColumn);


            DataGridViewButtonColumn setColumn = new DataGridViewButtonColumn();
            setColumn.HeaderText = "设置";
            setColumn.Name = "SET";
            setColumn.Width = columnWidth;// +clounmWidth / 4 + clounmWidth / 3;
            setColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.InventorydataGridView.Columns.Add(setColumn);

            this.InventorydataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

       
        }


        /// <summary>
        /// 更新库存信息表
        /// </summary>
        private void UpdateInventoryInfo()
        {

            try
            {
                ReloadRowSize();
                LoadGridView();
            }
            catch
            {
                throw;
            }

        }


        private void LoadGridView()
        {
                if (PR_CODE != "CT")
                {
                    GetInventoryInfo();
                    LoadInventoryList();
                }
                else
                {
                    GeTboxInventoryInfo();
                    LoadExInventoryList();
                }
         
        }

        private void RefereshGridview()
        {
            if (PR_CODE != "CT")
            {
               // GetInventoryInfo();
                LoadInventoryList();
            }
            else
            {
                //GeTboxInventoryInfo();
                LoadExInventoryList();
            }
        }




        private void btNext_Click(object sender, EventArgs e)
        {
            if (this.tableInfo != null)
            {
                this.tableInfo.SelectedPage = this.tableInfo.SelectedPage + 1;
                SetPage(this.tableInfo.SelectedPage);
                
               // LoadInventoryList();
                RefereshGridview();
            }
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            if (this.tableInfo != null)
            {
                this.tableInfo.SelectedPage = this.tableInfo.SelectedPage - 1;
                SetPage(this.tableInfo.SelectedPage);
                RefereshGridview();
                //LoadInventoryList();
            }
        }

        private void txtPage_TextChanged(object sender, EventArgs e)
        {

           Match m=   Regex.Match(this.txtPage.Text.Trim(),@"^[0-9]*$");

           if(!m.Success)
           {

               int pageIndex=Convert.ToInt32(this.txtPage.Text.Trim());

               //if (pageIndex < 0 || pageIndex>)

                 MessageBox.Show("请填写正确的数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
        
        }
      
        private void InventorydataGridView_Resize(object sender, EventArgs e)
        {

            try
            {
                UpdateInventoryInfo();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }



        private void DisplayNewCode(string code)
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new DelegateShowCode(DisplayNewCode), new object[] { code });
            }
            else
            {

                this.codeShowCtrl2.Content = code;
                this.codeShowCtrl2.Update();
                this.codeShowCtrl3.Content = code;
                this.codeShowCtrl3.Update();
 
            }
 
        }

        private void InventorydataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.InventorydataGridView.CellDoubleClick -= new DataGridViewCellEventHandler(InventorydataGridView_CellDoubleClick);

            try
            {


                string key = InventorydataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();

                DisplayNewCode(key);

                switch (e.ColumnIndex)
                {
                    case 10:
                      //  InventorydataGridView.Rows[e.RowIndex];
                           // Rows[e.RowIndex];

                        key = Convert.ToString(InventorydataGridView.Rows[e.RowIndex].Cells["SN"].Value);


                        if (key == null || key == string.Empty)
                            break;

                        InventoryInfoDlg dg = new InventoryInfoDlg();

                        InventoryItemDAL dal=new InventoryItemDAL ();

                        InventoryItemMDL mdl=dal.GetInventoryItem(key);

                        if(mdl==null)
                            break;

                        dg.InventoryItem = mdl;//inventoryList[e.RowIndex];

                        if(dg.ShowDialog()==DialogResult.Yes)
                        {
                            dal.UpdateInventoryItem(dg.InventoryItem);
                        
                            MessageBox.Show("更新产品成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            this.InventorydataGridView.CellDoubleClick += new DataGridViewCellEventHandler(InventorydataGridView_CellDoubleClick);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InitalTreeView();
        }

        private void txtPage_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                if (this.tableInfo == null)
                {
                    this.txtPage.Text = "0";
                    return;
                }

                int pageNum = Convert.ToInt32(this.txtPage.Text.Trim());

                if (pageNum < 0)
                    pageNum = 1;

                


                if (pageNum <= (this.tableInfo.PageNum + 1))
                {
                    this.tableInfo.SelectedPage = pageNum-1;
                    SetPage(this.tableInfo.SelectedPage);
                    RefereshGridview();
                    //LoadInventoryList();
                }
                else  
                {
                    this.txtPage.Text = (this.tableInfo.PageNum + 1).ToString();
                }
           
 
            }

        }

        private void InventorydataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            this.InventorydataGridView.CellContentClick -= new DataGridViewCellEventHandler(InventorydataGridView_CellContentClick);

            try
            {


                string key = InventorydataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();


                switch (e.ColumnIndex)
                {

                    case 7:
                        if (PR_CODE != "CT")
                            return;

                        key = Convert.ToString(InventorydataGridView.Rows[e.RowIndex].Cells["SN"].Value);
                        
                        if (key == null || key == string.Empty)
                            break;

                        ExInventoryInfoDlg exdg = new ExInventoryInfoDlg();

                        ExInventoryItemDAL exdal = new ExInventoryItemDAL();

                        ExInventoryItemMDL exmdl = exdal.GetInventoryItem(key);

                        if (exmdl == null)
                            break;

                        exdg.InventoryItem = exmdl;//inventoryList[e.RowIndex];

                        if (exdg.ShowDialog() == DialogResult.Yes)
                        {
                            exdal.UpdateInventoryItem(exdg.InventoryItem);
                            UpdateInventoryInfo();

                            MessageBox.Show("更新产品成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }

                        break;

                    case 10:
                        //  InventorydataGridView.Rows[e.RowIndex];
                        // Rows[e.RowIndex];
                        if (PR_CODE == "CT")
                            return;

                        key = Convert.ToString(InventorydataGridView.Rows[e.RowIndex].Cells["SN"].Value);


                        if (key == null || key == string.Empty)
                            break;

                        InventoryInfoDlg dg = new InventoryInfoDlg();

                        InventoryItemDAL dal = new InventoryItemDAL();

                        InventoryItemMDL mdl = dal.GetInventoryItem(key);

                        if (mdl == null)
                            break;

                        dg.InventoryItem = mdl;//inventoryList[e.RowIndex];

                        if (dg.ShowDialog() == DialogResult.Yes)
                        {
                            dal.UpdateInventoryItem(dg.InventoryItem);
                            UpdateInventoryInfo();

                            MessageBox.Show("更新产品成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            this.InventorydataGridView.CellContentClick += new DataGridViewCellEventHandler(InventorydataGridView_CellContentClick);
        }

        private void 打印二维码60100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeliveryDlg dlg = new DeliveryDlg();

            dlg.ProductInfo = this.productList[treeViewProduct.SelectedNode.Index];

            dlg.PrintInfo = MainForm._workSpace.GetDeviceInfo(0);
            dlg.CodeType = CodeType.QRRcode2;
            if (dlg.PrintInfo == null)
            {
                MessageBox.Show("请配置打印机，然后再进行打印！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dlg.ShowDialog() == DialogResult.OK)
            {

            }

            MainForm._workSpace.SetDeviceInfo(dlg.PrintInfo);
            MainForm._workSpace.Save();
        }

        private void 打印测试条码ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (treeViewProduct.SelectedNode.Tag == null)
                return;

            int index = Convert.ToInt32(treeViewProduct.SelectedNode.Tag);

            DeliveryDlg dlg = new DeliveryDlg();
           
            dlg.ProductInfo = this.productList[index];

            dlg.CodeType = CodeType.TboxBarCode;
            dlg.PrintInfo = MainForm._workSpace.GetDeviceInfo(0);


            if (dlg.PrintInfo == null)
            {
                MessageBox.Show("请配置打印机，然后再进行打印！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dlg.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
