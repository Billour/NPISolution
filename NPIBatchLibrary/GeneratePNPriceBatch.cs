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

namespace BatchLibrary
{
    /// <summary>
    /// 展開一金額資料
    /// 本功能取消
    /// </summary>
    public class GeneratePNPriceBatch : BaseApp
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GeneratePNPriceBatch()
            : base()
        { }

        /// <summary>
        /// 本Job 最主要是用來找議價檔
        /// 一個小時跑一次，找尋最新的議價資料
        /// 工作做為兩件事情做
        /// 一個把議價資料拿回來
        /// 一個是將資料送至eQuatation
        /// 流程如下：
        /// A：取得IsConfirm='N'的資料
        ///  A1:先去取得eQuotation已存在的資料
        ///  A2:再去TipTop找尋議價資料，如果有找到=IsConfirm='Y' 否則為='N'
        ///  A3：更新NPI價格資料
        /// B:將Confirm='Y'但是IsSend='N'的資料找出
        /// B1:分別將資料表送出去
        /// B2:更新本身資料代表已經送出。
        /// </summary>
        /// <param name="batchName"></param>
        /// <returns></returns>
        public override int DoJob(string batchName)
        {
            WriteLog("Job Start");

            EnumStatus status = EnumStatus.none;
            try
            {
                

                //bool isFlag = false;

                ////取得目前尚待處理的PN
                //WriteLog("取得目前尚待處理的PN");

                //SourcerLogic logic = new SourcerLogic();

                //List<PNPriceEntity> pnList = logic.GetWaitingPNPriceList("N", true);

                //WriteLog(String.Format("取得目前尚待處理的PN，筆數為{0}筆", pnList.Count));

                //if (pnList.Count > 0)
                //{
                //    ////先去EQuatation找尋是否有資料
                //    //WriteLog("先去EQuatation找尋是否有資料");
                //    //Dictionary<string, PNeQuotattionPriceEntity> dicPriceList = logic.GeteQuotationPriceDicList(pnList);
                //    //WriteLog(String.Format("eQuotation，筆數為{0}筆", dicPriceList.Values.Count));

                //    ////去找TipTop的金額資料
                //    //WriteLog("去找TipTop的金額資料");
                //    //List<PNPriceEntity> confirmList = logic.GetTipTopPriceListByPN(pnList);
                //    //WriteLog(String.Format("TipTop DB金額資料，筆數為{0}筆", confirmList.Count));

                //    //WriteLog("進行eQuotation的金額寫入");
                //    //int count = 1;
                //    //foreach (PNPriceEntity t in confirmList)
                //    //{
                //    //    WriteLog(String.Format("第{0}筆,PN={1}", count, t.PN));

                //    //    if (dicPriceList.ContainsKey(t.PN + t.YearQ + t.Site))
                //    //    {
                //    //        WriteLog(String.Format("金額：{0}", count, t.PN));
                //    //        t.QuatationPrice = dicPriceList[t.PN + t.YearQ + t.Site].Price;

                //    //    }

                //    //    count++;
                //    //}

                //    //WriteLog(String.Format("開始更新資料，筆數={0}筆", confirmList.Count));
                //    //if (confirmList.Count > 0)
                //    //{
                //    //    if (logic.UpdatePNPrice(confirmList))
                //    //    {
                //    //        isFlag = true;
                //    //        WriteLog(String.Format("更新資料完成，進行第三步驟"));

                //    //    }
                //    //    else
                //    //    {
                //    //        WriteLog(String.Format("第二階資料尚未完成，請確認"));

                //    //    }
                //    //}
                //    //else
                //    //{
                //    //    isFlag = true;
                //    //}

                //    isFlag = true;
                    

                //    if (isFlag)
                //    {
                //        //將資料找回，寫入資料庫即可(兩個-一是自已 二是SCM底下)
                //        //取回目前尚IsConfirm='Y' and IsSend='N'
                //        //將資料目前是IsConfirm但是Send是否的資料取回
                //        WriteLog("第三階段開始，取回等待傳送資料");
                //        List<PNPriceEntity> pnWaitingSendList = logic.GetWaitingSendPNPriceList();
                //        WriteLog(String.Format("找回等待傳送資料，筆數={0}筆", pnWaitingSendList.Count));

                //        //分成兩個Group一個是本身資料
                //        SortedList<string,PNEQuotationEntity> qList =new SortedList<string,PNEQuotationEntity>();

                //        List<PNSendEntity> sList = new List<PNSendEntity>();

                //        WriteLog("開始整理欲回存至eQuotation資料-開始");
                //        int countA = 1;
                //        int all = pnWaitingSendList.Count;

                //        foreach (PNPriceEntity t in pnWaitingSendList)
                //        {
                //            WriteLog(String.Format("{0}/{2}({1})", countA, t.PN,all));

                //            PNEQuotationEntity m = new PNEQuotationEntity(t);

                //            PNSendEntity s = new PNSendEntity(t);

                //            if (m.BuyingMode != "T")
                //            {
                //                //BuyingMode ==T 不要放進去資料裡面

                                
                //                if (!qList.ContainsKey(m.PN + m.SiteVendor + m.YearQ+m.BuyingMode))
                //                {
                //                    WriteLog(String.Format("{0}-{1}-{2}-{3}", new object[] { m.SiteVendor, m.BuyingMode, m.PN, m.Site }));
                //                    qList.Add(m.PN + m.SiteVendor + m.YearQ+m.BuyingMode, m);
                //                }
                //                else
                //                {
                //                    PNEQuotationEntity m1 = qList[m.PN + m.SiteVendor + m.YearQ+m.BuyingMode];

                //                    WriteLog(String.Format("Before:{0}-{1}-{2}-{3} ", new object[] { m1.PN, m1.SiteVendor, m1.YearQ, m1.Price }));

                //                    WriteLog(String.Format("After:{0}-{1}-{2}-{3} is Exist", new object[] { m.PN, m.SiteVendor, m.YearQ,m.Price}));
                //                }
                                
                //            }
                            
                //            sList.Add(s);

                //            countA++;

                //        }

                //        WriteLog("開始回存資料至eQuotation");
                //        //新增至eQuotation 完成最後的成果
                //        if (!logic.InserteQuatationData(qList, sList))
                //        {
                //            WriteLog("資料新增至eQuotation失敗");

                //            status = EnumStatus.fail;
                //            return 0;
                //        }
                //    }
                //    else
                //    {
                //        WriteLog("資料Update至NPI失敗");

                //        status = EnumStatus.fail;
                //        return 0;
                //    }
                //}

                
              

                status = EnumStatus.success;
                return 1;
                
            }
            catch (Exception ex)
            {
                WriteLog("程式失敗："  + ex.Message + ex.StackTrace);
                status = EnumStatus.fail;
                return 0;
            }
        }

    }
}
