using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Asus.Data;
using AsusLibrary.Config;
using AsusLibrary.Entity;
using Asus.Bussiness.Map;
using AsusLibrary.Utility;

namespace AsusLibrary.Logic
{
    /// <summary>
    /// Form Logic
    /// </summary>
    public class FormLogic:BaseLogic
    {
        public FormLogic()
            : base()
        { }

        public List<FormEntity> QueryFormList(string status)
        {
            string sql = " select t.pm_user_id,t.pm_company_id,c.* from npi_form_sub t,npi_form_main c where t.form_id=c.form_id ";

            //string sql = "select t.*,'' as pm_user_id,'' as pm_company_id from npi_form_main t where 1=1";

            object[] args = null;

            if (status != "A")
            {
                sql += " and c.form_status='{0}'";

                args = new object[] { status };
            }


            return this.QueryList<FormEntity>(sql, args, DataBaseDB.NPIDB);
        }

        
        public List<FormEntity> QueryFormListBySourcer(string status)
        {
            string sql = " select '' pm_user_id,'' pm_company_id,t.* from npi_form_main t where 1=1 ";

            //string sql = "select t.*,'' as pm_user_id,'' as pm_company_id from npi_form_main t where 1=1";

            object[] args = null;

            if (status != "A")
            {
                sql += " and t.form_status='{0}'";

                args = new object[] { status };
            }

            List<FormEntity> list=this.QueryList<FormEntity>(sql, args, DataBaseDB.NPIDB);

            foreach (FormEntity t in list)
            {
                t.FormName = QueryFormPMNames(t.FormId);
            }

            return list;
        }

        public string QueryFormPMNames(string formId)
        {
            string formName = "";

            //string sql = @"select s.user_name from caerdsa.npi_form_sub t,npi_privilege s where t.pm_user_id=s.user_id and t.form_id='{0}'";

            string sql = @"
                            select (a.group_id || '(' || s.user_name || ')' ) as user_name from caerdsa.npi_form_sub t,npi_privilege s,caerdsa.npi_group_mapping a where s.user_id=a.user_id and t.pm_user_id=s.user_id and t.form_id='{0}'
                        ";

            sql=String.Format(sql,formId);

            DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.NPIDB);

            foreach (DataRow row in dt.Rows)
            {
                formName += row["user_name"].ToString()+"/";
            }

            if (formName.Length > 0)
            {
                formName = formName.Substring(0, formName.Length - 1);
            }

            return formName;
        }

        /// <summary>
        /// 需要用使用者ID
        /// </summary>
        /// <param name="status"></param>
        /// <param name="pmUserId"></param>
        /// <returns></returns>
        public List<FormEntity> QueryFormList(string status,string pmUserId,string pmCompanyId)
        {
            string sql = "select t.pm_user_id,t.pm_company_id,c.* from npi_form_sub t,npi_form_main c where t.form_id=c.form_id  and t.pm_user_id='{0}' and t.pm_company_id='{1}'";

            object[] args = null;

            if (status != "A")
            {
                sql += " and c.form_status='{2}'";

                args = new object[] {pmUserId,pmCompanyId, status };
            }
            else
            {
                args = new object[] { pmUserId, pmCompanyId };
            }


            return this.QueryList<FormEntity>(sql, args, DataBaseDB.NPIDB);
        }

        /// <summary>
        /// 取得所有的PM 列表
        /// </summary>
        /// <param name="status"></param>
        /// <param name="pmCompanyId"></param>
        /// <returns></returns>
        public List<FormEntity> QueryFormList(string status, string pmCompanyId)
        {
            string sql = "select t.pm_user_id,t.pm_company_id,c.* from npi_form_sub t,npi_form_main c where t.form_id=c.form_id(+)  and t.pm_company_id='{0}'";

            object[] args = null;

            if (status != "A")
            {
                sql += " and c.form_status='{1}'";

                args = new object[] { pmCompanyId, status };
            }
            else
            {
                args = new object[] { pmCompanyId };
            }


            return this.QueryList<FormEntity>(sql, args, DataBaseDB.NPIDB);
        }

