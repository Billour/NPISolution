using System;
using System.Collections.Generic;
using System.Text;

using Asus.DBDesign;
using Asus.DBDesign.Attribute;

namespace AsusLibrary.DBSchema
{
    /// <summary>
    /// �w��NPI���
    /// �D�s�եN�X
    /// </summary>
    [Version(GroupId = "NPI", Version = 4)]
    [Schema(SchemaName = "caerdsa", TypeName = SchemaType.Oracle)]
    public class NPIVersion4
    {

        

        /// <summary>
        ///  �D�n�s��
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_Main", ChineseName = "NPI�D��", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 10)]
        public enum NPI_Main
        {
            /// <summary>
            /// �N��
            /// </summary>
            [PrimaryKey()]
            [Column("Main_Id", "Main_Id", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            Main_Id,

            /// <summary>
            /// �W��
            /// </summary>
            [Column("Main_Name", "Main_Name", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 20)]
            Main_Name,

            /// <summary>
            /// ����
            /// </summary>
            [Column("Main_Desc", "Main_Desc", Asus.Data.DataType.NVarChar, new object[] { 300 }, EnumAllowNull.Yes, 30)]
            Main_Desc,

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
        [Table(TableName = "NPI_Main_Map", ChineseName = "NPI�D�ɹ�M��", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 20)]
        public enum NPI_Main_Map
        {
            /// <summary>
            /// �D�ɥN��
            /// </summary>
            [PrimaryKey()]
            //[ForeignKey("NPI_Main", "Main_Id")]
            [Column("Main_Id", "Main_Id", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            Main_Id,

            /// <summary>
            /// ���N��
            /// </summary>
            [PrimaryKey()]
            //[ForeignKey("NPI_FORM_MAIN", "FORM_ID")]
            [Column("FORM_ID", "Form�N��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 20)]
            FORM_ID,

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
        /// NPI Form PN
        /// grant select, insert, update, delete on CAERDSA.NPI_FORM_PN to SHINEWAVE;
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_Main_PN", ChineseName = "NPI�D�ɮƸ���M��", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 30)]
        public enum NPI_Main_PN
        {
            /// <summary>
            /// Form�N��
            /// </summary>
            [PrimaryKey()]
            [Column("Main_Id", "Main_Id", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            Main_Id,

            /// <summary>
            /// ����Ƹ�
            /// </summary>
            [PrimaryKey()]
            [Column("ASUS_PN", "����Ƹ�", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 20)]
            ASUS_PN,

            /// <summary>
            /// �~�W
            /// </summary>
            [Column("PART_DESC1", "�~�W", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 30)]
            PART_DESC1,   

            /// <summary>
            /// �W��
            /// </summary>
            [Column("PART_DESC2", "�W��", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 40)]
            PART_DESC2,        

            /// <summary>
            /// LONGTERM_WEEK
            /// </summary>
            [Column("LONGTERM_WEEK", "long L/T(weeks)", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 50)]
            LONGTERM_WEEK,    

            /// <summary>
            /// �Ƹ��ݩ�
            /// </summary>
            [Column("PN_PROPERTY", "�Ƹ��ݩʡCRef(NPI_PN_Property)", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 60)]
            PN_PROPERTY,        

            /// <summary>
            /// �[�J�ĤG�ӷ�
            /// </summary>
            [Column("ADD2_SOURCE", "�[�J�ĤG�ӷ��CRef(NPI_PN_Add2Source)", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 70)]
            ADD2_SOURCE,         

            /// <summary>
            /// �[�J�ĤG�ӷ��Ƶ�
            /// </summary>
            [Column("ADD2_SOURCE_COMMENT", "�[�J�ĤG�ӷ��Ƶ�", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 80)]
            ADD2_SOURCE_COMMENT, 

            /// <summary>
            /// EOL�Ƶ�
            /// </summary>
            [Column("EOL_COMMENT", "EOL�Ƶ�", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 90)]
            EOL_COMMENT,

            /// <summary>
            /// �إߤH��
            /// </summary>
            [Column("CREATE_USER", "�إߤH��", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 100)]
            CREATE_USER,

            /// <summary>
            /// �إ߮ɶ�
            /// </summary>
            [Column("CREATE_DATE", "�إ߮ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 110)]
            CREATE_DATE,

            /// <summary>
            /// ��s�H��
            /// </summary>
            [Column("UPDATE_USER", "��s�H��", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 120)]
            UPDATE_USER,

            /// <summary>
            /// ��s�ɶ�
            /// </summary>
            [Column("UPDATE_DATE", "��s�ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 130)]
            UPDATE_DATE,

            /// <summary>
            /// �O�_����
            /// </summary>
            [Column("ALERT", "�O�_����", Asus.Data.DataType.Char, new object[] { 1 }, EnumAllowNull.No, 140)]
            ALERT,               //CHAR(1) default 'N',

            /// <summary>
            /// �Ƹ��s��
            /// </summary>
            [Column("ASSEMBLY_NO", "�Ƹ��s��", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 150)]
            ASSEMBLY_NO,         //NVARCHAR2(200),

            /// <summary>
            /// �D/���N��(N=�D�� S=���N��)
            /// </summary>
            [Column("ASSEMBLY_TYPE", "�D/���N��(N=�D�� S=���N��)", Asus.Data.DataType.Char, new object[] { 1 }, EnumAllowNull.No, 160)]
            ASSEMBLY_TYPE,      //CHAR(1),

            /// <summary>
            /// RISKBUY
            /// </summary>
            [Column("RISKBUY", "RiskBuy(Y=�O,N=���O)", Asus.Data.DataType.Char, new object[] { 1 }, EnumAllowNull.No, 170)]
            RISKBUY,             //CHAR(1)

            /// <summary>
            /// ���N�ưe���
            /// </summary>
            [Column("Action_Date", "���N�ưe���", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 180)]
            Action_Date
        }
    }
}
