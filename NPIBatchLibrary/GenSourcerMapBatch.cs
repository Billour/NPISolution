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
    /// ����Sourcer �PPN ��Map��
    /// ���\�����
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
                WriteLog("�{�����ѡG" + ex.InnerException.ToString() + ex.Message + ex.StackTrace);
                status = EnumStatus.fail;
                return 0;
            }

            //return 1;
        }

        

        /// <summary>
        /// ����Sourcer��ƪ�Mapping��
        /// �ΨӰ������ϥ�
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
                WriteLog("��Ʒs�W����");
            }
            else
            {
                WriteLog("��Ʒs�W����");
                throw new Exception("��Ʒs�W����");
            }

            //�q���޲z�̧䤣��Sourcer�������
            string mailServer = LoginInfo.MailServer;

            int mailPort = Convert.ToInt16(LoginInfo.MailPort);

            string from = "srm@asus.com.tw";

            string date = DateTime.Now.ToString();

            string subject = String.Format("{0}-NPI-�|�����o����Ƹ��PSourcer������ƦC��", DateTime.Now.ToString("yyyy/MM/dd"));

            string to = "";

            to += LoginInfo.AttachTo;

            bool isHasAttach = true;

            //�N�ݭn��������Ƨ�X
            List<SourcerPNMapEntity> pnList = slist["Y"];

            if (pnList.Count == 0)
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

                string saveFile = targetPath + String.Format("\\NPI_NoSourcerPN_{0}.xls", Convert.ToDateTime(date).ToString("MMdd"));
                WriteLog(String.Format("�U��Excel-���|={0}", saveFile));

                ExcelLogic eLogic = new ExcelLogic(templateFile, saveFile);


                if (eLogic.GeneratePNFile(pnList))
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
                body = "<p>Dear ALL:</p>";

                body += "<p>���󬰻ݽT�{PN����Sourcer����ƦC��, �ثe�b�t�Ω|���o��PN�Ƹ����ϥΪ�</p>";

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
