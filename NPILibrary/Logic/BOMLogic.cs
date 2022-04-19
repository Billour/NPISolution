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
    public class BOMLogic:BaseLogic
    {
        public BOMLogic()
            : base()
        { }
        //private string baseSql = "select t.*,c.form_id,c.work_status,c.booking_date from npi_bom t,npi_booking c,npi_form_main m ";

        //private string baseSql = @" select t.*,c.form_id,c.work_status,c.booking_date,s.ems_name as PVT_LOCATION_NAME from npi_bom t,npi_booking c,npi_form_main m,npi_ems s 
        //                            where t.pvt_location=s.ems_code";

        private string baseSql = @"
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
                             and t.user_id=u.user_id
                        ";

        /// <summary>
        /// 取回此PM的BOM資訊
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="bomId"></param>
        /// <returns></returns>
        public List<BOMBookingEntity> QueryPMBom(string empId, string bomId,string companyId)
        {

            object[] args = new object[] { empId, bomId,companyId };

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
                            and t.user_id='{0}' and t.bom_id='{1}' and t.company_id='{2}' order by c.booking_date desc";

            return this.QueryList<BOMBookingEntity>(sql, args, DataBaseDB.NPIDB);
           
        }

        /// <summary>
        /// 是否此BOM 己經存在
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="bomId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool IsPMBomExist(string empId, string bomId, string companyId)
        {
            object[] args = new object[] { empId, bomId, companyId };

            string sql = @"select * from caerdsa.npi_bom t where t.user_id='{0}' and t.company_id='{2}' and t.bom_id='{1}'
                            ";
            sql = String.Format(sql, args);

            DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.NPIDB);

            return dt.Rows.Count>0;
        }


        ///// <summary>
        ///// 取得PM BOM 的清單列表
        ///// </summary>
        ///// <param name="empId"></param>
        ///// <param name="isEnable"></param>
        ///// <returns></returns>
        //public List<BOMBookingEntity> QueryPMBomList(string empId,string isEnable,string companyId)
        //{
        //    string sql =baseSql+ " where t.user_id=c.user_id and t.bom_id=c.bom_id and t.user_id='{0}' and t.company_id='{1}'";

        //    object[] args = null;

        //    if (isEnable != "A")
        //    {
        //        sql += " and t.is_enable='{2}'";

        //        args = new object[] { empId,companyId, isEnable };
        //    }
        //    else
        //    {
        //        args = new object[] { empId,companyId };
        //    }

        //    return this.QueryList<BOMBookingEntity>(sql, args, DataBaseDB.NPIDB);

        //}

        /// <summary>
        /// 取得所有的BOM資料
        /// </summary>
        /// <param name="isEnable"></param>
        /// <param name="isclose"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<BOMBookingEntity> QueryPMBomList(string isEnable, string isclose, string companyId)
        {
            return QueryPMBomList("", isEnable,isclose,companyId);

        }

        /// <summary>
        /// 取得pm所註冊之BOM
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="isEnable"></param>
        /// <param name="isclose"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<BOMBookingEntity> QueryPMBomList(string empId, string isEnable,string isclose,string companyId)
        {
            string sql = baseSql + " and t.user_id=c.user_id and t.bom_id=c.bom_id ";

            if (empId != "")
            {
                sql += " and t.user_id='{0}' and t.company_id='{1}'";
            }

            sql=String.Format(sql,empId,companyId);

            object[] args = null;

            if (isEnable != "A")
            {
                sql += " and t.is_enable='{0}'";

                sql=String.Format(sql,isEnable);
            }
           

            if(isclose=="Y")
            {
                sql+=" and c.form_id=m.form_id(+) and m.form_status='Y' ";
            }
            else
            {
                sql += " and c.form_id=m.form_id(+) and (m.form_status='N' or m.form_status is null)";
            }

            return this.QueryList<BOMBookingEntity>(sql, args, DataBaseDB.NPIDB);

        }

       

        /// <summary>
        /// 取得此Form的BOMList
        /// </summary>
        /// <param name="formId"></param>
        /// <returns></returns>
        public List<BOMBookingEntity> QueryFromBookingBOM(string formId)
        {
            string sql = baseSql + " and c.form_id=m.form_id(+) and t.user_id=c.user_id and t.bom_id=c.bom_id and c.form_id='{0}' order by t.bom_id desc";

            object[] args = new object[] { formId};

            return this.QueryList<BOMBookingEntity>(sql, args, DataBaseDB.NPIDB);
        }

        public List<BOMBookingEntity> QueryFromBookingBOMByGenId(string genId)
        {
            string sql = baseSql + " and c.form_id=m.form_id(+) and t.user_id=c.user_id and t.bom_id=c.bom_id and c.form_id in(select m.form_id from caerdsa.npi_main_map m, caerdsa.npi_main t where m.main_id=t.main_id and t.main_id='{0}') order by t.bom_id desc";

            object[] args = new object[] { genId };

            return this.QueryList<BOMBookingEntity>(sql, args, DataBaseDB.NPIDB);
        }

        public List<BOMBookingEntity> QueryFromBookingBOM(string formId,string pmUserId)
        {
            string sql = baseSql + " and c.form_id=m.form_id(+) and t.user_id=c.user_id and t.bom_id=c.bom_id and c.form_id='{0}' and c.user_id='{1}' order by t.bom_id desc";

            object[] args = new object[] { formId,pmUserId };

            return this.QueryList<BOMBookingEntity>(sql, args, DataBaseDB.NPIDB);
        }
        
        ///// <summary>
        ///// 取得RuleList
        ///// </summary>
        ///// <returns></returns>
        //public List<PreFixRuleEntity> GetPreFixRuleList()
        //{
        //    List<PreFixRuleEntity> list=new List<PreFixRuleEntity>();

        //    for(int i=0;i<4;i++)
        //    {
        //        PreFixRuleEntity t=new PreFixRuleEntity();

        //        list.Add(t);
        //    }

        //    return list;
        //}

        /// <summary>
        /// 取得元件屬性料號列表
        /// </summary>
        /// <returns></returns>
        public List<KeyValuePair<string, string>> GetComponentPropertyList()
        {
            string sql = "select * from npi_pn_property t where t.is_enable='Y' order by t.property_id";

            DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.NPIDB);

            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new KeyValuePair<string, string>(row["property_id"].ToString(), String.Format("{0}.{1}", row["property_id"].ToString(), row["property_name"].ToString())));
            }

            return list;

        }

    
     /// <summary>
     /// 取得元件料號列表資料
     /// </summary>
     /// <returns></returns>
     public List<KeyValuePair<string, string>> GetAddSourceList()
     {
         string sql = "select * from npi_pn_add2source t where t.is_enable='Y' order by t.source_id";

         DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.NPIDB);

         List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

         foreach (DataRow row in dt.Rows)
         {
             list.Add(new KeyValuePair<string, string>(row["source_id"].ToString(),String.Format("{0}.{1}",row["source_id"].ToString(),row["source_name"].ToString())));
         }

         return list;
     }

        /// <summary>
        /// 取得此BOM是否已經正確
        /// </summary>
        /// <param name="bomId"></param>
        /// <returns></returns>
        public string GetTipTopBomName(string bomId)
        {
            string bomName=null;

            object[] args = new object[] { bomId };

            string sql = "select * from ima_file where ima01='{0}'";

            sql=String.Format(sql,args);

            DataTable dt=DbAssistant.DoSelect(sql,DataBaseDB.TipTopDB);

            if (dt.Rows.Count == 1)
            {
                DataRow row = (DataRow)dt.Rows[0];

                bomName = row["ima02"].ToString();
            }

            return bomName;
        }

        /// <summary>
        /// 找目前可以將Booking的BOM
        /// 10=Waiting 
        /// 20=OK
        /// 現在是By人
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<BOMBookingEntity> QueryBookingBomList(EnumWorkStatus status,string userId)
        {
            return QueryBookingBomList(status, new string[] { userId});

//            object[] args = new object[] { (int)status, userId };

////            string sql = @" select u.user_name,t.*, '' as FORM_ID, c.work_status,c.booking_date,s.ems_name as PVT_LOCATION_NAME                        
////                            from npi_bom t,npi_booking c,npi_ems s,
////                            (select distinct(user_id) as user_id,user_name from caerdsa.npi_privilege) u 
////                            where t.pvt_location=s.ems_code 
////                            and t.bom_id=c.bom_id
////                            and t.user_id=u.user_id 
////                            and c.work_status='{0}' 
////                            and c.user_id='{1}'  and t.is_enable='Y'";
//            string sql = @"select '' form_id,'' user_name,t.*,'' as FORM_ID, c.work_status,c.booking_date,s.ems_name as PVT_LOCATION_NAME from
//                            (
//                            select b.user_id,b.bom_id,b.form_id,b.work_status,b.booking_date from caerdsa.npi_booking b where b.user_id='{1}' and b.work_status='{0}'
//                            ) c,
//
//                            npi_bom t,
//                            npi_ems s
//                            where
//                             t.pvt_location=s.ems_code  
//                            and t.user_id=c.user_id
//                            and t.bom_id=c.bom_id
//                            and t.is_enable='Y'";
            

//            List<BOMBookingEntity> list=this.QueryList<BOMBookingEntity>(sql, args, DataBaseDB.NPIDB);
            
//            return list;

        }

        public List<BOMBookingEntity> QueryBookingBomList(EnumWorkStatus status, string[] userIdList)
        {

            string userList = "";

            foreach (string s in userIdList)
            {
                userList += String.Format("'{0}',", s);
            }

            if (userList.Length > 0)
            {
                userList = userList.Substring(0, userList.Length - 1);
            }

            object[] args = new object[] { (int)status, userList };

           
            string sql = @"select '' form_id,'' user_name,t.*,'' as FORM_ID, c.work_status,c.booking_date,s.ems_name as PVT_LOCATION_NAME from
                            (
                            select b.user_id,b.bom_id,b.form_id,b.work_status,b.booking_date from caerdsa.npi_booking b where b.user_id in ({1}) and b.work_status='{0}'
                            ) c,

                            npi_bom t,
                            npi_ems s
                            where
                             t.pvt_location=s.ems_code  
                            and t.user_id=c.user_id
                            and t.bom_id=c.bom_id
                            and t.is_enable='Y'";


            List<BOMBookingEntity> list = this.QueryList<BOMBookingEntity>(sql, args, DataBaseDB.NPIDB);

            return list;

        }

        /// <summary>
        /// 取得Booking狀態=等待的人員清單
        /// </summary>
        /// <returns></returns>
        public string[] QueryWaitingBookingBomsUser()
        {

            string sql = @" select distinct(t.user_id) as userid from caerdsa.npi_booking t where t.work_status='10'";

            string[] userList = null;

            DataTable dt = DbAssistant.DoSelect(sql,DataBaseDB.NPIDB);

            if (dt.Rows.Count > 0)
            { 
                userList=new string[dt.Rows.Count];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    userList[i] = dt.Rows[i]["userid"].ToString().Trim();
                }
            }

            return userList;

        }

        /// <summary>
        /// Insert 產生多筆的Booking Data
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool InsertDulplicateBookingData(BOMBookingEntity obj)
        {
            List<Command> commList = new List<Command>();

            List<Command> cList = this.GetDBCommandList(obj, typeof(BOMBookingEntity), PageCommandType.UpdateColumnMode, DataBaseDB.NPIDB);

            foreach (Command c in cList)
            {
                commList.Add(c);
            }

            BOMBookingEntity2 obj2=new BOMBookingEntity2(obj);

            List<Command> cList2 = this.GetDBCommandList(obj2, typeof(BOMBookingEntity2), PageCommandType.InsertColumnMode, DataBaseDB.NPIDB);

            //Booking 用Insert 的
            foreach (Command c in cList2)
            {
                commList.Add(c);
            }

            return DbAssistant.DoCommand(commList,DataBaseDB.NPIDB)>0;
        }

        /// <summary>
        /// Insert Batch Bom
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InserBatchBomData(List<BOMBookingEntity> list)
        {
            List<Command> commList = new List<Command>();

            foreach (BOMBookingEntity t in list)
            {

                if (!IsPMBomExist(t.EmpId,t.BOMId,t.CompanyId))
                {
                    List<Command> cList = this.GetDBCommandList(t, typeof(BOMBookingEntity), PageCommandType.InsertColumnMode, DataBaseDB.NPIDB);

                    foreach (Command c in cList)
                    {
                        commList.Add(c);
                    }
                }
                else
                {
                    List<Command> cList = this.GetDBCommandList(t, typeof(BOMBookingEntity), PageCommandType.UpdateColumnMode, DataBaseDB.NPIDB);

                    foreach (Command c in cList)
                    {
                        commList.Add(c);
                    }

                    BOMBookingEntity2 obj2 = new BOMBookingEntity2(t);

                    List<Command> cList2 = this.GetDBCommandList(obj2, typeof(BOMBookingEntity2), PageCommandType.InsertColumnMode, DataBaseDB.NPIDB);

                    //Booking 用Insert 的
                    foreach (Command c in cList2)
                    {
                        commList.Add(c);
                    }
                }

                
            }

            return DbAssistant.DoCommand(commList, DataBaseDB.NPIDB)>0;
        }

    }
}
