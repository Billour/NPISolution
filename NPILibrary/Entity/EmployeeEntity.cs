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
    /// ���u�����
    /// 
    /// </summary>
    public class EmployeeEntity:BaseEntity
    {
        private string _EmpAccountId;
        private string _EmpLoginId;
        private string _EmpDomainId;
        private string _EmpEnglishName;
        private string _EmpChineseName;
        private string _EmpEmail;
        private string _PhoneNo;
        private string _CompanyId;

        /// <summary>
        /// ���u�u��
        /// </summary>
        [DataColumn("EMP_ID")]
        public string EmpAccountId
        {
            set { _EmpAccountId = value; }
            get { return _EmpAccountId; }
        }

        /// <summary>
        /// ���uDomain Login ID
        /// </summary>
        [DataColumn("DOMAIN_ID")]
        public string EmpLoginId
        {
            set { _EmpLoginId = value; }
            get { return _EmpLoginId; }
        }

        /// <summary>
        /// ���u�n�JDomian 
        /// </summary>
        [DataColumn("DOMAIN")]
        public string EmpDomainId
        {
            set { _EmpDomainId = value; }
            get { return _EmpDomainId; }
        }

        /// <summary>
        /// ���u�^��W��
        /// </summary>
        [DataColumn("DOMAIN_ID_ENAME")]
        public string EmpEnglishName
        {
            set { _EmpEnglishName = value; }
            get { return _EmpEnglishName; }
        }

        /// <summary>
        /// ���u����W��
        /// </summary>
        [DataColumn("DOMAIN_ID_CNAME")]
        public string EmpChineseName
        {
            set { _EmpChineseName = value; }
            get { return _EmpChineseName; }
        }

        /// <summary>
        /// �q�l�l��
        /// </summary>
        [DataColumn("EMAIL")]
        public string EmpEmail
        {
            set { _EmpEmail = value; }
            get { return _EmpEmail; }
        }

        /// <summary>
        /// �q��
        /// </summary>
        [DataColumn("PHONE01")]
        public string PhoneNo
        {
            set { _PhoneNo = value; }
            get { return _PhoneNo; }
        }

        /// <summary>
        /// ���q�N��
        /// </summary>
        [DataColumn("COMPANY_ID")]
        public string CompanyId
        {
            set { _CompanyId = value; }
            get { return _CompanyId; }
        }


    }
}
