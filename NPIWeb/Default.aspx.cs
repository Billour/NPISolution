using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Asus.Data;

using System.Data.OleDb;
using AsusLibrary.WebPage;
using Asus;
using AsusLibrary.Utility;
using AsusLibrary;

using AsusWeb.Page;

using log4net;

namespace NPIWeb
{
    public partial class _Default : BasePage
    {
        private ILog log = LogManager.GetLogger(typeof(_Default));

        protected void Page_Load(object sender, EventArgs e)
        {
            //string aa = DateUtil.GetQuarter(DateTime.Now);

            //string bb = "";


            //if (!this.IsPostBack)
            //{
            //    lbLoginUser.Text = String.Format("{0}({1})",LoginUserInfo.UserEnglishName, LoginUserInfo.UserChineseName);
            //}

            //lbUser.Text = LoginUserInfo.UserChineseName;

            //EnumMapHelper.GetStringFromEnum(EnumWorkStatus.Wait);

            //lbUser.Text = Request.Url.Host;


            

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SortedList<string, List<string[]>> groupSList = GetGroupList();


            SortedList<int, SortedList<string, SortedList<string, string>>> groupPN = GetConvertPN(groupSList);

            SortedList<string, int> pNList = ConvertToPNGroup(groupPN);

            foreach (string key in pNList.Keys)
            {
                int num = pNList[key];

                log.Info(String.Format("{0},{1}",key,num));

                Response.Write(String.Format("{0},{1}<br>", key, num));
            }

            

        }

