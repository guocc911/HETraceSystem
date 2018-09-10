using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MDL;
using COMM;

namespace DAL
{


   
    public class ProductDAL
    {
        public ProductDAL()
        {
 
        }

        /// <summary>
        /// 获取类型数量
        /// </summary>
        /// <returns></returns>
        public int GetProductCount()
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_product";

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
        /// 检查产品是否添加
        /// </summary>
        /// <param name="codekey"></param>
        /// <returns></returns>
        public int ProductIsExited(string productid)
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "select count(*) from tlb_product where PCID='{0}'";

                strSql=string.Format(strSql, productid);

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





        public int IsUsedProductType(string productType)
        {

            int ret = -1;

            string strSql = string.Empty;

            try
            {

                strSql = "select count(*) from tlb_product where PR_CODE='{0}'";

                string.Format(strSql, productType);

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
        /// 插入新产品
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertProductItem(ProductMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {


                strSql = "insert  into  tlb_product (PCID,NAME,CP_CODE,VR_CODE,PR_CODE,SB_CODE,REG_DATE,REG_USER,"
                          + "USED_SEQ,PILE_TYPE,CHARGE_POWER,PORT_NUM,ADAPTER_TYPE,REMARK,PIPE_MODEL)"
                          + "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},'{11}','{12}','{13}',{14})";

               // string regdate = String.Format("{0:yyyy-MM-dd HH:mm:ss}", mdl.REG_DATE);


                strSql = string.Format(strSql, mdl.PCID, mdl.Name, mdl.CP_CODE, mdl.VR_CODE,mdl.PR_CODE,mdl.SB_CODE,
                                       mdl.REG_DATE.ToString("yyyy-MM-dd HH:mm:ss"), mdl.REG_USER, mdl.USED_CODE, (int)mdl.PILETYPE, mdl.CHARGE_POWER,
                                       mdl.PORT_NUM, mdl.ADAPTER_TYPE, mdl.REMARK, (int)mdl.PT_MODEL);

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
        public int UpdateProductItem(ProductMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "update tlb_product set  NAME='{0}',CP_CODE='{1}',VR_CODE='{2}',PR_CODE='{3}',SB_CODE='{4}',REG_DATE='{5}',"
                         + "REG_USER='{6}',USED_SEQ='{7}',PILE_TYPE='{8}',CHARGE_POWER='{9}',PORT_NUM='{10}',ADAPTER_TYPE='{11}',REMARK='{12}', PIPE_MODEL='{13}'"
                         + " where PCID='{14}'";

                strSql = string.Format(strSql, mdl.Name, mdl.CP_CODE, mdl.VR_CODE, mdl.PR_CODE, mdl.SB_CODE, mdl.REG_DATE.ToString("yyyy-MM-dd HH:mm:ss"),
                                       mdl.REG_USER, mdl.USED_CODE, (int)mdl.PILETYPE, mdl.CHARGE_POWER, mdl.PORT_NUM, mdl.ADAPTER_TYPE, mdl.REMARK, (int)mdl.PT_MODEL, mdl.PCID);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }
        }


        public ProductMDL GetProductItemByPRcode(string strPRCode)
        {

            try
            {

                DataSet dataSet = null;

                ProductMDL mdl = new ProductMDL();

                string strSql = "select * from tlb_product where PR_CODE='{0}' ";

                strSql = string.Format(strSql, strPRCode);

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                //解析数据
                mdl = ProductMDL.Parse(dataSet.Tables[0].Rows[0]);

                return mdl;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strPCID"></param>
        /// <returns></returns>
        public ProductMDL GetProductItem(string strPCID)
        {
            try
            {

                DataSet dataSet = null;

                ProductMDL mdl = new ProductMDL();

                string strSql = "select * from tlb_product where PCID='{0}' ";

                strSql = string.Format(strSql, strPCID);

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                //解析数据
                mdl = ProductMDL.Parse(dataSet.Tables[0].Rows[0]);

                return mdl;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int DeleteProduct(ProductMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "delete from tlb_product where PCID='" + mdl.PCID+"'";

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
        /// 获取产品信息
        /// </summary>
        /// <returns></returns>
        public List<ProductMDL> GetProducts()
        {
            List<ProductMDL> lists = new List<ProductMDL>();


            try
            {
                DataSet dataSet = null;

                string strSql = "select * from tlb_product order by REG_DATE asc";

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                //解析数据
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    ProductMDL mdl = new ProductMDL();
                    mdl = ProductMDL.Parse(item);
                    lists.Add(mdl);
                }

                return lists;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }



    }
}
