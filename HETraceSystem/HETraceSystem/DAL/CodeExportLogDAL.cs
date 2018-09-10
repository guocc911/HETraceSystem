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
    /// 编码导出日志
    /// </summary>
    public class CodeExportLogDAL
    {

        public CodeExportLogDAL()
        { 
        }
        /// <summary>
        /// 获取类型数量
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_codeexport_log";

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
        public int ExportLogIsExited(string seqID)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_codeexport_log where SEQID='{0}' ";

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
        public int InsertExportLogItem(CodeExportLogMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {


                strSql = "insert  into  tlb_codeexport_log (SEQID,SN,DIR,USERID,WIDTH,HEIGHT,PRINT_DATE)"
                          + "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";


                strSql = string.Format(strSql, mdl.SEQID, mdl.SN, mdl.DIR, mdl.USERID,
                                       mdl.WIDTH, mdl.HEIGHT,
                                       mdl.PRINT_DATE.ToString("yyyy-MM-dd HH:mm:ss"));

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
        public int UpdatPrintLogInfo(CodeExportLogMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "update tlb_codeexport_log set  SN='{0}',DIR='{1}',USERID='{2}',WIDTH='{3}',HEIGHT='{4}'"
                         + "PRINT_DATE='{5}'  where SEQID='{6}'";

                strSql = string.Format(strSql, mdl.SN, mdl.DIR, mdl.USERID, mdl.WIDTH,
                                               mdl.HEIGHT,
                                               mdl.PRINT_DATE.ToString("yyyy-MM-dd HH:mm:ss"),
                                               mdl.SEQID);

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
        public int DeleteCodeExportLog(CodeExportLogMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "delete from tlb_codeexport_log where SEQID=" + mdl.SEQID;

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
        public List<CodeExportLogMDL> GetCodeExportLogRecords()
        {
            List<CodeExportLogMDL> lists = new List<CodeExportLogMDL>();

            try
            {
                DataSet dataSet = null;

                string strSql = "select * from  tlb_codeexport_log  order by PRINT_DATE asc";

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                //解析数据
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    CodeExportLogMDL mdl = new CodeExportLogMDL();
                    mdl = CodeExportLogMDL.Parse(item);
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
        public List<CodeExportLogMDL> GetCodeExportLogRecords(int start, int end)
        {
            List<CodeExportLogMDL> lists = new List<CodeExportLogMDL>();

            try
            {
                DataSet dataSet = null;

                string strSql = "select * from  tlb_codeexport_log order by PRINT_DATE asc LIMIT {0},{1}";

                strSql = String.Format(strSql, start, end);

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                //解析数据
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    CodeExportLogMDL mdl = new CodeExportLogMDL();
                    mdl = CodeExportLogMDL.Parse(item);
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
        public CodeExportLogMDL GetCodeExportLogItem(string strSeq)
        {
            try
            {

                DataSet dataSet = null;

                CodeExportLogMDL mdl = new CodeExportLogMDL();

                string strSql = "select * from tlb_codeexport_log where SEQID='{0}' ";

                strSql = string.Format(strSql, strSeq);

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                //解析数据
                mdl = CodeExportLogMDL.Parse(dataSet.Tables[0].Rows[0]);

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
