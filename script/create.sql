prompt PL/SQL Developer import file
prompt Created on 2008年11月7日 by Wen-Bin_Tsai
set feedback off
set define off
prompt Creating NPI_BOM...
create table NPI_BOM
(
  USER_ID        NVARCHAR2(20) not null,
  BOM_ID         NVARCHAR2(20) not null,
  BOM_NAME       NVARCHAR2(60) not null,
  BOM_STATUS     NVARCHAR2(60),
  BOM_DESC       NVARCHAR2(60),
  BOM_REVISION   NVARCHAR2(20),
  RD_EMP_ID      NVARCHAR2(20),
  RD_EMP_NAME    NVARCHAR2(60),
  RD_EMP_PHONENO NVARCHAR2(60),
  PVT_QTY        NUMBER,
  PVT_TIME       DATE,
  PVT_LOCATION   NVARCHAR2(60),
  MP_TIME        DATE,
  MP_Q1_QTY      NUMBER,
  MP_Q2_QTY      NUMBER,
  CREATE_USER    NVARCHAR2(60),
  CREATE_DATE    DATE not null,
  UPDATE_USER    NVARCHAR2(60) not null,
  UPDATE_DATE    DATE not null,
  IS_ENABLE      CHAR(1) not null,
  COMPANY_ID     NVARCHAR2(60)
)
tablespace TOOLS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on column NPI_BOM.USER_ID
  is '員工帳號';
comment on column NPI_BOM.BOM_ID
  is 'BOM 型號';
comment on column NPI_BOM.BOM_NAME
  is 'BOM名稱';
comment on column NPI_BOM.BOM_STATUS
  is 'BOM 狀態';
comment on column NPI_BOM.BOM_DESC
  is 'BOM 說明';
comment on column NPI_BOM.BOM_REVISION
  is 'BOM 版本';
comment on column NPI_BOM.RD_EMP_ID
  is 'RD 員工帳號';
comment on column NPI_BOM.RD_EMP_NAME
  is 'RD 員工姓名';
comment on column NPI_BOM.RD_EMP_PHONENO
  is 'RD 員工分機';
comment on column NPI_BOM.PVT_QTY
  is 'PVT 數量';
comment on column NPI_BOM.PVT_TIME
  is 'PVT 時間';
comment on column NPI_BOM.PVT_LOCATION
  is 'PVT 生產地';
comment on column NPI_BOM.MP_TIME
  is 'MP 大量生產時間';
comment on column NPI_BOM.MP_Q1_QTY
  is 'MP Q1 數量';
comment on column NPI_BOM.MP_Q2_QTY
  is 'MP Q2 數量';
comment on column NPI_BOM.CREATE_USER
  is '建立人員';
comment on column NPI_BOM.CREATE_DATE
  is '建立時間';
comment on column NPI_BOM.UPDATE_USER
  is '更新人員';
comment on column NPI_BOM.UPDATE_DATE
  is '更新時間';
comment on column NPI_BOM.IS_ENABLE
  is '是否使用';
comment on column NPI_BOM.COMPANY_ID
  is '公司代號';
alter table NPI_BOM
  add constraint PK_BOM primary key (USER_ID, BOM_ID)
  using index 
  tablespace TOOLS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );

prompt Creating NPI_FORM_MAIN...
create table NPI_FORM_MAIN
(
  FORM_ID     NVARCHAR2(20) not null,
  FORM_DATE   DATE not null,
  CREATE_USER NVARCHAR2(20) not null,
  CREATE_DATE DATE,
  FORM_STATUS CHAR(1) default 'N'
)
tablespace TOOLS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on table NPI_FORM_MAIN
  is 'NPI 表單主檔';
comment on column NPI_FORM_MAIN.FORM_ID
  is '表單代號(yyyyMMddHHmmss)';
comment on column NPI_FORM_MAIN.FORM_DATE
  is '表單產生日期';
comment on column NPI_FORM_MAIN.CREATE_USER
  is '新增人員';
comment on column NPI_FORM_MAIN.CREATE_DATE
  is '新增日期';
comment on column NPI_FORM_MAIN.FORM_STATUS
  is 'FORM狀態N=尚未結案 Y=已結案';
alter table NPI_FORM_MAIN
  add constraint PK_NPI_FORM_MAIN primary key (FORM_ID)
  using index 
  tablespace TOOLS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );

prompt Creating NPI_BOM_PN...
create table NPI_BOM_PN
(
  FORM_ID     NVARCHAR2(20) not null,
  WORK_NO     NVARCHAR2(50) not null,
  ASUS_BOM    NVARCHAR2(60) not null,
  ASUS_PN     NVARCHAR2(60) not null,
  ASMBLY_QTY  NVARCHAR2(60) not null,
  CREATE_USER NVARCHAR2(20) not null,
  CREATE_DATE DATE not null,
  UPDATE_USER NVARCHAR2(20) not null,
  UPDATE_DATE DATE not null
)
tablespace TOOLS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on column NPI_BOM_PN.FORM_ID
  is 'Form代號';
comment on column NPI_BOM_PN.WORK_NO
  is '產生代號';
comment on column NPI_BOM_PN.ASUS_BOM
  is 'BOM';
comment on column NPI_BOM_PN.ASUS_PN
  is '元件料號';
comment on column NPI_BOM_PN.ASMBLY_QTY
  is '組合用料';
