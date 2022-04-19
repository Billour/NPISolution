using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


using AsusLibrary.Entity;
using Asus.WebUI.UserControl;

namespace AsusLibrary.WebPage.UserControl
{
    /// <summary>
    /// User Control 的第一個頁面
    /// </summary>
    public class BaseControl:BaseControlPage
    {
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
