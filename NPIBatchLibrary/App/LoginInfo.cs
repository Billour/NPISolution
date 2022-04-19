using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;

using Asus.Bussiness.Map;
using log4net;



namespace BatchLibrary.App
{
    public class LoginInfo
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(LoginInfo));

        private static string env = ConfigurationSettings.AppSettings["Environment"];

        #region Base Set

        /// <summary>
        /// 取得執行公司人員設定
        /// 此參數是針對執行人員的公司設定
        /// 最主要的是關使用人員資料的資料取得，必須要知道是那裡的公司在使用
        /// </summary>
        public static string Company
        {

            get { return GetBaseConfigValue("Company"); }
        }

        /// <summary>
        /// Mail Server
        /// </summary>
        public static string MailServer
        {

            get { return GetBaseConfigValue("MailServer"); }
        }

        /// <summary>
        /// Mail Port
        /// </summary>
        public static string MailPort
        {

            get { return GetBaseConfigValue("MailPort"); }
        }



        public static string SendMailURL
        {

            get { return GetBaseConfigValue("SendMailURL"); }
        }

        /// <summary>
        /// 寄給主管的信的地址
        /// </summary>
        public static string SendManageMailURL
        {

            get { return GetBaseConfigValue("SendManageMailURL"); }
        }

        public static string SCMOracleClient
        {

            get { return GetBaseConfigValue("SCMOracleClient"); }
        }

        /// <summary>
        /// Buying Mode=C 的模式 的網站
        /// 
        /// 整體適用 可以多選，用逗點隔開
        /// </summary>
        public static string ConSignSite
        {

            get { return GetBaseConfigValue("ConSignSite"); }
        }

        /// <summary>
        /// User Id
        /// </summary>
        public static string MailUserId
        {

            get { return GetBaseConfigValue("MailUserId"); }
        }

        /// <summary>
        /// User User Address
        /// </summary>
        public static string MailUserPasswd
        {

            get { return GetBaseConfigValue("MailUserPasswd"); }
        }

        /// <summary>
        /// User Domain
        /// </summary>
        public static string MailUserDomain
        {

            get { return GetBaseConfigValue("MailUserDomain"); }
        }

        public static string DebugPN
        {

            get { return GetBaseConfigValue("DebugPN"); }
        }

        /// <summary>
        /// Attach To
        /// </summary>
        public static string AttachTo
        {

            get { return GetBaseConfigValue("AttachTo"); }
        }


        /// <summary>
        /// 當PM 回覆結果自動回給PM所要註記的人員
        /// 有Jo Elva
        /// </summary>
        public static string AttachRespTo
        {

            get { return GetBaseConfigValue("AttachRespTo"); }
        }

        /// <summary>
        /// 是否要寄給User 每天的信件
        /// </summary>
        public static string IsSendUserEveryDayPrice
        {

            get { return GetBaseConfigValue("IsSendUserEveryDayPrice"); }
        }

        /// <summary>
        /// 放DB Schema Script 的位置
        /// 此功能是產生Table Schema 的功能
        /// 目前只支援Create Schema，其餘的部份等待實作
        /// </summary>
        public static string SchemaScriptDocPath
        {

            get { return GetBaseConfigValue("SchemaScriptDocPath"); }
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

        public static List<DbConnStringMap> SystemDbList
        {
            get
            {
                log.Info("新增資料庫列表");
                List<DbConnStringMap> mapList = new List<DbConnStringMap>();

                log.Info("新增1");
                NameValueCollection list = LoginInfo.DBConnectStringList;

                log.Info("新增2");
                NameValueCollection typeList = LoginInfo.DBTypeList;

                log.Info("加入");
                foreach (string s in list.Keys)
                {
                    mapList.Add(new DbConnStringMap(s, list[s].ToString(), typeList[s + "_Type"].ToString()));

                }

                return mapList;
            }
        }

        /// <summary>
        /// 取得所有的DB Schema 格式
        /// 
        /// </summary>
        /// <returns></returns>
        public static NameValueCollection GetDBSchemaList()
        {

            NameValueCollection di;

            if (env == null)
            {
                env = "Default";
            }

            di = (NameValueCollection)ConfigurationSettings.GetConfig("Asus/" + env + "/DbList/Schema");

            if (di.Count == 0)
            {
                throw new Exception("無法取得此區段" + env + "的設定參數，請確定Config有此區段的設定值");
            }


            return di;


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
                throw new Exception(String.Format("無法取得此區段/{0}/{1}的設定參數，請確定WebConfig有此區段的設定值", env, key));
            }


            return di[key].ToString();


        }



        private static NameValueCollection GetDBConnStringList()
        {
            NameValueCollection di;

            if (env == null)
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

            log.Info("開始取得DBType List");

            if (env == null)
            {
                env = "Default";
            }

            log.Info("取得 Asus/" + env + "/DBCoonection/DBType");

            di = (NameValueCollection)ConfigurationSettings.GetConfig("Asus/" + env + "/DBCoonection/DBType");

            if (di.Count == 0)
            {
                throw new Exception("無法取得此區段" + env + "的設定參數，請確定WebConfig有此區段的設定值");
            }

            log.Info("傳回di="+di.Count);

            return di;


        }


        ///// <summary>
        ///// 設定資料庫連線部份
        ///// </summary>
        //public static string ConnectionString
        //{

        //    get { return getAppSettingKeyValue("ConnectionString"); }
        //}

        //public static string OleDBConnectionString
        //{

        //    get { return getAppSettingKeyValue("OleDBConnectionString"); }
        //}
      
        ///// <summary>
        ///// 設定是DEMO或RELEASE
        ///// </summary>
        //public static string WebSiteRelease
        //{

        //    get { return getAppSettingKeyValue("WebSiteRelease"); }
        //}

        // /// <summary>
        ///// 設定是DEMO或RELEASE
        ///// </summary>
        //public static string CheckCaptureURL
        //{

        //    get { return getAppSettingKeyValue("CheckCaptureURL"); }
        //}

        ///// <summary>
        ///// 要Capture 的網站
        ///// </summary>
        //public static string CaptureWebSite
        //{
        //    get { return getAppSettingKeyValue("CaptureWebSite"); }
        //}

        
        //public static string WebDll
        //{
        //    get { return getAppSettingKeyValue("WebDll"); }
        //}

        //public static string EntityExportPath
        //{
        //    get { return getAppSettingKeyValue("EntityExportPath"); }
        //}

        

        //public static string CaptureSavePath
        //{
        //    get { return getAppSettingKeyValue("CaptureSavePath"); }
        //}


        //public static string AnalysisDocTemplatePath
        //{
        //    get { return getAppSettingKeyValue("AnalysisDocTemplatePath"); }
        //}

        //public static string AnalysisDocPath
        //{
        //    get { return getAppSettingKeyValue("AnalysisDocPath"); }
        //}

        //public static string AnalysisDocFileName
        //{
        //    get { return getAppSettingKeyValue("AnalysisDocFileName"); }
        
        //}

        //public static string MujiLibraryLogDllPath
        //{
        //    get { return getAppSettingKeyValue("MujiLibraryLogDllPath"); }
        //}

        ///// <summary>
        ///// 設定 C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\CONFIG\MACHINE.CONFIG
        ///// </summary>
        ///// <param name="key"></param>
        ///// <returns></returns>

        //public static string LibraryComponentPath
        //{

        //    get { return getAppSettingKeyValue("LibraryDllPath"); }
        //}

        //public static string TableTemplateFilePath
        //{

        //    get { return getAppSettingKeyValue("TableTemplateFilePath"); }
        //}

        //public static string TargetTableDocumentDirectory
        //{

        //    get { return getAppSettingKeyValue("TargetTableDocumentDirectory"); }
        //}
        
        ////<!--HTML Table Schema 範本路徑 附檔名為st -->
        ////<add key="HtmlTableTemplateRootPath" value="c:\\BankPro\\target\\batch"/>
        ////<add key="HtmlTableTemplateFileName" value="DBTableTemplate"/>
        ////<add key="TargetHTMLTableDocumentDirectory" value="c:\\BankPro\\target\\html\\"/>

        ///// <summary>
        ///// HTML 放置Table Schema範本的地方 Root Directory
        ///// </summary>
        //public static string HtmlTableTemplateRootPath
        //{

        //    get { return getAppSettingKeyValue("HtmlTableTemplateRootPath"); }
        //}


        ///// <summary>
        ///// HTML 放置HTML範本的檔案名稱，記得要捨去副檔名
        ///// </summary>
        ///// <remarks>
        /////     1.例如 檔案名稱=DBTableTemplate.st ，
        /////     請設定時用 <add key="HtmlTableTemplateFileName" value="DBTableTemplate"/> 沒有副檔名
        ///// </remarks>
        //public static string HtmlTableTemplateFileName
        //{

        //    get { return getAppSettingKeyValue("HtmlTableTemplateFileName"); }
        //}


        // public static string SQLScriptTargetDocumentDirectory
        //{

        //    get { return getAppSettingKeyValue("SQLScriptTargetDocumentDirectory"); }
        //}

        ////Entity 

        //public static string EntityTemplateRootPath
        //{

        //    get { return getAppSettingKeyValue("EntityTemplateRootPath"); }
        //}

        // public static string EntityTemplateFileName
        //{

        //    get { return getAppSettingKeyValue("EntityTemplateFileName"); }
        //}

        // public static string TargetEntityTableDocumentDirectory
        //{

        //    get { return getAppSettingKeyValue("TargetEntityTableDocumentDirectory"); }
        //}

        ///// <summary>
        ///// HTML最後的放置位置
        ///// </summary>
        //public static string TargetHTMLTableDocumentDirectory
        //{

        //    get { return getAppSettingKeyValue("TargetHTMLTableDocumentDirectory"); }
        //}

        ///// <summary>
        ///// 產生分析文件-版本
        ///// </summary>
        //public static string DocVersion
        //{

        //    get { return getAppSettingKeyValue("Version"); }
        //}


        //public static string DocSystemName
        //{

        //    get { return getAppSettingKeyValue("SystemName"); }
        //}


        //public static string DocCompany
        //{

        //    get { return getAppSettingKeyValue("Company"); }
        //}

        

        
        ///// <summary>
        ///// 取得一筆資料庫連線字串
        ///// 給我一個Key 給你一個連線字串
        ///// </summary>
        ///// <param name="key"></param>
        ///// <returns></returns>
        //public static string GetConnectionString(string key)
        //{
        //    NameValueCollection di=GetConnectionStringList();

        //    return di[key].ToString();
        //}

        ///// <summary>
        ///// 新的Word範本檔案名稱(符合Muji)
        ///// </summary>
        //public static string DBTemplatePath
        //{

        //    get { return getAppSettingKeyValue("DBTemplatePath"); }
        //}

        ///// <summary>
        ///// DBFileOutput
        ///// </summary>
        //public static string DBFileOutput
        //{

        //    get { return getAppSettingKeyValue("DBFileOutput"); }
        //}


        //private static string getAppSettingKeyValue(string key)
        //{
        //    string env = "";

        //    env = ConfigurationSettings.AppSettings["Environment"].ToString();

        //    if (env.Equals(""))
        //    {
        //        throw new Exception("無法取得環境參數，請確定AppSettings 中有Environment此參數");
        //    }

        //    NameValueCollection di = (NameValueCollection)ConfigurationSettings.GetConfig("BankPro/" + env+"/Base");

        //    if (di.Count == 0)
        //    {
        //        throw new Exception("無法取得此區段" + env + "的設定參數，請確定WebConfig有此區段的設定值");
        //    }

        //    return di[key].ToString();


        //}

        // /// <summary>
        ///// 加入商品的ConnectionString
        ///// </summary>
        ///// <param name="key"></param>
        ///// <returns></returns>
        //private static NameValueCollection GetConnectionStringList()
        //{
        //    string env = "";

        //    env = ConfigurationSettings.AppSettings["Environment"].ToString();

        //    if (env.Equals(""))
        //    {
        //        throw new Exception("無法取得環境參數，請確定AppSettings 中有Environment此參數");
        //    }

        //    NameValueCollection di = (NameValueCollection)ConfigurationSettings.GetConfig("BankPro/" + env+"/ConnectionList/ConnectionString");

        //    if (di.Count == 0)
        //    {
        //        throw new Exception("無法取得此區段" + env + "的設定參數，請確定WebConfig有此區段的設定值");
        //    }

        //    return di;


        //}

        //  /// <summary>
        ///// 加入分析文件的資料
        ///// </summary>
        ///// <param name="key"></param>
        ///// <returns></returns>
        //public static NameValueCollection GetDocList()
        //{
        //    string env = "";

        //    env = ConfigurationSettings.AppSettings["Environment"].ToString();

        //    if (env.Equals(""))
        //    {
        //        throw new Exception("無法取得環境參數，請確定AppSettings 中有Environment此參數");
        //    }

        //    NameValueCollection di = (NameValueCollection)ConfigurationSettings.GetConfig("BankPro/" + env+"/DocList/Doc");

        //    if (di.Count == 0)
        //    {
        //        throw new Exception("無法取得此區段" + env + "的設定參數，請確定WebConfig有此區段的設定值");
        //    }

        //    return di;


        //}

        //public static NameValueCollection GetConnectionList()
        //{
        //    string env = "";

        //    env = ConfigurationSettings.AppSettings["Environment"].ToString();

        //    if (env.Equals(""))
        //    {
        //        throw new Exception("無法取得環境參數，請確定AppSettings 中有Environment此參數");
        //    }

        //    NameValueCollection di = (NameValueCollection)ConfigurationSettings.GetConfig("BankPro/" + env+"/ConnectionList/ConnectionString");

        //    if (di.Count == 0)
        //    {
        //        throw new Exception("無法取得此區段" + env + "的設定參數，請確定WebConfig有此區段的設定值");
        //    }

        //    return di;


        //}

        
    }
}
