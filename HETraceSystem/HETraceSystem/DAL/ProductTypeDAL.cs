using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MDL;
using COMM;

namespace DAL
{
    /// <summary>
    /// 产品类型操作
    /// </summary>
    public class ProductTypeDAL
    {


        public static string Name="PT";

        public ProductTypeDAL()
        {
 
        }


        /// <summary>
        /// 获取类型数量
        /// </summary>
        /// <returns></returns>
        public int GetTypeCount()
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_product_type ";

                ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

                return ret;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// 检查类型是否存在
        /// </summary>
        /// <param name="codekey"></param>
        /// <returns></returns>
        public int CheckCode(string codekey)
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "select count(*) from tlb_product_type where TYPE_CODE='{0}'";

                string.Format(strSql, codekey);

                ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

                if (ret > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// 插入新类型
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertProType(ProductTypeMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "insert  into  tlb_product_type (TYPE_CODE,TYPE_NAME,REG_DATE,REMARK)" +
                         "values('{0}','{1}','{2}','{3}')";

                string regdate = String.Format("{0:yyyy-MM-dd HH:mm:ss}", mdl.RegDate);

                
                strSql = string.Format(strSql, mdl.TypeCode, mdl.TypeName, mdl.RegDate,mdl.ReMark);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }
 
        }

        /// <summary>
        /// 更新类型
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdateProType(ProductTypeMDL  mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "update tlb_product_type set TYPE_NAME='{0}', REMARK='{1}' "
                         + " where TYPE_CODE='{2}'";

                strSql = string.Format(strSql, mdl.TypeName, mdl.ReMark,mdl.TypeCode);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// 删除类型
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int DeleteProType(ProductTypeMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "delete from tlb_product_type where TYPE_CODE='{0}'";
                strSql = string.Format(strSql, mdl.TypeCode);
                //+mdl.TypeCode;

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }
        }


        /// <summary>
        /// 获取类型信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetProTypes()
        {

            try
            {
                DataSet dataSet = null;

                string strSql = "select * from tlb_product_type order by REG_DATE asc";

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet != null)
                    return dataSet.Tables[0];

                return null;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }


        public List<ProductTypeMDL> GetProTypeList()
        {

            List<ProductTypeMDL> protypes = new List<ProductTypeMDL>();

            try
            {
                DataSet dataSet = null;

                string strSql = "select * from tlb_product_type order by REG_DATE asc";

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet != null)
                {
                    foreach (DataRow item in dataSet.Tables[0].Rows)
                    {
                        protypes.Add(ProductTypeMDL.Parse(item));
                    }

                    return protypes;
                }
                else
                    return null;


            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                throw;
            }


        }





    }
}
