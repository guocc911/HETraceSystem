namespace HETraceSystem
{
    partial class ProductImportDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductImportDlg));
            this.headerPanel2 = new KIS.Controls.Windows.HeaderPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btAsmSetting = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbContact = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbPline = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCompany = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCount = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.codeShowCtrl1 = new HETraceSystem.Control.CodeShowCtrl();
            this.lbStatus = new System.Windows.Forms.Label();
            this.headerPanel1 = new KIS.Controls.Windows.HeaderPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btAddSingle = new System.Windows.Forms.Button();
            this.btManual = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonPile = new System.Windows.Forms.RadioButton();
            this.radioButtonTbox = new System.Windows.Forms.RadioButton();
            this.headerPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.headerPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel2
            // 
            this.headerPanel2.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel2.BorderStyle = KIS.Controls.BorderStyles.Single;
            this.headerPanel2.CaptionBeginColor = System.Drawing.SystemColors.InactiveCaption;
            this.headerPanel2.CaptionEndColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel2.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel2.CaptionHeight = 22;
            this.headerPanel2.CaptionPosition = KIS.Controls.CaptionPositions.Top;
            this.headerPanel2.CaptionText = "入库信息";
            this.headerPanel2.CaptionVisible = true;
            this.headerPanel2.Controls.Add(this.groupBox2);
            this.headerPanel2.Controls.Add(this.groupBox1);
            this.headerPanel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.headerPanel2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel2.GradientEnd = System.Drawing.SystemColors.Window;
            this.headerPanel2.GradientStart = System.Drawing.SystemColors.Window;
            this.headerPanel2.Location = new System.Drawing.Point(374, 23);
            this.headerPanel2.Name = "headerPanel2";
            this.headerPanel2.PanelIcon = null;
            this.headerPanel2.PanelIconVisible = false;
            this.headerPanel2.Size = new System.Drawing.Size(369, 463);
            this.headerPanel2.TabIndex = 4;
            this.headerPanel2.TextAntialias = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btAsmSetting);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lbContact);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lbPline);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbCompany);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lbCount);
            this.groupBox2.Location = new System.Drawing.Point(32, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 239);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "供应商信息";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(22, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 35;
            this.label6.Text = "批产时间：";
            // 
            // btAsmSetting
            // 
            this.btAsmSetting.Location = new System.Drawing.Point(249, 148);
            this.btAsmSetting.Name = "btAsmSetting";
            this.btAsmSetting.Size = new System.Drawing.Size(46, 23);
            this.btAsmSetting.TabIndex = 5;
            this.btAsmSetting.Text = "设置";
            this.btAsmSetting.UseVisualStyleBackColor = true;
            this.btAsmSetting.Click += new System.EventHandler(this.btAsmSetting_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(20, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "联系方式：";
            // 
            // lbContact
            // 
            this.lbContact.AutoSize = true;
            this.lbContact.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbContact.Location = new System.Drawing.Point(94, 79);
            this.lbContact.Name = "lbContact";
            this.lbContact.Size = new System.Drawing.Size(50, 17);
            this.lbContact.TabIndex = 50;
            this.lbContact.Text = "contact";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(20, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "入库数量：";
            // 
            // lbPline
            // 
            this.lbPline.AutoSize = true;
            this.lbPline.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbPline.Location = new System.Drawing.Point(94, 46);
            this.lbPline.Name = "lbPline";
            this.lbPline.Size = new System.Drawing.Size(36, 17);
            this.lbPline.TabIndex = 49;
            this.lbPline.Text = "pline";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 33;
            this.label1.Text = "生产厂商：";
            // 
            // lbCompany
            // 
            this.lbCompany.AutoSize = true;
            this.lbCompany.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbCompany.Location = new System.Drawing.Point(94, 15);
            this.lbCompany.Name = "lbCompany";
            this.lbCompany.Size = new System.Drawing.Size(61, 17);
            this.lbCompany.TabIndex = 46;
            this.lbCompany.Text = "company";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(94, 112);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(135, 23);
            this.dateTimePicker1.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(43, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 45;
            this.label2.Text = "产线:";
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbCount.Location = new System.Drawing.Point(96, 154);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(40, 17);
            this.lbCount.TabIndex = 40;
            this.lbCount.Text = "count";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.codeShowCtrl1);
            this.groupBox1.Controls.Add(this.lbStatus);
            this.groupBox1.Location = new System.Drawing.Point(32, 242);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 191);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "扫描信息:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(20, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(193, 17);
            this.label8.TabIndex = 43;
            this.label8.Text = "*请扫描条形码添加需要入库的商品";
            // 
            // codeShowCtrl1
            // 
            this.codeShowCtrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codeShowCtrl1.CodeType = COMM.CodeType.BarCode;
            this.codeShowCtrl1.Content = "0000";
            this.codeShowCtrl1.Location = new System.Drawing.Point(11, 23);
            this.codeShowCtrl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.codeShowCtrl1.Name = "codeShowCtrl1";
            this.codeShowCtrl1.Size = new System.Drawing.Size(284, 107);
            this.codeShowCtrl1.TabIndex = 38;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbStatus.Location = new System.Drawing.Point(17, 134);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(89, 17);
            this.lbStatus.TabIndex = 42;
            this.lbStatus.Text = "processStatus";
            // 
            // headerPanel1
            // 
            this.headerPanel1.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel1.BorderStyle = KIS.Controls.BorderStyles.Single;
            this.headerPanel1.CaptionBeginColor = System.Drawing.SystemColors.InactiveCaption;
            this.headerPanel1.CaptionEndColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel1.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel1.CaptionHeight = 22;
            this.headerPanel1.CaptionPosition = KIS.Controls.CaptionPositions.Top;
            this.headerPanel1.CaptionText = "扫描列表";
            this.headerPanel1.CaptionVisible = true;
            this.headerPanel1.Controls.Add(this.dataGridView1);
            this.headerPanel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.headerPanel1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel1.GradientEnd = System.Drawing.SystemColors.Window;
            this.headerPanel1.GradientStart = System.Drawing.SystemColors.Window;
            this.headerPanel1.Location = new System.Drawing.Point(26, 23);
            this.headerPanel1.Name = "headerPanel1";
            this.headerPanel1.PanelIcon = null;
            this.headerPanel1.PanelIconVisible = false;
            this.headerPanel1.Size = new System.Drawing.Size(317, 464);
            this.headerPanel1.TabIndex = 3;
            this.headerPanel1.TextAntialias = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(315, 440);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btAddSingle
            // 
            this.btAddSingle.Image = global::HETraceSystem.Properties.Resources.add;
            this.btAddSingle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAddSingle.Location = new System.Drawing.Point(27, 504);
            this.btAddSingle.Name = "btAddSingle";
            this.btAddSingle.Size = new System.Drawing.Size(88, 30);
            this.btAddSingle.TabIndex = 6;
            this.btAddSingle.Text = "单品添加";
            this.btAddSingle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAddSingle.UseVisualStyleBackColor = true;
            this.btAddSingle.Click += new System.EventHandler(this.btAddSingle_Click);
            // 
            // btManual
            // 
            this.btManual.Image = global::HETraceSystem.Properties.Resources.addt;
            this.btManual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btManual.Location = new System.Drawing.Point(155, 504);
            this.btManual.Name = "btManual";
            this.btManual.Size = new System.Drawing.Size(86, 30);
            this.btManual.TabIndex = 5;
            this.btManual.Text = "批量添加";
            this.btManual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btManual.UseVisualStyleBackColor = true;
            this.btManual.Click += new System.EventHandler(this.btManual_Click);
            // 
            // btCancel
            // 
            this.btCancel.Image = global::HETraceSystem.Properties.Resources.remove;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(642, 504);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 30);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "取 消";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btAdd
            // 
            this.btAdd.Image = global::HETraceSystem.Properties.Resources.playpng;
            this.btAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAdd.Location = new System.Drawing.Point(407, 504);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(80, 30);
            this.btAdd.TabIndex = 1;
            this.btAdd.Text = "入 库";
            this.btAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonTbox);
            this.groupBox3.Controls.Add(this.radioButtonPile);
            this.groupBox3.Location = new System.Drawing.Point(11, 180);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 53);
            this.groupBox3.TabIndex = 52;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "产品类型";
            // 
            // radioButtonPile
            // 
            this.radioButtonPile.AutoSize = true;
            this.radioButtonPile.Checked = true;
            this.radioButtonPile.Location = new System.Drawing.Point(31, 22);
            this.radioButtonPile.Name = "radioButtonPile";
            this.radioButtonPile.Size = new System.Drawing.Size(86, 21);
            this.radioButtonPile.TabIndex = 0;
            this.radioButtonPile.TabStop = true;
            this.radioButtonPile.Text = "充电桩相关";
            this.radioButtonPile.UseVisualStyleBackColor = true;
            this.radioButtonPile.CheckedChanged += new System.EventHandler(this.radioButtonPile_CheckedChanged);
            // 
            // radioButtonTbox
            // 
            this.radioButtonTbox.AutoSize = true;
            this.radioButtonTbox.Location = new System.Drawing.Point(139, 22);
            this.radioButtonTbox.Name = "radioButtonTbox";
            this.radioButtonTbox.Size = new System.Drawing.Size(74, 21);
            this.radioButtonTbox.TabIndex = 1;
            this.radioButtonTbox.Text = "车机相关";
            this.radioButtonTbox.UseVisualStyleBackColor = true;
            this.radioButtonTbox.CheckedChanged += new System.EventHandler(this.radioButtonTbox_CheckedChanged);
            // 
            // ProductImportDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(778, 557);
            this.Controls.Add(this.btAddSingle);
            this.Controls.Add(this.btManual);
            this.Controls.Add(this.headerPanel2);
            this.Controls.Add(this.headerPanel1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductImportDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "产品入库";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductImportDlg_FormClosing);
            this.Load += new System.EventHandler(this.ProductImportDlg_Load);
            this.headerPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.headerPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btCancel;
        private KIS.Controls.Windows.HeaderPanel headerPanel1;
        private KIS.Controls.Windows.HeaderPanel headerPanel2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private Control.CodeShowCtrl codeShowCtrl1;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btAsmSetting;
        private System.Windows.Forms.Label lbContact;
        private System.Windows.Forms.Label lbPline;
        private System.Windows.Forms.Label lbCompany;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btManual;
        private System.Windows.Forms.Button btAddSingle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonTbox;
        private System.Windows.Forms.RadioButton radioButtonPile;
    }
}