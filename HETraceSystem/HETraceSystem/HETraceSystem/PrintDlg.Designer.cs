namespace HETraceSystem
{
    partial class DeliveryDlg
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

            try
            {
                if (printThread != null)
                {
                    printThread.Suspend();

                    printThread.Abort();
                }
            }
            catch
            {
 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryDlg));
            this.headerPanel2 = new KIS.Controls.Windows.HeaderPanel();
            this.btStop = new System.Windows.Forms.Button();
            this.ckBoxRecord = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.lbPrintStatus = new System.Windows.Forms.Label();
            this.lbCodeType = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btPrintCOde = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbSN = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.headerPanel1 = new KIS.Controls.Windows.HeaderPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbPrintType = new System.Windows.Forms.Label();
            this.lbPrintInfo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbError = new System.Windows.Forms.Label();
            this.lbScanStaus = new System.Windows.Forms.Label();
            this.btScanlink = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOffsetY = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
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
            this.headerPanel2.Controls.Add(this.label7);
            this.headerPanel2.Controls.Add(this.txtCount);
            this.headerPanel2.Controls.Add(this.lbPrintStatus);
            this.headerPanel2.Controls.Add(this.lbCodeType);
            this.headerPanel2.Controls.Add(this.label6);
            this.headerPanel2.Controls.Add(this.label3);
            this.headerPanel2.Controls.Add(this.label2);
            this.headerPanel2.Controls.Add(this.txtEnd);
            this.headerPanel2.Controls.Add(this.txtStart);
            this.headerPanel2.Controls.Add(this.btCancel);
            this.headerPanel2.Controls.Add(this.btPrintCOde);
            this.headerPanel2.Controls.Add(this.label5);
            this.headerPanel2.Controls.Add(this.progressBar1);
            this.headerPanel2.Controls.Add(this.lbSN);
            this.headerPanel2.Controls.Add(this.label1);
            this.headerPanel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.headerPanel2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel2.GradientEnd = System.Drawing.SystemColors.Window;
            this.headerPanel2.GradientStart = System.Drawing.SystemColors.Window;
            this.headerPanel2.Location = new System.Drawing.Point(7, 224);
            this.headerPanel2.Name = "headerPanel2";
            this.headerPanel2.PanelIcon = null;
            this.headerPanel2.PanelIconVisible = false;
            this.headerPanel2.Size = new System.Drawing.Size(560, 263);
            this.headerPanel2.TabIndex = 5;
            this.headerPanel2.TextAntialias = true;
            this.headerPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.headerPanel2_Paint);
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
            this.ckBoxRecord.Location = new System.Drawing.Point(330, 93);
            this.ckBoxRecord.Name = "ckBoxRecord";
            this.ckBoxRecord.Size = new System.Drawing.Size(99, 21);
            this.ckBoxRecord.TabIndex = 19;
            this.ckBoxRecord.Text = "保存打印记录";
            this.ckBoxRecord.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(253, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "编号份数：";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(329, 49);
            this.txtCount.MaxLength = 1;
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(29, 23);
            this.txtCount.TabIndex = 17;
            this.txtCount.TextChanged += new System.EventHandler(this.txtCount_TextChanged);
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
            // btPrintCOde
            // 
            this.btPrintCOde.Location = new System.Drawing.Point(95, 212);
            this.btPrintCOde.Name = "btPrintCOde";
            this.btPrintCOde.Size = new System.Drawing.Size(75, 23);
            this.btPrintCOde.TabIndex = 7;
            this.btPrintCOde.Text = "打印";
            this.btPrintCOde.UseVisualStyleBackColor = true;
            this.btPrintCOde.Click += new System.EventHandler(this.btPrintCOde_Click);
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
            this.headerPanel1.CaptionText = "打印机信息";
            this.headerPanel1.CaptionVisible = true;
            this.headerPanel1.Controls.Add(this.label10);
            this.headerPanel1.Controls.Add(this.txtOffsetY);
            this.headerPanel1.Controls.Add(this.label11);
            this.headerPanel1.Controls.Add(this.label9);
            this.headerPanel1.Controls.Add(this.txtOffset);
            this.headerPanel1.Controls.Add(this.label8);
            this.headerPanel1.Controls.Add(this.lbPrintType);
            this.headerPanel1.Controls.Add(this.lbPrintInfo);
            this.headerPanel1.Controls.Add(this.label4);
            this.headerPanel1.Controls.Add(this.lbError);
            this.headerPanel1.Controls.Add(this.lbScanStaus);
            this.headerPanel1.Controls.Add(this.btScanlink);
            this.headerPanel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.headerPanel1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel1.GradientEnd = System.Drawing.SystemColors.Window;
            this.headerPanel1.GradientStart = System.Drawing.SystemColors.Window;
            this.headerPanel1.Location = new System.Drawing.Point(7, 12);
            this.headerPanel1.Name = "headerPanel1";
            this.headerPanel1.PanelIcon = null;
            this.headerPanel1.PanelIconVisible = false;
            this.headerPanel1.Size = new System.Drawing.Size(560, 206);
            this.headerPanel1.TabIndex = 4;
            this.headerPanel1.TextAntialias = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(396, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "毫米";
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(347, 79);
            this.txtOffset.MaxLength = 4;
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(43, 23);
            this.txtOffset.TabIndex = 21;
            this.txtOffset.TextChanged += new System.EventHandler(this.txtOffset_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(249, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "横向打印偏移：";
            // 
            // lbPrintType
            // 
            this.lbPrintType.AutoSize = true;
            this.lbPrintType.BackColor = System.Drawing.Color.White;
            this.lbPrintType.Location = new System.Drawing.Point(357, 43);
            this.lbPrintType.Name = "lbPrintType";
            this.lbPrintType.Size = new System.Drawing.Size(62, 17);
            this.lbPrintType.TabIndex = 8;
            this.lbPrintType.Text = "PrintType";
            // 
            // lbPrintInfo
            // 
            this.lbPrintInfo.AutoSize = true;
            this.lbPrintInfo.BackColor = System.Drawing.Color.White;
            this.lbPrintInfo.Location = new System.Drawing.Point(349, 10);
            this.lbPrintInfo.Name = "lbPrintInfo";
            this.lbPrintInfo.Size = new System.Drawing.Size(70, 17);
            this.lbPrintInfo.TabIndex = 7;
            this.lbPrintInfo.Text = "printStauts";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(273, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "打印类型：";
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.BackColor = System.Drawing.Color.White;
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(275, 153);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(68, 17);
            this.lbError.TabIndex = 5;
            this.lbError.Text = "错误信息：";
            this.lbError.Click += new System.EventHandler(this.lbError_Click);
            // 
            // lbScanStaus
            // 
            this.lbScanStaus.AutoSize = true;
            this.lbScanStaus.BackColor = System.Drawing.Color.White;
            this.lbScanStaus.Location = new System.Drawing.Point(263, 10);
            this.lbScanStaus.Name = "lbScanStaus";
            this.lbScanStaus.Size = new System.Drawing.Size(80, 17);
            this.lbScanStaus.TabIndex = 2;
            this.lbScanStaus.Text = "打印机状态：";
            // 
            // btScanlink
            // 
            this.btScanlink.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.btScanlink.Image = ((System.Drawing.Image)(resources.GetObject("btScanlink.Image")));
            this.btScanlink.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btScanlink.Location = new System.Drawing.Point(20, 19);
            this.btScanlink.Name = "btScanlink";
            this.btScanlink.Size = new System.Drawing.Size(185, 60);
            this.btScanlink.TabIndex = 0;
            this.btScanlink.Text = "打印测试页";
            this.btScanlink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btScanlink.UseVisualStyleBackColor = true;
            this.btScanlink.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(396, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 17);
            this.label10.TabIndex = 25;
            this.label10.Text = "毫米";
            // 
            // txtOffsetY
            // 
            this.txtOffsetY.Location = new System.Drawing.Point(347, 116);
            this.txtOffsetY.MaxLength = 4;
            this.txtOffsetY.Name = "txtOffsetY";
            this.txtOffsetY.Size = new System.Drawing.Size(43, 23);
            this.txtOffsetY.TabIndex = 24;
            this.txtOffsetY.TextChanged += new System.EventHandler(this.txtOffsetY_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(249, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "纵向打印偏移：";
            // 
            // DeliveryDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(573, 499);
            this.Controls.Add(this.headerPanel2);
            this.Controls.Add(this.headerPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeliveryDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "追溯标签打印";
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
        private System.Windows.Forms.Label lbScanStaus;
        private System.Windows.Forms.Label lbSN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Button btScanlink;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbPrintType;
        private System.Windows.Forms.Label lbPrintInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btPrintCOde;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbCodeType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbPrintStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.CheckBox ckBoxRecord;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtOffsetY;
        private System.Windows.Forms.Label label11;
    }
}