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
    public partial class GroupListUserControl : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Show()
        {
            //this.GenerateGridViewColumn(GridView1, typeof(GroupMapEntity));

            QueryData();


        }

        /// <summary>
        /// ¬d¸ß¸ê®Æ
        /// </summary>
        private void QueryData()
        {
            GridView1.DataSource = QueryGroupData();
            GridView1.DataBind();

        }

        private List<GroupMapEntity> QueryGroupData()
        {
            GroupLogic logic = new GroupLogic();

            List<GroupMapEntity> list=logic.QueryGroupList();

            return list;
        }
    }
}