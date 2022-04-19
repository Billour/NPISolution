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
    /// �H�H��RD PM
    /// �H�e���ɶ��I�b�C�P�����P�������W3:00
    /// �N�t�ε���
    /// ���\�ॿ�`
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
                mailMessage += "���o�Ҧ������ݪ�PM���<br>";

                FormLogic logic = new FormLogic();

                List<FormPMEntity> list = logic.QueryNotCloseFormList();

                mailMessage += String.Format("�H�oPM��Ƶ���={0}<br>",list.Count);

                if (list.Count > 0)
                {
                    foreach (FormPMEntity t in list)
                    {
                        WriteLog("�o���G��RD PM �}�l PM="+t.PMUserId+":FormId="+t.FormId);

                        SendFormExcelDataToPM(t);

                        WriteLog("�o���G��RD PM ���� PM=" + t.PMUserId + ":FormId=" + t.FormId);
                    }
                }
                else
                {
                    WriteLog("�ثe�S����ơA�{������");

                    mailMessage += "�ثe�S����ơA�{������<br>"; 
                }

                mailMessage += "�{�����榨�\<br>";

                status = EnumStatus.success;
                
            }
            catch (Exception ex)
            {
                WriteLog("�{�����Ϳ��~�A�{������");

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

                //���ެO�_�����\�A���n�o�H�L�h�q�������H��
                SendMailToAdmin(mailMessage);
            }

            return (int)status;
        }

        /// <summary>
        /// �N��ƱH��PM
        /// </summary>
        /// <param name="obj"></param>
        private void SendFormExcelDataToPM(FormPMEntity entity)
        {
            //Step 1 Get Data

            WriteLog("����Excel �ɮ׶}�l");
            string workFile=DownLoadExcel(entity);
            WriteLog("����Excel �ɮ׵���");

            WriteLog("�H�H��RDPM�}�l");
            
            SendMailToRDPM(workFile, entity.PMUserId);

            WriteLog("�H�H��RDPM����");

            WriteLog("��s�M�ת��A");
            if (CloseForm(entity.FormId))
            {
                WriteLog("�M�ת��A-����");
            }
            else
            {
                WriteLog("�M�ת��A- �|������");

                throw new Exception("NPI �M�׵L�k���סA�Ьd��Form ID=" + entity.FormId);
            }



        }

        /// <summary>
        ///  ����
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        private bool CloseForm(string formId)
        {
            FormLogic logic = new FormLogic();

            return logic.CloseForm(formId, EnumFormstatus.Y.ToString());
        }

        /// <summary>
        /// �U��Excel ���
        /// </summary>
        /// <returns></returns>
        public string DownLoadExcel(FormPMEntity entity)
        {
            WriteLog("�U��Excel");

            string path = Environment.CurrentDirectory;

            if (path.Substring(path.Length - 1, 1) == "\\")
            {
                path = path.Substring(0, path.Length - 1);
            }

            string templateFile = path + "\\BOMTemplate.xls";

            WriteLog("�]�w�U���ɮ׶}�l");

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
                throw new Exception("�L�k�إ�Excel�ɮסA�Ьd����]");
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
        /// �H�H��RD PM
        /// �N���G�H��
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="userId"></param>
        private void SendMailToRDPM(string fileName,string userId)
        {
            string mailServer = LoginInfo.MailServer;

            int port = Convert.ToInt16(LoginInfo.MailPort);

            string from = "srm@asus.com.tw";

            string to = "";

            WriteLog("�H��=>" + userId);

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
                WriteLog("Email=" + emp.EmpAccountId + "-(�Ьd�����H��Email�O�_�s�b)");
            }

            string subject = String.Format("{0}-NPI-{1}({2})�WE-NPI�^�е��G�q��", DateTime.Now.ToString("yyyy/MM/dd"), emp.EmpLoginId, emp.EmpChineseName);

            string body = "";

            body += String.Format("<p>Dear {0}({1}):</p>", emp.EmpLoginId, emp.EmpChineseName);

            body += @"
                        
                        <p>NPI�t�αN�^�Юƪp��Ʃ�P���|�H��RD PM �B�v�g�ҤW�Ǫ�BOM���סA����~</p>

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

                        <p>MIS ���f: Yulin Li(�����D)</p>

                        <p>������f : Jo Kuo(���Q�u) Sam Chen(���y�@)</p>


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
