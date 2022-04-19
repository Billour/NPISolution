using System;
using System.Collections.Generic;
using System.Text;

using BatchLibrary.App;


using AsusLibrary.Entity;
using AsusLibrary.Logic;
using Asus.Data;
using System.IO;
using System.Net.Mail;
using AsusLibrary.Utility;


namespace BatchLibrary
{
    /// <summary>
    /// 產生Sourcer 與PN 的Map檔
    /// 本功能取消
    /// </summary>
    public class GenSourcerMapBatch:BaseApp
    {
        public GenSourcerMapBatch()
            : base()
        { }

        public override int DoJob(string batchName)
        {
            WriteLog("Job Start");

            EnumStatus status = EnumStatus.none;
            try
            {
                //GenSourcerMapJob();

                status = EnumStatus.success;
                return 1;
            }
            catch (Exception ex)
            {
                WriteLog("程式失敗：" + ex.InnerException.ToString() + ex.Message + ex.StackTrace);
                status = EnumStatus.fail;
                return 0;
            }

            //return 1;
        }

        

        /// <summary>
        /// 產生Sourcer資料的Mapping檔
        /// 用來做分類使用
        /// </summary>
        private void GenSourcerMapJob()
        {
            SourcerLogic logic = new SourcerLogic();

            SortedList<string, List<SourcerPNMapEntity>> slist = logic.GetWaitingPNNotExistSourcerMap();

            foreach (string key in slist.Keys)
            {
                foreach (SourcerPNMapEntity t in slist[key])
                {
                    t.CompanyId = LoginInfo.Company;
                }
            }


            if (logic.InsertSourcePNMap(slist["N"], slist["U"]))
            {
                WriteLog("資料新增完畢");
            }
            else
            {
                WriteLog("資料新增失敗");
                throw new Exception("資料新增失敗");
            }

            //通知管理者找不到Sourcer對應資料
            string mailServer = LoginInfo.MailServer;

            int mailPort = Convert.ToInt16(LoginInfo.MailPort);

            string from = "srm@asus.com.tw";

            string date = DateTime.Now.ToString();

            string subject = String.Format("{0}-NPI-尚未取得元件料號與Sourcer對應資料列表", DateTime.Now.ToString("yyyy/MM/dd"));

            string to = "";

            to += LoginInfo.AttachTo;

            bool isHasAttach = true;

            //將需要報價的資料找出
            List<SourcerPNMapEntity> pnList = slist["Y"];

            if (pnList.Count == 0)
            {
                isHasAttach = false;
            }

            string workFile = "";

            if (isHasAttach)
            {
                WriteLog("開始寫入Excel");

                string templateFile = Environment.CurrentDirectory + "\\priceTemplate.xls";
                WriteLog(String.Format("下載Excel-路徑={0}", templateFile));

                WriteLog("設定下載檔案");

                string targetPath = Environment.CurrentDirectory + String.Format("\\TempDoc{0}", DateTime.Now.ToString("yyyyMMdd"));

                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }

                string saveFile = targetPath + String.Format("\\NPI_NoSourcerPN_{0}.xls", Convert.ToDateTime(date).ToString("MMdd"));
                WriteLog(String.Format("下載Excel-路徑={0}", saveFile));

                ExcelLogic eLogic = new ExcelLogic(templateFile, saveFile);


                if (eLogic.GeneratePNFile(pnList))
                {
                    WriteLog("文件建立成功");
                    workFile = saveFile;
                }
                else
                {
                    throw new Exception("無法建立Excel檔案，請查明原因");
                }
            }

            string body = "";

            if (isHasAttach)
            {
                body = "<p>Dear ALL:</p>";

                body += "<p>附件為需確認PN元件的Sourcer之資料列表, 目前在系統尚取得此PN料號的使用者</p>";

                string title = String.Format(" System send this mail to inform you this Info. Current Time: {0}", date);

                body += String.Format("<p>{0}</p>", title);

                body += "<div><img src=cid:mylogo></div>";

                List<LinkedResource> rList = new List<LinkedResource>();

                LinkedResource resource = new LinkedResource(Environment.CurrentDirectory + "/logo.gif");

                resource.ContentId = "mylogo";

                rList.Add(resource);

                //MailUtil.SendBodyHtml(mailServer, mailPort, from, to, subject, body, true, new string[] { workFile }, rList);

            }


        }
    }
}
