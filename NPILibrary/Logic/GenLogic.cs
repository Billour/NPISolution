using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Asus.Data;
using AsusLibrary.Config;
using AsusLibrary.Entity;
using Asus.Bussiness.Map;

namespace AsusLibrary.Logic
{
    public class GenLogic:BaseLogic
    {
        public bool InsertNewMain(GenNPIEntity obj)
        {
            List<Command> commList = new List<Command>();

            List<Command> cList1 = this.GetDBCommandList(obj.Main, typeof(GenMainEntity), PageCommandType.InsertColumnMode, DataBaseDB.NPIDB);

            foreach (Command c in cList1)
            {
                commList.Add(c);
            }

            foreach (GenFormEntity t in obj.FormList)
            {
                List<Command> cList2 = this.GetDBCommandList(t, typeof(GenFormEntity), PageCommandType.InsertColumnMode, DataBaseDB.NPIDB);

                foreach (Command c in cList2)
                {
                    commList.Add(c);
                }
            }

            foreach (GenPNEntity t in obj.GenPNList.Values)
            {
                List<Command> cList3 = this.GetDBCommandList(t, typeof(GenPNEntity), PageCommandType.InsertColumnMode, DataBaseDB.NPIDB);

                foreach (Command c in cList3)
                {
                    commList.Add(c);
                }
            }

            return DbAssistant.DoCommand(commList, DataBaseDB.NPIDB) > 0;
        }