        /// <summary>
        /// 取回一筆Form資料
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        public FormEntity QueryForm(string formId)
        {
            string sql = "select t.*,'' as pm_user_id,'' as pm_company_id  from npi_form_main t where t.form_id='{0}'";

            object[] args = new object[] { formId };

            
            return this.QueryDataDetailInfo<FormEntity>(sql, args, DataBaseDB.NPIDB);
        }
        
        /// <summary>
        /// 建立一個Form
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public bool CreateForm(FormEntity form)
        {
            List<Command> commandList = new List<Command>();

            //取得FormCommandList
            List<Command> formCommandList = this.GetDBCommandList(form, typeof(FormEntity), PageCommandType.InsertColumnMode, DataBaseDB.NPIDB);

            foreach (Command c in formCommandList)
            {
                commandList.Add(c);
            }
            
            //更新BOM
            foreach (FormBomEntity t in form.BomList)
            {
                List<Command> formBomCommandList = this.GetDBCommandList(t, typeof(FormBomEntity), PageCommandType.UpdateColumnMode, DataBaseDB.NPIDB);

                foreach (Command c in formBomCommandList)
                {
                    commandList.Add(c);
                }

            }

            //新增Form Sub

            foreach (FormPMUserEntity t in form.PMFormList.Values)
            {
                List<Command> formPMCommandList = this.GetDBCommandList(t, typeof(FormPMUserEntity), PageCommandType.InsertColumnMode, DataBaseDB.NPIDB);

                foreach (Command c in formPMCommandList)
                {
                    commandList.Add(c);
                }
            }

            //新增 Form以及PN

            foreach (FormPNEntity t in form.PNList.Values)
            {
                List<Command> formPNCommandList = this.GetDBCommandList(t, typeof(FormPNEntity), PageCommandType.InsertColumnMode, DataBaseDB.NPIDB);

                foreach (Command c in formPNCommandList)
                {
                    commandList.Add(c);
                }
            }

            //Form PN BOM

            foreach (FormPNBomEntity t in form.BOMPNList.Values)
            {
                List<Command> formBOMPNCommandList = this.GetDBCommandList(t, typeof(FormPNBomEntity), PageCommandType.InsertColumnMode, DataBaseDB.NPIDB);

                foreach (Command c in formBOMPNCommandList)
                {
                    commandList.Add(c);
                }
            }

            ////建立PN Price List
            //foreach (PNPriceEntity t in form.PNPriceList.Values)
            //{
            //    List<Command> formPNPriceCommandList = this.GetDBCommandList(t, typeof(PNPriceEntity), PageCommandType.InsertColumnMode, DataBaseDB.NPIDB);

            //    foreach (Command c in formPNPriceCommandList)
            //    {
            //        commandList.Add(c);
            //    }
            //}

            return DbAssistant.DoCommand(commandList, DataBaseDB.NPIDB)>0;
        }

        /// <summary>
        /// 取回Form PN List
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="pnGroup"></param>
        /// <returns></returns>
        public List<FormPNEntity> QueryFormPNList(string formId, string pnGroup,string[] pnGroupList)
        {
            string sql = @" select t.*,c.property_name,m.source_name 
                            from npi_form_pn t,npi_pn_property c,npi_pn_add2source m 
                            where t.pn_property=c.property_id 
                            and t.add2_source=m.source_id 
                            and t.form_id='{0}' ";

            object[] args = null;

            if (pnGroup != "A")
            {
                sql += " and SUBSTR(t.asus_pn,1,2)='{1}'";

                args = new object[] { formId, pnGroup };
            }
            else
            {
                string group = "";

                foreach (string s in pnGroupList)
                {
                    group += String.Format("'{0}',", s);
                }

                if (group.Length == 0)
                {
                    throw new Exception("你尚未有任何分派物料群組以供選擇，請聯絡系統管理員是否將物料群組設定給你");
                }

                group = group.Substring(0, group.Length - 1);

                sql +=String.Format( " and SUBSTR(t.asus_pn,1,2) in({0})",group);

                args = new object[] { formId }; 
            }

            //sql += " order by to_number(t.assembly_no),t.asus_pn,t.assembly_type ";

            sql += " order by t.asus_pn ";


            return this.QueryList<FormPNEntity>(sql, args, DataBaseDB.NPIDB);
        }


