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
using AsusLibrary;
using Asus.Bussiness.Attribute;


namespace AsusWeb.UserControl
{
    public partial class UCResponseList : BaseControl
    {
        public event AsusEventHandler ResultClick;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public EnumRole UseRole
        {
            set
            {
                ViewState["UseRole"] = value;
            }
            get
            {
                if (ViewState["UseRole"] == null)
                {
                    throw new Exception("無法取得角色型態");
                }
                return (EnumRole)ViewState["UseRole"];
            }
        }

        public void Show()
        {
            this.Visible = true;

            this.GenerateGridViewColumn(GridView1, typeof(FormEntity));

            switch (UseRole)
            {
                case EnumRole.Sourcer:
                    this.GenerateGridViewColumn<QueryColumn2Attribute>(GridView1, typeof(FormEntity));
                    break;

                default:
                    this.GenerateGridViewColumn(GridView1, typeof(FormEntity));
                    break;
            }
            

            QueryData(UseRole);
            
        }

        private void QueryData(EnumRole role)
        {
            FormLogic logic = new FormLogic();

            List<FormEntity> list = null;

            switch (role)
            { 
                case EnumRole.Sourcer:
                    list = logic.QueryFormListBySourcer(ddlEnable.SelectedValue);
                    break;
                case EnumRole.Management:
                    list = logic.QueryFormList(ddlEnable.SelectedValue, this.LoginUserInfo.CompanyId);
                    break;
                default:
                    list = logic.QueryFormList(ddlEnable.SelectedValue,this.LoginUserInfo.UserId,this.LoginUserInfo.CompanyId);
                    break;
            }

            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = GridView1.Rows[index];
            DataKey data = GridView1.DataKeys[index];

            if (ResultClick == null)
            {
                ResultClick = new AsusEventHandler(DefaultAction);
            }



            ResultClick(this, new string[] { data.Values["FormId"].ToString(), data.Values["FormStatus"].ToString(), data.Values["PMId"].ToString(), data.Values["PMCompanyId"].ToString() });
        }

        protected void ddlEnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryData(UseRole);
        }
    }
}