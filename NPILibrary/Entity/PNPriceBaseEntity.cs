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
        /// ����Ƹ�
        /// </summary>
        [DataColumn("PN")]
        [InsertColumn("NPI_PNPRICE", "PN", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "����Ƹ�", "Y", ViewRowType.BoundField, "N", 10)]
        [QueryColumn2("", "����Ƹ�", "Y", ViewRowType.BoundField, "N", 10)]
        public string PN
        {
            set { _PN = value; }
            get { return _PN; }
        }

        /// <summary>
        /// PN ����
        /// </summary>
        [DataColumn("PN_DESC")]
        [InsertColumn("NPI_PNPRICE", "PN_DESC", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "PN�~�W", "Y", ViewRowType.BoundField, "N", 12)]
        [QueryColumn2("", "PN�~�W", "Y", ViewRowType.BoundField, "N", 12)]
        public string PNDesc
        {
            set{_PNDesc=value;}
            get{return _PNDesc;}
        }

        /// <summary>
        /// PN�W��
        /// </summary>
        [DataColumn("PN_SPEC")]
        [InsertColumn("NPI_PNPRICE", "PN_SPEC", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "PN�W��", "Y", ViewRowType.BoundField, "N", 14)]
        [QueryColumn2("", "PN�W��", "Y", ViewRowType.BoundField, "N", 14)]
        public string PNSpec
        {
            set { _PNSpec = value; }
            get { return _PNSpec; }
        }

        /// <summary>
        /// �C�@��PN�����@��BuyingMode
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
        /// �~��
        /// </summary>
        [DataColumn("YEARQ")]
        [InsertColumn("NPI_PNPRICE", "YEARQ", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "�~��", "Y", ViewRowType.BoundField, "N", 20)]
        [QueryColumn2("", "�~��", "Y", ViewRowType.BoundField, "N", 20)]
        public string YearQ
        {
            set { _YearQ = value; }
            get { return _YearQ; }
        }

       

        /// <summary>
        /// �O�_�T�{
        /// </summary>
        [DataColumn("IS_CONFIRM")]
        [InsertColumn("NPI_PNPRICE", "IS_CONFIRM", Asus.Data.DataType.NVarChar)]
        [UpdateColumn("NPI_PNPRICE", "IS_CONFIRM", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "�O�_�T�{", "Y", ViewRowType.BoundField, "N", 30)]
        public string IsConfirm
        {
            set { _IsConfirm = value; }
            get { return _IsConfirm; }
        }

        /// <summary>
        /// �O�_�w�g�e��eQuatation
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
        /// ���O
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
        /// ���O�W��
        /// </summary>
        [DataColumn("DOLLAR_TYPENAME")]
        [QueryColumn("", "���O", "Y", ViewRowType.BoundField, "N", 40)]
        public string DollarTypeName
        {
            set { _DollarTypeName = value; }
            get { return _DollarTypeName; }
        }

        /// <summary>
        /// Site �O�A��BOM�M�w
        /// </summary>
        [DataColumn("LOCATION_SITE")]
        [InsertColumn("NPI_PNPRICE", "LOCATION_SITE", Asus.Data.DataType.NVarChar)]
        public string Site
        {
            set { _Site = value; }
            get { return _Site; }
        }

        [DataColumn("EMS_NAME")]
        [QueryColumn("", "�Ͳ��a", "Y", ViewRowType.BoundField, "N", 45)]
        [QueryColumn2("", "�Ͳ��a", "Y", ViewRowType.BoundField, "N", 45)]
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
        /// ��Tip Top ��o�������
        /// </summary>
        [DataColumn("TIPTOP_PRICE")]
        [QueryColumn("", "TipTop���B", "Y", ViewRowType.BoundField, "N", 50)]
        [InsertColumn("NPI_PNPRICE", "TIPTOP_PRICE", Asus.Data.DataType.Double)]
        [UpdateColumn("NPI_PNPRICE", "TIPTOP_PRICE", Asus.Data.DataType.Double)]
        public double TipTopPrice
        {
            set { _TipTopPrice = value; }
            get { return _TipTopPrice; }
        }

        /// <summary>
        /// ��Quatation ���o�������ɮ�
        /// </summary>
        [DataColumn("QUATATION_PRICE")]
        [InsertColumn("NPI_PNPRICE", "QUATATION_PRICE", Asus.Data.DataType.Double)]
        [UpdateColumn("NPI_PNPRICE", "QUATATION_PRICE", Asus.Data.DataType.Double)]
        [QueryColumn("", "eQuatation���B", "Y", ViewRowType.BoundField, "N", 60)]
        public double QuatationPrice
        {
            set { _QuatationPrice = value; }
            get { return _QuatationPrice; }
        }

        /// <summary>
        /// �ͮĤ�
        /// </summary>
        [DataColumn("EFFECT_DATE")]
        [InsertColumn("NPI_PNPRICE", "EFFECT_DATE", Asus.Data.DataType.DateTime)]
        [UpdateColumn("NPI_PNPRICE", "EFFECT_DATE", Asus.Data.DataType.DateTime)]
        [QueryColumn("", "�ͮĤ�", "Y", ViewRowType.BoundField, "N", 70)]
        public string EffectDate
        {
            set { _EffectDate = value; }
            get { return _EffectDate; }
        }

        /// <summary>
        /// ���Ĥ�
        /// </summary>
        [DataColumn("DISABLE_DATE")]
        [InsertColumn("NPI_PNPRICE", "DISABLE_DATE", Asus.Data.DataType.DateTime)]
        [UpdateColumn("NPI_PNPRICE", "DISABLE_DATE", Asus.Data.DataType.DateTime)]
        [QueryColumn("", "���Ĥ�", "Y", ViewRowType.BoundField, "N", 80)]
        public string DisableDate
        {
            set { _DisableDate = value; }
            get { return _DisableDate; }
        }

        /// <summary>
        /// �إߤH��
        /// </summary>
        [DataColumn("CREATE_USER")]
        [InsertColumn("NPI_PNPRICE", "CREATE_USER", Asus.Data.DataType.NVarChar)]
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }

        /// <summary>
        /// �إ߮ɶ�
        /// </summary>
        [DataColumn("CREATE_TIME")]
        [InsertColumn("NPI_PNPRICE", "CREATE_TIME", Asus.Data.DataType.DateTime)]
        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }

        /// <summary>
        /// �T�{���B�H��
        /// </summary>
        [DataColumn("CONFIRM_USER")]
        [UpdateColumn("NPI_PNPRICE", "CONFIRM_USER", Asus.Data.DataType.NVarChar)]
        public string ConfirmUser
        {
            set { _ConfirmUser = value; }
            get { return _ConfirmUser; }
        }

        /// <summary>
        /// �T�{���B�ɶ�
        /// </summary>
        [DataColumn("CONFIRM_TIME")]
        [UpdateColumn("NPI_PNPRICE", "CONFIRM_TIME", Asus.Data.DataType.DateTime)]
        public string ConfirmTime
        {
            set { _ConfirmTime = value; }
            get { return _ConfirmTime; }
        }

        /// <summary>
        /// �e��eQuatattion�H��
        /// </summary>
        [DataColumn("SEND_USER")]
        [UpdateColumn("NPI_PNPRICE", "SEND_USER", Asus.Data.DataType.NVarChar)]
        public string SendUser
        {
            set { _SendUser = value; }
            get { return _SendUser; }
        }

        /// <summary>
        /// �H�e�ɶ�
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
