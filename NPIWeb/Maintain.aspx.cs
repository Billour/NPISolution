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

namespace AsusWeb
{
    /// <summary>
    /// 管理者維護界面
    /// </summary>
    public partial class Maintain : BasePage
    {
        private EnumRole[] roles = new EnumRole[] { EnumRole.Admin, EnumRole.Management };

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Management";

            if (!IsAuth(roles))
            {
                ShowAjaxAlertMessage(lbTitle, "你無此權限進入");

                
            }
            else
            {
                if (!this.IsPostBack)
                {

                    InitPage(true);

                }
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

        private void SetUserCtrlSetting()
        {
            //新增模式
             if (PageState == EnumState.Query)
            {

                //查詢畫面資料
                UCBOMList1.PMAccountNo = LoginUserInfo.UserId;
                UCBOMList1.IsAdmin = true;
                UCBOMList1.PageState = PageState;
                UCBOMList1.Show();

            }

        }

        /// <summary>
        /// 下載BOM 列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkDownlaodBomTemplate_Click(object sender, EventArgs e)
        {
            string sFile = "";

            sFile = UCBOMList1.DownLoadExcel();

            Response.AppendHeader("Content-disposition", String.Format("attachment; filename=BOM{0}-{1}.xls", DateTime.Now.ToString("yyyyMMdd"), this.LoginUserInfo.UserEnglishName));
            Response.ContentType = "Application/vnd.ms-excel";
            Response.WriteFile(sFile);
            Response.End();
        }
    }
}
