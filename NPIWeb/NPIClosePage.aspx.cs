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
    public partial class NPIClosePage : BasePage
    {
        private string programId = "";

        private EnumRole[] roles = new EnumRole[] { EnumRole.Admin,EnumRole.Management};

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "�޲z�̵���";

            if (!IsAuth(roles))
            {
                ShowAlertMessage("�A�L���v���i�J");

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
                    throw new Exception("�L�k���o���⫬�A");
                }
                return (EnumFormstatus)ViewState["FormStatus"];
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
                    throw new Exception("�L�k���oFormId�N���A�Ьd����]");
                }
                return ViewState["FormId"].ToString();
            }

        }

        private string PMId
        {
            set
            {
                ViewState["PMId"] = value;


            }
            get
            {
                if (ViewState["PMId"] == null)
                {
                    throw new Exception("�L�k���oFormId�N���A�Ьd����]");
                }
                return ViewState["PMId"].ToString();
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
        /// �]�w�s�W�Ҧ�
        /// </summary>
        /// <param name="isNew"></param>
        private void SetCreateMode(bool isNew)
        {
            pnlCreate.Visible = isNew;
            pnlCreate2.Visible = isNew;
        }

        /// <summary>
        /// �]�w�ק�Ҧ�
        /// </summary>
        /// <param name="isEdit"></param>
        private void SetEditMode(bool isEdit)
        {
            pnlEdit.Visible = isEdit;
            pnlEdit2.Visible = isEdit;
        }

        /// <summary>
        /// �]�w�s���Ҧ�
        /// </summary>
        /// <param name="isBrower"></param>
        private void SetBrowerMode(bool isBrower)
        {
            pnlQuery.Visible = isBrower;
            pnlQuery2.Visible = isBrower;
        }

        /// <summary>
        /// �]�wUserControl�����p

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

            }

        }

        /// <summary>
        /// �^�W�@��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkBack_Click(object sender, EventArgs e)
        {
            InitPage(false);
        }

        //�s��
        protected void lnkSave_Click(object sender, EventArgs e)
        {

            if (UCResponse1.Save())
            {
                ShowAlertMessage("��Ƥw�g��s");
                InitPage(false);
            }

        }

        protected void Result_Click(object sender, object[] returnArgs)
        {
            string formId = returnArgs[0].ToString();

            string status = returnArgs[1].ToString();

            string pmId = returnArgs[2].ToString();

            PMId = returnArgs[2].ToString();

            string pmCompanyId = returnArgs[3].ToString();

            PageState = EnumState.Modify;

            bool isShowEdit = false;

            EnumFormstatus enumFormStatus = EnumUtil.StringToEnum<EnumFormstatus>(status);

            FormStatus = enumFormStatus; //�]�w�ثe��Form ���A

            switch (enumFormStatus)
            {
                case EnumFormstatus.Y:

                    //�s���Ҧ�
                    FormId = formId;
                    UCResponseQuery1.FormId = formId;
                    UCResponseQuery1.SourcerUserId = LoginUserInfo.UserId;
                    UCResponseQuery1.SourcerUserCompanyId = LoginUserInfo.CompanyId;
                    UCResponseQuery1.PMCompanyId = pmCompanyId;
                    UCResponseQuery1.PMUserId = pmId;

                    //lnkPrint.Visible = !isShowEdit;
                    lnkSave.Visible = isShowEdit;
                    lnkClose.Visible = isShowEdit;
                    break;
                case EnumFormstatus.N:

                    //�ק�Ҧ�
                    isShowEdit = true;

                    //���T�ӥN�����o���
                    FormId = formId;
                    UCResponse1.FormId = formId;
                    UCResponse1.SourcerUserId = LoginUserInfo.UserId;
                    UCResponse1.SourcerUserCompanyId = LoginUserInfo.CompanyId;
                    UCResponse1.PMCompanyId = pmCompanyId;
                    UCResponse1.PMUserId = pmId;

                    //lnkPrint.Visible = !isShowEdit;
                    lnkSave.Visible = isShowEdit;
                    lnkClose.Visible = isShowEdit;

                    break;
            }




            SetUserCtrlSetting(isShowEdit);
            SetCtrlSetting();
        }

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

            //string sFile = UCResponseQuery1.DownLoadExcel();

            //Response.AppendHeader("Content-disposition", String.Format("attachment; filename={0}-{1}.xls", DateTime.Now.ToString("yyyyMMdd"), this.LoginUserInfo.LoginId + this.LoginUserInfo.UserChineseName));
            Response.AppendHeader("Content-disposition", String.Format("attachment; filename={0}-{1}.xls", DateTime.Now.ToString("yyyyMMdd"),PMId));
            Response.ContentType = "Application/vnd.ms-excel";
            Response.WriteFile(sFile);
            Response.End();
        }

        protected void lnkClose_Click(object sender, EventArgs e)
        {
            if (UCResponse1.CloseForm())
            {
                ShowAlertMessage("���ק���");
                InitPage(false);
            }
        }

        protected void lnkViewBom_Click(object sender, EventArgs e)
        {
            this.OpenNewWindow("QueryFormBom.aspx?FormNo=" + FormId);
        }
    }
}
