using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Asus.Data;
using AsusLibrary.Config;
using AsusLibrary.Entity;

using Asus.Bussiness.Map;

using System.Data.OracleClient;
using System.Data;

namespace AsusLibrary.Logic
{
    public class SourcerLogic:BaseUserLogic
    {
        public SourcerLogic()
            : base()
        { }

        /// <summary>
        /// 取得Sourcer資訊
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public SourcerEntity GetSourcerUser(string empId,string companyId)
        {
            return GetRoleUser<SourcerEntity>(empId, EnumRole.Sourcer,companyId);
        }

        /// <summary>
        /// 取得需要寄信之Sourcer人員
        /// </summary>
        /// <returns></returns>
        public List<string> GetMailSourcerList()
        {
            string sql = @"　select distinct(t.user_id)as users 
                            from npi_pn_sourcer t where t.group_id in
                            (select substr(t.pn,1,2) as pnGroup from npi_pnprice t where t.is_confirm='N')";

            DataTable dt = DbAssistant.DoSelect(sql,DataBaseDB.NPIDB);

            List<string> list=new List<string>();

            if(dt.Rows.Count>0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    list.Add(row["users"].ToString());
                }
            }

            return list;

        }

        /// <summary>
        /// 取得欲寄給PM的信件
        /// </summary>
        /// <returns></returns>
        public List<string> GetMailPMList()
        {
            string sql = @"　select user_id from npi_privilege t where t.role_id='PM' order by t.user_id";

            DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.NPIDB);

