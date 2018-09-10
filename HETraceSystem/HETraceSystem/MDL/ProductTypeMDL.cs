using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;


namespace MDL
{
    /// <summary>
    /// 类型模型
    /// </summary>
    public class ProductTypeMDL
    {


        private string typecode;

        private string typename;

        private DateTime regdate;

        private string remark;



        /// <summary>
        /// 产品类型编号
        /// </summary>
        public string TypeCode
        {
            get { return typecode; }
            set { typecode = value; }
        }

        /// <summary>
        /// 产品类型名称
        /// </summary>
        public string TypeName
        {
            get { return typename; }
            set { typename = value; }
        }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegDate
        {
            get { return regdate; }
            set { regdate = value; }
 
        }


        /// <summary>
        /// 备注
        /// </summary>
        public string ReMark
        {
            get { return remark; }
            set { remark = value; }
        }


        public static ProductTypeMDL Parse(DataRow row)
        {
            try
            {
                if (row == null)
                    return null;

                ProductTypeMDL mdl = new ProductTypeMDL();

                mdl.TypeCode = Convert.ToString(row["TYPE_CODE"]);
                mdl.TypeName = Convert.ToString(row["TYPE_NAME"]);
                mdl.RegDate  = Convert.ToDateTime(row["REG_DATE"]);
                mdl.ReMark   = Convert.ToString(row["REMARK"]);
         

                return mdl;
            }
            catch
            {
                return null;
            }
        }
    }
}
