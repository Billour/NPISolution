using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

using System.Collections.Specialized;
using AsusWeb.Page;
using AsusLibrary.Entity;
using AsusLibrary.Logic;

using Asus.Sercurity;
using AsusLibrary.Entity;
using Asus.Bussiness.Map;

using AsusWeb.Page;
using log4net;

namespace AsusWeb
{
    public class Global : System.Web.HttpApplication
    {
        private ILog log = LogManager.GetLogger(typeof(Global));

        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();

           
            List<DbConnStringMap> list = LoginInfo.SystemDbList;

            foreach (DbConnStringMap map in list)
            {
                Asus.Data.Configuration.DataFarm.AddConnection(map.ConnectionName,map.ConnectionString,map.DataBaseType);
            }


        }

        protected void Application_End(object sender, EventArgs e)
        {

        }


        protected void Session_Start(object sender, EventArgs e)
        {

            //取得Login User Information
            string loginId = User.Identity.Name.Split(new char[] { '\\' })[1];

            
            if (LoginInfo.IsDebug == "N" && loginId.ToLower() == LoginInfo.AdminUserLoginId.ToLower())
            {
                SetAdminUser();
            }
            else
            {
                SetUserSessionToSystem();
            }

        }
                

        private void SetAdminUser()
        {
            string loginId = LoginInfo.AdminUserLoginId;
            
            List<string> roles = new List<string>();

            string role = "Admin";

            roles.Add(role);

            LoginUserEntity user = new LoginUserEntity();

            user.UserId = "A0425";
            user.LoginId = loginId;
            user.UserChineseName = "系統管理者";
            user.UserEnglishName = "SystemAdmin";
            user.UserDomain = "asus";
            user.UserEmail = "admin@com.tw";
            user.CompanyId = "13006";

            user.Roles = roles;

            Session["LoginUserInfo"] = user;

            log4net.GlobalContext.Properties["EmpName"] = String.Format("{0}({1})", user.UserId + "-" + user.LoginId, user.UserChineseName);
        }


        private void SetUserSessionToSystem()
        {
            //Get User Information

           
            string loginId = User.Identity.Name.Split(new char[] { '\\' })[1];
            string domain = User.Identity.Name.Split(new char[] { '\\' })[0];

            log.Info(String.Format("取得此人的帳號{0}-{1}", domain, loginId));

            UserLogic logic = new UserLogic();

            //Add Special Power

            if (LoginInfo.IsDebug == "Y")
            {
                loginId = LoginInfo.DeBugUserLoginId;
            }

            if (loginId == "")
            {
                throw new Exception("取得Login人員的資料為空白，請通知系街管理員查明原因");
            }

            EmployeeEntity emp;

            //例外處理User 此狀況是發生在SRM_User 發生多筆的時候使用
            NameValueCollection exceptionUserList = LoginInfo.ExceptionUsers;

            if (exceptionUserList[loginId] != null)
            {
                emp = logic.GetEmp(loginId, LoginInfo.Company, exceptionUserList[loginId]);
            }
            else
            {
                emp = logic.GetEmp(loginId, LoginInfo.Company);
            }

            

            //EmployeeEntity emp = logic.GetEmp("Jo_Kuo", LoginInfo.Company);

            if (emp == null)
            {
                log.Error("無法取得使用者{0}//{1} 公司別{2}的資料無法取得，請查明原因");
                throw new Exception(String.Format("使用者LoginId={0},Domian={1}資料無法取得，請通知系統管理員",loginId,domain));
               
            }

            List<UserEntity> roleList = logic.QueryThisUserRoleList(emp.EmpAccountId,"Y",LoginInfo.Company);

            List<string> roles = new List<string>();

            foreach (UserEntity t in roleList)
            {
                roles.Add(t.Role);
            }

            LoginUserEntity user = new LoginUserEntity();

            user.UserId=emp.EmpAccountId;
            user.LoginId=emp.EmpLoginId;
            user.UserChineseName=emp.EmpChineseName;
            user.UserEnglishName=emp.EmpEnglishName;
            user.UserDomain=emp.EmpDomainId;
            user.UserEmail=emp.EmpDomainId;
            user.CompanyId = emp.CompanyId;

            user.Roles = roles;
                        
            Session["LoginUserInfo"]=user;

            log4net.GlobalContext.Properties["EmpName"] = String.Format("{0}({1})",user.UserId+"-"+user.LoginId, user.UserChineseName);

            
        }
    }
}