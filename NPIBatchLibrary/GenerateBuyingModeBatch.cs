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
    /// �T�wBuyingMode �����
    /// ���\�����
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

                //////�q��Ʈw����^
                //List<PNPriceEntity> allList = logic.GetBuyingModeIsNullPNPriceList();
                //////����BuyingMode
                //foreach (PNPriceEntity p in allList)
                //{
                //    string buyMode = logic.GetBuyingMode(p.Site, p.PN, LoginInfo.ConSignSite);

                //    p.BuyingMode = buyMode;

                //    WriteLog(String.Format("{0} {1} {2}", p.PN, p.Site, p.BuyingMode));
                //}

                ////�g�J��Ʈw��
                //WriteLog("�g�J��Ʈw��--�}�l");
                //if (logic.UpdatePNPriceBuyingMode(allList))
                //{
                //    WriteLog("�g�J��Ʈw��--����");    
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
