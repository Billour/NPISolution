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
    public partial class UCBOMList : BaseControl
    {
        public event AsusEventHandler ResultClick;

        protected void Page_Load(object sender, EventArgs e)
        {



        }

        /// <summary>
        /// PM 員工帳號
        /// </summary>
        public string PMAccountNo
        {
            set
            {
                ViewState["PMAccountNo"] = value;
            }
            get
            {
                if (ViewState["PMAccountNo"] == null)
                {
                    throw new Exception("無法取得工號資料");
                }
                return ViewState["PMAccountNo"].ToString();
            }

        }

        /// <summary>
        /// 管理者使用
        /// 就全部顯示
        /// </summary>
        public bool IsAdmin
        {
            set
            {
                ViewState["IsAdmin"] = value;
            }
            get
            {
                if (ViewState["IsAdmin"] == null)
                {
                    ViewState["IsAdmin"]=false;
                }
                return (bool)ViewState["IsAdmin"];
            }

        }

        /// <summary>
        /// 顯示內容
        /// </summary>
        public void Show()
        {
            this.GenerateGridViewColumn(GridView1, typeof(BOMEntity));

            QueryData();
           
            
        }

        /// <summary>
        /// 查詢資料
        /// </summary>
        private void QueryData()
        {
            GridView1.DataSource = QueryBOMData();
            GridView1.DataBind();

        }

        private List<BOMBookingEntity> QueryBOMData()
        {
            BOMLogic logic = new BOMLogic();

            List<BOMBookingEntity> list = null;
            if (IsAdmin)
            {
                list = logic.QueryPMBomList(ddlEnable.SelectedValue, ddlIsClose.SelectedValue, LoginInfo.Company);
            }
            else
            {
                list = logic.QueryPMBomList(PMAccountNo, ddlEnable.SelectedValue, ddlIsClose.SelectedValue, LoginInfo.Company);
            }

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                ResultClick(this, new string[] { data.Values["EmpId"].ToString(), data.Values["BOMId"].ToString() });
            }
        }

        /// <summary>
        /// 下載BOM 列表
        /// </summary>
        /// <returns></returns>
        public string DownLoadExcel()
        {
            log.Info("下載Excel");

            string path = Server.MapPath(Request.ApplicationPath);

            if (path.Substring(path.Length - 1, 1) == "\\")
            {
                path = path.Substring(0, path.Length - 1);
            }

            string templateFile = path + "\\Excel\\BOMUploadTemplate.xls";

            log.Info("設定下載檔案");
            string saveFile = path + String.Format("\\TempDoc\\Bom{0}-{1}.xls", DateTime.Now.ToString("yyyyMMdd"), this.LoginUserInfo.UserEnglishName);


            ExcelLogic logic = new ExcelLogic(templateFile, saveFile);



            string workFile = "";

            if (logic.GenerateAdminBomFile(QueryBOMData()))
            {
                workFile = saveFile;
            }
            else
            {
                throw new Exception("無法建立Excel檔案，請查明原因");
            }

            return workFile;


        }

        /// <summary>
        /// DropDownList 資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlEnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryData();
        }

        protected void ddlIsClose_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryData();
        }
    }
}