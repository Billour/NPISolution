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
    /// ���M�ת��Ĥ@�ӭ���
    /// </summary>
    public class BasePage:BaseUIPage
    {
        /// <summary>
        /// ���^���H
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
        /// �n�J�t�ΤH�����
        /// �u����o�A����]�w
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
