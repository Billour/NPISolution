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
    /// <summary>
    /// 針對群組設定
    /// </summary>
    public class GroupLogic:BaseLogic
    {
        public List<GroupMapEntity> QueryGroupList()
        {
            string sql = "select * from caerdsa.npi_group t";

            List<GroupMapEntity> list = this.QueryList<GroupMapEntity>(sql, null, DataBaseDB.NPIDB);

            foreach (GroupMapEntity t in list)
            { 
                t.MemberUserNames=QueryMemberName(t.GroupId);
            }

            return list;
        }

        public string QueryMemberName(string groupId)
        {
            string sql = "select t.group_id, s.user_id,s.user_name from caerdsa.npi_group_mapping t,npi_privilege s where t.user_id=s.user_id and t.group_id='{0}' and s.role_id='PM' order by s.user_name";

            sql = String.Format(sql, groupId);

            DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.NPIDB);

            string members = "";

            foreach (DataRow row in dt.Rows)
            {
                members += row["user_name"].ToString()+"/";
            }

            return members;
        }

        /// <summary>
        /// 取得群組的人員名單
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public string[] GetGroupUsers(string groupId)
        {
            string sql = "select t.group_id, s.user_id,s.user_name from caerdsa.npi_group_mapping t,npi_privilege s where t.user_id=s.user_id and t.group_id='{0}' and s.role_id='PM' order by s.user_name";

            sql = String.Format(sql, groupId);

            DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.NPIDB);

            string[] users = new string[dt.Rows.Count];


            int count = 0;

            foreach (DataRow row in dt.Rows)
            {
                users[count]= row["user_id"].ToString();
                count++;
            }

            return users;
        }
    }
}
