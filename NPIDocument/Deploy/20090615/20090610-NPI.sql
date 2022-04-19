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


comment on table caerdsa.NPI_Main  is 'NPI主檔';
comment on column caerdsa.NPI_Main.Main_Id  is 'Main_Id';
comment on column caerdsa.NPI_Main.Main_Name  is 'Main_Name';
comment on column caerdsa.NPI_Main.Main_Desc  is 'Main_Desc';
comment on column caerdsa.NPI_Main.Work_Status  is '目前狀態';
comment on column caerdsa.NPI_Main.Create_User  is '新增人員';
comment on column caerdsa.NPI_Main.Create_Time  is '新增時間';
comment on column caerdsa.NPI_Main.Update_User  is '修改人員';
comment on column caerdsa.NPI_Main.Update_Time  is '修改時間';


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


comment on table caerdsa.NPI_Main_Map  is 'NPI主檔對映表';
comment on column caerdsa.NPI_Main_Map.Main_Id  is 'Main_Id';
comment on column caerdsa.NPI_Main_Map.FORM_ID  is 'Form代號';
comment on column caerdsa.NPI_Main_Map.Work_Status  is '目前狀態';
comment on column caerdsa.NPI_Main_Map.Create_User  is '新增人員';
comment on column caerdsa.NPI_Main_Map.Create_Time  is '新增時間';
comment on column caerdsa.NPI_Main_Map.Update_User  is '修改人員';
comment on column caerdsa.NPI_Main_Map.Update_Time  is '修改時間';


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


comment on table caerdsa.NPI_Main_PN  is 'NPI主檔料號對映表';
comment on column caerdsa.NPI_Main_PN.Main_Id  is 'Main_Id';
comment on column caerdsa.NPI_Main_PN.ASUS_PN  is '元件料號';
comment on column caerdsa.NPI_Main_PN.PART_DESC1  is '品名';
comment on column caerdsa.NPI_Main_PN.PART_DESC2  is '規格';
comment on column caerdsa.NPI_Main_PN.LONGTERM_WEEK  is 'long L/T(weeks)';
comment on column caerdsa.NPI_Main_PN.PN_PROPERTY  is '料號屬性。Ref(NPI_PN_Property)';
comment on column caerdsa.NPI_Main_PN.ADD2_SOURCE  is '加入第二來源。Ref(NPI_PN_Add2Source)';
comment on column caerdsa.NPI_Main_PN.ADD2_SOURCE_COMMENT  is '加入第二來源備註';
comment on column caerdsa.NPI_Main_PN.EOL_COMMENT  is 'EOL備註';
comment on column caerdsa.NPI_Main_PN.CREATE_USER  is '建立人員';
comment on column caerdsa.NPI_Main_PN.CREATE_DATE  is '建立時間';
comment on column caerdsa.NPI_Main_PN.UPDATE_USER  is '更新人員';
comment on column caerdsa.NPI_Main_PN.UPDATE_DATE  is '更新時間';
comment on column caerdsa.NPI_Main_PN.ALERT  is '是否提醒';
comment on column caerdsa.NPI_Main_PN.ASSEMBLY_NO  is '料號群組';
comment on column caerdsa.NPI_Main_PN.ASSEMBLY_TYPE  is '主/替代料(N=主料 S=替代料)';
comment on column caerdsa.NPI_Main_PN.RISKBUY  is 'RiskBuy(Y=是,N=不是)';
comment on column caerdsa.NPI_Main_PN.Action_Date  is '替代料送件日';


alter table caerdsa.NPI_Main_PN add constraint PKNPI_Main_PN primary key (Main_Id,ASUS_PN)  using index tablespace INDX_RD;

grant select, insert, update, delete on caerdsa.NPI_Main to shinewave;
grant select, insert, update, delete on caerdsa.NPI_Main_Map to shinewave;
grant select, insert, update, delete on caerdsa.NPI_Main_PN to shinewave;






