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
    /// ���\�ॿ�`
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
                    WriteLog("�}�l�^���ѼƳ]�w");

                    WriteLog(String.Format("Key={0},Value={1}", s, list[s]));

                    GenSqlFile(s);

                }


                WriteLog("Job Finish");


                status = EnumStatus.success;
                return 1;
            }
            catch (Exception ex)
            {
                WriteLog("�{�����ѡG" + ex.InnerException.ToString() + ex.Message + ex.StackTrace);
                status = EnumStatus.fail;
                return 0;
            }
        }

        /// <summary>
        /// ���o�Ҧ���Schema
        /// �N�䤺�e��m�@��File ��
        /// </summary>
        /// <param name="schemaGroup"></param>
        private void GenSqlFile(string schema)
        {

            SchemaLogic logic = new SchemaLogic();

            Type exType = logic.GetSchemaType(schema);

            if (exType == null)
            {
                WriteLog("�L�k���o��Schema���UType�A�Ьd��");

                throw new Exception("�L�k���o��Schema���UType�A�Ьd��");
            }


            DBMap db = logic.GetDBmapFromSchema(exType);

            StringCollection sc = logic.GenDBSchema(db);

            StringBuilder sb = new StringBuilder();

            foreach (string s in sc)
            {
                sb.Append(s + Environment.NewLine);
            }

            //�g�J����ɮפ�
            WriteLog("���ͤ��");

            if (!Directory.Exists(LoginInfo.SchemaScriptDocPath))
            {
                Directory.CreateDirectory(LoginInfo.SchemaScriptDocPath);
            }

            string TemplateFilePath = String.Format("{0}\\{1}", LoginInfo.SchemaScriptDocPath, DateTime.Now.ToString("yyyyMMdd") + "-" + db.Version.GroupId + "-" + db.Version.Version + ".sql");

            WriteLog("���o���ɮ׽d��=" + TemplateFilePath);

            FileInfo file = new FileInfo(TemplateFilePath);

            string script = sb.ToString();

            using (StreamWriter sw = new StreamWriter(TemplateFilePath))
            {
                sw.Write(script);
            }

            WriteLog("��󲣥�");


        }
    }
}
