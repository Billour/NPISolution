using System;
using System.Collections.Generic;
using System.Text;

using Asus.Bussiness.Attribute;
using Asus.Bussiness.Map;

namespace AsusLibrary.Entity
{
    /// <summary>
    /// ��Entity �O�w��
    /// Sourcer PN ��Map ������
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
        /// ���u�u��
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
        /// ���q�N��
        /// �ثe�u�䴩13006
        /// </summary>
        [DataColumn("COMPANY_ID")]
        [InsertColumn("NPI_SOURCERPN_MAP", "COMPANY_ID", Asus.Data.DataType.NVarChar)]
        public string CompanyId
        {
            set { _CompanyId = value; }
            get { return _CompanyId; }
        }

        /// <summary>
        /// �Ƹ�
        /// </summary>
        [DataColumn("ASUS_PN")]
        [InsertColumn("NPI_SOURCERPN_MAP", "ASUS_PN", Asus.Data.DataType.NVarChar)]
        public string PN
        {
            set { _PN = value; }
            get { return _PN; }
        }

        /// <summary>
        /// �O�_�n�q��
        /// </summary>
        public bool IsAlert
        {
            set { _IsAlert = value; }
            get { return _IsAlert; }
        }

        /// <summary>
        /// �s�W�H��
        /// </summary>
        [DataColumn("CREATE_USER")]
        [InsertColumn("NPI_SOURCERPN_MAP", "CREATE_USER", Asus.Data.DataType.NVarChar)]
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }

        /// <summary>
        /// �إ߮ɶ�
        /// </summary>
        [DataColumn("CREATE_TIME")]
        [InsertColumn("NPI_SOURCERPN_MAP", "CREATE_TIME", Asus.Data.DataType.DateTime)]
        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }

        /// <summary>
        /// ��s�H��
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
        /// ��s�ɶ�
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
