using System;
using System.Collections.Generic;
using System.Text;

using BatchLibrary.App;
using System.Collections.Specialized;
using AsusLibrary.Logic;
using System.IO;
using System.Reflection;
using Asus.Entity;
using Asus.DBDesign.Attribute;
using Asus.DBDesign.Map;
using Asus.DBDesign.Logic;

namespace BatchLibrary
{
    /// <summary>
    /// 本功能正常
    /// </summary>
    public class GenDbSchemaBatch:BaseApp
    {
        public GenDbSchemaBatch()
            : base()
        { }

        public override int DoJob(string batchName)
        {
            WriteLog("Job Start");

            EnumStatus status = EnumStatus.none;
            try
            {

                NameValueCollection list = LoginInfo.GetDBSchemaList();

                foreach (string s in list.AllKeys)
                {
                    WriteLog("開始擷取參數設定");

                    WriteLog(String.Format("Key={0},Value={1}", s, list[s]));

                    GenSqlFile(s);

                }


                WriteLog("Job Finish");


                status = EnumStatus.success;
                return 1;
            }
            catch (Exception ex)
            {
                WriteLog("程式失敗：" + ex.InnerException.ToString() + ex.Message + ex.StackTrace);
                status = EnumStatus.fail;
                return 0;
            }
        }

        /// <summary>
        /// 取得所有的Schema
        /// 將其內容放置一個File 檔
        /// </summary>
        /// <param name="schemaGroup"></param>
        private void GenSqlFile(string schema)
        {

            SchemaLogic logic = new SchemaLogic();

            Type exType = logic.GetSchemaType(schema);

            if (exType == null)
            {
                WriteLog("無法取得此Schema底下Type，請查明");

                throw new Exception("無法取得此Schema底下Type，請查明");
            }


            DBMap db = logic.GetDBmapFromSchema(exType);

            StringCollection sc = logic.GenDBSchema(db);

            StringBuilder sb = new StringBuilder();

            foreach (string s in sc)
            {
                sb.Append(s + Environment.NewLine);
            }

            //寫入文件檔案中
            WriteLog("產生文件");

            if (!Directory.Exists(LoginInfo.SchemaScriptDocPath))
            {
                Directory.CreateDirectory(LoginInfo.SchemaScriptDocPath);
            }

            string TemplateFilePath = String.Format("{0}\\{1}", LoginInfo.SchemaScriptDocPath, DateTime.Now.ToString("yyyyMMdd") + "-" + db.Version.GroupId + "-" + db.Version.Version + ".sql");

            WriteLog("取得此檔案範本=" + TemplateFilePath);

            FileInfo file = new FileInfo(TemplateFilePath);

            string script = sb.ToString();

            using (StreamWriter sw = new StreamWriter(TemplateFilePath))
            {
                sw.Write(script);
            }

            WriteLog("文件產生");


        }
    }
}
