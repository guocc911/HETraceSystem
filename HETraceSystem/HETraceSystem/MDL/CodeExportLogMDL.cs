using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MDL
{
    public class CodeExportLogMDL
    {

        private string seqid;

        private string sn;

        private int dir;

        private string userid;

        private int width;

        private int height;

        private DateTime printdate;


        public string SEQID 
        {
            get { return seqid; }
            set { seqid = value; }
        }
        public string SN
        {
            get { return seqid; }
            set { seqid = value; }
        }

        public int DIR
        {
            get { return dir; }
            set { dir = value; }
        }

        public string USERID
        {
            get { return userid; }
            set { userid = value; }
        }


        public int WIDTH
        {
            get { return width; }
            set { width = value; }
        }

        public int HEIGHT
        {
            get { return height; }
            set { height = value; }
        }

        public DateTime PRINT_DATE
        {
            get { return printdate; }
            set { printdate = value; }
        }

        public static CodeExportLogMDL Parse(DataRow row)
        {
            try
            {
                if (row == null)
                    return null;

                CodeExportLogMDL mdl = new CodeExportLogMDL();

                mdl.SEQID = Convert.ToString(row["SEQID"]);
                mdl.SN = Convert.ToString(row["SN"]);
                mdl.DIR = Convert.ToInt32(row["DIR"]);
                mdl.USERID = Convert.ToString(row["USERID"]);
                mdl.WIDTH = Convert.ToInt32(row["WIDTH"]);
                mdl.HEIGHT = Convert.ToInt32(row["HEIGHT"]);
                mdl.PRINT_DATE = Convert.ToDateTime(row["PRINT_DATE"]);

                return mdl;
            }
            catch
            {
                return null;
            }
        }
    }
}
