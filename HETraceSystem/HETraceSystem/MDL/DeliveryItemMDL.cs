using System;
using System.Collections.Generic;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MDL
{

    /// <summary>
    /// 发货记录表
    /// </summary>
    public class DeliveryItemMDL
    {
        private string seqid;

        private string sn;

        private string ln;

        private string pcid;

        private int deliver_status;

        private string contact;

        private string username;

        private string forwarderid;

        private string forwarder;

        private string direction;

        private DateTime deliver_date;

        private DateTime scan_date;

        private string userid;

        private DateTime login_date;

        private string address;

        /// <summary>
        /// 插入序号
        /// </summary>
        public string SEQID
        {
            get { return seqid; }
            set { seqid = value; }
        }


        /// <summary>
        /// 序列号
        /// </summary>
        public string SN
        {
            get { return sn; }
            set { sn = value; }
        }


        public string PCID
        {
            get {
               
                    try
                    {
                        if (pcid != null)
                            return pcid;

                        if (this.sn == null || this.sn == String.Empty)
                            return string.Empty;

                        return ProductMDL.PraseSNCode(this.sn);
                    }
                    catch
                    {
                        return string.Empty;
                    }

                }

            set { pcid = value; }
        }

        /// <summary>
        /// 物流编号
        /// </summary>
        public string LN
        {
            get { return ln; }
            set { ln = value; }
        }



        /// <summary>
        /// 发货状态
        /// </summary>
        public int DELIVER_STAUTS
        {
            get { return deliver_status; }
            set { deliver_status = value; }
        }


        /// <summary>
        /// 联系方式
        /// </summary>
        public string CONTACT
        {
            get { return contact; }
            set { contact = value; }
        }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string USERNAME
        {
            get { return username; }
            set { username = value; }
        }


        /// <summary>
        /// 货代信息
        /// </summary>
        public string FORWARDERDID
        {
            get { return forwarderid; }
            set { forwarderid = value; }
        }


        /// <summary>
        /// 方向
        /// </summary>
        public string DIRECTION
        {
            get { return direction; }
            set { direction = value; }
        }


        /// <summary>
        /// 投递时间
        /// </summary>
        public DateTime DELIVER_DATE
        {
            get { return deliver_date; }
            set { deliver_date = value; }
        }

        /// <summary>
        /// 扫描时间
        /// </summary>
        public DateTime SCAN_DATE
        {
            get { return scan_date; }
            set { scan_date = value; }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string USERID
        {
            get { return userid; }
            set { userid = value; }
        }

        /// <summary>
        /// 登记时间
        /// </summary>
        public DateTime LOGINDATE
        {
            get { return login_date; }
            set { login_date = value; }
        }


        public String ADDRESS
        {
            get { return address; }
            set { address = value; }
        }

        public static DeliveryItemMDL Parse(DataRow item)
        {
            try
            {
                if (item == null)
                    return null;
     


                DeliveryItemMDL mdl = new DeliveryItemMDL();
                mdl.SEQID = Convert.ToString(item["SEQID"]);
                mdl.SN = Convert.ToString(item["SN"]);
                mdl.LN = Convert.ToString(item["LN"]);
                mdl.PCID = Convert.ToString(item["PCID"]);
                mdl.DELIVER_STAUTS = Convert.ToInt32(item["DELIVER_STATUS"]);
                mdl.CONTACT = Convert.ToString(item["CONTACT"]);
                mdl.USERNAME = Convert.ToString(item["USERNAME"]);
                mdl.FORWARDERDID = Convert.ToString(item["FORWARDER"]);
                mdl.DIRECTION = Convert.ToString(item["DIRECTION"]);
                mdl.DELIVER_DATE = Convert.ToDateTime(item["DELIVER_DATE"]);
                mdl.SCAN_DATE = Convert.ToDateTime(item["SCAN_DATE"]);
                mdl.USERID = Convert.ToString(item["USERID"]);
                mdl.ADDRESS = Convert.ToString(item["ADDRESS"]);
                mdl.LOGINDATE = Convert.ToDateTime(item["LOGINDATE"]);
                return mdl;
            }
            catch
            {
                return null;
            }
        }


        public bool WriteInfo(XmlWriter xlwr)
        {
            try
            {
                if (xlwr == null)
                    return false;

                xlwr.WriteStartElement("DeliveryInfo");
                xlwr.WriteElementString("LN", this.ln.Trim());//物流编号
                xlwr.WriteElementString("Contact", this.ln.Trim());//联系方式
                xlwr.WriteElementString("UserName", this.username.Trim());//用户名称
                xlwr.WriteElementString("Agent", this.forwarder.Trim());//货代
                xlwr.WriteElementString("Direction", this.direction.Trim());//方向
                xlwr.WriteElementString("Address", this.address.Trim());//方向
                xlwr.WriteEndElement();

                return true;
            }
            catch
            {
                throw;
            }

        }

        public void SetDeviceInfo(DeliveryItemMDL info)
        {
            this.username = info.USERNAME;
            this.ln = info.LN;
            this.contact = info.CONTACT;
            this.forwarder = info.FORWARDERDID;
            this.direction = info.DIRECTION;
            this.address = info.ADDRESS;
        }

        /// <summary>
        /// 读数据信息
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public DeliveryItemMDL ReadInfo(XmlNode node)
        {
            try
            {
                if (node == null)
                    return null;

                DeliveryItemMDL mdl = new DeliveryItemMDL();

                foreach (XmlNode item in node.ChildNodes)
                {

                    switch (item.Name)
                    {
                        case "LN":
                            mdl.LN = item.InnerText.Trim();
                            break;
                        case "Contact":
                            mdl.CONTACT = item.InnerText.Trim();
                            break;
                        case "UserName":
                            mdl.USERNAME = item.InnerText.Trim();
                            break;
                        case "Agent":
                            mdl.FORWARDERDID = item.InnerText.Trim();
                            break;
                        case "Direction":
                            mdl.DIRECTION = item.InnerText.Trim();
                            break;
                        case "Address":
                            mdl.ADDRESS = item.InnerText.Trim();
                            break;
                        default:
                            break;
                    }


                }

                return mdl;
            }
            catch
            {
                throw;
            }
        }
    }
}
