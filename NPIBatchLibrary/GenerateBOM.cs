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
    /// 產生BOM資訊
    /// 本功能正常
    /// </summary>
    public class GenerateBOM:BaseApp
    {
        /// <summary>
        /// 產生BOM產生程式
        /// Add:新增一個Job
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

                //產生群組資料BOM資料
                GenerateGroupBOM();               

                //產生NPI主檔資料
                GenerateNPIMain(genId);
                
                message += "e-NPI工作完成";
                //AlertAdmin(message);

                isFlag = true;

                AlertSourcer("己經展開完畢，請上e-NPI填寫回覆內容");

                status = EnumStatus.success;
                return 1;
            }
            catch (Exception ex)
            {
                WriteLog("程式失敗："+ex.InnerException.Message +ex.Message + ex.StackTrace);
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
                    //一次一個群組
                    WriteLog("Group-->" + s.GroupId);

                    GenerateGroupFormBom(s.GroupId);
                }

                
            }
            else
            {
                message += "無Group可以展開，工作結束-寄發通知信通知Admin";

                WriteLog(message);

            }
        }

        /// <summary>
        /// 產生NPI主檔
        /// </summary>
        private void GenerateNPIMain(string genId)
        {

            GenNPIEntity obj = GetMainObject(genId);

            if (obj == null)
            {
                WriteLog("Gen Main 資料為空值，程式結束");
            }
            else
            {
                GenLogic logic = new GenLogic();

                if (logic.InsertNewMain(obj))
                {
                    WriteLog("Gen資料新增完成");
                }
                else
                {
                    WriteLog("Gen資料新增失敗");

                    throw new Exception("Gen資料新增失敗");
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

                //Main主檔
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

                //開始取得PN List

                List<AsusBomEntity> erpBomList = new List<AsusBomEntity>();

                //取得所有的延展的資料
                foreach (string s in workList)
                {
                    WriteLog(String.Format("({0})-Begin", s));

                    List<AsusBomEntity> AsusBomList = GetErpBomListByWorkNo(s);

                    foreach (AsusBomEntity ss in AsusBomList)
                    {
                        //WriteLog(String.Format("     PN：WorkNo={0},BOM={1},PN={2},Qty={3},Name={4},Desc={5}", new object[] { ss.WorkNo, ss.BomId, ss.PN, ss.Qty, ss.PNName, ss.PNDesc }));
                        erpBomList.Add(ss); //組合所有的資料
                        //WriteLog("PN Add End");
                    }

                    WriteLog(String.Format("({0})-End", s));
                }

                SortedList<string, List<string[]>> groupSList = ConvertToGroupInfo(erpBomList);

                // 2009/06/05 Add 群組的篩選
                SortedList<int, SortedList<string, SortedList<string, string>>> groupPN = GetConvertPN(groupSList);

                SortedList<string, int> pNList = ConvertToPNGroup(groupPN); //取得所有的資料

                obj.GenPNList = ChangeMainPNList(erpBomList,genId, pNList); //取得PN List

            }

            return obj;
        }

        /// <summary>
        /// 取得等待的群組
        /// </summary>
        /// <returns></returns>
        private List<GroupMapEntity> GetWaitingGroup()
        {
            GroupLogic logic = new GroupLogic();

            return logic.QueryGroupList();
        }

        /// <summary>
        /// 取得群組的BOM資料
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
        /// 以群組來
        /// </summary>
        /// <param name="groupId"></param>
        private void GenerateGroupFormBom(string groupId)
        {
            //WorkList
            List<string> workList = new List<string>();

            //展BOM所得
            List<AsusBomEntity> erpBomList = new List<AsusBomEntity>(); //來接受所的Erp Asus

            //取回等待
            WriteLog("取回等待的BOM List 開始");

            List<BOMBookingEntity> waitingBomList = GetWatingGroupBoms(groupId);

            WriteLog(String.Format("取回等待的BOM List 結束，總共是{0}筆", waitingBomList.Count));

            if (waitingBomList.Count > 0)
            {
                //新增FormEntity

                //取得FormNo
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

                        WriteLog(String.Format("workNo=空值，請查明{0}是否有值", workNo));

                        throw new Exception("資料有錯誤，請查明是否沒有元件料號或者是程式問題");
                    }



                    WriteLog(string.Format("{0}-End", count));

                    count++;
                }

                WriteLog("Step A Generate Bom End");



                WriteLog(String.Format("Step B workNo List Count={0}", workList.Count.ToString()));

                //取得所有的延展的資料
                foreach (string s in workList)
                {
                    WriteLog(String.Format("({0})-Begin", s));

                    List<AsusBomEntity> AsusBomList = GetErpBomListByWorkNo(s);

                    foreach (AsusBomEntity ss in AsusBomList)
                    {
                        //WriteLog(String.Format("     PN：WorkNo={0},BOM={1},PN={2},Qty={3},Name={4},Desc={5}", new object[] { ss.WorkNo, ss.BomId, ss.PN, ss.Qty, ss.PNName, ss.PNDesc }));
                        erpBomList.Add(ss); //組合所有的資料
                        //WriteLog("PN Add End");
                    }

                    WriteLog(String.Format("({0})-End", s));
                }

                WriteLog("Step B Finish");

                int n = erpBomList.Count;

                //開始將所找到的BOM 2009/06/05 加入群組內容
                // {0}=AssemblyNo {1}=IsSub
                // groupSList 代表是取得此料號在此情況下所的群組名稱


                SortedList<string, List<string[]>> groupSList = ConvertToGroupInfo(erpBomList);

                WriteLog("設定群組料號資訊");

                foreach (string s in groupSList.Keys)
                {
                    //WriteLog(String.Format("PN={0}",s));

                    List<string[]> list = groupSList[s];

                    //foreach (string[] t in list)
                    //{
                    //    WriteLog(String.Format("   {0},{1},{2}", t[0],t[1],t[2]));
                    //}
                }

                WriteLog("做群組的篩選開始");

                // 2009/06/05 Add 群組的篩選
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
                    //資料已經取得，將做排列組合
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

                    //建立一個議價資料
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

                        WriteLog("批次展BOM資料完成，工作結束");
                    }
                    else
                    {
                        string errMessage = "資料新增有問題，請查明原因";
                        //AlertAdmin(errMessage);
                        throw new Exception(errMessage);

                    }

                    WriteLog("Insert Form End");
                }
                else
                {
                    //string errMessage = "無法取得展BOM出來的元件料號，請查明是否尚未完成展BOM程式，程式結束";
                    //AlertAdmin(errMessage);
                    
                    WriteLog("無法取得等待欲展的BOM資料，完成此步驟");

                }


                WriteLog("更新Form資訊");

            }
            else
            {

                string errMessage = "無法取得等待展BOM資料，程式結束";
                //AlertAdmin(errMessage);
                WriteLog(errMessage);
            }
        }

        /// <summary>
        /// 取得此群組料號的資料
        /// 根據料號下去排列
        /// 其資料如下表示
        /// GroupNo 
        ///        BOMId1+AssemblyNo1
        ///                         PN1,PN1
        ///                         PN2,PN2
        ///        BOMId2+AssemblyNo2
        ///                         PN3,PN3
        ///                         PN3,PN3      
        /// 總共有三層，將所取得的資料做一個篩選
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
                            //存在 代表全部都要加上去
                            assemblyNo = num;
                            isFlag = true;
                            break;
                        }
                    }

                }

                //如果存在的話，代表此顆料己經有找到自己的家
                if (isFlag)
                {
                    //存在
                    if (assemblyNo == 0)
                    {
                        throw new Exception("AssemblyNo 沒有找到");
                    }


                    foreach (string[] str in strArray)
                    {

                        if (group[assemblyNo].ContainsKey(str[0] + str[1]))
                        {
                            //將PN Add SubList
                            if (!group[assemblyNo][str[0] + str[1]].ContainsKey(pn))
                            {
                                group[assemblyNo][str[0] + str[1]].Add(pn, pn);
                            }


                        }
                        else
                        {

                            //如果裡面不存在，則加上一個 PN List
                            SortedList<string, string> pnList = new SortedList<string, string>();

                            pnList.Add(pn, pn);

                            //新增一個Sub Group
                            group[assemblyNo].Add(str[0] + str[1], pnList);
                        }

                    }
                }
                else
                {
                    //不存在
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
        /// 將群組資料轉換成PN及一個群組料號
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
                            //不存在
                            pnGroupList.Add(s, num);
                        }

                    }


                }
            }

            return pnGroupList;
        }

        /// <summary>
        /// 產生User BOM 程式
        /// By User
        /// </summary>
        private void GenerateUserBOM()
        {
            string message = "";
            //取得此次欲處理BOM的人員清單
            string[] waitingUser = GetWaitingUserList();

            if (waitingUser != null)
            {
                foreach (string s in waitingUser)
                {
                    WriteLog("User-->" + s);

                    GenerateFormBom(s);
                }

                //AlertSourcer("己經展開完畢，請上e-NPI填寫回覆內容");
            }
            else
            {
                message += "無BOM可以展開，工作結束-寄發通知信通知Admin";

                WriteLog(message);

            }
        }

        /// <summary>
        /// 取得所有的群組料號屬性資料
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
        /// 展開此人的Form的BOM處理
        /// </summary>
        /// <param name="userId"></param>
        private void GenerateFormBom(string userId)
        {
            //WorkList
            List<string> workList = new List<string>();

            //展BOM所得
            List<AsusBomEntity> erpBomList = new List<AsusBomEntity>(); //來接受所的Erp Asus

            //取回等待
            WriteLog("取回等待的BOM List 開始");

            List<BOMBookingEntity> waitingBomList = GetWatingBoms(userId);

            WriteLog(String.Format("取回等待的BOM List 結束，總共是{0}筆", waitingBomList.Count));

            if (waitingBomList.Count > 0)
            {
                //新增FormEntity

                //取得FormNo
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

                        WriteLog(String.Format("workNo=空值，請查明{0}是否有值", workNo));

                        throw new Exception("資料有錯誤，請查明是否沒有元件料號或者是程式問題");
                    }



                    WriteLog(string.Format("{0}-End", count));

                    count++;
                }

                WriteLog("Step A Generate Bom End");



                WriteLog(String.Format("Step B workNo List Count={0}", workList.Count.ToString()));

                //取得所有的延展的資料
                foreach (string s in workList)
                {
                    WriteLog(String.Format("({0})-Begin", s));

                    List<AsusBomEntity> AsusBomList = GetErpBomListByWorkNo(s);

                    foreach (AsusBomEntity ss in AsusBomList)
                    {
                        WriteLog(String.Format("     PN：WorkNo={0},BOM={1},PN={2},Qty={3},Name={4},Desc={5}", new object[] { ss.WorkNo, ss.BomId, ss.PN, ss.Qty, ss.PNName, ss.PNDesc }));
                        erpBomList.Add(ss); //組合所有的資料
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
                    //資料已經取得，將做排列組合
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

                    //建立一個議價資料
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
                        
                        WriteLog("批次展BOM資料完成，工作結束");
                    }
                    else
                    {
                        string errMessage = "資料新增有問題，請查明原因";
                        //AlertAdmin(errMessage);
                        throw new Exception(errMessage);

                    }

                    WriteLog("Insert Form End");
                }
                else
                {
                    string errMessage = "無法取得展BOM出來的元件料號，請查明是否尚未完成展BOM程式，程式結束";
                    //AlertAdmin(errMessage);
                    WriteLog(errMessage);
                   
                }


                WriteLog("更新Form資訊");

            }
            else
            {
                
                string errMessage = "無法取得等待展BOM資料，程式結束";
                
                WriteLog(errMessage);
            }
        }

        private void AlertSourcer(string message)
        {
            SourcerLogic logic = new SourcerLogic();
            //找目前所有的ourcer
            List<string> mailUserList = logic.GetMailSourcerList();

            foreach (string s in mailUserList)
            {
                WriteLog("人員=>" + s);
            }

            //寄信給Sourcer
            if (mailUserList.Count > 0)
            {
                string mailServer = LoginInfo.MailServer;

                int mailPort = Convert.ToInt16(LoginInfo.MailPort);

                string to = "";

                to += LoginInfo.AttachTo;

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

                string subject = String.Format("E-NPI回覆資料通知 at {0}", DateTime.Now.ToString("yyyy/MM/dd"));
                WriteLog("取回Body-Begin");

                string body = "";

                body += "<p>Dear ALL):</p>";

                body += @"
                        
                        <p></p>
                        
                        <p>提醒您一下，請於每週三進入E-NPI來回覆料況資料，謝謝~</p>

                        <p>E-NPI網址:</p>

                        <p><a href=https://scm.asus.com/npi/Index.aspx>https://scm.asus.com/npi/Index.aspx</a></p>


                        <p>詳細E-NPI流程:</p>
                        <ul>
                        <li>
                            <font color=red>PM 將Booking BOM的資料建於E-NPI系統上，建完之後，其狀態為等待展BOM。</font>
                        </li> 
                        <li>到星期二晚上１０：００結束建資料，１０：００會有一支排程資料將所有等待展BOM的資料展開。
                        </li> 
                        <li>所有的Sourcer在星期三之後可以上網回覆展BOM的資料，可以回覆至此星期四晚上10:00結案，周四晚上十點系統自動結案，將結果寄給RDPM，一旦結案之後，Sourcer只能瀏覽／下載而不能回覆。 
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



            }
            else
            {
                WriteLog("無資料，程式執行完畢");
            }

        }

        /// <summary>
        /// 寄發信件
        /// </summary>
        /// <param name="message"></param>
        private void AlertAdmin(string message)
        {
            
            string mailServer = LoginInfo.MailServer;

            int mailPort = Convert.ToInt16(LoginInfo.MailPort);

            string to = "";

            to += LoginInfo.AttachTo;

            string from = "srm@asus.com.tw";

            string subject = String.Format("{0}-NPI批次資料異常處理通知", DateTime.Now.ToString("yyyy/MM/dd"));
            

            string body = "";

            body = "<p>Dear All</p>";

            body += "<p><font color=red>" + message + "</font></p>";

            body += "<p><font color=red>請查明</font></p>";

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
            WriteLog(String.Format("開始展BOM={0}資料",bomId));

            DBServer insDB = new DBServer();

            WriteLog(String.Format("DB ConnectionString={0}", insDB.ConnectionString));

            insDB.CloseConnAfterExec = false;

            DBServer insDBErp = new DBServer("ERP");

            WriteLog(String.Format("ERP ConnectionString={0}", insDBErp.ConnectionString));

            insDBErp.CloseConnAfterExec = false;

            WriteLog("開始展BOM資料");

            ERPSync insERPSync = new ERPSync(insDB, insDBErp);

            insERPSync.DlBomPoPartsThenStop = true;

            insERPSync.DlBomSubParts = true; // 是否要替代料

            insERPSync.DlBomLevelLimitTwo = false; // 測試限制下載層數

            insERPSync.DlBomN2N = true;

            WriteLog("DownLoad BOM");

            string workNo = insERPSync.DownloadBom(bomId);

            WriteLog(String.Format("WorkNo={0}", workNo));

            insDB.CloseConnection();
            insDBErp.CloseConnection();

            WriteLog(String.Format("完成展BOM資訊"));

            return workNo;
        }

        /// <summary>
        /// 取得一個WorkNo之下的資料
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

                    //Add 2009/06/05 加上群組的群組Id,重新再做一次篩選的動作
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
        /// 取得Main PN List
        /// 此資料更多
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

                    //Add 2009/06/05 加上群組的群組Id,重新再做一次篩選的動作
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
        /// 取得PN Price List
        /// 這是要組合成價錢
        /// </summary>
        /// <param name="pnList"></param>
        /// <param name="bomList"></param>
        /// <returns></returns>
        private SortedList<string, PNPriceEntity> ChangePNPriceList(List<AsusBomEntity> pnList, List<BOMBookingEntity> bomList)
        {
            WriteLog("取得目前已存在在NPI_PNPrice Table 以及轉換成Dictionary");
            //取得目前已存在在NPI_PNPrice Table 以及轉換成Dictionary
            Dictionary<string, PNPriceEntity> dicPNPriceList = ConvertToPNPriceDic();
            WriteLog(String.Format("取得日前已經存在資料結束，找得筆數={0}筆",dicPNPriceList.Values.Count));

            WriteLog("開始比對資料-開始");
            SortedList<string, PNPriceEntity> pricePNList = ConvertPNPriceListToGeteNewPNPriceList(dicPNPriceList, bomList, pnList);
            WriteLog("開始比對資料-結束");

            //取回現今需要增加的資料
            return pricePNList;
        }

        /// <summary>
        /// 取得目前在資料庫中有關此當季年度的資料
        /// </summary>
        /// <returns></returns>
        private List<PNPriceEntity> GetNowPNPriceList()
        {
            SourcerLogic sLogic = new SourcerLogic();

            //取得現在的年度季
            string yearQ = DateUtil.GetQuarter(DateTime.Now);


            List<PNPriceEntity> nowPriceList =sLogic.GetPNQuarterPriceList(yearQ);

            return nowPriceList;
        }



        /// <summary>
        /// 由List Convert To Dictionary
        /// 將資料由List轉換成Dictionary
        /// Key值為PN+YearQ+Site為唯一
        /// </summary>
        /// <param name="pnList"></param>
        /// <returns></returns>
        private Dictionary<string, PNPriceEntity> ConvertToPNPriceDic()
        {
            //取回目前已有此年度季的資料例如2008Q4
            List<PNPriceEntity> pnList = GetNowPNPriceList();

            Dictionary<string, PNPriceEntity> dicPNPriceList = new Dictionary<string, PNPriceEntity>();

            foreach (PNPriceEntity t in pnList)
            {
                dicPNPriceList.Add(t.PN+t.YearQ+t.Site, t); //Key值加PN+YearQ+Site別為Key
            }

            return dicPNPriceList;
        }

        /// <summary>
        /// 取回目前需要新增的New PN List
        /// Sorted Key= PN+YearQ+Site
        /// </summary>
        /// <param name="dicPNPriceList">目前已知道的PNPriceList</param>
        /// <param name="bomList">目前所有的BOM</param>
        /// <param name="pnList">Form PN List</param>
        /// <returns>轉換成資料</returns>
        private SortedList<string, PNPriceEntity> ConvertPNPriceListToGeteNewPNPriceList(Dictionary<string, PNPriceEntity> dicPNPriceList, List<BOMBookingEntity> bomList, List<AsusBomEntity> pnList)
        {
            WriteLog(String.Format("比對PN資料，總共PN有{0}筆",pnList.Count));
            SortedList<string, PNPriceEntity> sList = new SortedList<string, PNPriceEntity>();

            //先取得目前的BomList
            WriteLog(String.Format("比對BOM資料，總共PN有{0}筆", bomList.Count));
            Dictionary<string, BOMBookingEntity> dicBomList=ConvertBomListToDictionary(bomList);

            int count = 1;
            //轉換目前的PN List
            foreach (AsusBomEntity p in pnList)
            {
                WriteLog(String.Format("筆數{0}/{2},PN={1}",count,p.PN,pnList.Count));

                string pn=p.PN;

                string site="";

                string desc = p.PNName;

                string spec = p.PNDesc;

                string yearQ=DateUtil.GetQuarter(DateTime.Now);

                if(dicBomList.ContainsKey(p.BomId))
                {
                    //WriteLog("取得Site");
                    //取得Site Zone
                    site=dicBomList[p.BomId.Trim()].PVTLocation; //EMS Site

                    //WriteLog(String.Format("取得Site-{0}",site));
                }
                else
                {
                    WriteLog(String.Format("無法取得BOM與PN之關係無法，請查明原因BOMId={0},PN={1}", p.BomId, p.PN));
                    throw new Exception(String.Format("無法取得BOM與PN之關係無法，請查明原因BOMId={0},PN={1}",p.BomId,p.PN));
                }

                if (site == "")
                {
                    WriteLog(String.Format("無法找得此BOM的Site BOMId={0}", p.BomId));
                    throw new Exception(String.Format("無法找得此BOM的Site BOMId={0}",p.BomId));
                }

                if (!dicPNPriceList.ContainsKey(pn+yearQ+site)) //Key值包括有PN+earQ+site
                {

                    WriteLog(String.Format("加入PN={0},Site={1}",pn,site));

                    //就開始做轉換工作
                    //12/15 加了三個Desc Spec Buying Mode三個
                    PNPriceEntity obj = new PNPriceEntity();

                    obj.PN = pn;
                    WriteLog(String.Format("加入YearQ={0}",yearQ));
                    obj.YearQ = yearQ;
                    obj.Site = site;
                    WriteLog(String.Format("加入Desc={0}", desc));
                    obj.PNDesc = desc;
                    WriteLog(String.Format("加入Spec={0}", spec));
                    obj.PNSpec = spec;
                    WriteLog(String.Format("加入BuyingMode={0}","空值"));
                    obj.BuyingMode = "N";
                    
                    //obj.BuyingMode = GetSitePNBuyingMode(site,pn);

                    //WriteLog(String.Format("取得BuyingMode={0}",obj.BuyingMode));
                    obj.CreateUser = "System";
                    
                    WriteLog(String.Format("加入資料", "System"));
                    if (!sList.ContainsKey(pn + yearQ + site))
                    {
                        sList.Add(pn + yearQ + site, obj);

                        WriteLog(String.Format("加入完成"));
                    }
                    else
                    {
                        WriteLog(String.Format("資料已存在"));
                    }
                    
                }

                count++;
            }

            WriteLog(String.Format("PN資料取得完畢"));

            return sList;
            
        }

        /// <summary>
        /// 取回Buying Mode
        /// 如果沒有找到，直接算錯誤
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
                WriteLog(String.Format("無法取得BuyMode資料，請查明原因pn={1},site={0}", site, pn));
                //throw new Exception(String.Format("無法取得BuyMode資料，請查明原因pn={1},site={0}",site,pn));
            }

            return buyingMode;
            
        }

        /// <summary>
        /// 轉換BOM List到Dictionary
        /// 為了方便取生產地的Web Site
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
