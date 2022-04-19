using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Asus.Data;
using AsusLibrary.Config;
using AsusLibrary.Entity;

namespace AsusLibrary.Logic
{
    /// <summary>
    /// �M�����o�Ҧ����ϥΪ̸�T
    /// ���O��SRM_User
    /// NPI_Privivilege
    /// </summary>
    public class BaseUserLogic:BaseLogic
    {
        public BaseUserLogic()
            : base()
        { }

        /// <summary>
        /// ���^���u��T
        /// ComapnyId=ASUSTECH
        /// </summary>
        /// <param name="domain">Domain</param>
        /// <param name="loginId">DomianId</param>
        /// <returns>EmployeeEntity</returns>
        //public EmployeeEntity GetEmp(string domain, string loginId)
        //{
        //    return GetEmp(domain, loginId, m_ComapnyId);

        //}

        /// <summary>
        /// ���o���u��Ƹg��Login��T�Ө�
        /// </summary>
        /// <param name="domain">Domain</param>
        /// <param name="loginId">Domain Login Id</param>
        /// <param name="companyId">Comapny Id like 'ASUSTECH'</param>
        /// <returns></returns>
        public EmployeeEntity GetEmp(string loginId, string companyId)
        {
            EmployeeEntity emp = null;

            string sql = String.Format("select * from srm_user where company_id='{1}' and lower(domain_id)=lower('{0}') and work_status='Y'", loginId, companyId);

            List<EmployeeEntity> list = this.GetDBSelectSqlString<EmployeeEntity>(sql, false, DataBaseDB.UserDB);

            if (list.Count == 0)
            {

                throw new Exception(String.Format("loginId={0},CompanyId={1}����Ʀ��~�A�i��n�k���o LoginId�����", loginId, companyId));
            }

            if (list.Count >1)
            {
                log.Error("���~�G���o�h�����-�Ьd��");

                foreach (EmployeeEntity ee in list)
                {
                    
                    log.Error(String.Format("EMP_ID={0},DOMAIN_ID_CNAME={1}",ee.EmpAccountId,ee.EmpChineseName));    
                }
                

                throw new Exception(String.Format("loginId={0},CompanyId={1}����Ʀ��~�A�ϥΪ̲��ͦh�������εo��", loginId, companyId));
            }

            if (list.Count == 1)
            {
                emp = list[0];
            }
            
            

            

            return emp;

        }

        /// <summary>
        /// ���o���u��T
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="companyId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public EmployeeEntity GetEmp(string loginId, string companyId,string userId)
        {
            EmployeeEntity emp = null;

            string sql = String.Format("select * from srm_user where company_id='{1}' and lower(domain_id)=lower('{0}') and user_id='{2}' and work_status='Y'", loginId, companyId,userId);

            List<EmployeeEntity> list = this.GetDBSelectSqlString<EmployeeEntity>(sql, false, DataBaseDB.UserDB);

            if (list.Count == 0)
            {

                throw new Exception(String.Format("loginId={0},CompanyId={1}����Ʀ��~�A�i��n�k���o LoginId�����", loginId, companyId));
            }

            if (list.Count > 1)
            {
                log.Error("���~�G���o�h�����-�Ьd��");

                foreach (EmployeeEntity ee in list)
                {

                    log.Error(String.Format("EMP_ID={0},DOMAIN_ID_CNAME={1}", ee.EmpAccountId, ee.EmpChineseName));
                }


                throw new Exception(String.Format("loginId={0},CompanyId={1}����Ʀ��~�A�ϥΪ̲��ͦh�������εo��", loginId, companyId));
            }

            if (list.Count == 1)
            {
                emp = list[0];
            }





            return emp;

        }

        //public EmployeeEntity GetEmp(string domain, string loginId, string companyId)
        //{
        //    EmployeeEntity emp = null;

        //    string sql = String.Format("select * from srm_user where company_id='{2}' and domain_id='{0}' and domain='{1}'", loginId, domain, companyId);

        //    List<EmployeeEntity> list = this.GetDBSelectSqlString<EmployeeEntity>(sql, false, DataBaseDB.UserDB);