        public List<FormPNEntity> QueryMainPNList(string mainId,string userId)
        {
            string sql = @"select  t.*,c.property_name,m.source_name,t.main_id as form_id 
                            from caerdsa.npi_main_pn t,npi_pn_property c,npi_pn_add2source m 
                            where t.pn_property=c.property_id 
                            and t.add2_source=m.source_id
                            and t.main_id='{0}'
                            and SUBSTR(t.asus_pn,1,2) in(select t.group_id from caerdsa.npi_pn_sourcer t where t.user_id='{1}')
                            order by t.asus_pn";

            object[] args = new object[] { mainId,userId};

            return this.QueryList<FormPNEntity>(sql, args, DataBaseDB.NPIDB);
        }

        /// <summary>
        /// 加入查詢條件
        /// 
        /// </summary>
        /// <param name="mainId"></param>
        /// <param name="groupId"></param>
        /// <param name="pmUser"></param>
        /// <param name="bomList"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<FormPNEntity> QueryMainPNList(string mainId,string groupId,string pmUser,List<string> bomList, string userId)
        {
            string sql = "";
            // 代表全部都要下載
            if (groupId == "*")
            {
                sql = @"select  t.*,c.property_name,m.source_name,t.main_id as form_id 
                        from caerdsa.npi_main_pn t,npi_pn_property c,npi_pn_add2source m 
                        where t.pn_property=c.property_id 
                        and t.add2_source=m.source_id
                        and t.main_id='{0}'
                        and SUBSTR(t.asus_pn,1,2) in(select t.group_id from caerdsa.npi_pn_sourcer t where t.user_id='{1}')
                        order by t.asus_pn";
                sql = String.Format(sql, mainId, userId);

            }
            else
            {
                // 如果選擇一個Group 取得一個Form ID
                if (pmUser == "*")
                {
                    sql = @"
                            select a.asus_pn,
                               a.part_desc1,
                               a.part_desc2,
                               b.longterm_week,
                               b.pn_property,
                               b.add2_source,
                               b.add2_source_comment,
                               b.alert,
                               b.assembly_no,
                               b.eol_comment,
                               b.riskbuy, 
                               b.assembly_type,
                               b.action_date,
                               b.create_date,
                               b.create_user,
                               b.update_user,
                               b.update_date,    
                               d.property_name,
                               e.source_name,
                               b.main_id as form_id
                         from caerdsa.npi_form_pn a,
                              caerdsa.npi_main_pn b,
                              caerdsa.npi_main_map c,
                              npi_pn_property d,
                              npi_pn_add2source e 
                         where a.asus_pn=b.asus_pn 
                               and a.form_id =c.form_id
                               and b.pn_property=d.property_id 
                               and b.add2_source=e.source_id 
                               and c.main_id='{0}' 
                               and b.main_id='{0}' 
                               and SUBSTR(b.asus_pn,1,2) in(select t.group_id from caerdsa.npi_pn_sourcer t where t.user_id='{2}')
                               and a.form_id= 
                                   (
                                             select b.form_id 
                                            from 
                                               caerdsa.npi_main_map a,
                                               caerdsa.npi_form_sub b,
                                               caerdsa.npi_group_mapping c 
                                            where 
                                             a.main_id='{0}'
                                             and a.form_id=b.form_id
                                             and b.pm_user_id=c.user_id 
                                             and c.group_id='{1}'
                                   )
                            ";

                    sql = String.Format(sql, mainId, groupId, userId);
                }
                else
                { 
                    // 有加BOM ID

                    sql = @"select a.asus_pn,
                           a.part_desc1,
                           a.part_desc2,
                           b.longterm_week,
                           b.pn_property,
                           b.add2_source,
                           b.add2_source_comment,
                           b.alert,
                           b.assembly_no,
                           b.eol_comment,
                           b.riskbuy,
                           b.assembly_type,
                           b.action_date,
                           b.create_date,
                           b.create_user,
                           b.update_user,
                           b.update_date,
                           d.property_name,
                           e.source_name,
                           b.main_id as form_id
                     from caerdsa.npi_form_pn a,
                          caerdsa.npi_main_pn b,
                          caerdsa.npi_main_map c,
                          npi_pn_property d,
                          npi_pn_add2source e 
                     where a.asus_pn=b.asus_pn 
                           and a.form_id =c.form_id
                           and b.pn_property=d.property_id 
                           and b.add2_source=e.source_id 
                           and c.main_id='{0}' 
                           and b.main_id='{0}' 
                           and SUBSTR(b.asus_pn,1,2) in(select t.group_id from caerdsa.npi_pn_sourcer t where t.user_id='{2}')
                           and a.form_id= 
                               (
                                         select b.form_id 
                                        from 
                                           caerdsa.npi_main_map a,
                                           caerdsa.npi_form_sub b,
                                           caerdsa.npi_group_mapping c 
                                        where 
                                         a.main_id='{0}'
                                         and a.form_id=b.form_id
                                         and b.pm_user_id=c.user_id 
                                         and c.group_id='{1}'
                               )
                            and a.asus_pn in
                            (
                                select distinct(t.asus_pn) as pn from caerdsa.npi_bom_pn t 
                                where t.form_id=
                                (
                                         select b.form_id 
                                        from 
                                           caerdsa.npi_main_map a,
                                           caerdsa.npi_form_sub b,
                                           caerdsa.npi_group_mapping c 
                                        where 
                                         a.main_id='{0}'
                                         and a.form_id=b.form_id
                                         and b.pm_user_id=c.user_id 
                                         and c.group_id='{1}'
                               ) 
                                and t.asus_bom in({3})
                                
                            )order by a.asus_pn";

                    string sql2="";

                    foreach(string s in bomList)
                    {
                        sql2+=String.Format("'{0}',",s);
                    }

                    if(sql2.Length>0)
                    {
                        sql2=sql2.Substring(0,sql2.Length-1);
                    }

                    sql = String.Format(sql, new object[] { mainId, groupId, userId, sql2 });
                }
            }

            

            

            return this.QueryList<FormPNEntity>(sql,null, DataBaseDB.NPIDB);
        }


