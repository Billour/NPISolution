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
    /// 本功能取消
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
                WriteLog("程式失敗：" + ex.InnerException.ToString() + ex.Message + ex.StackTrace);
                status = EnumStatus.fail;
                return 0;
            }
            
        }

        private string GetBOMPN(string bomId)
        {
            //WriteLog(String.Format("開始展BOM={0}資料", bomId));

            DBServer insDB = new DBServer();

            //WriteLog(String.Format("DB ConnectionString={0}", insDB.ConnectionString));

            insDB.CloseConnAfterExec = false;

            DBServer insDBErp = new DBServer("ERP");

            //WriteLog(String.Format("ERP ConnectionString={0}", insDBErp.ConnectionString));

            insDBErp.CloseConnAfterExec = false;

            //WriteLog("開始展BOM資料");

            ERPSync insERPSync = new ERPSync(insDB, insDBErp);

            insERPSync.DlBomPoPartsThenStop = true;

            insERPSync.DlBomSubParts = true; // 是否要替代料

            insERPSync.DlBomLevelLimitTwo = false; // 測試限制下載層數

            insERPSync.DlBomN2N = true;

            string workNo = insERPSync.DownloadBom(bomId);

            //WriteLog(String.Format("WorkNo={0}", workNo));

            insDB.CloseConnection();
            insDBErp.CloseConnection();

            //WriteLog(String.Format("完成展BOM資訊"));

            return workNo;
        }

        /// <summary>
        /// 取得一個WorkNo之下的資料
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
