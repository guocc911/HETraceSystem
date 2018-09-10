using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MDL
{
    /// <summary>
    /// 充电桩标准
    /// </summary>
    public  class PileStandard
    {
        private int code;

        private string name;

        public int Code
        {
            get { return code; }
            set { code = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public PileStandard()
        {
            code = -1;
            name = string.Empty;
        }

        public PileStandard(int Code, string Name)
        {
            this.code = Code;
            this.name = Name;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static List<PileStandard> Prase(XmlElement node)
        {

             List<PileStandard> standards=new List<PileStandard>();

            try
            {

                foreach (XmlNode item in node.ChildNodes)
                {

                    switch (item.Name)
                    {
                        case "PileStandard":

                            string[] items = item.InnerText.Split(';');

                            foreach(string ps in items)
                            {
                                PileStandard standard = new PileStandard();

                                string[] codes = ps.Split('|');
                                standard.Name = codes[0];
                                standard.Code = Convert.ToInt32(codes[1]);

                                standards.Add(standard);

                            }


                            break;
                        default:
                            break;
                    }
                
                }
                return standards;
            }
            catch
            {
                throw;
            }
 
        }


        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="standards"></param>
        /// <returns></returns>
        public static string GetCData(List<PileStandard> standards)
        {

            StringBuilder ret = new StringBuilder();

            try
            {

                if (standards == null)
                    return String.Empty;

                foreach (PileStandard item in standards)
                {
                    ret.Append(item.Name + "|" + item.code.ToString()+";"); 
                }

                return ret.Remove(ret.Length-1,1).ToString();
            }
            catch
            {
                throw;
            }
 
        }


    }



    public class PileAdapter
    {

        private int code;

        private string name;

        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public PileAdapter()
        {
            code = -1;
            name = string.Empty;
        }

        public PileAdapter(int Code, string Name)
        {
            this.code = Code;
            this.name = Name;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static List<PileAdapter> Prase(XmlElement node)
        {

            List<PileAdapter> standards = new List<PileAdapter>();

            try
            {

                foreach (XmlNode item in node.ChildNodes)
                {

                    switch (item.Name)
                    {
                        case "PileAdapter":

                            string[] items = item.InnerText.Split(';');

                            foreach (string ps in items)
                            {
                                PileAdapter adapter = new PileAdapter();

                                string[] codes = ps.Split('|');
                                adapter.Name = codes[0];
                                adapter.Code = Convert.ToInt32(codes[1]);

                                standards.Add(adapter);

                            }


                            break;
                        default:
                            break;
                    }

                }
                return standards;
            }
            catch
            {
                throw;
            }

        }


        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="standards"></param>
        /// <returns></returns>
        public static string GetCData(List<PileAdapter> adapters)
        {

            StringBuilder ret = new StringBuilder();

            try
            {

                if (adapters == null)
                    return String.Empty;

                foreach (PileAdapter item in adapters)
                {
                    ret.Append(item.Name + "|" + item.code.ToString() + ";");
                }

                return ret.Remove(ret.Length - 1, 1).ToString();
            }
            catch
            {
                throw;
            }

        }

    }
}
