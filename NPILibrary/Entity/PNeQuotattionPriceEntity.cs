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
    /// eQuotation Price
    /// 根據Table SCM_EQUOTE_PN_PRICE
    /// 所製作
    /// </summary>
    public class PNeQuotattionPriceEntity:BaseEntity
    {
        private string _PN;
        private string _YearQ;
        private string _Site;
        private string _SiteVendor;
        private double _Price;

        /// <summary>
        /// PN
        /// </summary>
        [DataColumn("ASUS_PN")]
        public string PN
        {
            set { _PN = value; }
            get { return _PN; }
        }

        /// <summary>
        /// 年度
        /// </summary>
        [DataColumn("GROUP_NO")]
        public string YearQ
        {
            set { _YearQ = value; }
            get { return _YearQ; }
        }

        /// <summary>
        /// EMS Site
        /// </summary>
        [DataColumn("Site")]
        public string Site
        {
            set { _Site = value; }
            get { return _Site; }
        }

        /// <summary>
        /// EMS Vendor Site
        /// </summary>
        [DataColumn("EMS_CODE")]
        public string SiteVendor
        {
            set { _SiteVendor = value; }
            get { return _SiteVendor; }
        }

        /// <summary>
        /// 價格
        /// </summary>
        [DataColumn("PO_PRICE")]
        public double Price
        {
            set { _Price = value; }
            get { return _Price; }
        }

    }
}
