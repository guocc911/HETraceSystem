using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using COMM;

namespace PileBurner
{
    public partial class PortConfigDlg : Form
    {
        private SerialPortPar par = null;

        /// <summary>
        /// 
        /// </summary>
        public SerialPortPar SerialPortPar
        {
            get { return par; }
            set { par = value; }
        }


        public PortConfigDlg()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            if (this.cboPorts.Text.Trim().Length < 1)
            {
                MessageBox.Show("请选择端口号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.cboBaudRate.Text.Trim().Length < 1)
            {
                MessageBox.Show("请选择波特率！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.cboBaudRate.Text.Trim().Length < 1)
            {
                MessageBox.Show("请选择波特率！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.cboBaudRate.Text.Trim().Length < 1)
            {
                MessageBox.Show("请选择波特率！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.cboParity.Text.Trim().Length < 1)
            {
                MessageBox.Show("请选择效验位！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.cboDataBits.Text.Trim().Length < 1)
            {
                MessageBox.Show("请选数据位！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.cboStopBits.Text.Trim().Length < 1)
            {
                MessageBox.Show("请选停止位！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            this.par = new SerialPortPar();
            this.par.PortName = this.cboPorts.Text.Trim();
            this.par.BaudRate = Convert.ToInt32(this.cboBaudRate.Text.Trim());
            this.par.Parity = (Parity)this.cboParity.SelectedIndex;
            this.par.DataBits = Convert.ToInt32(this.cboDataBits.Text.Trim());
          //  this.par.StopBits = (StopBits)this.cboStopBits.Text;

           

            this.DialogResult = DialogResult.OK;
            this.Close();


        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private void InitalView()
        {
            string[] ArrayComPortsNames = null;
            int index = -1;
            string ComPortName = null;

            //Com Ports
            ArrayComPortsNames = SerialPort.GetPortNames();

            if (ArrayComPortsNames != null && ArrayComPortsNames.Length > 0)
            {
                do
                {
                    index += 1;
                    cboPorts.Items.Add(ArrayComPortsNames[index]);


                } while (!((ArrayComPortsNames[index] == ComPortName) || (index == ArrayComPortsNames.GetUpperBound(0))));
                Array.Sort(ArrayComPortsNames);

                if (index == ArrayComPortsNames.GetUpperBound(0))
                {
                    ComPortName = ArrayComPortsNames[0];
                }
                //get first item print in text
                cboPorts.Text = ArrayComPortsNames[0];
            }

            if (par != null)
                this.cboPorts.Text = this.par.PortName;

            

            //Baud Rate
            cboBaudRate.Items.Add(300);
            cboBaudRate.Items.Add(600);
            cboBaudRate.Items.Add(1200);
            cboBaudRate.Items.Add(2400);
            cboBaudRate.Items.Add(9600);
            cboBaudRate.Items.Add(14400);
            cboBaudRate.Items.Add(19200);
            cboBaudRate.Items.Add(38400);
            cboBaudRate.Items.Add(57600);
            cboBaudRate.Items.Add(115200);
            cboBaudRate.Items.ToString();
            //get first item print in text
            cboBaudRate.Text = cboBaudRate.Items[0].ToString();

            if (par != null)
                this.cboBaudRate.Text = this.par.BaudRate.ToString();

            //Data Bits
            cboDataBits.Items.Add(7);
            cboDataBits.Items.Add(8);
            //get the first item print it in the text 
            cboDataBits.Text = cboDataBits.Items[0].ToString();

            if (par != null)
                this.cboDataBits.Text = this.par.DataBits.ToString();

            //Stop Bits
            cboStopBits.Items.Add("One");
            cboStopBits.Items.Add("OnePointFive");
            cboStopBits.Items.Add("Two");
            //get the first item print in the text
            cboStopBits.Text = cboStopBits.Items[0].ToString();

            if (par != null)
                this.cboStopBits.Text = this.par.StopBits.ToString();

            //Parity 
            cboParity.Items.Add("None");
            cboParity.Items.Add("Even");
            cboParity.Items.Add("Mark");
            cboParity.Items.Add("Odd");
            cboParity.Items.Add("Space");
            //get the first item print in the text
            cboParity.Text = cboParity.Items[0].ToString();
            if (par != null)
                this.cboParity.Text = this.par.Parity.ToString();
            //Handshake
            //cboHandShaking.Items.Add("None");
            //cboHandShaking.Items.Add("XOnXOff");
            //cboHandShaking.Items.Add("RequestToSend");
            //cboHandShaking.Items.Add("RequestToSendXOnXOff");
        }

        private void PortConfigDlg_Load(object sender, EventArgs e)
        {
            InitalView();
        }

  
    }
}
