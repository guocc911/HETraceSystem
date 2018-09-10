using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Windows.Threading;
using System.Windows.Interop;
using System.Windows.Input;
//using System
using RawInput_dll;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace PileBurner.Config
{
    public partial class CalibrationDlg : Form
    {





        private string device_id;

        private delegate void DelegateShowInfo(string info);


        /// <summary>
        /// 设备ID
        /// </summary>
        public string DeviceID
        {
            get { return device_id; }
            set { device_id = value; }
 
        }


        public CalibrationDlg()
        {
            InitializeComponent();
        }

        private void CalibrationDlg_Load(object sender, EventArgs e)
        {
        }


      


        private void DoShowDeviceInfo(string strValue)
       {
           if (this.InvokeRequired)
           {

               this.Invoke(new DelegateShowInfo(DoShowDeviceInfo), new object[] { strValue });
           }
           else
           {
               this.txtInput.Text = strValue;
           }
       }







        //public static string Chr(int asciiCode)
        //{
        //    if (asciiCode >= 0 && asciiCode <= 255)
        //    {
        //        System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
        //      //  System.Text.UnicodeEncoding asciiEncoding = new System.Text.UnicodeEncoding();
        //        byte[] byteArray = new byte[] { (byte)asciiCode };
        //        string strCharacter = asciiEncoding.GetString(byteArray);
        //        return (strCharacter);
        //    }
        //    else
        //    {
        //        throw new Exception("ASCII Code is not valid.");
        //    }
        //}

        private void btCalibration_Click(object sender, EventArgs e)
        {

            if (this.btCalibration.Text == "开始标定")
            {

                //_eventQ.Clear();
                //_isMonitoring = true;
                MainForm.deviceid = string.Empty;
                this.txtDeviceID.ReadOnly=true;
                this.txtInput.Focus();
                this.btCalibration.Text = "结束标定";

            }
            else
            {
                string str_Out = string.Empty;

                if(MainForm.deviceid!=String.Empty)
                    DoShowDeviceInfo(MainForm.deviceid);

                this.device_id = MainForm.deviceid;
                if (device_id == null || device_id == string.Empty)
                {
                    MessageBox.Show("未获取到设备信息,请重试！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    this.DialogResult = DialogResult.No;
                }
                else
                {
                    this.txtDeviceID.Text = device_id;
                   // this.device_id=MainForm.deviceid;
                    this.btCalibration.Text = "开始标定";

                    this.DialogResult = DialogResult.Yes;

                }
            }
  
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
