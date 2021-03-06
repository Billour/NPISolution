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
using AsusWeb.Page;
using AsusLibrary.Utility;
using AsusLibrary;
using AsusLibrary.Logic;

namespace AsusWeb
{
    public partial class QueryFormBom : BasePage
    {
        private string programId = "查詢BOM資料";

        private EnumRole[] roles = new EnumRole[] { EnumRole.Sourcer };

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = programId;

            if (!IsAuth(roles))
            {
                ShowAlertMessage("你無此權限進入");

                
            }
            else
            {
                if (!this.IsPostBack)
                {
                    if (Request["FormNo"] == null)
                    {
                        throw new Exception("無法取參數內容，請通知系統管理員");
                    }

                    string formId = Request["FormNo"].ToString();

                    BOMListUserControl1.FormNo = formId;
                    BOMListUserControl1.Show();
                }
            }
        }
    }
}
