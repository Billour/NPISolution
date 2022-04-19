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
    public class BOMBookingEntity2
    {
        //�]�wBOOKING STATUS

        private string _EmpId;
        private string _CompanyId;

        private string _BOMId = "";
        private string _FormNo="AA";
        private string _WorkStatus="";
        private string _WorkStatusName="";

        private string _BookDate;
        private string _BookingCreateUser ;
        private string _BookingCreateTime = DateTime.Now.ToString();
        private string _BookingUpdateUser ;
        private string _BookingUpdateTime =DateTime.Now.ToString();

        
        [Tables(BOMBookingEntity.TABLE_NPI_BOOKING, PageCommandType.InsertColumnMode, DBCommandType.InsertMode, "", null)]
        public BOMBookingEntity2()
        { }

        public BOMBookingEntity2(BOMBookingEntity obj)
        {
            _EmpId = obj.EmpId;

            _CompanyId = obj.CompanyId;

            _BOMId = obj.BOMId;

            _FormNo = obj.FormNo;

            _WorkStatus = obj.WorkStatus;

            _BookDate = obj.BookDate;

            _BookingCreateUser = obj.BookingCreateUser;

            _BookingCreateTime = obj.BookingCreateTime;

            _BookingUpdateUser = obj.BookingUpdateUser;

            _BookingUpdateTime = obj.BookingUpdateTime;

        }

        /// <summary>
        /// PM���u�b��
        /// </summary>
        [DataColumn("USER_ID")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOOKING, "USER_ID", Asus.Data.DataType.NVarChar)]
        public string EmpId
        {
            set { _EmpId = value; }
            get { return _EmpId; }
        }

        /// <summary>
        /// ���q�N��
        /// </summary>
        [DataColumn("COMPANY_ID")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOOKING, "COMPANY_ID", Asus.Data.DataType.NVarChar)]
        public string CompanyId
        {
            set { _CompanyId = value; }
            get { return _CompanyId; }
        }

        /// <summary>
        /// BOM ����
        /// </summary>
        [DataColumn("BOM_ID")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOOKING, "BOM_ID", Asus.Data.DataType.NVarChar)]
        public string BOMId
        {
            set { _BOMId = value; }
            get { return _BOMId.Trim(); }
        }


        /// <summary>
        /// ���o�iBOM�N���A�ΨӨM�w�N�ӨϥΪ�BOM���X
        /// </summary>
        [DataColumn("FORM_ID")]
        [InsertColumn(BOMBookingEntity.TABLE_NPI_BOOKING, "FORM_ID", Asus.Data.DataType.NVarChar)]
        public string FormNo
        {
            set { _FormNo = value; }
            get { return _FormNo; }
        }

        /// <summary>
        /// �ثe���A
        /// ����
        /// 10-���ݮiBOM
        /// 20-�iBOM����
        /// </summary>
        [DataColumn("WORK_STATUS")]
        [InsertColumn(BOMBookingEntity.TABLE_NPI_BOOKING, "WORK_STATUS", Asus.Data.DataType.Int)]
        public string WorkStatus
        {
            set { _WorkStatus = value; }
            get { return _WorkStatus; }
        }

        

        /// <summary>
        /// Booking �ɶ��A
        /// �Ω�s�W��Ʈɭ�
        /// </summary>
        [DataColumn("BOOKING_DATE")]
        [InsertColumn(BOMBookingEntity.TABLE_NPI_BOOKING, "BOOKING_DATE", Asus.Data.DataType.DateTime)]
        public string BookDate
        {
            set { _BookDate = value; }
            get { return _BookDate; }
        }

        /// <summary>
        /// Booking �إߤH��
        /// </summary>
        [InsertColumn(BOMBookingEntity.TABLE_NPI_BOOKING, "CREATE_USER", Asus.Data.DataType.NVarChar)]
        public string BookingCreateUser
        {
            set { _BookingCreateUser = value; }
            get { return _BookingCreateUser; }
        }

        /// <summary>
        /// Booking �إ߮ɶ�
        /// </summary>
        [InsertColumn(BOMBookingEntity.TABLE_NPI_BOOKING, "CREATE_DATE", Asus.Data.DataType.DateTime)]
        public string BookingCreateTime
        {
            set { _BookingCreateTime = value; }
            get { return _BookingCreateTime; }
        }

        /// <summary>
        /// Booking ��s�H��
        /// </summary>
        [InsertColumn(BOMBookingEntity.TABLE_NPI_BOOKING, "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        [UpdateColumn(BOMBookingEntity.TABLE_NPI_BOOKING, "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        public string BookingUpdateUser
        {
            set { _BookingUpdateUser = value; }
            get { return _BookingUpdateUser; }
        }

        /// <summary>
        /// Booking ��s�H��
        /// </summary>
        [InsertColumn(BOMBookingEntity.TABLE_NPI_BOOKING, "UPDATE_DATE", Asus.Data.DataType.DateTime)]
        [UpdateColumn(BOMBookingEntity.TABLE_NPI_BOOKING, "UPDATE_DATE", Asus.Data.DataType.DateTime)]
        public string BookingUpdateTime
        {
            set { _BookingUpdateTime = value; }
            get { return _BookingUpdateTime; }
        }
    }
}
