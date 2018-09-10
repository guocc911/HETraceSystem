using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDL;

namespace HETraceSystem.Config
{
    public partial class DeliveryCfgDlg : Form
    {

        private DeliveryItemMDL mdl = null;


        public DeliveryItemMDL TempDeliveryInfo
        {

            get { return mdl; }
            set { mdl = value; }
            
        }


        public DeliveryCfgDlg()
        {
            InitializeComponent();
        }

        private void DeliveryCfgDlg_Load(object sender, EventArgs e)
        {
            InitalDeliveryCfg();

        }

        private void InitalDeliveryCfg()
        {
            try
            {

                if (mdl == null)
                    return;

                this.txtCompany.Text = mdl.USERNAME;
                this.txtContact.Text = mdl.CONTACT;
                this.txtAgent.Text = mdl.FORWARDERDID;
                this.txtDirection.Text = mdl.DIRECTION;
                this.txtLN.Text = mdl.LN;
            }
            catch
            {
                throw;
            }
 
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (this.txtCompany.Text.Trim().Length < 1)
            {
                MessageBox.Show("请填写公司信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.txtContact.Text.Trim().Length < 1)
            {
                MessageBox.Show("请填写联系方式！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.txtAgent.Text.Trim().Length < 1)
            {
                MessageBox.Show("请填写货代！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.txtDirection.Text.Trim().Length < 1)
            {
                MessageBox.Show("请填写方向！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.txtLN.Text.Trim().Length < 1)
            {
                MessageBox.Show("请填写物流编号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            if (this.txtAddress.Text.Trim().Length < 1)
            {
                MessageBox.Show("请填写收货地址！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            if (mdl == null)
                mdl = new DeliveryItemMDL();

            mdl.USERNAME = this.txtCompany.Text;
            mdl.CONTACT = this.txtContact.Text;
            mdl.FORWARDERDID = this.txtAgent.Text;
            mdl.DIRECTION =  this.txtDirection.Text;
            mdl.LN = this.txtLN.Text;
            mdl.ADDRESS = this.txtAddress.Text.Trim();


            this.DialogResult = DialogResult.Yes;

            this.Close();

        }



        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
