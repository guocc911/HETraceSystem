
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using System.Text;
using System.Xml;
using MDL;
using COMM;

namespace HETraceSystem.Utils
{
    public class WorkSpace
    {
        #region Fields

        private string cfgFile = "";

        private string _lastProjectPath = "'";

        private int _selectIndex = 0;

        private DBInfo dbinfo=null;

        private List<DeviceInfo> devices;


        //private List<PileStandard> pileStandards = null;

        private List<PileAdapter> pileAdapter = null;

        #endregion

        #region Properities
        //public string LastProjectPath
        //{
        //    get { return _lastProjectPath; }
        //    set { _lastProjectPath = value; }
        //}


        //public int SelectIndex
        //{
        //    get { return _selectIndex; }
        //    set { _selectIndex = value; }
        //}


        public List<DeviceInfo> Devices
        {
            get { return devices; }
            set { devices = value; }
        }



        public DBInfo DBInfo 
        {
            get { return dbinfo; }
            set { dbinfo = value; }
        }



        #endregion

        public WorkSpace(string filePath)
        {
            cfgFile = Path.Combine(filePath, "TraceSystem.cfg");
            devices = new List<DeviceInfo>();
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

                    //XmlNode nodes = congfigdoc.SelectSingleNode("TraceSystem/WorkSapce");

                    //foreach (XmlNode node in nodes.ChildNodes)
                    //{
                    //    switch (node.Name)
                    //    {
                    //        case "LastProject":
                    //            this._lastProjectPath = node.InnerText;
                    //            break;
                    //        case "SelectIndex":
                    //            this._selectIndex = Convert.ToInt32(node.InnerText);
                    //            break;
                    //        default:
                    //            break;
                    //    }
                    //}


                    XmlNode nodes = congfigdoc.SelectSingleNode("TraceSystem");

                    DBInfo info=new DBInfo();

                    foreach (XmlNode node in nodes.ChildNodes)
                    {
                        switch (node.Name)
                        {

                            case "DBConfig":
                                foreach(XmlNode item in node.ChildNodes)
                                {
                                    switch (item.Name)
                                    {
                                        case "Server":
                                            info.Server = item.InnerText;
                                            break;
                                        case "Name":
                                            info.DBName = item.InnerText;
                                            break;
                                        case "User":
                                            info.User = item.InnerText;
                                            break;
                                        case "Password":

                                           info.PWD = COMM.AESHelper.AESDecrypt(item.InnerText);
                                         
                                            break;

                                        default:
                                            break;
                                    }
                                }
                                break;

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
                            default:
                                break;
                            
                        }
                    }
                    this.dbinfo = info;

                    //this.dbinfo = DBInfo.DeCodeInfo(info);

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
                    xtr.WriteStartElement("TraceSystem");
                    xtr.WriteStartElement("WorkSapce");

                    //xtr.WriteElementString("LastProject", this._lastProjectPath);
                    //xtr.WriteElementString("SelectIndex", this._selectIndex.ToString());


                    xtr.WriteEndElement();

                     //数据库配置信息
                    if (dbinfo == null)
                        dbinfo = new Utils.DBInfo();

                        //DBInfo  info = DBInfo.EnCodeInfo(this.dbinfo);
                        xtr.WriteStartElement("DBConfig");
                        xtr.WriteElementString("Server", dbinfo.Server);
                        xtr.WriteElementString("User", dbinfo.User);
                        xtr.WriteElementString("Name", dbinfo.DBName);
                        xtr.WriteElementString("Password", COMM.AESHelper.AESEncrypt(dbinfo.PWD));
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
                if (devices==null||devices.Count == 0 )
                    return null;

                DeviceInfo ret = null;

                foreach (DeviceInfo item in devices)
                {
                    if (item.Index == index)
                    {
                        ret = new DeviceInfo();
                        ret = item;
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
                            item.SetDeviceInfo(info);
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
