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
    /// 产品装配信息
    /// </summary>
    public class AssemblageDAL
    {
        public AssemblageDAL()
        {
 
        }

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
                strSql = "select count(*) from tlb_assemblage_log where LOGID='{0}'";

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
        public int AssemblageIsExited(string assemblageID)
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "select count(*) from tlb_assemblage_log where LOGID={'0'}";

                string.Format(strSql, assemblageID);

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
        public int InsertAssemblageInfo(AssemblageMDL mdl)
        {
            int result = 0;

            string strSql = string.Empty;

            try
            {


                strSql = "insert  into  tlb_assemblage_log (LOGID,PCID,COMPANY,PRO_TIME,CONTACT,ARRIAL_TIME,PLINEID,START_SEQ,"
                          + "END_SEQ,PLINENAME,SUM,PRODUCTID,BAD,LOGIN_DATE)"
                          + "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')";



                strSql = string.Format(strSql, mdl.LOGID, mdl.PCID, mdl.COMPANY, mdl.PRO_TIME.ToString("yyyy-MM-dd HH:mm:ss"),
                                       mdl.CONTACT, mdl.ARRIAL_TIME.ToString("yyyy-MM-dd HH:mm:ss"),
                                       mdl.PLEND_ID, mdl.START_SEQ, mdl.END_SEQ,mdl.PLANE_NAME,mdl.SUM,mdl.PRODUCTID,
                                       mdl.BAD_NUM,mdl.LOGIN_DATE.ToString("yyyy-MM-dd HH:mm:ss"));

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
        public int UpdatAssemblageInfo(AssemblageMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "update tlb_assemblage_log set  PCID='{0}',COMPANY='{1}',PRO_TIME='{2}',CONTACT='{3}',ARRIAL_TIME='{4}',PLINEID='{5}',"
                         + "START_SEQ='{6}',END_SEQ='{7}',PLINENAME='{8}',SUM='{9}',PRODUCTID='{10}',BAD='{11}',LOGIN_DATE='{12}'"
                         + " where LOGID='{13}'";

                strSql = string.Format(strSql, mdl.PCID, mdl.COMPANY, mdl.PRO_TIME.ToString("yyyy-MM-dd HH:mm:ss"), mdl.CONTACT,
                                               mdl.ARRIAL_TIME.ToString("yyyy-MM-dd HH:mm:ss"),
                                               mdl.PLEND_ID,
                                               mdl.START_SEQ,
                                               mdl.END_SEQ, mdl.PLANE_NAME, mdl.SUM,
                                               mdl.PRODUCTID,
                                               mdl.BAD_NUM, mdl.LOGIN_DATE.ToString("yyyy-MM-dd HH:mm:ss"),mdl.LOGID);

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
        public int DeleteAssemblageInfo(AssemblageMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "delete from tlb_assemblage_log where LOGID=" + mdl.LOGID;

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
        public AssemblageMDL GetAssemblageInfo(string logid)
        {
            try
            {

                DataSet dataSet = null;

                AssemblageMDL mdl = new AssemblageMDL();

                string strSql = "select * from tlb_assemblage_log where LOGID='{0}' ";

                strSql = string.Format(strSql, logid);

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                //解析数据
                mdl = AssemblageMDL.Parse(dataSet.Tables[0].Rows[0]);

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

                string strSql = "select * from tlb_assemblage_log order by LOGIN_DATE asc";

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
