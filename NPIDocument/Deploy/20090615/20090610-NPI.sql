create table caerdsa.NPI_Main
(
  Main_Id  nvarchar2(20) not null ,
  Main_Name  nvarchar2(60) not null ,
  Main_Desc  nvarchar2(300),
  Work_Status  char(1) not null ,
  Create_User  nvarchar2(20) not null ,
  Create_Time  date not null ,
  Update_User  nvarchar2(20),
  Update_Time  date
) TABLESPACE TP_RD;


comment on table caerdsa.NPI_Main  is 'NPI�D��';
comment on column caerdsa.NPI_Main.Main_Id  is 'Main_Id';
comment on column caerdsa.NPI_Main.Main_Name  is 'Main_Name';
comment on column caerdsa.NPI_Main.Main_Desc  is 'Main_Desc';
comment on column caerdsa.NPI_Main.Work_Status  is '�ثe���A';
comment on column caerdsa.NPI_Main.Create_User  is '�s�W�H��';
comment on column caerdsa.NPI_Main.Create_Time  is '�s�W�ɶ�';
comment on column caerdsa.NPI_Main.Update_User  is '�ק�H��';
comment on column caerdsa.NPI_Main.Update_Time  is '�ק�ɶ�';


alter table caerdsa.NPI_Main add constraint PKNPI_Main primary key (Main_Id)  using index tablespace INDX_RD;




create table caerdsa.NPI_Main_Map
(
  Main_Id  nvarchar2(20) not null ,
  FORM_ID  nvarchar2(20) not null ,
  Work_Status  char(1) not null ,
  Create_User  nvarchar2(20) not null ,
  Create_Time  date not null ,
  Update_User  nvarchar2(20),
  Update_Time  date
) TABLESPACE TP_RD;


comment on table caerdsa.NPI_Main_Map  is 'NPI�D�ɹ�M��';
comment on column caerdsa.NPI_Main_Map.Main_Id  is 'Main_Id';
comment on column caerdsa.NPI_Main_Map.FORM_ID  is 'Form�N��';
comment on column caerdsa.NPI_Main_Map.Work_Status  is '�ثe���A';
comment on column caerdsa.NPI_Main_Map.Create_User  is '�s�W�H��';
comment on column caerdsa.NPI_Main_Map.Create_Time  is '�s�W�ɶ�';
comment on column caerdsa.NPI_Main_Map.Update_User  is '�ק�H��';
comment on column caerdsa.NPI_Main_Map.Update_Time  is '�ק�ɶ�';


alter table caerdsa.NPI_Main_Map add constraint PKNPI_Main_Map primary key (Main_Id,FORM_ID)  using index tablespace INDX_RD;




create table caerdsa.NPI_Main_PN
(
  Main_Id  nvarchar2(20) not null ,
  ASUS_PN  nvarchar2(60) not null ,
  PART_DESC1  nvarchar2(200),
  PART_DESC2  nvarchar2(200),
  LONGTERM_WEEK  nvarchar2(20),
  PN_PROPERTY  nvarchar2(20),
  ADD2_SOURCE  nvarchar2(20),
  ADD2_SOURCE_COMMENT  nvarchar2(200),
  EOL_COMMENT  nvarchar2(200),
  CREATE_USER  nvarchar2(60) not null ,
  CREATE_DATE  date not null ,
  UPDATE_USER  nvarchar2(60),
  UPDATE_DATE  date,
  ALERT  char(1) not null ,
  ASSEMBLY_NO  nvarchar2(200),
  ASSEMBLY_TYPE  char(1) not null ,
  RISKBUY  char(1) not null ,
  Action_Date  nvarchar2(20)
) TABLESPACE TP_RD;


comment on table caerdsa.NPI_Main_PN  is 'NPI�D�ɮƸ���M��';
comment on column caerdsa.NPI_Main_PN.Main_Id  is 'Main_Id';
comment on column caerdsa.NPI_Main_PN.ASUS_PN  is '����Ƹ�';
comment on column caerdsa.NPI_Main_PN.PART_DESC1  is '�~�W';
comment on column caerdsa.NPI_Main_PN.PART_DESC2  is '�W��';
comment on column caerdsa.NPI_Main_PN.LONGTERM_WEEK  is 'long L/T(weeks)';
comment on column caerdsa.NPI_Main_PN.PN_PROPERTY  is '�Ƹ��ݩʡCRef(NPI_PN_Property)';
comment on column caerdsa.NPI_Main_PN.ADD2_SOURCE  is '�[�J�ĤG�ӷ��CRef(NPI_PN_Add2Source)';
comment on column caerdsa.NPI_Main_PN.ADD2_SOURCE_COMMENT  is '�[�J�ĤG�ӷ��Ƶ�';
comment on column caerdsa.NPI_Main_PN.EOL_COMMENT  is 'EOL�Ƶ�';
comment on column caerdsa.NPI_Main_PN.CREATE_USER  is '�إߤH��';
comment on column caerdsa.NPI_Main_PN.CREATE_DATE  is '�إ߮ɶ�';
comment on column caerdsa.NPI_Main_PN.UPDATE_USER  is '��s�H��';
comment on column caerdsa.NPI_Main_PN.UPDATE_DATE  is '��s�ɶ�';
comment on column caerdsa.NPI_Main_PN.ALERT  is '�O�_����';
comment on column caerdsa.NPI_Main_PN.ASSEMBLY_NO  is '�Ƹ��s��';
comment on column caerdsa.NPI_Main_PN.ASSEMBLY_TYPE  is '�D/���N��(N=�D�� S=���N��)';
comment on column caerdsa.NPI_Main_PN.RISKBUY  is 'RiskBuy(Y=�O,N=���O)';
comment on column caerdsa.NPI_Main_PN.Action_Date  is '���N�ưe���';


alter table caerdsa.NPI_Main_PN add constraint PKNPI_Main_PN primary key (Main_Id,ASUS_PN)  using index tablespace INDX_RD;

grant select, insert, update, delete on caerdsa.NPI_Main to shinewave;
grant select, insert, update, delete on caerdsa.NPI_Main_Map to shinewave;
grant select, insert, update, delete on caerdsa.NPI_Main_PN to shinewave;






