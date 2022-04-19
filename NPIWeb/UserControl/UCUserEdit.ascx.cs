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

using AsusLibrary.WebPage.UserControl;
using AsusLibrary.Entity;
using Asus;
using AsusLibrary.Utility;
using AsusLibrary.Logic;
using AsusLibrary;
using AsusLibrary.Config;

using AsusWeb.Page;


namespace AsusWeb.UserControl
{
    public partial class UCUserEdit : BaseControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //取得目前的狀態
            EnumState state = EnumUtil.StringToEnum<EnumState>(lbPageState.Text);

            this.CreateTable<UserEntity>("A", "~/Layout/TableLayout.ascx", ph1,state, Asus.EnumTableColumn.OneColumn, "", "", "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 工號資料
        /// </summary>
        public string AccountNo
        {
            set
            {
                ViewState["AccountNo"] = value;
            }
            get
            {
                if (ViewState["AccountNo"] == null)
                {
                    throw new Exception("無法取得工號資料");
                }
                return ViewState["AccountNo"].ToString();
            }

        }
       
        public void Show()
        {
            if (PageState == EnumState.Modify || PageState==EnumState.Query)
            {
                UserLogic logic = new UserLogic();

                UserEntity obj = logic.QueryPMInfo(AccountNo, LoginInfo.Company);

                this.SetClassValueToControl("A", obj, PageState);
            }
        }

        /// <summary>
        /// 存檔
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            UserLogic logic = new UserLogic();

            UserEntity obj = OnSave<UserEntity>("A");
                

            if (PageState == EnumState.Create)
            {
                //先確定是否有此人存在
                EmployeeEntity emp = logic.GetUserInfo(obj.AccountNo, LoginInfo.Company);

                string userName = String.Format("{0}({1})", emp.EmpEnglishName, emp.EmpChineseName);

                if (userName == "")
                {
                    ShowAlertMessage("此帳號不存在");
                    return false;

                }
                else
                {
                    obj.AccountName = userName;

                    obj.Role = EnumRole.PM.ToString();
                    obj.CompanyId = emp.CompanyId;
                    obj.CreateUser = LoginUserInfo.LoginId;
                    obj.CreateTime = DateTime.Now.ToString();
                    obj.UpdateUser = LoginUserInfo.LoginId;
                    obj.UpdateTime = DateTime.Now.ToString();

                    return  logic.Insert<UserEntity>(obj,DataBaseDB.NPIDB);
                }

                
            }
            else if (PageState == EnumState.Modify)
            {
                obj.Role = EnumRole.PM.ToString();
                obj.CompanyId = LoginInfo.Company;
                obj.UpdateUser = LoginUserInfo.LoginId;
                obj.UpdateTime = DateTime.Now.ToString();

                return logic.UpdateDB<UserEntity>(obj,DataBaseDB.NPIDB);
            }
            

            return false;
        }

       




    }
}