using System;
using System.Collections.Generic;
using System.Text;

using Asus.DBDesign;
using Asus.DBDesign.Attribute;

namespace AsusLibrary.DBSchema
{
    /// <summary>
    /// 針對NPI資料
    /// 主群組代碼
    /// </summary>
    [Version(GroupId = "NPI", Version = 4)]
    [Schema(SchemaName = "caerdsa", TypeName = SchemaType.Oracle)]
    public class NPIVersion4
    {

        

        /// <summary>
        ///  主要群組
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_Main", ChineseName = "NPI主檔", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 10)]
        public enum NPI_Main
        {
            /// <summary>
            /// 代號
            /// </summary>
            [PrimaryKey()]
            [Column("Main_Id", "Main_Id", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            Main_Id,

            /// <summary>
            /// 名稱
            /// </summary>
            [Column("Main_Name", "Main_Name", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 20)]
            Main_Name,

            /// <summary>
            /// 說明
            /// </summary>
            [Column("Main_Desc", "Main_Desc", Asus.Data.DataType.NVarChar, new object[] { 300 }, EnumAllowNull.Yes, 30)]
            Main_Desc,

            /// <summary>
            /// 目前狀態
            /// Y=Enable
            /// N=Disable
            /// </summary>
            [Column("Work_Status", "目前狀態", Asus.Data.DataType.Char, new object[] { 1 }, EnumAllowNull.No, 40)]
            WorkStstus,

            /// <summary>
            /// 新增人員
            /// </summary>
            [Column("Create_User", "新增人員", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 50)]
            CreateUser,

            /// <summary>
            /// 新增時間
            /// </summary>
            [Column("Create_Time", "新增時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 60)]
            CreateTime,

            /// <summary>
            /// 修改人員
            /// </summary>
            [Column("Update_User", "修改人員", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 70)]
            UpdateUser,

            /// <summary>
            /// 修改時間
            /// </summary>
            [Column("Update_Time", "修改時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 80)]
            UpdateTime
        }

        /// <summary>
        /// 
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_Main_Map", ChineseName = "NPI主檔對映表", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 20)]
        public enum NPI_Main_Map
        {
            /// <summary>
            /// 主檔代號
            /// </summary>
            [PrimaryKey()]
            //[ForeignKey("NPI_Main", "Main_Id")]
            [Column("Main_Id", "Main_Id", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            Main_Id,

            /// <summary>
            /// 表單代號
            /// </summary>
            [PrimaryKey()]
            //[ForeignKey("NPI_FORM_MAIN", "FORM_ID")]
            [Column("FORM_ID", "Form代號", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 20)]
            FORM_ID,

            /// <summary>
            /// 目前狀態
            /// Y=Enable
            /// N=Disable
            /// </summary>
            [Column("Work_Status", "目前狀態", Asus.Data.DataType.Char, new object[] { 1 }, EnumAllowNull.No, 40)]
            WorkStstus,

            /// <summary>
            /// 新增人員
            /// </summary>
            [Column("Create_User", "新增人員", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 50)]
            CreateUser,

            /// <summary>
            /// 新增時間
            /// </summary>
            [Column("Create_Time", "新增時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 60)]
            CreateTime,

            /// <summary>
            /// 修改人員
            /// </summary>
            [Column("Update_User", "修改人員", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 70)]
            UpdateUser,

            /// <summary>
            /// 修改時間
            /// </summary>
            [Column("Update_Time", "修改時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 80)]
            UpdateTime


        }

        /// <summary>
        /// NPI Form PN
        /// grant select, insert, update, delete on CAERDSA.NPI_FORM_PN to SHINEWAVE;
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_Main_PN", ChineseName = "NPI主檔料號對映表", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 30)]
        public enum NPI_Main_PN
        {
            /// <summary>
            /// Form代號
            /// </summary>
            [PrimaryKey()]
            [Column("Main_Id", "Main_Id", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            Main_Id,

            /// <summary>
            /// 元件料號
            /// </summary>
            [PrimaryKey()]
            [Column("ASUS_PN", "元件料號", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 20)]
            ASUS_PN,

            /// <summary>
            /// 品名
            /// </summary>
            [Column("PART_DESC1", "品名", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 30)]
            PART_DESC1,   

            /// <summary>
            /// 規格
            /// </summary>
            [Column("PART_DESC2", "規格", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 40)]
            PART_DESC2,        

            /// <summary>
            /// LONGTERM_WEEK
            /// </summary>
            [Column("LONGTERM_WEEK", "long L/T(weeks)", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 50)]
            LONGTERM_WEEK,    

            /// <summary>
            /// 料號屬性
            /// </summary>
            [Column("PN_PROPERTY", "料號屬性。Ref(NPI_PN_Property)", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 60)]
            PN_PROPERTY,        

            /// <summary>
            /// 加入第二來源
            /// </summary>
            [Column("ADD2_SOURCE", "加入第二來源。Ref(NPI_PN_Add2Source)", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 70)]
            ADD2_SOURCE,         

            /// <summary>
            /// 加入第二來源備註
            /// </summary>
            [Column("ADD2_SOURCE_COMMENT", "加入第二來源備註", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 80)]
            ADD2_SOURCE_COMMENT, 

            /// <summary>
            /// EOL備註
            /// </summary>
            [Column("EOL_COMMENT", "EOL備註", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 90)]
            EOL_COMMENT,

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
            RISKBUY,             //CHAR(1)

            /// <summary>
            /// 替代料送件日
            /// </summary>
            [Column("Action_Date", "替代料送件日", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 180)]
            Action_Date
        }
    }
}