comment on column NPI_BOM_PN.CREATE_USER
  is '新增人員';
comment on column NPI_BOM_PN.CREATE_DATE
  is '新增日期';
comment on column NPI_BOM_PN.UPDATE_USER
  is '更新人員';
comment on column NPI_BOM_PN.UPDATE_DATE
  is '更新日期';
alter table NPI_BOM_PN
  add constraint PK_NPI_BOM_PN primary key (FORM_ID, ASUS_BOM, ASUS_PN)
  using index 
  tablespace TOOLS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
alter table NPI_BOM_PN
  add constraint FK_NPI_BOM_PN_FORM foreign key (FORM_ID)
  references NPI_FORM_MAIN (FORM_ID);

prompt Creating NPI_BOOKING...
create table NPI_BOOKING
(
  USER_ID      NVARCHAR2(20) not null,
  BOM_ID       NVARCHAR2(20) not null,
  FORM_ID      NVARCHAR2(20),
  WORK_STATUS  NUMBER not null,
  BOOKING_DATE DATE not null,
  CREATE_USER  NVARCHAR2(20) not null,
  CREATE_DATE  DATE not null,
  UPDATE_USER  NVARCHAR2(20) not null,
  UPDATE_DATE  DATE not null,
  COMPANY_ID   NVARCHAR2(60) not null
)
tablespace TOOLS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on table NPI_BOOKING
  is 'BOM BOOKING 資料表';
comment on column NPI_BOOKING.USER_ID
  is 'PM員工帳號';
comment on column NPI_BOOKING.BOM_ID
  is 'BOM 代號';
comment on column NPI_BOOKING.FORM_ID
  is '展BOM 的單號';
comment on column NPI_BOOKING.WORK_STATUS
  is '目前狀態';
comment on column NPI_BOOKING.BOOKING_DATE
  is 'BOOKING 時間';
comment on column NPI_BOOKING.CREATE_USER
  is '建立人員';
comment on column NPI_BOOKING.CREATE_DATE
  is '建立時間';
comment on column NPI_BOOKING.UPDATE_USER
  is '更新人員';
comment on column NPI_BOOKING.UPDATE_DATE
  is '更新時間';
comment on column NPI_BOOKING.COMPANY_ID
  is 'PM所在公司';
alter table NPI_BOOKING
  add constraint PK_BOMBOOKING primary key (USER_ID, BOM_ID)
  using index 
  tablespace TOOLS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );

prompt Creating NPI_PN_ADD2SOURCE...
create table NPI_PN_ADD2SOURCE
(
  SOURCE_ID   NVARCHAR2(20) not null,
  SOURCE_NAME NVARCHAR2(60) not null,
  IS_ENABLE   CHAR(1) not null,
  CREATE_USER NVARCHAR2(20) not null,
  CREATE_DATE DATE not null,
  UPDATE_USER NVARCHAR2(20) not null,
  UPDATE_DATE DATE
)
tablespace TOOLS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on column NPI_PN_ADD2SOURCE.SOURCE_ID
  is '第二來源代號';
comment on column NPI_PN_ADD2SOURCE.SOURCE_NAME
  is '第二來源名稱';
comment on column NPI_PN_ADD2SOURCE.IS_ENABLE
  is '是否啟用';
comment on column NPI_PN_ADD2SOURCE.CREATE_USER
  is '新增人員';
comment on column NPI_PN_ADD2SOURCE.CREATE_DATE
  is '新增日期';
comment on column NPI_PN_ADD2SOURCE.UPDATE_USER
  is '更新人員';
comment on column NPI_PN_ADD2SOURCE.UPDATE_DATE
  is '更新日期';
alter table NPI_PN_ADD2SOURCE
  add constraint PK_NPI_PN_ADD2SOURCE primary key (SOURCE_ID)
  using index 
  tablespace TOOLS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );

prompt Creating NPI_PN_PROPERTY...
create table NPI_PN_PROPERTY
(
  PROPERTY_ID   NVARCHAR2(20) not null,
  PROPERTY_NAME NVARCHAR2(60) not null,
  IS_ENABLE     CHAR(1) not null,
  CREATE_USER   NVARCHAR2(20) not null,
  CREATE_DATE   DATE not null,
  UPDATE_USER   NVARCHAR2(20) not null,
  UPDATE_DATE   DATE not null
)
tablespace TOOLS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on column NPI_PN_PROPERTY.PROPERTY_ID
  is '屬性代號';
comment on column NPI_PN_PROPERTY.PROPERTY_NAME
  is '屬性名稱';
comment on column NPI_PN_PROPERTY.IS_ENABLE
  is '是否啟用';
comment on column NPI_PN_PROPERTY.CREATE_USER
  is '新增人員';
comment on column NPI_PN_PROPERTY.CREATE_DATE
  is '新增日期';
comment on column NPI_PN_PROPERTY.UPDATE_USER
  is '更新人員';
comment on column NPI_PN_PROPERTY.UPDATE_DATE
  is '更新日期';
alter table NPI_PN_PROPERTY
  add constraint PK_PN_PROPERTY primary key (PROPERTY_ID)
  using index 
  tablespace TOOLS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );

