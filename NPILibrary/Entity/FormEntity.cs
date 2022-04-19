using System;
using System.Collections.Generic;
using System.Text;

using Asus;
using Asus.Bussiness.Attribute;
using Asus.Bussiness.Map;
using System.Web.UI.WebControls;
using AsusLibrary.Logic;

using AsusLibrary.Utility;
using AsusLibrary;

namespace AsusLibrary.Entity
{
    /// <summary>
    /// 產生Form 
    /// </summary>
    public class FormEntity:BaseEntity
    {

        /// <summary>
        /// 資料表
        /// NPI_FORM_MAIN
        /// </summary>
        public const string TABLE_NPI_FORM_MAIN = "NPI_FORM_MAIN";

        private string _FormId;
        private string _FormName = "";
        private string _FormDate;
        private string _FormStatus = "N";
        private string _FormStatusName = "";

        private string _PMId = "";
        private string _PMName = "";
        private string _PMCompanyId = "";

        private string _CreateUser = "";
        private string _CreateTime = "";

        private List<FormBomEntity> _BomList;
        private SortedList<string, FormPMUserEntity> _PMFormList;
        private SortedList<string, FormPNEntity> _PNList;
        private SortedList<string, FormPNBomEntity> _BOMPNList;

        /// <summary>
        /// 加入新的功能，計算計價
        /// </summary>
        private SortedList<string, PNPriceEntity> _PNPriceList;


        /// <summary>
        /// Form Main Entity
        /// </summary>
        [Tables(FormEntity.TABLE_NPI_FORM_MAIN, PageCommandType.InsertColumnMode, DBCommandType.InsertMode, "", null)]
        public FormEntity()
        { }

        /// <summary>
        /// Form代號
        /// </summary>
        [DataColumn("FORM_ID")]
        [QueryColumn("", "回覆代碼", "Y", ViewRowType.LinkButton, "N", 10)]
        [QueryColumn2("", "回覆代碼", "Y", ViewRowType.LinkButton, "N", 10)]
        [InsertColumn(FormEntity.TABLE_NPI_FORM_MAIN, "FORM_ID", Asus.Data.DataType.NVarChar)]
        public string FormId
        {
            set { _FormId = value; }
            get { return _FormId; }
        }

        [QueryColumn2("", "PM Names", "Y", ViewRowType.BoundField, "N", 15)]
        public string FormName
        {
            set { _FormName = value; }
            get { return _FormName; }
        }

        [DataColumn("pm_user_id")]
        public string PMId
        {
            set { _PMId = value; }
            get { return _PMId; }
        }

        [DataColumn("pm_company_id")]
        public string PMCompanyId
        {
            set { _PMCompanyId = value; }
            get { return _PMCompanyId; }
        }

        [QueryColumn("", "PM", "Y", ViewRowType.BoundField, "N", 15)]
        //[QueryColumn2("", "PM", "Y", ViewRowType.BoundField, "N", 15)]
        public string PMName
        {
            set { _PMName = value; }
            get
            {
                string userName = "";



                if (PMId != "" && PMCompanyId != "")
                {
                    UserLogic logic = new UserLogic();

                    UserEntity o = logic.QueryPMInfo(PMId, PMCompanyId);

                    if (o != null)
                    {
                        userName = o.AccountName;
                    }
                }



                return userName;
            }
        }

        /// <summary>
        /// Form 展開的時間
        /// </summary>
        [DataColumn("FORM_DATE")]
        [QueryColumn("", "產生日期", "Y", ViewRowType.BoundField, "N", 20)]
        [QueryColumn2("", "產生日期", "Y", ViewRowType.BoundField, "N", 20)]
        [InsertColumn(FormEntity.TABLE_NPI_FORM_MAIN, "FORM_DATE", Asus.Data.DataType.DateTime)]
        public string FormDate
        {
            set { _FormDate = value; }
            get { return _FormDate; }
        }

        

        [DataColumn("FORM_STATUS")]
        public string FormStatus
        {
            set { _FormStatus = value; }
            get { return _FormStatus; }
        }

        [QueryColumn("", "狀態", "Y", ViewRowType.BoundField, "N", 30)]
        [QueryColumn2("", "狀態", "Y", ViewRowType.BoundField, "N", 30)]
        public string FormStatusName
        {
            set { _FormStatusName = value; }
            get
            {
                if (_FormStatus != "")
                {
                    _FormStatusName = EnumMapHelper.GetStringFromEnum(EnumUtil.StringToEnum<EnumFormstatus>(_FormStatus));
                }


                return _FormStatusName;
            }
        }

        /// <summary>
        /// 建立人員
        /// </summary>
        [DataColumn("CREATE_USER")]
        [InsertColumn(FormEntity.TABLE_NPI_FORM_MAIN, "CREATE_USER", Asus.Data.DataType.NVarChar)]
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }

        /// <summary>
        /// 建立時間
        /// </summary>
        [DataColumn("CREATE_DATE")]
        [InsertColumn(FormEntity.TABLE_NPI_FORM_MAIN, "CREATE_DATE", Asus.Data.DataType.DateTime)]
        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }

        /// <summary>
        /// 這一次 PM和Form的關係
        /// 為多筆關係
        /// </summary>
        public SortedList<string, FormPMUserEntity> PMFormList
        {
            set { _PMFormList = value; }
            get { return _PMFormList; }
        }

        /// <summary>
        /// Form 與 PN
        /// </summary>
        public SortedList<string, FormPNEntity> PNList
        {
            set { _PNList = value; }
            get { return _PNList; }
        }

        /// <summary>
        /// BOM 與PN之關係
        /// </summary>
        public SortedList<string, FormPNBomEntity> BOMPNList
        {
            set { _BOMPNList = value; }
            get { return _BOMPNList; }
        }

        /// <summary>
        /// 取得需要回覆的BOM
        /// </summary>
        public List<FormBomEntity> BomList
        {
            set { _BomList = value; }
            get { return _BomList; }
        }

        /// <summary>
        /// PN Price List
        /// 這一個物件是用來議價檔Table NPI_PNPrice
        /// </summary>
        public SortedList<string, PNPriceEntity> PNPriceList
        {
            set { _PNPriceList = value; }
            get { return _PNPriceList; }
        }

      

       


      

    }
}