        private SortedList<string, int> ConvertToPNGroup(SortedList<int, SortedList<string, SortedList<string, string>>> groupPN)
        {
            SortedList<string, int> pnGroupList = new SortedList<string, int>();

            foreach (int num in groupPN.Keys)
            {

                foreach (SortedList<string, string> pnList in groupPN[num].Values)
                { 
                    foreach(string s in pnList.Values)
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
                            SortedList<string, string> pnList = new SortedList<string,string>();

                            pnList.Add(pn,pn);

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

                    SortedList<string, string> pnList = new SortedList<string,string>();

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



        private SortedList<string, List<string[]>> GetGroupList()
        {
            SortedList<string, List<string[]>> groupSList = new SortedList<string, List<string[]>>();

            List<string[]> list = null;

            string[] strArray = null;


            list = new List<string[]>();

            strArray = new string[] { "60-OA19MB2000-C01P", "10", "N" };

            list.Add(strArray);

            strArray = new string[] { "60-OA19MB2000-C01P", "10", "N" };

            list.Add(strArray);

            strArray = new string[] { "80OA-S19B111111000", "10", "N" };

            list.Add(strArray);

            strArray = new string[] { "80OA-S19B111111000", "10", "N" };

            list.Add(strArray);

            strArray = new string[] { "80OA-S19B111111000", "10", "N" };

            list.Add(strArray);

            strArray = new string[] { "80OA-S19B111111001", "10", "N" };

            list.Add(strArray);


            groupSList.Add("01G012990002", list);

            //2
            list = new List<string[]>();

            strArray = new string[] { "60-OA19MB2000-C01P", "20", "N" };

            list.Add(strArray);

            strArray = new string[] { "60-OA19MB2000-C01P", "20", "N" };

            list.Add(strArray);

            strArray = new string[] { "80OA-S19B111111000", "20", "N" };

            list.Add(strArray);

            strArray = new string[] { "80OA-S19B111111000", "20", "N" };

            list.Add(strArray);

            strArray = new string[] { "80OA-S19B111111000", "20", "N" };

            list.Add(strArray);

            strArray = new string[] { "80OA-S19B111111001", "20", "N" };

            list.Add(strArray);


            groupSList.Add("02G010007741", list);


            //3
            list = new List<string[]>();

            strArray = new string[] { "60-OA19MB2000-C01P", "30", "N" };

            list.Add(strArray);

            strArray = new string[] { "60-OA19MB2000-C01P", "30", "N" };

            list.Add(strArray);

            strArray = new string[] { "80OA-S19B111111000", "30", "N" };

            list.Add(strArray);

            strArray = new string[] { "80OA-S19B111111000", "30", "N" };

            list.Add(strArray);

            strArray = new string[] { "80OA-S19B111111000", "30", "N" };

            list.Add(strArray);

            strArray = new string[] { "80OA-S19B111111001", "30", "N" };

            list.Add(strArray);

            groupSList.Add("02G010018202", list);


            //4
            list = new List<string[]>();

            strArray = new string[] { "60-OA00RH4000-B01P", "10", "N" };

            list.Add(strArray);

            strArray = new string[] { "70-OA00RH4000P", "10", "N" };

            list.Add(strArray);

            groupSList.Add("02G033001110", list);

            
            //5
            list = new List<string[]>();

            strArray = new string[] { "60-OA19IO1000-B01P", "10", "N" };

            list.Add(strArray);

            strArray = new string[] { "60-OA19IO1000-B01P", "10", "N" };

            list.Add(strArray);

            strArray = new string[] { "80OA-S19B111111000", "10", "N" };

            list.Add(strArray);

            strArray = new string[] { "80OA-S19B111111001", "10", "N" };

            list.Add(strArray);

            strArray = new string[] { "80OA-S19B111111001", "10", "N" };

            list.Add(strArray);

            groupSList.Add("02G611005005", list);

            //6
            list = new List<string[]>();

            strArray = new string[] { "60-OA19CR1000-A01P", "10", "N" };

            list.Add(strArray);

            strArray = new string[] { "60-OA19CR1000-A01P", "10", "N" };

            list.Add(strArray);

            strArray = new string[] { "80OA-S19B111111000", "10", "N" };

            list.Add(strArray);

            strArray = new string[] { "80OA-S19B111111001", "10", "N" };

            list.Add(strArray);

            groupSList.Add("02G630000603", list);

            return groupSList;
        }

        

        //private void GetTableMetaData()
        //{
        //    OleDbConnection conn = null;

        //    string strConn = "Provider=OraOLEDB.Oracle;Data Source=TP-LOTDB-01.CORPNET.ASUS;User ID=shinewave;Password=shinewave";


        //    try
        //    {
        //        conn = new OleDbConnection(strConn);
        //        conn.Open();

        //        //取得Table
        //        //DataTable schemaTable = conn.GetOleDbSchemaTable(
        //        //    OleDbSchemaGuid.Tables,
        //        //    new object[] { null, "SHINEWAVE", null, "TABLE" });

        //        //GridView1.DataSource = schemaTable;
        //        //GridView1.DataBind();



        //        //DataTable schemaTableColumn = conn.GetOleDbSchemaTable(
        //        //   OleDbSchemaGuid.Columns, new object[] { null, "SHINEWAVE", "SEX", null });


        //        //GridView2.DataSource = schemaTableColumn;
        //        //GridView2.DataBind();

        //        //DataTable schemaTablePKKey = conn.GetOleDbSchemaTable(
        //        //   OleDbSchemaGuid.Primary_Keys, new object[] { null, "SHINEWAVE", "TESTUSER" });

        //        //GridView3.DataSource = schemaTablePKKey;
        //        //GridView3.DataBind();

        //        ////FK
        //        //DataTable schemaTableFKKey = conn.GetOleDbSchemaTable(
        //        //   OleDbSchemaGuid.Foreign_Keys, new object[] { null,null , null, null, "SHINEWAVE", "TESTUSER" });

        //        DataTable dt1 = DbAssistant.DoSelect("select a.table_name,b.comments from user_tables a,user_tab_comments b where a.TABLE_NAME=b.table_name(+) order by a.TABLE_NAME");

        //        GridView1.DataSource = dt1;
        //        GridView1.DataBind();



        //    }
        //    catch (OleDbException ex)
        //    {
        //        Trace.Write(ex.Message);
        //        Response.Write(ex.Message);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
            
        //}

        //protected void bn_Click(object sender, EventArgs e)
        //{
        //    lbUser.Text=cal.Text;
        //}
    }
}
