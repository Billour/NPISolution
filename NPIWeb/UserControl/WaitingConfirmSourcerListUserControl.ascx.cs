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
using AsusLibrary.Entity;
using System.Collections.Generic;
using AsusLibrary.Logic;

using AsusWeb.Page;

namespace AsusWeb.UserControl
{
    public partial class WaitingConfirmSourcerListUserControl : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 管理者帳號
        /// </summary>
        public string AccountNo
        {
            set
            {
                ViewState["AccountNo"] = value;
            }
            get
            {
                if (ViewState["AccountNo"] == null)
                {
                    throw new Exception("無法取得工號資料");
                }
                return ViewState["AccountNo"].ToString();
            }

        }

        public void Show()
        {

            SourcerLogic logic = new SourcerLogic();

            List<string> list = logic.GetSourceListByManager(AccountNo,LoginInfo.Company);

            foreach (string s in list)
            {
                SendMailPNListUserControl uc = (SendMailPNListUserControl)this.LoadControl("~/UserControl/SendMailPNListUserControl.ascx");

                uc.AccountNo = s;
                uc.Show();

                ph1.Controls.Add(uc);
                
            }


       }

        
    }
}