prompt Creating NPI_FORM_PN...
create table NPI_FORM_PN
(
  FORM_ID             NVARCHAR2(20) not null,
  ASUS_PN             NVARCHAR2(60) not null,
  PART_DESC1          NVARCHAR2(200),
  PART_DESC2          NVARCHAR2(200),
  LONGTERM_WEEK       NVARCHAR2(20),
  PN_PROPERTY         NVARCHAR2(20),
  ADD2_SOURCE         NVARCHAR2(20),
  ADD2_SOURCE_COMMENT NVARCHAR2(200),
  EOL_COMMENT         NVARCHAR2(200),
  CREATE_USER         NVARCHAR2(20) not null,
  CREATE_DATE         DATE not null,
  UPDATE_USER         NVARCHAR2(20) not null,
  UPDATE_DATE         DATE not null,
  ALERT               CHAR(1) default 'N',
  ASSEMBLY_NO         NVARCHAR2(200),
  ASSEMBLY_TYPE       CHAR(1),
  RISKBUY             CHAR(1)
)
tablespace TOOLS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on column NPI_FORM_PN.FORM_ID
  is '展開fORM ID';
comment on column NPI_FORM_PN.ASUS_PN
  is '元件料號';
comment on column NPI_FORM_PN.PART_DESC1
  is '品名';
comment on column NPI_FORM_PN.PART_DESC2
  is '規格';
comment on column NPI_FORM_PN.LONGTERM_WEEK
  is 'long L/T(weeks) 資料由Tip Top 來';
comment on column NPI_FORM_PN.PN_PROPERTY
  is '料號屬性。Ref(NPI_PN_Property)';
comment on column NPI_FORM_PN.ADD2_SOURCE
  is '加入第二來源。Ref(NPI_PN_Add2Source)';
comment on column NPI_FORM_PN.ADD2_SOURCE_COMMENT
  is '加入第二來源備註';
comment on column NPI_FORM_PN.EOL_COMMENT
  is 'EOL備註';
comment on column NPI_FORM_PN.CREATE_USER
  is '新增人員';
comment on column NPI_FORM_PN.CREATE_DATE
  is '新增日期';
comment on column NPI_FORM_PN.UPDATE_USER
  is '更新人員';
comment on column NPI_FORM_PN.UPDATE_DATE
  is '更新日期';
comment on column NPI_FORM_PN.ALERT
  is '是否提醒';
comment on column NPI_FORM_PN.ASSEMBLY_NO
  is '料號群組';
comment on column NPI_FORM_PN.ASSEMBLY_TYPE
  is '主/替代料(N=主料 S=替代料)';
comment on column NPI_FORM_PN.RISKBUY
  is 'RiskBuy(Y=是,N=不是)';
alter table NPI_FORM_PN
  add constraint PK_NPI_FORM_PN primary key (FORM_ID, ASUS_PN)
  using index 
  tablespace TOOLS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
alter table NPI_FORM_PN
  add constraint FK_NPI_FORM_PN_ADDSOUCER foreign key (ADD2_SOURCE)
  references NPI_PN_ADD2SOURCE (SOURCE_ID);
alter table NPI_FORM_PN
  add constraint FK_NPI_FORM_PN_PROPERTY foreign key (PN_PROPERTY)
  references NPI_PN_PROPERTY (PROPERTY_ID);

prompt Creating NPI_FORM_SUB...
create table NPI_FORM_SUB
(
  FORM_ID       NVARCHAR2(20) not null,
  PM_USER_ID    NVARCHAR2(20) not null,
  PM_COMPANY_ID NVARCHAR2(60) not null
)
tablespace TOOLS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on table NPI_FORM_SUB
  is 'NPI PM 表單資料表';
comment on column NPI_FORM_SUB.FORM_ID
  is '表單代號';
comment on column NPI_FORM_SUB.PM_USER_ID
  is '負責PM員工工號';
comment on column NPI_FORM_SUB.PM_COMPANY_ID
  is '負責PM員工公司';
alter table NPI_FORM_SUB
  add constraint PK_FORM_SUB primary key (FORM_ID, PM_USER_ID)
  using index 
  tablespace TOOLS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );

prompt Creating NPI_FORM_TEMP...
create table NPI_FORM_TEMP
(
  FORM_ID    NVARCHAR2(20) not null,
  USER_ID    NVARCHAR2(20) not null,
  COMPANY_ID NVARCHAR2(60) not null
)
tablespace TOOLS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
alter table NPI_FORM_TEMP
  add constraint PK_NPI_FORM_TEMP primary key (FORM_ID, USER_ID, COMPANY_ID)
  using index 
  tablespace TOOLS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );

prompt Creating NPI_PN_GROUP...
create table NPI_PN_GROUP
(
  GROUP_ID   NVARCHAR2(10) not null,
  GROUP_NAME NVARCHAR2(20)
)
tablespace TOOLS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on column NPI_PN_GROUP.GROUP_ID
  is '元件料號前置字元代號';
comment on column NPI_PN_GROUP.GROUP_NAME
  is '元件料號名稱';
alter table NPI_PN_GROUP
  add constraint PK_COMPONENT_ID primary key (GROUP_ID)
  using index 
  tablespace TOOLS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );

