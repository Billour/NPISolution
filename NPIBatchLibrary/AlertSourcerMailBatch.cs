using System;
using System.Collections.Generic;
using System.Text;

using BatchLibrary.App;
using ASUS.B2B.SRM.BusinessTier;
using ASUS.B2B.SRM.DataTier;

using AsusLibrary.Entity;
using AsusLibrary.Logic;

using AsusLibrary.Utility;
using System.Net.Mail;

namespace BatchLibrary
{
    public class AlertSourcerMailBatch : BaseApp
    {
        /// <summary>
        /// ����BOM���͵{��
        /// Add:�s�W�@��Job
        ///     
        /// ���\��v����
        /// </summary>
        public AlertSourcerMailBatch()
            : base()
        { }

        public override int DoJob(string batchName)
        {
            WriteLog("Job Start");

            EnumStatus status = EnumStatus.none;
            try
            {


                //AlertSourcer("�v�g�i�}�����A�ФWe-NPI��g�^�Ф��e");

                status = EnumStatus.success;
                return 1;
            }
            catch (Exception ex)
            {
                WriteLog("�{�����ѡG" + ex.Message + ex.StackTrace);
                status = EnumStatus.fail;
                return 0;
            }
        }

        private void AlertSourcer(string message)
        {
            SourcerLogic logic = new SourcerLogic();
            //��ثe�Ҧ���ourcer
            List<string> mailUserList = logic.GetMailSourcerList();

            foreach (string s in mailUserList)
            {
                WriteLog("�H��=>" + s);
            }

            //�H�H��Sourcer
            if (mailUserList.Count > 0)
            {
                foreach (string s in mailUserList)
                {
                    WriteLog("�H��=>" + s);
                    UserLogic userLogic = new UserLogic();

                    EmployeeEntity emp = logic.GetUserInfo(s, LoginInfo.Company);

                    string mailServer = LoginInfo.MailServer;

                    int mailPort = Convert.ToInt16(LoginInfo.MailPort);

                    string to = "";


                    WriteLog("Email=" + emp.EmpEmail);

                    to += LoginInfo.AttachTo;


                    if (emp.EmpEmail.Trim() != "")
                    {
                        to += "," + emp.EmpEmail;
                    }
                    else
                    {
                        WriteLog("Email=" + emp.EmpAccountId + "-(�Ьd�����H��Email�O�_�s�b)");
                    }


                    string from = "srm@asus.com.tw";

                    string subject = String.Format("{0}-NPI-{1}({2})�WE-NPI�^�и�Ƴq��", DateTime.Now.ToString("yyyy/MM/dd"), emp.EmpLoginId, emp.EmpChineseName);
                    WriteLog("���^Body-Begin");

                    string body = "";

                    body += String.Format("<p>Dear {0}({1}):</p>", emp.EmpLoginId, emp.EmpChineseName);

                    body += @"
                        
                        <p></p>
                        
                        <p>�����z�@�U�A�Щ�C�g�T�i�JE-NPI�Ӧ^�Юƪp��ơA����~</p>

                        <p>E-NPI���}:</p>

                        <p><a href=https://scm.asus.com/npi/Index.aspx>https://scm.asus.com/npi/Index.aspx</a></p>


                        <p>�Բ�E-NPI�y�{:</p>
                        <ul>
                        <li>
                            <font color=red>PM �NBooking BOM����ƫة�E-NPI�t�ΤW�A�ا�����A�䪬�A�����ݮiBOM�C</font>
                        </li> 
                        <li>��P���G�ߤW�����G���������ظ�ơA�����G�����|���@��Ƶ{��ƱN�Ҧ����ݮiBOM����Ʈi�}�C
                        </li> 
                        <li>�Ҧ���Sourcer�b�P���T����i�H�W���^�ЮiBOM����ơA�i�H�^�Цܦ��P���|�ߤW10:00���סA�P�|�ߤW�Q�I�t�Φ۰ʵ��סA�N���G�H��RDPM�A�@�����פ���ASourcer�u���s�����U���Ӥ���^�СC 
                        </li>
                         
                        </ul>

                        <p>MIS ���f: Wen-Bin Tsai(�����y)</p>

                        <p>������f : Jo Kuo(���Q�u) Sam Chen(���y�@)</p>


                    ";


                    string title = String.Format(" System send this mail to inform you this Info. Current Time: {0}", DateTime.Now.ToString());

                    body += String.Format("<p>{0}</p>", title);

                    body += "<div><img src=cid:mylogo></div>";

                    List<LinkedResource> rList = new List<LinkedResource>();

                    LinkedResource resource = new LinkedResource(Environment.CurrentDirectory + "/logo.gif");

                    resource.ContentId = "mylogo";

                    rList.Add(resource);

                    WriteLog("���^Body-OK");

                    MailUtil.SendBodyHtml(mailServer, mailPort, from, to, subject, body, true, rList);

                    WriteLog("�H�H����");

                    System.Threading.Thread.Sleep(3000);
                }

            }
            else
            {
                WriteLog("�L��ơA�{�����槹��");
            }

        }
    }
}
