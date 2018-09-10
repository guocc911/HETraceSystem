using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MDL;
using COMM;



namespace DAL
{
    public class PrintLogDAL
    {


        public PrintLogDAL()
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
                strSql = "select count(*) from tlb_print_log ";

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
        /// 检查产品是否创建
        /// </summary>
        /// <param name="codekey"></param>
        /// <returns></returns>
        public int PrintRecordIsExited(string seqID)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_print_log where SEQID='{0}'";

                string.Format(strSql, seqID);

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
        /// 插入打印项
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertPrintItem(PrintLogMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {


                strSql = "insert  into  tlb_print_log (SEQID,SN,PRINT_TYPE,COUNT,PRINT_DATE,DEVICEID,USERID)"
                          + "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";

  
                strSql = string.Format(strSql, mdl.SEQID, mdl.SN, (int)mdl.PRINT_TYPE, mdl.COUNT, 
                                       mdl.PRINT_DATE.ToString("yyyy-MM-dd HH:mm:ss"), mdl.DEVICE_ID,
                                       mdl.USERID);

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
        /// 更新打印信息
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdatPrintLogInfo(PrintLogMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "update tlb_print_log set  SEQID='{0}',SN='{1}',PRINT_TYPE='{2}',COUNT='{3}',PRINT_DATE='{4}',DEVICEID='{5}',"
                         + "USERID='{6}'  where SEQID='{7}'";

                strSql = string.Format(strSql, mdl.SEQID, mdl.SN, mdl.PRINT_TYPE, mdl.COUNT,
                                               mdl.PRINT_DATE.ToString("yyyy-MM-dd HH:mm:ss"),
                                               mdl.DEVICE_ID,
                                               mdl.USERID,mdl.SEQID);

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
        /// 删除打印记录
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int DeletePrintLog(PrintLogMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "delete from tlb_print_log where PCID=" + mdl.SEQID;

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
        /// 获取打印日志
        /// </summary>
        /// <returns></returns>
        public List<PrintLogMDL> GetPrintLogRecords()
        {
            List<PrintLogMDL> lists = new List<PrintLogMDL>();

            try
            {
                DataSet dataSet = null;

                string strSql = "select * from tlb_print_log  order by PRINT_DATE asc";

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                //解析数据
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    PrintLogMDL mdl = new PrintLogMDL();
                    mdl = PrintLogMDL.Parse(item);
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


        /// <summary>
        /// 获取生成信息
        /// </summary>
        /// <returns></returns>
        public List<PrintLogMDL> GetPrintLogRecords(int start,int end)
        {
            List<PrintLogMDL> lists = new List<PrintLogMDL>();

            try
            {
                DataSet dataSet = null;

                string strSql = "select * from tlb_print_log  order by PRINT_DATE asc LIMIT {0},{1}";

                strSql = String.Format(strSql, start, end);

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                //解析数据
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    PrintLogMDL mdl = new PrintLogMDL();
                    mdl = PrintLogMDL.Parse(item);
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


        /// <summary>
        /// 获取创建记录
        /// </summary>
        /// <param name="strPCID"></param>
        /// <returns></returns>
        public PrintLogMDL GetPrintLogItem(string strSeq)
        {
            try
            {

                DataSet dataSet = null;

                PrintLogMDL mdl = new PrintLogMDL();

                string strSql = "select * from tlb_print_log where SEQID='{0}' ";

                strSql = string.Format(strSql, strSeq);

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                //解析数据
                mdl = PrintLogMDL.Parse(dataSet.Tables[0].Rows[0]);

                return mdl;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }
    }
}
