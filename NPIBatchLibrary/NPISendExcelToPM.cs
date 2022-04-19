using System;
using System.Collections.Generic;
using System.Text;

using BatchLibrary.App;


using AsusLibrary.Entity;
using AsusLibrary.Logic;

using AsusLibrary.Utility;
using System.Net.Mail;
using System.IO;
using AsusLibrary;

namespace BatchLibrary
{
    /// <summary>
    /// 寄信給RD PM
    /// 寄送的時間點在每星期的星期五早上3:00
    /// 將系統結案
    /// 本功能正常
    /// </summary>
    public class NPISendExcelToPM : BaseApp
    {
        public NPISendExcelToPM()
            : base()
        { }

        public override int DoJob(string batchName)
        {
            WriteLog("Job Start");

            EnumStatus status = EnumStatus.none;

            string mailMessage = "";

            try
            {
                mailMessage += "取得所有的等待的PM資料<br>";

                FormLogic logic = new FormLogic();

                List<FormPMEntity> list = logic.QueryNotCloseFormList();

                mailMessage += String.Format("寄發PM資料筆數={0}<br>",list.Count);

                if (list.Count > 0)
                {
                    foreach (FormPMEntity t in list)
                    {
                        WriteLog("發結果至RD PM 開始 PM="+t.PMUserId+":FormId="+t.FormId);

                        SendFormExcelDataToPM(t);

                        WriteLog("發結果至RD PM 結束 PM=" + t.PMUserId + ":FormId=" + t.FormId);
                    }
                }
                else
                {
                    WriteLog("目前沒有資料，程式結束");

                    mailMessage += "目前沒有資料，程式結束<br>"; 
                }

                mailMessage += "程式執行成功<br>";

                status = EnumStatus.success;
                
            }
            catch (Exception ex)
            {
                WriteLog("程式產生錯誤，程式中止");

                mailMessage += "System Error Begin <br>";

                string errMessage = "";

                if (ex.InnerException != null)
                {
                    errMessage += ex.InnerException.Message;
                }

                WriteLog("Error=" + errMessage + ex.Message + ex.StackTrace);

                mailMessage += "Error=" + errMessage + ex.Message + ex.StackTrace;
                
                status = EnumStatus.fail;
                
            }
            finally
            {
                WriteLog(mailMessage);

                //不管是否有成功，都要發信過去通知相關人等
                SendMailToAdmin(mailMessage);
            }

            return (int)status;
        }

        /// <summary>
        /// 將資料寄給PM
        /// </summary>
        /// <param name="obj"></param>
        private void SendFormExcelDataToPM(FormPMEntity entity)
        {
            //Step 1 Get Data

            WriteLog("產生Excel 檔案開始");
            string workFile=DownLoadExcel(entity);
            WriteLog("產生Excel 檔案結束");

            WriteLog("寄信給RDPM開始");
            
            SendMailToRDPM(workFile, entity.PMUserId);

            WriteLog("寄信給RDPM結束");

            WriteLog("更新專案狀態");
            if (CloseForm(entity.FormId))
            {
                WriteLog("專案狀態-結案");
            }
            else
            {
                WriteLog("專案狀態- 尚未結案");

                throw new Exception("NPI 專案無法結案，請查明Form ID=" + entity.FormId);
            }



        }

        /// <summary>
        ///  結案
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        private bool CloseForm(string formId)
        {
            FormLogic logic = new FormLogic();

            return logic.CloseForm(formId, EnumFormstatus.Y.ToString());
        }

        /// <summary>
        /// 下載Excel 資料
        /// </summary>
        /// <returns></returns>
        public string DownLoadExcel(FormPMEntity entity)
        {
            WriteLog("下載Excel");

            string path = Environment.CurrentDirectory;

            if (path.Substring(path.Length - 1, 1) == "\\")
            {
                path = path.Substring(0, path.Length - 1);
            }

            string templateFile = path + "\\BOMTemplate.xls";

            WriteLog("設定下載檔案開始");

            string currentSavePath = path + "\\ExcelTemp";

            if (!Directory.Exists(currentSavePath))
            {
                Directory.CreateDirectory(currentSavePath);
            }

            string saveFile = path + String.Format("\\ExcelTemp\\{2}-{0}-{1}.xls", DateTime.Now.ToString("yyyyMMdd"),entity.PMUserId,entity.FormId);


            ExcelLogic logic = new ExcelLogic(templateFile, saveFile);

            FormResponseEntity obj = GetDownloadFormData(entity);

            string workFile = "";

            if (logic.GenerateBomFile(obj))
            {
                workFile = saveFile;
            }
            else
            {
                throw new Exception("無法建立Excel檔案，請查明原因");
            }

            return workFile;



        }

