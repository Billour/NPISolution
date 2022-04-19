using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

using BatchLibrary.App;
using ASUS.B2B.SRM.BusinessTier;
using ASUS.B2B.SRM.DataTier;

using AsusLibrary.Entity;
using AsusLibrary.Logic;

namespace BatchLibrary
{
    /// <summary>
    /// ���\�����
    /// </summary>
    public class TestBomBatch:BaseApp
    {
        public TestBomBatch()
            : base()
        { }

        public override int DoJob(string batchName)
        {
            WriteLog("Job Start");

            EnumStatus status = EnumStatus.none;
            try
            {
               //Generate BOM
            //  string workNo = GetBOMPN(ConfigurationSettings.AppSettings["BOMId"].ToString());

            //  WriteLog(String.Format("workNo=({0})", workNo));

            //  List<AsusBomEntity> AsusBomList = GetErpBomListByWorkNo(workNo);
            
            //  WriteLog(String.Format("Count={0}",AsusBomList.Count));

            //int no=1;
            //foreach (AsusBomEntity ss in AsusBomList)
            //{
            //   WriteLog(String.Format("{1}.PN={0}",ss.PN,no));

            //   no ++;
            //}
                    
                status = EnumStatus.success;
                return 1;
            }
            catch (Exception ex)
            {
                WriteLog("�{�����ѡG" + ex.InnerException.ToString() + ex.Message + ex.StackTrace);
                status = EnumStatus.fail;
                return 0;
            }
            
        }

        private string GetBOMPN(string bomId)
        {
            //WriteLog(String.Format("�}�l�iBOM={0}���", bomId));

            DBServer insDB = new DBServer();

            //WriteLog(String.Format("DB ConnectionString={0}", insDB.ConnectionString));

            insDB.CloseConnAfterExec = false;

            DBServer insDBErp = new DBServer("ERP");

            //WriteLog(String.Format("ERP ConnectionString={0}", insDBErp.ConnectionString));

            insDBErp.CloseConnAfterExec = false;

            //WriteLog("�}�l�iBOM���");

            ERPSync insERPSync = new ERPSync(insDB, insDBErp);

            insERPSync.DlBomPoPartsThenStop = true;

            insERPSync.DlBomSubParts = true; // �O�_�n���N��

            insERPSync.DlBomLevelLimitTwo = false; // ���խ���U���h��

            insERPSync.DlBomN2N = true;

            string workNo = insERPSync.DownloadBom(bomId);

            //WriteLog(String.Format("WorkNo={0}", workNo));

            insDB.CloseConnection();
            insDBErp.CloseConnection();

            //WriteLog(String.Format("�����iBOM��T"));

            return workNo;
        }

        /// <summary>
        /// ���o�@��WorkNo���U�����
        /// </summary>
        /// <param name="workNo"></param>
        /// <returns></returns>
        private List<AsusBomEntity> GetErpBomListByWorkNo(string workNo)
        {
            AsusBomLogic logic = new AsusBomLogic();

            return logic.GetERPBomList(workNo);
        }
    }
}
