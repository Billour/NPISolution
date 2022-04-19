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
    public partial class BomBooking : BasePage
    {
        /// <summary>
        /// 這裡寫程式代號，做為將來權限使用
        /// </summary>
        private string programId = "";
        private EnumRole[] roles = new EnumRole[] { EnumRole.Admin,EnumRole.PM};


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "PM Booking BOM";

            

            if (!IsAuth(roles))
            {
                ShowAjaxAlertMessage(lbTitle, "你無此權限進入");

                //ShowAlertMessage("你無此權限進入");

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
            //新增模式
            if (PageState == EnumState.Create)
            {
                UCBOMCreate1.PageState = PageState;
                UCBOMCreate1.Show();
              
            }
            else if (PageState == EnumState.Modify)
            {
                UCBOM1.PageState = PageState;
                UCBOM1.Show();

            }
            else if (PageState == EnumState.Query)
            {
                
                //查詢畫面資料
                UCBOMList1.PMAccountNo = LoginUserInfo.UserId;
                UCBOMList1.PageState = PageState;
                UCBOMList1.Show();

            }

        }




        /// <summary>
        /// 新增按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkSubmit_Click(object sender, EventArgs e)
        {
            PageState = EnumState.Create;

            UCBOMCreate1.PMAccountNo = LoginUserInfo.UserId;
            
            SetUserCtrlSetting();
            SetCtrlSetting();
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

        /// <summary>
        /// 存檔資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkSave_Click(object sender, EventArgs e)
        {
            if (UCBOM1.Valid())
            {
                if (UCBOM1.Save())
                {
                    ShowAjaxAlertMessage(lbTitle, "資料已經更新");
                    //ShowAlertMessage("資料已經更新");
                    InitPage(false);
                }
            }


        }

        /// <summary>
        /// 資料新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkCreateSave_Click(object sender, EventArgs e)
        {
            if(UCBOMCreate1.Valid())
            {
                if (UCBOMCreate1.Save())
                {
                    ShowAjaxAlertMessage(lbTitle, "資料已經新增");
                    //ShowAlertMessage("資料已經新增");
                    InitPage(false);
                } 
            }

           
        }

        /// <summary>
        /// 新增按鈕回上一頁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkCreateBack_Click(object sender, EventArgs e)
        {
            InitPage(false);
        }

        /// <summary>
        /// GridView Event List 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="returnArgs"></param>
        protected void Result_Click(object sender, object[] returnArgs)
        {

            PageState = EnumState.Modify;
            UCBOM1.PMAccountNo = returnArgs[0].ToString();
            UCBOM1.BomNo = returnArgs[1].ToString();
            SetUserCtrlSetting();
            SetCtrlSetting();
        }

             
        /// <summary>
        /// 下載BOM範本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkDownlaodBomTemplate_Click(object sender, EventArgs e)
        {
            string sFile = "";

            sFile = UCBOM1.DownLoadExcel();

            Response.AppendHeader("Content-disposition", String.Format("attachment; filename=BOM{0}-{1}.xls", DateTime.Now.ToString("yyyyMMdd"), this.LoginUserInfo.UserEnglishName));
            Response.ContentType = "Application/vnd.ms-excel";
            Response.WriteFile(sFile);
            Response.End();
        }

        protected void lnkUploadBom_Click(object sender, EventArgs e)
        {
            SetUploadVisible(true);

            UploadExcelUserControl1.PageState = PageState;
            UploadExcelUserControl1.Show();

            SetBrowerMode(false);
        }

        private void SetUploadVisible(bool isVisible)
        {
            pnlUpload1.Visible = isVisible;
            pnlUpload2.Visible = isVisible;
        }

        protected void lnkBack2_Click(object sender, EventArgs e)
        {
            SetUploadVisible(false);

            InitPage(true);
            
        }
    }
}
