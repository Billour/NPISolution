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
    public class MainPNEntity:BaseEntity
    {
         /// <summary>
        /// 資料表 NPI_FORM_PN
        /// </summary>
        

        private string _MainId;
        private string _PN;
        private string _PNName;
        private string _PNDesc;

        //組件料號 是否為替代料
        private string _AssemblyNo;
        private string _IsSub;

        private string _LTWeeks;
        private string _Alert;
        private bool _IsAlert;

        private string _RiskBuy;
        private bool _IsRiskBuy;

        //建立20個bom號碼 由01-20

        private string _BOMId01 = "";
        private string _BOMId02 = "";
        private string _BOMId03 = "";
        private string _BOMId04 = "";
        private string _BOMId05 = "";
        private string _BOMId06 = "";
        private string _BOMId07 = "";
        private string _BOMId08 = "";
        private string _BOMId09 = "";
        private string _BOMId10 = "";
        private string _BOMId11 = "";
        private string _BOMId12 = "";
        private string _BOMId13 = "";
        private string _BOMId14 = "";
        private string _BOMId15 = "";
        private string _BOMId16 = "";
        private string _BOMId17 = "";
        private string _BOMId18 = "";
        private string _BOMId19 = "";
        private string _BOMId20 = "";
        
        private string _PNProperty="0";
        private string _AddSource="0";
        private string _AddSourceComment;
        private string _EOL;

        private string _Action;

        private string _PNPropertyName = "";
        private string _AddSourceName = "";

        private string _CreateUser = "";
        private string _CreateTime = "";
        private string _UpdateUser = "";
        private string _UpdateTime = "";

        /// <summary>
        /// 最重要的 Model
        /// </summary>
        [Tables("NPI_Main_PN", PageCommandType.InsertColumnMode, DBCommandType.InsertMode, "", null)]
        //[Tables("NPI_Main_PN", PageCommandType.UpdateColumnMode, DBCommandType.UpdateMode, " where main_id='{0}' and asus_pn='{1}'", new string[] { "MainId", "PN" })]
        public MainPNEntity()
        { }

        /// <summary>
        /// Form代號
        /// </summary>
        [DataColumn("Main_ID")]
        [InsertColumn("NPI_Main_PN", "Main_ID", Asus.Data.DataType.NVarChar)]
        public string MainId
        {
            set { _MainId = value; }
            get { return _MainId; }
        }

        /// <summary>
        /// 元件料號
        /// </summary>
        [DataColumn("ASUS_PN")]
        [QueryColumn("", "元件料號", "Y", ViewRowType.BoundField, "N", 10)]
        [QueryColumn2("", "元件料號", "Y", ViewRowType.BoundField, "N", 10)]
        [InsertColumn(FormPNEntity.TABLE_NPI_FORM_PN, "ASUS_PN", Asus.Data.DataType.NVarChar)]
        public string PN
        {
            set { _PN = value; }
            get { return _PN; }
        }

        /// <summary>
        /// 品名
        /// </summary>
        [DataColumn("PART_DESC1")]
        [QueryColumn("", "品名", "Y", ViewRowType.BoundField, "N", 20)]
        [QueryColumn2("", "品名", "Y", ViewRowType.BoundField, "N", 20)]
        [InsertColumn(FormPNEntity.TABLE_NPI_FORM_PN, "PART_DESC1", Asus.Data.DataType.NVarChar)]
        public string PNName
        {
            set { _PNName = value; }
            get { return _PNName; }
        }

        /// <summary>
        /// 規格
        /// </summary>
        [DataColumn("PART_DESC2")]
        [QueryColumn("", "規格", "Y", ViewRowType.BoundField, "N", 30)]
        [QueryColumn2("", "規格", "Y", ViewRowType.BoundField, "N", 30)]
        [InsertColumn(FormPNEntity.TABLE_NPI_FORM_PN, "PART_DESC2", Asus.Data.DataType.NVarChar)]
        public string PNDesc
        {
            set { _PNDesc = value; }
            get { return _PNDesc; }
        }

        /// <summary>
        /// 組件號
        /// </summary>
        [DataColumn("ASSEMBLY_NO")]
        [QueryColumn("", "組件號", "Y", ViewRowType.BoundField, "N", 33)]
        [QueryColumn2("", "組件號", "Y", ViewRowType.BoundField, "N", 33)]
        [InsertColumn(FormPNEntity.TABLE_NPI_FORM_PN, "ASSEMBLY_NO", Asus.Data.DataType.NVarChar)]
        public string AssemblyNo
        {
            set { _AssemblyNo = value; }
            get { return _AssemblyNo; }
        }


        /// <summary>
        /// 主要料或替代料(N=主料/S=替代料)
        /// </summary>
        [DataColumn("ASSEMBLY_TYPE")]
        [QueryColumn("", "主/替", "Y", ViewRowType.BoundField, "N", 35)]
        [QueryColumn2("", "主/替", "Y", ViewRowType.BoundField, "N", 35)]
        [InsertColumn(FormPNEntity.TABLE_NPI_FORM_PN, "ASSEMBLY_TYPE", Asus.Data.DataType.NVarChar)]
        public string IsSub
        {
            set { _IsSub = value; }
            get { return _IsSub; }
        }

        [QueryColumn("", "BOM01", "Y", ViewRowType.BoundField, "N", 40)]
        [QueryColumn2("", "BOM01", "Y", ViewRowType.BoundField, "N", 40)]
        public string BOMId01
        {
            set { _BOMId01 = value; }
            get { return _BOMId01; }
        }

        [QueryColumn("", "BOM02", "Y", ViewRowType.BoundField, "N", 45)]
        [QueryColumn2("", "BOM02", "Y", ViewRowType.BoundField, "N", 45)]
        public string BOMId02
        {
            set { _BOMId02 = value; }
            get { return _BOMId02; }
        }

        [QueryColumn("", "BOM03", "Y", ViewRowType.BoundField, "N", 50)]
        [QueryColumn2("", "BOM03", "Y", ViewRowType.BoundField, "N", 50)]
        public string BOMId03
        {
            set { _BOMId03 = value; }
            get { return _BOMId03; }
        }

        [QueryColumn("", "BOM04", "Y", ViewRowType.BoundField, "N", 60)]
        [QueryColumn2("", "BOM04", "Y", ViewRowType.BoundField, "N", 60)]
        public string BOMId04
        {
            set { _BOMId04 = value; }
            get { return _BOMId04; }
        }

        [QueryColumn("", "BOM05", "Y", ViewRowType.BoundField, "N", 70)]
        [QueryColumn2("", "BOM05", "Y", ViewRowType.BoundField, "N", 70)]
        public string BOMId05
        {
            set { _BOMId05 = value; }
            get { return _BOMId05; }
        }

        [QueryColumn("", "BOM06", "Y", ViewRowType.BoundField, "N", 80)]
        [QueryColumn2("", "BOM06", "Y", ViewRowType.BoundField, "N", 80)]
        public string BOMId06
        {
            set { _BOMId06 = value; }
            get { return _BOMId06; }
        }

        [QueryColumn("", "BOM07", "Y", ViewRowType.BoundField, "N", 90)]
        [QueryColumn2("", "BOM07", "Y", ViewRowType.BoundField, "N", 90)]
        public string BOMId07
        {
            set { _BOMId07 = value; }
            get { return _BOMId07; }
        }

        [QueryColumn("", "BOM08", "Y", ViewRowType.BoundField, "N", 100)]
        [QueryColumn2("", "BOM08", "Y", ViewRowType.BoundField, "N", 100)]
        public string BOMId08
        {
            set { _BOMId08 = value; }
            get { return _BOMId08; }
        }

        [QueryColumn("", "BOM09", "Y", ViewRowType.BoundField, "N", 110)]
        [QueryColumn2("", "BOM09", "Y", ViewRowType.BoundField, "N", 110)]
        public string BOMId09
        {
            set { _BOMId09 = value; }
            get { return _BOMId09; }
        }

        [QueryColumn("", "BOM10", "Y", ViewRowType.BoundField, "N", 120)]
        [QueryColumn2("", "BOM10", "Y", ViewRowType.BoundField, "N", 120)]
        public string BOMId10
        {
            set { _BOMId10 = value; }
            get { return _BOMId10; }
        }

        [QueryColumn("", "BOM11", "Y", ViewRowType.BoundField, "N", 130)]
        [QueryColumn2("", "BOM11", "Y", ViewRowType.BoundField, "N", 130)]
        public string BOMId11
        {
            set { _BOMId11 = value; }
            get { return _BOMId11; }
        }

        [QueryColumn("", "BOM12", "Y", ViewRowType.BoundField, "N", 140)]
        [QueryColumn2("", "BOM12", "Y", ViewRowType.BoundField, "N", 140)]
        public string BOMId12
        {
            set { _BOMId12 = value; }
            get { return _BOMId12; }
        }

        [QueryColumn("", "BOM13", "Y", ViewRowType.BoundField, "N", 150)]
        [QueryColumn2("", "BOM13", "Y", ViewRowType.BoundField, "N", 150)]
        public string BOMId13
        {
            set { _BOMId13 = value; }
            get { return _BOMId13; }
        }

        [QueryColumn("", "BOM14", "Y", ViewRowType.BoundField, "N", 160)]
        [QueryColumn2("", "BOM14", "Y", ViewRowType.BoundField, "N", 160)]
        public string BOMId14
        {
            set { _BOMId14 = value; }
            get { return _BOMId14; }
        }

        [QueryColumn("", "BOM15", "Y", ViewRowType.BoundField, "N", 170)]
        [QueryColumn2("", "BOM15", "Y", ViewRowType.BoundField, "N", 170)]
        public string BOMId15
        {
            set { _BOMId15 = value; }
            get { return _BOMId15; }
        }

        [QueryColumn("", "BOM16", "Y", ViewRowType.BoundField, "N", 180)]
        [QueryColumn2("", "BOM16", "Y", ViewRowType.BoundField, "N", 180)]
        public string BOMId16
        {
            set { _BOMId16 = value; }
            get { return _BOMId16; }
        }

        [QueryColumn("", "BOM17", "Y", ViewRowType.BoundField, "N", 190)]
        [QueryColumn2("", "BOM17", "Y", ViewRowType.BoundField, "N", 190)]
        public string BOMId17
        {
            set { _BOMId17 = value; }
            get { return _BOMId17; }
        }

        [QueryColumn("", "BOM18", "Y", ViewRowType.BoundField, "N", 200)]
        [QueryColumn2("", "BOM18", "Y", ViewRowType.BoundField, "N", 200)]
        public string BOMId18
        {
            set { _BOMId18 = value; }
            get { return _BOMId18; }
        }

        [QueryColumn("", "BOM19", "Y", ViewRowType.BoundField, "N", 210)]
        [QueryColumn2("", "BOM19", "Y", ViewRowType.BoundField, "N", 210)]
        public string BOMId19
        {
            set { _BOMId19 = value; }
            get { return _BOMId19; }
        }

        [QueryColumn("", "BOM20", "Y", ViewRowType.BoundField, "N", 220)]
        [QueryColumn2("", "BOM20", "Y", ViewRowType.BoundField, "N", 220)]
        public string BOMId20
        {
            set { _BOMId20 = value; }
            get { return _BOMId20; }
        }

        /// <summary>
        /// 元件料號
        /// </summary>
        [QueryColumn("", "元件料號", "Y", ViewRowType.BoundField, "N", 230)]
        public string PN2
        {
            set { _PN = value; }
            get { return _PN; }
        }


        [DataColumn("ALERT")]
        [QueryColumn2("", "上傳", "Y", ViewRowType.BoundField, "N", 240)]
        [UpdateColumn(FormPNEntity.TABLE_NPI_FORM_PN, "ALERT", Asus.Data.DataType.NVarChar)]
        public string Alert
        {
            set { _Alert = value; }
            get { return _Alert; }
        }

        [QueryColumn("", "上傳", "Y", ViewRowType.CheckBox, "N", 240)]
        public bool IsAlert
        {
            set { _IsAlert = value; }
            get
            {
                if (_Alert != "")
                {
                    _IsAlert = _Alert == "Y" ? true : false;
                }
                return _IsAlert;
            }
        }

        /// <summary>
        /// RiskBuy
        /// </summary>
        [DataColumn("RISKBUY")]
        [QueryColumn2("", "RiskBuy", "Y", ViewRowType.BoundField, "N", 250)]
        [UpdateColumn(FormPNEntity.TABLE_NPI_FORM_PN, "RISKBUY", Asus.Data.DataType.NVarChar)]
        public string RiskBuy
        {
            set { _RiskBuy = value; }
            get { return _RiskBuy; }
        }

        /// <summary>
        /// Modify RiskBuy
        /// </summary>
        [QueryColumn("", "RiskBuy", "Y", ViewRowType.CheckBox, "N", 250)]
        public bool IsRiskBuy
        {
            set { _IsRiskBuy = value; }
            get
            {
                if (_RiskBuy != "")
                {
                    _IsRiskBuy = _RiskBuy == "Y" ? true : false;
                }
                return _IsRiskBuy;
            }
        }

        /// <summary>
        /// LT Time
        /// </summary>
        [DataColumn("LONGTERM_WEEK")]
        [QueryColumn("", "long L/T(weeks)", "Y", ViewRowType.TextBox, "N", 260)]
        [QueryColumn2("", "long L/T(weeks)", "Y", ViewRowType.BoundField, "N", 260)]
        [InsertColumn(FormPNEntity.TABLE_NPI_FORM_PN, "LONGTERM_WEEK", Asus.Data.DataType.NVarChar)]
        [UpdateColumn(FormPNEntity.TABLE_NPI_FORM_PN, "LONGTERM_WEEK", Asus.Data.DataType.NVarChar)]
        public string LTWeeks
        {
            set { _LTWeeks = value; }
            get { return _LTWeeks; }
        }

       
        /// <summary>
        /// 料號屬性
        /// </summary>
        [DataColumn("PN_PROPERTY")]
        [QueryColumn("", "料號屬性", "Y", ViewRowType.DropDownList, "N", 270)]
        [TemplateSubList(typeof(BOMLogic), "GetComponentPropertyList", null, "Key", "Value")]
        [InsertColumn(FormPNEntity.TABLE_NPI_FORM_PN, "PN_PROPERTY", Asus.Data.DataType.NVarChar)]
        [UpdateColumn(FormPNEntity.TABLE_NPI_FORM_PN, "PN_PROPERTY", Asus.Data.DataType.NVarChar)]
        public string PNProperty
        {
            set { _PNProperty = value; }
            get { return _PNProperty; }
        }

        [DataColumn("property_name")]
        [QueryColumn2("", "屬性", "Y", ViewRowType.BoundField, "N", 270)]
        public string PNPropertyName
        {
            set { _PNPropertyName = value; }
            get { return _PNPropertyName; }
        }

        /// <summary>
        /// 加入第二來源
        /// </summary>
        [DataColumn("ADD2_SOURCE")]
        [QueryColumn("", "加入第二來源", "Y", ViewRowType.DropDownList, "N", 280)]
        [TemplateSubList(typeof(BOMLogic), "GetAddSourceList", null, "Key", "Value")]
        [InsertColumn(FormPNEntity.TABLE_NPI_FORM_PN, "ADD2_SOURCE", Asus.Data.DataType.NVarChar)]
        [UpdateColumn(FormPNEntity.TABLE_NPI_FORM_PN, "ADD2_SOURCE", Asus.Data.DataType.NVarChar)]
        public string AddSource
        {
            set { _AddSource = value; }
            get { return _AddSource; }
        }

        [DataColumn("source_name")]
        [QueryColumn2("", "第二來源", "Y", ViewRowType.BoundField, "N", 280)]
        public string AddSourceName
        {
            set { _AddSourceName = value; }
            get { return _AddSourceName; }
        }

        /// <summary>
        /// 加入第二來源備註
        /// </summary>
        [DataColumn("ADD2_SOURCE_COMMENT")]
        [QueryColumn("", "加入第二來源備註", "Y", ViewRowType.TextBox, "N", 290)]
        [QueryColumn2("", "第二來源備註", "Y", ViewRowType.BoundField, "N", 290)]
        [InsertColumn(FormPNEntity.TABLE_NPI_FORM_PN, "ADD2_SOURCE_COMMENT", Asus.Data.DataType.NVarChar)]
        [UpdateColumn(FormPNEntity.TABLE_NPI_FORM_PN, "ADD2_SOURCE_COMMENT", Asus.Data.DataType.NVarChar)]
        public string AddSourceComment
        {
            set { _AddSourceComment = value; }
            get { return _AddSourceComment; }
        }

        /// <summary>
        /// EOL備註
        /// </summary>
        [DataColumn("EOL_COMMENT")]
        [QueryColumn("","EOL備註", "Y", ViewRowType.TextBox, "N", 300)]
        [QueryColumn2("", "EOL", "Y", ViewRowType.BoundField, "N", 300)]
        [InsertColumn(FormPNEntity.TABLE_NPI_FORM_PN, "EOL_COMMENT", Asus.Data.DataType.NVarChar)]
        [UpdateColumn(FormPNEntity.TABLE_NPI_FORM_PN, "EOL_COMMENT", Asus.Data.DataType.NVarChar)]
        public string EOL
        {
            set { _EOL = value; }
            get { return _EOL; }
        }

        /// <summary>
        /// 主替代料送件日
        /// </summary>
        [DataColumn("Action_Date")]
        public string ActionDate
        {
            set { _Action = value; }
            get { return _Action; }
        }

        /// <summary>
        /// 新增人員
        /// </summary>
        [DataColumn("CREATE_USER")]
        [InsertColumn(FormPNEntity.TABLE_NPI_FORM_PN, "CREATE_USER", Asus.Data.DataType.NVarChar)]
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }

        /// <summary>
        /// 新增時間
        /// </summary>
        [DataColumn("CREATE_DATE")]
        [InsertColumn(FormPNEntity.TABLE_NPI_FORM_PN, "CREATE_DATE", Asus.Data.DataType.DateTime)]
        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }

        /// <summary>
        /// 更新人員
        /// </summary>
        [DataColumn("UPDATE_USER")]
        [QueryColumn("", "更新人員", "Y", ViewRowType.BoundField, "N", 310)]
        [InsertColumn(FormPNEntity.TABLE_NPI_FORM_PN, "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        [UpdateColumn(FormPNEntity.TABLE_NPI_FORM_PN, "UPDATE_USER", Asus.Data.DataType.NVarChar)]
        public string UpdateUser
        {
            set { _UpdateUser = value; }
            get { return _UpdateUser; }
        }

        /// <summary>
        /// 更新時間
        /// </summary>
        [DataColumn("UPDATE_DATE")]
        [InsertColumn(FormPNEntity.TABLE_NPI_FORM_PN, "UPDATE_DATE", Asus.Data.DataType.DateTime)]
        [UpdateColumn(FormPNEntity.TABLE_NPI_FORM_PN, "UPDATE_DATE", Asus.Data.DataType.DateTime)]
        [QueryColumn("", "更新時間", "Y", ViewRowType.BoundField, "N", 320)]
        public string UpdateTime
        {
            set { _UpdateTime = value; }
            get { return _UpdateTime; }
        }
    }
}
