namespace HETraceSystem
{
    partial class CTProductCfgDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CTProductCfgDlg));
            this.btModify = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbCBCode = new System.Windows.Forms.Label();
            this.txtVRCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCPCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAppType = new System.Windows.Forms.TextBox();
            this.txtSubCode = new System.Windows.Forms.TextBox();
            this.cbModelT = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btModify
            // 
            this.btModify.Location = new System.Drawing.Point(78, 390);
            this.btModify.Name = "btModify";
            this.btModify.Size = new System.Drawing.Size(75, 23);
            this.btModify.TabIndex = 1;
            this.btModify.Text = "修 改";
            this.btModify.UseVisualStyleBackColor = true;
            this.btModify.Click += new System.EventHandler(this.btModify_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(245, 390);
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Window;
            this.label13.Location = new System.Drawing.Point(97, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 56;
            this.label13.Text = "公司编号：";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtName.Location = new System.Drawing.Point(168, 70);
            this.txtName.MaxLength = 30;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(152, 21);
            this.txtName.TabIndex = 57;
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtRemark.Location = new System.Drawing.Point(165, 306);
            this.txtRemark.MaxLength = 200;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(206, 52);
            this.txtRemark.TabIndex = 55;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Window;
            this.label12.Location = new System.Drawing.Point(109, 309);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 54;
            this.label12.Text = "备注：";
            // 
            // lbCBCode
            // 
            this.lbCBCode.AutoSize = true;
            this.lbCBCode.Font = new System.Drawing.Font("Arial Narrow", 15.75F);
            this.lbCBCode.Location = new System.Drawing.Point(160, 28);
            this.lbCBCode.Name = "lbCBCode";
            this.lbCBCode.Size = new System.Drawing.Size(121, 25);
            this.lbCBCode.TabIndex = 43;
            this.lbCBCode.Text = "product_code";
            // 
            // txtVRCode
            // 
            this.txtVRCode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtVRCode.Location = new System.Drawing.Point(168, 144);
            this.txtVRCode.MaxLength = 2;
            this.txtVRCode.Name = "txtVRCode";
            this.txtVRCode.Size = new System.Drawing.Size(97, 21);
            this.txtVRCode.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Window;
            this.label7.Font = new System.Drawing.Font("黑体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(56, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 21);
            this.label7.TabIndex = 42;
            this.label7.Text = "产品型号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(88, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 39;
            this.label4.Text = "产品小型号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(97, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "产品名称：";
            // 
            // txtCPCode
            // 
            this.txtCPCode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCPCode.Location = new System.Drawing.Point(168, 108);
            this.txtCPCode.MaxLength = 2;
            this.txtCPCode.Name = "txtCPCode";
            this.txtCPCode.Size = new System.Drawing.Size(97, 21);
            this.txtCPCode.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(97, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "产品类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 37;
            this.label3.Text = "版本编号：";
            // 
            // txtAppType
            // 
            this.txtAppType.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtAppType.Location = new System.Drawing.Point(168, 180);
            this.txtAppType.MaxLength = 2;
            this.txtAppType.Name = "txtAppType";
            this.txtAppType.Size = new System.Drawing.Size(97, 21);
            this.txtAppType.TabIndex = 58;
            // 
            // txtSubCode
            // 
            this.txtSubCode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtSubCode.Location = new System.Drawing.Point(168, 219);
            this.txtSubCode.MaxLength = 2;
            this.txtSubCode.Name = "txtSubCode";
            this.txtSubCode.Size = new System.Drawing.Size(97, 21);
            this.txtSubCode.TabIndex = 59;
            // 
            // cbModelT
            // 
            this.cbModelT.FormattingEnabled = true;
            this.cbModelT.Location = new System.Drawing.Point(168, 262);
            this.cbModelT.Name = "cbModelT";
            this.cbModelT.Size = new System.Drawing.Size(97, 20);
            this.cbModelT.TabIndex = 61;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Window;
            this.label14.Location = new System.Drawing.Point(76, 265);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 12);
            this.label14.TabIndex = 60;
            this.label14.Text = "通信接口版本：";
            // 
            // CTProductCfgDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(399, 433);
            this.Controls.Add(this.cbModelT);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtSubCode);
            this.Controls.Add(this.txtAppType);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lbCBCode);
            this.Controls.Add(this.txtVRCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCPCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btModify);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CTProductCfgDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "车机产品注册";
            this.Load += new System.EventHandler(this.CTProductCfgDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btModify;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbCBCode;
        private System.Windows.Forms.TextBox txtVRCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCPCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAppType;
        private System.Windows.Forms.TextBox txtSubCode;
        private System.Windows.Forms.ComboBox cbModelT;
        private System.Windows.Forms.Label label14;
    }
}