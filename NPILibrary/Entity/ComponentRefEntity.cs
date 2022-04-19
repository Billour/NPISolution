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
    public class ComponentRefEntity:BaseEntity
    {
        private string _EmpId;
        private string _ComponentId;
        private string _ComponentName;
        private string _CompanyId;

        [Tables("NPI_PN_SOURCER", PageCommandType.InsertColumnMode, DBCommandType.InsertMode, "", null)]
        public ComponentRefEntity()
        { }

        /// <summary>
        /// o���u�b��
        /// </summary>
        [DataColumn("USER_ID")]
        [InsertColumn("NPI_PN_SOURCER", "USER_ID", Asus.Data.DataType.NVarChar)]
        public string EmpId
        {
            set { _EmpId = value; }
            get { return _EmpId; }
        }

        /// <summary>
        /// ����Ƹ�
        /// </summary>
        [DataColumn("GROUP_ID")]
        [InsertColumn("NPI_PN_SOURCER", "GROUP_ID", Asus.Data.DataType.NVarChar)]
        public string ComponentId
        {
            set { _ComponentId = value; }
            get { return _ComponentId; }
        }

        /// <summary>
        /// ����Ƹ��W��
        /// </summary>
        [DataColumn("Group_Name")]
        public string ComponentName
        {
            set { _ComponentName = value; }
            get { return _ComponentName; }
        }

        /// <summary>
        /// ���q�W��
        /// </summary>
        [DataColumn("COMPANY_ID")]
        [InsertColumn("NPI_PN_SOURCER", "COMPANY_ID", Asus.Data.DataType.NVarChar)]
        public string CompanyId
        {
            set { _CompanyId = value; }
            get { return _CompanyId; }
        }

    }
}
