using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Asus.Data;
using AsusLibrary.Config;
using AsusLibrary.Entity;

namespace AsusLibrary.Logic
{
    public class AsusBomLogic:BaseLogic
    {
        public AsusBomLogic()
            : base()
        { }

        /// <summary>
        /// 取回一個WorkNo的資料
        /// 篩選條件
        /// 1. PN的前兩碼必須小於16 ，只取前兩碼小於16的PN
        /// 有例外，所以將SQL資料
        /// </summary>
        /// <param name="workNo"></param>
        /// <returns></returns>
        public List<AsusBomEntity> GetERPBomList(string workNo)
        {
            object[] args = new object[] { workNo };

            //string sql = "select * from srm_bom_erp_dl t where t.work_no='{0}' and to_number(substr(t.asus_pn,0,2))<16 order by asus_pn";

            string sql = @" select * from srm_bom_erp_dl t 
                            where t.work_no='{0}' 
                            and substr(t.asus_pn,0,2) 
                            in ('01','02','03','04','05','06','07','08','09','10','11','12','13','14','15','16') 
                            order by asus_pn";

            return this.QueryList<AsusBomEntity>(sql, args, DataBaseDB.UserDB); 
        }

        /// <summary>
        /// 取得EMS Site 資料
        /// </summary>
        /// <returns></returns>
        public DataTable GetEMSDataTable()
        {
            string sql = "select * from npi_ems t";


            DataTable dt=DbAssistant.DoSelect(sql, DataBaseDB.NPIDB);

            

            return dt;
        }

        /// <summary>
        /// 取回EMS Site資料
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public EMSSiteEntity GetEmsSite(string code)
        {
            string sql = "select * from npi_ems t where t.EMS_CODE='{0}'";

            object[] args = new object[] { code };

            return this.QueryDataDetailInfo<EMSSiteEntity>(sql,args,DataBaseDB.NPIDB);
        }
    }
}
