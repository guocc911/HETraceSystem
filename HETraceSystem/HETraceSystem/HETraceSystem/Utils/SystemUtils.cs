using System;
using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;



namespace HETraceSystem
{


    public class TableInfo
    {

        private int count = 0;

        private int curindex = 0;

        private int pageSize = 0;

        private int selectedPage = 0;

        /// <summary>
        /// 电桩总数
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        /// <summary>
        /// 选择的页号
        /// </summary>
        public int SelectedIndex
        {
            get { return curindex; }
            set { curindex = value; }
        }

        /// <summary>
        /// 选择页面
        /// </summary>
        public int SelectedPage
        {
            get { return selectedPage; }
            set { selectedPage = value; }
        }

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
 
        }



        public int PageNum
        {
            get
            {
                if (count <= 0 && pageSize <= 0)
                    return 0;

                int ret = count / pageSize;

                return ret;
            }
        }
 
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }


        public override string ToString()
        {
            return Text;
        }
    }
    public static class SystemUtils
    {
        public static string ApplicationPath = Path.GetDirectoryName(Application.ExecutablePath);



        public static ArrayList getTboxModelList()
        {
            ArrayList modelList = new ArrayList();
                modelList.Add("V0.1");
                modelList.Add("V1.0");
                modelList.Add("V1.1");
                modelList.Add("国标");

                return modelList;
         }

        public static int AppendSNNumber = 0;
        public static string GetNewTboxSN(string pcid,int sCount)
        {

            try
            {
                string ret = string.Empty;

                ExInventoryItemDAL dal = new ExInventoryItemDAL();

                if (AppendSNNumber<=0)
                    AppendSNNumber = sCount;

               // AppendSNNumber += 1;

                int pCount = dal.GetCount() + AppendSNNumber;

                string sn = String.Format("{0}{1:D6}{2}", pcid.Substring(0, 6), pCount, pcid.Substring(6, 2));

                if(dal.IMEIExsited(sn)>0)
                {
                    ret = GetNewTboxSN(pcid, pCount);
                }

                ret = sn;


                return sn;


            }
            catch
            {
                throw;
            }
            finally
            {
                AppendSNNumber = 0;
            }

        }



    }
}
