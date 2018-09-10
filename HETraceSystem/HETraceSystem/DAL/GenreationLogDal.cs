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
    /// 创建日志DAL
    /// </summary>
    public class GenreationLogDAL
    {
        public GenreationLogDAL()
        {

        }

        /// <summary>
        /// 获取生成记录
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_genreation_log";

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
        public int GenreationIsExited(string seqID)
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_genreation_log where SEQID='{0}'";

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
        /// 插入配置信息
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int InsertGenreationLog(GenreationLogMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {


                strSql = "insert  into  tlb_genreation_log (SEQID,PCID,CP_CODE,VR_CODE,PR_CODE,SB_CODE,START_NUM,END_NUM,STATUS,"
                          + "LOGIN_DATE)"
                          + "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')";



                strSql = string.Format(strSql, mdl.SEQID, mdl.PCID,mdl.CPCODE, mdl.VRCODE, mdl.PRCODE,
                                       mdl.SBCODE, mdl.START_NUM,
                                       mdl.END_NUM, mdl.STAUTS, mdl.LOGIN_DATE.ToString("yyyy-MM-dd HH:mm:ss"));

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
        /// 更新创建信息
        /// </summary>
        /// <param name="mdl"></param>
        /// <returns></returns>
        public int UpdattGenreationLog(GenreationLogMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "update tlb_genreation_log set SEQID='{0}',PCID='{1}',CP_CODE='{2}',VR_CODE='{3}',PR_CODE='{4}',SB_CODE='{5}',START_NUM='{6}',"
                         + "END_NUM='{7}',STATUS='{8}',LOGIN_DATE='{9}'";

                strSql = string.Format(strSql, mdl.SEQID,mdl.PCID, mdl.CPCODE, 
                                               mdl.VRCODE,mdl.PRCODE,
                                               mdl.SBCODE,
                                               mdl.START_NUM,
                                               mdl.END_NUM,
                                               mdl.STAUTS,
                                               mdl.LOGIN_DATE.ToString("yyyy-MM-dd HH:mm:ss"));

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
        /// 获取生成信息
        /// </summary>
        /// <returns></returns>
        public List<GenreationLogMDL> GetGenreationLogRecords()
        {
            List<GenreationLogMDL> lists = new List<GenreationLogMDL>();

            try
            {
                DataSet dataSet = null;

                string strSql = "select * from tlb_genreation_log  order by LOGIN_DATE asc";

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                //解析数据
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    GenreationLogMDL mdl = new GenreationLogMDL();
                    mdl = GenreationLogMDL.Parse(item);
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
        public GenreationLogMDL GetGenreationLogItem(string strPCID)
        {
            try
            {

                DataSet dataSet = null;

                GenreationLogMDL mdl = new GenreationLogMDL();

                string strSql = "select * from tlb_genreation_log where SEQID='{0}' ";

                strSql = string.Format(strSql, strPCID);

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                //解析数据
                mdl = GenreationLogMDL.Parse(dataSet.Tables[0].Rows[0]);

                return mdl;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }


        /// <summary>
        /// 获取创建产品记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetGenreationRecords()
        {

            try
            {
                DataSet dataSet = null;

                string strSql = "select gl.SEQID,gl.PCID,gl.START_NUM,gl.END_NUM,gl.STATUS,p.NAME,p.PILE_TYPE,p.PORT_NUM,p.CHARGE_POWER"
                                  + " from tlb_genreation_log gl,tlb_product p WHERE  gl.PCID=p.PCID order by LOGIN_DATE asc ";


                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }


        /// <summary>
        /// 获取创建产品记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetGenreationRecords(int startOffset, int endOffset)
        {
          
            try
            {
                DataSet dataSet = null;

                string strSql = "select gl.SEQID,gl.PCID,gl.START_NUM,gl.END_NUM,gl.STATUS,p.NAME,p.PILE_TYPE,p.PORT_NUM,p.CHARGE_POWER"
                                  + " from tlb_genreation_log gl,tlb_product p WHERE  gl.PCID=p.PCID order by LOGIN_DATE asc limit {0},{1}";

                strSql = string.Format(strSql, startOffset, endOffset);

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return null;
            }
        }
    }


}
