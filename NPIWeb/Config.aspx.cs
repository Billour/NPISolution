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
    /// �ϥΪ̳]�w�{��
    /// </summary>
    public partial class Config : BasePage
    {
        /// <summary>
        /// �o�̼g�{���N���A�����N���v���ϥ�
        /// </summary>
        private string programId = "Config";
        private EnumRole[] roles = new EnumRole[] { EnumRole.Admin, EnumRole.Management };

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "PM �H���]�w";

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

        /// <summary>
        /// <code>
        ///     private void InitPage(bool isInit)
        ///     {
        ///    PageState = EnumState.Query;
        ///    SetCtrlSetting();
        ///    SetUserCtrlSetting();
        ///    }
        /// </code>
        /// </summary>
        /// <param name="isInit"></param>
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
        private void  SetCreateMode(bool isNew)
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
                UCUserCreate1.PageState = PageState;
                UCUserCreate1.Show();
            }
            else if (PageState == EnumState.Modify)
            {
                UCUserEdit1.PageState = PageState;
                UCUserEdit1.Show();
                

            }
            else if (PageState == EnumState.Query)
            {

              //�d�ߵe�����
                UCUserList1.PageState = PageState;
                UCUserList1.Show();

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
        /// ��s�s��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkSave_Click(object sender, EventArgs e)
        {

            if (UCUserEdit1.Save())
            {
                ShowAlertMessage("��Ƥw�g��s");
                InitPage(false);
            }

            
        }

        /// <summary>
        /// �s�W���s
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkCreateSave_Click(object sender, EventArgs e)
        {
            if (UCUserCreate1.Save())
            {
                ShowAlertMessage("��Ƥw�g�s�W");
                InitPage(false);
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

        protected void Result_Click(object sender, object[] returnArgs)
        {

            PageState = EnumState.Modify;
            UCUserEdit1.AccountNo = returnArgs[0].ToString();
            SetUserCtrlSetting();
            SetCtrlSetting();
        }

      
    }
}
