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
    /// 確定BuyingMode 的資料
    /// 本功能取消
    /// </summary>
    public class GenerateBuyingModeBatch : BaseApp
    {

        public GenerateBuyingModeBatch()
            : base()
        { }

        public override int DoJob(string batchName)
        {
            WriteLog("Job Start");

            EnumStatus status = EnumStatus.none;
            try
            {
                //SourcerLogic logic = new SourcerLogic();

                //////從資料庫資取回
                //List<PNPriceEntity> allList = logic.GetBuyingModeIsNullPNPriceList();
                //////對應BuyingMode
                //foreach (PNPriceEntity p in allList)
                //{
                //    string buyMode = logic.GetBuyingMode(p.Site, p.PN, LoginInfo.ConSignSite);

                //    p.BuyingMode = buyMode;

                //    WriteLog(String.Format("{0} {1} {2}", p.PN, p.Site, p.BuyingMode));
                //}

                ////寫入資料庫中
                //WriteLog("寫入資料庫中--開始");
                //if (logic.UpdatePNPriceBuyingMode(allList))
                //{
                //    WriteLog("寫入資料庫中--結束");    
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
