using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MDL;
using COMM;

namespace DAL
{
    public class ExInventoryItemDAL
    {

        public ExInventoryItemDAL()
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
                strSql = "select count(*) from tlb_exinventory_list";

                ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

                return ret;
            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }
        }

        //public string GetNewPNCode()
        //{
        //    try
        //    {
        //        int count = GetCount();


        //    }
        //    catch
        //    {
        //        throw;
        //    }

        //}


        public int GetCount(string cpid)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_exinventory_list where PCID='{0}'";

                strSql = String.Format(strSql, cpid);

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
        public int SNIsExited(string seqID)
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_exinventory_list where SN='{0}'";

                strSql=string.Format(strSql, seqID);

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

        public int IMEIExsited(string imei)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {
                strSql = "select count(*) from tlb_exinventory_list where IMEI='{0}'";

                strSql = string.Format(strSql, imei);

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

        public int ProductIsDelivery(string strSN)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "select count(*) from tlb_exinventory_list where SN='{0}' and DELIVER_STATUS=0";

                strSql = string.Format(strSql, strSN);

                ret = Convert.ToInt32(MySqlDBHelper.ExecuteScalar(MySqlDBHelper.Conn, CommandType.Text, strSql, null));

                if (ret > 0)
                    return 0;
                else
                    return 1;
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
        public int InsertExInventoryItem(ExInventoryItemMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {


                strSql = "insert  into  tlb_exinventory_list (SN,NAME,MD5,PCID,IMEI,CP_CODE,VR_CODE,PR_CODE,SB_CODE,REG_DATE,PRINT_STATUS,DELIVER_STATUS,MODEL,PN)"
                          + "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},{12},'{13}')";



                strSql = string.Format(strSql, mdl.SN, mdl.Name,mdl.MD5,mdl.PCID, mdl.IMEI,mdl.CPCode, mdl.VRCode,
                                       mdl.PRCode, mdl.SBCode,
                                       mdl.REGDATE.ToString("yyyy-MM-dd HH:mm:ss"),
                                       mdl.PRINT_STATUS, mdl.DELIVER_STATUS, (int)mdl.MODEL,mdl.PN);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }

        }




        public int UpdateDeliverStatus(string sn,int status)
        {

            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "update tlb_exinventory_list set DELIVER_STATUS={0}  where SN='{1}' ";

                strSql = string.Format(strSql,status, sn);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }


        }


        public int UpdateInventoryPileType(string cpid,int pileModel)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "update tlb_exinventory_list set MODEL={0} where PCID='{1}' ";

                strSql = string.Format(strSql, pileModel, cpid);

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
        public int UpdateInventoryItem(ExInventoryItemMDL mdl)
        {
            int ret = 0;

            string strSql = string.Empty;

            try
            {

                strSql = "update tlb_exinventory_list set NAME='{0}',MD5='{1}',PCID='{2}',IMEI='{3}',CP_CODE='{4}',VR_CODE='{5}',PR_CODE='{6}',SB_CODE='{7}',REG_DATE='{8}',"
                         + "PRINT_STATUS='{9}',DELIVER_STATUS='{10}',MODEL={11},PN='{12}' where SN='{13}' ";

                strSql = string.Format(strSql, mdl.Name,mdl.MD5,mdl.PCID, mdl.IMEI,
                                               mdl.CPCode,mdl.VRCode,
                                               mdl.PRCode,
                                               mdl.SBCode,
                                               mdl.REGDATE.ToString("yyyy-MM-dd HH:mm:ss"),
                                               mdl.PRINT_STATUS,
                                               mdl.DELIVER_STATUS, (int)mdl.MODEL,mdl.PN, mdl.SN);

                ret = MySqlDBHelper.ExecuteNonQuery(MySqlDBHelper.Conn, CommandType.Text, strSql, null);

                return ret;

            }
            catch (Exception ex)
            {
                CLog.WriteErrLogInTrace(ex.Message);
                return 0;
            }
        }



        ///// <summary>
        ///// 获取生成信息
        ///// </summary>
        ///// <returns></returns>
        //public List<InventoryItemMDL> GetInventoryRecords()
        //{
        //    List<InventoryItemMDL> lists = new List<InventoryItemMDL>();

        //    try
        //    {
        //        DataSet dataSet = null;

        //        string strSql = "select * from tlb_inventory_list  order by LOGIN_DATE asc";

        //        dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

        //        if (dataSet == null)
        //            return null;

        //        //解析数据
        //        foreach (DataRow item in dataSet.Tables[0].Rows)
        //        {
        //            InventoryItemMDL mdl = new InventoryItemMDL();
        //            mdl = InventoryItemMDL.Parse(item);
        //            lists.Add(mdl);
        //        }

        //        return lists;
        //    }
        //    catch (Exception ex)
        //    {
        //        CLog.WriteErrLogInTrace(ex.Message);
        //        return null;
        //    }
        //}


        /// <summary>
        /// 获取创建记录
        /// </summary>
        /// <param name="strPCID"></param>
        /// <returns></returns>
        public ExInventoryItemMDL GetInventoryItem(string sn)
        {
            try
            {

                DataSet dataSet = null;

                ExInventoryItemMDL mdl = new ExInventoryItemMDL();

                string strSql = "select * from tlb_exinventory_list where SN='{0}' ";

                strSql = string.Format(strSql, sn);

                dataSet = MySqlDBHelper.ExecuteDataSet(MySqlDBHelper.Conn, CommandType.Text, strSql);

                if (dataSet == null)
                    return null;

                //解析数据
                mdl = ExInventoryItemMDL.Parse(dataSet.Tables[0].Rows[0]);

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
        public DataTable GetInventoryRecords()
        {

            try
            {
                DataSet dataSet = null;

                string strSql = "select tl.SN,tl.NAME,tl.PCID,tl.REG_DATE,tl.PRINT_STATUS,tl.DELIVER_STATUS,p.MODEL "
                                  + " from tlb_exinventory_list tl,tlb_product p WHERE  tl.PCID=p.PCID order by REG_DATE asc ";


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
        public DataTable GetInventoryRecordPage(int startOffset, int endOffset)
        {
          
            try
            {
                DataSet dataSet = null;

                string strSql = "select tl.SN,tl.NAME,tl.PCID,tl.REG_DATE,tl.PRINT_STATUS,tl.DELIVER_STATUS,p.MODEL "
                                  + " from tlb_exinventory_list tl,tlb_product p WHERE  tl.PCID=p.PCID order by REG_DATE asc limit {0},{1}";

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


        /// <summary>
        /// 获取创建产品记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetInventoryRecordPage(int startOffset, int endOffset,string cpid)
        {

            try
            {
                DataSet dataSet = null;

                string strSql = "select tl.SN,p.NAME,tl.PCID,tl.REG_DATE,tl.PRINT_STATUS,tl.DELIVER_STATUS,tl.IMEI,tl.MODEL "
                                  + " from tlb_exinventory_list tl,tlb_product p WHERE  tl.PCID=p.PCID and tl.PCID='{0}'  order by SN asc limit {1},{2}";

                strSql = string.Format(strSql, cpid,startOffset, endOffset);

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
