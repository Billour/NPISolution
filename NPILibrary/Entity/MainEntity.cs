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
    /// <summary>
    /// �D��Entity
    /// </summary>
    public class MainEntity:BaseEntity
    {
        private string _MainId;
        private string _MainName;
        private string _MainDesc;
        private string _WorkStatus;

        private string _CreateUser = "";
        private string _CreateTime = "";
        private string _UpdateUser = "";
        private string _UpdateTime = "";

        [Tables("NPI_Main", PageCommandType.InsertColumnMode, DBCommandType.InsertMode, "", null)]
        public MainEntity()
        { }

        /// <summary>
        /// �D��id
        /// </summary>
        [DataColumn("Main_Id")]
        [InsertColumn("NPI_Main", "Main_Id", Asus.Data.DataType.NVarChar)]
        public string MainId
        {
            set { _MainId = value; }
            get { return _MainId; }
        }

        [DataColumn("Main_Name")]
        [InsertColumn("NPI_Main", "Main_Name", Asus.Data.DataType.NVarChar)]
        public string MainName
        {
            set { _MainName = value; }
            get { return _MainName; }
        }

        [DataColumn("Main_Desc")]
        [InsertColumn("NPI_Main", "Main_Desc", Asus.Data.DataType.NVarChar)]
        public string MainDesc
        {
            set { _MainDesc = value; }
            get { return _MainDesc; }
        }

        [DataColumn("Work_Status")]
        [InsertColumn("NPI_Main", "Work_Status", Asus.Data.DataType.NVarChar)]
        public string WorkStatus
        {
            set { _WorkStatus = value; }
            get { return _WorkStatus; }
        }

        /// <summary>
        /// �s�W�H��
        /// </summary>
        [DataColumn("CREATE_USER")]
        [InsertColumn("NPI_Main", "CREATE_USER", Asus.Data.DataType.NVarChar)]
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }

        /// <summary>
        /// �s�W�ɶ�
        /// </summary>
        [DataColumn("Create_Time")]
        [InsertColumn("NPI_Main", "CREATE_DATE", Asus.Data.DataType.DateTime)]
        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }

        /// <summary>
        /// ��s�H��
        /// </summary>
        [DataColumn("UPDATE_USER")]
        [InsertColumn("NPI_Main", "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        public string UpdateUser
        {
            set { _UpdateUser = value; }
            get { return _UpdateUser; }
        }

        /// <summary>
        /// ��s�ɶ�
        /// </summary>
        [DataColumn("Update_Time")]
        [InsertColumn("NPI_Main", "UPDATE_DATE", Asus.Data.DataType.DateTime)]
        public string UpdateTime
        {
            set { _UpdateTime = value; }
            get { return _UpdateTime; }
        }
    }
}
