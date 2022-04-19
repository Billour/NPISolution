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
        /// ���ͷs��Table 
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_SourcerPN_Map", ChineseName = "���ʻPPN�Ƹ����s�����Y", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 10)]
        public enum PNSourcer
        {
            /// <summary>
            /// CMS UserId
            /// </summary>
            [PrimaryKey()]
            [Column("User_Id", "UserId", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            UserId,

            /// <summary>
            /// ���q�N��
            /// </summary>
            [PrimaryKey()]
            [Column("Company_Id", "���q�N��", Asus.Data.DataType.NVarChar, new object[] { 100 }, EnumAllowNull.No, 15)]
            ComapnyId,

            [PrimaryKey()]
            [Column("Asus_PN", "PN�Ƹ�", Asus.Data.DataType.NVarChar, new object[] { 100 }, EnumAllowNull.No, 20)]
            PN,


            /// <summary>
            /// �s�W�H��
            /// </summary>
            [Column("Create_User", "�s�W�H��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 70)]
            CreateUser,

            /// <summary>
            /// �s�W�ɶ�
            /// </summary>
            [Column("Create_Time", "�s�W�ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 80)]
            CreateTime,

            /// <summary>
            /// �ק�H��
            /// </summary>
            [Column("Update_User", "�ק�H��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 90)]
            UpdateUser,

            /// <summary>
            /// �ק�ɶ�
            /// </summary>
            [Column("Update_Time", "�ק�ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 100)]
            UpdateTime


        }
    }
}
