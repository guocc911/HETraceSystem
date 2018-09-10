using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HETraceSystem.Control;
using HETraceSystem.Config;
using WeifenLuo.WinFormsUI.Docking;
using HETraceSystem.Utils;
using DAL;
using MDL;

namespace HETraceSystem
{
    public partial class MainForm : Form
    {

        #region Fields



        private ProductListDlg _productListDlg = null;



        public static  WorkSpace _workSpace = null;


        #endregion



        public MainForm()
        {
            InitializeComponent();
        }




        private void 货品查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 数据库配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintConfig dlg = new PrintConfig();

            dlg.DBinfo = _workSpace.DBInfo;

            if (dlg.ShowDialog() == DialogResult.Yes)
            {
        
                SavaDBConfig(dlg.DBinfo);

                MessageBox.Show("保存配置成功！");
            }
        }

        #region Intial Windows 

        private void LoadConfig()
        {
            try
            {
                _workSpace = new WorkSpace(SystemUtils.ApplicationPath);
                _workSpace.Load();

                bool openDB = COMM.MySqlDBHelper.ModifyConnectionInfo(_workSpace.DBInfo.Server,
                                                                       _workSpace.DBInfo.DBName,
                                                                       _workSpace.DBInfo.User,
                                                                       _workSpace.DBInfo.PWD);
                OpenPLDlg();

                if (openDB)
                {
                    ShowStatusInfo("状态：连接数据库成功！", Color.Blue);
                }
                else
                {
                   // MessageBox.Show("连接数据库失败，请检查数据库配置！", "追溯系统", MessageBoxButtons.OK);
                    ShowStatusInfo("状态：连接数据库失败！", Color.Red);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

        }




        private void SavaDBConfig(DBInfo info)
        {
            try
            {
                _workSpace = new WorkSpace(SystemUtils.ApplicationPath);
                _workSpace.Load();
                _workSpace.DBInfo=info;
       
                if (_workSpace.Save())
                {
                   COMM.MySqlDBHelper.ModifyConnectionInfo(_workSpace.DBInfo.Server,
                                                           _workSpace.DBInfo.DBName,
                                                           _workSpace.DBInfo.User,
                                                           _workSpace.DBInfo.PWD);

                    ShowStatusInfo("状态：连接数据库成功！", Color.Blue);
                }
                else
                {
                    // MessageBox.Show("连接数据库失败，请检查数据库配置！", "追溯系统", MessageBoxButtons.OK);
                    ShowStatusInfo("状态：连接数据库失败！", Color.Red);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }


        public void ShowStatusInfo(string info,Color color)
        {
            this.toolStripSlbSysteminfo.Text = info.Trim();
            this.toolStripSlbSysteminfo.ForeColor = color;
        }



        public  bool TestConnection()
        {
            bool result = COMM.MySqlDBHelper.ModifyConnectionInfo( _workSpace.DBInfo.DBName,
                                                                   _workSpace.DBInfo.Server,
                                                                   _workSpace.DBInfo.User,
                                                                   _workSpace.DBInfo.PWD);
            return result;
        }

        private void OpenPLDlg()
        {

            if (_productListDlg == null)
            {
                _productListDlg = new ProductListDlg();
            }
            else
                return;

            _productListDlg.Show(this.hE_DockPanel1);
        }




        private void ClostPLDlg()
        {
            CloseWindows("ProductListDlg");
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="name"></param>
        private void CloseWindows(string name)
        {

            if (dockPanel == null)
                return;

            dockPanel.SuspendLayout(true);
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                {
                    if (name == form.Name)
                    {
                        form.Close();
                    }
                }
            }
            else
            {
                for (int index = dockPanel.Contents.Count - 1; index >= 0; index--)
                {
                    if (dockPanel.Contents[index] is IDockContent)
                    {
                        IDockContent content = (IDockContent)dockPanel.Contents[index];
                        if (content.DockHandler.Form.Name == name)
                        {
                            content.DockHandler.Close();
                        }
                    }
                }
            }

            dockPanel.ResumeLayout(true, true);
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
           // byte temp=ASCIIEncoding.Default.GetBytes("P".Substring(0, 1))[0];
            LoadConfig();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClostPLDlg();
            this.Close();
        }

        private void 产品类型配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductTypeCfgDlg dlg = new ProductTypeCfgDlg();

            if (dlg.ShowDialog() == DialogResult.Yes)
            { 
            }
        }

        private void 货品录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductImportDlg importProductDlg = new ProductImportDlg();

            if (importProductDlg.ShowDialog() == DialogResult.Yes)
            {
 
            }
        }

        private void 产品类型登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductTypeCfgDlg dlg = new ProductTypeCfgDlg();

            dlg.ShowDialog();
        }

        private void 产品登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductRegDlg regDlg = new ProductRegDlg();

            regDlg.ShowDialog();
        }

        private void dockPanel_ActiveContentChanged(object sender, EventArgs e)
        {

        }

        private void 打印机配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintConfigDlg dlg = new PrintConfigDlg();

            dlg.DeviceInfo = _workSpace.GetDeviceInfo(0);

            if (dlg.ShowDialog() == DialogResult.Yes)
            {
                _workSpace.SetDeviceInfo(dlg.DeviceInfo);
                _workSpace.Save();
            }
             
        }

        private void 扫描枪配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SacnConfigDlg dlg = new SacnConfigDlg();
            dlg.DeviceInfo = _workSpace.GetDeviceInfo(1);

            if (dlg.ShowDialog() == DialogResult.Yes)
            {
                _workSpace.SetDeviceInfo(dlg.DeviceInfo);
                _workSpace.Save();
            }
        }

        private void 货品入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductImportDlg dlg = new ProductImportDlg();

            dlg.DeviceInfo = _workSpace.GetDeviceInfo(1);
             
            if (dlg.ShowDialog() == DialogResult.Yes)
            {
                //_workSpace.SetDeviceInfo(dlg.DeviceInfo);
                //_workSpace.Save();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确实要关闭该窗口吗！", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {

                _workSpace.Save();
                e.Cancel = false;

  

            }
            else
            {
                e.Cancel = true;
            }
        }

        private void 货品出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 车机产品登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CTProductRegDlg dlg = new CTProductRegDlg();
            dlg.ShowDialog();
           

        }

        private void 充电桩出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeliveryInfoDlg dlg = new DeliveryInfoDlg();
            dlg.ScanInfo = _workSpace.GetDeviceInfo(1);
            dlg.ShowDialog();

        }

        private void 车机出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExDeliveryInfoDlg dlg = new ExDeliveryInfoDlg();
            dlg.ScanInfo = _workSpace.GetDeviceInfo(1);
            dlg.ShowDialog();
        }


    }
}
