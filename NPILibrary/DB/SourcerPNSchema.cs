using System;
using System.Collections.Generic;
using System.Text;

using Asus.DBDesign;
using Asus.DBDesign.Attribute;

namespace AsusLibrary.DB
{
    [Version(GroupId = "NPI", Version = 1)]
    [Schema(SchemaName = "caerdsa", TypeName = SchemaType.Oracle)]
    public class SourcerPNSchema
    {
        /// <summary>
        /// 產生新的Table 
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_SourcerPN_Map", ChineseName = "採購與PN料號之群組關係", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 10)]
        public enum PNSourcer
        {
            /// <summary>
            /// CMS UserId
            /// </summary>
            [PrimaryKey()]
            [Column("User_Id", "UserId", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            UserId,

            /// <summary>
            /// 公司代號
            /// </summary>
            [PrimaryKey()]
            [Column("Company_Id", "公司代號", Asus.Data.DataType.NVarChar, new object[] { 100 }, EnumAllowNull.No, 15)]
            ComapnyId,

            [PrimaryKey()]
            [Column("Asus_PN", "PN料號", Asus.Data.DataType.NVarChar, new object[] { 100 }, EnumAllowNull.No, 20)]
            PN,


            /// <summary>
            /// 新增人員
            /// </summary>
            [Column("Create_User", "新增人員", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 70)]
            CreateUser,

            /// <summary>
            /// 新增時間
            /// </summary>
            [Column("Create_Time", "新增時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 80)]
            CreateTime,

            /// <summary>
            /// 修改人員
            /// </summary>
            [Column("Update_User", "修改人員", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 90)]
            UpdateUser,

            /// <summary>
            /// 修改時間
            /// </summary>
            [Column("Update_Time", "修改時間", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 100)]
            UpdateTime


        }
    }
}
