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
    /// 恨瞶蝴臔
    /// </summary>
    public partial class Maintain : BasePage
    {
        private EnumRole[] roles = new EnumRole[] { EnumRole.Admin, EnumRole.Management };

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Management";

            if (!IsAuth(roles))
            {
                ShowAjaxAlertMessage(lbTitle, "礚舦秈");

                
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
        /// 砞﹚穝糤家Α
        /// </summary>
        /// <param name="isNew"></param>
        private void SetCreateMode(bool isNew)
        {
            pnlCreate.Visible = isNew;
            pnlCreate2.Visible = isNew;
        }

        /// <summary>
        /// 砞﹚э家Α
        /// </summary>
        /// <param name="isEdit"></param>
        private void SetEditMode(bool isEdit)
        {
            pnlEdit.Visible = isEdit;
            pnlEdit2.Visible = isEdit;
        }

        /// <summary>
        /// 砞﹚聅凝家Α
        /// </summary>
        /// <param name="isBrower"></param>
        private void SetBrowerMode(bool isBrower)
        {
            pnlQuery.Visible = isBrower;
            pnlQuery2.Visible = isBrower;
        }

        private void SetUserCtrlSetting()
        {
            //穝糤家Α
             if (PageState == EnumState.Query)
            {

                //琩高礶戈
                UCBOMList1.PMAccountNo = LoginUserInfo.UserId;
                UCBOMList1.IsAdmin = true;
                UCBOMList1.PageState = PageState;
                UCBOMList1.Show();

            }

        }

        /// <summary>
        /// 更BOM 
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
