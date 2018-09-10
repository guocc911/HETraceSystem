namespace HETraceSystem
{
    partial class OutFileDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutFileDlg));
            this.headerPanel2 = new KIS.Controls.Windows.HeaderPanel();
            this.btStop = new System.Windows.Forms.Button();
            this.ckBoxRecord = new System.Windows.Forms.CheckBox();
            this.lbPrintStatus = new System.Windows.Forms.Label();
            this.lbCodeType = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOutPut = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbSN = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.headerPanel1 = new KIS.Controls.Windows.HeaderPanel();
            this.btSelectFile = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.headerPanel2.SuspendLayout();
            this.headerPanel1.SuspendLayout();
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
            this.headerPanel2.CaptionText = "产品信息";
            this.headerPanel2.CaptionVisible = true;
            this.headerPanel2.Controls.Add(this.btStop);
            this.headerPanel2.Controls.Add(this.ckBoxRecord);
            this.headerPanel2.Controls.Add(this.lbPrintStatus);
            this.headerPanel2.Controls.Add(this.lbCodeType);
            this.headerPanel2.Controls.Add(this.label6);
            this.headerPanel2.Controls.Add(this.label3);
            this.headerPanel2.Controls.Add(this.label2);
            this.headerPanel2.Controls.Add(this.txtEnd);
            this.headerPanel2.Controls.Add(this.txtStart);
            this.headerPanel2.Controls.Add(this.btCancel);
            this.headerPanel2.Controls.Add(this.btOutPut);
            this.headerPanel2.Controls.Add(this.label5);
            this.headerPanel2.Controls.Add(this.progressBar1);
            this.headerPanel2.Controls.Add(this.lbSN);
            this.headerPanel2.Controls.Add(this.label1);
            this.headerPanel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.headerPanel2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel2.GradientEnd = System.Drawing.SystemColors.Window;
            this.headerPanel2.GradientStart = System.Drawing.SystemColors.Window;
            this.headerPanel2.Location = new System.Drawing.Point(7, 136);
            this.headerPanel2.Name = "headerPanel2";
            this.headerPanel2.PanelIcon = null;
            this.headerPanel2.PanelIconVisible = false;
            this.headerPanel2.Size = new System.Drawing.Size(560, 275);
            this.headerPanel2.TabIndex = 5;
            this.headerPanel2.TextAntialias = true;
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(246, 212);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 20;
            this.btStop.Text = "停止";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // ckBoxRecord
            // 
            this.ckBoxRecord.AutoSize = true;
            this.ckBoxRecord.Location = new System.Drawing.Point(256, 53);
            this.ckBoxRecord.Name = "ckBoxRecord";
            this.ckBoxRecord.Size = new System.Drawing.Size(99, 21);
            this.ckBoxRecord.TabIndex = 19;
            this.ckBoxRecord.Text = "保存导出记录";
            this.ckBoxRecord.UseVisualStyleBackColor = true;
            // 
            // lbPrintStatus
            // 
            this.lbPrintStatus.AutoSize = true;
            this.lbPrintStatus.BackColor = System.Drawing.Color.White;
            this.lbPrintStatus.Location = new System.Drawing.Point(92, 177);
            this.lbPrintStatus.Name = "lbPrintStatus";
            this.lbPrintStatus.Size = new System.Drawing.Size(32, 17);
            this.lbPrintStatus.TabIndex = 16;
            this.lbPrintStatus.Text = "状态";
            // 
            // lbCodeType
            // 
            this.lbCodeType.AutoSize = true;
            this.lbCodeType.BackColor = System.Drawing.Color.White;
            this.lbCodeType.Location = new System.Drawing.Point(327, 19);
            this.lbCodeType.Name = "lbCodeType";
            this.lbCodeType.Size = new System.Drawing.Size(62, 17);
            this.lbCodeType.TabIndex = 15;
            this.lbCodeType.Text = "codetype";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(253, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "编码类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "结束编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "起始编号：";
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(93, 90);
            this.txtEnd.MaxLength = 5;
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(100, 23);
            this.txtEnd.TabIndex = 11;
            this.txtEnd.TextChanged += new System.EventHandler(this.txtEnd_TextChanged);
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(93, 48);
            this.txtStart.MaxLength = 5;
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(100, 23);
            this.txtStart.TabIndex = 10;
            this.txtStart.TextChanged += new System.EventHandler(this.txtStart_TextChanged);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(405, 212);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOutPut
            // 
            this.btOutPut.Location = new System.Drawing.Point(95, 212);
            this.btOutPut.Name = "btOutPut";
            this.btOutPut.Size = new System.Drawing.Size(75, 23);
            this.btOutPut.TabIndex = 7;
            this.btOutPut.Text = "导出文件";
            this.btOutPut.UseVisualStyleBackColor = true;
            this.btOutPut.Click += new System.EventHandler(this.btPrintCOde_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(16, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "产品型号：";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(93, 136);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(419, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 5;
            // 
            // lbSN
            // 
            this.lbSN.AutoSize = true;
            this.lbSN.BackColor = System.Drawing.Color.White;
            this.lbSN.Location = new System.Drawing.Point(90, 19);
            this.lbSN.Name = "lbSN";
            this.lbSN.Size = new System.Drawing.Size(28, 17);
            this.lbSN.TabIndex = 4;
            this.lbSN.Text = "SN:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "产品型号：";
            // 
            // headerPanel1
            // 
            this.headerPanel1.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel1.BorderStyle = KIS.Controls.BorderStyles.None;
            this.headerPanel1.CaptionBeginColor = System.Drawing.SystemColors.InactiveCaption;
            this.headerPanel1.CaptionEndColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel1.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel1.CaptionHeight = 22;
            this.headerPanel1.CaptionPosition = KIS.Controls.CaptionPositions.Top;
            this.headerPanel1.CaptionText = "导出目录信息";
            this.headerPanel1.CaptionVisible = true;
            this.headerPanel1.Controls.Add(this.btSelectFile);
            this.headerPanel1.Controls.Add(this.txtPath);
            this.headerPanel1.Controls.Add(this.label4);
            this.headerPanel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.headerPanel1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel1.GradientEnd = System.Drawing.SystemColors.Window;
            this.headerPanel1.GradientStart = System.Drawing.SystemColors.Window;
            this.headerPanel1.Location = new System.Drawing.Point(7, 12);
            this.headerPanel1.Name = "headerPanel1";
            this.headerPanel1.PanelIcon = null;
            this.headerPanel1.PanelIconVisible = false;
            this.headerPanel1.Size = new System.Drawing.Size(560, 118);
            this.headerPanel1.TabIndex = 4;
            this.headerPanel1.TextAntialias = true;
            // 
            // btSelectFile
            // 
            this.btSelectFile.Location = new System.Drawing.Point(460, 37);
            this.btSelectFile.Name = "btSelectFile";
            this.btSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btSelectFile.TabIndex = 22;
            this.btSelectFile.Text = "选取文件";
            this.btSelectFile.UseVisualStyleBackColor = true;
            this.btSelectFile.Click += new System.EventHandler(this.btSelectFile_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(96, 37);
            this.txtPath.MaxLength = 5;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(346, 23);
            this.txtPath.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(26, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "文件目录：";
            // 
            // OutFileDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(573, 420);
            this.Controls.Add(this.headerPanel2);
            this.Controls.Add(this.headerPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutFileDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "屏幕二维码导出";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeliveryDlg_FormClosing);
            this.Load += new System.EventHandler(this.DeliveryDlg_Load);
            this.headerPanel2.ResumeLayout(false);
            this.headerPanel2.PerformLayout();
            this.headerPanel1.ResumeLayout(false);
            this.headerPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KIS.Controls.Windows.HeaderPanel headerPanel1;
        private KIS.Controls.Windows.HeaderPanel headerPanel2;
        private System.Windows.Forms.Label lbSN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOutPut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbCodeType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbPrintStatus;
        private System.Windows.Forms.CheckBox ckBoxRecord;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btSelectFile;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}