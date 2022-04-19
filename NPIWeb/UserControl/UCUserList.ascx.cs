using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using AsusLibrary.WebPage.UserControl;
using AsusLibrary.Entity;
using AsusLibrary.Logic;

using AsusWeb.Page;


namespace AsusWeb.UserControl
{
    public partial class UCUserList : BaseControl
    {
        public event AsusEventHandler ResultClick;

        protected void Page_Load(object sender, EventArgs e)
        {
            


        }

        public void Show()
        {
            this.GenerateGridViewColumn(GridView1, typeof(UserEntity));

            QueryData();
            
        }

        private void QueryData()
        {
            List<UserEntity> list = GetGridViewData();

            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        private List<UserEntity> GetGridViewData()
        {
            UserLogic logic = new UserLogic();

            return logic.QueryPMList(ddlEnable.SelectedValue, LoginInfo.Company);
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

        /// <summary>
        /// Auto Post Back Query Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlEnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryData();
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
            List<UserEntity> list = GetGridViewData();
            
            PopulateGrid<UserEntity>(sortfield, sortDirectionId, pageIndex, list, GridView1);

            
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            SetSortDirection(e);
        }
    }
}