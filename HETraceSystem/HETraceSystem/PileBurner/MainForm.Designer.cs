namespace PileBurner
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.headerPanel2 = new KIS.Controls.Windows.HeaderPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ledBulb1 = new PileBurner.Contorl.LedBulb();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.lbLEDStatus = new System.Windows.Forms.Label();
            this.lbSN = new System.Windows.Forms.Label();
            this.txtburnInfo = new System.Windows.Forms.TextBox();
            this.headerPanel1 = new KIS.Controls.Windows.HeaderPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbScanStatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btCalibration = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbPath = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btSelectDir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btConnect = new System.Windows.Forms.Button();
            this.btPortConfig = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbStopBits = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDataBits = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbParity = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbBaudRate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.headerPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.headerPanel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel2
            // 
            this.headerPanel2.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel2.BorderStyle = KIS.Controls.BorderStyles.Shadow;
            this.headerPanel2.CaptionBeginColor = System.Drawing.SystemColors.InactiveCaption;
            this.headerPanel2.CaptionEndColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerPanel2.CaptionGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel2.CaptionHeight = 22;
            this.headerPanel2.CaptionPosition = KIS.Controls.CaptionPositions.Top;
            this.headerPanel2.CaptionText = "烧录状态";
            this.headerPanel2.CaptionVisible = true;
            this.headerPanel2.Controls.Add(this.groupBox4);
            this.headerPanel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.headerPanel2.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel2.GradientEnd = System.Drawing.SystemColors.Window;
            this.headerPanel2.GradientStart = System.Drawing.SystemColors.Window;
            this.headerPanel2.Location = new System.Drawing.Point(505, 12);
            this.headerPanel2.Name = "headerPanel2";
            this.headerPanel2.PanelIcon = null;
            this.headerPanel2.PanelIconVisible = false;
            this.headerPanel2.Size = new System.Drawing.Size(312, 418);
            this.headerPanel2.TabIndex = 16;
            this.headerPanel2.TextAntialias = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox4.Controls.Add(this.progressBar1);
            this.groupBox4.Controls.Add(this.ledBulb1);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.lbLEDStatus);
            this.groupBox4.Controls.Add(this.lbSN);
            this.groupBox4.Controls.Add(this.txtburnInfo);
            this.groupBox4.Location = new System.Drawing.Point(23, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(263, 373);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "写入信息:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(21, 348);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(228, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 15;
            // 
            // ledBulb1
            // 
            this.ledBulb1.BackColor = System.Drawing.SystemColors.Window;
            this.ledBulb1.Info = null;
            this.ledBulb1.Location = new System.Drawing.Point(21, 206);
            this.ledBulb1.Name = "ledBulb1";
            this.ledBulb1.Size = new System.Drawing.Size(25, 23);
            this.ledBulb1.Status = PileBurner.Contorl.ClientStatus.None;
            this.ledBulb1.TabIndex = 14;
            this.ledBulb1.Text = "ledBulb1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Window;
            this.label12.Location = new System.Drawing.Point(18, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 17);
            this.label12.TabIndex = 5;
            this.label12.Text = "电桩编号：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Window;
            this.label13.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label13.Location = new System.Drawing.Point(17, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(157, 17);
            this.label13.TabIndex = 8;
            this.label13.Text = "*请扫描条形码获取电桩编号";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(20, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 63);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "模式：";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.SystemColors.Window;
            this.radioButton2.Location = new System.Drawing.Point(110, 22);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(74, 21);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "本地模式";
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.SystemColors.Window;
            this.radioButton1.Location = new System.Drawing.Point(18, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(74, 21);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "共享模式";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // lbLEDStatus
            // 
            this.lbLEDStatus.AutoSize = true;
            this.lbLEDStatus.BackColor = System.Drawing.SystemColors.Window;
            this.lbLEDStatus.Location = new System.Drawing.Point(52, 212);
            this.lbLEDStatus.Name = "lbLEDStatus";
            this.lbLEDStatus.Size = new System.Drawing.Size(43, 17);
            this.lbLEDStatus.TabIndex = 12;
            this.lbLEDStatus.Text = "Status";
            // 
            // lbSN
            // 
            this.lbSN.AutoSize = true;
            this.lbSN.BackColor = System.Drawing.SystemColors.Window;
            this.lbSN.Location = new System.Drawing.Point(90, 37);
            this.lbSN.Name = "lbSN";
            this.lbSN.Size = new System.Drawing.Size(21, 17);
            this.lbSN.TabIndex = 7;
            this.lbSN.Text = "sn";
            // 
            // txtburnInfo
            // 
            this.txtburnInfo.BackColor = System.Drawing.SystemColors.Window;
            this.txtburnInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtburnInfo.Location = new System.Drawing.Point(20, 237);
            this.txtburnInfo.Multiline = true;
            this.txtburnInfo.Name = "txtburnInfo";
            this.txtburnInfo.Size = new System.Drawing.Size(229, 107);
            this.txtburnInfo.TabIndex = 13;
            this.txtburnInfo.Text = "result";
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
            this.headerPanel1.CaptionText = "配置信息";
            this.headerPanel1.CaptionVisible = true;
            this.headerPanel1.Controls.Add(this.groupBox6);
            this.headerPanel1.Controls.Add(this.groupBox5);
            this.headerPanel1.Controls.Add(this.groupBox3);
            this.headerPanel1.Controls.Add(this.groupBox1);
            this.headerPanel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.headerPanel1.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.headerPanel1.GradientEnd = System.Drawing.SystemColors.Window;
            this.headerPanel1.GradientStart = System.Drawing.SystemColors.Window;
            this.headerPanel1.Location = new System.Drawing.Point(23, 12);
            this.headerPanel1.Name = "headerPanel1";
            this.headerPanel1.PanelIcon = null;
            this.headerPanel1.PanelIconVisible = false;
            this.headerPanel1.Size = new System.Drawing.Size(459, 418);
            this.headerPanel1.TabIndex = 15;
            this.headerPanel1.TextAntialias = true;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox5.Controls.Add(this.lbScanStatus);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.btCalibration);
            this.groupBox5.Location = new System.Drawing.Point(267, 129);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(162, 191);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "扫描枪标定:";
            // 
            // lbScanStatus
            // 
            this.lbScanStatus.AutoSize = true;
            this.lbScanStatus.BackColor = System.Drawing.SystemColors.Window;
            this.lbScanStatus.Location = new System.Drawing.Point(47, 33);
            this.lbScanStatus.Name = "lbScanStatus";
            this.lbScanStatus.Size = new System.Drawing.Size(68, 17);
            this.lbScanStatus.TabIndex = 7;
            this.lbScanStatus.Text = "scanstatus";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Window;
            this.label8.Location = new System.Drawing.Point(6, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "状态：";
            // 
            // btCalibration
            // 
            this.btCalibration.BackColor = System.Drawing.SystemColors.Control;
            this.btCalibration.Location = new System.Drawing.Point(97, 130);
            this.btCalibration.Name = "btCalibration";
            this.btCalibration.Size = new System.Drawing.Size(59, 23);
            this.btCalibration.TabIndex = 6;
            this.btCalibration.Text = "配置";
            this.btCalibration.UseVisualStyleBackColor = false;
            this.btCalibration.Click += new System.EventHandler(this.btCalibration_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox3.Controls.Add(this.lbPath);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btSelectDir);
            this.groupBox3.Location = new System.Drawing.Point(15, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(414, 107);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "导出目录配置:";
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.BackColor = System.Drawing.SystemColors.Window;
            this.lbPath.Location = new System.Drawing.Point(57, 52);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(34, 17);
            this.lbPath.TabIndex = 7;
            this.lbPath.Text = "path";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(7, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "目录：";
            // 
            // btSelectDir
            // 
            this.btSelectDir.BackColor = System.Drawing.SystemColors.Control;
            this.btSelectDir.Location = new System.Drawing.Point(312, 47);
            this.btSelectDir.Name = "btSelectDir";
            this.btSelectDir.Size = new System.Drawing.Size(65, 23);
            this.btSelectDir.TabIndex = 6;
            this.btSelectDir.Text = "选择目录";
            this.btSelectDir.UseVisualStyleBackColor = false;
            this.btSelectDir.Click += new System.EventHandler(this.btSelectDir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.btConnect);
            this.groupBox1.Controls.Add(this.btPortConfig);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbStopBits);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbDataBits);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbParity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbBaudRate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbPort);
            this.groupBox1.Location = new System.Drawing.Point(15, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 193);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口配置:";
            // 
            // btConnect
            // 
            this.btConnect.BackColor = System.Drawing.SystemColors.Control;
            this.btConnect.Location = new System.Drawing.Point(175, 161);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(65, 23);
            this.btConnect.TabIndex = 14;
            this.btConnect.Text = "连接";
            this.btConnect.UseVisualStyleBackColor = false;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // btPortConfig
            // 
            this.btPortConfig.BackColor = System.Drawing.SystemColors.Control;
            this.btPortConfig.Location = new System.Drawing.Point(175, 132);
            this.btPortConfig.Name = "btPortConfig";
            this.btPortConfig.Size = new System.Drawing.Size(65, 23);
            this.btPortConfig.TabIndex = 13;
            this.btPortConfig.Text = "配置";
            this.btPortConfig.UseVisualStyleBackColor = false;
            this.btPortConfig.Click += new System.EventHandler(this.btPortConfig_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(22, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率：";
            // 
            // lbStopBits
            // 
            this.lbStopBits.AutoSize = true;
            this.lbStopBits.BackColor = System.Drawing.SystemColors.Window;
            this.lbStopBits.Location = new System.Drawing.Point(84, 145);
            this.lbStopBits.Name = "lbStopBits";
            this.lbStopBits.Size = new System.Drawing.Size(56, 17);
            this.lbStopBits.TabIndex = 12;
            this.lbStopBits.Text = "StopBits";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(22, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口号：";
            // 
            // lbDataBits
            // 
            this.lbDataBits.AutoSize = true;
            this.lbDataBits.BackColor = System.Drawing.SystemColors.Window;
            this.lbDataBits.Location = new System.Drawing.Point(84, 115);
            this.lbDataBits.Name = "lbDataBits";
            this.lbDataBits.Size = new System.Drawing.Size(56, 17);
            this.lbDataBits.TabIndex = 11;
            this.lbDataBits.Text = "DataBits";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(22, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "校验位：";
            // 
            // lbParity
            // 
            this.lbParity.AutoSize = true;
            this.lbParity.BackColor = System.Drawing.SystemColors.Window;
            this.lbParity.Location = new System.Drawing.Point(84, 84);
            this.lbParity.Name = "lbParity";
            this.lbParity.Size = new System.Drawing.Size(40, 17);
            this.lbParity.TabIndex = 10;
            this.lbParity.Text = "Parity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(22, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "数据位：";
            // 
            // lbBaudRate
            // 
            this.lbBaudRate.AutoSize = true;
            this.lbBaudRate.BackColor = System.Drawing.SystemColors.Window;
            this.lbBaudRate.Location = new System.Drawing.Point(84, 55);
            this.lbBaudRate.Name = "lbBaudRate";
            this.lbBaudRate.Size = new System.Drawing.Size(64, 17);
            this.lbBaudRate.TabIndex = 9;
            this.lbBaudRate.Text = "BaudRate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(22, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "停止位：";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.BackColor = System.Drawing.SystemColors.Window;
            this.lbPort.Location = new System.Drawing.Point(88, 28);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(34, 17);
            this.lbPort.TabIndex = 8;
            this.lbPort.Text = "path";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioButton4);
            this.groupBox6.Controls.Add(this.radioButton3);
            this.groupBox6.Location = new System.Drawing.Point(15, 327);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(414, 57);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "电桩类型：";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = System.Drawing.SystemColors.Window;
            this.radioButton3.Location = new System.Drawing.Point(37, 22);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(62, 21);
            this.radioButton3.TabIndex = 11;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "壁挂式";
            this.radioButton3.UseVisualStyleBackColor = false;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.BackColor = System.Drawing.SystemColors.Window;
            this.radioButton4.Location = new System.Drawing.Point(132, 22);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(62, 21);
            this.radioButton4.TabIndex = 12;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "广告桩";
            this.radioButton4.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(834, 442);
            this.Controls.Add(this.headerPanel2);
            this.Controls.Add(this.headerPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电桩配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.headerPanel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.headerPanel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.Button btSelectDir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbStopBits;
        private System.Windows.Forms.Label lbDataBits;
        private System.Windows.Forms.Label lbParity;
        private System.Windows.Forms.Label lbBaudRate;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Button btPortConfig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbSN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label lbLEDStatus;
        private System.Windows.Forms.TextBox txtburnInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private Contorl.LedBulb ledBulb1;
        private KIS.Controls.Windows.HeaderPanel headerPanel1;
        private KIS.Controls.Windows.HeaderPanel headerPanel2;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lbScanStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btCalibration;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}

