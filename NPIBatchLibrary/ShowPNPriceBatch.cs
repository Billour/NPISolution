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
    /// 本功能取消
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
                ////取得目前尚待處理的PN
                //WriteLog("取得目前尚待處理的PN");
                //SourcerLogic logic = new SourcerLogic();
                //List<PNPriceEntity> pnList = logic.GetWaitingPNPriceList("N");
                //WriteLog(String.Format("取得目前尚待處理的PN，筆數為{0}筆", pnList.Count));

                //if (pnList.Count > 0)
                //{
                //    //先去EQuatation找尋是否有資料
                //    WriteLog("先去EQuatation找尋是否有資料");
                //    Dictionary<string, PNeQuotattionPriceEntity> dicPriceList = logic.GeteQuotationPriceDicList(pnList);
                //    WriteLog(String.Format("eQuotation，筆數為{0}筆", dicPriceList.Values.Count));

                //    //去找TipTop的金額資料
                //    WriteLog("去找TipTop的金額資料");
                //    List<PNPriceEntity> confirmList = logic.GetTipTopPriceListByPN(pnList);
                //    WriteLog(String.Format("TipTop DB金額資料，筆數為{0}筆", confirmList.Count));

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
                WriteLog("程式失敗：" + ex.InnerException.ToString() + ex.Message + ex.StackTrace);
                status = EnumStatus.fail;
                return 0;
            }

        }
    }
}