        public List<string> QueryFormListByMainId(string mainId)
        {
            string sql = "select distinct(t.form_id) as no from caerdsa.npi_bom_pn t where substr(t.form_id,1,8)='{0}'";

            sql = String.Format(sql, mainId);

            DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.NPIDB);

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["no"].ToString());
            }

            return list;
        }
        
        public List<string> QueryWorkNoListByMainId(string mainId)
        {
            string sql = "select distinct(t.work_no) as no from caerdsa.npi_bom_pn t where substr(t.form_id,1,8)='{0}'";

            sql = String.Format(sql, mainId);

            DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.NPIDB);

            List<string> list = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["no"].ToString());
            }

            return list;
        }

        /// <summary>
        /// 取回一個FormId的資料
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        public List<FormPNBomEntity> QueryFormPNBomList(string formId)
        {
            string sql = "select * from caerdsa.npi_bom_pn t where t.form_id='{0}'";

            object[] args = new object[] { formId };

            return QueryList<FormPNBomEntity>(sql, args, DataBaseDB.NPIDB);
        }

        /// <summary>
        /// 取得目前的主要狀態
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<GenMainEntity> QueryMainList(string status)
        {
            string sql = " select * from caerdsa.npi_main t ";

            object[] args = null;

            if (status != "A")
            {
                sql += " where t.work_status='{0}'";

                args = new object[] { status };
            }


            return this.QueryList<GenMainEntity>(sql, args, DataBaseDB.NPIDB);
        }

        public DataTable GetGroupListByMainId(string mainId)
        {
            string sql = @"
                            select distinct(c.group_id) as group_id from caerdsa.npi_group_mapping c where c.user_id 
                                in
                                (
                                select t.pm_user_id from caerdsa.npi_form_sub t where t.form_id 
                                in(
                                       select a.form_id from caerdsa.npi_main_map a where a.main_id='{0}'
                                )
                                ) order by c.group_id
                        ";

            sql = String.Format(sql, mainId);

            return DbAssistant.DoSelect(sql, DataBaseDB.NPIDB);
        }

        /// <summary>
        /// 取得目前所申請 User PM
        /// </summary>
        /// <param name="group"></param>
        /// <param name="mainId"></param>
        /// <returns></returns>
        public List<KeyValuePair<string,string>> GetUserPMByMainId(string group,string mainId)
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            if (group != "*")
            {
                string sql = @"
                            select * from caerdsa.npi_group_mapping t where t.group_id='{1}' 
                            and t.user_id in
                            (
                                select t.pm_user_id from caerdsa.npi_form_sub t where t.form_id 
                                in(
                                       select a.form_id from caerdsa.npi_main_map a where a.main_id='{0}'
                                   )
                            )
                        ";

                sql = String.Format(sql, mainId, group);

                DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.NPIDB);

                

                UserLogic logic = new UserLogic();

                foreach (DataRow row in dt.Rows)
                {

                    UserEntity o = logic.QueryPMInfo(row["user_id"].ToString(), "13006");

                    string userName = "";

                    if (o != null)
                    {
                        userName = o.AccountName;
                    }

                    KeyValuePair<string, string> key = new KeyValuePair<string, string>(row["user_id"].ToString(), userName);

                    list.Add(key);

                }

            }

            
            return list;
        }

        public List<BOMBookingEntity> GetBOMListByMainId(string mainId, string userId)
        {

            string sql = @"
                            select u.user_name,t.*,c.form_id,c.work_status,c.booking_date,s.ems_name as PVT_LOCATION_NAME 
                            from 
                            npi_bom t, 
                            npi_booking c,
                            npi_ems s,
                            (select distinct(user_id) as user_id,user_name from caerdsa.npi_privilege) u     
                            where t.pvt_location=s.ems_code 
                            and t.user_id=c.user_id
                            and t.user_id=u.user_id 
                            and t.bom_id=c.bom_id 
                            and c.user_id='{1}' 
                            and c.company_id='13006'
                            and c.form_id in
                            (
                                select t.form_id from caerdsa.npi_form_sub t where t.pm_user_id='{1}'
                                  and t.form_id in
                                  (
                                  select a.form_id from caerdsa.npi_main_map a where a.main_id='{0}'
                                  )
                            )
                            order by t.bom_id
                        ";
            sql=String.Format(sql,mainId,userId);

            return this.QueryList<BOMBookingEntity>(sql, null, DataBaseDB.NPIDB);

        }

        public List<T> GetBOMListByMainId2<T>(string mainId, List<string> groupList)
        {

            return GetBOMListByMainId2<T>(mainId,groupList,null);

        }

        /// <summary>
        /// 加入BOM List 的機制
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mainId"></param>
        /// <param name="groupList"></param>
        /// <param name="bomList"></param>
        /// <returns></returns>
        public List<T> GetBOMListByMainId2<T>(string mainId, List<string> groupList,List<string> bomList)
        {

            string sql = @"
                            select u.user_name,m.group_id,t.*,c.form_id,c.work_status,c.booking_date,s.ems_name as PVT_LOCATION_NAME 
                              from 
                              npi_bom t, 
                              npi_booking c,
                              npi_ems s,
                              (select distinct(user_id) as user_id,user_name from caerdsa.npi_privilege) u,
                              caerdsa.npi_group_mapping m     
                              where t.pvt_location=s.ems_code 
                              and t.user_id=c.user_id
                              and t.user_id=u.user_id 
                              and t.bom_id=c.bom_id
                              and t.user_id=m.user_id 
                              and c.form_id in
                              (
                                  select t.form_id from caerdsa.npi_form_sub t where 1=1
                                    and t.form_id in
                                    (
                                    select a.form_id from caerdsa.npi_main_map a where a.main_id='{0}'
                                    )
                              )
                              and m.group_id in({1})
                              {2} 
                              order by t.user_id
                        ";

            string groups = "";
            string boms = "";
            string bomsSQL = "";

            foreach (string s in groupList)
            {
                groups += String.Format("'{0}',", s);
            }

            if (groups.Length > 0)
            {
                groups = groups.Substring(0, groups.Length - 1);
            }

            if (bomList != null && bomList.Count > 0)
            {
                bomsSQL += "and t.bom_id in({0})";

                foreach (string s in bomList)
                {
                    boms += String.Format("'{0}',", s);
                }

                if (boms.Length > 0)
                {
                    boms = boms.Substring(0, boms.Length - 1);
                }

                bomsSQL = String.Format(bomsSQL, boms);
            }

            sql = String.Format(sql, mainId, groups, bomsSQL);

            return this.QueryList<T>(sql, null, DataBaseDB.NPIDB);

        }

        public List<BOMBookingEntity> GetMainIdBomListByUserGroup(string mainId,string groupId,string userId,List<string> bomIdList)
        {
            string sql1 = ""; //and t.user_id='AH0800033';
            string sql2 = ""; //and t.bom_id in('70-MIBBG0-A01','70-MIBBE0-A01')

            string sql = @"
                            select 
                              u.user_name,
                              t.*,
                              c.form_id,
                              c.work_status,
                              c.booking_date,
                              s.ems_name as PVT_LOCATION_NAME 
                            from 
                             npi_bom t,
                             npi_booking c,
                             npi_form_main m,
                             npi_ems s,
                            (select distinct(user_id) as user_id,user_name from caerdsa.npi_privilege) u 
                             where t.pvt_location=s.ems_code 
                             and t.user_id=u.user_id {1} {2} 
                         and c.form_id=m.form_id(+) and t.user_id=c.user_id and t.bom_id=c.bom_id and c.form_id in(select m.form_id from caerdsa.npi_main_map m, caerdsa.npi_main t where m.main_id=t.main_id and t.main_id='{0}') order by t.bom_id
                        ";


            if (groupId != "*")
            {
                if (userId != "*")
                {
                    sql1 = String.Format(" and t.user_id='{0}'", userId);

                    if (bomIdList.Count > 0)
                    {
                        string bom = "";

                        foreach (string s in bomIdList)
                        {
                            bom += String.Format("'{0}',", s);
                        }

                        if (bom.Length > 0)
                        {
                            bom = bom.Substring(0, bom.Length - 1);
                        }

                        sql2 = String.Format(" and t.bom_id in({0})", bom);
                    }
                }
                else
                { 
                    //代表是 By Group

                    string userIdList = "";

                    List<KeyValuePair<string, string>> users = GetUserPMByMainId(groupId, mainId);

                    foreach (KeyValuePair<string, string> s in users)
                    {
                        userIdList += String.Format("'{0}',", s.Key);
                    }

                    if (userIdList.Length > 0)
                    {
                        userIdList = userIdList.Substring(0, userIdList.Length - 1);
                    }

                    sql1 = String.Format(" and t.user_id in({0})", userIdList);
 

                }
            }
            

            sql = String.Format(sql, mainId,sql1,sql2);

            return this.QueryList<BOMBookingEntity>(sql, null, DataBaseDB.NPIDB);
        }

        

    }
}