prompt Creating NPI_PN_SOURCER...
create table NPI_PN_SOURCER
(
  USER_ID    NVARCHAR2(20) not null,
  GROUP_ID   NVARCHAR2(20) not null,
  COMPANY_ID NVARCHAR2(60)
)
tablespace TOOLS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
alter table NPI_PN_SOURCER
  add constraint PK_NPI_PN_SOURCER_ID primary key (USER_ID, GROUP_ID)
  using index 
  tablespace TOOLS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );

prompt Creating NPI_ROLE...
create table NPI_ROLE
(
  ROLE_ID     NVARCHAR2(20) not null,
  ROLE_NAME   NVARCHAR2(60) not null,
  CREATE_DATE DATE not null,
  CREATE_USER NVARCHAR2(20) not null,
  UPDATE_DATE DATE not null,
  UPDATE_USER NVARCHAR2(20) not null
)
tablespace TOOLS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on column NPI_ROLE.ROLE_ID
  is '角色代號';
comment on column NPI_ROLE.ROLE_NAME
  is '角色名稱';
comment on column NPI_ROLE.CREATE_DATE
  is '建立時間';
comment on column NPI_ROLE.CREATE_USER
  is '建立人員';
comment on column NPI_ROLE.UPDATE_DATE
  is '更新時間';
comment on column NPI_ROLE.UPDATE_USER
  is '更新人員';
alter table NPI_ROLE
  add constraint PK_ROLE_ID primary key (ROLE_ID)
  using index 
  tablespace TOOLS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );

prompt Creating NPI_PRIVILEGE...
create table NPI_PRIVILEGE
(
  USER_ID     NVARCHAR2(60) not null,
  USER_NAME   NVARCHAR2(60) not null,
  ROLE_ID     NVARCHAR2(20) not null,
  CREATE_DATE DATE not null,
  CREATE_USER NVARCHAR2(20) not null,
  UPDATE_DATE DATE not null,
  UPDATE_USER NVARCHAR2(20) not null,
  IS_ENABLE   CHAR(1) not null,
  COMPANY_ID  NVARCHAR2(100) not null
)
tablespace TOOLS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
comment on table NPI_PRIVILEGE
  is 'NPI 權限列表';
comment on column NPI_PRIVILEGE.USER_ID
  is '員工工號';
comment on column NPI_PRIVILEGE.USER_NAME
  is '員工名稱';
comment on column NPI_PRIVILEGE.ROLE_ID
  is '角色';
comment on column NPI_PRIVILEGE.CREATE_DATE
  is '新增日期';
comment on column NPI_PRIVILEGE.CREATE_USER
  is '新增人員';
comment on column NPI_PRIVILEGE.UPDATE_DATE
  is '更新時間';
comment on column NPI_PRIVILEGE.UPDATE_USER
  is '更新人員';
comment on column NPI_PRIVILEGE.IS_ENABLE
  is '是否啟用Y/N';
comment on column NPI_PRIVILEGE.COMPANY_ID
  is '公司';
alter table NPI_PRIVILEGE
  add constraint PK_USER_ROLE primary key (USER_ID, ROLE_ID, COMPANY_ID)
  using index 
  tablespace TOOLS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
alter table NPI_PRIVILEGE
  add constraint FK_USER_ROLE_ROLE_ID foreign key (ROLE_ID)
  references NPI_ROLE (ROLE_ID);

