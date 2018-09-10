using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HETraceSystem.Config
{
    public partial class AsmConfigDlg : Form
    {


        private string company;


        private string pline;


        private string contact;


        public string Company
        {
            get { return company; }

            set { company = value; }
        }


        public string Pline
        {
            get { return pline; }

            set { pline = value; }
        }


        public string Contact
        {
            get { return contact; }

            set { contact = value; }
        }


        public AsmConfigDlg()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (this.txtCompany.Text.Trim().Length < 1)
            {
                MessageBox.Show("请填写公司信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.txtPLine.Text.Trim().Length < 1)
            {
                MessageBox.Show("请填数产线信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //if (this.txtContact.Text.Trim().Length < 1)
            //{
            //    MessageBox.Show("请填写用户名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}

            company = this.txtCompany.Text.Trim();
            pline = this.txtPLine.Text.Trim();
            contact = this.txtContact.Text.Trim();

            DialogResult = DialogResult.Yes;
            this.Close();


        }

        private void btCancel_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void AsmConfigDlg_Load(object sender, EventArgs e)
        {
            this.txtCompany.Text = company;
            this.txtPLine.Text = pline;
            this.txtContact.Text = contact;
     
        }
    }
}
