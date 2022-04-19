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
    /// <summary>
    /// Sourcer �d�߳���
    /// �̥D�n�����O��Sourcer�ϥ�
    /// ���Ѭd�ߪ��ƪ�����
    /// �C�@��Sourcer�u��d�ߪ��ۤw�����
    /// </summary>
    public partial class QueryPN : BasePage
    {
        /// <summary>
        /// �{���W��
        /// </summary>
        private string programId = "�����d��";

        private EnumRole[] roles = new EnumRole[] { EnumRole.Admin,EnumRole.Sourcer };

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "�����d��";

            if (!IsAuth(roles))
            {
                ShowAlertMessage("�A�L���v���i�J");

                Response.Redirect(Request.UrlReferrer.AbsoluteUri);
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
            if (PageState == EnumState.Query)
            {

                //�d�ߵe�����
                QueryPNPriceListUserControl1.PageState = PageState;
                QueryPNPriceListUserControl1.Show();
               

            }

        }

        
    }
}
