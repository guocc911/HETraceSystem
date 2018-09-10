using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using COMM;

namespace MDL
{

    /// <summary>
    /// 装配信息
    /// </summary>
    public class AssemblageMDL
    {
        private string logid;

        private string pcid;

        private string company;

        private DateTime protime;

        private string contact;

        private DateTime arrial_time;

        private string plineid;

        private int startsq;

        private int endseq;

        private string pline_name;

        private int sum;

        private string productid;

        private int bad;

        private DateTime logindate;


        #region    产品装配日志

        public string LOGID
        {
            get { return logid; }
            set {logid = value;}
        }

        /// <summary>
        /// 大类产品编码
        /// </summary>
        public string PCID
        {
            get { return pcid; }
            set { pcid = value; }
        }


        public string COMPANY
        {
            get { return company; }
            set { company = value; }
        }

        public DateTime PRO_TIME
        {
            get { return protime; }
            set { protime = value; }
        }


        public string CONTACT
        {
            get { return contact; }
            set { contact = value; }
        }


        public DateTime ARRIAL_TIME
        {
            get { return arrial_time; }
            set { arrial_time = value; }
        }

        /// <summary>
        /// 产线ID
        /// </summary>
        public string PLEND_ID
        {
            get { return plineid; }
            set { plineid = value; }
        }

        public int  START_SEQ
        {
            get { return startsq; }
            set { startsq = value; }
        }

        public int END_SEQ
        {
            get { return endseq; }
            set { endseq = value; }
        }


        /// <summary>
        /// 产线名称
        /// </summary>
        public string PLANE_NAME
        {
            get { return pline_name; }
            set { pline_name = value; }
        }

        /// <summary>
        /// 产品数量
        /// </summary>
        public int SUM
        {
            get { return sum; }
            set { sum = value; }
        }

        /// <summary>
        /// 产品大类编号
        /// </summary>
        public string PRODUCTID
        {
            get { return productid; }
            set { productid = value; }
        }


        /// <summary>
        /// 不良品数量
        /// </summary>
        public int BAD_NUM
        {
            get { return bad; }
            set { bad = value; }
 
        }


        /// <summary>
        /// 登记时间
        /// </summary>
        public DateTime LOGIN_DATE
        {
            get { return logindate; }
            set { logindate = value; }

        }





        /// <summary>
        /// 解析数据
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static AssemblageMDL Parse(DataRow item)
        {
            try
            {
                if (item == null)
                    return null;

                AssemblageMDL mdl = new AssemblageMDL();

                mdl.LOGID = Convert.ToString(item["LOGID"]);
                mdl.PCID = Convert.ToString(item["PCID"]);
                mdl.COMPANY = Convert.ToString(item["COMPANY"]);
                mdl.PRO_TIME = Convert.ToDateTime(item["PRO_TIME"]);
                mdl.CONTACT = Convert.ToString(item["CONTACT"]);
                mdl.ARRIAL_TIME = Convert.ToDateTime(item["ARRIAL_TIME"]);
                mdl.PLEND_ID = Convert.ToString(item["PLINEID"]);
                mdl.START_SEQ = Convert.ToInt32(item["START_SEQ"]);
                mdl.END_SEQ = Convert.ToInt32(item["END_SEQ"]);
                mdl.PLANE_NAME = Convert.ToString(item["PLINENAME"]);
                mdl.SUM = Convert.ToInt32(item["SUM"]);
                mdl.PRODUCTID = Convert.ToString(item["PRODUCTID"]);
                mdl.BAD_NUM = Convert.ToInt32(item["BAD"]);
                mdl.LOGIN_DATE = Convert.ToDateTime(item["LOGIN_DATE"]);
       

                return mdl;
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}
