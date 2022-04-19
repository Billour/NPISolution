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
    public class GenMainEntity:BaseEntity
    {
        private string _MainId;
        private string _MainName;
        private string _MainDesc;
        private string _WorkStatus="Y";

        private string _CreateUser = "";
        private string _CreateTime = "";
        private string _UpdateUser = "";
        private string _UpdateTime = "";

        [Tables("caerdsa.NPI_Main", PageCommandType.InsertColumnMode, DBCommandType.InsertMode, "", null)]
        [Tables("caerdsa.NPI_Main", PageCommandType.UpdateColumnMode, DBCommandType.UpdateMode, " where Main_Id='{0}' ", new string[] { "MainId" })]
        public GenMainEntity()
        { }

        [DataColumn("Main_Id")]
        [InsertColumn("caerdsa.NPI_Main", "Main_Id", Asus.Data.DataType.NVarChar)]
        public string MainId
        {
            set { _MainId = value; }
            get { return _MainId; }
        }

        [DataColumn("Main_Name")]
        [InsertColumn("caerdsa.NPI_Main", "Main_Name", Asus.Data.DataType.NVarChar)]
        public string MainName
        {
            set { _MainName = value; }
            get { return _MainName; }
        }

        [DataColumn("Main_Desc")]
        [InsertColumn("caerdsa.NPI_Main", "Main_Desc", Asus.Data.DataType.NVarChar)]
        public string MainDesc
        {
            set { _MainDesc = value; }
            get { return _MainDesc; }
        }

        [DataColumn("Work_Status")]
        [InsertColumn("caerdsa.NPI_Main", "Work_Status", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("caerdsa.NPI_Main", "Work_Status", Asus.Data.DataType.NVarChar)]
        public string WorkStatus
        {
            set { _WorkStatus = value; }
            get { return _WorkStatus; }
        }

        /// <summary>
        /// 新增人員
        /// </summary>
        [DataColumn("CREATE_USER")]
        [InsertColumn("caerdsa.NPI_Main", "CREATE_USER", Asus.Data.DataType.NVarChar)]
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }

        /// <summary>
        /// 新增時間
        /// </summary>
        [DataColumn("CREATE_Time")]
        [InsertColumn("caerdsa.NPI_Main", "CREATE_Time", Asus.Data.DataType.DateTime)]
        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }

        /// <summary>
        /// 更新人員
        /// </summary>
        [DataColumn("UPDATE_USER")]
        [InsertColumn("caerdsa.NPI_Main", "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("caerdsa.NPI_Main", "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        public string UpdateUser
        {
            set { _UpdateUser = value; }
            get { return _UpdateUser; }
        }

        /// <summary>
        /// 更新時間
        /// </summary>
        [DataColumn("UPDATE_Time")]
        [InsertColumn("caerdsa.NPI_Main", "UPDATE_Time", Asus.Data.DataType.DateTime)]
        [UpdateColumn("caerdsa.NPI_Main", "UPDATE_Time", Asus.Data.DataType.DateTime)]
        public string UpdateTime
        {
            set { _UpdateTime = value; }
            get { return _UpdateTime; }
        }
    }
}
