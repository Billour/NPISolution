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
using AsusLibrary.Logic;
using System.Collections.Generic;

using AsusWeb.Page;



namespace AsusWeb.UserControl
{
    public partial class UCSourcerList : BaseControl
    {
        public event AsusEventHandler ResultClick;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            ComponentLogic logic = new ComponentLogic();

            ddlComponent.DataSource = logic.GetComponentGroupList();
            ddlComponent.DataTextField = "Name";
            ddlComponent.DataValueField = "ID";
            ddlComponent.DataBind();

            ddlComponent.Items.Insert(0, new ListItem("------","0"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Show()
        {
            this.GenerateGridViewColumn(GridView1, typeof(SourcerEntity));

            QueryData();
        }

        private void QueryData()
        {
            List<SourcerEntity> list = GetGridViewData();

            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ModifyCommand")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];
                DataKey data = GridView1.DataKeys[index];

                if (ResultClick == null)
                {
                    ResultClick = new AsusEventHandler(DefaultAction);
                }

                ResultClick(this, new string[] { data.Values["AccountNo"].ToString() });
            }
           
        }

        protected void ddlEnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryData();
        }

        protected void ddlComponent_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryData();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            SetSortDirection(e);
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (e.SortExpression == LastSortExpression)
            {
                if (LastSortDirection == SortDirection.Ascending)
                {
                    e.SortDirection = SortDirection.Descending;
                }
                else
                {
                    e.SortDirection = SortDirection.Ascending;
                }
            }
            else
            {
                e.SortDirection = SortDirection.Descending;
            }

            PopulateGrid(e.SortExpression, e.SortDirection);
        }

        private void PopulateGrid(string sortfield, SortDirection sortDirectionId)
        {
            PopulateGrid(sortfield, sortDirectionId, GridViewPageIndex);
        }

        private void PopulateGrid(string sortfield, SortDirection sortDirectionId, int pageIndex)
        {
            List<SourcerEntity> list = GetGridViewData();
            PopulateGrid<SourcerEntity>(sortfield, sortDirectionId, pageIndex, list, GridView1);
        }

        private List<SourcerEntity> GetGridViewData()
        {
            SourcerLogic logic = new SourcerLogic();

            List<SourcerEntity> list = logic.GetSourcerList(ddlComponent.SelectedValue, ddlEnable.SelectedValue, LoginInfo.Company);

            return list;
        }
    }
}