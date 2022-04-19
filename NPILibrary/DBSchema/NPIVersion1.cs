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
        /// ��Table �Ψө�RD PM �ҩ�BOM�򥻸��
        /// ��Table �|�P Booking Table �@�_�ϥ�
        /// 
        /// Grant 
        /// grant select, insert, update, delete on CAERDSA.NPI_BOM to SHINEWAVE;
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_BOM", ChineseName = "BOM�򥻸��", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 10)]
        public enum NPI_BOM
        {
            /// <summary>
            /// ���u�b��
            /// </summary>
            [PrimaryKey()]
            [Column("User_Id", "���u�b��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            USER_ID,

            /// <summary>
            /// BOM ����
            /// </summary>
            [PrimaryKey()]
            [Column("BOM_ID", "BOM ����", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 20)]
            BOM_ID,

            /// <summary>
            /// BOM�W��
            /// </summary>
            [Column("BOM_NAME", "BOM�W��", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 30)]
            BOM_NAME,


            /// <summary>
            /// BOM ���A
            /// </summary>
            [Column("BOM_STATUS", "BOM ���A", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 40)]
            BOM_STATUS,

            /// <summary>
            /// BOM ����
            /// </summary>
            [Column("BOM_DESC", "BOM ����", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 50)]
            BOM_DESC,

            /// <summary>
            /// BOM ����
            /// </summary>
            [Column("BOM_REVISION", "BOM ����", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 60)]
            BOM_REVISION,

            /// <summary>
            /// RD ���u�b��
            /// </summary>
            [Column("RD_EMP_ID", "RD ���u�b��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 70)]
            RD_EMP_ID,

            /// <summary>
            /// RD ���u�m�W
            /// </summary>
            [Column("RD_EMP_NAME", "RD ���u�m�W", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 80)]
            RD_EMP_NAME,

            /// <summary>
            /// RD ���u����
            /// </summary>
            [Column("RD_EMP_PHONENO", "RD ���u����", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 90)]
            RD_EMP_PHONENO,

            /// <summary>
            /// PVT �ƶq
            /// </summary>
            [Column("PVT_QTY", "PVT �ƶq", Asus.Data.DataType.Int, null, EnumAllowNull.Yes, 100)]
            PVT_QTY,

            /// <summary>
            /// PVT �ɶ�
            /// </summary>
            [Column("PVT_TIME", "PVT �ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 110)]
            PVT_TIME,

            /// <summary>
            /// PVT �Ͳ��a
            /// </summary>
            [Column("PVT_LOCATION", "PVT �Ͳ��a", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 120)]
            PVT_LOCATION,

            /// <summary>
            ///  MP �j�q�Ͳ��ɶ�
            /// </summary>
            [Column("MP_TIME", "MP �j�q�Ͳ��ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 130)]
            MP_TIME,

            /// <summary>
            /// MP Q1 �ƶq
            /// </summary>
            [Column("MP_Q1_QTY", "MP Q1 �ƶq", Asus.Data.DataType.Int, null, EnumAllowNull.Yes, 140)]
            MP_Q1_QTY,

            /// <summary>
            /// MP Q2 �ƶq
            /// </summary>
            [Column("MP_Q2_QTY", "MP Q2 �ƶq", Asus.Data.DataType.Int, null, EnumAllowNull.Yes, 150)]
            MP_Q2_QTY,

            /// <summary>
            /// �إߤH��
            /// </summary>
            [Column("CREATE_USER", "�إߤH��", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 160)]
            CREATE_USER,

            /// <summary>
            /// �إ߮ɶ�
            /// </summary>
            [Column("CREATE_DATE", "�إ߮ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 170)]
            CREATE_DATE,

            /// <summary>
            /// ��s�H��
            /// </summary>
            [Column("UPDATE_USER", "��s�H��", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 180)]
            UPDATE_USER,

            /// <summary>
            /// ��s�ɶ�
            /// </summary>
            [Column("UPDATE_DATE", "��s�ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 190)]
            UPDATE_DATE,

            /// <summary>
            /// �O�_�ϥ�
            /// </summary>
            [Column("IS_ENABLE", "�O�_�ϥ�", Asus.Data.DataType.Char, new object[] { 1 }, EnumAllowNull.No, 200)]
            IS_ENABLE,

            /// <summary>
            /// ���q�N��
            /// </summary>
            [Column("COMPANY_ID", "���q�N��", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 210)]
            COMPANY_ID
            
            
        }

        /// <summary>
        /// BOM PN �����Y�A��Table �O��BOM �P PN�����Y�A�ѮiBOM �{���Ө�
        /// 
        /// 
        /// grant select, insert, update, delete on CAERDSA.NPI_BOM_PN to SHINEWAVE;
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_BOM", ChineseName = "BOM�iPN�Ƹ����Y", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 20)]
        public enum NPI_BOM_PN
        {
            /// <summary>
            /// Form�N��
            /// </summary>
            [PrimaryKey()]
            [ForeignKey("NPI_FORM_MAIN", "FORM_ID")]
            [Column("FORM_ID", "Form�N��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            FORM_ID,     //NVARCHAR2(20) not null,

            /// <summary>
            /// ���ͥN��
            /// </summary>
            [Column("WORK_NO", "���ͥN��", Asus.Data.DataType.NVarChar, new object[] { 50 }, EnumAllowNull.No, 20)]
            WORK_NO,     //NVARCHAR2(50) not null,
            
            /// <summary>
            /// BOM
            /// </summary>
            [PrimaryKey()]
            [Column("ASUS_BOM", "BOM", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 30)]
            ASUS_BOM,    //NVARCHAR2(60) not null,
            
            /// <summary>
            /// ����Ƹ�
            /// </summary>
            [PrimaryKey()]
            [Column("ASUS_PN", "����Ƹ�", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 40)]
            ASUS_PN,     //NVARCHAR2(60) not null,
            
            /// <summary>
            /// �զX�ή�
            /// </summary>
            [Column("ASUS_PN", "�զX�ή�", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 50)]
            ASMBLY_QTY,  //NVARCHAR2(60) not null,
            
            /// <summary>
            /// �إߤH��
            /// </summary>
            [Column("CREATE_USER", "�إߤH��", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 160)]
            CREATE_USER,

            /// <summary>
            /// �إ߮ɶ�
            /// </summary>
            [Column("CREATE_DATE", "�إ߮ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 170)]
            CREATE_DATE,

            /// <summary>
            /// ��s�H��
            /// </summary>
            [Column("UPDATE_USER", "��s�H��", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 180)]
            UPDATE_USER,

            /// <summary>
            /// ��s�ɶ�
            /// </summary>
            [Column("UPDATE_DATE", "��s�ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 190)]
            UPDATE_DATE,
        }

        /// <summary>
        /// BOM BOOKING ��ƪ�
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_BOOKING", ChineseName = "BOM BOOKING ��ƪ�", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 30)]
        public enum NPI_BOOKING
        {
            /// <summary>
            /// PM���u�b��
            /// </summary>
            [PrimaryKey()]
            [Column("USER_ID", "PM���u�b��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)] 
            USER_ID,            //NVARCHAR2(20) not null,
            
            /// <summary>
            /// �iBOM ���渹
            /// </summary>
            [PrimaryKey()]
            [Column("BOM_ID", "BOM �N��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 20)] 
            BOM_ID,       //NVARCHAR2(20) not null,

            /// <summary>
            /// Form�N��
            /// </summary>
            [PrimaryKey()]
            [Column("FORM_ID", "Form�N��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 30)]
            FORM_ID,     //NVARCHAR2(20) not null,

            /// <summary>
            /// �ثe���A
            /// </summary>
            [Column("WORK_STATUS", "�ثe���A", Asus.Data.DataType.Int, null, EnumAllowNull.No, 40)]
            WORK_STATUS,  //NUMBER not null,

            /// <summary>
            /// BOOKING �ɶ�
            /// </summary>
            [Column("BOOKING_DATE", "BOOKING �ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 50)]
            BOOKING_DATE, //DATE not null,

             /// <summary>
             /// �إߤH��
             /// </summary>
             [Column("CREATE_USER", "�إߤH��", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 160)]
             CREATE_USER,

             /// <summary>
             /// �إ߮ɶ�
             /// </summary>
             [Column("CREATE_DATE", "�إ߮ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 170)]
             CREATE_DATE,

             /// <summary>
             /// ��s�H��
             /// </summary>
             [Column("UPDATE_USER", "��s�H��", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 180)]
             UPDATE_USER,

             /// <summary>
             /// ��s�ɶ�
             /// </summary>
             [Column("UPDATE_DATE", "��s�ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.Yes, 190)]
             UPDATE_DATE,

             /// <summary>
             /// PM�Ҧb���q
             /// </summary>
            [Column("COMPANY_ID", "PM�Ҧb���q", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.Yes, 210)]
             COMPANY_ID
        }

        /// <summary>
        /// ���O���
        /// grant select, insert, update, delete on CAERDSA.NPI_DOLLAR_TYPE to SHINEWAVE;
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_DOLLAR_TYPE", ChineseName = "���O���", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 40)]
        public enum NPI_DOLLAR_TYPE
        {
            /// <summary>
            /// ���O�N��
            /// </summary>
            [PrimaryKey()]
            [Column("DOLLAR_TYPEID", "���O�N��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)] 
             DOLLAR_TYPEID,   //NVARCHAR2(20) not null,

            /// <summary>
             /// ���O�W��
            /// </summary>
            [PrimaryKey()]
            [Column("DOLLAR_TYPENAME", "���O�W��", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 30)] 
            DOLLAR_TYPENAME, //NVARCHAR2(60) not null,

            /// <summary>
            /// ����
            /// </summary>
            [Column("DESCRIPTION", "����", Asus.Data.DataType.NVarChar, new object[] { 300 }, EnumAllowNull.Yes, 40)] 
            DESCRIPTION,     //NVARCHAR2(300),
              /// <summary>
              /// ��s�H��
              /// </summary>
              [Column("UPDATE_USER", "��s�H��", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 180)]
              UPDATE_USER,

              /// <summary>
              /// ��s�ɶ�
              /// </summary>
              [Column("UPDATE_DATE", "��s�ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 190)]
              UPDATE_DATE,
        }

        /// <summary>
        /// EMS ���@�{��
        /// </summary>
        [Action(Seq = 1, Control = EnumDbControl.Table, Mode = EnumDbMode.Create)]
        [Table(TableName = "NPI_EMS", ChineseName = "EMS ���@�{��", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 50)]
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
            /// ��s�H��
            /// </summary>
            [Column("UPDATE_USER", "��s�H��", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 40)]
            UPDATE_USER,

            /// <summary>
            /// ��s�ɶ�
            /// </summary>
            [Column("UPDATE_TIME", "��s�ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 50)]
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
        [Table(TableName = "NPI_FORM_MAIN", ChineseName = "NPI �iBOM �D��", TableSpace = "TP_RD", IndexSpace = "INDX_RD", Seq = 50)]
        public enum NPI_FORM_MAIN
        {
            /// <summary>
            /// Form�N��
            /// </summary>
            [PrimaryKey()]
            [Column("FORM_ID", "Form�N��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            FORM_ID,     //NVARCHAR2(20) not null,

            [Column("FORM_DATE", "Form ���", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 20)]
            FORM_DATE,   //DATE not null,

            /// <summary>
            /// �إߤH��
            /// </summary>
            [Column("CREATE_USER", "�إߤH��", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 30)]
            CREATE_USER,

            /// <summary>
            /// �إ߮ɶ�
            /// </summary>
            [Column("CREATE_DATE", "�إ߮ɶ�", Asus.Data.DataType.DateTime, null, EnumAllowNull.No, 40)]
            CREATE_DATE,

            /// <summary>
            /// �O�_�ϥ�
            /// </summary>
            [Column("FORM_STATUS", "FORM���AN=�|������ Y=�w����", Asus.Data.DataType.Char, new object[] { 1 }, EnumAllowNull.No, 50)]
            FORM_STATUS //CHAR(1) default 'N'
        }


        /// <summary>
        /// NPI Form PN
        /// grant select, insert, update, delete on CAERDSA.NPI_FORM_PN to SHINEWAVE;
        /// </summary>
        public enum NPI_FORM_PN
        {
            /// <summary>
            /// Form�N��
            /// </summary>
            [PrimaryKey()]
            [Column("FORM_ID", "Form�N��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            FORM_ID,     //NVARCHAR2(20) not null,

            /// <summary>
            /// ����Ƹ�
            /// </summary>
            [PrimaryKey()]
            [Column("ASUS_PN", "����Ƹ�", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 20)]
            ASUS_PN,             //NVARCHAR2(60) not null,

            /// <summary>
            /// �~�W
            /// </summary>
            [Column("PART_DESC1", "�~�W", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 30)]
            PART_DESC1,          //NVARCHAR2(200),

            /// <summary>
            /// �W��
            /// </summary>
            [Column("PART_DESC2", "�W��", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 40)]
            PART_DESC2,          //NVARCHAR2(200),

            /// <summary>
            /// LONGTERM_WEEK
            /// </summary>
            [Column("LONGTERM_WEEK", "long L/T(weeks)", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 50)]
            LONGTERM_WEEK,       //NVARCHAR2(20),

            /// <summary>
            /// �Ƹ��ݩ�
            /// </summary>
            [Column("PN_PROPERTY", "�Ƹ��ݩʡCRef(NPI_PN_Property)", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 60)]
            PN_PROPERTY,         //NVARCHAR2(20),

            /// <summary>
            /// �[�J�ĤG�ӷ�
            /// </summary>
            [Column("ADD2_SOURCE", "�[�J�ĤG�ӷ��CRef(NPI_PN_Add2Source)", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.Yes, 70)]
            ADD2_SOURCE,         //NVARCHAR2(20),

            /// <summary>
            /// �[�J�ĤG�ӷ��Ƶ�
            /// </summary>
            [Column("ADD2_SOURCE_COMMENT", "�[�J�ĤG�ӷ��Ƶ�", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 80)]
            ADD2_SOURCE_COMMENT, //NVARCHAR2(200),

            /// <summary>
            /// EOL�Ƶ�
            /// </summary>
            [Column("EOL_COMMENT", "EOL�Ƶ�", Asus.Data.DataType.NVarChar, new object[] { 200 }, EnumAllowNull.Yes, 90)]
            EOL_COMMENT,         //NVARCHAR2(200),

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
            RISKBUY             //CHAR(1)
        }

        /// <summary>
        /// NPI PM ����ƪ�
        /// grant select, insert, update, delete on CAERDSA.NPI_FORM_SUB to SHINEWAVE;
        /// </summary>
        public enum NPI_FORM_SUB
        {
            /// <summary>
            /// Form�N��
            /// </summary>
            [PrimaryKey()]
            [Column("FORM_ID", "Form�N��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 10)]
            FORM_ID,     //NVARCHAR2(20) not null,

            /// <summary>
            /// �t�dPM���u�u��
            /// </summary>
            [PrimaryKey()]
            [Column("PM_USER_ID", "�t�dPM���u�u��", Asus.Data.DataType.NVarChar, new object[] { 20 }, EnumAllowNull.No, 20)]
             PM_USER_ID,    //NVARCHAR2(20) not null,

             /// <summary>
             /// �t�dPM���u���q
             /// </summary>
             [PrimaryKey()]
            [Column("PM_COMPANY_ID", "�t�dPM���u���q", Asus.Data.DataType.NVarChar, new object[] { 60 }, EnumAllowNull.No, 30)]
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
