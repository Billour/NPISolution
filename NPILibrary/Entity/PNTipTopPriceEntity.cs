using System;
using System.Collections.Generic;
using System.Text;

using Asus;
using Asus.Bussiness.Attribute;
using Asus.Bussiness.Map;
using System.Web.UI.WebControls;
using AsusLibrary.Logic;


namespace AsusLibrary.Entity
{
    /// <summary>
    /// Tip Top ��ĳ���ɸ��
    /// </summary>
    public class PNTipTopPriceEntity:BaseEntity
    {
        private string _PN;
        private string _YearQ;
        private string _TipTopSite;
        private string _DollarType;
        private double _PNPrice;
        private string _EffectedDate;
        private string _DisAbleDate;

        
        public string PN
        {
            set { _PN = value; }
            get { return _PN; }
        }

        
        public string YearQ
        {
            set { _YearQ = value; }
            get { return _YearQ; }
        }

        /// <summary>
        /// TipTop Site
        /// �PNPI ��euotation���@��
        /// </summary>
        [DataColumn("psa07")]
        public string TipTopSite
        {
            set { _TipTopSite = value; }
            get { return _TipTopSite; }
        }

        /// <summary>
        /// ���O
        /// </summary>
        [DataColumn("psa06")]
        public string DollarType
        {
            set { _DollarType = value; }
            get { return _DollarType; }
        }

        /// <summary>
        /// ����
        /// </summary>
        [DataColumn("PSB07")]
        public double PNPrice
        {
            set { _PNPrice = value; }
            get { return _PNPrice; }
        }

        /// <summary>
        /// �ͮĤ�
        /// </summary>
        [DataColumn("Psb14")]
        public string EffectedDate
        {
            set { _EffectedDate = value; }
            get { return _EffectedDate; }
        }

        /// <summary>
        /// ���Ĥ�
        /// </summary>
        [DataColumn("Psb15")]
        public string DisAbleDate
        {
            set { _DisAbleDate = value; }
            get { return _DisAbleDate; }
        }
    }
}
