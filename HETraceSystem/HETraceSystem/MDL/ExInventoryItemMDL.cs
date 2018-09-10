using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMM;
namespace MDL
{

    /// <summary>
    /// 库存列表
    /// </summary>
    public class ExInventoryItemMDL
    {

        public string _sn;

        private string _name;

        private string _pn;

        private string _imei;

        private string _md5;

        private string _pcid;

        private string _cpcode;

        private string _vrcode;

        private string _prcode;

        private string _sbcode;

        private DateTime _regdate;

        private TboxModel _ptModel;

        private int _print_status;

        private int _deliver_status;

        #region  properities



       
        public string SN
        {
            get { return _sn; }
            set { _sn = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string PN
        {
            get { return _pn; }
            set { _pn = value; }
        }

        public string MD5
        {
            get { return _md5; }
            set { _md5 = value; }
        }


        /// <summary>
        /// 产品ID
        /// </summary>
        public string PCID
        {
            get { return this._cpcode + this._vrcode + this._prcode + this._sbcode; }
            set { _pcid = value; }
        }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string CPCode
        {
            get { return _cpcode; }
            set { _cpcode = value; }
        }


        public string IMEI
        {
            get { return _imei; }
            set { _imei = value; }
        }
        /// <summary>
        /// 版本号
        /// </summary>
        public string VRCode
        {
            get { return _vrcode; }
            set { _vrcode = value; }
        }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string PRCode
        {
            get { return _prcode; }
            set { _prcode = value; }
        }

        /// <summary>
        /// 子版本编号
        /// </summary>
        public string SBCode
        {
            get { return _sbcode; }
            set { _sbcode = value; }
        }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime REGDATE
        {
            get { return _regdate; }
            set { _regdate = value; }
        }


        /// <summary>
        /// 打印状态
        /// </summary>
        public int PRINT_STATUS
        {
            get { return _print_status; }
            set { _print_status = value; }
        }

        /// <summary>
        /// 发货状态
        /// </summary>
        public int DELIVER_STATUS
        {
            get { return _deliver_status; }
            set { _deliver_status = value; }
        }


        public TboxModel MODEL
        {
            get { return _ptModel; }
            set { _ptModel = value; }
        }


        public static ExInventoryItemMDL Parse(DataRow item)
        {
            try
            {
                if (item == null)
                    return null;

                ExInventoryItemMDL mdl = new ExInventoryItemMDL();

                mdl.SN = Convert.ToString(item["SN"]);
                mdl.Name = Convert.ToString(item["NAME"]);
                mdl.MD5 = Convert.ToString(item["MD5"]);
                mdl.PN = Convert.ToString(item["PN"]);
                mdl.PCID = Convert.ToString(item["PCID"]);
                mdl.IMEI = Convert.ToString(item["IMEI"]);
                mdl.CPCode = Convert.ToString(item["CP_CODE"]);
                mdl.VRCode = Convert.ToString(item["VR_CODE"]);
                mdl.PRCode = Convert.ToString(item["PR_CODE"]);
                mdl.SBCode = Convert.ToString(item["SB_CODE"]);
                mdl.REGDATE = Convert.ToDateTime(item["REG_DATE"]);
                mdl.PRINT_STATUS = Convert.ToInt32(item["PRINT_STATUS"]);
                mdl.DELIVER_STATUS = Convert.ToInt32(item["DELIVER_STATUS"]);
                mdl.MODEL =(TboxModel) Convert.ToInt32(item["MODEL"]);


                return mdl;
            }
            catch
            {

                throw;
            }
        }
        #endregion

    }
}
