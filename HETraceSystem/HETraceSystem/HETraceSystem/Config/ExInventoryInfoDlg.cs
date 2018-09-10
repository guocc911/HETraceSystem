using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HETraceSystem.Config;
using System.Text.RegularExpressions;
using DAL;
using MDL;

namespace HETraceSystem
{
    public partial class ExInventoryInfoDlg : Form
    {



        private ExInventoryItemMDL inMDL = null;


        private bool isUpdate = false;


        /// <summary>
        /// 产品信息
        /// </summary>
        public ExInventoryItemMDL InventoryItem
        {
            get { return inMDL; }
            set { inMDL = value; }
        }

        public bool Modidfy
        {
            get { return isUpdate; }
            set { isUpdate = value; }
        }


        public ExInventoryInfoDlg()
        {
            InitializeComponent();
        }

        private void InventoryInfoDlg_Load(object sender, EventArgs e)
        {
            LoadInventoryInfo();

        }



        private void LoadInventoryInfo()
        {
            try
            {

                if (inMDL!=null)
                this.lbName.Text = this.inMDL.Name;
                this.LbSN.Text = this.inMDL.SN;
                this.txtPN.Text = this.inMDL.IMEI;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    
        }

        private void InventoryInfoDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtPN.Text == null || this.txtPN.Text.Length < 1)
            {
                MessageBox.Show("请填写IMEI号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

        

            if(this.txtPN.Text.Trim().Length!=8)
            {
                MessageBox.Show("请填写正确的IMEI号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

        
            int checkCode = 0;
            Int32.TryParse(this.txtPN.Text.Trim(),out checkCode);

            if(checkCode<=0)
            {
                MessageBox.Show("请填写正确的IMEI号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            this.inMDL.IMEI = this.txtPN.Text.Trim();
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