            List<string> list = new List<string>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(row["user_id"].ToString());
                }
            }

            return list;

        }

        /// <summary>
        /// 取得尚未確認的金額，以群組的方式包裝起來
        /// 還加入不推薦用料-選擇
        /// </summary>
        /// <returns></returns>
        public SortedList<string, PNPriceEntity> GetNotConfirmPricePNList()
        {
            //取得所有的群組
            ComponentLogic logic=new ComponentLogic();

            List<ComponentGroupEntity> groupList = logic.GetComponentGroupList();

            //取得目前尚未議價的資料
            List<PNPriceEntity> myNotConfirmList = GetWaitingPNPriceListByUserId(); 

            //取得目前不被推薦的料號清單
            Dictionary<string, string> notUsedDicList = GetTipTopSecondSourceNotUsePN();

            SortedList<string, SortedList<string, PNPriceEntity>> sortList = new SortedList<string, SortedList<string, PNPriceEntity>>();

            //將所有的資料群組化
            foreach (ComponentGroupEntity t in groupList)
            {
                sortList.Add(t.ID, new SortedList<string, PNPriceEntity>());
            }

            //把所有的資料群組化
            int count = 1;
            int all = myNotConfirmList.Count;
            foreach (PNPriceEntity t in myNotConfirmList)
            {
                if (!notUsedDicList.ContainsKey(t.PN))
                {
                    foreach (string key in sortList.Keys)
                    {
                        if (t.PN.Substring(0, 2) == key)
                        {
                            log.Info(String.Format("{0}/{1}-{2}-{3}-{4}", new object[] { count, all, t.PN,t.YearQ,t.Site}));
                            sortList[key].Add(t.PN+t.YearQ+t.Site,t);
                            count++;
                            break;
                        }
                    }
                }
            }

            SortedList<string, PNPriceEntity> returnList = new SortedList<string, PNPriceEntity>();
            
            foreach(SortedList<string, PNPriceEntity> s in sortList.Values)
            {
                foreach (PNPriceEntity m in s.Values)
                {
                    returnList.Add(m.PN + m.YearQ + m.Site, m);
                }
            }
                

            return returnList;

        }

        /// <summary>
        /// 取得目市尚未回覆的Sourcer主管名單
        /// 先找出5天以內的資料
        /// </summary>
        /// <returns></returns>
        public List<string> GetSourcerNotConfirmManagerList()
        {

            List<string> list = new List<string>();

            string sql = @"　select distinct(t.user_id)as users 
                            from npi_pn_sourcer t where t.group_id in
                            (select substr(t.pn,1,2) as pnGroup from npi_pnprice t where t.is_confirm='N' and sysdate<=5+t.create_time)";

            DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.NPIDB);

            string argString = "";

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    argString += String.Format("'{0}',", row["users"].ToString());
                   
                }
            }

            if (argString.Length > 0)
            {
                argString = argString.Substring(0, argString.Length - 1);

                sql =String.Format("select distinct(t.manager_id) as users from srm_user t where t.user_id in({0})",argString);

                dt = DbAssistant.DoSelect(sql, DataBaseDB.UserDB);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        list.Add(row["users"].ToString());
                    }
                }
            }

            return list;
            
            
        }

        /// <summary>
        /// 利用主管的帳號去取得Sourcer的資料
        /// 再用此資料去比對採購的資料
        /// </summary>
        /// <param name="managerId"></param>
        /// <returns></returns>
        public List<string> GetSourceListByManager(string managerId,string companyId)
        {
            //先取得此主管的使用者資料
            List<string> list = new List<string>();

            string sql = @"　select * from srm_user t where t.manager_id='{0}' and t.company_id='{1}'";

            sql = String.Format(sql, managerId, companyId);

             string argString = "";

            //取得使用者資料
            DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.UserDB); 

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                     argString += String.Format("'{0}',", row["user_id"].ToString());
                }
            }


            if (argString.Length>0)
            {
                argString = argString.Substring(0, argString.Length - 1);

                sql = @"select * from
                        (
                        select distinct(t.user_id)as users 
                                                    from npi_pn_sourcer t where t.group_id in
                                                    (select substr(t.pn,1,2) as pnGroup from npi_pnprice t where t.is_confirm='N' and sysdate<=5+t.create_time)
                        ) a where a.users in({0}) ";

                sql = String.Format(sql, argString);

                dt = DbAssistant.DoSelect(sql, DataBaseDB.NPIDB);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        list.Add(row["users"].ToString());
                    }
                }
            }

            return list;


        }

        public List<SourcerEntity> GetSourcerList(string componentGoroupId, string isEnable,string companyId)
        {
            string sql = "";

            if (componentGoroupId == "0")
            {

                object[] args = new object[] { EnumRole.Sourcer.ToString(), companyId, isEnable };

                sql = this.GetRoleSql(isEnable);

                sql = String.Format(sql, args);

               
            }
            else
            {

                sql = String.Format("select r.* from npi_pn_sourcer t,npi_privilege r where t.user_id=r.user_id and t.company_id=r.company_id and r.is_enable='{0}' and t.group_id='{1}'", isEnable, componentGoroupId);
            }



            return this.GetDBSelectSqlString<SourcerEntity>(sql, false, DataBaseDB.NPIDB);
        }


        /// <summary>
        /// 取得尚未議價的PN Price Data 
        /// 取的所有的資料
        /// </summary>
        /// <returns></returns>
        public List<PNPriceEntity> GetWaitingPNPriceListByUserId()
        {
            return GetWaitingPNPriceListByUserId("",true);
        }

        /// <summary>
        /// 取得目前尚未議價的資料
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public List<PNPriceEntity> GetWaitingPNPriceListByUserId(string accountId)
        {

            return GetWaitingPNPriceListByUserId(accountId,false);
//            string sql = @"select t.*,d.dollar_typename,m.ems_name from npi_pnprice t,npi_dollar_type d,npi_ems m 
//                where t.dollar_type=d.dollar_typeid and t.location_site=m.ems_code and t.is_confirm='N' 
//                and substr(t.pn,1,2) in (select t.group_id  from npi_pn_sourcer t where t.user_id='{0}') order by t.pn";

//            object[] args = new object[] { accountId };

//            return this.QueryList<PNPriceEntity>(sql, args, DataBaseDB.NPIDB);

        }

        public List<PNPriceEntity> GetWaitingPNPriceListByUserId(string accountId,bool isExclueT)
        {
            string sql = @"select t.*,d.dollar_typename,m.ems_name from npi_pnprice t,npi_dollar_type d,npi_ems m 
                where t.dollar_type=d.dollar_typeid and t.location_site=m.ems_code and t.is_confirm='N' {1}
                and substr(t.pn,1,2) in (select t.group_id  from npi_pn_sourcer t {0}) order by t.pn";

            string exclude = "";

            string user = "";

            if (accountId != "")
            {
                user =String.Format(" where t.user_id='{0}' ",accountId);
            }

            if (isExclueT)
            {
                exclude = "and t.buying_mode in('B','A','C')";
            }

            object[] args = new object[] { user,exclude};

            return this.QueryList<PNPriceEntity>(sql, args, DataBaseDB.NPIDB);

        }

        /// <summary>
        /// 取得昕有的Sourcer
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllSourcer()
        {
            string sql = @"select * from caerdsa.npi_privilege t where t.role_id='Sourcer' order by t.user_name";

            DataTable dt = DbAssistant.DoSelect(sql,DataBaseDB.NPIDB);

            List<string> list=new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                string acctno = row["user_id"].ToString();

                list.Add(acctno);
            }


            return list;
        }

        /// <summary>
        /// 檢查此資料是否正確
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pnGroup"></param>
        /// <returns></returns>
        public bool IsValidSourcerPNGroup(string userid,string pnGroup)
        {
            if (pnGroup == "")
            {
                throw new Exception("PN 資料是空值，程式必須先判斷是否空值，不允許不檢查直托使用");
            }

            string sql = "select * from npi_pn_sourcer t where t.user_id='{0}' and t.group_id='{1}'";

            sql = String.Format(sql, userid, pnGroup);

            return DbAssistant.DoSelect(sql, DataBaseDB.NPIDB).Rows.Count > 0;

        }

        /// <summary>
        /// 取回此人可以回覆的元件料號
        /// 由01-20
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public List<ComponentRefEntity> GetSourcerComponentList(string userId,string companyId)
        {
            object[] args = new object[] { userId, companyId };

            string sql = "select t.*,r.group_name from npi_pn_sourcer t,npi_pn_group r where t.group_id=r.group_id and t.user_id='{0}' and t.company_id='{1}'";

            return this.QueryList<ComponentRefEntity>(sql, args, DataBaseDB.NPIDB);
        }

        /// <summary>
        /// 根據群組取回裡面所有的人
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public List<string> GetUserIdByGroup(string groupId)
        { 
            string sql=@" select t.*,r.group_name from npi_pn_sourcer t,npi_pn_group r 
                          where t.group_id=r.group_id and r.group_id='{0}'";

            sql=String.Format(sql,groupId);

            DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.NPIDB);

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["user_id"].ToString());
            }

            return list;
        }

        /// <summary>
        /// 取回Sourcer的工號 根據TipTop上面的PN與Sourcer的對應檔
        /// 用來做一個
        /// </summary>
        /// <param name="pn"></param>
        /// <returns></returns>
        public string GetSourcerIdPNMapByTipTop(string pn)
        {
            string sourcerId = "";

            string sql = @"
                    select ima01, ima02, ima021, ima43,
                    (select trim(ind303) from ind3_file where ind301=ima43) as SOURCER_ID,
                    (select trim(ind302) from ind3_file where ind301=ima43) as SOURCER_NAME 
                    from ima_file where ima01='{0}'";

            sql = String.Format(sql, pn);

            DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.TipTopDB);

            if (dt.Rows.Count > 0)
            {
                sourcerId = dt.Rows[0]["SOURCER_ID"].ToString();

            }

            return sourcerId;
        }

        /// <summary>
        /// 建立一筆Sourcer資料
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool CreateNewSourcer(SourcerEntity obj)
        {
            
               List<Command> list=new List<Command>();
               
               //新增一筆資料
                List<Command> commandList=GetDBCommandList(obj,typeof(SourcerEntity),PageCommandType.InsertColumnMode,DataBaseDB.NPIDB);

                foreach(Command c in commandList)
                {
                    list.Add(c);
                }

                //刪除之前的已有的資料
                string sql = String.Format("delete from npi_pn_sourcer where user_id='{0}' and company_id='{1}'", obj.AccountNo,obj.CompanyId);

                Command comm=new Command();
                comm.CommandType= CommandType.Text;
                comm.CommandText=sql;

                list.Add(comm);

                //加入所選的資料

                foreach (ComponentRefEntity t in obj.ComponentList)
                {
                    List<Command> cList=this.GetDBCommandList(t, typeof(ComponentRefEntity), PageCommandType.InsertColumnMode,DataBaseDB.NPIDB);

                    foreach (Command c in cList)
                    {
                        list.Add(c);
                    }
                    
                }
               
                return DbAssistant.DoCommand(list,DataBaseDB.NPIDB)>0;
           
        }

        /// <summary>
        /// 更新Sourcer資訊
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool UpdateSourcer(SourcerEntity obj)
        {
            List<Command> list = new List<Command>();

            //新增一筆資料
            List<Command> commandList = GetDBCommandList(obj, typeof(SourcerEntity), PageCommandType.UpdateColumnMode,DataBaseDB.NPIDB);

            foreach (Command c in commandList)
            {
                list.Add(c);
            }

            //刪除之前的已有的資料
            string sql = String.Format("delete from npi_pn_sourcer where user_id='{0}' and company_id='{1}'", obj.AccountNo, obj.CompanyId);

            Command comm = new Command();
            comm.CommandType = CommandType.Text;
            comm.CommandText = sql;

            list.Add(comm);

            //加入所選的資料

            foreach (ComponentRefEntity t in obj.ComponentList)
            {
                List<Command> cList = this.GetDBCommandList(t, typeof(ComponentRefEntity), PageCommandType.InsertColumnMode,DataBaseDB.NPIDB);

                foreach (Command c in cList)
                {
                    list.Add(c);
                }

            }

            return DbAssistant.DoCommand(list, DataBaseDB.NPIDB) > 0;
        }

        /// <summary>
        /// 取回查詢資料
        /// 取回目前已經確認的資料
        /// </summary>
        /// <param name="pn"></param>
        /// <returns></returns>
        public List<PNPriceEntity> GetPNPriceList(string pn)
        {
           return GetPNPriceList(pn,"Y");
        }

        /// <summary>
        /// 尚未確認的PNPriceList的資料
        /// </summary>
        /// <param name="pn"></param>
        /// <param name="isConfirm"></param>
        /// <returns></returns>
        public List<PNPriceEntity> GetWaitingPNPriceList(string isConfirm)
        {
            return GetWaitingPNPriceList(isConfirm,false);
            
            //object[] args = new object[] {isConfirm };

            //string sql = "select t.*,d.dollar_typename,m.ems_name from npi_pnprice t,npi_dollar_type d,npi_ems m where t.dollar_type=d.dollar_typeid and t.location_site=m.ems_code and t.is_confirm='{0}' order by t.yearQ desc";

            //return this.QueryList<PNPriceEntity>(sql, args, DataBaseDB.NPIDB);
        }

        public List<PNPriceEntity> GetWaitingPNPriceList(string isConfirm,bool isExcludeT)
        {
            //object[] args = new object[] { isConfirm };


            string arg2 = "";

            if (isExcludeT)
            {
                 arg2 = " and t.buying_mode<>'T' ";
            }

            string sql = "select t.*,d.dollar_typename,m.ems_name from npi_pnprice t,npi_dollar_type d,npi_ems m where t.dollar_type=d.dollar_typeid and t.location_site=m.ems_code and t.is_confirm='{0}'  {1} order by t.yearQ desc";

            sql = String.Format(sql, isConfirm, arg2);

            log.Info("sql="+sql);
            
            return this.QueryList<PNPriceEntity>(sql, null, DataBaseDB.NPIDB);
        }

        /// <summary>
        /// 取回特定的PN且尚未Confirm的資料
        /// </summary>
        /// <param name="isConfirm"></param>
        /// <param name="pn"></param>
        /// <returns></returns>
        public List<PNPriceEntity> GetWaitingPNPriceList(string isConfirm,string pn)
        {
            object[] args = new object[] { isConfirm,pn };

            string sql = "select t.*,d.dollar_typename,m.ems_name from npi_pnprice t,npi_dollar_type d,npi_ems m where t.dollar_type=d.dollar_typeid and t.location_site=m.ems_code and t.is_confirm='{0}' and t.pn='{1}' order by t.yearQ desc";

            return this.QueryList<PNPriceEntity>(sql, args, DataBaseDB.NPIDB);
        }

        /// <summary>
        /// 取得所有的PNPriceData
        /// </summary>
        /// <returns></returns>
        public List<PNPriceEntity> GetBuyingModeIsNullPNPriceList()
        {

            string sql = "select t.*,d.dollar_typename,m.ems_name from npi_pnprice t,npi_dollar_type d,npi_ems m where t.dollar_type=d.dollar_typeid and t.location_site=m.ems_code  order by t.yearQ desc";

            return this.QueryList<PNPriceEntity>(sql, null, DataBaseDB.NPIDB);
        }

        /// <summary>
        /// 取得已經是金額確認的資料，
        /// 但是尚未送出至EQuotation的資料
        /// </summary>
        /// <returns></returns>
        public List<PNPriceEntity> GetWaitingSendPNPriceList()
        {
            string sql = "select t.*,d.dollar_typename,m.ems_name from npi_pnprice t,npi_dollar_type d,npi_ems m where t.dollar_type=d.dollar_typeid and t.location_site=m.ems_code and t.is_confirm='Y' and t.is_send='N' order by t.yearQ desc";

            return this.QueryList<PNPriceEntity>(sql, null, DataBaseDB.NPIDB);
        }
        

        /// <summary>
        /// 取得元件料號
        /// </summary>
        /// <param name="pn"></param>
        /// <param name="isConfirm"></param>
        /// <returns></returns>
        public List<PNPriceEntity> GetPNPriceList(string pn,string isConfirm)
        {
            object[] args = new object[] { pn,isConfirm };

            string sql = "select t.*,d.dollar_typename,m.ems_name from npi_pnprice t,npi_dollar_type d,npi_ems m where t.dollar_type=d.dollar_typeid and t.location_site=m.ems_code and t.pn='{0}' and t.is_confirm='{1}' order by t.yearQ desc";

            return this.QueryList<PNPriceEntity>(sql, args, DataBaseDB.NPIDB);
        }

        /// <summary>
        /// 找得目前在資料表中此季的資料，以供比對
        /// Table NPI_PNPrice
        /// </summary>
        /// <param name="yearQ">2008Q4</param>
        /// <param name="isConfirm">Y/N</param>
        /// <returns>取回此季的元件料號列表</returns>
        public List<PNPriceEntity> GetPNQuarterPriceList(string yearQ)
        {
            string sql = "select t.*,d.dollar_typename,m.ems_name from npi_pnprice t,npi_dollar_type d,npi_ems m where t.dollar_type=d.dollar_typeid and t.location_site=m.ems_code and t.yearq='{0}' order by t.pn";

            object[] args = new object[] { yearQ };
            

            return this.QueryList<PNPriceEntity>(sql, args, DataBaseDB.NPIDB);
        }

        /// <summary>
        /// 取回此Site的Buying Mode
        /// site：EMS Site
        /// pn:元件料號
        /// </summary>
        /// <param name="site">PGSZB1</param>
        /// <param name="pn">04G070000900TW</param>
        /// <returns>B/C/A/T</returns>
        public string GetBuyingMode(string site, string pn,string conSignSite)
        {
            string buyMode = "";

            bool isConSign = false;

            if (conSignSite != "")
            {
                char[] delimiterChars = {','};

                string text = conSignSite;
                
                string[] words = text.Split(delimiterChars);

                foreach (string s in words)
                {
                    if (s == site)
                    {
                        isConSign = true;
                        break;
                    }
                }

            }

            if (isConSign)
            {
                buyMode = "C";
            }
            else
            {
                string sql = @"select max(ryd07) as buyingMode 

                            from ryd_file 

                            where ryd01='{0}' 

                            and '{1}' matches ryd06 and length(ryd06)=

                            (select max(length(ryd06)) from ryd_file where ryd01='{0}' and '{1}' matches ryd06)

                            and ryd05=(select min(ryd05) from ryd_file where ryd01='{0}' and '{1}' matches ryd06)
                            ";

                object[] args = new object[] { site, pn };

                sql = String.Format(sql, args);

                DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.TipTopDB);

                if (dt != null && dt.Rows.Count > 0)
                {

                    buyMode = dt.Rows[0]["buyingMode"].ToString();
                }
            }


            return buyMode;



