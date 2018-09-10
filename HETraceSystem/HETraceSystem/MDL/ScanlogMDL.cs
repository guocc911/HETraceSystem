using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMM;

namespace MDL
{
    public class ScanlogMDL
    {
        private string seqid;

        private string sn;

        private CodeType type;

        private int count;

        private string deviceid;

        private string userid;

        private DateTime printdate;


        #region properties
        /// <summary>
        /// 插入序列号
        /// </summary>
        public string SEQID
        {
            get { return seqid; }
            set { seqid = value; }
        }

        /// <summary>
        /// 发货编码
        /// </summary>
        public string SN
        {
            get { return sn; }
            set { sn = value; }
        }

        public CodeType  Type
        {
            get { return type; }
            set { type = value; }
        }

        public int COUNT
        {
            get { return count; }
            set { count = value; }
        }

        public string  DEVICEID
        {
            get { return deviceid; }
            set { deviceid = value; }
        }


        public string USERID
        {
            get { return userid; }
            set { userid = value; }
        }


        public DateTime printDate
        {
            get { return printdate; }
            set { printdate = value; }
        }

        public ScanlogMDL()
        {
            seqid=string.Empty;
            sn=string.Empty;
            type = CodeType.Orther;
            count=0;
            deviceid=string.Empty;
            userid=string.Empty;
            printdate = DateTime.Now;
        }
       
        #endregion

    }
}
