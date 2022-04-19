using System;
using System.Collections.Generic;
using System.Text;

using Asus;
using Asus.Bussiness.Attribute;
using Asus.Bussiness.Map;
using System.Web.UI.WebControls;
using AsusLibrary.Logic;

namespace AsusLibrary.Entity
{
    public class GenPNEntity:BaseEntity
    {
        

        private string _MainId;
        private string _PN;
        private string _PNName;
        private string _PNDesc;

        //組件料號 是否為替代料
        private string _AssemblyNo;
        private string _IsSub;

        private string _LTWeeks;
        private string _Alert="N";
        

        private string _RiskBuy="*";
        
       
        private string _PNProperty="0";
        private string _AddSource="0";
        private string _AddSourceComment;
        private string _EOL;

        private string _PNPropertyName = "";
        private string _AddSourceName = "";
        private string _ActionDate="";

        private string _CreateUser = "";
        private string _CreateTime = "";
        private string _UpdateUser = "";
        private string _UpdateTime = "";

        /// <summary>
        /// 最重要的 Model
        /// </summary>
        [Tables("caerdsa.NPI_Main_PN", PageCommandType.InsertColumnMode, DBCommandType.InsertMode, "", null)]
        [Tables("caerdsa.NPI_Main_PN", PageCommandType.UpdateColumnMode, DBCommandType.UpdateMode, " where Main_Id='{0}' and asus_pn='{1}'", new string[] { "MainId", "PN" })]
        public GenPNEntity()
        { }

        /// <summary>
        /// Main代號
        /// </summary>
        [DataColumn("Main_Id")]
        [InsertColumn("caerdsa.NPI_Main_PN", "Main_Id", Asus.Data.DataType.NVarChar)]
        public string MainId
        {
            set { _MainId = value; }
            get { return _MainId; }
        }

        /// <summary>
        /// 元件料號
        /// </summary>
        [DataColumn("ASUS_PN")]
        [InsertColumn("caerdsa.NPI_Main_PN", "ASUS_PN", Asus.Data.DataType.NVarChar)]
        public string PN
        {
            set { _PN = value; }
            get { return _PN; }
        }

        /// <summary>
        /// 品名
        /// </summary>
        [DataColumn("PART_DESC1")]
        [InsertColumn("caerdsa.NPI_Main_PN", "PART_DESC1", Asus.Data.DataType.NVarChar)]
        public string PNName
        {
            set { _PNName = value; }
            get { return _PNName; }
        }

        /// <summary>
        /// 規格
        /// </summary>
        [DataColumn("PART_DESC2")]
        [InsertColumn("caerdsa.NPI_Main_PN", "PART_DESC2", Asus.Data.DataType.NVarChar)]
        public string PNDesc
        {
            set { _PNDesc = value; }
            get { return _PNDesc; }
        }

        /// <summary>
        /// 組件號
        /// </summary>
        [DataColumn("ASSEMBLY_NO")]
        [InsertColumn("caerdsa.NPI_Main_PN", "ASSEMBLY_NO", Asus.Data.DataType.NVarChar)]
        public string AssemblyNo
        {
            set { _AssemblyNo = value; }
            get { return _AssemblyNo; }
        }


        /// <summary>
        /// 主要料或替代料(N=主料/S=替代料)
        /// </summary>
        [DataColumn("ASSEMBLY_TYPE")]
        [InsertColumn("caerdsa.NPI_Main_PN", "ASSEMBLY_TYPE", Asus.Data.DataType.NVarChar)]
        public string IsSub
        {
            set { _IsSub = value; }
            get { return _IsSub; }
        }