//            string sql = @"select *
//
//                            from ryd_file 
//
//                            where ryd01='{0}' and '{1}' matches ryd06 order by ryd05,length(ryd06) desc";

            //string sql = "select ecst_get.PN_CBAT_Type('{1}','{0}')as buymode from dual";

            //object[] args = new object[] { site,pn };

            //sql = String.Format(sql, args);

            //DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.QuatatinDB);

            //if (dt!=null && dt.Rows.Count > 0)
            //{

            //    buyMode = dt.Rows[0]["buymode"].ToString();
            //}

            //return buyMode;

            //string buyMode = "";

            //string spName = "ecst_get.pn_cbat_type";

            //List<Parameter> list = new List<Parameter>();

            //Parameter p1 = null;

            

            //p1 = new Parameter();

            //p1.ParameterName = "MPN";
            //p1.Value = pn;
            //p1.Direction = ParameterDirection.Input;
            //p1.DataType = DataType.VarChar;

            //list.Add(p1);

            //p1 = new Parameter();

            //p1.ParameterName = "MSITEID";
            //p1.Value = site;
            //p1.DataType = DataType.VarChar;
            //p1.Direction = ParameterDirection.Input;

            //list.Add(p1);

            //p1 = new Parameter();

            //p1.ParameterName = "result";
            //p1.DataType = DataType.VarChar;
            //p1.Direction = ParameterDirection.ReturnValue;

            //return DoSpSelectReturnValue(spName, list,p1,connString);

            

        }

        public bool UpdatePNPriceBuyingMode(List<PNPriceEntity> list)
        {
            List<Command> commList = new List<Command>();

            string sql = @"update npi_pnprice
                        set 
                        buying_Mode='{3}'
                        where pn='{0}' and yearq='{1}' and location_site='{2}'";
            foreach (PNPriceEntity t in list)
            {
                Command c = new Command();
                c.CommandType = CommandType.Text;
                c.CommandText = String.Format(sql, new object[] { t.PN, t.YearQ, t.Site, t.BuyingMode });

                commList.Add(c);
            }

            return DbAssistant.DoCommand(commList, DataBaseDB.NPIDB)>0;
        }

        /// <summary>
        /// 取得所有可能的BuyingMode
        /// </summary>
        /// <param name="pn"></param>
        /// <returns></returns>
        public DataTable GetBuyingMode(string pn)
        {

            string sql = @"select * 

                            from ryd_file 

                            where '{0}' matches ryd06 order by ryd05,length(ryd06) desc";

            object[] args = new object[] {pn };

            sql = String.Format(sql, args);

            DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.TipTopDB);

            return dt;
        }

        /// <summary>
        /// 取得在eQuotation的資料可以使用
        /// 狀況：這會在尚未有TipTop的資料時先去eQuotation
        /// </summary>
        /// <param name="pnList"></param>
        /// <returns></returns>
        public Dictionary<string, PNeQuotattionPriceEntity> GeteQuotationPriceDicList(List<PNPriceEntity> pnList)
        {
            Dictionary<string, PNeQuotattionPriceEntity> dicList = new Dictionary<string, PNeQuotattionPriceEntity>();

            foreach (PNPriceEntity t in pnList)
            {
                string sql = @"select t.*,'{3}' as Site  from scm_equote_npi_price t 
                                where t.ems_code='{2}' 
                                and t.asus_pn='{0}' 
                                and t.group_no='{1}'";
                
                object[] args = new object[] { t.PN,t.YearQ,t.SiteVendor,t.Site};

                List<PNeQuotattionPriceEntity> list = this.QueryList<PNeQuotattionPriceEntity>(sql, args, DataBaseDB.QuatatinDB);

                foreach (PNeQuotattionPriceEntity m in list)
                {
                    dicList.Add(m.PN + m.YearQ + m.Site, m);
                }
            }

            

            return dicList;
        }

        /// <summary>
        /// 取得所有的TipTip的資料列表
        /// </summary>
        /// <param name="pnList"></param>
        /// <returns></returns>
        public List<PNPriceEntity> GetTipTopPriceListByPN(List<PNPriceEntity> pnList)
        {
            List<PNPriceEntity> list = new List<PNPriceEntity>();

            log.Info(String.Format("取得要到TipTop的PN數量={0}筆",pnList.Count));
            int count = 1;
            int total = list.Count;

            foreach (PNPriceEntity t in pnList)
            {
                object[] args=new object[]{t.Site,t.PN,t.YearQ,count,total};

                log.Info(String.Format("第{3}/{4}筆,Site={0},PN={1},YearQ={2}",args));
                PNTipTopPriceEntity obj = GetPNTipTopPriceData(t.Site, t.PN, t.YearQ);
                

                if (obj != null)
                {
                    log.Info(String.Format("金額={0},DolarType={1}", obj.PNPrice, obj.DollarType));
                    t.TipTopPrice = obj.PNPrice;
                    t.DollarType = obj.DollarType.Trim();
                    t.EffectDate = obj.EffectedDate.Trim();
                    t.DisableDate = obj.DisAbleDate.Trim();
                    t.IsConfirm = "Y";
                    t.ConfirmTime = DateTime.Now.ToString();
                    t.ConfirmUser = "System";

                    list.Add(t);
                }
                else
                {
                    log.Info("空值");
                }
                count++;
            }

            return list;
        }

        /// <summary>
        /// 更新CommandListData
        /// </summary>
        /// <param name="pnList"></param>
        /// <returns></returns>
        public bool UpdatePNPrice(List<PNPriceEntity> pnList)
        {
            List<Command> commandList = new List<Command>();

            foreach (PNPriceEntity t in pnList)
            {
                List<Command> tList = this.GetDBCommandList(t, typeof(PNPriceEntity), PageCommandType.UpdateColumnMode, DataBaseDB.NPIDB);

                foreach (Command c in tList)
                {
                    commandList.Add(c);
                }
            }

            return DbAssistant.DoCommand(commandList, DataBaseDB.NPIDB) > 0;
        }

        /// <summary>
        /// 取得一筆TipTopPrice資料
        /// </summary>
        /// <param name="site"></param>
        /// <param name="pn"></param>
        /// <param name="yearQ"></param>
        /// <returns></returns>
        public PNTipTopPriceEntity GetPNTipTopPriceData(string site,string pn,string yearQ)
        {
            PNTipTopPriceEntity obj = null;
            
            string maxDate = ConvertLastDate(yearQ);

            //log.Info(String.Format("MaxDate={0}",maxDate));

            //site 需要紿過轉換
            string tipTopSite=ConvertToSite(site);

            string sql = @"select distinct psa05, psa06, psa07, psb07, psaconf,

                        (year(psb14) || '/' || month(psb14) || '/' || day(psb14)) psb14,

                        (year(psb15) || '/' || month(psb15) || '/' || day(psb15)) psb15

                        from psa_file a, psb_file b where psaconf='Y'

                        and psa06 in ('USD', 'RMB') and psa07 in({2})

                        and b.psb03 = '{0}'

                        and psb14<=TO_DATE('{1}','%Y/%m/%d') and psb15>=TO_DATE('{1}','%Y/%m/%d')

                        and a.psa01 = b.psb01 and psa01=(select max(psa01)

                        from psa_file, psb_file

                        where psa05=a.psa05

                        and psb03 = '{0}' and psa07 in({2})

                        and psb14<=TO_DATE('{1}','%Y/%m/%d') and psb15>=TO_DATE('{1}','%Y/%m/%d')

                        and psa01 = psb01) order by psa05 asc,psb07 desc
                        ";
            object[] args = new object[] { pn,maxDate,tipTopSite };

            //log.Info("SQL=" + String.Format(sql, args));

            //現在修正為，找到最大的那一筆
            


            List<PNTipTopPriceEntity> list=this.QueryList<PNTipTopPriceEntity>(sql, args, DataBaseDB.TipTopDB);

            log.Info("Count=" + list.Count);

            if (list.Count > 0)
            {
                obj = list[0];
            }

            return obj;

            
        }

        /// <summary>
        /// 取得利用元件料號找議價資料
        /// </summary>
        /// <param name="pn"></param>
        /// <returns></returns>
        public DataTable GetPNTipTopPriceData(string pn)
        {

           string sql = @"
                            select  psa05, psa06, psa07, psb07, psaconf,

                        (year(psb14) || '/' || month(psb14) || '/' || day(psb14)) psb14,

                        (year(psb15) || '/' || month(psb15) || '/' || day(psb15)) psb15

                        from psa_file a, psb_file b where psaconf='Y'

                        and psa06 in ('USD', 'RMB') 

                        and b.psb03 = '{0}'

                         and a.psa01 = b.psb01

                        order by  psa05 asc,psb07 desc
                        ";
            object[] args = new object[] { pn };

            sql = String.Format(sql, args);

            return DbAssistant.DoSelect(sql, DataBaseDB.TipTopDB);


        }

        private string ConvertLastDate(string yearQ)
        {
            string strValue = "";

            string year = yearQ.Substring(0, 4);

            string q=yearQ.Substring(5,1);

            switch (Convert.ToInt16(q))
            { 
                case 1:
                    strValue = year+"/03/31";
                    break;
                case 2:
                    strValue = year+"/06/30" ;
                    break;
                case 3:
                    strValue = year+"/09/30"; 
                    break;
                case 4:
                    strValue = year+"/12/31";
                    break;
                default:
                    throw new Exception(String.Format("無法取得此類型的資料，請確定q={0},YearQ={1}", q, yearQ));
            }

            return strValue;

            
        }

        /// <summary>
        /// 由Site別轉換成TipTop Site別
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        private string ConvertToSite(string site)
        {
            string tipTopSite = "";

            AsusBomLogic logic = new AsusBomLogic();

            EMSSiteEntity obj = logic.GetEmsSite(site);

            if (obj == null)
            {
                throw new Exception("無法取得EMS Site以及TipTop關連性");
            }

            string tipTop = obj.TipTopSite;

            char[] delimiterChars = {','};

            string[] words =tipTop.Split(delimiterChars);
            
            foreach (string s in words)
            {
                tipTopSite += String.Format("'{0}',", s);
            }

            if (tipTopSite.Length == 0)
            {
                throw new Exception("Site 資料為空白");
            }
            else
            {
                tipTopSite = tipTopSite.Substring(0, tipTopSite.Length - 1);
            }

            return tipTopSite;
        }

        /// <summary>
        /// 取回Site Vendor Code
        /// 有一例外：PeGaTron
        /// 其餘的部份都要與原來的比對
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public string GetVendorCode(string site)
        {
            string siteVendor = "";

            if (site == "")
            {
                throw new Exception("Site 代號為空白");
            }

            if (site.Substring(0, 2) == "PG")
            {
                siteVendor = "PEGATRON";
            }
            else
            { 
                //去找資料
                string sql = "select * from scm_ems_vendor t where t.ems_code='{0}'";

                object[] args = new object[] { site };

                sql = String.Format(sql, args);

                DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.QuatatinDB);

                if (dt.Rows.Count == 0)
                {
                    throw new Exception(String.Format("無法取得Vendor Code 請確認-Table(SCM_EMS_VENDOR)裡面有EMS_CODE={0}", site));
                }
                else
                {
                    siteVendor = dt.Rows[0]["VENDOR_CODE"].ToString();
                }


                
            }

            return siteVendor;


        }

        /// <summary>
        /// 新增資料至eQuotation
        /// </summary>
        /// <param name="eList"></param>
        /// <param name="sList">本身確認知道</param>
        /// <returns></returns>
        public bool InserteQuatationData(SortedList<string,PNEQuotationEntity> eList, List<PNSendEntity> sList)
        {
            bool isFlag = false;

            //新增至eQuotation
            List<Command> commandList = new List<Command>();

            foreach (PNEQuotationEntity t in eList.Values)
            {
                List<Command> tList = this.GetDBCommandList(t, typeof(PNEQuotationEntity), PageCommandType.InsertColumnMode, DataBaseDB.QuatatinDB);

                foreach (Command c in tList)
                {
                    commandList.Add(c);
                }
            }

            if (DbAssistant.DoCommand(commandList,DataBaseDB.QuatatinDB) > 0)
            {
                isFlag=true;
                ////更新本身資料
                //List<Command> tCommandList = new List<Command>();

                //foreach (PNSendEntity t in sList)
                //{
                //    List<Command> nCommandList = this.GetDBCommandList(t, typeof(PNSendEntity), PageCommandType.UpdateColumnMode, DataBaseDB.NPIDB);

                //    foreach (Command m in nCommandList)
                //    {
                //        tCommandList.Add(m);
                //    }
                //}

                //if (DbAssistant.DoCommand(tCommandList,DataBaseDB.NPIDB) > 0)
                //{
                //    isFlag = true;
                //}
                //else
                //{
                //    log.Info("Error 無法更新資料");
                //}
            }
            else
            {
                log.Info("Error 無法做新增資料");
            }

            //更新資料

            return isFlag;
        }

        /// <summary>
        /// 取得所有的不推薦的元件料號資料
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,string> GetTipTopSecondSourceNotUsePN()
        {
            string sql = @"select pon07 from pon_file where pon06='X'";
            
            DataTable dt=DbAssistant.DoSelect(sql, DataBaseDB.TipTopDB);

            Dictionary<string, string> dicList = new Dictionary<string, string>();

            foreach (DataRow row in dt.Rows)
            { 
                string pn=row["pon07"].ToString().Trim();

                dicList.Add(pn, pn);
            }

            return dicList;

        }


        /// <summary>
        /// 取得現在尚未建立Sourcer與PN之間之關係
        /// 這是為了尚未有議價檔-但是尚未無法有Sourcer資料
        /// </summary>
        /// <returns></returns>
        public SortedList<string, List<SourcerPNMapEntity>> GetWaitingPNNotExistSourcerMap()
        {
            string sql = @"select distinct(t.asus_pn) as PN1,'insert' as dbmode 
                            from npi_form_pn t 
                            where t.asus_pn not in(select asus_pn from npi_sourcerpn_map t ) 
                            and substr(t.asus_pn,0,2) 
                            in ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15','16')
                            
                            union
                            select t.asus_pn PN1,'update' as dbmode from caerdsa.npi_sourcerpn_map t
                          ";

            DataTable dt = DbAssistant.DoSelect(sql,DataBaseDB.NPIDB);

             List<SourcerPNMapEntity> alertList = new List<SourcerPNMapEntity>();

            List<SourcerPNMapEntity> insertList = new List<SourcerPNMapEntity>();

            List<SourcerPNMapEntity> updateList = new List<SourcerPNMapEntity>();

            //取得所有的資料
            SortedList<string, List<SourcerPNMapEntity>> reList = new SortedList<string, List<SourcerPNMapEntity>>();

            foreach (DataRow row in dt.Rows)
            {
                string pn = row["PN1"].ToString();

                log.Info("PN-->"+pn);

                string userid = GetSourcerIdPNMapByTipTop(pn);

                SourcerPNMapEntity obj = new SourcerPNMapEntity();

                obj.UserId = userid;
                obj.PN = pn;

                if (userid != "")
                {

                    log.Info("UserId-->" + userid);

                    string dbmode=row["dbmode"].ToString();

                    if (dbmode == "insert")
                    {
                        insertList.Add(obj);
                    }
                    else if (dbmode == "update")
                    {
                        updateList.Add(obj);
                    }
                    
                }
                else
                {
                    obj.IsAlert = true;
                    alertList.Add(obj);
                }

            }

            // Y=要通知管理者的 N=有找到要放到資料庫的
            reList.Add("Y", alertList);
            reList.Add("N", insertList);
            reList.Add("U", updateList);

            return reList;
        }

        /// <summary>
        /// 新增資料進NPI_SOURCERPN_MAP
        /// 包括
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertSourcePNMap(List<SourcerPNMapEntity> insertList,List<SourcerPNMapEntity> updateList)
        { 
            List<Command> commList = new List<Command>();


            foreach (SourcerPNMapEntity t in insertList)
            {
                List<Command> cList = this.GetDBCommandList(t, typeof(SourcerPNMapEntity), PageCommandType.InsertColumnMode, DataBaseDB.NPIDB);

                foreach(Command c in cList)
                {
                    commList.Add(c);    
                }
            }

            //Update Command

            foreach (SourcerPNMapEntity t in updateList)
            {
                List<Command> cList = this.GetDBCommandList(t, typeof(SourcerPNMapEntity), PageCommandType.UpdateColumnMode, DataBaseDB.NPIDB);

                foreach (Command c in cList)
                {
                    commList.Add(c);
                }
            }

            return DbAssistant.DoCommand(commList, DataBaseDB.NPIDB) > 0;
        }

        /// <summary>
        /// 取回等待通知Sourcer 議價檔的資料
        /// 2009/02/25 新版
        /// 有加入使用者的名單
        /// </summary>
        /// <returns></returns>
        public SortedList<string, SortedList<string, PNPrice2Entity>> GetWaitingAlertSourcePrice()
        {
            SortedList<string, SortedList<string, PNPrice2Entity>> sList = new SortedList<string, SortedList<string, PNPrice2Entity>>();

            //string =pn+site+yearQ
            SortedList<string, PNPrice2Entity> allList = new SortedList<string, PNPrice2Entity>(); 

            //取回己經需要通知的料
            string sql = @"select t.*,s.user_id,d.dollar_typename,m.ems_name 
                            from npi_pnprice t,npi_dollar_type d,npi_ems m, npi_sourcerpn_map s
                            where t.dollar_type=d.dollar_typeid 
                            and t.location_site=m.ems_code 
                            and t.is_confirm='N' 
                            and t.pn=s.asus_pn and t.buying_mode  in('B','C','A')
                            and substr(t.asus_pn,0,2) 
                            in ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15','16')
                            ";

            List<PNPrice2Entity> queryList = this.QueryList<PNPrice2Entity>(sql, null, DataBaseDB.NPIDB);

            //通過不推薦用料
            Dictionary<string, string> notUsedDicList = GetTipTopSecondSourceNotUsePN();

            foreach (PNPrice2Entity t in queryList)
            {
                if (!notUsedDicList.ContainsKey(t.PN))
                {
                    if (!allList.ContainsKey(t.PN + t.YearQ + t.Site))
                    {
                        allList.Add(t.PN + t.YearQ + t.Site, t);
                    }
                }
            }

            //完成目前尚未報價的檔案
            foreach (PNPrice2Entity m in allList.Values)
            {
                if (sList.ContainsKey(m.SourcerId))
                {
                    //如果存在，加入它的SortestList
                    sList[m.SourcerId].Add(m.PN + m.YearQ + m.Site, m);
                }
                else
                { 
                    //如果不存在
                    SortedList<string, PNPrice2Entity> pList = new SortedList<string, PNPrice2Entity>();

                    pList.Add(m.PN + m.YearQ + m.Site, m);

                    sList.Add(m.SourcerId, pList);
                }
            }


            return sList;

        }

        

    }
}