        private FormResponseEntity GetDownloadFormData(FormPMEntity entity)
        {
            FormResponseEntity obj = new FormResponseEntity();

            FormLogic logic = new FormLogic();

            obj.FormId = entity.FormId;

            obj.PNList = logic.QueryFormPNList(entity.FormId);
            

            obj.BOMList = GetBookingBomList(entity.FormId,entity.PMUserId);

            Dictionary<string, string> dicList = logic.QueryFormBOMPNQtyList(entity.FormId);

            obj.BOMPNQtyList = dicList;
            

            return obj;
        }

        private List<BOMBookingEntity> GetBookingBomList(string formId,string userId)
        {
            BOMLogic bomLogic = new BOMLogic();

            List<BOMBookingEntity> bomList = bomLogic.QueryFromBookingBOM(formId, userId);
            
            return bomList;
        }

        /// <summary>
        /// 寄信至RD PM
        /// 將結果寄至
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="userId"></param>
        private void SendMailToRDPM(string fileName,string userId)
        {
            string mailServer = LoginInfo.MailServer;

            int port = Convert.ToInt16(LoginInfo.MailPort);

            string from = "srm@asus.com.tw";

            string to = "";

            WriteLog("人員=>" + userId);

            UserLogic userLogic = new UserLogic();


            EmployeeEntity emp = userLogic.GetUserInfo(userId, LoginInfo.Company);

            WriteLog("Email=" + emp.EmpEmail);

            to += LoginInfo.AttachRespTo;
           

            if (emp.EmpEmail.Trim() != "")
            {
                if (LoginInfo.IsSendUserEveryDayPrice == "Y")
                {
                    to += "," + emp.EmpEmail;
                }
            }
            else
            {
                WriteLog("Email=" + emp.EmpAccountId + "-(請查明此人的Email是否存在)");
            }

            string subject = String.Format("{0}-NPI-{1}({2})上E-NPI回覆結果通知", DateTime.Now.ToString("yyyy/MM/dd"), emp.EmpLoginId, emp.EmpChineseName);

            string body = "";

            body += String.Format("<p>Dear {0}({1}):</p>", emp.EmpLoginId, emp.EmpChineseName);

            body += @"
                        
                        <p>NPI系統將回覆料況資料於星期四寄至RD PM 且己經所上傳的BOM結案，謝謝~</p>

                        <p>E-NPI網址:</p>

                        <p><a href=https://scm.asus.com/npi/Index.aspx>https://scm.asus.com/npi/Index.aspx</a></p>


                        <p>詳細E-NPI流程:</p>
                        <ul>
                        <li>
                            <font color=red>PM 將Booking BOM的資料建於E-NPI系統上，建完之後，其狀態為等待展BOM。</font>
                        </li> 
                        <li>到星期二晚上１０：００結束建資料，１０：００會有一支排程資料將所有等待展BOM的資料展開。
                        </li> 
                        <li>所有的Sourcer在星期三之後可以上網回覆展BOM的資料，可以回覆至此星期四晚上10:00結案，周四晚上十點系統自動結案，將結果寄給RDPM，一旦結案之後，Sourcer只能瀏覽／下載而不能回覆。 
                        </li>
                         
                        </ul>

                        <p>MIS 窗口: Yulin Li(黎郁伶)</p>

                        <p>資材窗口 : Jo Kuo(郭淑真) Sam Chen(陳慶昇)</p>


                    ";

            string title = String.Format(" System send this mail to inform you this Info. Current Time: {0}", DateTime.Now.ToString());

            body += String.Format("<p>{0}</p>", title);

            body += "<div><img src=cid:mylogo></div>";

            List<LinkedResource> rList = new List<LinkedResource>();

            LinkedResource resource = new LinkedResource(Environment.CurrentDirectory + "/logo.gif");

            resource.ContentId = "mylogo";

            rList.Add(resource);
           
            
            MailUtil.SendBodyHtml(mailServer, port, from, to, subject, body, true, new string[] { fileName }, rList);
            


        }

        private void SendMailToAdmin(string bodyMessage)
        {
            string mailServer = LoginInfo.MailServer;

            int port = Convert.ToInt16(LoginInfo.MailPort);

            string from = "srm@asus.com.tw";

            string toList = LoginInfo.AttachTo;

            string subject = String.Format("NPI System Send Excel To PM Job Mail at {0}", DateTime.Now.ToString());

            string body = "";

            body = "<p>Dear All:</p>";

            string title = String.Format(" System send this mail to inform you this Info. Current Time: {0}", DateTime.Now.ToString());

            body += String.Format("<p>{0}</p>", title);

            body += bodyMessage;

            body += "<div><img src=cid:mylogo></div>";

            List<LinkedResource> rList = new List<LinkedResource>();

            LinkedResource resource = new LinkedResource(Environment.CurrentDirectory + "/logo.gif");

            resource.ContentId = "mylogo";

            rList.Add(resource);

           
            MailUtil.SendBodyHtml(mailServer, port, from, toList, subject, body, true, rList);
            


        }
    }
}
