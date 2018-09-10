namespace HETraceSystem
{
    partial class ProductRegDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductRegDlg));
            this.btAdd = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看产品信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改产品信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除产品信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headerPanel2 = new KIS.Controls.Windows.HeaderPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbAdapterType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPortNum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbPileType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSubCode = new System.Windows.Forms.TextBox();
            this.lbCBCode = new System.Windows.Forms.Label();
            this.txtVRCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAppType = new System.Windows.Forms.ComboBox();
            this.txtCPCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.headerPanel1 = new KIS.Controls.Windows.HeaderPanel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label14 = new System.Windows.Forms.Label();
            this.cbModelT = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1.SuspendLayout();
            this.headerPanel2.SuspendLayout();
            this.headerPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(310, 588);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 1;
            this.btAdd.Text = "添加";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(470, 588);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "取 消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "barcode.png");
            this.imageList1.Images.SetKeyName(1, "product.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看产品信息ToolStripMenuItem,
            this.修改产品信息ToolStripMenuItem,
            this.删除产品信息ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 70);
            // 
            // 查看产品信息ToolStripMenuItem
            // 
            this.查看产品信息ToolStripMenuItem.Name = "查看产品信息ToolStripMenuItem";
            this.查看产品信息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.查看产品信息ToolStripMenuItem.Text = "查看产品信息";
            this.查看产品信息ToolStripMenuItem.Click += new System.EventHandler(this.查看产品信息ToolStripMenuItem_Click);
            // 
            // 修改产品信息ToolStripMenuItem
            // 
            this.修改产品信息ToolStripMenuItem.Name = "修改产品信息ToolStripMenuItem";
            this.修改产品信息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.修改产品信息ToolStripMenuItem.Text = "修改产品信息";
            this.修改产品信息ToolStripMenuItem.Click += new System.EventHandler(this.修改产品信息ToolStripMenuItem_Click);
            // 
            // 删除产品信息ToolStripMenuItem
            // 
            this.删除产品信息ToolStripMenuItem.Name = "删除产品信息ToolStripMenuItem";
            this.删除产品信息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除产品信息ToolStripMenuItem.Text = "删除产品信息";
            this.删除产品信息ToolStripMenuItem.Click += new System.EventHandler(this.删除产品信息ToolStripMenuItem_Click);
            // 
            // headerPanel2
            // 
            this.headerPanel2.BackColor = System.Drawing.SystemColors.Window;
            this.headerPanel2.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel2.BorderStyle = KIS.Controls.BorderStyles.Single;
            this.headerPanel2.CaptionBeginColor = System.Drawing.SystemColors.InactiveCaption;
            this.headerPanel2.CaptionEndColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel2.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel2.CaptionHeight = 22;
            this.headerPanel2.CaptionPosition = KIS.Controls.CaptionPositions.Top;
            this.headerPanel2.CaptionText = "登记产品信息";
            this.headerPanel2.CaptionVisible = true;
            this.headerPanel2.Controls.Add(this.cbModelT);
            this.headerPanel2.Controls.Add(this.label14);
            this.headerPanel2.Controls.Add(this.label13);
            this.headerPanel2.Controls.Add(this.txtName);
            this.headerPanel2.Controls.Add(this.txtRemark);
            this.headerPanel2.Controls.Add(this.label12);
            this.headerPanel2.Controls.Add(this.label11);
            this.headerPanel2.Controls.Add(this.label6);
            this.headerPanel2.Controls.Add(this.cbAdapterType);
            this.headerPanel2.Controls.Add(this.label10);
            this.headerPanel2.Controls.Add(this.txtPower);
            this.headerPanel2.Controls.Add(this.label9);
            this.headerPanel2.Controls.Add(this.txtPortNum);
            this.headerPanel2.Controls.Add(this.label8);
            this.headerPanel2.Controls.Add(this.cbPileType);
            this.headerPanel2.Controls.Add(this.label5);
            this.headerPanel2.Controls.Add(this.txtSubCode);
            this.headerPanel2.Controls.Add(this.lbCBCode);
            this.headerPanel2.Controls.Add(this.txtVRCode);
            this.headerPanel2.Controls.Add(this.label7);
            this.headerPanel2.Controls.Add(this.label4);
            this.headerPanel2.Controls.Add(this.label1);
            this.headerPanel2.Controls.Add(this.cbAppType);
            this.headerPanel2.Controls.Add(this.txtCPCode);
            this.headerPanel2.Controls.Add(this.label2);
            this.headerPanel2.Controls.Add(this.label3);
            this.headerPanel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.headerPanel2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel2.GradientEnd = System.Drawing.SystemColors.Window;
            this.headerPanel2.GradientStart = System.Drawing.SystemColors.Window;
            this.headerPanel2.Location = new System.Drawing.Point(251, 13);
            this.headerPanel2.Name = "headerPanel2";
            this.headerPanel2.PanelIcon = null;
            this.headerPanel2.PanelIconVisible = false;
            this.headerPanel2.Size = new System.Drawing.Size(340, 569);
            this.headerPanel2.TabIndex = 4;
            this.headerPanel2.TextAntialias = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Window;
            this.label13.Location = new System.Drawing.Point(65, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 17);
            this.label13.TabIndex = 32;
            this.label13.Text = "公司编号：";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtName.Location = new System.Drawing.Point(136, 61);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(97, 23);
            this.txtName.TabIndex = 33;
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtRemark.Location = new System.Drawing.Point(133, 457);
            this.txtRemark.MaxLength = 200;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(168, 76);
            this.txtRemark.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Window;
            this.label12.Location = new System.Drawing.Point(89, 460);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 17);
            this.label12.TabIndex = 30;
            this.label12.Text = "备注：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Window;
            this.label11.Location = new System.Drawing.Point(205, 295);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 17);
            this.label11.TabIndex = 29;
            this.label11.Text = "个";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(205, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 17);
            this.label6.TabIndex = 28;
            this.label6.Text = "KW";
            // 
            // cbAdapterType
            // 
            this.cbAdapterType.FormattingEnabled = true;
            this.cbAdapterType.Location = new System.Drawing.Point(136, 371);
            this.cbAdapterType.Name = "cbAdapterType";
            this.cbAdapterType.Size = new System.Drawing.Size(97, 25);
            this.cbAdapterType.TabIndex = 27;
            this.cbAdapterType.SelectedIndexChanged += new System.EventHandler(this.cbAdapterType_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Window;
            this.label10.Location = new System.Drawing.Point(68, 376);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 17);
            this.label10.TabIndex = 26;
            this.label10.Text = "适配类型：";
            // 
            // txtPower
            // 
            this.txtPower.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPower.Location = new System.Drawing.Point(136, 330);
            this.txtPower.MaxLength = 10;
            this.txtPower.Name = "txtPower";
            this.txtPower.Size = new System.Drawing.Size(58, 23);
            this.txtPower.TabIndex = 25;
            this.txtPower.TextChanged += new System.EventHandler(this.txtPower_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Window;
            this.label9.Location = new System.Drawing.Point(89, 335);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "功率：";
            // 
            // txtPortNum
            // 
            this.txtPortNum.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPortNum.Location = new System.Drawing.Point(136, 292);
            this.txtPortNum.MaxLength = 2;
            this.txtPortNum.Name = "txtPortNum";
            this.txtPortNum.Size = new System.Drawing.Size(58, 23);
            this.txtPortNum.TabIndex = 23;
            this.txtPortNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPortNum_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Window;
            this.label8.Location = new System.Drawing.Point(41, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "充电接口数量：";
            // 
            // cbPileType
            // 
            this.cbPileType.FormattingEnabled = true;
            this.cbPileType.Location = new System.Drawing.Point(136, 251);
            this.cbPileType.Name = "cbPileType";
            this.cbPileType.Size = new System.Drawing.Size(97, 25);
            this.cbPileType.TabIndex = 21;
            this.cbPileType.SelectedIndexChanged += new System.EventHandler(this.cbPileType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(68, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "电桩类型：";
            // 
            // txtSubCode
            // 
            this.txtSubCode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtSubCode.Location = new System.Drawing.Point(136, 214);
            this.txtSubCode.MaxLength = 2;
            this.txtSubCode.Name = "txtSubCode";
            this.txtSubCode.Size = new System.Drawing.Size(97, 23);
            this.txtSubCode.TabIndex = 17;
            this.txtSubCode.TextChanged += new System.EventHandler(this.txtSubCode_TextChanged);
            this.txtSubCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSubCode_KeyPress);
            // 
            // lbCBCode
            // 
            this.lbCBCode.AutoSize = true;
            this.lbCBCode.Font = new System.Drawing.Font("Arial Narrow", 15.75F);
            this.lbCBCode.Location = new System.Drawing.Point(128, 21);
            this.lbCBCode.Name = "lbCBCode";
            this.lbCBCode.Size = new System.Drawing.Size(121, 25);
            this.lbCBCode.TabIndex = 19;
            this.lbCBCode.Text = "product_code";
            // 
            // txtVRCode
            // 
            this.txtVRCode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtVRCode.Location = new System.Drawing.Point(136, 135);
            this.txtVRCode.MaxLength = 2;
            this.txtVRCode.Name = "txtVRCode";
            this.txtVRCode.Size = new System.Drawing.Size(97, 23);
            this.txtVRCode.TabIndex = 16;
            this.txtVRCode.TextChanged += new System.EventHandler(this.txtVRCode_TextChanged);
            this.txtVRCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVRCode_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Window;
            this.label7.Font = new System.Drawing.Font("黑体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 21);
            this.label7.TabIndex = 18;
            this.label7.Text = "产品型号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(56, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "产品小型号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(65, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "产品名称：";
            // 
            // cbAppType
            // 
            this.cbAppType.FormattingEnabled = true;
            this.cbAppType.Location = new System.Drawing.Point(136, 173);
            this.cbAppType.Name = "cbAppType";
            this.cbAppType.Size = new System.Drawing.Size(97, 25);
            this.cbAppType.TabIndex = 11;
            this.cbAppType.SelectedIndexChanged += new System.EventHandler(this.cbAppType_SelectedIndexChanged);
            // 
            // txtCPCode
            // 
            this.txtCPCode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCPCode.Location = new System.Drawing.Point(136, 99);
            this.txtCPCode.MaxLength = 2;
            this.txtCPCode.Name = "txtCPCode";
            this.txtCPCode.Size = new System.Drawing.Size(97, 23);
            this.txtCPCode.TabIndex = 7;
            this.txtCPCode.TextChanged += new System.EventHandler(this.txtCPCode_TextChanged);
            this.txtCPCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCPCode_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(65, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "产品类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "版本编号：";
            // 
            // headerPanel1
            // 
            this.headerPanel1.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel1.BorderStyle = KIS.Controls.BorderStyles.None;
            this.headerPanel1.CaptionBeginColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel1.CaptionEndColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel1.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel1.CaptionHeight = 22;
            this.headerPanel1.CaptionPosition = KIS.Controls.CaptionPositions.Top;
            this.headerPanel1.CaptionText = "产品列表";
            this.headerPanel1.CaptionVisible = true;
            this.headerPanel1.Controls.Add(this.treeView1);
            this.headerPanel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.headerPanel1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel1.GradientEnd = System.Drawing.SystemColors.Window;
            this.headerPanel1.GradientStart = System.Drawing.SystemColors.Window;
            this.headerPanel1.Location = new System.Drawing.Point(12, 12);
            this.headerPanel1.Name = "headerPanel1";
            this.headerPanel1.PanelIcon = null;
            this.headerPanel1.PanelIconVisible = false;
            this.headerPanel1.Size = new System.Drawing.Size(233, 570);
            this.headerPanel1.TabIndex = 3;
            this.headerPanel1.TextAntialias = true;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(233, 548);
            this.treeView1.TabIndex = 0;
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Window;
            this.label14.Location = new System.Drawing.Point(41, 419);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 17);
            this.label14.TabIndex = 34;
            this.label14.Text = "通信接口版本：";
            // 
            // cbModelT
            // 
            this.cbModelT.FormattingEnabled = true;
            this.cbModelT.Location = new System.Drawing.Point(136, 416);
            this.cbModelT.Name = "cbModelT";
            this.cbModelT.Size = new System.Drawing.Size(97, 25);
            this.cbModelT.TabIndex = 35;
            // 
            // ProductRegDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(605, 623);
            this.Controls.Add(this.headerPanel2);
            this.Controls.Add(this.headerPanel1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductRegDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "电桩产品注册";
            this.Load += new System.EventHandler(this.ProductRegDlg_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.headerPanel2.ResumeLayout(false);
            this.headerPanel2.PerformLayout();
            this.headerPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCPCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbAppType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubCode;
        private System.Windows.Forms.TextBox txtVRCode;
        private KIS.Controls.Windows.HeaderPanel headerPanel1;
        private System.Windows.Forms.TreeView treeView1;
        private KIS.Controls.Windows.HeaderPanel headerPanel2;
        private System.Windows.Forms.ComboBox cbAdapterType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPortNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbPileType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbCBCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查看产品信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改产品信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除产品信息ToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbModelT;
        private System.Windows.Forms.Label label14;
    }
}