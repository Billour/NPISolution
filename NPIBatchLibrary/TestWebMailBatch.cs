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

namespace BatchLibrary
{
    /// <summary>
    /// 測試信件是否可以
    /// 以Sam為主
    /// 本功能取消
    /// </summary>
    public class TestWebMailBatch : BaseApp
    {
        public TestWebMailBatch()
            : base()
        { }

        public override int DoJob(string batchName)
        {
            WriteLog("Job Start");

            EnumStatus status = EnumStatus.none;
            try
            {
                //bool isFlag = false;

                ////先取得必須要寄信的人員
                //SourcerLogic logic = new SourcerLogic();

                //WriteLog("取回要寄信的人員");
                //List<string> mailUserList = new List<string>();

                //mailUserList.Add("AA0800226");

                //foreach (string s in mailUserList)
                //{
                //    WriteLog("人員=>" + s);
                //}

                //if (mailUserList.Count > 0)
                //{
                //    foreach (string s in mailUserList)
                //    {
                //        WriteLog("人員=>" + s);
                //        UserLogic userLogic = new UserLogic();

                //        EmployeeEntity emp = logic.GetUserInfo(s, LoginInfo.Company);

                //        string mailServer = LoginInfo.MailServer;

                //        int mailPort = Convert.ToInt16(LoginInfo.MailPort);

                //        string to = "";
                //        //to += "wen-bin_tsai@asus.com.tw";

                //        WriteLog("Email=" + emp.EmpEmail);
                //        //;

                //        to += "wen-bin_tsai@asus.com.tw";


                //        //if (emp.EmpEmail.Trim() != "")
                //        //{
                //        //    to += "," + emp.EmpEmail;
                //        //}
                //        //else
                //        //{
                //        //    WriteLog("Email=" + emp.EmpAccountId+"-(請查明此人的Email是否存在)");
                //        //}


                //        string from = "scm@asus.com.tw";

                //        string subject = String.Format("{0}-NPI-{1}({2})尚未議價之元件資料列表", DateTime.Now.ToString("yyyy/MM/dd"), emp.EmpLoginId, emp.EmpChineseName);
                //        WriteLog("取回Body-Begin");

                //        string body = String.Format(LoginInfo.SendMailURL, emp.EmpAccountId);

                //        WriteLog("取回Body-OK");

                //        MailUtil.Send(mailServer, mailPort, from, to, subject, body, true);

                //        WriteLog("寄信完成");

                //        System.Threading.Thread.Sleep(3000);
                //    }




                //}
                //else
                //{
                //    WriteLog("無資料，程式執行完畢");
                //}


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
    }
}
