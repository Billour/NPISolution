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
using Asus.Bussiness.Attribute;

namespace AsusWeb.UserControl
{
    public partial class SendMailPNListUserControl : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// PM 員工帳號
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
            

            GenerateColumn();

            QueryData();

        }

        private void GenerateColumn()
        {
            this.GenerateDynamicGridViewColumn<QueryColumn2Attribute,PNPriceEntity>(GridView1);
        }

        /// <summary>
        /// 查詢資料
        /// </summary>
        private void QueryData()
        {
            UserLogic userLogic = new UserLogic();

            EmployeeEntity emp = userLogic.GetUserInfo(AccountNo, LoginInfo.Company);

            if (emp != null)
            {
                lbUserMessage.Text = String.Format("{0}({1})", emp.EmpLoginId, emp.EmpChineseName);
            }

            SourcerLogic logic = new SourcerLogic();

            List<PNPriceEntity> list = logic.GetWaitingPNPriceListByUserId(AccountNo,true);

            GridView1.DataSource = list;
            GridView1.DataBind();

        }
    }
}