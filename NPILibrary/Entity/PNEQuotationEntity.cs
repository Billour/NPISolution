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
    /// PN在EQuatation的資料
    /// Table SCM_EQuotation_NPI_Price
    /// 提供
    /// </summary>
    public class PNEQuotationEntity:BaseEntity
    {
        private string _PN;
        private string _YearQ;
        private string _Site;
        private string _SiteVendor;
        private string _SiteVendor2;
        private string _BuyingMode;
        
        private string _PNDesc;
        private string _PNSpec;
        private string _DaoolarType;
        private double _Price;
        private string _EffectiveDate;
        private string _DisableDate;

        private string _CreatUser="System";
        private string _CreatDate=DateTime.Now.ToString("yyyy/MM/dd");

        [Tables("SCM_EQUOTE_NPI_PRICE", PageCommandType.InsertColumnMode, DBCommandType.InsertMode, "", null)]
        public PNEQuotationEntity()
        { }

        public PNEQuotationEntity(PNPriceEntity obj)
        {
            _PN = obj.PN;
            _YearQ = obj.YearQ;
            _Site = obj.Site;
            _BuyingMode = obj.BuyingMode;



            //規格資料
            _PNDesc = obj.PNDesc;
            _PNSpec = obj.PNSpec;


            _DaoolarType = obj.DollarType;
            _Price = obj.TipTopPrice;
            _EffectiveDate = obj.EffectDate;
            _DisableDate = obj.DisableDate;
            

            
        }

        /// <summary>
        /// PN元件料號
        /// </summary>
        [DataColumn("ASUS_PN")]
        [InsertColumn("SCM_EQUOTE_NPI_PRICE", "ASUS_PN", Asus.Data.DataType.NVarChar)]
        public string PN
        {
            set { _PN = value; }
            get { return _PN; }
        }

        /// <summary>
        /// 年度資料
        /// </summary>
        [DataColumn("GROUP_NO")]
        [InsertColumn("SCM_EQUOTE_NPI_PRICE", "GROUP_NO", Asus.Data.DataType.NVarChar)]
        public string YearQ
        {
            set { _YearQ = value; }
            get { return _YearQ; }
        }

        public string Site
        {
            set { _Site = value; }
            get { return _Site; }
        }

        /// <summary>
        /// Site Vendor 資料
        /// 現在由轉換回來由EMS--> Vendor
        /// </summary>

        [DataColumn("EMS_CODE")]
        [InsertColumn("SCM_EQUOTE_NPI_PRICE", "EMS_CODE", Asus.Data.DataType.NVarChar)]
        public string SiteVendor
        {
            set { _SiteVendor = value; }
            get {
                SourcerLogic logic = new SourcerLogic();

                    return logic.GetVendorCode(_Site); 
            
            }
        }

       
        public string SiteVendor2
        {
            set { _SiteVendor = value; }
            get
            {
                return _SiteVendor2;
            }
        }


        /// <summary>
        /// Buying Mode
        /// </summary>
        [DataColumn("BUYING_MODE")]
        [InsertColumn("SCM_EQUOTE_NPI_PRICE", "BUYING_MODE", Asus.Data.DataType.NVarChar)]
        public string BuyingMode
        {
            set { _BuyingMode = value; }
            get { return _BuyingMode; }
        }

        /// <summary>
        /// PN說明
        /// </summary>
        [DataColumn("PART_DESC")]
        [InsertColumn("SCM_EQUOTE_NPI_PRICE", "PART_DESC", Asus.Data.DataType.NVarChar)]
        public string PNDesc
        {
            set { _PNDesc = value; }
            get { return _PNDesc; }
        }

        /// <summary>
        /// PN Spec
        /// </summary>
        [DataColumn("PART_SPEC")]
        [InsertColumn("SCM_EQUOTE_NPI_PRICE", "PART_SPEC", Asus.Data.DataType.NVarChar)]
        public string PNSpec
        {
            set { _PNSpec = value; }
            get { return _PNSpec; }
        }

        /// <summary>
        /// 幣別
        /// </summary>
        [DataColumn("CURRENCY")]
        [InsertColumn("SCM_EQUOTE_NPI_PRICE", "CURRENCY", Asus.Data.DataType.NVarChar)]
        public string DaoolarType
        {
            set { _DaoolarType = value; }
            get { return _DaoolarType; }
        }

        [DataColumn("PO_PRICE")]
        [InsertColumn("SCM_EQUOTE_NPI_PRICE", "PO_PRICE", Asus.Data.DataType.Double)]
        public double Price
        {
            set { _Price = value; }
            get { return _Price; }
        }

        [DataColumn("PO_EFFECTIVE_DATE")]
        [InsertColumn("SCM_EQUOTE_NPI_PRICE", "PO_EFFECTIVE_DATE", Asus.Data.DataType.DateTime)]
        public string EffectiveDate
        {
            set { _EffectiveDate = value; }
            get { return _EffectiveDate; }
        }

        [DataColumn("PO_EXPIRED_DATE")]
        [InsertColumn("SCM_EQUOTE_NPI_PRICE", "PO_EXPIRED_DATE", Asus.Data.DataType.DateTime)]
        public string DisableDate
        {
            set { _DisableDate = value; }
            get { return _DisableDate; }
        }

        [DataColumn("CRE_STAFF")]
        [InsertColumn("SCM_EQUOTE_NPI_PRICE", "CRE_STAFF", Asus.Data.DataType.NVarChar)]
        public string CreatUser
        {
            set { _CreatUser = value; }
            get { return _CreatUser; }
        }

        [DataColumn("CRE_DATE")]
        [InsertColumn("SCM_EQUOTE_NPI_PRICE", "CRE_DATE", Asus.Data.DataType.DateTime)]
        public string CreatDate
        {
            set { _CreatDate = value; }
            get { return _CreatDate; }
        }

        
    }
}
