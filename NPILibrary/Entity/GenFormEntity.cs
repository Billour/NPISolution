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
    public class GenFormEntity:BaseEntity
    {
        private string _MainId;
        private string _FormId;
        private string _WorkStatus="Y";

        private string _CreateUser = "";
        private string _CreateTime = "";
        private string _UpdateUser = "";
        private string _UpdateTime = "";

        [Tables("caerdsa.NPI_Main_Map", PageCommandType.InsertColumnMode, DBCommandType.InsertMode, "", null)]
        [Tables("caerdsa.NPI_Main_Map", PageCommandType.UpdateColumnMode, DBCommandType.UpdateMode, " where Main_Id='{0}' and FORM_ID='{1}' ", new string[] { "MainId" })]
        public GenFormEntity()
        { }

        [DataColumn("Main_Id")]
        [InsertColumn("caerdsa.NPI_Main_Map", "Main_Id", Asus.Data.DataType.NVarChar)]
        public string MainId
        {
            set { _MainId = value; }
            get { return _MainId; }
        }

        [DataColumn("FORM_ID")]
        [InsertColumn("caerdsa.NPI_Main_Map", "FORM_ID", Asus.Data.DataType.NVarChar)]
        public string FormId
        {
            set { _FormId = value; }
            get { return _FormId; }
        }

       

        [DataColumn("Work_Status")]
        [InsertColumn("caerdsa.NPI_Main_Map", "Work_Status", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("caerdsa.NPI_Main_Map", "Work_Status", Asus.Data.DataType.NVarChar)]
        public string WorkStatus
        {
            set { _WorkStatus = value; }
            get { return _WorkStatus; }
        }

        /// <summary>
        /// 新增人員
        /// </summary>
        [DataColumn("CREATE_USER")]
        [InsertColumn("caerdsa.NPI_Main_Map", "CREATE_USER", Asus.Data.DataType.NVarChar)]
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }

        /// <summary>
        /// 新增時間
        /// </summary>
        [DataColumn("CREATE_Time")]
        [InsertColumn("caerdsa.NPI_Main_Map", "CREATE_Time", Asus.Data.DataType.DateTime)]
        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }

        /// <summary>
        /// 更新人員
        /// </summary>
        [DataColumn("UPDATE_USER")]
        [InsertColumn("caerdsa.NPI_Main_Map", "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("caerdsa.NPI_Main_Map", "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        public string UpdateUser
        {
            set { _UpdateUser = value; }
            get { return _UpdateUser; }
        }

        /// <summary>
        /// 更新時間
        /// </summary>
        [DataColumn("UPDATE_Time")]
        [InsertColumn("caerdsa.NPI_Main_Map", "UPDATE_Time", Asus.Data.DataType.DateTime)]
        [UpdateColumn("caerdsa.NPI_Main_Map", "UPDATE_Time", Asus.Data.DataType.DateTime)]
        public string UpdateTime
        {
            set { _UpdateTime = value; }
            get { return _UpdateTime; }
        }
    }
}
