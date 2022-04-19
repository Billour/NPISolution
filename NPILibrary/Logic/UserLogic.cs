using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Asus.Data;
using AsusLibrary.Config;
using AsusLibrary.Entity;

namespace AsusLibrary.Logic
{
    public class UserLogic:BaseUserLogic
    {
        public UserLogic()
            : base()
        { }
        /// <summary>
        /// 取得PM角色的人員
        /// </summary>
        /// <param name="isEnable"></param>
        /// <returns></returns>
        //public List<UserEntity> QueryPMList(string isEnable)
        //{
        //    return this.GetRoleList<UserEntity>(EnumRole.PM, isEnable);
        //}

        /// <summary>
        /// 取得PM角色的人
        /// </summary>
        /// <param name="isEnable"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<UserEntity> QueryPMList(string isEnable, string companyId)
        {
            return this.GetRoleList<UserEntity>(EnumRole.PM, isEnable, companyId);
        }

        /// <summary>
        /// 取得PM的人員資訊
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //public UserEntity QueryPMInfo(string userId)
        //{
        //    return this.GetRoleUser<UserEntity>(userId, EnumRole.PM);
        //}

        /// <summary>
        /// 取得PM角色的人員
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public UserEntity QueryPMInfo(string userId, string companyId)
        {
            return this.GetRoleUser<UserEntity>(userId, EnumRole.PM, companyId);
        }

       
       
    }


    
}
