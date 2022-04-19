using System;
using System.Data;
using System.Configuration;
using System.Web;

using Asus.WebUI;
using AsusLibrary;
using AsusLibrary.Entity;

namespace AsusLibrary.WebPage
{
    /// <summary>
    /// 此專案的第一個頁面
    /// </summary>
    public class BasePage:BaseUIPage
    {
        /// <summary>
        /// 取回此人
        /// </summary>
        /// <param name="programKey"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        protected bool IsAuth(EnumRole[] roles)
        {
            bool isFlag = false;

            //GetLoginUser
            LoginUserEntity user = LoginUserInfo;

            foreach (EnumRole t in roles)
            {
                foreach (string s in user.Roles)
                {
                    if (t.ToString() == s)
                    {
                        isFlag = true;
                        break;
                    }
                }

                if (isFlag)
                {
                    break;
                }
            }
            
            return isFlag;
        }

        /// <summary>
        /// 登入系統人員資料
        /// 只能取得，不能設定
        /// </summary>
        protected LoginUserEntity LoginUserInfo
        {

            get
            {
                if (Session["LoginUserInfo"] != null)
                {
                    return (LoginUserEntity)Session["LoginUserInfo"];
                }

                return null;
            }
        }
        
    }

   

}
