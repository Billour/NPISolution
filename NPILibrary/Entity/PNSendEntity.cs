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
    /// �T�{��Ƨ�s
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
        /// �������U�C����ƥ����n�ഫ
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
        /// ����Ƹ�
        /// </summary>
        public string PN
        {
            set { _PN = value; }
            get { return _PN; }
        }

        /// <summary>
        /// �~��
        /// </summary>
        public string YearQ
        {
            set { _YearQ = value; }
            get { return _YearQ; }
        }

             

        /// <summary>
        /// �O�_�w�g�e��eQuatation
        /// </summary>
        [UpdateColumn("NPI_PNPRICE", "IS_SEND", Asus.Data.DataType.NVarChar)]
        public string IsSend
        {
            set { _IsSend = value; }
            get { return _IsSend; }
        }

       /// <summary>
       /// Site�O
       /// </summary>
         public string Site
        {
            set { _Site = value; }
            get { return _Site; }
        }

        /// <summary>
        /// �e��eQuatattion�H��
        /// </summary>
        [UpdateColumn("NPI_PNPRICE", "SEND_USER", Asus.Data.DataType.NVarChar)]
        public string SendUser
        {
            set { _SendUser = value; }
            get { return _SendUser; }
        }

        /// <summary>
        /// �H�e�ɶ�
        /// </summary>
        [UpdateColumn("NPI_PNPRICE", "SEND_TIME", Asus.Data.DataType.DateTime)]
        public string SendTime
        {
            set { _SendTime = value; }
            get { return _SendTime; }
        }


    }
}
