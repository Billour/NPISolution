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
    /// Booking Entity 
    /// </summary>
    public class BOMBookingEntity:BaseBOM
    {
        //�]�wBOOKING STATUS

        private string _FormNo="AA";
        private string _WorkStatus="";
        private string _WorkStatusName="";

        private string _BookDate;
        private string _BookingCreateUser ;
        private string _BookingCreateTime = DateTime.Now.ToString();
        private string _BookingUpdateUser ;
        private string _BookingUpdateTime =DateTime.Now.ToString();

        [Tables(BOMBookingEntity.TABLE_NPI_BOM, PageCommandType.InsertColumnMode, DBCommandType.InsertMode, "", null)]
        [Tables(BOMBookingEntity.TABLE_NPI_BOOKING, PageCommandType.InsertColumnMode, DBCommandType.InsertMode, "", null)]
        [Tables(BOMBookingEntity.TABLE_NPI_BOM, PageCommandType.UpdateColumnMode, DBCommandType.UpdateMode, " where user_id='{0}' and bom_id='{1}' and company_id='{2}'", new string[] { "EmpId", "BOMId", "CompanyId" })]
        public BOMBookingEntity()
        { }

        /// <summary>
        /// ���o�iBOM�N���A�ΨӨM�w�N�ӨϥΪ�BOM���X
        /// </summary>
        [DataColumn("FORM_ID")]
        [InsertColumn(BOMBookingEntity.TABLE_NPI_BOOKING, "FORM_ID", Asus.Data.DataType.NVarChar)]
        [Create("Y", "", "�iBOM�N���G", new EnumUIControl[] { EnumUIControl.Label}, 300)]
        [Visible(EnumUIControl.Label, PageMode.ModifyMode)]
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

        [Create("Y", "", "�i�}���A�G", new EnumUIControl[] { EnumUIControl.Label }, 310)]
        [Visible(EnumUIControl.Label, PageMode.ModifyMode)]
        public string WorkStatusName
        {
            set { _WorkStatusName = value; }
            get {
                    
                
                    if (_WorkStatus != "")
                    { 
                        _WorkStatusName=EnumMapHelper.GetStringFromEnum((EnumWorkStatus)(Convert.ToInt16(_WorkStatus)));
                    }

                    return _WorkStatusName;
                }
        }

        /// <summary>
        /// Booking �ɶ��A
        /// �Ω�s�W��Ʈɭ�
        /// </summary>
        [DataColumn("BOOKING_DATE")]
        [InsertColumn(BOMBookingEntity.TABLE_NPI_BOOKING, "BOOKING_DATE", Asus.Data.DataType.DateTime)]
        [Create("Y", "", "Booking�ɶ��G", new EnumUIControl[] { EnumUIControl.Label }, 320)]
        [Visible(EnumUIControl.Label, PageMode.ModifyMode)]
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
