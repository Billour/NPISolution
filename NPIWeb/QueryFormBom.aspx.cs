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
        private string programId = "琩高BOM戈";

        private EnumRole[] roles = new EnumRole[] { EnumRole.Sourcer };

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = programId;

            if (!IsAuth(roles))
            {
                ShowAlertMessage("礚舦秈");

                
            }
            else
            {
                if (!this.IsPostBack)
                {
                    if (Request["FormNo"] == null)
                    {
                        throw new Exception("礚猭把计ず甧叫硄╰参恨瞶");
                    }

                    string formId = Request["FormNo"].ToString();

                    BOMListUserControl1.FormNo = formId;
                    BOMListUserControl1.Show();
                }
            }
        }
    }
}
