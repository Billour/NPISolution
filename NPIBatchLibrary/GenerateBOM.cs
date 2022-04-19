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
    /// <summary>
    /// ����BOM��T
    /// ���\�ॿ�`
    /// </summary>
    public class GenerateBOM:BaseApp
    {
        /// <summary>
        /// ����BOM���͵{��
        /// Add:�s�W�@��Job
        ///     
        /// 
        /// </summary>
        public GenerateBOM()
            : base()
        { }

        public override int DoJob(string batchName)
        {
            bool isFlag = false;
            
            WriteLog("Job Start");

            EnumStatus status = EnumStatus.none;
            try
            {
                string message = "";

                string genId = DateTime.Now.ToString("yyyyMMdd"); 

                //���͸s�ո��BOM���
                GenerateGroupBOM();               

                //����NPI�D�ɸ��
                GenerateNPIMain(genId);
                
                message += "e-NPI�u�@����";
                //AlertAdmin(message);

                isFlag = true;

                AlertSourcer("�v�g�i�}�����A�ФWe-NPI��g�^�Ф��e");

                status = EnumStatus.success;
                return 1;
            }
            catch (Exception ex)
            {
                WriteLog("�{�����ѡG"+ex.InnerException.Message +ex.Message + ex.StackTrace);
                status = EnumStatus.fail;
                return 0;
            }
            
            

            //return 1;
        }

        /// <summary>
        /// Gen Main BOM
        /// </summary>
        private void GenerateGroupBOM()
        {
            string message = "";

            List<GroupMapEntity> waitingGroupList = GetWaitingGroup();

            if (waitingGroupList.Count>0)
            {
                //Insert Main Table Data

                foreach (GroupMapEntity s in waitingGroupList)
                {
                    //�@���@�Ӹs��
                    WriteLog("Group-->" + s.GroupId);

                    GenerateGroupFormBom(s.GroupId);
                }

                
            }
            else
            {
                message += "�LGroup�i�H�i�}�A�u�@����-�H�o�q���H�q��Admin";

                WriteLog(message);

            }
        }

        /// <summary>
        /// ����NPI�D��
        /// </summary>
        private void GenerateNPIMain(string genId)
        {

            GenNPIEntity obj = GetMainObject(genId);

            if (obj == null)
            {
                WriteLog("Gen Main ��Ƭ��ŭȡA�{������");
            }
            else
            {
                GenLogic logic = new GenLogic();

                if (logic.InsertNewMain(obj))
                {
                    WriteLog("Gen��Ʒs�W����");
                }
                else
                {
                    WriteLog("Gen��Ʒs�W����");

                    throw new Exception("Gen��Ʒs�W����");
                }
            }

            


        }

        private GenNPIEntity GetMainObject(string genId)
        {
            GenNPIEntity obj = null;
            
            //GenId
            //string genId = DateTime.Now.ToString("yyyyMMdd");
            
            GenLogic logic = new GenLogic();

            List<string> workList = logic.QueryWorkNoListByMainId(genId);

            List<string> formList = logic.QueryFormListByMainId(genId);

            if (formList.Count > 0)
            {
                obj = new GenNPIEntity();

                //Main�D��
                GenMainEntity main = new GenMainEntity();

                main.MainId = genId;
                main.MainName = DateTime.Now.ToString("yyy/MM/dd");
                main.MainDesc = "";

                main.CreateUser = "System";
                main.CreateTime = DateTime.Now.ToString();

                main.UpdateUser = "System";
                main.UpdateTime = DateTime.Now.ToString();
                main.WorkStatus = "N";

                obj.Main = main;

                List<GenFormEntity> genFormList = new List<GenFormEntity>();

                foreach (string s in formList)
                {
                    GenFormEntity f = new GenFormEntity();

                    f.MainId = genId;
                    f.FormId = s;
                    f.WorkStatus = "Y";

                    f.CreateUser = "System";
                    f.CreateTime = DateTime.Now.ToString();

                    f.UpdateUser = "System";
                    f.UpdateTime = DateTime.Now.ToString();

                    genFormList.Add(f);

                    
                }

                obj.FormList = genFormList;

                //�}�l���oPN List

                List<AsusBomEntity> erpBomList = new List<AsusBomEntity>();

                //���o�Ҧ������i�����
                foreach (string s in workList)
                {
                    WriteLog(String.Format("({0})-Begin", s));

                    List<AsusBomEntity> AsusBomList = GetErpBomListByWorkNo(s);

                    foreach (AsusBomEntity ss in AsusBomList)
                    {
                        //WriteLog(String.Format("     PN�GWorkNo={0},BOM={1},PN={2},Qty={3},Name={4},Desc={5}", new object[] { ss.WorkNo, ss.BomId, ss.PN, ss.Qty, ss.PNName, ss.PNDesc }));
                        erpBomList.Add(ss); //�զX�Ҧ������
                        //WriteLog("PN Add End");
                    }

                    WriteLog(String.Format("({0})-End", s));
                }

                SortedList<string, List<string[]>> groupSList = ConvertToGroupInfo(erpBomList);

                // 2009/06/05 Add �s�ժ��z��
                SortedList<int, SortedList<string, SortedList<string, string>>> groupPN = GetConvertPN(groupSList);

                SortedList<string, int> pNList = ConvertToPNGroup(groupPN); //���o�Ҧ������

                obj.GenPNList = ChangeMainPNList(erpBomList,genId, pNList); //���oPN List

            }

            return obj;
        }

        /// <summary>
        /// ���o���ݪ��s��
        /// </summary>
        /// <returns></returns>
        private List<GroupMapEntity> GetWaitingGroup()
        {
            GroupLogic logic = new GroupLogic();

            return logic.QueryGroupList();
        }

        /// <summary>
        /// ���o�s�ժ�BOM���
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        private List<BOMBookingEntity> GetWatingGroupBoms(string groupId)
        {
            GroupLogic gLogic = new GroupLogic();

            string[] waitingUserList = gLogic.GetGroupUsers(groupId);
            
            BOMLogic logic = new BOMLogic();

            return logic.QueryBookingBomList(AsusLibrary.EnumWorkStatus.Wait, waitingUserList);
        }

        /// <summary>
        /// �H�s�ը�
        /// </summary>
        /// <param name="groupId"></param>
        private void GenerateGroupFormBom(string groupId)
        {
            //WorkList
            List<string> workList = new List<string>();

            //�iBOM�ұo
            List<AsusBomEntity> erpBomList = new List<AsusBomEntity>(); //�ӱ����Ҫ�Erp Asus

            //���^����
            WriteLog("���^���ݪ�BOM List �}�l");

            List<BOMBookingEntity> waitingBomList = GetWatingGroupBoms(groupId);

            WriteLog(String.Format("���^���ݪ�BOM List �����A�`�@�O{0}��", waitingBomList.Count));

            if (waitingBomList.Count > 0)
            {
                //�s�WFormEntity

                //���oFormNo
                string FormNo = DateTime.Now.ToString("yyyyMMddHHmmss");
                string FormDate = DateTime.Now.ToString();

                WriteLog(string.Format("Bom Generate List={0}", waitingBomList.Count));

                int count = 0;

                WriteLog("Step A Generate Bom Begin");

                foreach (BOMBookingEntity t in waitingBomList)
                {
                    WriteLog(string.Format("{0}.{1}({2})", count, t.BOMId, t.BOMName));

                    string workNo = GetBOMPN(t.BOMId);

                    WriteLog(String.Format("{0}.workNo={1}", count, workNo));

                    if (workNo != "")
                    {
                        workList.Add(workNo);
                    }
                    else
                    {

                        WriteLog(String.Format("workNo=�ŭȡA�Ьd��{0}�O�_����", workNo));

                        throw new Exception("��Ʀ����~�A�Ьd���O�_�S������Ƹ��Ϊ̬O�{�����D");
                    }



                    WriteLog(string.Format("{0}-End", count));

                    count++;
                }

                WriteLog("Step A Generate Bom End");



                WriteLog(String.Format("Step B workNo List Count={0}", workList.Count.ToString()));

                //���o�Ҧ������i�����
                foreach (string s in workList)
                {
                    WriteLog(String.Format("({0})-Begin", s));

                    List<AsusBomEntity> AsusBomList = GetErpBomListByWorkNo(s);

                    foreach (AsusBomEntity ss in AsusBomList)
                    {
                        //WriteLog(String.Format("     PN�GWorkNo={0},BOM={1},PN={2},Qty={3},Name={4},Desc={5}", new object[] { ss.WorkNo, ss.BomId, ss.PN, ss.Qty, ss.PNName, ss.PNDesc }));
                        erpBomList.Add(ss); //�զX�Ҧ������
                        //WriteLog("PN Add End");
                    }

                    WriteLog(String.Format("({0})-End", s));
                }

                WriteLog("Step B Finish");

                int n = erpBomList.Count;

                //�}�l�N�ҧ�쪺BOM 2009/06/05 �[�J�s�դ��e
                // {0}=AssemblyNo {1}=IsSub
                // groupSList �N��O���o���Ƹ��b�����p�U�Ҫ��s�զW��


                SortedList<string, List<string[]>> groupSList = ConvertToGroupInfo(erpBomList);

                WriteLog("�]�w�s�ծƸ���T");

                foreach (string s in groupSList.Keys)
                {
                    //WriteLog(String.Format("PN={0}",s));

                    List<string[]> list = groupSList[s];

                    //foreach (string[] t in list)
                    //{
                    //    WriteLog(String.Format("   {0},{1},{2}", t[0],t[1],t[2]));
                    //}
                }

                WriteLog("���s�ժ��z��}�l");

                // 2009/06/05 Add �s�ժ��z��
                SortedList<int, SortedList<string, SortedList<string, string>>> groupPN = GetConvertPN(groupSList);

                SortedList<string, int> pNList = ConvertToPNGroup(groupPN);

                foreach (string key in pNList.Keys)
                {
                    int num = pNList[key];

                    //WriteLog(String.Format("{0},{1}", key, num));
                                        
                }
                                

                WriteLog(String.Format("ERP-BOM List Count={0}", n));

                WriteLog("Step C Assembly PN Begin");

                if (n > 0)
                {
                    //��Ƥw�g���o�A�N���ƦC�զX
                    FormEntity form = new FormEntity();
                    form.FormId = FormNo;
                    form.FormDate = FormDate;

                    foreach (BOMBookingEntity m in waitingBomList)
                    {
                        m.FormNo = FormNo;
                        m.WorkStatus = Convert.ToString((int)AsusLibrary.EnumWorkStatus.Wait);
                    }

                    form.BomList = ChangeFormBom(waitingBomList, FormNo);

                    WriteLog("Step Get BOM List=" + form.BomList.Count);


                    form.PMFormList = ChangePMForm(waitingBomList, FormNo);
                    WriteLog("Step Get PM Form List=" + form.PMFormList.Count);


                    form.PNList = ChangePNList(erpBomList, FormNo, pNList);
                    WriteLog("Step Get PN List=" + form.PNList.Count);

                    //�إߤ@��ĳ�����
                    form.PNPriceList = new SortedList<string, PNPriceEntity>();
                    //form.PNPriceList = ChangePNPriceList(erpBomList, waitingBomList);
                    //WriteLog("Step Get PN Price List=" + form.PNPriceList.Count);


                    form.BOMPNList = ChangePNBOM(erpBomList, FormNo);
                    WriteLog("Step Get PN BOM List=" + form.BOMPNList.Count);

                    form.CreateTime = DateTime.Now.ToString();
                    form.CreateUser = "System";

                    FormLogic logic = new FormLogic();

                    WriteLog("Insert Form Begin");

                    if (logic.CreateForm(form))
                    {

                        WriteLog("�妸�iBOM��Ƨ����A�u�@����");
                    }
                    else
                    {
                        string errMessage = "��Ʒs�W�����D�A�Ьd����]";
                        //AlertAdmin(errMessage);
                        throw new Exception(errMessage);

                    }

                    WriteLog("Insert Form End");
                }
                else
                {
                    //string errMessage = "�L�k���o�iBOM�X�Ӫ�����Ƹ��A�Ьd���O�_�|�������iBOM�{���A�{������";
                    //AlertAdmin(errMessage);
                    
                    WriteLog("�L�k���o���ݱ��i��BOM��ơA�������B�J");

                }


                WriteLog("��sForm��T");

            }
            else
            {

                string errMessage = "�L�k���o���ݮiBOM��ơA�{������";
                //AlertAdmin(errMessage);
                WriteLog(errMessage);
            }
        }

        /// <summary>
        /// ���o���s�ծƸ������
        /// �ھڮƸ��U�h�ƦC
        /// ���Ʀp�U���
        /// GroupNo 
        ///        BOMId1+AssemblyNo1
        ///                         PN1,PN1
        ///                         PN2,PN2
        ///        BOMId2+AssemblyNo2
        ///                         PN3,PN3
        ///                         PN3,PN3      
        /// �`�@���T�h�A�N�Ҩ��o����ư��@�ӿz��
        /// </summary>
        /// <param name="groupSList"></param>
        /// <returns></returns>
        private SortedList<int, SortedList<string, SortedList<string, string>>> GetConvertPN(SortedList<string, List<string[]>> groupSList)
        {
            SortedList<int, SortedList<string, SortedList<string, string>>> group = new SortedList<int, SortedList<string, SortedList<string, string>>>();

            int number = 0;

            foreach (string pn in groupSList.Keys)
            {
                List<string[]> strArray = groupSList[pn];

                bool isFlag = false;

                int assemblyNo = 0;

                foreach (int num in group.Keys)
                {
                    SortedList<string, SortedList<string, string>> subGroup = group[num];

                    foreach (string[] sList in strArray)
                    {
                        if (subGroup.ContainsKey(sList[0] + sList[1]))
                        {
                            //�s�b �N��������n�[�W�h
                            assemblyNo = num;
                            isFlag = true;
                            break;
                        }
                    }

                }

                //�p�G�s�b���ܡA�N�����Ƥv�g�����ۤv���a
                if (isFlag)
                {
                    //�s�b
                    if (assemblyNo == 0)
                    {
                        throw new Exception("AssemblyNo �S�����");
                    }


                    foreach (string[] str in strArray)
                    {

                        if (group[assemblyNo].ContainsKey(str[0] + str[1]))
                        {
                            //�NPN Add SubList
                            if (!group[assemblyNo][str[0] + str[1]].ContainsKey(pn))
                            {
                                group[assemblyNo][str[0] + str[1]].Add(pn, pn);
                            }


                        }
                        else
                        {

                            //�p�G�̭����s�b�A�h�[�W�@�� PN List
                            SortedList<string, string> pnList = new SortedList<string, string>();

                            pnList.Add(pn, pn);

                            //�s�W�@��Sub Group
                            group[assemblyNo].Add(str[0] + str[1], pnList);
                        }

                    }
                }
                else
                {
                    //���s�b
                    number += 10;

                    SortedList<string, SortedList<string, string>> addGroup = new SortedList<string, SortedList<string, string>>();

                    SortedList<string, string> pnList = new SortedList<string, string>();

                    foreach (string[] str in strArray)
                    {
                        if (!addGroup.ContainsKey(str[0] + str[1]))
                        {
                            if (!pnList.ContainsKey(pn))
                            {
                                pnList.Add(pn, pn);
                            }

                            addGroup.Add(str[0] + str[1], pnList);
                        }

                    }

                    group.Add(number, addGroup);
                }


            }

            return group;


        }

        /// <summary>
        /// �N�s�ո���ഫ��PN�Τ@�Ӹs�ծƸ�
        /// </summary>
        /// <param name="groupPN"></param>
        /// <returns></returns>
        private SortedList<string, int> ConvertToPNGroup(SortedList<int, SortedList<string, SortedList<string, string>>> groupPN)
        {
            SortedList<string, int> pnGroupList = new SortedList<string, int>();

            foreach (int num in groupPN.Keys)
            {

                foreach (SortedList<string, string> pnList in groupPN[num].Values)
                {
                    foreach (string s in pnList.Values)
                    {
                        if (!pnGroupList.ContainsKey(s))
                        {
                            //���s�b
                            pnGroupList.Add(s, num);
                        }

                    }


                }
            }

            return pnGroupList;
        }

        /// <summary>
        /// ����User BOM �{��
        /// By User
        /// </summary>
        private void GenerateUserBOM()
        {
            string message = "";
            //���o�������B�zBOM���H���M��
            string[] waitingUser = GetWaitingUserList();

            if (waitingUser != null)
            {
                foreach (string s in waitingUser)
                {
                    WriteLog("User-->" + s);

                    GenerateFormBom(s);
                }

                //AlertSourcer("�v�g�i�}�����A�ФWe-NPI��g�^�Ф��e");
            }
            else
            {
                message += "�LBOM�i�H�i�}�A�u�@����-�H�o�q���H�q��Admin";

                WriteLog(message);

            }
        }

        /// <summary>
        /// ���o�Ҧ����s�ծƸ��ݩʸ��
        /// </summary>
        /// <param name="erpBomList"></param>
        /// <returns></returns>
        public SortedList<string, List<string[]>> ConvertToGroupInfo(List<AsusBomEntity> erpBomList)
        {
            SortedList<string, List<string[]>> list = new SortedList<string, List<string[]>>();

            foreach (AsusBomEntity s in erpBomList)
            {
                if (list.ContainsKey(s.PN))
                {
                    list[s.PN].Add(new string[] { s.BomId,s.AssemblyNo, s.IsSub });
                }
                else
                { 
                    List<string[]> newList= new List<string[]>();

                    newList.Add(new string[]{s.BomId,s.AssemblyNo,s.IsSub});

                    list.Add(s.PN, newList);
                }
            }

            return list;
        }

        /// <summary>
        /// �i�}���H��Form��BOM�B�z
        /// </summary>
        /// <param name="userId"></param>
        private void GenerateFormBom(string userId)
        {
            //WorkList
            List<string> workList = new List<string>();

            //�iBOM�ұo
            List<AsusBomEntity> erpBomList = new List<AsusBomEntity>(); //�ӱ����Ҫ�Erp Asus

            //���^����
            WriteLog("���^���ݪ�BOM List �}�l");

            List<BOMBookingEntity> waitingBomList = GetWatingBoms(userId);

            WriteLog(String.Format("���^���ݪ�BOM List �����A�`�@�O{0}��", waitingBomList.Count));

            if (waitingBomList.Count > 0)
            {
                //�s�WFormEntity

                //���oFormNo
                string FormNo = DateTime.Now.ToString("yyyyMMddHHmmss");


                WriteLog(string.Format("Bom Generate List={0}", waitingBomList.Count));

                int count = 0;

                WriteLog("Step A Generate Bom Begin");

                foreach (BOMBookingEntity t in waitingBomList)
                {
                    WriteLog(string.Format("{0}.{1}({2})", count, t.BOMId, t.BOMName));

                    string workNo = GetBOMPN(t.BOMId);

                    WriteLog(String.Format("{0}.workNo={1}", count, workNo));

                    if (workNo != "")
                    {
                        workList.Add(workNo);
                    }
                    else
                    {

                        WriteLog(String.Format("workNo=�ŭȡA�Ьd��{0}�O�_����", workNo));

                        throw new Exception("��Ʀ����~�A�Ьd���O�_�S������Ƹ��Ϊ̬O�{�����D");
                    }



                    WriteLog(string.Format("{0}-End", count));

                    count++;
                }

                WriteLog("Step A Generate Bom End");



                WriteLog(String.Format("Step B workNo List Count={0}", workList.Count.ToString()));

                //���o�Ҧ������i�����
                foreach (string s in workList)
                {
                    WriteLog(String.Format("({0})-Begin", s));

                    List<AsusBomEntity> AsusBomList = GetErpBomListByWorkNo(s);

                    foreach (AsusBomEntity ss in AsusBomList)
                    {
                        WriteLog(String.Format("     PN�GWorkNo={0},BOM={1},PN={2},Qty={3},Name={4},Desc={5}", new object[] { ss.WorkNo, ss.BomId, ss.PN, ss.Qty, ss.PNName, ss.PNDesc }));
                        erpBomList.Add(ss); //�զX�Ҧ������
                        WriteLog("PN Add End");
                    }

                    WriteLog(String.Format("({0})-End", s));
                }

                WriteLog("Step B Finish");

                int n = erpBomList.Count;

                WriteLog(String.Format("ERP-BOM List Count={0}", n));

                WriteLog("Step C Assembly PN Begin");

                if (n > 0)
                {
                    //��Ƥw�g���o�A�N���ƦC�զX
                    FormEntity form = new FormEntity();
                    form.FormId = FormNo;
                    form.FormDate = DateTime.Now.ToString();

                    foreach (BOMBookingEntity m in waitingBomList)
                    {
                        m.FormNo = FormNo;
                        m.WorkStatus = Convert.ToString((int)AsusLibrary.EnumWorkStatus.Wait);
                    }



                    form.BomList = ChangeFormBom(waitingBomList, FormNo);

                    WriteLog("Step Get BOM List=" + form.BomList.Count);


                    form.PMFormList = ChangePMForm(waitingBomList, FormNo);
                    WriteLog("Step Get PM Form List=" + form.PMFormList.Count);

                    
                    //form.PNList = ChangePNList(erpBomList, FormNo);
                    WriteLog("Step Get PN List=" + form.PNList.Count);

                    //�إߤ@��ĳ�����
                    form.PNPriceList = ChangePNPriceList(erpBomList, waitingBomList);
                    WriteLog("Step Get PN Price List=" + form.PNPriceList.Count);


                    form.BOMPNList = ChangePNBOM(erpBomList, FormNo);
                    WriteLog("Step Get PN BOM List=" + form.BOMPNList.Count);

                    form.CreateTime = DateTime.Now.ToString();
                    form.CreateUser = "System";

                    FormLogic logic = new FormLogic();

                    WriteLog("Insert Form Begin");

                    if (logic.CreateForm(form))
                    {
                        
                        WriteLog("�妸�iBOM��Ƨ����A�u�@����");
                    }
                    else
                    {
                        string errMessage = "��Ʒs�W�����D�A�Ьd����]";
                        //AlertAdmin(errMessage);
                        throw new Exception(errMessage);

                    }

                    WriteLog("Insert Form End");
                }
                else
                {
                    string errMessage = "�L�k���o�iBOM�X�Ӫ�����Ƹ��A�Ьd���O�_�|�������iBOM�{���A�{������";
                    //AlertAdmin(errMessage);
                    WriteLog(errMessage);
                   
                }


                WriteLog("��sForm��T");

            }
            else
            {
                
                string errMessage = "�L�k���o���ݮiBOM��ơA�{������";
                
                WriteLog(errMessage);
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
                string mailServer = LoginInfo.MailServer;

                int mailPort = Convert.ToInt16(LoginInfo.MailPort);

                string to = "";

                to += LoginInfo.AttachTo;

                foreach (string s in mailUserList)
                {
                    WriteLog("�H��=>" + s);
                    UserLogic userLogic = new UserLogic();

                    EmployeeEntity emp = logic.GetUserInfo(s, LoginInfo.Company);


                    WriteLog("Email=" + emp.EmpEmail);

                    if (emp.EmpEmail.Trim() != "")
                    {
                        to += "," + emp.EmpEmail;
                    }
                    else
                    {
                        WriteLog("Email=" + emp.EmpAccountId + "-(�Ьd�����H��Email�O�_�s�b)");
                    }
                    
                }


                string from = "srm@asus.com.tw";

                string subject = String.Format("E-NPI�^�и�Ƴq�� at {0}", DateTime.Now.ToString("yyyy/MM/dd"));
                WriteLog("���^Body-Begin");

                string body = "";

                body += "<p>Dear ALL):</p>";

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

                WriteLog("���^Body-OK");

                MailUtil.SendBodyHtml(mailServer, mailPort, from, to, subject, body, true, rList);

                WriteLog("�H�H����");



            }
            else
            {
                WriteLog("�L��ơA�{�����槹��");
            }

        }

        /// <summary>
        /// �H�o�H��
        /// </summary>
        /// <param name="message"></param>
        private void AlertAdmin(string message)
        {
            
            string mailServer = LoginInfo.MailServer;

            int mailPort = Convert.ToInt16(LoginInfo.MailPort);

            string to = "";

            to += LoginInfo.AttachTo;

            string from = "srm@asus.com.tw";

            string subject = String.Format("{0}-NPI�妸��Ʋ��`�B�z�q��", DateTime.Now.ToString("yyyy/MM/dd"));
            

            string body = "";

            body = "<p>Dear All</p>";

            body += "<p><font color=red>" + message + "</font></p>";

            body += "<p><font color=red>�Ьd��</font></p>";

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

            
                
        }

        private List<BOMBookingEntity> GetWatingBoms(string userId)
        {
           
            BOMLogic logic = new BOMLogic();
            
            return logic.QueryBookingBomList(AsusLibrary.EnumWorkStatus.Wait,userId);
        }

        private string[] GetWaitingUserList()
        {
            BOMLogic logic = new BOMLogic();

            return logic.QueryWaitingBookingBomsUser();
        }

        private string GetBOMPN(string bomId)
        {
            WriteLog(String.Format("�}�l�iBOM={0}���",bomId));

            DBServer insDB = new DBServer();

            WriteLog(String.Format("DB ConnectionString={0}", insDB.ConnectionString));

            insDB.CloseConnAfterExec = false;

            DBServer insDBErp = new DBServer("ERP");

            WriteLog(String.Format("ERP ConnectionString={0}", insDBErp.ConnectionString));

            insDBErp.CloseConnAfterExec = false;

            WriteLog("�}�l�iBOM���");

            ERPSync insERPSync = new ERPSync(insDB, insDBErp);

            insERPSync.DlBomPoPartsThenStop = true;

            insERPSync.DlBomSubParts = true; // �O�_�n���N��

            insERPSync.DlBomLevelLimitTwo = false; // ���խ���U���h��

            insERPSync.DlBomN2N = true;

            WriteLog("DownLoad BOM");

            string workNo = insERPSync.DownloadBom(bomId);

            WriteLog(String.Format("WorkNo={0}", workNo));

            insDB.CloseConnection();
            insDBErp.CloseConnection();

            WriteLog(String.Format("�����iBOM��T"));

            return workNo;
        }

        /// <summary>
        /// ���o�@��WorkNo���U�����
        /// </summary>
        /// <param name="workNo"></param>
        /// <returns></returns>
        private List<AsusBomEntity> GetErpBomListByWorkNo(string workNo)
        {
            AsusBomLogic logic = new AsusBomLogic();

            return logic.GetERPBomList(workNo);
        }

        private List<FormBomEntity> ChangeFormBom(List<BOMBookingEntity> waitingBomList,string formNo)
        {
            List<FormBomEntity> list = new List<FormBomEntity>();

            foreach (BOMBookingEntity t in waitingBomList)
            {
                FormBomEntity b = new FormBomEntity();

                b.BOMId = t.BOMId;
                b.BookingUpdateTime = DateTime.Now.ToString();
                b.BookingUpdateUser = "System";
                b.CompanyId = t.CompanyId;
                b.EmpId = t.EmpId;
                b.FormNo = formNo;
                b.WorkStatus = Convert.ToString((int)AsusLibrary.EnumWorkStatus.Complete);

                list.Add(b);
            }

            return list;
        }

        private SortedList<string,FormPMUserEntity> ChangePMForm(List<BOMBookingEntity> waitingBomList,string formNo)
        {
            SortedList<string, FormPMUserEntity> list = new SortedList<string, FormPMUserEntity>();

            foreach (BOMBookingEntity t in waitingBomList)
            {
                string myKey = t.EmpId + t.CompanyId + formNo;

                if (!list.ContainsKey(myKey))
                {
                    FormPMUserEntity b = new FormPMUserEntity();

                    b.FormId = formNo;
                    b.PMCompanyId = t.CompanyId;
                    b.PMUserId = t.EmpId;
                    list.Add(myKey, b);
                }
               
            }

            return list;
        }


        private SortedList<string,FormPNEntity> ChangePNList(List<AsusBomEntity> erpBomList,string formNo,SortedList<string, int> assemblyPNList)
        {
            SortedList<string, FormPNEntity> list = new SortedList<string, FormPNEntity>();

            foreach (AsusBomEntity t in erpBomList)
            {
                string myKey = t.PN + formNo;

                if (!list.ContainsKey(myKey))
                {
                    FormPNEntity b = new FormPNEntity();

                    b.CreateTime = DateTime.Now.ToString();
                    b.CreateUser = "System";
                    b.FormId = formNo;
                    b.PN = t.PN;
                    b.PNDesc = t.PNDesc;
                    b.PNName = t.PNName;

                    //Add 2009/06/05 �[�W�s�ժ��s��Id,���s�A���@���z�諸�ʧ@
                    if (assemblyPNList.ContainsKey(t.PN))
                    {
                        b.AssemblyNo = assemblyPNList[t.PN].ToString();
                    }
                    else
                    {
                        b.AssemblyNo = "";
                    }
                    
                    
                    b.IsSub = "";
                    b.UpdateTime = DateTime.Now.ToString();
                    b.UpdateUser = "System";

                    
                    list.Add(myKey, b);
                }

            }

            return list;
        }

        /// <summary>
        /// ���oMain PN List
        /// ����Ƨ�h
        /// </summary>
        /// <param name="erpBomList"></param>
        /// <param name="formNo"></param>
        /// <param name="assemblyPNList"></param>
        /// <returns></returns>
        private SortedList<string,GenPNEntity> ChangeMainPNList(List<AsusBomEntity> erpBomList, string mainId, SortedList<string, int> assemblyPNList)
        {
            SortedList<string, GenPNEntity> list = new SortedList<string, GenPNEntity>();

            foreach (AsusBomEntity t in erpBomList)
            {
                string myKey = t.PN + mainId;

                if (!list.ContainsKey(myKey))
                {
                    GenPNEntity b = new GenPNEntity();
                                        
                    b.CreateTime = DateTime.Now.ToString();
                    b.CreateUser = "System";
                    b.MainId = mainId;
                    b.PN = t.PN;
                    b.PNDesc = t.PNDesc;
                    b.PNName = t.PNName;

                    //Add 2009/06/05 �[�W�s�ժ��s��Id,���s�A���@���z�諸�ʧ@
                    if (assemblyPNList.ContainsKey(t.PN))
                    {
                        b.AssemblyNo = assemblyPNList[t.PN].ToString();
                    }
                    else
                    {
                        b.AssemblyNo = "";
                    }


                    b.IsSub = "*";
                    b.UpdateTime = DateTime.Now.ToString();
                    b.UpdateUser = "System";


                    list.Add(myKey, b);
                }

            }

            return list;
        }

        private SortedList<string,FormPNBomEntity> ChangePNBOM(List<AsusBomEntity> erpBomList,string formNo)
        {
            SortedList<string, FormPNBomEntity> list = new SortedList<string, FormPNBomEntity>();

            foreach (AsusBomEntity t in erpBomList)
            {
                string myKey = t.BomId+t.PN + formNo;

                if (!list.ContainsKey(myKey))
                {
                    FormPNBomEntity b = new FormPNBomEntity();

                    b.BomId = t.BomId;
                    b.CreateTime = DateTime.Now.ToString();
                    b.CreateUser = "System";
                    b.FormId = formNo;
                    b.PN = t.PN;
                    b.Qty = t.Qty;
                    
                    //Add Data
                    b.AssemblyNo = t.AssemblyNo;
                    b.AssemblyType = t.IsSub;

                    b.UpdateTime = DateTime.Now.ToString();
                    b.UpdateUser = "System";
                    b.WorkNo = t.WorkNo;


                    list.Add(myKey, b);
                }

            }

            return list;
        }


        /// <summary>
        /// ���oPN Price List
        /// �o�O�n�զX������
        /// </summary>
        /// <param name="pnList"></param>
        /// <param name="bomList"></param>
        /// <returns></returns>
        private SortedList<string, PNPriceEntity> ChangePNPriceList(List<AsusBomEntity> pnList, List<BOMBookingEntity> bomList)
        {
            WriteLog("���o�ثe�w�s�b�bNPI_PNPrice Table �H���ഫ��Dictionary");
            //���o�ثe�w�s�b�bNPI_PNPrice Table �H���ഫ��Dictionary
            Dictionary<string, PNPriceEntity> dicPNPriceList = ConvertToPNPriceDic();
            WriteLog(String.Format("���o��e�w�g�s�b��Ƶ����A��o����={0}��",dicPNPriceList.Values.Count));

            WriteLog("�}�l�����-�}�l");
            SortedList<string, PNPriceEntity> pricePNList = ConvertPNPriceListToGeteNewPNPriceList(dicPNPriceList, bomList, pnList);
            WriteLog("�}�l�����-����");

            //���^�{���ݭn�W�[�����
            return pricePNList;
        }

        /// <summary>
        /// ���o�ثe�b��Ʈw����������u�~�ת����
        /// </summary>
        /// <returns></returns>
        private List<PNPriceEntity> GetNowPNPriceList()
        {
            SourcerLogic sLogic = new SourcerLogic();

            //���o�{�b���~�שu
            string yearQ = DateUtil.GetQuarter(DateTime.Now);


            List<PNPriceEntity> nowPriceList =sLogic.GetPNQuarterPriceList(yearQ);

            return nowPriceList;
        }



        /// <summary>
        /// ��List Convert To Dictionary
        /// �N��ƥ�List�ഫ��Dictionary
        /// Key�Ȭ�PN+YearQ+Site���ߤ@
        /// </summary>
        /// <param name="pnList"></param>
        /// <returns></returns>
        private Dictionary<string, PNPriceEntity> ConvertToPNPriceDic()
        {
            //���^�ثe�w�����~�שu����ƨҦp2008Q4
            List<PNPriceEntity> pnList = GetNowPNPriceList();

            Dictionary<string, PNPriceEntity> dicPNPriceList = new Dictionary<string, PNPriceEntity>();

            foreach (PNPriceEntity t in pnList)
            {
                dicPNPriceList.Add(t.PN+t.YearQ+t.Site, t); //Key�ȥ[PN+YearQ+Site�O��Key
            }

            return dicPNPriceList;
        }

        /// <summary>
        /// ���^�ثe�ݭn�s�W��New PN List
        /// Sorted Key= PN+YearQ+Site
        /// </summary>
        /// <param name="dicPNPriceList">�ثe�w���D��PNPriceList</param>
        /// <param name="bomList">�ثe�Ҧ���BOM</param>
        /// <param name="pnList">Form PN List</param>
        /// <returns>�ഫ�����</returns>
        private SortedList<string, PNPriceEntity> ConvertPNPriceListToGeteNewPNPriceList(Dictionary<string, PNPriceEntity> dicPNPriceList, List<BOMBookingEntity> bomList, List<AsusBomEntity> pnList)
        {
            WriteLog(String.Format("���PN��ơA�`�@PN��{0}��",pnList.Count));
            SortedList<string, PNPriceEntity> sList = new SortedList<string, PNPriceEntity>();

            //�����o�ثe��BomList
            WriteLog(String.Format("���BOM��ơA�`�@PN��{0}��", bomList.Count));
            Dictionary<string, BOMBookingEntity> dicBomList=ConvertBomListToDictionary(bomList);

            int count = 1;
            //�ഫ�ثe��PN List
            foreach (AsusBomEntity p in pnList)
            {
                WriteLog(String.Format("����{0}/{2},PN={1}",count,p.PN,pnList.Count));

                string pn=p.PN;

                string site="";

                string desc = p.PNName;

                string spec = p.PNDesc;

                string yearQ=DateUtil.GetQuarter(DateTime.Now);

                if(dicBomList.ContainsKey(p.BomId))
                {
                    //WriteLog("���oSite");
                    //���oSite Zone
                    site=dicBomList[p.BomId.Trim()].PVTLocation; //EMS Site

                    //WriteLog(String.Format("���oSite-{0}",site));
                }
                else
                {
                    WriteLog(String.Format("�L�k���oBOM�PPN�����Y�L�k�A�Ьd����]BOMId={0},PN={1}", p.BomId, p.PN));
                    throw new Exception(String.Format("�L�k���oBOM�PPN�����Y�L�k�A�Ьd����]BOMId={0},PN={1}",p.BomId,p.PN));
                }

                if (site == "")
                {
                    WriteLog(String.Format("�L�k��o��BOM��Site BOMId={0}", p.BomId));
                    throw new Exception(String.Format("�L�k��o��BOM��Site BOMId={0}",p.BomId));
                }

                if (!dicPNPriceList.ContainsKey(pn+yearQ+site)) //Key�ȥ]�A��PN+earQ+site
                {

                    WriteLog(String.Format("�[�JPN={0},Site={1}",pn,site));

                    //�N�}�l���ഫ�u�@
                    //12/15 �[�F�T��Desc Spec Buying Mode�T��
                    PNPriceEntity obj = new PNPriceEntity();

                    obj.PN = pn;
                    WriteLog(String.Format("�[�JYearQ={0}",yearQ));
                    obj.YearQ = yearQ;
                    obj.Site = site;
                    WriteLog(String.Format("�[�JDesc={0}", desc));
                    obj.PNDesc = desc;
                    WriteLog(String.Format("�[�JSpec={0}", spec));
                    obj.PNSpec = spec;
                    WriteLog(String.Format("�[�JBuyingMode={0}","�ŭ�"));
                    obj.BuyingMode = "N";
                    
                    //obj.BuyingMode = GetSitePNBuyingMode(site,pn);

                    //WriteLog(String.Format("���oBuyingMode={0}",obj.BuyingMode));
                    obj.CreateUser = "System";
                    
                    WriteLog(String.Format("�[�J���", "System"));
                    if (!sList.ContainsKey(pn + yearQ + site))
                    {
                        sList.Add(pn + yearQ + site, obj);

                        WriteLog(String.Format("�[�J����"));
                    }
                    else
                    {
                        WriteLog(String.Format("��Ƥw�s�b"));
                    }
                    
                }

                count++;
            }

            WriteLog(String.Format("PN��ƨ��o����"));

            return sList;
            
        }

        /// <summary>
        /// ���^Buying Mode
        /// �p�G�S�����A��������~
        /// </summary>
        /// <param name="site"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        private string GetSitePNBuyingMode(string site, string pn)
        {
            SourcerLogic logic = new SourcerLogic();

            string buyingMode = logic.GetBuyingMode(site, pn,LoginInfo.ConSignSite);

            if (buyingMode == "")
            {
                buyingMode = "N";
                WriteLog(String.Format("�L�k���oBuyMode��ơA�Ьd����]pn={1},site={0}", site, pn));
                //throw new Exception(String.Format("�L�k���oBuyMode��ơA�Ьd����]pn={1},site={0}",site,pn));
            }

            return buyingMode;
            
        }

        /// <summary>
        /// �ഫBOM List��Dictionary
        /// ���F��K���Ͳ��a��Web Site
        /// 
        /// </summary>
        /// <param name="bomList"></param>
        /// <returns></returns>
        private Dictionary<string, BOMBookingEntity> ConvertBomListToDictionary(List<BOMBookingEntity> bomList)
        {
            Dictionary<string, BOMBookingEntity> dicList = new Dictionary<string, BOMBookingEntity>();

            foreach (BOMBookingEntity t in bomList)
            {
                dicList.Add(t.BOMId, t);
            }

            return dicList;
        }


    }
}
