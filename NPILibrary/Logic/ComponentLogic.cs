using System;
using System.Collections.Generic;
using System.Text;

using AsusLibrary.Entity;
using AsusLibrary.Config;


namespace AsusLibrary.Logic
{
    public class ComponentLogic:BaseLogic
    {
        public ComponentLogic()
            : base()
        { }
        /// <summary>
        /// 取回元件料號群組
        /// </summary>
        /// <returns></returns>
        public List<ComponentGroupEntity> GetComponentGroupList()
        {
            List<ComponentGroupEntity> list = new List<ComponentGroupEntity>();

            string sql = "select * from NPI_PN_GROUP t order by t.GROUP_ID";

            list = this.GetDBSelectSqlString<ComponentGroupEntity>(sql, false, DataBaseDB.NPIDB);

            return list;
        }
    }
}
