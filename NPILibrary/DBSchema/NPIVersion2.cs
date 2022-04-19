using System;
using System.Collections.Generic;
using System.Text;

using Asus.DBDesign;
using Asus.DBDesign.Attribute;


namespace AsusLibrary.DBSchema
{
    /// <summary>
    /// 
    /// </summary>
    [Version(GroupId = "NPI", Version = 2)]
    [Schema(SchemaName = "caerdsa", TypeName = SchemaType.Oracle)]
    public class NPIVersion2
    {
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_Group", ChineseName = "NPI 群組", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 10)]
        public enum NPI_Group
        {
            /// <summary>
            /// 群組代號
            /// </summary>
            [PrimaryKey()]
            [Column("Group_Id", "Group_Id", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            Group_Id,

            /// <summary>
            /// 系統名稱
            /// </summary>
            [Column("System_Name", "System_Name", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 20)]
            Group_Name,

            /// <summary>
            /// 系統說明
            /// </summary>
            [Column("System_Desc", "Project_Desc", Asus.Data.DataType.NVarChar, new object[] { 300 }, EnumAllowNull.Yes, 30)]
            Group_Desc,

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
        [Table(TableName = "NPI_Group_Mapping", ChineseName = "NPI 群組 人員", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 20)]
        public enum NPI_Group_Mapping
        {
            /// <summary>
            /// 群組代號
            /// </summary>
            [PrimaryKey()]
            [ForeignKey("NPI_Group", "Group_Id")]
            [Column("Group_Id", "Group_Id", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            Group_Id,

            /// <summary>
            /// 員工帳號
            /// 員工工號
            /// </summary>
            [PrimaryKey()]
            [Column("User_Id", "員工帳號", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 20)]
            USER_ID,

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
    }
}
