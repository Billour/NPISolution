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
    /// 員工資料檔
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
        /// 員工工號
        /// </summary>
        [DataColumn("EMP_ID")]
        public string EmpAccountId
        {
            set { _EmpAccountId = value; }
            get { return _EmpAccountId; }
        }

        /// <summary>
        /// 員工Domain Login ID
        /// </summary>
        [DataColumn("DOMAIN_ID")]
        public string EmpLoginId
        {
            set { _EmpLoginId = value; }
            get { return _EmpLoginId; }
        }

        /// <summary>
        /// 員工登入Domian 
        /// </summary>
        [DataColumn("DOMAIN")]
        public string EmpDomainId
        {
            set { _EmpDomainId = value; }
            get { return _EmpDomainId; }
        }

        /// <summary>
        /// 員工英文名稱
        /// </summary>
        [DataColumn("DOMAIN_ID_ENAME")]
        public string EmpEnglishName
        {
            set { _EmpEnglishName = value; }
            get { return _EmpEnglishName; }
        }

        /// <summary>
        /// 員工中文名稱
        /// </summary>
        [DataColumn("DOMAIN_ID_CNAME")]
        public string EmpChineseName
        {
            set { _EmpChineseName = value; }
            get { return _EmpChineseName; }
        }

        /// <summary>
        /// 電子郵件
        /// </summary>
        [DataColumn("EMAIL")]
        public string EmpEmail
        {
            set { _EmpEmail = value; }
            get { return _EmpEmail; }
        }

        /// <summary>
        /// 電話
        /// </summary>
        [DataColumn("PHONE01")]
        public string PhoneNo
        {
            set { _PhoneNo = value; }
            get { return _PhoneNo; }
        }

        /// <summary>
        /// 公司代號
        /// </summary>
        [DataColumn("COMPANY_ID")]
        public string CompanyId
        {
            set { _CompanyId = value; }
            get { return _CompanyId; }
        }


    }
}
