using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using AsusLibrary.WebPage;
using Asus;
using AsusLibrary;

namespace AsusWeb
{
    /// <summary>
    /// 本功能己取消
    /// </summary>
    public partial class AlertSourcerMail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InitPage();

                
            }
        }

        private void InitPage()
        { 
            //取得UserId
            if(Request["Sourcer"]!=null)
            {
                string userId = Request["Sourcer"].ToString();

                lbnowDate.Text = DateTime.Now.ToString();

                SendMailPNListUserControl1.AccountNo = userId;
                SendMailPNListUserControl1.Show();
            }
            
        }
    }
}
