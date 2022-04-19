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

using AsusWeb.Page;
using System.Collections.Specialized;
using System.Collections.Generic;
using Asus.Bussiness.Map;
using Asus.Data;

using AsusLibrary.WebPage;
using Asus;
using AsusLibrary;
using Asus.Helper;

using System.IO;

using AsusLibrary.Logic;

namespace AsusWeb
{
    /// <summary>
    /// 查詢功能
    /// 
    /// </summary>
    public partial class Query : BasePage
    {
        private string programId = "Query";
        private EnumRole[] roles = new EnumRole[] { EnumRole.Admin };

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "查詢資料";

            if (!IsAuth(roles))
            {
                ShowAlertMessage("你無此權限進入");

                
            }
            else
            {
                if (!this.IsPostBack)
                {

                    InitPage();
                    pnlVisible.Visible = true;

                }
            }
        }

        private void InitPage()
        {
            BindControl();
        }

        private void BindControl()
        {
            NameValueCollection items = LoginInfo.DBConnectStringList;

            List<DbConnStringMap> list = LoginInfo.SystemDbList;

            ddlSource.DataSource = list;
            ddlSource.DataValueField = "ConnectionString";
            ddlSource.DataTextField = "ConnectionName";
            ddlSource.DataBind();
            
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = DbAssistant.DoSelect(tbQuery.Text, ddlSource.SelectedItem.Text);
            GridView1.DataBind();
        }

        /// <summary>
        /// 使用者帳號資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUserQuery_Click(object sender, EventArgs e)
        {
            string sql = "select * from srm_user where company_id='13006' and lower(domain_id)=lower('{0}') and work_status='Y'";

            sql = String.Format(sql, tbLoginId.Text);

            GridView2.DataSource = DbAssistant.DoSelect(sql, "UserDB");
            GridView2.DataBind();
        }

        /// <summary>
        /// Download Logs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDownloadLogs_Click(object sender, EventArgs e)
        {
            string fileName =String.Format("\\log-{0}.zip",DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));

            string zipPath=Server.MapPath("~/TempDoc")+fileName;

            

            if (ZipHelper.ZipFilesAndFolder(zipPath, null, new string[] { Server.MapPath("~/logs/NPI/LogFile") }))
            {
                Response.AppendHeader("Content-disposition",fileName);
                Response.ContentType = "Application/zip";
                Response.WriteFile(zipPath);
                Response.End();
            }
            

            
        }

        /// <summary>
        /// 查詢生產地及Buying Mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQueryBOMSite_Click(object sender, EventArgs e)
        {
            SourcerLogic logic = new SourcerLogic();

            GridView3.DataSource = logic.GetPNTipTopPriceData(tbPN.Text);
            GridView3.DataBind();

            GridView4.DataSource = logic.GetBuyingMode(tbPN.Text);
            GridView4.DataBind();
        }

        /// <summary>
        /// 等待展BOM資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            //BOMLogic logic = new BOMLogic();

            //GridView5.DataSource=logic.QueryBookingBomList(AsusLibrary.EnumWorkStatus.Wait);
            //GridView5.DataBind();

        }
    }
}
