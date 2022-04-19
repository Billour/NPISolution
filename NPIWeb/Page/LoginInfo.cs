using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;

using Asus.Bussiness.Map;

namespace AsusWeb.Page
{
    /// <summary>
    /// 設定資料庫連線部份
    /// </summary>
    public  class LoginInfo
    {
        private static string env=ConfigurationSettings.AppSettings["Environment"];

        #region Base Set

        /// <summary>
        /// 取得執行公司人員設定
        /// 此參數是針對執行人員的公司設定
        /// 最主要的是關使用人員資料的資料取得，必須要知道是那裡的公司在使用
        /// </summary>
        public static string Company
        {

            get { return GetBaseConfigValue("Company");}
        }

        /// <summary>
        /// 是否在Debug模式，如果是DeBug模式，會以一位模擬人員
        /// </summary>
        public static string IsDebug
        {

            get { return GetBaseConfigValue("IsDebug"); }
        }

        /// <summary>
        /// 模擬人員帳號
        /// </summary>
        public static string DeBugUserLoginId
        {

            get { return GetBaseConfigValue("DeBugUserLoginId"); }
        }

        /// <summary>
        /// Admin User
        /// </summary>
        public static string AdminUserLoginId
        {

            get { return GetBaseConfigValue("AdminUserLoginId"); }
        }

        /// <summary>
        /// 取得Excel檔案放置目錄
        /// </summary>
        public static string ExcelFileUpload
        {
            get { return GetBaseConfigValue("ExcelFileUpload"); }
        }

        #endregion 


        #region DB Connection String List

        /// <summary>
        /// 取得所有的資料庫連線
        /// </summary>
        public static NameValueCollection DBConnectStringList
        {

            get { return GetDBConnStringList(); }
        }

        /// <summary>
        /// 取得所有的資料庫資料
        /// </summary>
        public static NameValueCollection DBTypeList
        {
            get { return GetDBTypeList(); }
        }

        /// <summary>
        /// 取得Exception Users
        /// </summary>
        public static NameValueCollection ExceptionUsers
        {
            get { return QueryExceptionUserList(); }
        }

        public static List<DbConnStringMap> SystemDbList
        {
            get 
            {
                List<DbConnStringMap> mapList = new List<DbConnStringMap>();

                NameValueCollection list = LoginInfo.DBConnectStringList;

                NameValueCollection typeList = LoginInfo.DBTypeList;

                foreach (string s in list.Keys)
                {
                    mapList.Add(new DbConnStringMap(s, list[s].ToString(), typeList[s + "_Type"].ToString()));
                    
                }

                return mapList;
            }
        }
        
        #endregion



        private static string GetBaseConfigValue(string key)
        {
            if (env == null)
            {
                env = "Default";
            }

            if (ConfigurationSettings.GetConfig("Asus/" + env + "/Base") == null)
            {
                throw new Exception("無法取得此區段" + env + "的參數");
            }

            NameValueCollection di = (NameValueCollection)ConfigurationSettings.GetConfig("Asus/" + env + "/Base");

            if (di.Count == 0)
            {
                throw new Exception(String.Format("無法取得此區段/{0}/{1}的設定參數，請確定WebConfig有此區段的設定值",env,key));
            }

            
            return di[key].ToString();


        }

        private static NameValueCollection QueryExceptionUserList()
        {
            NameValueCollection di;

            if (env == null)
            {
                env = "Default";
            }

            di = (NameValueCollection)ConfigurationSettings.GetConfig("Asus/" + env + "/Accounts/UserId");

            if (di.Count == 0)
            {
                throw new Exception("無法取得此Exception User List區段" + env + "的設定參數，請確定WebConfig有此區段的設定值");
            }

            return di;


        }
        

        private static NameValueCollection GetDBConnStringList()
        {
            NameValueCollection di;

            if (env ==null)
            {
                env = "Default";             
            }
          
            di = (NameValueCollection)ConfigurationSettings.GetConfig("Asus/" + env + "/DBCoonection/DBConnString");

            if (di.Count == 0)
            {
                throw new Exception("無法取得此區段" + env + "的設定參數，請確定WebConfig有此區段的設定值");
            }

            return di;


        }

        private static NameValueCollection GetDBTypeList()
        {
            NameValueCollection di;

            if (env == null)
            {
                env = "Default";
            }

            di = (NameValueCollection)ConfigurationSettings.GetConfig("Asus/" + env + "/DBCoonection/DBType");

            if (di.Count == 0)
            {
                throw new Exception("無法取得此區段" + env + "的設定參數，請確定WebConfig有此區段的設定值");
            }

            return di;


        }


    }
}
