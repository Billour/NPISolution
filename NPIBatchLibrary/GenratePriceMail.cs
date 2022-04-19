using System;
using System.Collections.Generic;
using System.Text;

using BatchLibrary.App;
using ASUS.B2B.SRM.BusinessTier;
using ASUS.B2B.SRM.DataTier;

using AsusLibrary.Entity;
using AsusLibrary.Logic;

using AsusLibrary.Utility;

using Asus.Data;
using System.Net.Mail;
using System.IO;

namespace BatchLibrary
{
    /// <summary>
    /// 每天寄信給Sourcer
    /// 本功能取消
    /// </summary>
    public class GenratePriceMail : BaseApp
    {
        public GenratePriceMail()
            : base()
        { }

        public override int DoJob(string batchName)
        {
            WriteLog("Job Start");

            EnumStatus status = EnumStatus.none;
            try
            {
                //將信件做成以人名表示
                //SendSourceMail3();


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
        /// 第三代寄信內容
        /// 是以人為主
        /// 加上料號資料/PN關係資料
        /// </summary>
        private void SendSourceMail3()
        {
            bool isFlag = false;

            //第一步驟(先取得所有的尚未議價的PN)-己經篩選過的結果，回傳以SortedList Group化分好

            SourcerLogic logic = new SourcerLogic();

            SortedList<string, SortedList<string, PNPrice2Entity>> list=logic.GetWaitingAlertSourcePrice();

            string mailServer = LoginInfo.MailServer;

            int mailPort = Convert.ToInt16(LoginInfo.MailPort);

            string from = "srm@asus.com.tw";

            //取回己經分類好議價資料，開始寄信 s=SourcerId 員工工號
            foreach(string key in list.Keys)
            {
                string date = DateTime.Now.ToString();

                WriteLog("人員=>" + key);

                UserLogic userLogic = new UserLogic();

                WriteLog("開始取得人員資料-開始");

                EmployeeEntity emp = logic.GetUserInfo(key, LoginInfo.Company);

                string subject = String.Format("{0}-NPI-{1}({2})尚未議價之元件資料列表", DateTime.Now.ToString("yyyy/MM/dd"), emp.EmpLoginId, emp.EmpChineseName);

                string to = "";

                WriteLog("Email=" + emp.EmpEmail);

                to += LoginInfo.AttachTo;

                if (emp.EmpEmail.Trim() != "")
                {
                    //先行不寄，之後調整
                    if (LoginInfo.IsSendUserEveryDayPrice == "Y")
                    {
                        to += "," + emp.EmpEmail;
                    }
                }
                else
                {
                    WriteLog("Email=" + emp.EmpAccountId + "-(請查明此人的Email是否存在)");
                }

                bool isHasAttach = true;

                //將需要報價的資料找出
                SortedList<string, PNPrice2Entity> priceList = list[key]; 

                if (priceList.Count == 0)
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

                    string saveFile = targetPath + String.Format("\\NPI_Price_{0}_{1}.xls", Convert.ToDateTime(date).ToString("MMdd"), emp.EmpLoginId);
                    WriteLog(String.Format("下載Excel-路徑={0}", saveFile));

                    ExcelLogic eLogic = new ExcelLogic(templateFile, saveFile);


                    if (eLogic.GeneratePrice2File(priceList))
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
                    body = String.Format("<p>Dear {0}({1}):</p>", emp.EmpLoginId, emp.EmpChineseName);

                    body += "<p>附件為需維護議價檔之元件料號</p>";

                    string title = String.Format(" System send this mail to inform you this Info. Current Time: {0}", date);

                    body += String.Format("<p>{0}</p>", title);

                    body += "<div><img src=cid:mylogo></div>";

                }

                List<LinkedResource> rList = new List<LinkedResource>();

                LinkedResource resource = new LinkedResource(Environment.CurrentDirectory + "/logo.gif");

                resource.ContentId = "mylogo";

                rList.Add(resource);

                if (isHasAttach)
                {
                    MailUtil.SendBodyHtml(mailServer, mailPort, from, to, subject, body, true, new string[] { workFile }, rList);
                }

            }

            WriteLog("Job Finish");
            
            
        }

        /// <summary>
        /// 第一代寄信內容
        /// 是以人為主
        /// 
        /// </summary>
        private void SendSourceMail()
        {
            bool isFlag = false;

            //第一步驟(先取得所有的尚未議價的PN)-己經篩選過的結果，回傳以SortedList Group化分好

            SourcerLogic logic = new SourcerLogic();

            SortedList<string, PNPriceEntity> notConfirmList = logic.GetNotConfirmPricePNList();

            //取得所有的Sourcer 寄信的資料(如果有符合的資料的時候)加入資料用Excel來做，如果沒有的話也寄一封信通知它不用議價。
            List<string> mailList = logic.GetAllSourcer();

            SortedList<string, List<ComponentRefEntity>> sortedMailList = new SortedList<string, List<ComponentRefEntity>>();

            foreach (string s in mailList)
            {

                sortedMailList.Add(s, logic.GetSourcerComponentList(s, LoginInfo.Company));
            }

            //寄信
            if (sortedMailList.Count > 0)
            {
                foreach (string key in sortedMailList.Keys)
                {
                    string date = DateTime.Now.ToString();

                    //開始寄信

                    WriteLog("人員=>" + key);

                    UserLogic userLogic = new UserLogic();

                    WriteLog("開始取得人員資料-開始");
                    EmployeeEntity emp = logic.GetUserInfo(key, LoginInfo.Company);

                    WriteLog("開始取得人員資料-完畢");
                    string mailServer = LoginInfo.MailServer;

                    int mailPort = Convert.ToInt16(LoginInfo.MailPort);

                    string subject = String.Format("{0}-NPI-{1}({2})尚未議價之元件資料列表", DateTime.Now.ToString("yyyy/MM/dd"), emp.EmpLoginId, emp.EmpChineseName);

                    string to = "";

                    WriteLog("Email=" + emp.EmpEmail);

                    to += LoginInfo.AttachTo;

                    if (emp.EmpEmail.Trim() != "")
                    {
                        //先行不寄，之後調整
                        if (LoginInfo.IsSendUserEveryDayPrice == "Y")
                        {
                            to += "," + emp.EmpEmail;
                        }
                    }
                    else
                    {
                        WriteLog("Email=" + emp.EmpAccountId + "-(請查明此人的Email是否存在)");
                    }

                    bool isHasAttach = true;

                    string from = "srm@asus.com.tw";

                    SortedList<string, PNPriceEntity> priceList = ConvertToNotUsedList(notConfirmList, sortedMailList[key]); //將需要報價的資料找出

                    if (priceList.Count == 0)
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

                        string saveFile = targetPath + String.Format("\\NPI_Price_{0}_{1}.xls", Convert.ToDateTime(date).ToString("MMdd"), emp.EmpLoginId);
                        WriteLog(String.Format("下載Excel-路徑={0}", saveFile));

                        ExcelLogic eLogic = new ExcelLogic(templateFile, saveFile);


                        if (eLogic.GeneratePriceFile(priceList))
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
                        body = String.Format("<p>Dear {0}({1}):</p>", emp.EmpLoginId, emp.EmpChineseName);

                        body += "<p>附件為需維護議價檔之元件料號</p>";

                        body += "<font color=red>ps:目前元件料號是以大類來設定，所以會寄發給該大類的sourcer眾人。若非料件本人，可忽略。</font><br>";

                        string title = String.Format(" System send this mail to inform you this Info. Current Time: {0}", date);

                        body += String.Format("<p>{0}</p>", title);

                        body += "<div><img src=cid:mylogo></div>";

                    }
                    else
                    {
                        body = String.Format("<p>Dear {0}({1}):</p>", emp.EmpLoginId, emp.EmpChineseName);

                        body += "<p>目前無議價檔資料需要維護</p>";

                        string title = String.Format(" System send this mail to inform you this Info. Current Time: {0}", date);

                        body += String.Format("<p>{0}</p>", title);

                        body += "<div><img src=cid:mylogo></div>";
                    }

                    List<LinkedResource> rList = new List<LinkedResource>();

                    LinkedResource resource = new LinkedResource(Environment.CurrentDirectory + "/logo.gif");

                    resource.ContentId = "mylogo";

                    rList.Add(resource);

                    if (isHasAttach)
                    {
                        MailUtil.SendBodyHtml(mailServer, mailPort, from, to, subject, body, true, new string[] { workFile }, rList);
                    }



                }

                WriteLog("Job Finish");

            }
            else
            {
                WriteLog("無資料，不需要寄信");
            }
        }

        private SortedList<string,PNPriceEntity> ConvertToNotUsedList(SortedList<string,PNPriceEntity> pnlist,List<ComponentRefEntity> groupList)
        {
            SortedList<string, PNPriceEntity> list = new SortedList<string, PNPriceEntity>();

            foreach (string s in pnlist.Keys)
            {
                foreach (ComponentRefEntity t in groupList)
                {
                    if (t.ComponentId.Trim() == s.Substring(0, 2))
                    {
                        if (!list.ContainsKey(pnlist[s].PN))
                        {
                            list.Add(pnlist[s].PN,pnlist[s]);
                        }
                        
                    }
                }
            }

            return list;
        }
    }
}
