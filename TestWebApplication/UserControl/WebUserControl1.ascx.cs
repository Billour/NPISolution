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

using AsusLibrary.WebPage.UserControl;

namespace TestWebApplication.UserControl
{
    public partial class WebUserControl1 : BaseControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.CreateTable<ModifyRequestEntity>("A", "~/Layout/TableLayout.ascx", ph1,Asus.EnumState.Create, Asus.EnumTableColumn.TwoColumn, "", "", "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}