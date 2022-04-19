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
    /// 使用者列表
    /// </summary>
    public class UserEntity:BaseUserEntity
    {
        [Tables("NPI_PRIVILEGE", PageCommandType.InsertColumnMode, DBCommandType.InsertMode, "", null)]
        [Tables("NPI_PRIVILEGE", PageCommandType.UpdateColumnMode, DBCommandType.UpdateMode, " where user_id='{0}' and company_id='{1}' and role_id='{2}'", new string[] { "AccountNo", "CompanyId", "Role" })]
        public UserEntity()
        {}


       
       
    }
}
