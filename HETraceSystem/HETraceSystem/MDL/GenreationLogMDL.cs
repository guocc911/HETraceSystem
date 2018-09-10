using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDL
{
    public class GenreationLogMDL
    {
        #region fields
        private string seqid;

        private string pcid;

        private string cpcode;

        private string vrcode;

        private string prcode;

        private string sbcode;

        private int startnum;

        private int endnum;

        private int status;

        private DateTime logindate;

        #endregion

        #region properities

        public string SEQID
        {
            get { return seqid; }
            set { seqid = value; }
 
        }

        /// <summary>
        /// 大类编号
        /// </summary>
        public string PCID
        {
            get { return pcid; }
            set { pcid = value; }
        }

        public string CPCODE
        {
            get { return cpcode; }
            set { cpcode = value; }
        }


        public string VRCODE
        {
            get { return vrcode; }
            set { vrcode = value; }
        }


        public string PRCODE
        {
            get { return prcode; }
            set { prcode = value; }
        }

        public string SBCODE
        {
            get { return sbcode; }
            set { sbcode = value; }
        }

        public int START_NUM
        {
            get { return startnum; }
            set { startnum = value; }
        }

        public int END_NUM
        {
            get { return endnum; }
            set { endnum = value; }
        }

        public int STAUTS
        {
            get { return status; }
            set { status = value; }
        }


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
        public static GenreationLogMDL Parse(DataRow item)
        {
            try
            {
                if (item == null)
                    return null;

                GenreationLogMDL mdl = new GenreationLogMDL();

                mdl.SEQID = Convert.ToString(item["SEQID"]);
                mdl.PCID = Convert.ToString(item["PCID"]);
                mdl.CPCODE = Convert.ToString(item["CP_CODE"]);
                mdl.VRCODE = Convert.ToString(item["VR_CODE"]);
                mdl.PRCODE = Convert.ToString(item["PR_CODE"]);
                mdl.SBCODE = Convert.ToString(item["SB_CODE"]);
                mdl.START_NUM = Convert.ToInt32(item["START_NUM"]);
                mdl.END_NUM = Convert.ToInt32(item["END_NUM"]);
                mdl.STAUTS = Convert.ToInt32(item["STATUS"]);
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
