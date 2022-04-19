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
    /// ���իH��O�_�i�H
    /// �HSam���D
    /// ���\�����
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

                ////�����o�����n�H�H���H��
                //SourcerLogic logic = new SourcerLogic();

                //WriteLog("���^�n�H�H���H��");
                //List<string> mailUserList = new List<string>();

                //mailUserList.Add("AA0800226");

                //foreach (string s in mailUserList)
                //{
                //    WriteLog("�H��=>" + s);
                //}

                //if (mailUserList.Count > 0)
                //{
                //    foreach (string s in mailUserList)
                //    {
                //        WriteLog("�H��=>" + s);
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
                //        //    WriteLog("Email=" + emp.EmpAccountId+"-(�Ьd�����H��Email�O�_�s�b)");
                //        //}


                //        string from = "scm@asus.com.tw";

                //        string subject = String.Format("{0}-NPI-{1}({2})�|��ĳ���������ƦC��", DateTime.Now.ToString("yyyy/MM/dd"), emp.EmpLoginId, emp.EmpChineseName);
                //        WriteLog("���^Body-Begin");

                //        string body = String.Format(LoginInfo.SendMailURL, emp.EmpAccountId);

                //        WriteLog("���^Body-OK");

                //        MailUtil.Send(mailServer, mailPort, from, to, subject, body, true);

                //        WriteLog("�H�H����");

                //        System.Threading.Thread.Sleep(3000);
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
