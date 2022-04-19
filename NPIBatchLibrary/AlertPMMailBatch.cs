using System;
using System.Collections.Generic;
using System.Text;

using BatchLibrary.App;


using AsusLibrary.Entity;
using AsusLibrary.Logic;

using AsusLibrary.Utility;
using System.Net.Mail;

namespace BatchLibrary
{
    /// <summary>
    /// 寄發給PM的通知信
    /// 目前時間是在星期二晚上10:00發
    /// 本功能正常
    /// </summary>
    public class AlertPMMailBatch:BaseApp
    {
        public AlertPMMailBatch()
            : base()
        { }

        public override int DoJob(string batchName)
        {
            WriteLog("Job Start");

            EnumStatus status = EnumStatus.none;
            try
            {
                //通知PM 信件
                AlertPM();

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

        private void AlertPM()
        {
            SourcerLogic logic = new SourcerLogic();
            //找目前所有的ourcer
            List<string> mailUserList = logic.GetMailPMList();

            foreach (string s in mailUserList)
            {
                WriteLog("人員=>" + s);
            }

            string mailServer = LoginInfo.MailServer;

            int mailPort = Convert.ToInt16(LoginInfo.MailPort);

            string to = "";


            

            to += LoginInfo.AttachTo;


            //寄信給Sourcer
            if (mailUserList.Count > 0)
            {
                foreach (string s in mailUserList)
                {
                    WriteLog("人員=>" + s);
                    UserLogic userLogic = new UserLogic();

                    EmployeeEntity emp = logic.GetUserInfo(s, LoginInfo.Company);

                    WriteLog("Email=" + emp.EmpEmail);

                    if (emp.EmpEmail.Trim() != "")
                    {
                        
                            to += "," + emp.EmpEmail;
                        

                    }
                    else
                    {
                        WriteLog("Email=" + emp.EmpAccountId + "-(請查明此人的Email是否存在)");
                    }

                }


                    string from = "srm@asus.com.tw";

                    string subject = String.Format("{0}-NPI請在每週二晚上10:00前進入E-NPI來填寫 NEW BOM", DateTime.Now.ToString("yyyy/MM/dd"));
                    WriteLog("取回Body-Begin");

                    string body = "";

                    //body = String.Format("<p>Dear {0}({1}):</p>", emp.EmpLoginId, emp.EmpChineseName);

                    body = "<p>Dear All:</p>";
                    
                    body+= @"
                        
                        <p>提醒您一下，請於每週二晚上10:00前進入E-NPI來填寫 NEW BOM資料，謝謝~</p>

                        <p>E-NPI網址:</p>

                        <p>https://scm.asus.com/npi/Index.aspx</p>


                        <p>詳細E-NPI流程:</p>
                        <ul>
                        <li>
                            <font color=red>PM 將Booking BOM的資料建於E-NPI系統上，建完之後，其狀態為等待展BOM。</font>
                        </li> 
                        <li>到星期二晚上１０：００結束建資料，１０：００會有一支排程資料將所有等待展BOM的資料展開。
                        </li> 
                        <li>所有的Sourcer在星期三之後可以上網回覆展BOM的資料，可以回覆至此星期四晚上10:00結案，周四晚上十點系統自動結案，將結果寄給RD PM，一旦結案之後，Sourcer只能瀏覽／下載而不能回覆。 
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

                    WriteLog("取回Body-OK");

                    MailUtil.SendBodyHtml(mailServer, mailPort, from, to, subject, body, true, rList);

                    WriteLog("寄信完成");

                    //System.Threading.Thread.Sleep(3000);
                

            }
            else
            {
                WriteLog("無資料，程式執行完畢");
            }

        }
    }
}
