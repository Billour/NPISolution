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
    public class PNPriceBaseEntity:BaseEntity
    {
        private string _PN;

        private string _PNDesc;
        private string _PNSpec;

        private string _YearQ;
        private string _IsConfirm="N";
        private string _IsSend="N";

        private string _BuyingMode="";

        private string _DollarType="USD";
        private string _DollarTypeName="";

        private string _Site;
        private string _SiteName="";
        private string _SiteVendor;

        private double _TipTopPrice=-1;
        private double _QuatationPrice=-1;
        private string _EffectDate=DateTime.Now.ToString();
        private string _DisableDate=DateTime.Now.ToString();

        private string _CreateUser;
        private string _CreateTime=DateTime.Now.ToString();

        private string _ConfirmUser;
        private string _ConfirmTime;

        private string _SendUser;
        private string _SendTime;

        
        /// <summary>
        /// 元件料號
        /// </summary>
        [DataColumn("PN")]
        [InsertColumn("NPI_PNPRICE", "PN", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "元件料號", "Y", ViewRowType.BoundField, "N", 10)]
        [QueryColumn2("", "元件料號", "Y", ViewRowType.BoundField, "N", 10)]
        public string PN
        {
            set { _PN = value; }
            get { return _PN; }
        }

        /// <summary>
        /// PN 說明
        /// </summary>
        [DataColumn("PN_DESC")]
        [InsertColumn("NPI_PNPRICE", "PN_DESC", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "PN品名", "Y", ViewRowType.BoundField, "N", 12)]
        [QueryColumn2("", "PN品名", "Y", ViewRowType.BoundField, "N", 12)]
        public string PNDesc
        {
            set{_PNDesc=value;}
            get{return _PNDesc;}
        }

        /// <summary>
        /// PN規格
        /// </summary>
        [DataColumn("PN_SPEC")]
        [InsertColumn("NPI_PNPRICE", "PN_SPEC", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "PN規格", "Y", ViewRowType.BoundField, "N", 14)]
        [QueryColumn2("", "PN規格", "Y", ViewRowType.BoundField, "N", 14)]
        public string PNSpec
        {
            set { _PNSpec = value; }
            get { return _PNSpec; }
        }

        /// <summary>
        /// 每一個PN都有一個BuyingMode
        /// </summary>
        [DataColumn("BUYING_MODE")]
        [InsertColumn("NPI_PNPRICE", "BUYING_MODE", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "BuyingMode", "Y", ViewRowType.BoundField, "N", 16)]
        [QueryColumn2("", "BuyingMode", "Y", ViewRowType.BoundField, "N", 16)]
        public string BuyingMode
        {
            set { _BuyingMode = value; }
            get { return _BuyingMode; }
        }

        /// <summary>
        /// 年度
        /// </summary>
        [DataColumn("YEARQ")]
        [InsertColumn("NPI_PNPRICE", "YEARQ", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "年度", "Y", ViewRowType.BoundField, "N", 20)]
        [QueryColumn2("", "年度", "Y", ViewRowType.BoundField, "N", 20)]
        public string YearQ
        {
            set { _YearQ = value; }
            get { return _YearQ; }
        }

       

        /// <summary>
        /// 是否確認
        /// </summary>
        [DataColumn("IS_CONFIRM")]
        [InsertColumn("NPI_PNPRICE", "IS_CONFIRM", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("NPI_PNPRICE", "IS_CONFIRM", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "是否確認", "Y", ViewRowType.BoundField, "N", 30)]
        public string IsConfirm
        {
            set { _IsConfirm = value; }
            get { return _IsConfirm; }
        }

        /// <summary>
        /// 是否已經送至eQuatation
        /// </summary>
        [DataColumn("IS_SEND")]
        [InsertColumn("NPI_PNPRICE", "IS_SEND", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("NPI_PNPRICE", "IS_SEND", Asus.Data.DataType.NVarChar)]
        public string IsSend
        {
            set { _IsSend = value; }
            get { return _IsSend; }
        }

        /// <summary>
        /// 幣別
        /// </summary>
        [DataColumn("DOLLAR_TYPE")]
        [InsertColumn("NPI_PNPRICE", "DOLLAR_TYPE", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("NPI_PNPRICE", "DOLLAR_TYPE", Asus.Data.DataType.NVarChar)]
        public string DollarType
        {
            set { _DollarType = value; }
            get { return _DollarType; }
        }

        /// <summary>
        /// 幣別名稱
        /// </summary>
        [DataColumn("DOLLAR_TYPENAME")]
        [QueryColumn("", "幣別", "Y", ViewRowType.BoundField, "N", 40)]
        public string DollarTypeName
        {
            set { _DollarTypeName = value; }
            get { return _DollarTypeName; }
        }

        /// <summary>
        /// Site 別，由BOM決定
        /// </summary>
        [DataColumn("LOCATION_SITE")]
        [InsertColumn("NPI_PNPRICE", "LOCATION_SITE", Asus.Data.DataType.NVarChar)]
        public string Site
        {
            set { _Site = value; }
            get { return _Site; }
        }

        [DataColumn("EMS_NAME")]
        [QueryColumn("", "生產地", "Y", ViewRowType.BoundField, "N", 45)]
        [QueryColumn2("", "生產地", "Y", ViewRowType.BoundField, "N", 45)]
        public string SiteName
        {
            set { _SiteName = value; }
            get { return _SiteName; }
        }

        public string SiteVendor
        {
            set { _SiteVendor = value; }
            get
            {
                SourcerLogic logic = new SourcerLogic();

                return logic.GetVendorCode(_Site);

            }
        }

        /// <summary>
        /// 由Tip Top 找得的資料檔
        /// </summary>
        [DataColumn("TIPTOP_PRICE")]
        [QueryColumn("", "TipTop金額", "Y", ViewRowType.BoundField, "N", 50)]
        [InsertColumn("NPI_PNPRICE", "TIPTOP_PRICE", Asus.Data.DataType.Double)]
        [UpdateColumn("NPI_PNPRICE", "TIPTOP_PRICE", Asus.Data.DataType.Double)]
        public double TipTopPrice
        {
            set { _TipTopPrice = value; }
            get { return _TipTopPrice; }
        }

        /// <summary>
        /// 由Quatation 取得的價錢檔案
        /// </summary>
        [DataColumn("QUATATION_PRICE")]
        [InsertColumn("NPI_PNPRICE", "QUATATION_PRICE", Asus.Data.DataType.Double)]
        [UpdateColumn("NPI_PNPRICE", "QUATATION_PRICE", Asus.Data.DataType.Double)]
        [QueryColumn("", "eQuatation金額", "Y", ViewRowType.BoundField, "N", 60)]
        public double QuatationPrice
        {
            set { _QuatationPrice = value; }
            get { return _QuatationPrice; }
        }

        /// <summary>
        /// 生效日
        /// </summary>
        [DataColumn("EFFECT_DATE")]
        [InsertColumn("NPI_PNPRICE", "EFFECT_DATE", Asus.Data.DataType.DateTime)]
        [UpdateColumn("NPI_PNPRICE", "EFFECT_DATE", Asus.Data.DataType.DateTime)]
        [QueryColumn("", "生效日", "Y", ViewRowType.BoundField, "N", 70)]
        public string EffectDate
        {
            set { _EffectDate = value; }
            get { return _EffectDate; }
        }

        /// <summary>
        /// 失效日
        /// </summary>
        [DataColumn("DISABLE_DATE")]
        [InsertColumn("NPI_PNPRICE", "DISABLE_DATE", Asus.Data.DataType.DateTime)]
        [UpdateColumn("NPI_PNPRICE", "DISABLE_DATE", Asus.Data.DataType.DateTime)]
        [QueryColumn("", "失效日", "Y", ViewRowType.BoundField, "N", 80)]
        public string DisableDate
        {
            set { _DisableDate = value; }
            get { return _DisableDate; }
        }

        /// <summary>
        /// 建立人員
        /// </summary>
        [DataColumn("CREATE_USER")]
        [InsertColumn("NPI_PNPRICE", "CREATE_USER", Asus.Data.DataType.NVarChar)]
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }

        /// <summary>
        /// 建立時間
        /// </summary>
        [DataColumn("CREATE_TIME")]
        [InsertColumn("NPI_PNPRICE", "CREATE_TIME", Asus.Data.DataType.DateTime)]
        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }

        /// <summary>
        /// 確認金額人員
        /// </summary>
        [DataColumn("CONFIRM_USER")]
        [UpdateColumn("NPI_PNPRICE", "CONFIRM_USER", Asus.Data.DataType.NVarChar)]
        public string ConfirmUser
        {
            set { _ConfirmUser = value; }
            get { return _ConfirmUser; }
        }

        /// <summary>
        /// 確認金額時間
        /// </summary>
        [DataColumn("CONFIRM_TIME")]
        [UpdateColumn("NPI_PNPRICE", "CONFIRM_TIME", Asus.Data.DataType.DateTime)]
        public string ConfirmTime
        {
            set { _ConfirmTime = value; }
            get { return _ConfirmTime; }
        }

        /// <summary>
        /// 送至eQuatattion人員
        /// </summary>
        [DataColumn("SEND_USER")]
        [UpdateColumn("NPI_PNPRICE", "SEND_USER", Asus.Data.DataType.NVarChar)]
        public string SendUser
        {
            set { _SendUser = value; }
            get { return _SendUser; }
        }

        /// <summary>
        /// 寄送時間
        /// </summary>
        [DataColumn("SEND_TIME")]
        [UpdateColumn2("NPI_PNPRICE", "SEND_TIME", Asus.Data.DataType.DateTime)]
        public string SendTime
        {
            set { _SendTime = value; }
            get { return _SendTime; }
        }
    }
}
