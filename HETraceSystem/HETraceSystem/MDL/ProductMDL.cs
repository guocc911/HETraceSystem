using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using COMM;

namespace MDL
{
    /// <summary>
    /// 产品
    /// </summary>
    public class ProductMDL
    {

        private string pcid;

        private string name;

        private string cp_code;

        private string vr_code;

        private string pr_code;

        private string sb_code;

        private int seqnum;

        private DateTime reg_date;

        private string reg_user;

        private string used_code;

        private PileType pileType;

        private PtModel ptModel;

        private double chargepower;

        private int port_num;

        private string adapter_type;


        private string remark;



        #region properites
        /// <summary>
        ///  电桩ID
        /// </summary>
        public string PCID 
        {
            get { return pcid; }
            set { pcid = value; }
        }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //公司编号
        public string CP_CODE
        {
            get { return cp_code; }
            set { cp_code = value; }
        }

        //版本编号
        public string VR_CODE
        {
            get { return vr_code; }
            set { vr_code = value; }
        }

        /// <summary>
        /// 序列号
        /// </summary>
        public int SeqNum
        {
            get { return seqnum; }
            set { seqnum = value; }
        }


        //产品编号
        public string PR_CODE
        {
            get { return pr_code; }
            set { pr_code = value; }
        }

        //小版本号
        public string SB_CODE
        {
            get { return sb_code; }
            set { sb_code = value; }
        }


        //注册时间
        public DateTime REG_DATE
        {
            get { return reg_date; }
            set { reg_date = value; }
        }

        //注册用户
        public string REG_USER
        {
            get { return reg_user; }
            set { reg_user = value; }
        }

        /// <summary>
        ///  登记用户编号
        /// </summary>
        public string USED_CODE
        {
            get { return used_code; }
            set { used_code = value; }
        }



        public PileType PILETYPE
        {
            get { return pileType; }
            set { pileType = value; }
        }

        /// <summary>
        /// 接口类型
        /// </summary>
        public PtModel PT_MODEL
        {
            get { return ptModel; }
            set { ptModel = value; }
        }

        public double CHARGE_POWER
        {
            get { return chargepower; }
            set { chargepower = value; }
        }

        public int PORT_NUM
        {
            get { return port_num; }
            set { port_num = value; }
        }

        public string ADAPTER_TYPE
        {
            get { return adapter_type; }
            set { adapter_type = value; }
        }


        public string REMARK
        {
            get { return remark; }
            set { remark = value; }
        }

        #endregion
        
        public static string getProductSN(ProductMDL product,string seqCode)
        {
            string ret = string.Empty;

            ret = product.CP_CODE +
                product.PR_CODE +
                product.VR_CODE +
                seqCode +
                product.SB_CODE;
            return ret;

        }


        /// <summary>
        /// 打包SN编码
        /// </summary>
        /// <param name="product"></param>
        /// <param name="seqCode"></param>
        /// <returns></returns>
        public static string getProductSN(ProductMDL product, int seqCode)
        {
            string ret = string.Empty;

            ret = product.CP_CODE +
                  product.PR_CODE +
                  product.VR_CODE +
                  String.Format("{0:D6}", seqCode) +
                  product.SB_CODE;

            return ret;

        }

        public static string PraseSNCode(string sn)
        {
            try
            {

                if (sn == null || sn == String.Empty || sn.Length != 14)
                    return null;


                string pcid = sn.Substring(0, 2) + sn.Substring(2, 2)
                              + sn.Substring(4, 2) + sn.Substring(12,2);

                return pcid;

            }
            catch
            {
                throw;
 
            }
 
        }

        /// <summary>
        /// 解析SN编码
        /// </summary>
        /// <param name="snCode"></param>
        /// <returns></returns>
        public static ProductMDL praseProductSN(string snCode)
        {
            ProductMDL pm = new ProductMDL();
            try
            {
                if (snCode == null || snCode.Length < 14)
                    return null;

                pm.CP_CODE = snCode.Substring(0, 2);
                pm.PR_CODE = snCode.Substring(2,2);
                pm.VR_CODE = snCode.Substring(4,2);
               
                string temp = snCode.Substring(6,6);
                int seq = 0;
                Int32.TryParse(temp, out seq);

                pm.SeqNum = seq;
                pm.SB_CODE = snCode.Substring(12,2);

                return pm;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 解析数据
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ProductMDL Parse(DataRow item)
        {
            try
            {
                if (item == null)
                    return null;

                ProductMDL mdl = new ProductMDL();

                mdl.PCID = Convert.ToString(item["PCID"]);
                mdl.Name = Convert.ToString(item["NAME"]);
                mdl.CP_CODE = Convert.ToString(item["CP_CODE"]);
                mdl.VR_CODE = Convert.ToString(item["VR_CODE"]);
                mdl.PR_CODE = Convert.ToString(item["PR_CODE"]);
                mdl.SB_CODE = Convert.ToString(item["SB_CODE"]);
                mdl.REG_DATE = Convert.ToDateTime(item["REG_DATE"]);
                mdl.REG_USER = Convert.ToString(item["REG_USER"]);
                mdl.USED_CODE = Convert.ToString(item["USED_SEQ"]);
                mdl.PILETYPE =(PileType) Convert.ToInt32(item["PILE_TYPE"]);
                mdl.CHARGE_POWER = Convert.ToDouble(item["CHARGE_POWER"]);
                mdl.PORT_NUM = Convert.ToInt32(item["PORT_NUM"]);
                mdl.PT_MODEL = (PtModel)Convert.ToInt32(item["PIPE_MODEL"]);
                mdl.ADAPTER_TYPE = Convert.ToString(item["ADAPTER_TYPE"]);
                mdl.REMARK = Convert.ToString(item["REMARK"]);
                return mdl;
            }
            catch
            {
                return null;
            }
        }

    }
}
