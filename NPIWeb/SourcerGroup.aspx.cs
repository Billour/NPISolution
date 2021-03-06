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
    /// 採購人員設定檔
    /// </summary>
    public partial class SourcerGroup : BasePage
    {
        /// <summary>
        /// 這裡寫程式代號，做為將來權限使用
        /// </summary>
        private string programId = "Config";
        private EnumRole[] roles = new EnumRole[] { EnumRole.Admin, EnumRole.Management };

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Sourcer 人員設定";

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
                UCSourcerCreate1.PageState = PageState;
                UCSourcerCreate1.Show();
            }
            else if (PageState == EnumState.Modify)
            {
                UCSourcerEdit1.PageState = PageState;
                UCSourcerEdit1.Show();
              

            }
            else if (PageState == EnumState.Query)
            {

                //查詢畫面資料
                UCSourcerList1.PageState = PageState;
                UCSourcerList1.Show();

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

        //存檔
        protected void lnkSave_Click(object sender, EventArgs e)
        {
            if (UCSourcerEdit1.Save())
            {
                ShowAlertMessage("資料已經更新");
                InitPage(false);
            }
        }

        protected void lnkCreateSave_Click(object sender, EventArgs e)
        {

            if (UCSourcerCreate1.Save())
            {
                ShowAlertMessage("資料已經新增");
                InitPage(false);
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

        protected void Result_Click(object sender, object[] returnArgs)
        {

            PageState = EnumState.Modify;
            UCSourcerEdit1.AccountNo = returnArgs[0].ToString();
            SetUserCtrlSetting();
            SetCtrlSetting();
        }
    }
}