        public List<FormPNEntity> QueryMainPNList2(string mainId, List<string> groupList, List<string> bomList, string sourcerUserId)
        {
            string sql = @"
                            select  t.*,c.property_name,m.source_name,t.main_id as form_id 
                              from caerdsa.npi_main_pn t,npi_pn_property c,npi_pn_add2source m 
                              where t.pn_property=c.property_id 
                              and t.add2_source=m.source_id
                              and t.main_id='{0}'
                              and SUBSTR(t.asus_pn,1,2) in(select t.group_id from caerdsa.npi_pn_sourcer t where t.user_id='{3}')
                              and t.asus_pn in
                              (
                                  select 
                                   distinct(b.asus_pn) as pn 
                                 from 
                                   caerdsa.npi_form_sub t,
                                   caerdsa.npi_group_mapping a,
                                   caerdsa.npi_bom_pn b 
                                 where
                                  t.pm_user_id=a.user_id 
                                 and a.group_id in({1}) 
                                 and
                                 t.form_id in
                                 (select t.form_id from caerdsa.npi_main_map t where t.main_id='{0}')
                                 and t.form_id=b.form_id 
                                 and b.asus_bom in({2}) 
                                                   
                              )
                              order by t.asus_pn
                            ";
           
                    string sql1 = "";
                    string sql2 = "";

                    foreach (string s in groupList)
                    {
                        sql1 += String.Format("'{0}',", s);
                    }

                    if (sql1.Length > 0)
                    {
                        sql1 = sql1.Substring(0, sql1.Length - 1);
                    }    
                        
                    // bom List
                    foreach (string s in bomList)
                    {
                        sql2 += String.Format("'{0}',", s);
                    }

                    if (sql2.Length > 0)
                    {
                        sql2 = sql2.Substring(0, sql2.Length - 1);
                    }

                    sql = String.Format(sql, new object[] { mainId, sql1, sql2, sourcerUserId});
                





            return this.QueryList<FormPNEntity>(sql, null, DataBaseDB.NPIDB);
        }


