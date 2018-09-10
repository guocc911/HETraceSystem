using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using MDL;


namespace HETraceSystem.Config
{
    public partial class ProductTypeCfgDlg : Form
    {

       // private List<ProductTypeMDL> types;

        private DataTable types;
       
        public ProductTypeCfgDlg()
        {
            InitializeComponent();
        }

        private void btAddDevice_Click(object sender, EventArgs e)
        {
            AddProductTypeDlg dlg = new AddProductTypeDlg();

            if (dlg.ShowDialog() == DialogResult.Yes)
            {
                ProductTypeDAL dal = new ProductTypeDAL();

                if (dal.InsertProType(dlg.ProductType) > 0)
                {
                    MessageBox.Show("登记产品类型成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.ReloadDataGrid();
                }
                else
                {
                    MessageBox.Show("登记产品类型失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /// <summary>
        /// 加载列表
        /// </summary>
        public void ReloadDataGrid()
        {
            try
            {
                InitialDataGridViewHeader();
                IntialDaraGrid();
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// 初始化表单
        /// </summary>
        private void InitialDataGridViewHeader()
        {

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns.Clear();


            int clounmWidth = this.dataGridView1.Width/4-1;

            DataGridViewColumn codeColumn = new DataGridViewTextBoxColumn();
            codeColumn.HeaderText = "类型编码";
            codeColumn.Name = "TYPE_CODE";
            codeColumn.Width = clounmWidth;
            dataGridView1.Columns.Add(codeColumn);

            DataGridViewColumn typeColumn = new DataGridViewTextBoxColumn();
            typeColumn.HeaderText = "类型名称";
            typeColumn.Name = "TYPE_NAME";
            typeColumn.Width = clounmWidth;
            dataGridView1.Columns.Add(typeColumn);

            DataGridViewColumn regDateColumn = new DataGridViewTextBoxColumn();
            regDateColumn.HeaderText = "注册时间";
            regDateColumn.Name = "REG_DATE";
            regDateColumn.Width = clounmWidth;
            dataGridView1.Columns.Add(regDateColumn);


            DataGridViewColumn delColumn = new DataGridViewButtonColumn();
            delColumn.HeaderText = "删 除";
            delColumn.Name = "DisNumber";
            delColumn.Width = clounmWidth;
            dataGridView1.Columns.Add(delColumn);

            this.dataGridView1.Rows.Clear();

        }

        /// <summary>
        /// 
        /// </summary>
        private void IntialDaraGrid()
        {
            try
            {
                this.dataGridView1.Rows.Clear();

                ProductTypeDAL mdl=new ProductTypeDAL();

                types = mdl.GetProTypes();
       

                if (types != null && types.Rows.Count > 0)
                {
                    for (int i = 0; i < types.Rows.Count; i++)
                    {

                        DataRow row = types.Rows[i];

                        this.dataGridView1.Rows.Add(Convert.ToString(row["TYPE_CODE"]),
                                                    Convert.ToString(row["TYPE_NAME"]),
                                                    Convert.ToString(row["REG_DATE"]), "删 除");
                    }
                }
           
            }
            catch
            {
                throw;
            }
        }
        


        private void ProductTypeCfgDlg_Load(object sender, EventArgs e)
        {
            try
            {
                ReloadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            this.dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView1_CellContentClick);

            try
            {



                DataRow rd = null;

                switch (e.ColumnIndex)
                {
                    case 3:


                        //ProductDAL productDAL = new ProductDAL();

                        rd = this.types.Rows[e.RowIndex];

                        string code = Convert.ToString(rd["TYPE_CODE"]);

                        //if (productDAL.IsUsedProductType(code) > 0)
                        //{
                        //    MessageBox.Show("该产品类型已经使用", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk

                        //}

                        if (MessageBox.Show("确定要删除该配置信息吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                        {
                            //rd = this.types.Rows[e.RowIndex];
                            //int id = Convert.ToInt32(rd["TYPE_CODE"]);

                            ProductTypeMDL mdl = new ProductTypeMDL();
                            mdl.TypeCode = code;

                            ProductTypeDAL typeDal = new ProductTypeDAL();

                            if (typeDal.DeleteProType(mdl) > 0)
                            {
                                MessageBox.Show("删除数据成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                MessageBox.Show("删除数据失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }


                            this.ReloadDataGrid();
                        }

                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
        }


    }
}
