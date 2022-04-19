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
        /// PM���u�b��
        /// </summary>
        public string EmpId
        {
            set { _EmpId = value; }
            get { return _EmpId; }
        }

        /// <summary>
        /// ���q�N��
        /// </summary>
         public string CompanyId
        {
            set { _CompanyId = value; }
            get { return _CompanyId; }
        }

        /// <summary>
        /// BOM ����
        /// </summary>
        public string BOMId
        {
            set { _BOMId = value; }
            get { return _BOMId; }
        }

        /// <summary>
        /// ���o�iBOM�N���A�ΨӨM�w�N�ӨϥΪ�BOM���X
        /// </summary>
        [UpdateColumn(FormBomEntity.TABLE_NPI_BOOKING, "FORM_ID", Asus.Data.DataType.NVarChar)]
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
        [UpdateColumn(FormBomEntity.TABLE_NPI_BOOKING, "WORK_STATUS", Asus.Data.DataType.Int)]
        public string WorkStatus
        {
            set { _WorkStatus = value; }
            get { return _WorkStatus; }
        }


        /// <summary>
        /// Booking ��s�H��
        /// </summary>
        [UpdateColumn(FormBomEntity.TABLE_NPI_BOOKING, "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        public string BookingUpdateUser
        {
            set { _BookingUpdateUser = value; }
            get { return _BookingUpdateUser; }
        }

        /// <summary>
        /// Booking ��s�H��
        /// </summary>
        [UpdateColumn(FormBomEntity.TABLE_NPI_BOOKING, "UPDATE_DATE", Asus.Data.DataType.DateTime)]
        public string BookingUpdateTime
        {
            set { _BookingUpdateTime = value; }
            get { return _BookingUpdateTime; }
        }

    }
}
