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
        /// 帳戶-工號
        /// </summary>
        [DataColumn("USER_ID")]
        [InsertColumn("NPI_PRIVILEGE", "USER_ID", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "帳號", "Y", ViewRowType.BoundField, "Y", 10)]
        [Create("Y", "", "帳號：", new EnumUIControl[] { EnumUIControl.Label, EnumUIControl.TextBox }, 10)]
        [Visible(EnumUIControl.TextBox, PageMode.CreateMode)]
        [Visible(EnumUIControl.Label, PageMode.ModifyMode + PageMode.Query)]
        public string AccountNo
        {
            set { _AccountNo = value; }
            get { return _AccountNo; }
        }

        /// <summary>
        /// 姓名 例如 Boris Chin(秦國雄) 英文名稱+(中文名稱)
        /// </summary>
        [DataColumn("USER_NAME")]
        [InsertColumn("NPI_PRIVILEGE", "USER_NAME", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "姓名", "Y", ViewRowType.LinkButton, "Y", 20)]
        [Create("Y", "", "姓名：", new EnumUIControl[] { EnumUIControl.Label }, 20)]
        [Visible(EnumUIControl.Label, PageMode.CreateMode + PageMode.ModifyMode + PageMode.Query)]
        public string AccountName
        {
            set { _AccountName = value; }
            get { return _AccountName; }
        }



        /// <summary>
        /// 是否啟用
        /// </summary>
        [DataColumn("IS_ENABLE")]
        [InsertColumn("NPI_PRIVILEGE", "IS_ENABLE", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("NPI_PRIVILEGE", "IS_ENABLE", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "是否啟用", "Y", ViewRowType.BoundField, "N", 40)]
        [Create("Y", "", "是否啟用：", new EnumUIControl[] { EnumUIControl.RadioButtonList }, 30)]
        [Visible(EnumUIControl.RadioButtonList, PageMode.CreateMode + PageMode.ModifyMode, "", true)]
        [SubListClass(typeof(UserLogic), "GetYesOrNoList", null, "Key", "Value")]
        [ControlProperty(EnumUIControl.RadioButtonList, "RepeatDirection", RepeatDirection.Horizontal)]
        public string IsEnable
        {
            set { _IsEnable = value; }
            get { return _IsEnable; }
        }

        /// <summary>
        /// 角色
        /// </summary>
        [DataColumn("ROLE_ID")]
        [InsertColumn("NPI_PRIVILEGE", "ROLE_ID", Asus.Data.DataType.NVarChar)]
        public string Role
        {
            set { _Role = value; }
            get { return _Role; }
        }

        /// <summary>
        /// 公司代號
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
        /// 建立人員
        /// </summary>
        [DataColumn("CREATE_USER")]
        [InsertColumn("NPI_PRIVILEGE", "CREATE_USER", Asus.Data.DataType.NVarChar)]
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }

        /// <summary>
        /// 建立時間
        /// </summary>
        [DataColumn("CREATE_DATE")]
        [InsertColumn("NPI_PRIVILEGE", "CREATE_DATE", Asus.Data.DataType.DateTime)]
        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }

        /// <summary>
        /// 更新人員
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
        /// 更新時間
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
