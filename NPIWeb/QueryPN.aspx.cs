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
    /// <summary>
    /// Sourcer 琩高厨基
    /// 程璶场琌倒Sourcerㄏノ
    /// 矗ㄑ琩高基
    /// –Sourcer琩高戈
    /// </summary>
    public partial class QueryPN : BasePage
    {
        /// <summary>
        /// 祘Α嘿
        /// </summary>
        private string programId = "厨基琩高";

        private EnumRole[] roles = new EnumRole[] { EnumRole.Admin,EnumRole.Sourcer };

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "厨基琩高";

            if (!IsAuth(roles))
            {
                ShowAlertMessage("礚舦秈");

                Response.Redirect(Request.UrlReferrer.AbsoluteUri);
            }
            else
            {
                if (!this.IsPostBack)
                {

                    InitPage(true);

                }
            }
        }

        private void InitPage(bool isInit)
        {
            PageState = EnumState.Query;
            SetCtrlSetting();
            SetUserCtrlSetting();
        }

        private void SetCtrlSetting()
        {
            bool isNew = false;
            bool isEdit = false;
            bool isBrower = true;

            if (PageState == EnumState.Modify)
            {
                isNew = false;
                isEdit = true;
                isBrower = false;


            }
            else if (PageState == EnumState.Create)
            {
                isNew = true;
                isEdit = false;
                isBrower = false;
            }

            SetCreateMode(isNew);
            SetEditMode(isEdit);
            SetBrowerMode(isBrower);
        }

        /// <summary>
        /// 砞﹚穝糤家Α
        /// </summary>
        /// <param name="isNew"></param>
        private void SetCreateMode(bool isNew)
        {
            pnlCreate.Visible = isNew;
            pnlCreate2.Visible = isNew;
        }

        /// <summary>
        /// 砞﹚э家Α
        /// </summary>
        /// <param name="isEdit"></param>
        private void SetEditMode(bool isEdit)
        {
            pnlEdit.Visible = isEdit;
            pnlEdit2.Visible = isEdit;
        }

        /// <summary>
        /// 砞﹚聅凝家Α
        /// </summary>
        /// <param name="isBrower"></param>
        private void SetBrowerMode(bool isBrower)
        {
            pnlQuery.Visible = isBrower;
            pnlQuery2.Visible = isBrower;
        }

        /// <summary>
        /// 砞﹚UserControl猵

        /// </summary>
        private void SetUserCtrlSetting()
        {
            if (PageState == EnumState.Query)
            {

                //琩高礶戈
                QueryPNPriceListUserControl1.PageState = PageState;
                QueryPNPriceListUserControl1.Show();
               

            }

        }

        
    }
}
