using System;
using System.Collections.Generic;
using System.Text;

using Asus.Sercurity;

namespace AsusLibrary.Entity
{
    /// <summary>
    /// Login User 資料
    /// 加入角色列表
    /// </summary>
    public class LoginUserEntity:LoginUser
    {
        private List<string> _Roles;

        /// <summary>
        /// NPI 新增角色列表
        /// </summary>
        public List<string> Roles
        {
            set { _Roles = value; }
            get { return _Roles; }
        }
    }
}
