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
        /// �o�̼g�{���N���A�����N���v���ϥ�
        /// </summary>
        private string programId = "";
        private EnumRole[] roles = new EnumRole[] { EnumRole.Admin,EnumRole.PM};


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "PM Booking BOM";

            

            if (!IsAuth(roles))
            {
                ShowAjaxAlertMessage(lbTitle, "�A�L���v���i�J");

                //ShowAlertMessage("�A�L���v���i�J");

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
        private void SetUserCtrlSetting()
        {
            //�s�W�Ҧ�
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
                
                //�d�ߵe�����
                UCBOMList1.PMAccountNo = LoginUserInfo.UserId;
                UCBOMList1.PageState = PageState;
                UCBOMList1.Show();

            }

        }




        /// <summary>
        /// �s�W���s
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
        /// �^�W�@��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkBack_Click(object sender, EventArgs e)
        {
            InitPage(false);
        }

        /// <summary>
        /// �s�ɸ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkSave_Click(object sender, EventArgs e)
        {
            if (UCBOM1.Valid())
            {
                if (UCBOM1.Save())
                {
                    ShowAjaxAlertMessage(lbTitle, "��Ƥw�g��s");
                    //ShowAlertMessage("��Ƥw�g��s");
                    InitPage(false);
                }
            }


        }

        /// <summary>
        /// ��Ʒs�W
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkCreateSave_Click(object sender, EventArgs e)
        {
            if(UCBOMCreate1.Valid())
            {
                if (UCBOMCreate1.Save())
                {
                    ShowAjaxAlertMessage(lbTitle, "��Ƥw�g�s�W");
                    //ShowAlertMessage("��Ƥw�g�s�W");
                    InitPage(false);
                } 
            }

           
        }

        /// <summary>
        /// �s�W���s�^�W�@��
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
        /// �U��BOM�d��
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
