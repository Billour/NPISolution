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
    /// �H���D�ު��H
    /// </summary>
    public partial class SendOverDaysMail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InitPage();
            }
        }

        /// <summary>
        /// ��l��
        /// </summary>
        private void InitPage()
        {
            //���oUserId
            if (Request["Manager"] != null)
            {
                string userId = Request["Manager"].ToString();

                WaitingConfirmSourcerListUserControl1.AccountNo = userId;
                WaitingConfirmSourcerListUserControl1.Show();
            }

        }
    }
}