prompt Disabling triggers for NPI_BOM...
alter table NPI_BOM disable all triggers;
prompt Disabling triggers for NPI_FORM_MAIN...
alter table NPI_FORM_MAIN disable all triggers;
prompt Disabling triggers for NPI_BOM_PN...
alter table NPI_BOM_PN disable all triggers;
prompt Disabling triggers for NPI_BOOKING...
alter table NPI_BOOKING disable all triggers;
prompt Disabling triggers for NPI_PN_ADD2SOURCE...
alter table NPI_PN_ADD2SOURCE disable all triggers;
prompt Disabling triggers for NPI_PN_PROPERTY...
alter table NPI_PN_PROPERTY disable all triggers;
prompt Disabling triggers for NPI_FORM_PN...
alter table NPI_FORM_PN disable all triggers;
prompt Disabling triggers for NPI_FORM_SUB...
alter table NPI_FORM_SUB disable all triggers;
prompt Disabling triggers for NPI_FORM_TEMP...
alter table NPI_FORM_TEMP disable all triggers;
prompt Disabling triggers for NPI_PN_GROUP...
alter table NPI_PN_GROUP disable all triggers;
prompt Disabling triggers for NPI_PN_SOURCER...
alter table NPI_PN_SOURCER disable all triggers;
prompt Disabling triggers for NPI_ROLE...
alter table NPI_ROLE disable all triggers;
prompt Disabling triggers for NPI_PRIVILEGE...
alter table NPI_PRIVILEGE disable all triggers;
prompt Disabling foreign key constraints for NPI_BOM_PN...
alter table NPI_BOM_PN disable constraint FK_NPI_BOM_PN_FORM;
prompt Disabling foreign key constraints for NPI_FORM_PN...
alter table NPI_FORM_PN disable constraint FK_NPI_FORM_PN_ADDSOUCER;
alter table NPI_FORM_PN disable constraint FK_NPI_FORM_PN_PROPERTY;
prompt Disabling foreign key constraints for NPI_PRIVILEGE...
alter table NPI_PRIVILEGE disable constraint FK_USER_ROLE_ROLE_ID;
prompt Deleting NPI_PRIVILEGE...
delete from NPI_PRIVILEGE;
commit;
prompt Deleting NPI_ROLE...
delete from NPI_ROLE;
commit;
prompt Deleting NPI_PN_SOURCER...
delete from NPI_PN_SOURCER;
commit;
prompt Deleting NPI_PN_GROUP...
delete from NPI_PN_GROUP;
commit;
prompt Deleting NPI_FORM_TEMP...
delete from NPI_FORM_TEMP;
commit;
prompt Deleting NPI_FORM_SUB...
delete from NPI_FORM_SUB;
commit;
prompt Deleting NPI_FORM_PN...
delete from NPI_FORM_PN;
commit;
prompt Deleting NPI_PN_PROPERTY...
delete from NPI_PN_PROPERTY;
commit;
prompt Deleting NPI_PN_ADD2SOURCE...
delete from NPI_PN_ADD2SOURCE;
commit;
prompt Deleting NPI_BOOKING...
delete from NPI_BOOKING;
commit;
prompt Deleting NPI_BOM_PN...
delete from NPI_BOM_PN;
commit;
prompt Deleting NPI_FORM_MAIN...
delete from NPI_FORM_MAIN;
commit;
prompt Deleting NPI_BOM...
delete from NPI_BOM;
commit;
prompt Loading NPI_PN_GROUP...
insert into NPI_PN_GROUP (GROUP_ID, GROUP_NAME)
values ('01', '01*CPU');
insert into NPI_PN_GROUP (GROUP_ID, GROUP_NAME)
values ('02', '02*Chip Set');
insert into NPI_PN_GROUP (GROUP_ID, GROUP_NAME)
values ('03', '03*Memory IC');
insert into NPI_PN_GROUP (GROUP_ID, GROUP_NAME)
values ('04', '04*System Component');
insert into NPI_PN_GROUP (GROUP_ID, GROUP_NAME)
values ('05', '05*Programable IC');
insert into NPI_PN_GROUP (GROUP_ID, GROUP_NAME)
values ('06', '06*IC');
insert into NPI_PN_GROUP (GROUP_ID, GROUP_NAME)
values ('07', '07*DISCRETE');
insert into NPI_PN_GROUP (GROUP_ID, GROUP_NAME)
values ('12', '12*CONNECTOR');
insert into NPI_PN_GROUP (GROUP_ID, GROUP_NAME)
values ('08', '08*PCB');
insert into NPI_PN_GROUP (GROUP_ID, GROUP_NAME)
values ('09', '09*INDUCTOR');
insert into NPI_PN_GROUP (GROUP_ID, GROUP_NAME)
values ('10', '10*RESISTOR');
insert into NPI_PN_GROUP (GROUP_ID, GROUP_NAME)
values ('11', '11*CAPACITOR');
insert into NPI_PN_GROUP (GROUP_ID, GROUP_NAME)
values ('13', '13*機構');
insert into NPI_PN_GROUP (GROUP_ID, GROUP_NAME)
values ('14', '14*CABLE');
insert into NPI_PN_GROUP (GROUP_ID, GROUP_NAME)
values ('15', '15*包材');
insert into NPI_PN_GROUP (GROUP_ID, GROUP_NAME)
values ('17', '17*STORAGE');
insert into NPI_PN_GROUP (GROUP_ID, GROUP_NAME)
values ('18', '18*DISPLAY');
commit;
prompt 17 records loaded
prompt Loading NPI_PN_SOURCER...
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801030', '02', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801030', '06', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18928', '02', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801028', '06', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801028', '07', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801826', '10', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18928', '01', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18928', '03', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18928', '04', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18928', '05', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18928', '06', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18928', '07', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18928', '08', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18928', '09', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18928', '10', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18928', '11', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18928', '12', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18928', '13', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18928', '14', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18928', '15', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18928', '17', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18928', '18', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P2879', '01', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P2879', '02', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P2879', '03', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P2879', '04', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P2879', '05', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P2879', '06', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P2879', '07', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P2879', '08', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P2879', '09', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P2879', '10', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P2879', '11', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P2879', '12', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P2879', '13', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P2879', '14', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P2879', '15', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P2879', '17', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P2879', '18', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801022', '06', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801022', '07', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8428', '01', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X15640', '02', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X15640', '06', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X16803', '02', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X15454', '06', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8454', '02', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8454', '03', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8454', '04', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X17734', '05', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X15631', '06', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X15454', '07', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8597', '06', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8597', '07', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P5854', '08', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18151', '08', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AA0800473', '08', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X17535', '13', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X16804', '09', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X16804', '10', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X16804', '11', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X17744', '12', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X17535', '12', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X15515', '13', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X19296', '13', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801027', '13', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801032', '13', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801029', '13', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8025', '14', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18076', '15', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801014', '15', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8094', '13', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X17175', '13', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X18908', '13', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8321', '14', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7903', '15', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6380', '18', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AA0800315', '18', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6395', '01', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6395', '02', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6395', '03', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6395', '04', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6395', '05', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6395', '06', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6395', '07', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6395', '08', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6395', '09', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6395', '10', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6395', '11', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6395', '12', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6395', '13', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6395', '14', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6395', '15', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6395', '17', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P6395', '18', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8100', '01', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8100', '02', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8100', '03', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8100', '04', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8100', '05', '13006');
commit;
prompt 100 records committed...
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8100', '06', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8100', '07', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8100', '08', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8100', '09', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8100', '10', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8100', '11', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8100', '12', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8100', '13', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8100', '14', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8100', '15', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8100', '17', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P8100', '18', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7313', '01', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7313', '02', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7313', '03', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7313', '04', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7313', '05', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7313', '06', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7313', '07', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7313', '08', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7313', '09', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7313', '10', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7313', '11', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7313', '12', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7313', '13', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7313', '14', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7313', '15', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7313', '17', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('P7313', '18', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('X15957', '17', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801023', '11', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801035', '12', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801272', '14', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801015', '04', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801018', '04', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801164', '04', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801024', '06', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801825', '09', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AA0800226', '02', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AH0801019', '02', '13006');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('23', '03', 'ASUSTECH');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('23', '04', 'ASUSTECH');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('23', '05', 'ASUSTECH');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('23', '06', 'ASUSTECH');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('23', '07', 'ASUSTECH');
insert into NPI_PN_SOURCER (USER_ID, GROUP_ID, COMPANY_ID)
values ('AA0800226', '01', '13006');
commit;
prompt 146 records loaded
prompt Loading NPI_ROLE...
insert into NPI_ROLE (ROLE_ID, ROLE_NAME, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER)
values ('Admin', '系統管理者', to_date('15-08-2008', 'dd-mm-yyyy'), 'Wen-Bin_Tsai', to_date('15-08-2008', 'dd-mm-yyyy'), 'Wen-Bin_Tsai');
insert into NPI_ROLE (ROLE_ID, ROLE_NAME, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER)
values ('Management', '管理者', to_date('15-08-2008', 'dd-mm-yyyy'), 'Wen-Bin_Tsai', to_date('15-08-2008', 'dd-mm-yyyy'), 'Wen-Bin_Tsai');
insert into NPI_ROLE (ROLE_ID, ROLE_NAME, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER)
values ('PM', 'PM', to_date('15-08-2008', 'dd-mm-yyyy'), 'Wen-Bin_Tsai', to_date('15-08-2008', 'dd-mm-yyyy'), 'Wen-Bin_Tsai');
insert into NPI_ROLE (ROLE_ID, ROLE_NAME, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER)
values ('Sourcer', '採購', to_date('15-08-2008', 'dd-mm-yyyy'), 'Wen-Bin_Tsai', to_date('15-08-2008', 'dd-mm-yyyy'), 'Wen-Bin_Tsai');
commit;
prompt 4 records loaded
prompt Loading NPI_PRIVILEGE...
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X18928', 'James1_Cheng(鄭耀國)', 'Management', to_date('25-08-2008', 'dd-mm-yyyy'), 'Wen-Bin_Tsai', to_date('25-08-2008 18:18:06', 'dd-mm-yyyy hh24:mi:ss'), 'James1_Cheng', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X18928', 'James1_Cheng(鄭耀國)', 'PM', to_date('25-08-2008 18:07:40', 'dd-mm-yyyy hh24:mi:ss'), 'James1_Cheng', to_date('17-09-2008 10:11:37', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'N', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X18928', 'James1_Cheng(鄭耀國)', 'Sourcer', to_date('25-08-2008 18:07:40', 'dd-mm-yyyy hh24:mi:ss'), 'James1_Cheng', to_date('27-10-2008 10:09:10', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AA0800553', 'Joey_Lin(林美君)', 'Sourcer', to_date('17-09-2008 10:19:21', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 11:42:53', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'N', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0801030', 'Lene_Li(黎雁)', 'Sourcer', to_date('17-10-2008', 'dd-mm-yyyy'), 'Sam_Chen', to_date('17-10-2008 16:18:07', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0801826', 'sandy_tao(陶從雪)', 'Sourcer', to_date('17-10-2008 16:32:00', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-10-2008 16:39:43', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P2879', 'Jo_Kuo(郭淑真)', 'Sourcer', to_date('27-10-2008 10:11:24', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('27-10-2008 10:11:24', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P8428', 'mrchris_lin(林奕男)', 'Sourcer', to_date('17-09-2008 11:43:32', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 11:43:32', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AA0800226', 'Sam_Chen(陳慶昇)', 'Sourcer', to_date('29-08-2008 15:13:25', 'dd-mm-yyyy hh24:mi:ss'), 'James1_Cheng', to_date('06-11-2008 16:17:28', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X15640', 'Elva_Hsu(許雅婷)', 'Sourcer', to_date('17-09-2008 11:47:57', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 11:47:57', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X16803', 'Tina_Wu(吳玉楨)', 'Sourcer', to_date('17-09-2008 11:50:24', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 11:50:24', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P8454', 'Grace1_Huang(黃靜儀)', 'Sourcer', to_date('17-09-2008 11:51:03', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 11:53:51', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X17734', 'Scott_Huang(黃政睿)', 'Sourcer', to_date('17-09-2008 11:54:34', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 11:54:34', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X15631', 'Ruby_Yen(顏桂汝)', 'Sourcer', to_date('17-09-2008 11:55:43', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 11:55:43', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X15454', 'Nick1_Cheng(鄭育榮)', 'Sourcer', to_date('17-09-2008 13:39:56', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:39:56', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P8597', 'Susi_Chao(趙詩柔)', 'Sourcer', to_date('17-09-2008 13:40:35', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:40:35', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P5854', 'T.N._Lin(林泰男)', 'Sourcer', to_date('17-09-2008 13:41:12', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:41:12', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X18151', 'Kerry_Wang(王淑美)', 'Sourcer', to_date('17-09-2008 13:41:48', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:41:48', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AA0800473', 'David_Soung(宋仁哲)', 'Sourcer', to_date('17-09-2008 13:42:01', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:42:01', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X16804', 'Alice_Yeh(葉秀珍)', 'Sourcer', to_date('17-09-2008 13:42:30', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:43:01', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X17744', 'Fone_Tsai(蔡銘峰)', 'Sourcer', to_date('17-09-2008 13:43:38', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:43:38', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X17535', 'Adam_Lin(林廷威)', 'Sourcer', to_date('17-09-2008 13:44:08', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:44:08', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X15515', 'Vincent1_Tsai(蔡岳璋)', 'Sourcer', to_date('17-09-2008 13:45:49', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:45:49', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X19296', 'Alex_Tseng(曾哲文)', 'Sourcer', to_date('17-09-2008 13:46:03', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:46:03', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0801027', 'Benny_Wei(魏巍)', 'Sourcer', to_date('17-09-2008 13:46:27', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:46:27', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0801032', '(嚴紅飛)', 'Sourcer', to_date('17-09-2008 13:46:56', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:46:56', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0801029', 'Geodern_Chen(陳先祝)', 'Sourcer', to_date('17-09-2008 13:47:09', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:47:09', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P8025', 'Simon_Chou(周君安)', 'Sourcer', to_date('17-09-2008 13:47:37', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:47:37', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X18076', 'Peter_Jong(鐘裕評)', 'Sourcer', to_date('17-09-2008 13:48:09', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:48:09', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0801014', 'Sofia_Zhou(周英)', 'Sourcer', to_date('17-09-2008 13:48:25', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:48:25', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P8094', 'Jason_Chen(陳重宇)', 'Sourcer', to_date('17-09-2008 13:50:10', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:50:10', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X17175', 'Sean1_Yang(楊智翔)', 'Sourcer', to_date('17-09-2008 13:50:54', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:50:54', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X18908', 'Soup_Tang(湯圭才)', 'Sourcer', to_date('17-09-2008 13:51:20', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:51:20', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P8321', 'Jaff_Chiou(邱立民)', 'Sourcer', to_date('17-09-2008 13:52:08', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:52:08', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P7903', 'Jeff_Chen(陳思維)', 'Sourcer', to_date('17-09-2008 13:52:37', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:52:37', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P6380', 'Kelly_Chuang(莊婷栩)', 'Sourcer', to_date('17-09-2008 13:53:13', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:53:13', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AA0800315', 'Alex3_Wang(王俊祥)', 'Sourcer', to_date('17-09-2008 13:53:31', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:53:31', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P6395', 'Bruce_You(游三奇)', 'Sourcer', to_date('17-09-2008 13:54:08', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:54:08', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P8100', 'Michael_hsu(許家銘)', 'Sourcer', to_date('17-09-2008 13:54:30', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:54:30', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P7313', 'marisa_wu(吳靜美)', 'Sourcer', to_date('17-09-2008 13:55:34', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:55:34', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X15957', 'Tiffany_Chang(張瑞玉)', 'Sourcer', to_date('17-09-2008 13:56:33', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 13:56:33', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0801023', 'Angela_Jin(靳偉克)', 'Sourcer', to_date('18-09-2008 15:24:06', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('18-09-2008 15:24:06', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0801019', 'Enya_Bo(柏基平)', 'Sourcer', to_date('18-09-2008 15:24:30', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-10-2008 16:48:38', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0801035', 'Winner_Wang(王金容)', 'Sourcer', to_date('18-09-2008 15:25:11', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('18-09-2008 15:25:11', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0801272', '(楊雅玲)', 'Sourcer', to_date('18-09-2008 15:27:08', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('18-09-2008 15:27:08', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P2879', 'Jo_Kuo(郭淑真)', 'PM', to_date('22-09-2008 11:30:38', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', to_date('22-09-2008 11:30:38', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0801015', 'Surfy_Ge(葛振潔)', 'Sourcer', to_date('18-09-2008 15:18:06', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('18-09-2008 15:18:06', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0801018', 'Kaola_Gao(高新棟)', 'Sourcer', to_date('18-09-2008 15:18:32', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('18-09-2008 15:18:32', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0801164', 'Li-jun_Qian(錢麗君)', 'Sourcer', to_date('18-09-2008 15:18:59', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('18-09-2008 15:18:59', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0801024', 'June_Xia(夏娟)', 'Sourcer', to_date('18-09-2008 15:19:45', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('18-09-2008 15:19:45', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0801022', 'Jolin_Yin(尹麗)', 'Sourcer', to_date('18-09-2008 15:20:21', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('29-10-2008 10:20:20', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0801028', 'Enna_Shen(申賽芬)', 'Sourcer', to_date('18-09-2008 15:20:53', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-10-2008 16:34:54', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AA0800553', 'Joey_Lin(林美君)', 'PM', to_date('03-09-2008 10:45:56', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', to_date('03-09-2008 10:45:56', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X19120', 'Jodie_Hsu(許惠媜)', 'PM', to_date('03-09-2008 10:46:15', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', to_date('03-09-2008 10:46:15', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('900789', 'Linday_Zhang(張麗靜)', 'PM', to_date('03-09-2008 10:46:32', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', to_date('03-09-2008 10:46:32', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P6343', 'Chaka_Chen(陳亭萍)', 'PM', to_date('03-09-2008 10:46:48', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', to_date('03-09-2008 10:46:48', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P2879', 'Jo Kuo(郭淑真)', 'Management', to_date('25-08-2008', 'dd-mm-yyyy'), 'Wen-Bin_Tsai', to_date('25-08-2008 18:18:06', 'dd-mm-yyyy hh24:mi:ss'), 'James1_Cheng', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AA0800736', 'Jason3_Chuang(莊英杰)', 'PM', to_date('03-09-2008 10:47:27', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', to_date('03-09-2008 10:47:27', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X19690', 'Phoebe_Chen(陳盈君)', 'PM', to_date('03-09-2008 10:47:44', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', to_date('03-09-2008 10:47:44', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0800188', 'Catherine_Yue(岳芬)', 'PM', to_date('03-09-2008 10:48:02', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', to_date('03-09-2008 10:48:02', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X19685', 'Gillian_Lin(林佳慧)', 'PM', to_date('03-09-2008 10:48:39', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', to_date('03-09-2008 10:48:39', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P6345', 'Eva33_Hsu(徐婉毓)', 'PM', to_date('03-09-2008 10:49:00', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', to_date('03-09-2008 10:49:00', 'dd-mm-yyyy hh24:mi:ss'), 'Jo_Kuo', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AA0800226', 'Sam_Chen(陳慶昇)', 'Management', to_date('29-08-2008 15:13:25', 'dd-mm-yyyy hh24:mi:ss'), 'James1_Cheng', to_date('29-08-2008 15:13:25', 'dd-mm-yyyy hh24:mi:ss'), 'James1_Cheng', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('P9476', 'Robin_Huang(黃丞亨)', 'PM', to_date('17-09-2008 10:05:54', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 10:11:50', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'N', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AA0800226', 'Sam_Chen(陳慶昇)', 'PM', to_date('17-09-2008 10:30:28', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('18-09-2008 14:14:00', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('X18076', 'Peter_Jong(鐘裕評)', 'PM', to_date('17-09-2008 10:31:12', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('17-09-2008 10:33:13', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'N', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AA0800785', 'Boris_Chin(秦國雄)', 'Management', to_date('14-10-2008', 'dd-mm-yyyy'), 'Sam_Chen', to_date('14-10-2008', 'dd-mm-yyyy'), 'Sam_Chen', 'Y', '13006');
insert into NPI_PRIVILEGE (USER_ID, USER_NAME, ROLE_ID, CREATE_DATE, CREATE_USER, UPDATE_DATE, UPDATE_USER, IS_ENABLE, COMPANY_ID)
values ('AH0801825', 'Rachel_Cheung(張宇珂)', 'Sourcer', to_date('20-10-2008 16:16:15', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', to_date('20-10-2008 16:16:15', 'dd-mm-yyyy hh24:mi:ss'), 'Sam_Chen', 'Y', '13006');
commit;
prompt 68 records loaded
prompt Enabling foreign key constraints for NPI_BOM_PN...
alter table NPI_BOM_PN enable constraint FK_NPI_BOM_PN_FORM;
prompt Enabling foreign key constraints for NPI_FORM_PN...
alter table NPI_FORM_PN enable constraint FK_NPI_FORM_PN_ADDSOUCER;
alter table NPI_FORM_PN enable constraint FK_NPI_FORM_PN_PROPERTY;
prompt Enabling foreign key constraints for NPI_PRIVILEGE...
alter table NPI_PRIVILEGE enable constraint FK_USER_ROLE_ROLE_ID;
prompt Enabling triggers for NPI_BOM...
alter table NPI_BOM enable all triggers;
prompt Enabling triggers for NPI_FORM_MAIN...
alter table NPI_FORM_MAIN enable all triggers;
prompt Enabling triggers for NPI_BOM_PN...
alter table NPI_BOM_PN enable all triggers;
prompt Enabling triggers for NPI_BOOKING...
alter table NPI_BOOKING enable all triggers;
prompt Enabling triggers for NPI_PN_ADD2SOURCE...
alter table NPI_PN_ADD2SOURCE enable all triggers;
prompt Enabling triggers for NPI_PN_PROPERTY...
alter table NPI_PN_PROPERTY enable all triggers;
prompt Enabling triggers for NPI_FORM_PN...
alter table NPI_FORM_PN enable all triggers;
prompt Enabling triggers for NPI_FORM_SUB...
alter table NPI_FORM_SUB enable all triggers;
prompt Enabling triggers for NPI_FORM_TEMP...
alter table NPI_FORM_TEMP enable all triggers;
prompt Enabling triggers for NPI_PN_GROUP...
alter table NPI_PN_GROUP enable all triggers;
prompt Enabling triggers for NPI_PN_SOURCER...
alter table NPI_PN_SOURCER enable all triggers;
prompt Enabling triggers for NPI_ROLE...
alter table NPI_ROLE enable all triggers;
prompt Enabling triggers for NPI_PRIVILEGE...
alter table NPI_PRIVILEGE enable all triggers;
set feedback on
set define on
prompt Done.
