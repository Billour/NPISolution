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
    public class BaseUserEntity:BaseEntity
    {
        private string _AccountNo;
        private string _AccountName;
        private string _IsEnable;
        private string _Role;
        private string _CompanyId;



        private string _CreateUser = "";
        private string _CreateTime = "";
        private string _UpdateUser = "";
        private string _UpdateTime = "";


        /// <summary>
        /// �b��-�u��
        /// </summary>
        [DataColumn("USER_ID")]
        [InsertColumn("NPI_PRIVILEGE", "USER_ID", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "�b��", "Y", ViewRowType.BoundField, "Y", 10)]
        [Create("Y", "", "�b���G", new EnumUIControl[] { EnumUIControl.Label, EnumUIControl.TextBox }, 10)]
        [Visible(EnumUIControl.TextBox, PageMode.CreateMode)]
        [Visible(EnumUIControl.Label, PageMode.ModifyMode + PageMode.Query)]
        public string AccountNo
        {
            set { _AccountNo = value; }
            get { return _AccountNo; }
        }

        /// <summary>
        /// �m�W �Ҧp Boris Chin(���궯) �^��W��+(����W��)
        /// </summary>
        [DataColumn("USER_NAME")]
        [InsertColumn("NPI_PRIVILEGE", "USER_NAME", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "�m�W", "Y", ViewRowType.LinkButton, "Y", 20)]
        [Create("Y", "", "�m�W�G", new EnumUIControl[] { EnumUIControl.Label }, 20)]
        [Visible(EnumUIControl.Label, PageMode.CreateMode + PageMode.ModifyMode + PageMode.Query)]
        public string AccountName
        {
            set { _AccountName = value; }
            get { return _AccountName; }
        }



        /// <summary>
        /// �O�_�ҥ�
        /// </summary>
        [DataColumn("IS_ENABLE")]
        [InsertColumn("NPI_PRIVILEGE", "IS_ENABLE", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("NPI_PRIVILEGE", "IS_ENABLE", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "�O�_�ҥ�", "Y", ViewRowType.BoundField, "N", 40)]
        [Create("Y", "", "�O�_�ҥΡG", new EnumUIControl[] { EnumUIControl.RadioButtonList }, 30)]
        [Visible(EnumUIControl.RadioButtonList, PageMode.CreateMode + PageMode.ModifyMode, "", true)]
        [SubListClass(typeof(UserLogic), "GetYesOrNoList", null, "Key", "Value")]
        [ControlProperty(EnumUIControl.RadioButtonList, "RepeatDirection", RepeatDirection.Horizontal)]
        public string IsEnable
        {
            set { _IsEnable = value; }
            get { return _IsEnable; }
        }

        /// <summary>
        /// ����
        /// </summary>
        [DataColumn("ROLE_ID")]
        [InsertColumn("NPI_PRIVILEGE", "ROLE_ID", Asus.Data.DataType.NVarChar)]
        public string Role
        {
            set { _Role = value; }
            get { return _Role; }
        }

        /// <summary>
        /// ���q�N��
        /// 
        /// </summary>
        [DataColumn("COMPANY_ID")]
        [InsertColumn("NPI_PRIVILEGE", "COMPANY_ID", Asus.Data.DataType.NVarChar)]
        public string CompanyId
        {
            set { _CompanyId = value; }
            get { return _CompanyId; }
        }

        /// <summary>
        /// �إߤH��
        /// </summary>
        [DataColumn("CREATE_USER")]
        [InsertColumn("NPI_PRIVILEGE", "CREATE_USER", Asus.Data.DataType.NVarChar)]
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }

        /// <summary>
        /// �إ߮ɶ�
        /// </summary>
        [DataColumn("CREATE_DATE")]
        [InsertColumn("NPI_PRIVILEGE", "CREATE_DATE", Asus.Data.DataType.DateTime)]
        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }

        /// <summary>
        /// ��s�H��
        /// </summary>
        [DataColumn("UPDATE_USER")]
        [InsertColumn("NPI_PRIVILEGE", "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("NPI_PRIVILEGE", "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        public string UpdateUser
        {
            set { _UpdateUser = value; }
            get { return _UpdateUser; }
        }

        /// <summary>
        /// ��s�ɶ�
        /// </summary>
        [DataColumn("UPDATE_DATE")]
        [InsertColumn("NPI_PRIVILEGE", "UPDATE_DATE", Asus.Data.DataType.DateTime)]
        [UpdateColumn("NPI_PRIVILEGE", "UPDATE_DATE", Asus.Data.DataType.DateTime)]
        public string UpdateTime
        {
            set { _UpdateTime = value; }
            get { return _UpdateTime; }
        }
    }
}
