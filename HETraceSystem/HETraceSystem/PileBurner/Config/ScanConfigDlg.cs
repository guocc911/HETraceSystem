using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COMM;

namespace PileBurner.Config
{
    public partial class SacnConfigDlg : Form
    {

        private DeviceInfo info = null;


        /// <summary>
        /// 设备信息
        /// </summary>
        public DeviceInfo DeviceInfo
        {
            get { return info; }
            set { info = value; }
 
        }


        public SacnConfigDlg()
        {
            InitializeComponent();
        }


        private void LoadView()
        {
            this.txtScanName.Text = info.Name;
            this.txtDeviceID.Text = info.DeviceID;
        }


        private void btApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtScanName.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写扫描枪名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.txtDeviceID.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请输入扫描枪ID", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }




                if (info == null)
                    info = new DeviceInfo();
                info.Index = 1;
                info.DeviceID = this.txtDeviceID.Text.Trim();
                info.Name = this.txtScanName.Text.Trim();
                info.Status = 0;

                this.DialogResult = DialogResult.Yes;

            }
            catch (Exception ex)
            {
 
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void PrintConfigDlg_Load(object sender, EventArgs e)
        {

            if (info == null)
                this.txtScanName.Text = "Honeywell";
            else
                LoadView();

        }

        private void btCalibration_Click(object sender, EventArgs e)
        {
            CalibrationDlg dlg = new CalibrationDlg();

            if (dlg.ShowDialog()== DialogResult.Yes)
            {
                this.txtDeviceID.Text = dlg.DeviceID;
                MessageBox.Show("保存设备ID成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            
        }
    }
}
