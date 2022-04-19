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
    /// 主管收到警示信
    /// 凡是時間超過五天之後，請通知主管
    /// 此功能己經取消
    /// </summary>
    public class AlertManagerBatch : BaseApp
    {
        public AlertManagerBatch()
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

                //List<string> mailUserList = logic.GetSourcerNotConfirmManagerList();

                //if (mailUserList.Count > 0)
                //{
                //    foreach (string s in mailUserList)
                //    {
                //        UserLogic userLogic = new UserLogic();

                //        EmployeeEntity emp = logic.GetUserInfo(s, LoginInfo.Company);

                //        string mailServer = LoginInfo.MailServer;

                //        int mailPort = Convert.ToInt16(LoginInfo.MailPort);

                //        //string to = emp.EmpEmail;
                //        string to = "wen-bin_tsai@asus.com.tw";

                //        string from = "wen-bin_tsai@asus.com.tw";

                //        string subject = String.Format("{0}-NPI-{1}({2})主管確認尚未議價之元件資料列表", DateTime.Now.ToString("yyyy/MM/dd"), emp.EmpLoginId, emp.EmpChineseName);

                //        string body = String.Format(LoginInfo.SendManageMailURL, emp.EmpAccountId);

                //        MailUtil.Send(mailServer, mailPort, from, to, subject, body, true);
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
