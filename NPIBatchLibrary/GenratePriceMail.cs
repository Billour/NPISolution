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
    /// �C�ѱH�H��Sourcer
    /// ���\�����
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
                //�N�H�󰵦��H�H�W���
                //SendSourceMail3();


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
        /// �ĤT�N�H�H���e
        /// �O�H�H���D
        /// �[�W�Ƹ����/PN���Y���
        /// </summary>
        private void SendSourceMail3()
        {
            bool isFlag = false;

            //�Ĥ@�B�J(�����o�Ҧ����|��ĳ����PN)-�v�g�z��L�����G�A�^�ǥHSortedList Group�Ƥ��n

            SourcerLogic logic = new SourcerLogic();

            SortedList<string, SortedList<string, PNPrice2Entity>> list=logic.GetWaitingAlertSourcePrice();

            string mailServer = LoginInfo.MailServer;

            int mailPort = Convert.ToInt16(LoginInfo.MailPort);

            string from = "srm@asus.com.tw";

            //���^�v�g�����nĳ����ơA�}�l�H�H s=SourcerId ���u�u��
            foreach(string key in list.Keys)
            {
                string date = DateTime.Now.ToString();

                WriteLog("�H��=>" + key);

                UserLogic userLogic = new UserLogic();

                WriteLog("�}�l���o�H�����-�}�l");

                EmployeeEntity emp = logic.GetUserInfo(key, LoginInfo.Company);

                string subject = String.Format("{0}-NPI-{1}({2})�|��ĳ���������ƦC��", DateTime.Now.ToString("yyyy/MM/dd"), emp.EmpLoginId, emp.EmpChineseName);

                string to = "";

                WriteLog("Email=" + emp.EmpEmail);

                to += LoginInfo.AttachTo;

                if (emp.EmpEmail.Trim() != "")
                {
                    //���椣�H�A����վ�
                    if (LoginInfo.IsSendUserEveryDayPrice == "Y")
                    {
                        to += "," + emp.EmpEmail;
                    }
                }
                else
                {
                    WriteLog("Email=" + emp.EmpAccountId + "-(�Ьd�����H��Email�O�_�s�b)");
                }

                bool isHasAttach = true;

                //�N�ݭn��������Ƨ�X
                SortedList<string, PNPrice2Entity> priceList = list[key]; 

                if (priceList.Count == 0)
                {
                    isHasAttach = false;
                }

                string workFile = "";

                if (isHasAttach)
                {
                    WriteLog("�}�l�g�JExcel");

                    string templateFile = Environment.CurrentDirectory + "\\priceTemplate.xls";
                    WriteLog(String.Format("�U��Excel-���|={0}", templateFile));

                    WriteLog("�]�w�U���ɮ�");

                    string targetPath = Environment.CurrentDirectory + String.Format("\\TempDoc{0}", DateTime.Now.ToString("yyyyMMdd"));

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }

                    string saveFile = targetPath + String.Format("\\NPI_Price_{0}_{1}.xls", Convert.ToDateTime(date).ToString("MMdd"), emp.EmpLoginId);
                    WriteLog(String.Format("�U��Excel-���|={0}", saveFile));

                    ExcelLogic eLogic = new ExcelLogic(templateFile, saveFile);


                    if (eLogic.GeneratePrice2File(priceList))
                    {
                        WriteLog("���إߦ��\");
                        workFile = saveFile;
                    }
                    else
                    {
                        throw new Exception("�L�k�إ�Excel�ɮסA�Ьd����]");
                    }
                }

                string body = "";

                if (isHasAttach)
                {
                    body = String.Format("<p>Dear {0}({1}):</p>", emp.EmpLoginId, emp.EmpChineseName);

                    body += "<p>���󬰻ݺ��@ĳ���ɤ�����Ƹ�</p>";

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
        /// �Ĥ@�N�H�H���e
        /// �O�H�H���D
        /// 
        /// </summary>
        private void SendSourceMail()
        {
            bool isFlag = false;

            //�Ĥ@�B�J(�����o�Ҧ����|��ĳ����PN)-�v�g�z��L�����G�A�^�ǥHSortedList Group�Ƥ��n

            SourcerLogic logic = new SourcerLogic();

            SortedList<string, PNPriceEntity> notConfirmList = logic.GetNotConfirmPricePNList();

            //���o�Ҧ���Sourcer �H�H�����(�p�G���ŦX����ƪ��ɭ�)�[�J��ƥ�Excel�Ӱ��A�p�G�S�����ܤ]�H�@�ʫH�q��������ĳ���C
            List<string> mailList = logic.GetAllSourcer();

            SortedList<string, List<ComponentRefEntity>> sortedMailList = new SortedList<string, List<ComponentRefEntity>>();

            foreach (string s in mailList)
            {

                sortedMailList.Add(s, logic.GetSourcerComponentList(s, LoginInfo.Company));
            }

            //�H�H
            if (sortedMailList.Count > 0)
            {
                foreach (string key in sortedMailList.Keys)
                {
                    string date = DateTime.Now.ToString();

                    //�}�l�H�H

                    WriteLog("�H��=>" + key);

                    UserLogic userLogic = new UserLogic();

                    WriteLog("�}�l���o�H�����-�}�l");
                    EmployeeEntity emp = logic.GetUserInfo(key, LoginInfo.Company);

                    WriteLog("�}�l���o�H�����-����");
                    string mailServer = LoginInfo.MailServer;

                    int mailPort = Convert.ToInt16(LoginInfo.MailPort);

                    string subject = String.Format("{0}-NPI-{1}({2})�|��ĳ���������ƦC��", DateTime.Now.ToString("yyyy/MM/dd"), emp.EmpLoginId, emp.EmpChineseName);

                    string to = "";

                    WriteLog("Email=" + emp.EmpEmail);

                    to += LoginInfo.AttachTo;

                    if (emp.EmpEmail.Trim() != "")
                    {
                        //���椣�H�A����վ�
                        if (LoginInfo.IsSendUserEveryDayPrice == "Y")
                        {
                            to += "," + emp.EmpEmail;
                        }
                    }
                    else
                    {
                        WriteLog("Email=" + emp.EmpAccountId + "-(�Ьd�����H��Email�O�_�s�b)");
                    }

                    bool isHasAttach = true;

                    string from = "srm@asus.com.tw";

                    SortedList<string, PNPriceEntity> priceList = ConvertToNotUsedList(notConfirmList, sortedMailList[key]); //�N�ݭn��������Ƨ�X

                    if (priceList.Count == 0)
                    {
                        isHasAttach = false;
                    }

                    string workFile = "";

                    if (isHasAttach)
                    {
                        WriteLog("�}�l�g�JExcel");

                        string templateFile = Environment.CurrentDirectory + "\\priceTemplate.xls";
                        WriteLog(String.Format("�U��Excel-���|={0}", templateFile));

                        WriteLog("�]�w�U���ɮ�");

                        string targetPath = Environment.CurrentDirectory + String.Format("\\TempDoc{0}", DateTime.Now.ToString("yyyyMMdd"));

                        if (!Directory.Exists(targetPath))
                        {
                            Directory.CreateDirectory(targetPath);
                        }

                        string saveFile = targetPath + String.Format("\\NPI_Price_{0}_{1}.xls", Convert.ToDateTime(date).ToString("MMdd"), emp.EmpLoginId);
                        WriteLog(String.Format("�U��Excel-���|={0}", saveFile));

                        ExcelLogic eLogic = new ExcelLogic(templateFile, saveFile);


                        if (eLogic.GeneratePriceFile(priceList))
                        {
                            WriteLog("���إߦ��\");
                            workFile = saveFile;
                        }
                        else
                        {
                            throw new Exception("�L�k�إ�Excel�ɮסA�Ьd����]");
                        }
                    }


                    string body = "";

                    if (isHasAttach)
                    {
                        body = String.Format("<p>Dear {0}({1}):</p>", emp.EmpLoginId, emp.EmpChineseName);

                        body += "<p>���󬰻ݺ��@ĳ���ɤ�����Ƹ�</p>";

                        body += "<font color=red>ps:�ثe����Ƹ��O�H�j���ӳ]�w�A�ҥH�|�H�o���Ӥj����sourcer���H�C�Y�D�ƥ󥻤H�A�i�����C</font><br>";

                        string title = String.Format(" System send this mail to inform you this Info. Current Time: {0}", date);

                        body += String.Format("<p>{0}</p>", title);

                        body += "<div><img src=cid:mylogo></div>";

                    }
                    else
                    {
                        body = String.Format("<p>Dear {0}({1}):</p>", emp.EmpLoginId, emp.EmpChineseName);

                        body += "<p>�ثe�Lĳ���ɸ�ƻݭn���@</p>";

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
                WriteLog("�L��ơA���ݭn�H�H");
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
