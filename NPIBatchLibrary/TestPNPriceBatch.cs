using System;
using System.Collections.Generic;
using System.Text;

using BatchLibrary.App;
using ASUS.B2B.SRM.BusinessTier;
using ASUS.B2B.SRM.DataTier;

using AsusLibrary.Entity;
using AsusLibrary.Logic;

using AsusLibrary.Utility;

using Asus.Data;
using System.Data;

namespace BatchLibrary
{
    /// <summary>
    /// ���\�����
    /// </summary>
    public class TestPNPriceBatch : BaseApp
    {
        public TestPNPriceBatch()
            : base()
        { }

        public override int DoJob(string batchName)
        {
            WriteLog("Job Start");

            EnumStatus status = EnumStatus.none;
            try
            {
                ////���h��PN���򥻸�ơA�p�G�����ܡA�N������ܡA�p�G�S�����ܡA�h��Ʈw���

                //string pn = LoginInfo.DebugPN;

                //SourcerLogic logic = new SourcerLogic();

                //WriteLog("���oPN�򥻸��");

                //DataTable dt = logic.GetPNTipTopPriceData(pn);

                //WriteLog("PN="+pn);

                //WriteLog("PN TipTop ���B���-------------------------");

                //foreach (DataRow row in dt.Rows)
                //{
                    

                //    WriteLog(String.Format(" {0}  {1}  {2}  {3}  {4}  {5}  {6}", new object[] { row["psa05"].ToString(), row["psa06"].ToString(), row["psa07"].ToString(), row["psb07"].ToString(), row["psaconf"].ToString(), row["psb14"].ToString(), row["psb15"].ToString() }));
                //}

                //WriteLog("PN TipTop ���B��Ƶ���-------------------------");

                //List<PNPriceEntity> list= logic.GetWaitingPNPriceList("N",pn);

                //if (list.Count > 0)
                //{
                //    int count = 1;
                //    int all = list.Count;
                //    foreach (PNPriceEntity t in list)
                //    {
                //        object[] args = new object[] { t.Site, t.PN, t.YearQ, count,all };

                //        WriteLog(String.Format("��{3}/{4}��,Site={0},PN={1},YearQ={2}", args));
                        
                //        PNTipTopPriceEntity obj = logic.GetPNTipTopPriceData(t.Site, t.PN, t.YearQ);

                //        if (obj != null)
                //        {
                //            WriteLog(String.Format("���B={0},DolarType={1}", obj.PNPrice, obj.DollarType));
                //        }
                //        else
                //        {
                //            WriteLog("�ŭ�");
                //        }

                //        count++;
                //    }
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
    }
}
