using System;
using System.Collections.Generic;
using System.Text;

using BatchLibrary.App;
using ASUS.B2B.SRM.BusinessTier;
using ASUS.B2B.SRM.DataTier;

using AsusLibrary.Entity;
using AsusLibrary.Logic;

using AsusLibrary.Utility;

namespace BatchLibrary
{
    /// <summary>
    /// ���\�����
    /// </summary>
    public class ShowPNPriceBatch:BaseApp
    {
        public ShowPNPriceBatch()
            : base()
        { }

        public override int DoJob(string batchName)
        {
            WriteLog("Job Start");

            EnumStatus status = EnumStatus.none;
            try
            {
                ////���o�ثe�|�ݳB�z��PN
                //WriteLog("���o�ثe�|�ݳB�z��PN");
                //SourcerLogic logic = new SourcerLogic();
                //List<PNPriceEntity> pnList = logic.GetWaitingPNPriceList("N");
                //WriteLog(String.Format("���o�ثe�|�ݳB�z��PN�A���Ƭ�{0}��", pnList.Count));

                //if (pnList.Count > 0)
                //{
                //    //���hEQuatation��M�O�_�����
                //    WriteLog("���hEQuatation��M�O�_�����");
                //    Dictionary<string, PNeQuotattionPriceEntity> dicPriceList = logic.GeteQuotationPriceDicList(pnList);
                //    WriteLog(String.Format("eQuotation�A���Ƭ�{0}��", dicPriceList.Values.Count));

                //    //�h��TipTop�����B���
                //    WriteLog("�h��TipTop�����B���");
                //    List<PNPriceEntity> confirmList = logic.GetTipTopPriceListByPN(pnList);
                //    WriteLog(String.Format("TipTop DB���B��ơA���Ƭ�{0}��", confirmList.Count));

                //    foreach (PNPriceEntity t in confirmList)
                //    {
                //        WriteLog(String.Format("{0} {1} {2} {3}", new object[] { t.PN,t.YearQ,t.Site,t.TipTopPrice}));
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
