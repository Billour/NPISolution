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
    public partial class Index : BasePage
    {
        private string programId = "Home";
        private EnumRole[] roles = new EnumRole[] { EnumRole.Admin, EnumRole.Management,EnumRole.PM,EnumRole.Sourcer };

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "系統首頁";

            if (!IsAuth(roles))
            {
                ShowAlertMessage("你無此權限進入");
                
            }
            else
            {
                if (!this.IsPostBack)
                {

                    InitPage();

                }
            }
        }

        private void InitPage()
        {
            GroupListUserControl1.Show();
        }
    }
}
