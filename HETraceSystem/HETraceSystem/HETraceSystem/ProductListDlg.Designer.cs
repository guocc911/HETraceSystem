namespace HETraceSystem
{
    partial class ProductListDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductListDlg));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.productListPanel = new KIS.Controls.Windows.HeaderPanel();
            this.treeViewProduct = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.productInfoPanel = new KIS.Controls.Windows.HeaderPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.InventorydataGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbPileCount = new System.Windows.Forms.Label();
            this.lbPageSize = new System.Windows.Forms.Label();
            this.lbSize = new System.Windows.Forms.Label();
            this.btPrevious = new System.Windows.Forms.Button();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.btNext = new System.Windows.Forms.Button();
            this.headerPanel1 = new KIS.Controls.Windows.HeaderPanel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.codeShowCtrl2 = new HETraceSystem.Control.CodeShowCtrl();
            this.codeShowCtrl3 = new HETraceSystem.Control.CodeShowCtrl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看库存信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印条形码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印二维码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印二维码60100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出二维码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印车机条码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.productListPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.productInfoPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InventorydataGridView)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.headerPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.productListPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(840, 504);
            this.splitContainer1.SplitterDistance = 172;
            this.splitContainer1.TabIndex = 0;
            // 
            // productListPanel
            // 
            this.productListPanel.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.productListPanel.BorderStyle = KIS.Controls.BorderStyles.Shadow;
            this.productListPanel.CaptionBeginColor = System.Drawing.SystemColors.InactiveCaption;
            this.productListPanel.CaptionEndColor = System.Drawing.SystemColors.ActiveCaption;
            this.productListPanel.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.productListPanel.CaptionHeight = 22;
            this.productListPanel.CaptionPosition = KIS.Controls.CaptionPositions.Top;
            this.productListPanel.CaptionText = "产品列表";
            this.productListPanel.CaptionVisible = true;
            this.productListPanel.Controls.Add(this.treeViewProduct);
            this.productListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productListPanel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.productListPanel.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.productListPanel.GradientEnd = System.Drawing.SystemColors.Window;
            this.productListPanel.GradientStart = System.Drawing.SystemColors.Window;
            this.productListPanel.Location = new System.Drawing.Point(0, 0);
            this.productListPanel.Name = "productListPanel";
            this.productListPanel.PanelIcon = null;
            this.productListPanel.PanelIconVisible = false;
            this.productListPanel.Size = new System.Drawing.Size(172, 504);
            this.productListPanel.TabIndex = 0;
            this.productListPanel.TextAntialias = true;
            // 
            // treeViewProduct
            // 
            this.treeViewProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewProduct.Location = new System.Drawing.Point(0, 0);
            this.treeViewProduct.Name = "treeViewProduct";
            this.treeViewProduct.Size = new System.Drawing.Size(165, 475);
            this.treeViewProduct.TabIndex = 1;
            this.treeViewProduct.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewProduct_MouseDown);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.productInfoPanel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.headerPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(664, 504);
            this.splitContainer2.SplitterDistance = 359;
            this.splitContainer2.TabIndex = 0;
            // 
            // productInfoPanel
            // 
            this.productInfoPanel.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.productInfoPanel.BorderStyle = KIS.Controls.BorderStyles.Shadow;
            this.productInfoPanel.CaptionBeginColor = System.Drawing.SystemColors.InactiveCaption;
            this.productInfoPanel.CaptionEndColor = System.Drawing.SystemColors.ActiveCaption;
            this.productInfoPanel.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.productInfoPanel.CaptionHeight = 22;
            this.productInfoPanel.CaptionPosition = KIS.Controls.CaptionPositions.Top;
            this.productInfoPanel.CaptionText = "库存列表";
            this.productInfoPanel.CaptionVisible = true;
            this.productInfoPanel.Controls.Add(this.tableLayoutPanel1);
            this.productInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productInfoPanel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.productInfoPanel.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.productInfoPanel.GradientEnd = System.Drawing.SystemColors.Window;
            this.productInfoPanel.GradientStart = System.Drawing.SystemColors.Window;
            this.productInfoPanel.Location = new System.Drawing.Point(0, 0);
            this.productInfoPanel.Name = "productInfoPanel";
            this.productInfoPanel.PanelIcon = null;
            this.productInfoPanel.PanelIconVisible = false;
            this.productInfoPanel.Size = new System.Drawing.Size(664, 359);
            this.productInfoPanel.TabIndex = 0;
            this.productInfoPanel.TextAntialias = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.InventorydataGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.27273F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.72727F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(657, 330);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // InventorydataGridView
            // 
            this.InventorydataGridView.AllowUserToAddRows = false;
            this.InventorydataGridView.AllowUserToDeleteRows = false;
            this.InventorydataGridView.AllowUserToOrderColumns = true;
            this.InventorydataGridView.AllowUserToResizeColumns = false;
            this.InventorydataGridView.AllowUserToResizeRows = false;
            this.InventorydataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InventorydataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InventorydataGridView.Location = new System.Drawing.Point(3, 3);
            this.InventorydataGridView.Name = "InventorydataGridView";
            this.InventorydataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.InventorydataGridView.RowTemplate.Height = 23;
            this.InventorydataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InventorydataGridView.Size = new System.Drawing.Size(651, 282);
            this.InventorydataGridView.TabIndex = 1;
            this.InventorydataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InventorydataGridView_CellContentClick);
            this.InventorydataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InventorydataGridView_CellDoubleClick);
            this.InventorydataGridView.Resize += new System.EventHandler(this.InventorydataGridView_Resize);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 341F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 291);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(651, 36);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flowLayoutPanel1.Controls.Add(this.lbPileCount);
            this.flowLayoutPanel1.Controls.Add(this.lbPageSize);
            this.flowLayoutPanel1.Controls.Add(this.lbSize);
            this.flowLayoutPanel1.Controls.Add(this.btPrevious);
            this.flowLayoutPanel1.Controls.Add(this.txtPage);
            this.flowLayoutPanel1.Controls.Add(this.btNext);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(317, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(331, 30);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // lbPileCount
            // 
            this.lbPileCount.AutoSize = true;
            this.lbPileCount.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lbPileCount.Location = new System.Drawing.Point(3, 0);
            this.lbPileCount.Name = "lbPileCount";
            this.lbPileCount.Size = new System.Drawing.Size(76, 20);
            this.lbPileCount.TabIndex = 20;
            this.lbPileCount.Text = "电桩总数:0";
            // 
            // lbPageSize
            // 
            this.lbPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPageSize.AutoSize = true;
            this.lbPageSize.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lbPageSize.Location = new System.Drawing.Point(85, 0);
            this.lbPageSize.Name = "lbPageSize";
            this.lbPageSize.Size = new System.Drawing.Size(54, 32);
            this.lbPageSize.TabIndex = 18;
            this.lbPageSize.Text = "总页数:";
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbSize.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lbSize.Location = new System.Drawing.Point(145, 0);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(34, 32);
            this.lbSize.TabIndex = 19;
            this.lbSize.Text = "size";
            // 
            // btPrevious
            // 
            this.btPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btPrevious.Image")));
            this.btPrevious.Location = new System.Drawing.Point(185, 3);
            this.btPrevious.Name = "btPrevious";
            this.btPrevious.Size = new System.Drawing.Size(26, 24);
            this.btPrevious.TabIndex = 15;
            this.btPrevious.UseVisualStyleBackColor = true;
            this.btPrevious.Click += new System.EventHandler(this.btPrevious_Click);
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(217, 3);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(56, 23);
            this.txtPage.TabIndex = 17;
            this.txtPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPage_KeyDown);
            // 
            // btNext
            // 
            this.btNext.Image = ((System.Drawing.Image)(resources.GetObject("btNext.Image")));
            this.btNext.Location = new System.Drawing.Point(279, 3);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(26, 26);
            this.btNext.TabIndex = 16;
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // headerPanel1
            // 
            this.headerPanel1.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel1.BorderStyle = KIS.Controls.BorderStyles.Shadow;
            this.headerPanel1.CaptionBeginColor = System.Drawing.SystemColors.InactiveCaption;
            this.headerPanel1.CaptionEndColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel1.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel1.CaptionHeight = 22;
            this.headerPanel1.CaptionPosition = KIS.Controls.CaptionPositions.Top;
            this.headerPanel1.CaptionText = "条码信息";
            this.headerPanel1.CaptionVisible = true;
            this.headerPanel1.Controls.Add(this.splitContainer3);
            this.headerPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.headerPanel1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel1.GradientEnd = System.Drawing.SystemColors.Window;
            this.headerPanel1.GradientStart = System.Drawing.SystemColors.Window;
            this.headerPanel1.Location = new System.Drawing.Point(0, 0);
            this.headerPanel1.Name = "headerPanel1";
            this.headerPanel1.PanelIcon = null;
            this.headerPanel1.PanelIconVisible = false;
            this.headerPanel1.Size = new System.Drawing.Size(664, 141);
            this.headerPanel1.TabIndex = 0;
            this.headerPanel1.TextAntialias = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.codeShowCtrl2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.codeShowCtrl3);
            this.splitContainer3.Size = new System.Drawing.Size(657, 112);
            this.splitContainer3.SplitterDistance = 253;
            this.splitContainer3.TabIndex = 0;
            // 
            // codeShowCtrl2
            // 
            this.codeShowCtrl2.CodeType = COMM.CodeType.BarCode;
            this.codeShowCtrl2.Content = "0000";
            this.codeShowCtrl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeShowCtrl2.Location = new System.Drawing.Point(0, 0);
            this.codeShowCtrl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.codeShowCtrl2.Name = "codeShowCtrl2";
            this.codeShowCtrl2.Size = new System.Drawing.Size(253, 112);
            this.codeShowCtrl2.TabIndex = 0;
            // 
            // codeShowCtrl3
            // 
            this.codeShowCtrl3.CodeType = COMM.CodeType.QRRcode;
            this.codeShowCtrl3.Content = "aGFwcHlldjovL3BpbGVpZC9hZDI5ZWZkZjdmODZjY2M2OTBiZWY1ZjAzMDk1YmUxMQ==";
            this.codeShowCtrl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeShowCtrl3.Location = new System.Drawing.Point(0, 0);
            this.codeShowCtrl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.codeShowCtrl3.Name = "codeShowCtrl3";
            this.codeShowCtrl3.Size = new System.Drawing.Size(400, 112);
            this.codeShowCtrl3.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看库存信息ToolStripMenuItem,
            this.打印条形码ToolStripMenuItem,
            this.打印二维码ToolStripMenuItem,
            this.打印二维码60100ToolStripMenuItem,
            this.导出二维码ToolStripMenuItem,
            this.打印车机条码ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(201, 136);
            // 
            // 查看库存信息ToolStripMenuItem
            // 
            this.查看库存信息ToolStripMenuItem.Name = "查看库存信息ToolStripMenuItem";
            this.查看库存信息ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.查看库存信息ToolStripMenuItem.Text = "查看库存信息";
            this.查看库存信息ToolStripMenuItem.Click += new System.EventHandler(this.查看库存信息ToolStripMenuItem_Click);
            // 
            // 打印条形码ToolStripMenuItem
            // 
            this.打印条形码ToolStripMenuItem.Name = "打印条形码ToolStripMenuItem";
            this.打印条形码ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.打印条形码ToolStripMenuItem.Text = "打印条形码";
            this.打印条形码ToolStripMenuItem.Click += new System.EventHandler(this.打印条形码ToolStripMenuItem_Click);
            // 
            // 打印二维码ToolStripMenuItem
            // 
            this.打印二维码ToolStripMenuItem.Name = "打印二维码ToolStripMenuItem";
            this.打印二维码ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.打印二维码ToolStripMenuItem.Text = "打印二维码（40*100）";
            this.打印二维码ToolStripMenuItem.Click += new System.EventHandler(this.打印二维码ToolStripMenuItem_Click);
            // 
            // 打印二维码60100ToolStripMenuItem
            // 
            this.打印二维码60100ToolStripMenuItem.Name = "打印二维码60100ToolStripMenuItem";
            this.打印二维码60100ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.打印二维码60100ToolStripMenuItem.Text = "打印二维码（60*100）";
            this.打印二维码60100ToolStripMenuItem.Click += new System.EventHandler(this.打印二维码60100ToolStripMenuItem_Click);
            // 
            // 导出二维码ToolStripMenuItem
            // 
            this.导出二维码ToolStripMenuItem.Name = "导出二维码ToolStripMenuItem";
            this.导出二维码ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.导出二维码ToolStripMenuItem.Text = "导出二维码";
            this.导出二维码ToolStripMenuItem.Click += new System.EventHandler(this.导出二维码ToolStripMenuItem_Click);
            // 
            // 打印车机条码ToolStripMenuItem
            // 
            this.打印车机条码ToolStripMenuItem.Name = "打印车机条码ToolStripMenuItem";
            this.打印车机条码ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.打印车机条码ToolStripMenuItem.Text = "打印车机条码";
            this.打印车机条码ToolStripMenuItem.Click += new System.EventHandler(this.打印测试条码ToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "barcode.png");
            this.imageList1.Images.SetKeyName(1, "product.png");
            this.imageList1.Images.SetKeyName(2, "BarcodeSelect.png");
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem1.Text = "刷新";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ProductListDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 504);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ProductListDlg";
            this.Text = "产品信息窗口";
            this.Load += new System.EventHandler(this.ProductListDlg_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.productListPanel.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.productInfoPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InventorydataGridView)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.headerPanel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private KIS.Controls.Windows.HeaderPanel productListPanel;
        private System.Windows.Forms.TreeView treeViewProduct;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private KIS.Controls.Windows.HeaderPanel productInfoPanel;
        private KIS.Controls.Windows.HeaderPanel headerPanel1;
        private Control.CodeShowCtrl codeShowCtrl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer3;
   
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem 打印条形码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印二维码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出二维码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看库存信息ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbPageSize;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.Button btPrevious;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.DataGridView InventorydataGridView;
        private System.Windows.Forms.Label lbPileCount;
        private System.Windows.Forms.ToolStripMenuItem 打印二维码60100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印车机条码ToolStripMenuItem;
        private Control.CodeShowCtrl codeShowCtrl2;
        private Control.CodeShowCtrl codeShowCtrl3;
    }
}