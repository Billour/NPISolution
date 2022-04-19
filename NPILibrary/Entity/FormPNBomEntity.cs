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
    /// 為BOM與PN的關係
    /// </summary>
    public class FormPNBomEntity:BaseEntity
    {
        /// <summary>
        /// Table:NPI_BOM_PN
        /// </summary>
        public const string TABLE_NPI_BOM_PN = "NPI_BOM_PN";

        private string _FormId;
        private string _WorkNo;
        private string _BomId;
        private string _PN;
        private string _Qty;

        private string _AssemblyNo = "";
        private string _AssemblyType = "";

        private string _CreateUser = "";
        private string _CreateTime = "";
        private string _UpdateUser = "";
        private string _UpdateTime = "";

        [Tables(FormPNBomEntity.TABLE_NPI_BOM_PN, PageCommandType.InsertColumnMode, DBCommandType.InsertMode, "", null)]
        public FormPNBomEntity()
        {}

        

        /// <summary>
        /// Form Id
        /// </summary>
        [DataColumn("FORM_ID")]
        [InsertColumn(FormPNBomEntity.TABLE_NPI_BOM_PN, "FORM_ID", Asus.Data.DataType.NVarChar)]
        public string FormId
        {
            set { _FormId = value; }
            get { return _FormId; }
        }

        /// <summary>
        /// Work No
        /// </summary>
        [DataColumn("WORK_NO")]
        [InsertColumn(FormPNBomEntity.TABLE_NPI_BOM_PN, "WORK_NO", Asus.Data.DataType.NVarChar)]
        public string WorkNo
        {
            set { _WorkNo = value; }
            get { return _WorkNo; }
        }

        /// <summary>
        /// BomId
        /// </summary>
        [DataColumn("ASUS_BOM")]
        [InsertColumn(FormPNBomEntity.TABLE_NPI_BOM_PN, "ASUS_BOM", Asus.Data.DataType.NVarChar)]
        public string BomId
        {
            set { _BomId = value; }
            get { return _BomId; }
        }

        /// <summary>
        /// PN
        /// </summary>
        [DataColumn("ASUS_PN")]
        [InsertColumn(FormPNBomEntity.TABLE_NPI_BOM_PN, "ASUS_PN", Asus.Data.DataType.NVarChar)]
        public string PN
        {
            set { _PN = value; }
            get { return _PN; }
        }

        /// <summary>
        /// 組合用量
        /// </summary>
        [DataColumn("ASMBLY_QTY")]
        [InsertColumn(FormPNBomEntity.TABLE_NPI_BOM_PN, "ASMBLY_QTY", Asus.Data.DataType.NVarChar)]
        public string Qty
        {
            set { _Qty = value; }
            get { return _Qty; }
        }

        [DataColumn("ASSEMBLY_NO")]
        [InsertColumn(FormPNBomEntity.TABLE_NPI_BOM_PN, "ASSEMBLY_NO", Asus.Data.DataType.NVarChar)]
        public string AssemblyNo
        {
            set{_AssemblyNo=value;}
            get{return _AssemblyNo;}
        }

        [DataColumn("ASSEMBLY_TYPE")]
        [InsertColumn(FormPNBomEntity.TABLE_NPI_BOM_PN, "ASSEMBLY_TYPE", Asus.Data.DataType.NVarChar)]
        public string AssemblyType
        {
            set{_AssemblyType=value;}
            get{return _AssemblyType;}
        }

        /// <summary>
        /// 新增人員
        /// </summary>
        [DataColumn("CREATE_USER")]
        [InsertColumn(FormPNBomEntity.TABLE_NPI_BOM_PN, "CREATE_USER", Asus.Data.DataType.NVarChar)]
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }

        /// <summary>
        /// 新增時間
        /// </summary>
        [DataColumn("CREATE_DATE")]
        [InsertColumn(FormPNBomEntity.TABLE_NPI_BOM_PN, "CREATE_DATE", Asus.Data.DataType.DateTime)]
        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }

        /// <summary>
        /// 更新人員
        /// </summary>
        [DataColumn("UPDATE_USER")]
        [InsertColumn(FormPNBomEntity.TABLE_NPI_BOM_PN, "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        public string UpdateUser
        {
            set { _UpdateUser = value; }
            get { return _UpdateUser; }
        }

        /// <summary>
        /// 更新時間
        /// </summary>
        [DataColumn("UPDATE_DATE")]
        [InsertColumn(FormPNBomEntity.TABLE_NPI_BOM_PN, "UPDATE_DATE", Asus.Data.DataType.DateTime)]
        public string UpdateTime
        {
            set { _UpdateTime = value; }
            get { return _UpdateTime; }
        }


    }
}
