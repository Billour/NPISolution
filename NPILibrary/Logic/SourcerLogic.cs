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
        /// ���oSourcer��T
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public SourcerEntity GetSourcerUser(string empId,string companyId)
        {
            return GetRoleUser<SourcerEntity>(empId, EnumRole.Sourcer,companyId);
        }

        /// <summary>
        /// ���o�ݭn�H�H��Sourcer�H��
        /// </summary>
        /// <returns></returns>
        public List<string> GetMailSourcerList()
        {
            string sql = @"�@select distinct(t.user_id)as users 
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
        /// ���o���H��PM���H��
        /// </summary>
        /// <returns></returns>
        public List<string> GetMailPMList()
        {
            string sql = @"�@select user_id from npi_privilege t where t.role_id='PM' order by t.user_id";

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
        /// ���o�|���T�{�����B�A�H�s�ժ��覡�]�˰_��
        /// �٥[�J�����˥ή�-���
        /// </summary>
        /// <returns></returns>
        public SortedList<string, PNPriceEntity> GetNotConfirmPricePNList()
        {
            //���o�Ҧ����s��
            ComponentLogic logic=new ComponentLogic();

            List<ComponentGroupEntity> groupList = logic.GetComponentGroupList();

            //���o�ثe�|��ĳ�������
            List<PNPriceEntity> myNotConfirmList = GetWaitingPNPriceListByUserId(); 

            //���o�ثe���Q���˪��Ƹ��M��
            Dictionary<string, string> notUsedDicList = GetTipTopSecondSourceNotUsePN();

            SortedList<string, SortedList<string, PNPriceEntity>> sortList = new SortedList<string, SortedList<string, PNPriceEntity>>();

            //�N�Ҧ�����Ƹs�դ�
            foreach (ComponentGroupEntity t in groupList)
            {
                sortList.Add(t.ID, new SortedList<string, PNPriceEntity>());
            }

            //��Ҧ�����Ƹs�դ�
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
        /// ���o�إ��|���^�Ъ�Sourcer�D�ަW��
        /// ����X5�ѥH�������
        /// </summary>
        /// <returns></returns>
        public List<string> GetSourcerNotConfirmManagerList()
        {

            List<string> list = new List<string>();

            string sql = @"�@select distinct(t.user_id)as users 
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
        /// �Q�ΥD�ު��b���h���oSourcer�����
        /// �A�Φ���ƥh�����ʪ����
        /// </summary>
        /// <param name="managerId"></param>
        /// <returns></returns>
        public List<string> GetSourceListByManager(string managerId,string companyId)
        {
            //�����o���D�ު��ϥΪ̸��
            List<string> list = new List<string>();

            string sql = @"�@select * from srm_user t where t.manager_id='{0}' and t.company_id='{1}'";

            sql = String.Format(sql, managerId, companyId);

             string argString = "";

            //���o�ϥΪ̸��
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
        /// ���o�|��ĳ����PN Price Data 
        /// �����Ҧ������
        /// </summary>
        /// <returns></returns>
        public List<PNPriceEntity> GetWaitingPNPriceListByUserId()
        {
            return GetWaitingPNPriceListByUserId("",true);
        }

        /// <summary>
        /// ���o�ثe�|��ĳ�������
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
        /// ���o������Sourcer
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
        /// �ˬd����ƬO�_���T
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pnGroup"></param>
        /// <returns></returns>
        public bool IsValidSourcerPNGroup(string userid,string pnGroup)
        {
            if (pnGroup == "")
            {
                throw new Exception("PN ��ƬO�ŭȡA�{���������P�_�O�_�ŭȡA�����\���ˬd�����ϥ�");
            }

            string sql = "select * from npi_pn_sourcer t where t.user_id='{0}' and t.group_id='{1}'";

            sql = String.Format(sql, userid, pnGroup);

            return DbAssistant.DoSelect(sql, DataBaseDB.NPIDB).Rows.Count > 0;

        }

        /// <summary>
        /// ���^���H�i�H�^�Ъ�����Ƹ�
        /// ��01-20
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
        /// �ھڸs�ը��^�̭��Ҧ����H
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
        /// ���^Sourcer���u�� �ھ�TipTop�W����PN�PSourcer��������
        /// �ΨӰ��@��
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
        /// �إߤ@��Sourcer���
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool CreateNewSourcer(SourcerEntity obj)
        {
            
               List<Command> list=new List<Command>();
               
               //�s�W�@�����
                List<Command> commandList=GetDBCommandList(obj,typeof(SourcerEntity),PageCommandType.InsertColumnMode,DataBaseDB.NPIDB);

                foreach(Command c in commandList)
                {
                    list.Add(c);
                }

                //�R�����e���w�������
                string sql = String.Format("delete from npi_pn_sourcer where user_id='{0}' and company_id='{1}'", obj.AccountNo,obj.CompanyId);

                Command comm=new Command();
                comm.CommandType= CommandType.Text;
                comm.CommandText=sql;

                list.Add(comm);

                //�[�J�ҿ諸���

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
        /// ��sSourcer��T
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool UpdateSourcer(SourcerEntity obj)
        {
            List<Command> list = new List<Command>();

            //�s�W�@�����
            List<Command> commandList = GetDBCommandList(obj, typeof(SourcerEntity), PageCommandType.UpdateColumnMode,DataBaseDB.NPIDB);

            foreach (Command c in commandList)
            {
                list.Add(c);
            }

            //�R�����e���w�������
            string sql = String.Format("delete from npi_pn_sourcer where user_id='{0}' and company_id='{1}'", obj.AccountNo, obj.CompanyId);

            Command comm = new Command();
            comm.CommandType = CommandType.Text;
            comm.CommandText = sql;

            list.Add(comm);

            //�[�J�ҿ諸���

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
        /// ���^�d�߸��
        /// ���^�ثe�w�g�T�{�����
        /// </summary>
        /// <param name="pn"></param>
        /// <returns></returns>
        public List<PNPriceEntity> GetPNPriceList(string pn)
        {
           return GetPNPriceList(pn,"Y");
        }

        /// <summary>
        /// �|���T�{��PNPriceList�����
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
        /// ���^�S�w��PN�B�|��Confirm�����
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
        /// ���o�Ҧ���PNPriceData
        /// </summary>
        /// <returns></returns>
        public List<PNPriceEntity> GetBuyingModeIsNullPNPriceList()
        {

            string sql = "select t.*,d.dollar_typename,m.ems_name from npi_pnprice t,npi_dollar_type d,npi_ems m where t.dollar_type=d.dollar_typeid and t.location_site=m.ems_code  order by t.yearQ desc";

            return this.QueryList<PNPriceEntity>(sql, null, DataBaseDB.NPIDB);
        }

        /// <summary>
        /// ���o�w�g�O���B�T�{����ơA
        /// ���O�|���e�X��EQuotation�����
        /// </summary>
        /// <returns></returns>
        public List<PNPriceEntity> GetWaitingSendPNPriceList()
        {
            string sql = "select t.*,d.dollar_typename,m.ems_name from npi_pnprice t,npi_dollar_type d,npi_ems m where t.dollar_type=d.dollar_typeid and t.location_site=m.ems_code and t.is_confirm='Y' and t.is_send='N' order by t.yearQ desc";

            return this.QueryList<PNPriceEntity>(sql, null, DataBaseDB.NPIDB);
        }
        

        /// <summary>
        /// ���o����Ƹ�
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
        /// ��o�ثe�b��ƪ����u����ơA�H�Ѥ��
        /// Table NPI_PNPrice
        /// </summary>
        /// <param name="yearQ">2008Q4</param>
        /// <param name="isConfirm">Y/N</param>
        /// <returns>���^���u������Ƹ��C��</returns>
        public List<PNPriceEntity> GetPNQuarterPriceList(string yearQ)
        {
            string sql = "select t.*,d.dollar_typename,m.ems_name from npi_pnprice t,npi_dollar_type d,npi_ems m where t.dollar_type=d.dollar_typeid and t.location_site=m.ems_code and t.yearq='{0}' order by t.pn";

            object[] args = new object[] { yearQ };
            

            return this.QueryList<PNPriceEntity>(sql, args, DataBaseDB.NPIDB);
        }

        /// <summary>
        /// ���^��Site��Buying Mode
        /// site�GEMS Site
        /// pn:����Ƹ�
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
        /// ���o�Ҧ��i�઺BuyingMode
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
        /// ���o�beQuotation����ƥi�H�ϥ�
        /// ���p�G�o�|�b�|����TipTop����Ʈɥ��heQuotation
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
        /// ���o�Ҧ���TipTip����ƦC��
        /// </summary>
        /// <param name="pnList"></param>
        /// <returns></returns>
        public List<PNPriceEntity> GetTipTopPriceListByPN(List<PNPriceEntity> pnList)
        {
            List<PNPriceEntity> list = new List<PNPriceEntity>();

            log.Info(String.Format("���o�n��TipTop��PN�ƶq={0}��",pnList.Count));
            int count = 1;
            int total = list.Count;

            foreach (PNPriceEntity t in pnList)
            {
                object[] args=new object[]{t.Site,t.PN,t.YearQ,count,total};

                log.Info(String.Format("��{3}/{4}��,Site={0},PN={1},YearQ={2}",args));
                PNTipTopPriceEntity obj = GetPNTipTopPriceData(t.Site, t.PN, t.YearQ);
                

                if (obj != null)
                {
                    log.Info(String.Format("���B={0},DolarType={1}", obj.PNPrice, obj.DollarType));
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
                    log.Info("�ŭ�");
                }
                count++;
            }

            return list;
        }

        /// <summary>
        /// ��sCommandListData
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
        /// ���o�@��TipTopPrice���
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

            //site �ݭn��L�ഫ
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

            //�{�b�ץ����A���̤j�����@��
            


            List<PNTipTopPriceEntity> list=this.QueryList<PNTipTopPriceEntity>(sql, args, DataBaseDB.TipTopDB);

            log.Info("Count=" + list.Count);

            if (list.Count > 0)
            {
                obj = list[0];
            }

            return obj;

            
        }

        /// <summary>
        /// ���o�Q�Τ���Ƹ���ĳ�����
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
                    throw new Exception(String.Format("�L�k���o����������ơA�нT�wq={0},YearQ={1}", q, yearQ));
            }

            return strValue;

            
        }

        /// <summary>
        /// ��Site�O�ഫ��TipTop Site�O
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
                throw new Exception("�L�k���oEMS Site�H��TipTop���s��");
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
                throw new Exception("Site ��Ƭ��ť�");
            }
            else
            {
                tipTopSite = tipTopSite.Substring(0, tipTopSite.Length - 1);
            }

            return tipTopSite;
        }

        /// <summary>
        /// ���^Site Vendor Code
        /// ���@�ҥ~�GPeGaTron
        /// ��l���������n�P��Ӫ����
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public string GetVendorCode(string site)
        {
            string siteVendor = "";

            if (site == "")
            {
                throw new Exception("Site �N�����ť�");
            }

            if (site.Substring(0, 2) == "PG")
            {
                siteVendor = "PEGATRON";
            }
            else
            { 
                //�h����
                string sql = "select * from scm_ems_vendor t where t.ems_code='{0}'";

                object[] args = new object[] { site };

                sql = String.Format(sql, args);

                DataTable dt = DbAssistant.DoSelect(sql, DataBaseDB.QuatatinDB);

                if (dt.Rows.Count == 0)
                {
                    throw new Exception(String.Format("�L�k���oVendor Code �нT�{-Table(SCM_EMS_VENDOR)�̭���EMS_CODE={0}", site));
                }
                else
                {
                    siteVendor = dt.Rows[0]["VENDOR_CODE"].ToString();
                }


                
            }

            return siteVendor;


        }

        /// <summary>
        /// �s�W��Ʀ�eQuotation
        /// </summary>
        /// <param name="eList"></param>
        /// <param name="sList">�����T�{���D</param>
        /// <returns></returns>
        public bool InserteQuatationData(SortedList<string,PNEQuotationEntity> eList, List<PNSendEntity> sList)
        {
            bool isFlag = false;

            //�s�W��eQuotation
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
                ////��s�������
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
                //    log.Info("Error �L�k��s���");
                //}
            }
            else
            {
                log.Info("Error �L�k���s�W���");
            }

            //��s���

            return isFlag;
        }

        /// <summary>
        /// ���o�Ҧ��������˪�����Ƹ����
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
        /// ���o�{�b�|���إ�Sourcer�PPN���������Y
        /// �o�O���F�|����ĳ����-���O�|���L�k��Sourcer���
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

            //���o�Ҧ������
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

            // Y=�n�q���޲z�̪� N=�����n����Ʈw��
            reList.Add("Y", alertList);
            reList.Add("N", insertList);
            reList.Add("U", updateList);

            return reList;
        }

        /// <summary>
        /// �s�W��ƶiNPI_SOURCERPN_MAP
        /// �]�A
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
        /// ���^���ݳq��Sourcer ĳ���ɪ����
        /// 2009/02/25 �s��
        /// ���[�J�ϥΪ̪��W��
        /// </summary>
        /// <returns></returns>
        public SortedList<string, SortedList<string, PNPrice2Entity>> GetWaitingAlertSourcePrice()
        {
            SortedList<string, SortedList<string, PNPrice2Entity>> sList = new SortedList<string, SortedList<string, PNPrice2Entity>>();

            //string =pn+site+yearQ
            SortedList<string, PNPrice2Entity> allList = new SortedList<string, PNPrice2Entity>(); 

            //���^�v�g�ݭn�q������
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

            //�q�L�����˥ή�
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

            //�����ثe�|���������ɮ�
            foreach (PNPrice2Entity m in allList.Values)
            {
                if (sList.ContainsKey(m.SourcerId))
                {
                    //�p�G�s�b�A�[�J����SortestList
                    sList[m.SourcerId].Add(m.PN + m.YearQ + m.Site, m);
                }
                else
                { 
                    //�p�G���s�b
                    SortedList<string, PNPrice2Entity> pList = new SortedList<string, PNPrice2Entity>();

                    pList.Add(m.PN + m.YearQ + m.Site, m);

                    sList.Add(m.SourcerId, pList);
                }
            }


            return sList;

        }

        

    }
}
