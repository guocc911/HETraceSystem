using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMM;

namespace MDL
{

    
    public class PrintLogMDL
    {
        private string seqid;

        private string sn;

        private CodeType print_type;

        private int count;

        private DateTime print_date;

        private string deviceid;

        private string userid;

        
        /// <summary>
        ///序号ID
        /// </summary>
        public string SEQID
        {
            get { return seqid; }
            set { seqid = value; }
        }

        /// <summary>
        /// 序号
        /// </summary>
        public string SN
        {
            get { return sn; }
            set { sn = value; }
        }

        /// <summary>
        /// 打印类型
        /// </summary>
        public CodeType PRINT_TYPE
        {
            get { return print_type; }
            set { print_type = value; }
        }

        /// <summary>
        /// 数量
        /// </summary>
        public int COUNT
        {
            get { return count; }
            set { count = value; }
        }

        /// <summary>
        /// 打印时间
        /// </summary>
        public DateTime  PRINT_DATE
        {
            get { return print_date; }
            set { print_date = value; }
        }


        public string DEVICE_ID
        {
            get { return deviceid; }
            set { deviceid = value; }
        }

        public string USERID
        {
            get { return userid; }
            set { userid = value; }
        }



        /// <summary>
        /// 解析数据
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static PrintLogMDL Parse(DataRow item)
        {
            try
            {
                if (item == null)
                    return null;

                PrintLogMDL mdl = new PrintLogMDL();

                mdl.SEQID = Convert.ToString(item["SEQID"]);
                mdl.SN = Convert.ToString(item["SN"]);
                mdl.PRINT_TYPE = (CodeType)Convert.ToInt32(item["PRINT_TYPE"]);
                mdl.COUNT = Convert.ToInt32(item["COUNT"]);
                mdl.PRINT_DATE = Convert.ToDateTime(item["PRINT_DATE"]);
                mdl.DEVICE_ID = Convert.ToString(item["DEVICEID"]);
                mdl.USERID = Convert.ToString(item["USERID"]);
     
                return mdl;
            }
            catch
            {
                return null;
            }
        }
    }
}