        //    if (list.Count == 1)
        //    {
        //        emp = list[0];
        //    }
        //    else if (list.Count != 0)
        //    {
        //        throw new Exception("�ϥΪ̸�ƥX�{�h�����p�A�Ьd����]");
        //    }

        //    return emp;

        //}

        /// <summary>
        /// ���oUser���Info
        /// �Q��UserId ���^���u���
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        //public EmployeeEntity GetUserInfo(string userId)
        //{
        //    return GetUserInfo(userId, m_ComapnyId);
        //}

        /// <summary>
        /// ���^���u���
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public EmployeeEntity GetUserInfo(string userId,string companyId)
        {
            object[] args = new object[] { userId, companyId };

            string sql = "select * from srm_user t where user_id='{0}' and company_id='{1}'";

            return QueryDataDetailInfo<EmployeeEntity>(sql, args, DataBaseDB.UserDB);
        }
        
       
       

        /// <summary>
        /// ���o���⪺�H��
        /// </summary>
        /// <param name="empId">���u</param>
        /// <param name="role">����</param>
        /// <returns></returns>
        //protected T GetRoleUser<T>(string userId, EnumRole role)
        //{
        //    return GetRoleUser<T>(userId, role, m_ComapnyId);            
        //}

        


        /// <summary>
        /// ���o���H��Role���C��
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="userId"></param>
        /// <param name="role"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        protected T GetRoleUser<T>(string userId, EnumRole role,string companyId)
        {
            object[] args = new object[] { userId, role.ToString(),companyId };

            string sql = "select * from npi_privilege t where user_id='{0}' and role_id='{1}' and t.company_id='{2}'";

            return this.QueryDataDetailInfo<T>(sql, args, DataBaseDB.NPIDB);
        }



        /// <summary>
        ///  ���o���ϥΪ̨���
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        //protected List<T> GetRoleList<T>(EnumRole role)
        //{
        //    return GetRoleList<T>(role,m_Enable, m_ComapnyId);

        //}

        //protected List<T> GetRoleList<T>(EnumRole role, string isEnable)
        //{
        //    return GetRoleList<T>(role, isEnable, m_ComapnyId);

        //}

        

        /// <summary>
        /// ���^�Ҧ�������C��
        /// �o�̬O�HRole���D�A��^�������H��
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isEnable"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        protected List<T> GetRoleList<T>(EnumRole role,string isEnable, string companyId)
        {
            object[] args = new object[] { role.ToString(), companyId, isEnable };

            string sql=GetRoleSql(isEnable);
            
            //string sql = "select * from npi_privilege t where 1=1 ";

            //sql += " and t.role_id='{0}' and t.company_id='{1}' ";

            //if (isEnable != "A")
            //{
            //    sql += " and t.is_enable='{2}' ";
            //}

           return this.QueryList<T>(sql, args, DataBaseDB.NPIDB);

        }

        protected string GetRoleSql(string isEnable)
        {
            string sql = "select * from npi_privilege t where 1=1 ";

            sql += " and t.role_id='{0}' and t.company_id='{1}' ";

            if (isEnable != "A")
            {
                sql += " and t.is_enable='{2}' ";
            }

            return sql;
        }

        /// <summary>
        /// ���o���H������C��
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //public List<UserEntity> QueryThisUserRoleList(string userId)
        //{
        //    return QueryThisUserRoleList(userId,m_Enable);
        //}

        /// <summary>
        /// ���o���H������C��
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isEnable"></param>
        /// <returns></returns>
        //public List<UserEntity> QueryThisUserRoleList(string userId, string isEnable)
        //{
        //    return QueryThisUserRoleList(userId,isEnable,m_ComapnyId);
        //}

        /// <summary>
        /// ���o���H������C��
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isEnable"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<UserEntity> QueryThisUserRoleList(string userId,string isEnable,string companyId)
        {
            object[] args = new object[] { userId, companyId, isEnable };

            string sql = "select * from npi_privilege t where 1=1 ";

            sql += " and t.user_id='{0}' and t.company_id='{1}' ";

            if (isEnable != "A")
            {
                sql += " and t.is_enable='{2}' ";
            }

            return this.QueryList<UserEntity>(sql, args, DataBaseDB.NPIDB); 
        }



    }
}
