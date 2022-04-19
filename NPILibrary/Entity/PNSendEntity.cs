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
    /// 確認資料更新
    /// </summary>
    public class PNSendEntity:BaseEntity
    {
        private string _PN;
        private string _YearQ;
        private string _Site;

        private string _IsSend="Y";

                   

        private string _SendUser="System";
        private string _SendTime=DateTime.Now.ToString();

        
        [Tables("NPI_PNPRICE", PageCommandType.UpdateColumnMode, DBCommandType.UpdateMode, " where pn='{0}' and yearq='{1}' and location_site='{2}'", new string[] { "PN", "YearQ", "Site"})]
        public PNSendEntity()
        { }

        /// <summary>
        /// 必須有下列欄位資料必須要轉換
        /// PN
        /// YearQ
        /// IsSend
        /// BuyingMode
        /// SendUser
        /// SendTime
        /// </summary>
        /// <param name="obj"></param>
        public PNSendEntity(PNPriceEntity obj)
        {
            _PN = obj.PN;
            _YearQ = obj.YearQ;
            _Site = obj.Site;
           
        }

        /// <summary>
        /// 元件料號
        /// </summary>
        public string PN
        {
            set { _PN = value; }
            get { return _PN; }
        }

        /// <summary>
        /// 年度
        /// </summary>
        public string YearQ
        {
            set { _YearQ = value; }
            get { return _YearQ; }
        }

             

        /// <summary>
        /// 是否已經送至eQuatation
        /// </summary>
        [UpdateColumn("NPI_PNPRICE", "IS_SEND", Asus.Data.DataType.NVarChar)]
        public string IsSend
        {
            set { _IsSend = value; }
            get { return _IsSend; }
        }

       /// <summary>
       /// Site別
       /// </summary>
         public string Site
        {
            set { _Site = value; }
            get { return _Site; }
        }

        /// <summary>
        /// 送至eQuatattion人員
        /// </summary>
        [UpdateColumn("NPI_PNPRICE", "SEND_USER", Asus.Data.DataType.NVarChar)]
        public string SendUser
        {
            set { _SendUser = value; }
            get { return _SendUser; }
        }

        /// <summary>
        /// 寄送時間
        /// </summary>
        [UpdateColumn("NPI_PNPRICE", "SEND_TIME", Asus.Data.DataType.DateTime)]
        public string SendTime
        {
            set { _SendTime = value; }
            get { return _SendTime; }
        }


    }
}
