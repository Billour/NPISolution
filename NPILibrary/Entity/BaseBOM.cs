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
    public class BaseBOM:BaseEntity
    {
        /// <summary>
        /// ��Ʈw��ƪ�NPI_BOM
        /// </summary>
        public const string TABLE_NPI_BOM = "NPI_BOM";
        
        /// <summary>
        /// ��Ʈw��ƪ� NPI_BOOKING
        /// </summary>
        public const string TABLE_NPI_BOOKING = "NPI_BOOKING";

        private bool _IsSelected = true;

        private string _EmpId;
        private string _EmpName;
        private string _CompanyId;

        private string _BOMId="";
        private string _BOMName="";
        private string _BOMDesc="";
        private string _BOMStatus="";

        private string _Revision="";
        private string _RDOwner = "";
        private string _RDAccount="";
        private string _RDName="";
        private string _RDPhoneNo="";

        private string _PVTLocation="";
        private string _PVTLocationName = "";

        private string _PVTTime="";
        private string _PVTQty="";

        private string _MPTime=DateTime.Now.AddYears(1).ToString("yyyy/MM/dd");
        private string _MPQ1Qty="-1";
        private string _MPQ2Qty="-1";

        //�]�wResponse Time
        private string _IsOpen="Y";

        private string _CreateUser;
        private string _CreateTime;
        private string _UpdateUser;
        private string _UpdateTime;

        [QueryColumn3("", "���", "Y", ViewRowType.CheckBox, "N", 10)]
        public bool IsSelected
        {
            set { _IsSelected = value; }
            get { return _IsSelected; }
        }

        /// <summary>
        /// PM���u�b��
        /// </summary>
        [DataColumn("USER_ID")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "USER_ID", Asus.Data.DataType.NVarChar)]
        [InsertColumn(BaseBOM.TABLE_NPI_BOOKING, "USER_ID", Asus.Data.DataType.NVarChar)]
        //[QueryColumn("", "PM���u�b��", "Y", ViewRowType.BoundField, "N", 10)]
        //[QueryColumn2("", "PM���u�b��", "Y", ViewRowType.BoundField, "N", 10)]
        public string EmpId
        {
            set { _EmpId = value; }
            get { return _EmpId; }
        }

        [DataColumn("USER_Name")]
        //[QueryColumn("", "PM���u�b��", "Y", ViewRowType.BoundField, "N", 12)]
        //[QueryColumn2("", "PM���u�b��", "Y", ViewRowType.BoundField, "N", 12)]
        public string EmpName
        {
            set { _EmpName = value; }
            get { return _EmpName; }
        }

        /// <summary>
        /// ���^���W
        /// </summary>
        [QueryColumn("", "PM���u�b��", "Y", ViewRowType.BoundField, "N", 10)]
        [QueryColumn2("", "PM���u�b��", "Y", ViewRowType.BoundField, "N", 10)]
        [QueryColumn3("", "PM���u�b��", "Y", ViewRowType.BoundField, "N", 12)]
        public string EmpFullName
        {
            get { return String.Format("{0}({1})", _EmpId, _EmpName); }
        }

        /// <summary>
        /// ���q�N��
        /// </summary>
        [DataColumn("COMPANY_ID")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "COMPANY_ID", Asus.Data.DataType.NVarChar)]
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
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "BOM_ID", Asus.Data.DataType.NVarChar)]
        [InsertColumn(BaseBOM.TABLE_NPI_BOOKING, "BOM_ID", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "BOM ����", "Y", ViewRowType.LinkButton, "N", 15)]
        [QueryColumn2("", "BOM ����", "Y", ViewRowType.BoundField, "N", 15)]
        [QueryColumn3("", "BOM ����", "Y", ViewRowType.BoundField, "N", 15)]
        [Create("Y", "*", "BOM�N��", new EnumUIControl[] { EnumUIControl.TextBox,EnumUIControl.Label }, 10)]
        [Visible(EnumUIControl.TextBox, PageMode.CreateMode)]
        [Visible(EnumUIControl.Label, PageMode.ModifyMode)]
        public string BOMId
        {
            set { _BOMId = value; }
            get { return _BOMId.Trim(); }
        }

        /// <summary>
        /// BOM �m�W
        /// </summary>
        [DataColumn("BOM_NAME")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "BOM_NAME", Asus.Data.DataType.NVarChar)]
        [UpdateColumn(BaseBOM.TABLE_NPI_BOM, "BOM_NAME", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "�Ƹ�", "Y", ViewRowType.BoundField, "N", 20)]
        [QueryColumn2("", "�Ƹ�", "Y", ViewRowType.BoundField, "N", 20)]
        [QueryColumn3("", "�Ƹ�", "Y", ViewRowType.BoundField, "N", 20)]
        [Create("Y", "", "�Ƹ�", new EnumUIControl[] { EnumUIControl.Label }, 20)]
        [Visible(EnumUIControl.Label, PageMode.ModifyMode)]
        public string BOMName
        {
            set { _BOMName = value; }
            get { return _BOMName; }
        }

        /// <summary>
        /// BOM ���A
        /// </summary>
        [DataColumn("BOM_STATUS")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "BOM_STATUS", Asus.Data.DataType.NVarChar)]
        [UpdateColumn(BaseBOM.TABLE_NPI_BOM, "BOM_STATUS", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "BOM Status", "Y", ViewRowType.BoundField, "N", 30)]
        [QueryColumn2("", "BOM Status", "Y", ViewRowType.BoundField, "N", 30)]
        [Create("Y", "*", "BOM Status", new EnumUIControl[] { EnumUIControl.TextBox }, 30)]
        [Visible(EnumUIControl.TextBox, PageMode.ModifyMode + PageMode.CreateMode)]
        public string BOMStatus
        {
            set { _BOMStatus = value; }
            get { return _BOMStatus; }
        }


        /// <summary>
        /// BOM ����
        /// </summary>
        [DataColumn("BOM_DESC")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "BOM_DESC", Asus.Data.DataType.NVarChar)]
        [UpdateColumn(BaseBOM.TABLE_NPI_BOM, "BOM_DESC", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "Description", "Y", ViewRowType.BoundField, "N", 40)]
        [QueryColumn2("", "Description", "Y", ViewRowType.BoundField, "N", 40)]
        [QueryColumn3("", "Description", "Y", ViewRowType.BoundField, "N", 40)]
        [Create("Y", "", "Description", new EnumUIControl[] { EnumUIControl.TextBox }, 40)]
        [Visible(EnumUIControl.TextBox, PageMode.ModifyMode + PageMode.CreateMode)]
        public string BOMDesc
        {
            set { _BOMDesc = value; }
            get { return _BOMDesc; }
        }



        /// <summary>
        /// ����
        /// </summary>
        [DataColumn("BOM_REVISION")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "BOM_REVISION", Asus.Data.DataType.NVarChar)]
        [UpdateColumn(BaseBOM.TABLE_NPI_BOM, "BOM_REVISION", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "Revision", "Y", ViewRowType.BoundField, "N", 50)]
        [QueryColumn2("", "Revision", "Y", ViewRowType.BoundField, "N", 50)]
        [Create("Y", "*", "Revision", new EnumUIControl[] { EnumUIControl.TextBox }, 50)]
        [Visible(EnumUIControl.TextBox, PageMode.ModifyMode + PageMode.CreateMode)]
        public string Revision
        {
            set { _Revision = value; }
            get { return _Revision; }
        }


        /// <summary>
        /// RD Owner
        /// RDAccount+RDName + RDPhoneNo
        /// </summary>
        [QueryColumn("", "RD Name�]�����^", "Y", ViewRowType.BoundField, "N", 60)]
        [QueryColumn2("", "RD Name�]�����^", "Y", ViewRowType.BoundField, "N", 60)]
        [Create("Y", "*", "RD Name�]�����^", new EnumUIControl[] { EnumUIControl.Label }, 60)]
        [Visible(EnumUIControl.Label, PageMode.Query)]
        public string RDOwner
        {
            set { _RDOwner = value; }
            get { return _RDAccount+_RDName + _RDPhoneNo; }
        }

         /// <summary>
         /// RD �b��
         /// </summary>
        [DataColumn("RD_EMP_ID")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "RD_EMP_ID", Asus.Data.DataType.NVarChar)]
        //[Create("Y", "*", "RD �b��", new EnumUIControl[] { EnumUIControl.TextBox}, 61)]
        //[Visible(EnumUIControl.TextBox, PageMode.CreateMode+PageMode.ModifyMode)]
        public string RDAccount
        {
            set { _RDAccount = value; }
            get { return _RDAccount; }
        }

        /// <summary>
        /// RD �m�W
        /// </summary>
        [DataColumn("RD_EMP_NAME")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "RD_EMP_NAME", Asus.Data.DataType.NVarChar)]
        [UpdateColumn(BaseBOM.TABLE_NPI_BOM, "RD_EMP_NAME", Asus.Data.DataType.NVarChar)]
        [Create("Y", "*", "RD �m�W", new EnumUIControl[] {EnumUIControl.TextBox }, 62)]
        [Visible(EnumUIControl.TextBox, PageMode.CreateMode + PageMode.ModifyMode)]
        public string RDName
        {
            set { _RDName = value; }
            get { return _RDName; }
        }

        /// <summary>
        /// ����
        /// </summary>
        [DataColumn("RD_EMP_PHONENO")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "RD_EMP_PHONENO", Asus.Data.DataType.NVarChar)]
        [UpdateColumn(BaseBOM.TABLE_NPI_BOM, "RD_EMP_PHONENO", Asus.Data.DataType.NVarChar)]
        [Create("Y", "*", "����", new EnumUIControl[] {EnumUIControl.TextBox }, 63)]
        [Visible(EnumUIControl.TextBox, PageMode.CreateMode + PageMode.ModifyMode)]
        public string RDPhoneNo
        {
            set { _RDPhoneNo = value; }
            get { return _RDPhoneNo; }
        }

        /// <summary>
        /// �Ͳ��ɶ�
        /// </summary>
        [DataColumn("PVT_TIME")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "PVT_TIME", Asus.Data.DataType.DateTime)]
        [UpdateColumn(BaseBOM.TABLE_NPI_BOM, "PVT_TIME", Asus.Data.DataType.DateTime)]
        [Create("Y", "*", "PVT Time", new EnumUIControl[] { EnumUIControl.Calendar }, 70)]
        [Visible(EnumUIControl.Calendar, PageMode.ModifyMode + PageMode.CreateMode)]
        [ControlProperty(EnumUIControl.Calendar, "ImageButtonSkinID", "ImageCalndarSkin")]
        [Remark(PageMode.ModifyMode + PageMode.CreateMode,"yyyy/MM/dd", EnumPosition.Right)]
        public string PVTTime
        {
            set { _PVTTime = value; }
            get {

               

                return _PVTTime;
                
            }
        }

        [QueryColumn("", "PVT Time", "Y", ViewRowType.BoundField, "N", 70)]
        [QueryColumn2("", "PVT Time", "Y", ViewRowType.BoundField, "N", 70)]
        public string PVTTime2
        {
            get
            {

                DateTime dt;

                bool isOK = DateTime.TryParse(_PVTTime, out dt);

                if (isOK)
                {
                    return dt.ToString("yyyy/MM/dd");
                }

                return null;

            }
        }

        /// <summary>
        /// �Ͳ��ƶq
        /// </summary>
        [DataColumn("PVT_QTY")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "PVT_QTY", Asus.Data.DataType.Int)]
        [UpdateColumn(BaseBOM.TABLE_NPI_BOM, "PVT_QTY", Asus.Data.DataType.Int)]
        [QueryColumn("", "PVT �ƶq", "Y", ViewRowType.BoundField, "N", 80)]
        [QueryColumn2("", "PVT �ƶq", "Y", ViewRowType.BoundField, "N", 80)]
        [Create("Y", "*", "PVT �ƶq", new EnumUIControl[] { EnumUIControl.TextBox }, 80)]
        [Visible(EnumUIControl.TextBox, PageMode.ModifyMode + PageMode.CreateMode)]
        [Remark(PageMode.ModifyMode + PageMode.CreateMode,"(pcs)�Ʀr", EnumPosition.Right)]
        public string PVTQty
        {
            set { _PVTQty = value; }
            get { return _PVTQty; }
        }

        /// <summary>
        /// �Ͳ��a�I
        /// </summary>
        [DataColumn("PVT_LOCATION")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "PVT_LOCATION", Asus.Data.DataType.NVarChar)]
        [UpdateColumn(BaseBOM.TABLE_NPI_BOM, "PVT_LOCATION", Asus.Data.DataType.NVarChar)]
        [Create("Y", "*", "PVT ���a", new EnumUIControl[] { EnumUIControl.RadioButtonList }, 90)]
        [Visible(EnumUIControl.RadioButtonList, PageMode.ModifyMode + PageMode.CreateMode,"",true)]
        [ControlProperty(EnumUIControl.RadioButtonList, "RepeatDirection", RepeatDirection.Horizontal)]
        [ControlProperty(EnumUIControl.RadioButtonList, "RepeatColumns", 2)]
        [SubListClass(typeof(AsusBomLogic), "GetEMSDataTable",null,"EMS_CODE","EMS_NAME")]
        public string PVTLocation
        {
            set { _PVTLocation = value; }
            get { return _PVTLocation; }
        }


        /// <summary>
        /// �Ͳ��a�I�W��
        /// </summary>
        [DataColumn("PVT_LOCATION_NAME")]
        [QueryColumn("", "PVT ���a", "Y", ViewRowType.BoundField, "N", 90)]
        [QueryColumn2("", "PVT ���a", "Y", ViewRowType.BoundField, "N", 90)]
        public string PVTLocationName
        {
            set { _PVTLocationName = value; }
            get { return _PVTLocationName; }
        }

        /// <summary>
        /// �j�q�Ͳ��ɶ�
        /// </summary>
        [DataColumn("MP_TIME")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "MP_TIME", Asus.Data.DataType.DateTime)]
        [UpdateColumn(BaseBOM.TABLE_NPI_BOM, "MP_TIME", Asus.Data.DataType.DateTime)]
        [QueryColumn("", "MP Time", "Y", ViewRowType.BoundField, "N", 92)]
        [QueryColumn2("", "MP Time", "Y", ViewRowType.BoundField, "N", 92)]
        [Create("Y", "", "MP Time", new EnumUIControl[] { EnumUIControl.Calendar }, 92)]
        [Visible(EnumUIControl.Calendar, PageMode.ModifyMode + PageMode.CreateMode)]
        [ControlProperty(EnumUIControl.Calendar, "ImageButtonSkinID", "ImageCalndarSkin")]
        [Remark(PageMode.ModifyMode + PageMode.CreateMode, "yyyy/MM/dd(�p�L�k�T�{�A�O�d��l��)", EnumPosition.Right)]
        public string MPTime
        {
            set { _MPTime = value; }
            get { return Convert.ToDateTime(_MPTime).ToString("yyyy/MM/dd"); }
        }

        /// <summary>
        /// Q1 �ƶq
        /// </summary>
        [DataColumn("MP_Q1_QTY")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "MP_Q1_QTY", Asus.Data.DataType.Int)]
        [UpdateColumn(BaseBOM.TABLE_NPI_BOM, "MP_Q1_QTY", Asus.Data.DataType.Int)]
        [QueryColumn("", "MP Q1 Qty", "Y", ViewRowType.BoundField, "N", 94)]
        [QueryColumn2("", "MP Q1 Qty", "Y", ViewRowType.BoundField, "N", 94)]
        [Create("Y", "", "MP Q1 Qty", new EnumUIControl[] { EnumUIControl.TextBox }, 94)]
        [Visible(EnumUIControl.TextBox, PageMode.ModifyMode + PageMode.CreateMode)]
        [Remark(PageMode.ModifyMode + PageMode.CreateMode, "(pcs)�Ʀr(�p�L�k�T�{�A�ƶq�]�w��-1)", EnumPosition.Right)]
        public string MPQ1Qty
        {
            set { _MPQ1Qty = value; }
            get { return _MPQ1Qty; }
        }

        /// <summary>
        /// Q2 �ƶq
        /// </summary>
        [DataColumn("MP_Q2_QTY")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "MP_Q2_QTY", Asus.Data.DataType.Int)]
        [UpdateColumn(BaseBOM.TABLE_NPI_BOM, "MP_Q2_QTY", Asus.Data.DataType.Int)]
        [QueryColumn("", "MP Q2 Qty", "Y", ViewRowType.BoundField, "N", 96)]
        [QueryColumn2("", "MP Q2 Qty", "Y", ViewRowType.BoundField, "N", 96)]
        [Create("Y", "", "MP Q2 Qty", new EnumUIControl[] { EnumUIControl.TextBox }, 96)]
        [Visible(EnumUIControl.TextBox, PageMode.ModifyMode + PageMode.CreateMode)]
        [Remark(PageMode.ModifyMode + PageMode.CreateMode, "(pcs)�Ʀr(�p�L�k�T�{�A�ƶq�]�w��-1)", EnumPosition.Right)]
        public string MPQ2Qty
        {
            set { _MPQ2Qty = value; }
            get { return _MPQ2Qty; }
        }

        /// <summary>
        /// BOM �O�_�ҥ�
        /// </summary>
        [DataColumn("IS_ENABLE")]
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "IS_ENABLE", Asus.Data.DataType.NVarChar)]
        [UpdateColumn(BaseBOM.TABLE_NPI_BOM, "IS_ENABLE", Asus.Data.DataType.NVarChar)]
        [QueryColumn("", "�O�_�ҥ�", "Y", ViewRowType.BoundField, "N", 120)]
        [QueryColumn2("", "�O�_�ҥ�", "Y", ViewRowType.BoundField, "N", 120)]
        [Create("Y", "", "�O�_�ҥΡG", new EnumUIControl[] { EnumUIControl.RadioButtonList }, 120)]
        [Visible(EnumUIControl.RadioButtonList, PageMode.CreateMode + PageMode.ModifyMode, "", true)]
        [SubListClass(typeof(UserLogic), "GetYesOrNoList", null, "Key", "Value")]
        [ControlProperty(EnumUIControl.RadioButtonList, "RepeatDirection", RepeatDirection.Horizontal)]
        public string IsOpen
        {
            set { _IsOpen = value; }
            get { return _IsOpen; }
        }

        /// <summary>
        /// �إߤH��
        /// </summary>
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "CREATE_USER", Asus.Data.DataType.NVarChar)]
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }

        /// <summary>
        /// �إ߮ɶ�
        /// </summary>
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "CREATE_DATE", Asus.Data.DataType.DateTime)]
        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }

        /// <summary>
        /// ��s�H��
        /// </summary>
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        [UpdateColumn(BaseBOM.TABLE_NPI_BOM, "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        public string UpdateUser
        {
            set { _UpdateUser = value; }
            get { return _UpdateUser; }
        }

        /// <summary>
        /// ��s�ɶ�
        /// </summary>
        [InsertColumn(BaseBOM.TABLE_NPI_BOM, "UPDATE_DATE", Asus.Data.DataType.DateTime)]
        [UpdateColumn(BaseBOM.TABLE_NPI_BOM, "UPDATE_DATE", Asus.Data.DataType.DateTime)]
        public string UpdateTime
        {
            set { _UpdateTime = value; }
            get { return _UpdateTime; }
        }
    }
}
