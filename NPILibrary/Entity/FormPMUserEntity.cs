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
    /// Form�PPM�����Y
    /// </summary>
    public class FormPMUserEntity:BaseEntity
    {
        /// <summary>
        /// NPI��ƪ� NPI_FORM_SUB 
        /// </summary>
        public const string TABLE_NPI_FORM_SUB = "NPI_FORM_SUB";

        private string _FormId;
        private string _PMUserId;
        private string _PMCompanyId;

        [Tables(FormPMUserEntity.TABLE_NPI_FORM_SUB, PageCommandType.InsertColumnMode, DBCommandType.InsertMode, "", null)]
        public FormPMUserEntity()
        { }

        /// <summary>
        /// Form Id
        /// </summary>
        [DataColumn("FORM_ID")]
        [InsertColumn(FormPMUserEntity.TABLE_NPI_FORM_SUB, "FORM_ID", Asus.Data.DataType.NVarChar)]
        public string FormId
        {
            set { _FormId = value; }
            get { return _FormId; }
        }

        /// <summary>
        /// PM User Id �u��
        /// </summary>
        [DataColumn("PM_USER_ID")]
        [InsertColumn(FormPMUserEntity.TABLE_NPI_FORM_SUB, "PM_USER_ID", Asus.Data.DataType.NVarChar)]
        public string PMUserId
        {
            set { _PMUserId = value; }
            get { return _PMUserId; }
        }

        /// <summary>
        /// ���u�����q
        /// </summary>
        [DataColumn("PM_COMPANY_ID")]
        [InsertColumn(FormPMUserEntity.TABLE_NPI_FORM_SUB, "PM_COMPANY_ID", Asus.Data.DataType.NVarChar)]
        public string PMCompanyId
        {
            set { _PMCompanyId = value; }
            get { return _PMCompanyId; }
        }

    }
}
