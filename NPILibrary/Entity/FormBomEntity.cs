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
    public class FormBomEntity:BaseEntity
    {
        public const string TABLE_NPI_BOOKING = "NPI_BOOKING";

        private string _EmpId;
        private string _CompanyId;

        private string _BOMId = "";
        private string _FormNo = "";
        private string _WorkStatus = "";

        private string _BookingUpdateUser;
        private string _BookingUpdateTime = DateTime.Now.ToString();

        [Tables(FormBomEntity.TABLE_NPI_BOOKING, PageCommandType.UpdateColumnMode, DBCommandType.UpdateMode, " where user_id='{0}' and bom_id='{1}' and company_id='{2}' and FORM_ID='AA'", new string[] { "EmpId", "BOMId", "CompanyId" })]
        public FormBomEntity()
        { }

        /// <summary>
        /// PM員工帳號
        /// </summary>
        public string EmpId
        {
            set { _EmpId = value; }
            get { return _EmpId; }
        }

        /// <summary>
        /// 公司代號
        /// </summary>
         public string CompanyId
        {
            set { _CompanyId = value; }
            get { return _CompanyId; }
        }

        /// <summary>
        /// BOM 型號
        /// </summary>
        public string BOMId
        {
            set { _BOMId = value; }
            get { return _BOMId; }
        }

        /// <summary>
        /// 取得展BOM代號，用來決定將來使用的BOM號碼
        /// </summary>
        [UpdateColumn(FormBomEntity.TABLE_NPI_BOOKING, "FORM_ID", Asus.Data.DataType.NVarChar)]
        public string FormNo
        {
            set { _FormNo = value; }
            get { return _FormNo; }
        }

        /// <summary>
        /// 目前狀態
        /// 分為
        /// 10-等待展BOM
        /// 20-展BOM完畢
        /// </summary>
        [UpdateColumn(FormBomEntity.TABLE_NPI_BOOKING, "WORK_STATUS", Asus.Data.DataType.Int)]
        public string WorkStatus
        {
            set { _WorkStatus = value; }
            get { return _WorkStatus; }
        }


        /// <summary>
        /// Booking 更新人員
        /// </summary>
        [UpdateColumn(FormBomEntity.TABLE_NPI_BOOKING, "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        public string BookingUpdateUser
        {
            set { _BookingUpdateUser = value; }
            get { return _BookingUpdateUser; }
        }

        /// <summary>
        /// Booking 更新人員
        /// </summary>
        [UpdateColumn(FormBomEntity.TABLE_NPI_BOOKING, "UPDATE_DATE", Asus.Data.DataType.DateTime)]
        public string BookingUpdateTime
        {
            set { _BookingUpdateTime = value; }
            get { return _BookingUpdateTime; }
        }

    }
}
