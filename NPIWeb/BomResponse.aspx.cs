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
using AsusWeb.Page;
using AsusLibrary.Utility;
using AsusLibrary;
using AsusLibrary.Logic;

namespace AsusWeb
{
    public partial class BomResponse : BasePage
    {
        private string programId = "";

        private EnumRole[] roles = new EnumRole[] { EnumRole.Sourcer };
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "BOM回覆";

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

        private EnumFormstatus FormStatus
        {
            set
            {
                ViewState["FormStatus"] = value;
            }
            get
            {
                if (ViewState["FormStatus"] == null)
                {
                    throw new Exception("無法取得角色型態");
                }
                return (EnumFormstatus)ViewState["FormStatus"];
            }
        }

        /// <summary>
        /// 表單代號
        /// </summary>
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

        private string MainId
        {
            set
            {
                ViewState["MainId"] = value;


            }
            get
            {
                if (ViewState["MainId"] == null)
                {
                    ViewState["MainId"] = "";
                }
                return ViewState["MainId"].ToString();
            }

        }

        private void InitPage(bool isInit)
        {
            PageState = EnumState.Query;
            SetCtrlSetting();
            SetUserCtrlSetting(true);
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

            DateTime myDate = new DateTime(2009, 6, 23);

            if (DateUtil.DateDiff(DateInterval.Day, DateTime.Now, myDate) > 0)
            {
                pnlQuery3.Visible = false;
            }
            else
            {
                pnlQuery3.Visible = isBrower;
            }

            
        }

        /// <summary>
        /// 設定UserControl的狀況

