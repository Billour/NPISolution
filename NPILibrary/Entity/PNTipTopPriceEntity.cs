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
    /// Tip Top 的議價檔資料
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
        /// 與NPI 及euotation不一樣
        /// </summary>
        [DataColumn("psa07")]
        public string TipTopSite
        {
            set { _TipTopSite = value; }
            get { return _TipTopSite; }
        }

        /// <summary>
        /// 幣別
        /// </summary>
        [DataColumn("psa06")]
        public string DollarType
        {
            set { _DollarType = value; }
            get { return _DollarType; }
        }

        /// <summary>
        /// 價格
        /// </summary>
        [DataColumn("PSB07")]
        public double PNPrice
        {
            set { _PNPrice = value; }
            get { return _PNPrice; }
        }

        /// <summary>
        /// 生效日
        /// </summary>
        [DataColumn("Psb14")]
        public string EffectedDate
        {
            set { _EffectedDate = value; }
            get { return _EffectedDate; }
        }

        /// <summary>
        /// 失效日
        /// </summary>
        [DataColumn("Psb15")]
        public string DisAbleDate
        {
            set { _DisAbleDate = value; }
            get { return _DisAbleDate; }
        }
    }
}
