using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MDL;
using COMM;

namespace DAL
{
    public class DeliveryLogDal
    {

        /// <summary>
        /// 获取装配记录
        /// </summary>
        /// <returns></returns>
        public int GetRecrodCount()
        {

            int result = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_delivery_list";
   

                result = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

                return result;
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
        public int DeliveryItemIsExited(string seqid)
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "select count(*) from tlb_delivery_list where SEQID={'0'}";

                strSql=string.Format(strSql, seqid);

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
        /// 插入装配信息
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertDeliveryItem(DeliveryItemMDL mdl)
        {
            int result = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "insert  into  tlb_delivery_list (SEQID,SN,LN,PCID,DELIVER_STATUS,CONTACT,USERNAME,FORWARDERID,"
                          + "FORWARDER,DIRECTION,DELIVER_DATE,SCAN_DATE,USERID,LOGINDATE,ADDRESS)"
                          + "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')";



                strSql = string.Format(strSql, mdl.SEQID, mdl.SN, mdl.LN,mdl.PCID, mdl.DELIVER_STAUTS,
                                       mdl.CONTACT, mdl.USERNAME,
                                       mdl.FORWARDERDID, mdl.FORWARDERDID, 
                                       mdl.DIRECTION, mdl.DELIVER_DATE.ToString("yyyy-MM-dd HH:mm:ss"),
                                       mdl.SCAN_DATE.ToString("yyyy-MM-dd HH:mm:ss"),
                                       mdl.USERID,mdl.LOGINDATE.ToString("yyyy-MM-dd HH:mm:ss"),mdl.ADDRESS);

                result = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return result;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }

        }


        /// <summary>
        /// 更新装配信息
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdatDeliveryItem(DeliveryItemMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {



                strSql = "update tlb_delivery_list set  SN='{0}',LN='{1}',PCID='{2}',DELIVER_STATUS='{3}',CONTACT='{4}',USERNAME='{5}',"
                         + "FORWARDERID='{6}',FORWARDER='{7}',DIRECTION='{8}',DELIVER_DATE='{9}',SCAN_DATE='{10}',USERID='{11}',LOGINDATE='{12}'"
                         +" where SEQID='{13}'";

                strSql = string.Format(strSql, mdl.SN, mdl.LN, mdl.PCID, mdl.DELIVER_STAUTS,mdl.CONTACT,
                                               mdl.USERNAME,mdl.FORWARDERDID,mdl.FORWARDERDID,mdl.DIRECTION,
                                               mdl.DELIVER_DATE.ToString("yyyy-MM-dd HH:mm:ss"),
                                               mdl.SCAN_DATE.ToString("yyyy-MM-dd HH:mm:ss"),
                                               mdl.USERID,
                                               mdl.LOGINDATE.ToString("yyyy-MM-dd HH:mm:ss"), mdl.SEQID);

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
        /// 删除装配信息
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int DeleteDelivertInfo(DeliveryItemMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "delete from tlb_delivery_list where SEQID='{0}'";

                strSql = string.Format(strSql, mdl.SEQID);

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
        /// 获取装配记录
        /// </summary>
        /// <param name="strPCID"></param>
        /// <returns></returns>
        public DeliveryItemMDL GetDeliveryInfo(string seqid)
        {
            try
            {

                DataSet dataSet = null;

                DeliveryItemMDL mdl = new DeliveryItemMDL();

                string strSql = "select * from tlb_delivery_list where SEQID='{0}' ";

                strSql = string.Format(strSql, seqid);

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                //解析数据
                mdl = DeliveryItemMDL.Parse(dataSet.Tables[0].Rows[0]);

                return mdl;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }


        /// <summary>
        /// 获取装配信息
        /// </summary>
        /// <returns></returns>
        public List<AssemblageMDL> GetAssemblageRecords()
        {
            List<AssemblageMDL> lists = new List<AssemblageMDL>();


            try
            {
                DataSet dataSet = null;

                string strSql = "select * from tlb_delivery_list order by LOGINDATE asc";

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                //解析数据
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    AssemblageMDL mdl = new AssemblageMDL();
                    mdl = AssemblageMDL.Parse(item);
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
