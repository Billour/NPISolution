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
using Asus;
using AsusLibrary.Utility;


namespace AsusWeb.UserControl
{
    public partial class UCRuleList : BaseControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //取得目前的狀態
            EnumState state = EnumUtil.StringToEnum<EnumState>(lbPageState.Text);

            this.CreateTable<PreFixRuleEntity>("A", "~/Layout/TableLayout.ascx", ph1,state, Asus.EnumTableColumn.OneColumn, "", "", "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Show()
        {
            this.Visible = true;

            this.GenerateGridViewColumn(GridView1, typeof(PreFixRuleEntity));

            List<PreFixRuleEntity> list = new List<PreFixRuleEntity>();

            list.Add(new PreFixRuleEntity());
            list.Add(new PreFixRuleEntity());
            list.Add(new PreFixRuleEntity());
            list.Add(new PreFixRuleEntity());
            list.Add(new PreFixRuleEntity());

            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}