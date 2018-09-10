using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MDL;
using DAL;

namespace HETraceSystem.Config
{
    public partial class AddProductTypeDlg : Form
    {


        private ProductTypeMDL mdl = null;


        public ProductTypeMDL ProductType
        {

            get { return mdl; }

            set { mdl = value; }
        }


        public AddProductTypeDlg()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddProductTypeDlg_Load(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// 
        /// </summary>
        private void InitalDialog()
        {
 
            
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtTypeCode.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填写类型编码！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (this.txtTypeName.Text.Trim().Length < 1)
                {
                    MessageBox.Show("请填类型名称！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }


                this.mdl = new ProductTypeMDL();
                this.mdl.TypeCode = this.txtTypeCode.Text.Trim();

                ProductTypeDAL dal = new ProductTypeDAL();

                if (dal.CheckCode(this.mdl.TypeCode)>0)
                {
                    MessageBox.Show("当前输入的编号已经存在请重试！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.txtTypeCode.Text = string.Empty;
                    this.mdl = null;
                    return;
                }
               
                this.mdl.TypeName = this.txtTypeName.Text.Trim();
                this.mdl.RegDate = DateTime.Now;
                this.DialogResult = DialogResult.Yes;

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


      

        private void txtTypeCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                if (!char.IsLetter(e.KeyChar))
                {
                    MessageBox.Show("只能输入数字或英文字母", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Handled = true;
                }
        }
    }
}
