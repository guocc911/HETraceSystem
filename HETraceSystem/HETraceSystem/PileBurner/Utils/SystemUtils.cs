using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace PileBurner
{


    public class TableInfo
    {

        private int count = 0;

        private int curindex = 0;

        private int pageSize = 0;

        private int selectedPage = 0;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

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

    }
}
