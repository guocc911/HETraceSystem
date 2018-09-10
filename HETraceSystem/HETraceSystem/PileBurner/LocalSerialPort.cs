using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using COMM;


namespace PileBurner
{
    public class LocalSerialPort:SerialPortEx
    {


        public EventHandler ReceiveResultEvent;


        private System.Threading.Timer processTimer = null;



        public override bool OpenPort(string port, int nBaudRate, Parity parity, int nDataBits,
                                    StopBits nStopBits, Handshake handshake)
        {
            try
            {
                bool open = base.OpenPort(port, nBaudRate, parity, nDataBits, nStopBits, handshake);


                //if (!this.DsrHolding)
                //{
                //    this.Close();
                //    return false;
                //}

                return open;
            }
            catch(Exception ex)
            {

                return false;
                //throw;
            }
        }

        public void SendSNCode(string sn)
        {
            byte[] dataBytes = new byte[17];

            byte[] cpBytes   = ASCIIEncoding.Default.GetBytes(sn.Substring(0, 2));

            byte   vrByte    = (byte)Convert.ToInt32(sn.Substring(2, 2),16);

            byte[] prBytes   = ASCIIEncoding.Default.GetBytes(sn.Substring(4, 2));

            byte[] seqBytes  = ASCIIEncoding.Default.GetBytes(sn.Substring(6, 6));

            byte sbByte      = (byte)Convert.ToInt32(sn.Substring(12, 2), 16);

            dataBytes[0]  = 0xFF;
            dataBytes[1]  = 0x03;
            dataBytes[2]  = 0x01;
            dataBytes[3]  = cpBytes[0];
            dataBytes[4]  = cpBytes[1];
            dataBytes[5]  = vrByte;
            dataBytes[6]  = prBytes[0];
            dataBytes[7]  = prBytes[1];
            dataBytes[8]  = seqBytes[0];
            dataBytes[9]  = seqBytes[1];
            dataBytes[10] = seqBytes[2];
            dataBytes[11] = seqBytes[3];
            dataBytes[12] = seqBytes[4];
            dataBytes[13] = seqBytes[5];
            dataBytes[14] = sbByte;
            dataBytes[15] = 0xEE;
            dataBytes[16] = 0x02;

            SendMessage(dataBytes);
        }


        /// <summary>
        /// 设置模式
        /// </summary>
        /// <param name="mode"></param>
        public void SendModeCode(int mode)
        {
            byte[] dataBytes = new byte[6];
            dataBytes[0] = 0xFF;
            dataBytes[1] = 0x03;
            dataBytes[2] = 0x02;
            dataBytes[3] = (byte)mode;
            dataBytes[4] = 0xEE;
            dataBytes[5] = 0x02;

            SendMessage(dataBytes);
 
        }



        /// <summary>
        /// 处理读取数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void ProcessDataReceived(object sender, EventArgs e)
        {
            try
            {
                int totalBytes = this.BytesToRead;
                if (totalBytes == 0)
                    return;

                int byteCount = 0;

                byte[] readBytes = new byte[totalBytes];

                while (byteCount < totalBytes)
                {

                    readBytes[byteCount] = (byte)this.ReadByte();

                    byteCount++;
                }

                String SerialIn = System.Text.Encoding.ASCII.GetString(readBytes, 0, totalBytes);

                if (ReceiveResultEvent != null)
                {
                    ReceiveResultEvent(SerialIn, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                CLog.WriteErrLog(ex.Message.ToString());
            }

        }


        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="data"></param>
        private void SendMessage(byte[] data)
        {
            try
            {
                this.Write(data, 0, data.Length);
            }
            catch
            {
                throw;
            }
        }

        public void ClosePort()
        {
            if (this.IsOpen)
                this.DiscardOutBuffer();
            if (this.IsOpen)
                this.Close();
  
        }

    }
}