        [DataColumn("ALERT")]
        [InsertColumn("caerdsa.NPI_Main_PN", "ALERT", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("caerdsa.NPI_Main_PN", "ALERT", Asus.Data.DataType.NVarChar)]
        public string Alert
        {
            set { _Alert = value; }
            get { return _Alert; }
        }

        /// <summary>
        /// RiskBuy
        /// </summary>
        [DataColumn("RISKBUY")]
        [InsertColumn("caerdsa.NPI_Main_PN", "RISKBUY", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("caerdsa.NPI_Main_PN", "RISKBUY", Asus.Data.DataType.NVarChar)]
        public string RiskBuy
        {
            set { _RiskBuy = value; }
            get { return _RiskBuy; }
        }

        

        /// <summary>
        /// LT Time
        /// </summary>
        [DataColumn("LONGTERM_WEEK")]
        [UpdateColumn("caerdsa.NPI_Main_PN", "LONGTERM_WEEK", Asus.Data.DataType.NVarChar)]
        public string LTWeeks
        {
            set { _LTWeeks = value; }
            get { return _LTWeeks; }
        }

       
        /// <summary>
        /// 料號屬性
        /// </summary>
        [DataColumn("PN_PROPERTY")]
        [InsertColumn("caerdsa.NPI_Main_PN", "PN_PROPERTY", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("caerdsa.NPI_Main_PN", "PN_PROPERTY", Asus.Data.DataType.NVarChar)]
        public string PNProperty
        {
            set { _PNProperty = value; }
            get { return _PNProperty; }
        }

        
        /// <summary>
        /// 加入第二來源
        /// </summary>
        [DataColumn("ADD2_SOURCE")]
        [InsertColumn("caerdsa.NPI_Main_PN", "ADD2_SOURCE", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("caerdsa.NPI_Main_PN", "ADD2_SOURCE", Asus.Data.DataType.NVarChar)]
        public string AddSource
        {
            set { _AddSource = value; }
            get { return _AddSource; }
        }

        /// <summary>
        /// 加入第二來源備註
        /// </summary>
        [DataColumn("ADD2_SOURCE_COMMENT")]
        [UpdateColumn("caerdsa.NPI_Main_PN", "ADD2_SOURCE_COMMENT", Asus.Data.DataType.NVarChar)]
        public string AddSourceComment
        {
            set { _AddSourceComment = value; }
            get { return _AddSourceComment; }
        }

        /// <summary>
        /// EOL備註
        /// </summary>
        [DataColumn("EOL_COMMENT")]
        [UpdateColumn("caerdsa.NPI_Main_PN", "EOL_COMMENT", Asus.Data.DataType.NVarChar)]
        public string EOL
        {
            set { _EOL = value; }
            get { return _EOL; }
        }

        [DataColumn("ACTION_DATE")]
        [UpdateColumn("caerdsa.NPI_Main_PN", "ACTION_DATE", Asus.Data.DataType.NVarChar)]
        public string ActionDate
        {
            set { _ActionDate = value; }
            get { return _ActionDate; }
        }

        /// <summary>
        /// 新增人員
        /// </summary>
        [DataColumn("CREATE_USER")]
        [InsertColumn("caerdsa.NPI_Main_PN", "CREATE_USER", Asus.Data.DataType.NVarChar)]
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }

        /// <summary>
        /// 新增時間
        /// </summary>
        [DataColumn("CREATE_DATE")]
        [InsertColumn("caerdsa.NPI_Main_PN", "CREATE_DATE", Asus.Data.DataType.DateTime)]
        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }

        /// <summary>
        /// 更新人員
        /// </summary>
        [DataColumn("UPDATE_USER")]
        [InsertColumn("caerdsa.NPI_Main_PN", "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("caerdsa.NPI_Main_PN", "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        public string UpdateUser
        {
            set { _UpdateUser = value; }
            get { return _UpdateUser; }
        }

        /// <summary>
        /// 更新時間
        /// </summary>
        [DataColumn("UPDATE_DATE")]
        [InsertColumn("caerdsa.NPI_Main_PN", "UPDATE_DATE", Asus.Data.DataType.DateTime)]
        [UpdateColumn("caerdsa.NPI_Main_PN", "UPDATE_DATE", Asus.Data.DataType.DateTime)]
        public string UpdateTime
        {
            set { _UpdateTime = value; }
            get { return _UpdateTime; }
        }
    }
}