        public List<FormPNEntity> QueryMainPNListByFormId(string formId, string userId)
        {
            string sql = @"select a.form_id,b.* from
                        (
                             select t.asus_pn,t.form_id 
                             from npi_form_pn t 
                             where t.form_id='{0}' order by t.asus_pn
                        ) a,
                        (
                          select  t.*,c.property_name,m.source_name,t.main_id as form_id 
                                      from caerdsa.npi_main_pn t,npi_pn_property c,npi_pn_add2source m 
                                      where t.pn_property=c.property_id 
                                      and t.add2_source=m.source_id
                                      and t.main_id in(select t.main_id from caerdsa.npi_main_map t where t.form_id='{0}')
                                      and SUBSTR(t.asus_pn,1,2) in(select t.group_id from caerdsa.npi_pn_sourcer t where t.user_id='{1}')
                                      order by t.asus_pn
                        )b where a.asus_pn=b.asus_pn";

            object[] args = new object[] { formId, userId };

            return this.QueryList<FormPNEntity>(sql, args, DataBaseDB.NPIDB);
        }

        

        /// <summary>
        /// 取得所有的PNList
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        public List<FormPNEntity> QueryFormPNList(string formId)
        {
            string sql = "";

            DateTime myDate = new DateTime(2009, 6, 23);

            if (DateUtil.DateDiff(DateInterval.Day, DateTime.Now, myDate) > 0)
            {
                sql = @" select t.*,c.property_name,m.source_name 
                            from npi_form_pn t,npi_pn_property c,npi_pn_add2source m 
                            where t.pn_property=c.property_id 
                            and t.add2_source=m.source_id 
                            and t.form_id='{0}' order by t.asus_pn ";
            }
            else
            {
                sql = @"select a.form_id,b.* from
                            (
                                 select t.asus_pn,t.form_id 
                                 from npi_form_pn t 
                                 where t.form_id='{0}' order by t.asus_pn
                            ) a,
                            (
                              select t.*,c.property_name,m.source_name 
                              from caerdsa.npi_main_pn t,npi_pn_property c,npi_pn_add2source m 
                              where t.pn_property=c.property_id 
                              and t.add2_source=m.source_id 
                              and t.main_id in(select t.main_id from caerdsa.npi_main_map t where t.form_id='{0}')
                            )b where a.asus_pn=b.asus_pn";
            }



            

            object[] args = new object[] { formId };

            return this.QueryList<FormPNEntity>(sql, args, DataBaseDB.NPIDB);

            //---afsdfasd

        }

        public SortedList<string,FormPNEntity> QueryMainPNListByFormId(string formId)
        {
            SortedList<string, FormPNEntity> formList = new SortedList<string, FormPNEntity>(); 

            string sql = @"select  t.*,c.property_name,m.source_name,t.main_id as form_id 
                            from caerdsa.npi_main_pn t,npi_pn_property c,npi_pn_add2source m 
                            where t.pn_property=c.property_id 
                            and t.add2_source=m.source_id
                            and t.main_id =(select m.main_id from caerdsa.npi_main_map m where m.form_id='{0}')
                            order by t.asus_pn";

            object[] args = new object[] {formId };

            List<FormPNEntity> pnList= this.QueryList<FormPNEntity>(sql, args, DataBaseDB.NPIDB);

            foreach (FormPNEntity t in pnList)
            {
                if (!formList.ContainsKey(formId + t.PN))
                {
                    formList.Add(formId + t.PN, t);
                }
            }

            return formList;
        }

        public Dictionary<string, string> QueryFormBOMPNQtyList(string formId)
        {
            string sql = " select * from npi_bom_pn t where t.form_id='{0}' ";

            object[] args = new object[] { formId }; 

            List<FormPNBomEntity> list= this.QueryList<FormPNBomEntity>(sql, args, DataBaseDB.NPIDB);

            Dictionary<string, string> dicList = new Dictionary<string, string>();

            
            foreach (FormPNBomEntity t in list)
            {
                dicList.Add(t.BomId + t.FormId + t.PN, t.Qty);

                
            }


            return dicList;
        }

        public Dictionary<string, string> QueryFormBOMPNQtyListByGenId(string genId)
        {
            string sql = " select * from npi_bom_pn t where t.form_id in(select m.form_id from caerdsa.npi_main_map m, caerdsa.npi_main t where m.main_id=t.main_id and t.main_id='{0}') ";

            object[] args = new object[] { genId };

            List<FormPNBomEntity> list = this.QueryList<FormPNBomEntity>(sql, args, DataBaseDB.NPIDB);

            Dictionary<string, string> dicList = new Dictionary<string, string>();


            foreach (FormPNBomEntity t in list)
            {
                dicList.Add(t.BomId + t.PN, t.Qty);
            }


            return dicList;
        }

