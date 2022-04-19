using System;
using System.Collections.Generic;
using System.Text;

using Asus.Bussiness.Attribute;
using Asus.Bussiness.Map;

namespace AsusLibrary.Entity
{
    /// <summary>
    /// 此Entity 是針對
    /// Sourcer PN 的Map 對應檔
    /// </summary>
    public class SourcerPNMapEntity:BaseEntity
    {
        
        private string _UserId;
        private string _CompanyId;
        private string _PN;
        private string _CreateUser = "System";
        private string _CreateTime = DateTime.Now.ToString();
        private string _UpdateUser="System";
        private string _UpdateTime=DateTime.Now.ToString();

        private bool _IsAlert=false;

        [Tables("NPI_SOURCERPN_MAP", PageCommandType.InsertColumnMode, DBCommandType.InsertMode, "", null)]
        [Tables("NPI_SOURCERPN_MAP", PageCommandType.UpdateColumnMode, DBCommandType.UpdateMode, " where asus_pn='{0}'", new string[] { "PN" })]
        public SourcerPNMapEntity()
        { }

        /// <summary>
        /// 員工工號
        /// </summary>
        [DataColumn("USER_ID")]
        [InsertColumn("NPI_SOURCERPN_MAP", "USER_ID", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("NPI_SOURCERPN_MAP", "USER_ID", Asus.Data.DataType.NVarChar)]
        public string UserId
        {
            set { _UserId = value; }
            get { return _UserId; }
        }

        /// <summary>
        /// 公司代號
        /// 目前只支援13006
        /// </summary>
        [DataColumn("COMPANY_ID")]
        [InsertColumn("NPI_SOURCERPN_MAP", "COMPANY_ID", Asus.Data.DataType.NVarChar)]
        public string CompanyId
        {
            set { _CompanyId = value; }
            get { return _CompanyId; }
        }

        /// <summary>
        /// 料號
        /// </summary>
        [DataColumn("ASUS_PN")]
        [InsertColumn("NPI_SOURCERPN_MAP", "ASUS_PN", Asus.Data.DataType.NVarChar)]
        public string PN
        {
            set { _PN = value; }
            get { return _PN; }
        }

        /// <summary>
        /// 是否要通知
        /// </summary>
        public bool IsAlert
        {
            set { _IsAlert = value; }
            get { return _IsAlert; }
        }

        /// <summary>
        /// 新增人員
        /// </summary>
        [DataColumn("CREATE_USER")]
        [InsertColumn("NPI_SOURCERPN_MAP", "CREATE_USER", Asus.Data.DataType.NVarChar)]
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }

        /// <summary>
        /// 建立時間
        /// </summary>
        [DataColumn("CREATE_TIME")]
        [InsertColumn("NPI_SOURCERPN_MAP", "CREATE_TIME", Asus.Data.DataType.DateTime)]
        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }

        /// <summary>
        /// 更新人員
        /// </summary>
        [DataColumn("UPDATE_USER")]
        [InsertColumn("NPI_SOURCERPN_MAP", "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("NPI_SOURCERPN_MAP", "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        public string UpdateUser
        {
            set { _UpdateUser = value; }
            get { return _UpdateUser; }
        }

        /// <summary>
        /// 更新時間
        /// </summary>
        [DataColumn("UPDATE_TIME")]
        [InsertColumn("NPI_SOURCERPN_MAP", "UPDATE_TIME", Asus.Data.DataType.DateTime)]
        [UpdateColumn("NPI_SOURCERPN_MAP", "UPDATE_TIME", Asus.Data.DataType.DateTime)]
        public string UpdateTime
        {
            set { _UpdateTime = value; }
            get { return _UpdateTime; }
        }

    }
}
