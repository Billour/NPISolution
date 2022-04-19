using System;
using System.Collections.Generic;
using System.Text;

using Asus.DBDesign;
using Asus.DBDesign.Attribute;

namespace AsusLibrary.DBSchema
{
    [Version(GroupId = "NPI", Version = 1)]
    [Schema(SchemaName = "caerdsa", TypeName = SchemaType.Oracle)]
    public class NPIVersion1
    {
        /// <summary>
        /// Table NPI_BOM
        /// 
        /// 本Table 用來放RD PM 所放的BOM基本資料
        /// 本Table 會與 Booking Table 一起使用
        /// 
        /// Grant 
        /// grant select, insert, update, delete on CAERDSA.NPI_BOM to SHINEWAVE;
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_BOM", ChineseName = "BOM基本資料", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 10)]
        public enum NPI_BOM
        {
            /// <summary>
            /// 員工帳號
            /// </summary>
            [PrimaryKey()]
            [Column("User_Id", "員工帳號", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            USER_ID,

            /// <summary>
            /// BOM 型號
            /// </summary>
            [PrimaryKey()]
            [Column("BOM_ID", "BOM 型號", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 20)]
            BOM_ID,

            /// <summary>
            /// BOM名稱
            /// </summary>
            [Column("BOM_NAME", "BOM名稱", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 30)]
            BOM_NAME,


            /// <summary>
            /// BOM 狀態
            /// </summary>
            [Column("BOM_STATUS", "BOM 狀態", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 40)]
            BOM_STATUS,

            /// <summary>
            /// BOM 說明
            /// </summary>
            [Column("BOM_DESC", "BOM 說明", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 50)]
            BOM_DESC,

            /// <summary>
            /// BOM 版本
            /// </summary>
            [Column("BOM_REVISION", "BOM 版本", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 60)]
            BOM_REVISION,

            /// <summary>
            /// RD 員工帳號
            /// </summary>
            [Column("RD_EMP_ID", "RD 員工帳號", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 70)]
            RD_EMP_ID,

            /// <summary>
            /// RD 員工姓名
            /// </summary>
            [Column("RD_EMP_NAME", "RD 員工姓名", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 80)]
            RD_EMP_NAME,

            /// <summary>
            /// RD 員工分機
            /// </summary>
            [Column("RD_EMP_PHONENO", "RD 員工分機", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 90)]
            RD_EMP_PHONENO,

            /// <summary>
            /// PVT 數量
            /// </summary>
            [Column("PVT_QTY", "PVT 數量", Asus.Data.DataType.Int, null, EnumAllowNull.Yes, 100)]
            PVT_QTY,

            /// <summary>
            /// PVT 時間
            /// </summary>
            [Column("PVT_TIME", "PVT 時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 110)]
            PVT_TIME,

            /// <summary>
            /// PVT 生產地
            /// </summary>
            [Column("PVT_LOCATION", "PVT 生產地", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 120)]
            PVT_LOCATION,

            /// <summary>
            ///  MP 大量生產時間
            /// </summary>
            [Column("MP_TIME", "MP 大量生產時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 130)]
            MP_TIME,

            /// <summary>
            /// MP Q1 數量
            /// </summary>
            [Column("MP_Q1_QTY", "MP Q1 數量", Asus.Data.DataType.Int, null, EnumAllowNull.Yes, 140)]
            MP_Q1_QTY,

            /// <summary>
            /// MP Q2 數量
            /// </summary>
            [Column("MP_Q2_QTY", "MP Q2 數量", Asus.Data.DataType.Int, null, EnumAllowNull.Yes, 150)]
            MP_Q2_QTY,

            /// <summary>
            /// 建立人員
            /// </summary>
            [Column("CREATE_USER", "建立人員", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 160)]
            CREATE_USER,

            /// <summary>
            /// 建立時間
            /// </summary>
            [Column("CREATE_DATE", "建立時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 170)]
            CREATE_DATE,

            /// <summary>
            /// 更新人員
            /// </summary>
            [Column("UPDATE_USER", "更新人員", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 180)]
            UPDATE_USER,

            /// <summary>
            /// 更新時間
            /// </summary>
            [Column("UPDATE_DATE", "更新時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 190)]
            UPDATE_DATE,

            /// <summary>
            /// 是否使用
            /// </summary>
            [Column("IS_ENABLE", "是否使用", Asus.Data.DataType.Char, new object[] { 1 }, EnumAllowNull.No, 200)]
            IS_ENABLE,

            /// <summary>
            /// 公司代號
            /// </summary>
            [Column("COMPANY_ID", "公司代號", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 210)]
            COMPANY_ID
            
            
        }

        /// <summary>
        /// BOM PN 的關係，本Table 是放BOM 與 PN的關係，由展BOM 程式而來
        /// 
        /// 
        /// grant select, insert, update, delete on CAERDSA.NPI_BOM_PN to SHINEWAVE;
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_BOM", ChineseName = "BOM展PN料號關係", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 20)]
        public enum NPI_BOM_PN
        {
            /// <summary>
            /// Form代號
            /// </summary>
            [PrimaryKey()]
            [ForeignKey("NPI_FORM_MAIN", "FORM_ID")]
            [Column("FORM_ID", "Form代號", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            FORM_ID,     //NVARCHAR2(20) not null,

            /// <summary>
            /// 產生代號
            /// </summary>
            [Column("WORK_NO", "產生代號", Asus.Data.DataType.NVarChar, new object[] { 50 }, EnumAllowNull.No, 20)]
            WORK_NO,     //NVARCHAR2(50) not null,
            
            /// <summary>
            /// BOM
            /// </summary>
            [PrimaryKey()]
            [Column("ASUS_BOM", "BOM", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 30)]
            ASUS_BOM,    //NVARCHAR2(60) not null,
            
            /// <summary>
            /// 元件料號
            /// </summary>
            [PrimaryKey()]
            [Column("ASUS_PN", "元件料號", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 40)]
            ASUS_PN,     //NVARCHAR2(60) not null,
            
            /// <summary>
            /// 組合用料
            /// </summary>
            [Column("ASUS_PN", "組合用料", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 50)]
            ASMBLY_QTY,  //NVARCHAR2(60) not null,
            
            /// <summary>
            /// 建立人員
            /// </summary>
            [Column("CREATE_USER", "建立人員", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 160)]
            CREATE_USER,

            /// <summary>
            /// 建立時間
            /// </summary>
            [Column("CREATE_DATE", "建立時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 170)]
            CREATE_DATE,

            /// <summary>
            /// 更新人員
            /// </summary>
            [Column("UPDATE_USER", "更新人員", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 180)]
            UPDATE_USER,

            /// <summary>
            /// 更新時間
            /// </summary>
            [Column("UPDATE_DATE", "更新時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 190)]
            UPDATE_DATE,
        }

        /// <summary>
        /// BOM BOOKING 資料表
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_BOOKING", ChineseName = "BOM BOOKING 資料表", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 30)]
        public enum NPI_BOOKING
        {
            /// <summary>
            /// PM員工帳號
            /// </summary>
            [PrimaryKey()]
            [Column("USER_ID", "PM員工帳號", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)] 
            USER_ID,            //NVARCHAR2(20) not null,
            
            /// <summary>
            /// 展BOM 的單號
            /// </summary>
            [PrimaryKey()]
            [Column("BOM_ID", "BOM 代號", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 20)] 
            BOM_ID,       //NVARCHAR2(20) not null,

            /// <summary>
            /// Form代號
            /// </summary>
            [PrimaryKey()]
            [Column("FORM_ID", "Form代號", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 30)]
            FORM_ID,     //NVARCHAR2(20) not null,

            /// <summary>
            /// 目前狀態
            /// </summary>
            [Column("WORK_STATUS", "目前狀態", Asus.Data.DataType.Int, null, EnumAllowNull.No, 40)]
            WORK_STATUS,  //NUMBER not null,

            /// <summary>
            /// BOOKING 時間
            /// </summary>
            [Column("BOOKING_DATE", "BOOKING 時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 50)]
            BOOKING_DATE, //DATE not null,

             /// <summary>
             /// 建立人員
             /// </summary>
             [Column("CREATE_USER", "建立人員", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 160)]
             CREATE_USER,

             /// <summary>
             /// 建立時間
             /// </summary>
             [Column("CREATE_DATE", "建立時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 170)]
             CREATE_DATE,

             /// <summary>
             /// 更新人員
             /// </summary>
             [Column("UPDATE_USER", "更新人員", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 180)]
             UPDATE_USER,

             /// <summary>
             /// 更新時間
             /// </summary>
             [Column("UPDATE_DATE", "更新時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 190)]
             UPDATE_DATE,

             /// <summary>
             /// PM所在公司
             /// </summary>
            [Column("COMPANY_ID", "PM所在公司", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 210)]
             COMPANY_ID
        }

        /// <summary>
        /// 幣別資料
        /// grant select, insert, update, delete on CAERDSA.NPI_DOLLAR_TYPE to SHINEWAVE;
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_DOLLAR_TYPE", ChineseName = "幣別資料", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 40)]
        public enum NPI_DOLLAR_TYPE
        {
            /// <summary>
            /// 幣別代號
            /// </summary>
            [PrimaryKey()]
            [Column("DOLLAR_TYPEID", "幣別代號", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)] 
             DOLLAR_TYPEID,   //NVARCHAR2(20) not null,

            /// <summary>
             /// 幣別名稱
            /// </summary>
            [PrimaryKey()]
            [Column("DOLLAR_TYPENAME", "幣別名稱", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 30)] 
            DOLLAR_TYPENAME, //NVARCHAR2(60) not null,

            /// <summary>
            /// 說明
            /// </summary>
            [Column("DESCRIPTION", "說明", Asus.Data.DataType.NVarChar, new object[] { 300 }, EnumAllowNull.Yes, 40)] 
            DESCRIPTION,     //NVARCHAR2(300),
              /// <summary>
              /// 更新人員
              /// </summary>
              [Column("UPDATE_USER", "更新人員", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 180)]
              UPDATE_USER,

              /// <summary>
              /// 更新時間
              /// </summary>
              [Column("UPDATE_DATE", "更新時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 190)]
              UPDATE_DATE,
        }

        /// <summary>
        /// EMS 維護程式
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_EMS", ChineseName = "EMS 維護程式", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 50)]
        public enum NPI_EMS
        {
            /// <summary>
            /// EMS CODE
            /// </summary>
            [PrimaryKey()]
            [Column("EMS_CODE", "EMS CODE", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)] 
            EMS_CODE,    //NVARCHAR2(20) not null,

            /// <summary>
            /// EMS NAME
            /// </summary>
            [Column("EMS_NAME", "EMS NAME", Asus.Data.DataType.NVarChar, new object[] { 30 }, EnumAllowNull.No, 20)] 
            EMS_NAME,    //NVARCHAR2(30) not null,

            /// <summary>
            /// EMS_COMPANY
            /// </summary>
            [Column("EMS_COMPANY", "EMS_COMPANY", Asus.Data.DataType.NVarChar, new object[] { 30 }, EnumAllowNull.Yes, 30)] 
            EMS_COMPANY, //NVARCHAR2(30),


            /// <summary>
            /// 更新人員
            /// </summary>
            [Column("UPDATE_USER", "更新人員", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 40)]
            UPDATE_USER,

            /// <summary>
            /// 更新時間
            /// </summary>
            [Column("UPDATE_TIME", "更新時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 50)]
            UPDATE_TIME,

           
            /// <summary>
            /// TIPTOP_SITE
            /// </summary>
            [Column("TIPTOP_SITE", "TIPTOP SITE", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 60)] 
            TIPTOP_SITE  //NVARCHAR2(60)
        }

        /// <summary>
        /// NPI Main Form
        /// 
        /// grant select, insert, update, delete on CAERDSA.NPI_FORM_MAIN to SHINEWAVE;
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_FORM_MAIN", ChineseName = "NPI 展BOM 主檔", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 50)]
        public enum NPI_FORM_MAIN
        {
            /// <summary>
            /// Form代號
            /// </summary>
            [PrimaryKey()]
            [Column("FORM_ID", "Form代號", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            FORM_ID,     //NVARCHAR2(20) not null,

            [Column("FORM_DATE", "Form 日期", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 20)]
            FORM_DATE,   //DATE not null,

            /// <summary>
            /// 建立人員
            /// </summary>
            [Column("CREATE_USER", "建立人員", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 30)]
            CREATE_USER,

            /// <summary>
            /// 建立時間
            /// </summary>
            [Column("CREATE_DATE", "建立時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 40)]
            CREATE_DATE,

            /// <summary>
            /// 是否使用
            /// </summary>
            [Column("FORM_STATUS", "FORM狀態N=尚未結案 Y=已結案", Asus.Data.DataType.Char, new object[] { 1 }, EnumAllowNull.No, 50)]
            FORM_STATUS //CHAR(1) default 'N'
        }


        /// <summary>
        /// NPI Form PN
        /// grant select, insert, update, delete on CAERDSA.NPI_FORM_PN to SHINEWAVE;
        /// </summary>
        public enum NPI_FORM_PN
        {
            /// <summary>
            /// Form代號
            /// </summary>
            [PrimaryKey()]
            [Column("FORM_ID", "Form代號", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            FORM_ID,     //NVARCHAR2(20) not null,

            /// <summary>
            /// 元件料號
            /// </summary>
            [PrimaryKey()]
            [Column("ASUS_PN", "元件料號", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 20)]
            ASUS_PN,             //NVARCHAR2(60) not null,

            /// <summary>
            /// 品名
            /// </summary>
            [Column("PART_DESC1", "品名", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 30)]
            PART_DESC1,          //NVARCHAR2(200),

            /// <summary>
            /// 規格
            /// </summary>
            [Column("PART_DESC2", "規格", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 40)]
            PART_DESC2,          //NVARCHAR2(200),

            /// <summary>
            /// LONGTERM_WEEK
            /// </summary>
            [Column("LONGTERM_WEEK", "long L/T(weeks)", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 50)]
            LONGTERM_WEEK,       //NVARCHAR2(20),

            /// <summary>
            /// 料號屬性
            /// </summary>
            [Column("PN_PROPERTY", "料號屬性。Ref(NPI_PN_Property)", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 60)]
            PN_PROPERTY,         //NVARCHAR2(20),

            /// <summary>
            /// 加入第二來源
            /// </summary>
            [Column("ADD2_SOURCE", "加入第二來源。Ref(NPI_PN_Add2Source)", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 70)]
            ADD2_SOURCE,         //NVARCHAR2(20),

            /// <summary>
            /// 加入第二來源備註
            /// </summary>
            [Column("ADD2_SOURCE_COMMENT", "加入第二來源備註", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 80)]
            ADD2_SOURCE_COMMENT, //NVARCHAR2(200),

            /// <summary>
            /// EOL備註
            /// </summary>
            [Column("EOL_COMMENT", "EOL備註", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 90)]
            EOL_COMMENT,         //NVARCHAR2(200),

            /// <summary>
            /// 建立人員
            /// </summary>
            [Column("CREATE_USER", "建立人員", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 100)]
            CREATE_USER,

            /// <summary>
            /// 建立時間
            /// </summary>
            [Column("CREATE_DATE", "建立時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 110)]
            CREATE_DATE,

            /// <summary>
            /// 更新人員
            /// </summary>
            [Column("UPDATE_USER", "更新人員", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 120)]
            UPDATE_USER,

            /// <summary>
            /// 更新時間
            /// </summary>
            [Column("UPDATE_DATE", "更新時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 130)]
            UPDATE_DATE,

            /// <summary>
            /// 是否提醒
            /// </summary>
            [Column("ALERT", "是否提醒", Asus.Data.DataType.Char, new object[] { 1 }, EnumAllowNull.No, 140)]
            ALERT,               //CHAR(1) default 'N',

            /// <summary>
            /// 料號群組
            /// </summary>
            [Column("ASSEMBLY_NO", "料號群組", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 150)]
            ASSEMBLY_NO,         //NVARCHAR2(200),

            /// <summary>
            /// 主/替代料(N=主料 S=替代料)
            /// </summary>
            [Column("ASSEMBLY_TYPE", "主/替代料(N=主料 S=替代料)", Asus.Data.DataType.Char, new object[] { 1 }, EnumAllowNull.No, 160)]
            ASSEMBLY_TYPE,      //CHAR(1),

            /// <summary>
            /// RISKBUY
            /// </summary>
            [Column("RISKBUY", "RiskBuy(Y=是,N=不是)", Asus.Data.DataType.Char, new object[] { 1 }, EnumAllowNull.No, 170)]
            RISKBUY             //CHAR(1)
        }

        /// <summary>
        /// NPI PM 表單資料表
        /// grant select, insert, update, delete on CAERDSA.NPI_FORM_SUB to SHINEWAVE;
        /// </summary>
        public enum NPI_FORM_SUB
        {
            /// <summary>
            /// Form代號
            /// </summary>
            [PrimaryKey()]
            [Column("FORM_ID", "Form代號", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            FORM_ID,     //NVARCHAR2(20) not null,

            /// <summary>
            /// 負責PM員工工號
            /// </summary>
            [PrimaryKey()]
            [Column("PM_USER_ID", "負責PM員工工號", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 20)]
             PM_USER_ID,    //NVARCHAR2(20) not null,

             /// <summary>
             /// 負責PM員工公司
             /// </summary>
             [PrimaryKey()]
            [Column("PM_COMPANY_ID", "負責PM員工公司", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 30)]
            PM_COMPANY_ID //NVARCHAR2(60) not null
        }

        /// <summary>
        /// NPI Price
        /// </summary>
        public enum NPI_PNPRICE
        { 
          PN,              //NVARCHAR2(60) not null,
          YEARQ,           //NVARCHAR2(20) not null,
          IS_CONFIRM,      //CHAR(1) not null,
          IS_SEND,         //CHAR(1) not null,
          DOLLAR_TYPE,     //NVARCHAR2(20) not null,
          LOCATION_SITE,   //NVARCHAR2(20) not null,
          TIPTOP_PRICE,    //NUMBER not null,
          QUATATION_PRICE, //NUMBER,
          EFFECT_DATE,     //DATE not null,
          DISABLE_DATE,    //DATE not null,
          CREATE_USER,     //NVARCHAR2(20) not null,
          CREATE_TIME,     //DATE not null,
          CONFIRM_USER,    //NVARCHAR2(20),
          CONFIRM_TIME,    //DATE,
          SEND_USER,       //NVARCHAR2(20),
          SEND_TIME,       //DATE,
          PN_DESC,         //NVARCHAR2(300),
          PN_SPEC,         //NVARCHAR2(300),
          BUYING_MODE     //CHAR(1)
        }

    }
}