        /// <summary>
        /// 更新PN資料
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool UpdateResponseForm(SortedList<string, FormPNEntity> list)
        {
            List<Command> commandList = new List<Command>();

            foreach (FormPNEntity t in list.Values)
            {
                List<Command> formPNCommandList = this.GetDBCommandList(t, typeof(FormPNEntity), PageCommandType.UpdateColumnMode, DataBaseDB.NPIDB);

                foreach (Command c in formPNCommandList)
                {
                    commandList.Add(c);
                }
            }

            return DbAssistant.DoCommand(commandList, DataBaseDB.NPIDB) > 0;
        }

        public bool UpdateResponseMain(SortedList<string, GenPNEntity> list)
        {
            List<Command> commandList = new List<Command>();

            foreach (GenPNEntity t in list.Values)
            {
                List<Command> formPNCommandList = this.GetDBCommandList(t, typeof(GenPNEntity), PageCommandType.UpdateColumnMode, DataBaseDB.NPIDB);

                foreach (Command c in formPNCommandList)
                {
                    commandList.Add(c);
                }
            }

            return DbAssistant.DoCommand(commandList, DataBaseDB.NPIDB) > 0;
        }

        /// <summary>
        /// 更新至Temp檔
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool SaveFormTemp(string formId, string userId, string companyId)
        {
            string sql1 = String.Format("select * from npi_form_temp t where t.user_id='{0}' and t.company_id='{1}'", userId, companyId);

            string sql2 = String.Format("insert into npi_form_temp(user_id,company_id,form_id)values('{0}','{1}','{2}')", userId, companyId, formId);

            string sql3 = String.Format("update npi_form_temp set form_id='{0}' where user_id='{1}' and company_id='{2}'", formId, userId, companyId);

            string sql="";

            if (DbAssistant.DoSelect(sql1, DataBaseDB.NPIDB).Rows.Count > 0)
            {
                //Update
                sql=sql3;
            }
            else
            { 
                //Insert
                sql=sql2;
            }

            return DbAssistant.DoCommand(sql, DataBaseDB.NPIDB)>0;
        }

        /// <summary>
        /// 取得此FormId資料
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public string QueryFormTemp(string userId, string companyId)
        {
            string sql1 = String.Format("select * from npi_form_temp t where t.user_id='{0}' and t.company_id='{1}'", userId, companyId);
            
            DataTable dt=DbAssistant.DoSelect(sql1, DataBaseDB.NPIDB);

            string formId = "";

            if (dt.Rows.Count == 1)
            {
                formId = dt.Rows[0]["form_id"].ToString();
            }
           

            return formId;
        }

        public bool CloseForm(string formId,string  isClose)
        {
            List<Command> commList = new List<Command>();

            string sql = String.Format("update npi_form_main set FORM_STATUS='{1}' where FORM_ID='{0}'", formId, isClose);

            Command c = new Command();
            c.CommandText = sql;
            c.CommandType = CommandType.Text;

            commList.Add(c);


            string mainId=QueryMainIdFromMap(formId);

            if (mainId != "")
            { 
                //如果有資料的話
                string sql2 =String.Format("update caerdsa.npi_main  set work_status='{0}' where main_id='{1}'",isClose,mainId);

                c = new Command();
                c.CommandText = sql2;
                c.CommandType = CommandType.Text;

                commList.Add(c);
            }
            
            

            return DbAssistant.DoCommand(commList, DataBaseDB.NPIDB) > 0;
        }

        public string QueryMainIdFromMap(string formId)
        {
            string mainId = "";
            
            string sql = "select * from caerdsa.npi_main_map t where t.form_id='{0}'";

            sql=String.Format(sql,formId);

            DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.NPIDB);

            if (dt.Rows.Count > 0)
            {
                mainId = dt.Rows[0]["main_id"].ToString();
            }

            return mainId;
        }

        /// <summary>
        /// 取得目前尚未結案的資料
        /// </summary>
        /// <returns></returns>
        public List<FormPMEntity> QueryNotCloseFormList()
        {
            string sql = "select t.form_id,s.pm_user_id from npi_form_main t,npi_form_sub s where t.form_id=s.form_id and t.form_status='N'";

            return this.QueryList<FormPMEntity>(sql, null, DataBaseDB.NPIDB);
        }


    }
}
