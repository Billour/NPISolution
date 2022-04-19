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
using AsusLibrary.Utility;
using System.Runtime.InteropServices;

namespace AsusWeb
{
    public partial class BomProc : BasePage
    {
        private string programId = "";

        private EnumRole[] roles = new EnumRole[] { EnumRole.PM };

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "PM DownLoad Excel";

            if (!IsAuth(roles))
            {
                ShowAlertMessage("你無此權限進入");

                //Response.Redirect(Request.UrlReferrer.AbsoluteUri);

                
            }
            else
            {
                if (!this.IsPostBack)
                {

                    InitPage(true);

                }
            }

            
        }

        private string FormId
        {
            set
            {
                ViewState["FormId"] = value;


            }
            get
            {
                if (ViewState["FormId"] == null)
                {
                    throw new Exception("無法取得FormId代號，請查明原因");
                }
                return ViewState["FormId"].ToString();
            }

        }


        private void InitPage(bool isInit)
        {
            PageState = EnumState.Query;
            SetCtrlSetting();
            SetUserCtrlSetting();
        }

        private void SetCtrlSetting()
        {
            bool isNew = false;
            bool isEdit = false;
            bool isBrower = true;

            if (PageState == EnumState.Modify)
            {
                isNew = false;
                isEdit = true;
                isBrower = false;


            }
            else if (PageState == EnumState.Create)
            {
                isNew = true;
                isEdit = false;
                isBrower = false;
            }

            SetCreateMode(isNew);
            SetEditMode(isEdit);
            SetBrowerMode(isBrower);
        }

        /// <summary>
        /// 設定新增模式
        /// </summary>
        /// <param name="isNew"></param>
        private void SetCreateMode(bool isNew)
        {
            pnlCreate.Visible = isNew;
            pnlCreate2.Visible = isNew;
        }

        /// <summary>
        /// 設定修改模式
        /// </summary>
        /// <param name="isEdit"></param>
        private void SetEditMode(bool isEdit)
        {
            pnlEdit.Visible = isEdit;
            pnlEdit2.Visible = isEdit;
        }

        /// <summary>
        /// 設定瀏覽模式
        /// </summary>
        /// <param name="isBrower"></param>
        private void SetBrowerMode(bool isBrower)
        {
            pnlQuery.Visible = isBrower;
            pnlQuery2.Visible = isBrower;
        }

        /// <summary>
        /// 設定UserControl的狀況

        /// </summary>
        private void SetUserCtrlSetting()
        {
            if (PageState == EnumState.Modify)
            {
                UCResponseQuery1.PageState = EnumState.Query;
                UCResponseQuery1.Show();

            }
            else if (PageState == EnumState.Query)
            {

                UCResponseList1.PageState = PageState;
                UCResponseList1.Show();

            }

        }

        /// <summary>
        /// 回上一頁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkBack_Click(object sender, EventArgs e)
        {
            InitPage(false);
        }

        //下載Excel
        protected void lnkSave_Click(object sender, EventArgs e)
        {
            string sFile = UCResponseQuery1.DownLoadExcel();

            //Response.AppendHeader("Content-disposition", String.Format("attachment; filename={0}-{1}.xls", DateTime.Now.ToString("yyyyMMdd"), this.LoginUserInfo.LoginId + this.LoginUserInfo.UserChineseName));
            Response.ContentType = "Application/vnd.ms-excel";
            Response.WriteFile(sFile);
            Response.End();
        }

        protected void Result_Click(object sender, object[] returnArgs)
        {

            string formId = returnArgs[0].ToString();

            string status = returnArgs[1].ToString();

            PageState = EnumState.Modify;

            FormId = formId;
            
            //瀏覽模式
            UCResponseQuery1.FormId = formId;

            SetUserCtrlSetting();
            SetCtrlSetting();
        }

        /// <summary>
        /// 管理者結案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkClose_Click(object sender, EventArgs e)
        {
            if (UCResponseQuery1.CloseForm())
            {
                ShowAlertMessage("結案完成");
                InitPage(false);
            }
        }

        protected void lnkViewBom_Click(object sender, EventArgs e)
        {
            this.OpenNewWindow("QueryFormBom.aspx?FormNo=" + FormId);
        }
    }
}
