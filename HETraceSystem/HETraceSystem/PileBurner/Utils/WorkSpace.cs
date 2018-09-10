
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using System.Text;
using System.Xml;
using MDL;
using COMM;

namespace PileBurner.Utils
{
    public class WorkSpace
    {
        #region Fields

        private string cfgFile = "";

        private string _lastProjectPath = "'";

        private int _selectIndex = 0;


        private List<DeviceInfo> devices;

        private SerialPortPar serialPortPar = null;


        //private List<PileStandard> pileStandards = null;

        private List<PileAdapter> pileAdapter = null;


        private string outPath;


        #endregion

        #region Properities



        public List<DeviceInfo> Devices
        {
            get { return devices; }
            set { devices = value; }
        }

        public SerialPortPar SerialPortPar
        {
            get { return serialPortPar; }
            set { serialPortPar = value; }
        }


        public string OutPath
        {
            get { return outPath; }
            set { outPath = value; }
        }





        #endregion

        public WorkSpace(string filePath)
        {
            cfgFile = Path.Combine(filePath, "PileBurner.cfg");
            devices = new List<DeviceInfo>();
            SerialPortPar = new SerialPortPar();
            outPath = @"C:\QRCode";

            //_lastProjectPath = "";
            //_selectIndex = 0;
        }



        private void InitialPileAdapter()
        {
 
        }

        /// <summary>
        /// 加载工作空间
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            bool ret = false;
            try
            {
                if (File.Exists(cfgFile))
                {
                    XmlDocument congfigdoc = new XmlDocument();

                    congfigdoc.Load(cfgFile);

                    XmlNode nodes = congfigdoc.SelectSingleNode("PileBurner");


                    foreach (XmlNode node in nodes.ChildNodes)
                    {
                        switch (node.Name)
                        {
                            case "Devices":

                               // int count = Convert.ToInt32(node.Attributes[0]);

                                if (this.devices == null)
                                    this.devices.Clear();

                                this.devices = new List<DeviceInfo>();


                                foreach (XmlNode deviceItem in node.ChildNodes)
                                {
                                    switch (deviceItem.Name)
                                    {
                                        case "DeviceInfo":

                                            DeviceInfo device = new DeviceInfo();
                                            this.devices.Add(device.ReadInfo(deviceItem));

                                            break;
                                        default:
                                            break;
                                    }

                                }
                              
                                break;
                            case "SerialPort":
                                serialPortPar = serialPortPar.ReadInfo(node);
                                break;
                            case "OutPath":
                                outPath = node.InnerText;
                                break;

                            default:
                                break;
                            
                        }
                    }
          

                }
                else
                {
                    WriteFile();
                }
            }
            catch
            {
                throw;
            }
            return ret;
        }


        /// <summary>
        /// 保存工作空间
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            bool ret = false;
            try
            {
                ret = WriteFile();
            }
            catch
            {

            }
            return ret;
        }

        /// <summary>
        /// 写配置文件
        /// </summary>
        private bool WriteFile()
        {
            bool ret = false;
            try
            {

                XmlWriterSettings setting = new XmlWriterSettings();
                setting.Encoding = System.Text.Encoding.UTF8;
                setting.Indent = true;
                setting.IndentChars = "  ";

                if (File.Exists(cfgFile))
                {
                    File.Delete(cfgFile);
                }


                using (XmlWriter xtr = XmlWriter.Create(cfgFile, setting))
                {
                    xtr.WriteStartDocument();
                    xtr.WriteStartElement("PileBurner");
                    xtr.WriteStartElement("WorkSapce");

                    //xtr.WriteElementString("LastProject", this._lastProjectPath);
                    //xtr.WriteElementString("SelectIndex", this._selectIndex.ToString());


                    xtr.WriteEndElement();


                        ///写入设备
                        if (devices != null)
                        {

                            xtr.WriteStartElement("Devices");
                            xtr.WriteAttributeString("Count", devices.Count.ToString());

                            foreach (DeviceInfo info in devices)
                            {
                                info.WriteInfo(xtr);
                            }
                            xtr.WriteEndElement();

                        }

                        if (serialPortPar != null)
                        {
                            serialPortPar.WriteInfo(xtr);
                        }

                        xtr.WriteStartElement("OutPath");
                        xtr.WriteElementString("Path",this.outPath.Trim());
                        xtr.WriteEndElement();

                        xtr.WriteEndElement();
                        xtr.WriteEndDocument();
                        xtr.Flush();

                }

                ret = true;
            }
            catch
            {
            }
            return ret;
        }


        /// <summary>
        /// 获取打印机信息
        /// </summary>
        /// <returns></returns>
        public DeviceInfo GetDeviceInfo(int index)
        {
            try
            {
                if (devices==null )
                    return null;

                DeviceInfo ret = null;

                foreach (DeviceInfo item in devices)
                {
                    if (item.Index == index)
                    {
                        ret = new DeviceInfo();
                        ret.Index = item.Index;
                        ret.Name = item.Name;
                        ret.DeviceID = item.DeviceID;
                        ret.Status = item.Status;
                    }
                }

                return ret;

            }
            catch
            {
                throw;
            }
        }


        public void SetDeviceInfo(DeviceInfo info )
        {
            try
            {
                bool added = false;

                if(info==null)
                    return ;

                if (devices.Count == 0)
                {
                    devices.Add(info);
                    added = true;
                }
                else
                {
                    foreach (DeviceInfo item in devices)
                    {
                        if (item.Index == info.Index)
                        {
                            item.Index = info.Index;
                            item.Name = info.Name;
                            item.DeviceID = info.DeviceID;
                            item.Status = info.Status;
                            added = true;
                        }
                    }
                }


                if (!added)
                {

                    devices.Add(info);
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
