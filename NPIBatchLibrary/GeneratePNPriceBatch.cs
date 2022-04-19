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
    /// �i�}�@���B���
    /// ���\�����
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
        /// ��Job �̥D�n�O�Ψӧ�ĳ����
        /// �@�Ӥp�ɶ]�@���A��M�̷s��ĳ�����
        /// �u�@�������Ʊ���
        /// �@�ӧ�ĳ����Ʈ��^��
        /// �@�ӬO�N��ưe��eQuatation
        /// �y�{�p�U�G
        /// A�G���oIsConfirm='N'�����
        ///  A1:���h���oeQuotation�w�s�b�����
        ///  A2:�A�hTipTop��Mĳ����ơA�p�G�����=IsConfirm='Y' �_�h��='N'
        ///  A3�G��sNPI������
        /// B:�NConfirm='Y'���OIsSend='N'����Ƨ�X
        /// B1:���O�N��ƪ�e�X�h
        /// B2:��s������ƥN��w�g�e�X�C
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

                ////���o�ثe�|�ݳB�z��PN
                //WriteLog("���o�ثe�|�ݳB�z��PN");

                //SourcerLogic logic = new SourcerLogic();

                //List<PNPriceEntity> pnList = logic.GetWaitingPNPriceList("N", true);

                //WriteLog(String.Format("���o�ثe�|�ݳB�z��PN�A���Ƭ�{0}��", pnList.Count));

                //if (pnList.Count > 0)
                //{
                //    ////���hEQuatation��M�O�_�����
                //    //WriteLog("���hEQuatation��M�O�_�����");
                //    //Dictionary<string, PNeQuotattionPriceEntity> dicPriceList = logic.GeteQuotationPriceDicList(pnList);
                //    //WriteLog(String.Format("eQuotation�A���Ƭ�{0}��", dicPriceList.Values.Count));

                //    ////�h��TipTop�����B���
                //    //WriteLog("�h��TipTop�����B���");
                //    //List<PNPriceEntity> confirmList = logic.GetTipTopPriceListByPN(pnList);
                //    //WriteLog(String.Format("TipTop DB���B��ơA���Ƭ�{0}��", confirmList.Count));

                //    //WriteLog("�i��eQuotation�����B�g�J");
                //    //int count = 1;
                //    //foreach (PNPriceEntity t in confirmList)
                //    //{
                //    //    WriteLog(String.Format("��{0}��,PN={1}", count, t.PN));

                //    //    if (dicPriceList.ContainsKey(t.PN + t.YearQ + t.Site))
                //    //    {
                //    //        WriteLog(String.Format("���B�G{0}", count, t.PN));
                //    //        t.QuatationPrice = dicPriceList[t.PN + t.YearQ + t.Site].Price;

                //    //    }

                //    //    count++;
                //    //}

                //    //WriteLog(String.Format("�}�l��s��ơA����={0}��", confirmList.Count));
                //    //if (confirmList.Count > 0)
                //    //{
                //    //    if (logic.UpdatePNPrice(confirmList))
                //    //    {
                //    //        isFlag = true;
                //    //        WriteLog(String.Format("��s��Ƨ����A�i��ĤT�B�J"));

                //    //    }
                //    //    else
                //    //    {
                //    //        WriteLog(String.Format("�ĤG����Ʃ|�������A�нT�{"));

                //    //    }
                //    //}
                //    //else
                //    //{
                //    //    isFlag = true;
                //    //}

                //    isFlag = true;
                    

                //    if (isFlag)
                //    {
                //        //�N��Ƨ�^�A�g�J��Ʈw�Y�i(���-�@�O�ۤw �G�OSCM���U)
                //        //���^�ثe�|IsConfirm='Y' and IsSend='N'
                //        //�N��ƥثe�OIsConfirm���OSend�O�_����ƨ��^
                //        WriteLog("�ĤT���q�}�l�A���^���ݶǰe���");
                //        List<PNPriceEntity> pnWaitingSendList = logic.GetWaitingSendPNPriceList();
                //        WriteLog(String.Format("��^���ݶǰe��ơA����={0}��", pnWaitingSendList.Count));

                //        //�������Group�@�ӬO�������
                //        SortedList<string,PNEQuotationEntity> qList =new SortedList<string,PNEQuotationEntity>();

                //        List<PNSendEntity> sList = new List<PNSendEntity>();

                //        WriteLog("�}�l��z���^�s��eQuotation���-�}�l");
                //        int countA = 1;
                //        int all = pnWaitingSendList.Count;

                //        foreach (PNPriceEntity t in pnWaitingSendList)
                //        {
                //            WriteLog(String.Format("{0}/{2}({1})", countA, t.PN,all));

                //            PNEQuotationEntity m = new PNEQuotationEntity(t);

                //            PNSendEntity s = new PNSendEntity(t);

                //            if (m.BuyingMode != "T")
                //            {
                //                //BuyingMode ==T ���n��i�h��Ƹ̭�

                                
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

                //        WriteLog("�}�l�^�s��Ʀ�eQuotation");
                //        //�s�W��eQuotation �����̫᪺���G
                //        if (!logic.InserteQuatationData(qList, sList))
                //        {
                //            WriteLog("��Ʒs�W��eQuotation����");

                //            status = EnumStatus.fail;
                //            return 0;
                //        }
                //    }
                //    else
                //    {
                //        WriteLog("���Update��NPI����");

                //        status = EnumStatus.fail;
                //        return 0;
                //    }
                //}

                
              

                status = EnumStatus.success;
                return 1;
                
            }
            catch (Exception ex)
            {
                WriteLog("�{�����ѡG"  + ex.Message + ex.StackTrace);
                status = EnumStatus.fail;
                return 0;
            }
        }

    }
}
