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
        [Table(TableName = "NPI_Group", ChineseName = "NPI �s��", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 10)]
        public enum NPI_Group
        {
            /// <summary>
            /// �s�եN��
            /// </summary>
            [PrimaryKey()]
            [Column("Group_Id", "Group_Id", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            Group_Id,

            /// <summary>
            /// �t�ΦW��
            /// </summary>
            [Column("System_Name", "System_Name", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 20)]
            Group_Name,

            /// <summary>
            /// �t�λ���
            /// </summary>
            [Column("System_Desc", "Project_Desc", Asus.Data.DataType.NVarChar, new object[] { 300 }, EnumAllowNull.Yes, 30)]
            Group_Desc,

            /// <summary>
            /// �ثe���A
            /// Y=Enable
            /// N=Disable
            /// </summary>
            [Column("Work_Status", "�ثe���A", Asus.Data.DataType.Char, new object[] { 1 }, EnumAllowNull.No, 40)]
            WorkStstus,

            /// <summary>
            /// �s�W�H��
            /// </summary>
            [Column("Create_User", "�s�W�H��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 50)]
            CreateUser,

            /// <summary>
            /// �s�W�ɶ�
            /// </summary>
            [Column("Create_Time", "�s�W�ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 60)]
            CreateTime,

            /// <summary>
            /// �ק�H��
            /// </summary>
            [Column("Update_User", "�ק�H��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 70)]
            UpdateUser,

            /// <summary>
            /// �ק�ɶ�
            /// </summary>
            [Column("Update_Time", "�ק�ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 80)]
            UpdateTime
        }

        /// <summary>
        /// 
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_Group_Mapping", ChineseName = "NPI �s�� �H��", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 20)]
        public enum NPI_Group_Mapping
        {
            /// <summary>
            /// �s�եN��
            /// </summary>
            [PrimaryKey()]
            [ForeignKey("NPI_Group", "Group_Id")]
            [Column("Group_Id", "Group_Id", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            Group_Id,

            /// <summary>
            /// ���u�b��
            /// ���u�u��
            /// </summary>
            [PrimaryKey()]
            [Column("User_Id", "���u�b��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 20)]
            USER_ID,

            /// <summary>
            /// �ثe���A
            /// Y=Enable
            /// N=Disable
            /// </summary>
            [Column("Work_Status", "�ثe���A", Asus.Data.DataType.Char, new object[] { 1 }, EnumAllowNull.No, 40)]
            WorkStstus,

            /// <summary>
            /// �s�W�H��
            /// </summary>
            [Column("Create_User", "�s�W�H��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 50)]
            CreateUser,

            /// <summary>
            /// �s�W�ɶ�
            /// </summary>
            [Column("Create_Time", "�s�W�ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 60)]
            CreateTime,

            /// <summary>
            /// �ק�H��
            /// </summary>
            [Column("Update_User", "�ק�H��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 70)]
            UpdateUser,

            /// <summary>
            /// �ק�ɶ�
            /// </summary>
            [Column("Update_Time", "�ק�ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 80)]
            UpdateTime


        }
    }
}
