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
    /// �D�ަ���ĵ�ܫH
    /// �Z�O�ɶ��W�L���Ѥ���A�гq���D��
    /// ���\��v�g����
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

                ////�����o�����n�H�H���H��
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

                //        string subject = String.Format("{0}-NPI-{1}({2})�D�޽T�{�|��ĳ���������ƦC��", DateTime.Now.ToString("yyyy/MM/dd"), emp.EmpLoginId, emp.EmpChineseName);

                //        string body = String.Format(LoginInfo.SendManageMailURL, emp.EmpAccountId);

                //        MailUtil.Send(mailServer, mailPort, from, to, subject, body, true);
                //    }
                //}
                //else
                //{
                //    WriteLog("�L��ơA�{�����槹��");
                //}


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
    }
}
