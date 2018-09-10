using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COMM;

namespace HETraceSystem.Config
{
    public partial class PrintConfigDlg : Form
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


        public PrintConfigDlg()
        {
            InitializeComponent();
        }



        private void btApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtPrint.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写打印机信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (info == null)
                    info = new DeviceInfo();

                info.Index = 0;
                info.DeviceID = "POSTEK";
                info.Name =this.txtPrint.Text.Trim();
                info.Type = 1;///打印机

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

            if (info != null)
                this.txtPrint.Text = info.Name;

        }
    }
}