        /// </summary>
        private void SetUserCtrlSetting(bool isShowEdit)
        {
            if (PageState == EnumState.Modify)
            {
                UCResponse1.Visible = false;
                UCResponseQuery1.Visible = false;

                if (isShowEdit)
                {
                    UCResponse1.PageState = PageState;
                    UCResponse1.Show();
                }
                else
                {
                    UCResponseQuery1.PageState = EnumState.Query;
                    UCResponseQuery1.Show();
                }

                

                

            }
            else if (PageState == EnumState.Query)
            {

                UCResponseList1.PageState = PageState;
                UCResponseList1.Show();

                UCGenList1.PageState = PageState;
                UCGenList1.Show();

            }
            else if (PageState == EnumState.Create)
            {
                //上傳Excel 檔案
                UploadExcelUserControl1.PageState = PageState;
                UploadExcelUserControl1.Show();
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

        //存檔
        protected void lnkSave_Click(object sender, EventArgs e)
        {
            DateTime myDate = new DateTime(2009, 6, 23);

            if (DateUtil.DateDiff(DateInterval.Day, DateTime.Now, myDate) > 0)
            {
                if (UCResponse1.Save())
                {
                    ShowAlertMessage("資料已經更新");
                    InitPage(false);
                }
            }
            else
            {
                ShowAjaxAlertMessage(lnkSave, "此功能暫停使用，請利用Excel上傳功能");
            }

            

            

        }

        protected void Result_Click(object sender, object[] returnArgs)
        {
            string formId = returnArgs[0].ToString();

            string status = returnArgs[1].ToString();

            PageState = EnumState.Modify;

            bool isShowEdit = false;

            EnumFormstatus enumFormStatus = EnumUtil.StringToEnum<EnumFormstatus>(status);

            FormStatus = enumFormStatus; //設定目前的Form 狀態

            FormId = formId;

            isShowEdit = IsShowResponseExcel(formId, enumFormStatus);

            //switch (enumFormStatus)
            //{ 
            //    case EnumFormstatus.Y:
                    
            //        //瀏覽模式
            //        UCResponseQuery1.FormId = formId;
            //        UCResponseQuery1.SourcerUserId = LoginUserInfo.UserId;
            //        UCResponseQuery1.SourcerUserCompanyId = LoginUserInfo.CompanyId;
                    
            //        //lnkPrint.Visible = !isShowEdit;
            //        lnkSave.Visible = isShowEdit;
            //        break;
            //    case EnumFormstatus.N:

            //        //修改模式
            //        isShowEdit = true;

            //        //給三個代號取得資料
            //        UCResponse1.FormId = formId;
            //        UCResponse1.SourcerUserId = LoginUserInfo.UserId;
            //        UCResponse1.SourcerUserCompanyId = LoginUserInfo.CompanyId;
                    
            //        //lnkPrint.Visible = !isShowEdit;
            //        lnkSave.Visible = isShowEdit;

            //        break;
            //}

            
           

            SetUserCtrlSetting(isShowEdit);
            SetCtrlSetting();
        }

        protected void Result2_Click(object sender, object[] returnArgs)
        {
            PageState = EnumState.Create;

            MainId = returnArgs[0].ToString();

            UploadExcelUserControl1.FormId = MainId;
            UploadExcelUserControl1.SourcerUserId = LoginUserInfo.UserId; //Sourcer 工號
            UploadExcelUserControl1.UpLoadMode = EnumUploadMode.Main;

            SetCtrlSetting();
            
        }

        private bool IsShowResponseExcel(string formId,EnumFormstatus status)
        {
            bool isShowEdit = false;
            
            switch (status)
            {
                case EnumFormstatus.Y:

                    //瀏覽模式
                    UCResponseQuery1.FormId = formId;
                    UCResponseQuery1.SourcerUserId = LoginUserInfo.UserId;
                    UCResponseQuery1.SourcerUserCompanyId = LoginUserInfo.CompanyId;

                    //lnkPrint.Visible = !isShowEdit;
                    lnkSave.Visible = isShowEdit;
                    break;
                case EnumFormstatus.N:

                    //修改模式
                    isShowEdit = true;

                    //給三個代號取得資料
                    UCResponse1.FormId = formId;
                    UCResponse1.SourcerUserId = LoginUserInfo.UserId;
                    UCResponse1.SourcerUserCompanyId = LoginUserInfo.CompanyId;

                    //lnkPrint.Visible = !isShowEdit;
                    lnkSave.Visible = isShowEdit;

                    break;
            }

            return isShowEdit;
        }

        /// <summary>
        /// 下載Excel檔案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkPrint_Click(object sender, EventArgs e)
        {
            EnumFormstatus enumFormStatus = FormStatus;

            string sFile = "";

            switch (enumFormStatus)
            {
                case EnumFormstatus.Y:

                    sFile = UCResponseQuery1.DownLoadExcel();

                    break;
                case EnumFormstatus.N:

                    sFile = UCResponse1.DownLoadExcel();

                    break;
            }
            
            //string sFile=UCResponseQuery1.DownLoadExcel();



            Response.AppendHeader("Content-disposition", String.Format("attachment; filename={0}-{1}.xls", DateTime.Now.ToString("yyyyMMdd"),this.LoginUserInfo.UserEnglishName));
            Response.ContentType = "Application/vnd.ms-excel";
            Response.WriteFile(sFile);
            Response.End();
        }

        /// <summary>
        /// 上傳Excel資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkUploadExcel_Click(object sender, EventArgs e)
        {
            DateTime myDate = new DateTime(2009, 6, 23);

            if (DateUtil.DateDiff(DateInterval.Day, DateTime.Now, myDate) > 0)
            {
                PageState = EnumState.Create;

                UploadExcelUserControl1.FormId = FormId;
                UploadExcelUserControl1.SourcerUserId = LoginUserInfo.UserId; //Sourcer 工號

                SetCtrlSetting();
            }
            else
            {
                ShowAjaxAlertMessage(lnkUploadExcel, "此上傳功能己取消");
            }
            
            

            
            
        }

        /// <summary>
        /// 回到第二頁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkBack2_Click(object sender, EventArgs e)
        {
            if (MainId == "")
            {
                PageState = EnumState.Modify;

                bool isShowEdit = false;

                isShowEdit = IsShowResponseExcel(FormId, FormStatus);


                SetUserCtrlSetting(isShowEdit);
                SetCtrlSetting();
            }
            else
            {
                InitPage(false);
            }

            

            //PageState = EnumState.Modify;

            ////bool isShowEdit = IsShowResponseExcel(FormId, FormStatus);


            //SetCtrlSetting();
            ////SetUserCtrlSetting(isShowEdit);
        }

        /// <summary>
        /// 細看BOM資訊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkViewBom_Click(object sender, EventArgs e)
        {
            this.OpenNewWindow("QueryFormBom.aspx?FormNo="+FormId);
        }
    }
}
