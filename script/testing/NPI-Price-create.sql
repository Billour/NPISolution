create table caerdsa.NPI_DOLLAR_TYPE
(
  DOLLAR_TYPEID   NVARCHAR2(20) not null,
  DOLLAR_TYPENAME NVARCHAR2(60) not null,
  DESCRIPTION     NVARCHAR2(300),
  UPDATE_USER     NVARCHAR2(20) not null,
  UPDATE_TIME     DATE not null
)
tablespace TP_RD;
  
comment on column caerdsa.NPI_DOLLAR_TYPE.DOLLAR_TYPEID  is '幣別代號';
comment on column caerdsa.NPI_DOLLAR_TYPE.DOLLAR_TYPENAME  is '幣別名稱';
comment on column caerdsa.NPI_DOLLAR_TYPE.DESCRIPTION  is '說明';
comment on column caerdsa.NPI_DOLLAR_TYPE.UPDATE_USER  is '更新人員';
comment on column caerdsa.NPI_DOLLAR_TYPE.UPDATE_TIME  is '更新時間';
 
alter table caerdsa.NPI_DOLLAR_TYPE
  add constraint PK_NPI_DOLLAR_TYPE primary key (DOLLAR_TYPEID)
  using index  tablespace indx_rd;


create table caerdsa.NPI_PNPRICE
(
  PN              NVARCHAR2(60) not null,
  YEARQ           NVARCHAR2(20) not null,
  IS_CONFIRM      CHAR(1) not null,
  IS_SEND         CHAR(1) not null,
  DOLLAR_TYPE     NVARCHAR2(20) not null,
  LOCATION_SITE   NVARCHAR2(20) not null,
  TIPTOP_PRICE    NUMBER not null,
  QUATATION_PRICE NUMBER,
  EFFECT_DATE     DATE not null,
  DISABLE_DATE    DATE not null,
  CREATE_USER     NVARCHAR2(20) not null,
  CREATE_TIME     DATE not null,
  CONFIRM_USER    NVARCHAR2(20),
  CONFIRM_TIME    DATE,
  SEND_USER       NVARCHAR2(20),
  SEND_TIME       DATE
)
tablespace TP_RD;
  
comment on column caerdsa.NPI_PNPRICE.PN  is '元件料號';
comment on column caerdsa.NPI_PNPRICE.YEARQ  is '年度2008Q4';
comment on column caerdsa.NPI_PNPRICE.IS_CONFIRM  is '是否已經由TipTop確認過 Y/N';
comment on column caerdsa.NPI_PNPRICE.IS_SEND  is '是否已經將資料送至eQuatation Y/N';
comment on column caerdsa.NPI_PNPRICE.DOLLAR_TYPE  is '幣別';
comment on column caerdsa.NPI_PNPRICE.LOCATION_SITE  is '生產地 Ref(NPI_EMS)';
comment on column caerdsa.NPI_PNPRICE.TIPTOP_PRICE  is 'TipTop議價金額';
comment on column caerdsa.NPI_PNPRICE.QUATATION_PRICE  is 'eQuatation金額';
comment on column caerdsa.NPI_PNPRICE.EFFECT_DATE  is 'PN生效日';
comment on column caerdsa.NPI_PNPRICE.DISABLE_DATE  is 'PN失效日';
comment on column caerdsa.NPI_PNPRICE.CREATE_USER  is '建立人員';
comment on column caerdsa.NPI_PNPRICE.CREATE_TIME  is '建立時間';
comment on column caerdsa.NPI_PNPRICE.CONFIRM_USER  is '確認人員';
comment on column caerdsa.NPI_PNPRICE.CONFIRM_TIME  is '確認時間';
comment on column caerdsa.NPI_PNPRICE.SEND_USER  is '送至人員';
comment on column caerdsa.NPI_PNPRICE.SEND_TIME  is '送至時間';

alter table caerdsa.NPI_PNPRICE
  add constraint PK_NPI_PNPRICE primary key (PN, YEARQ)
  using index  tablespace indx_rd;
  
alter table caerdsa.NPI_PNPRICE
  add constraint FK_NPI_DOLLARTYPE foreign key (DOLLAR_TYPE)
  references caerdsa.NPI_DOLLAR_TYPE (DOLLAR_TYPEID);
alter table caerdsa.NPI_PNPRICE
  add constraint FK_NPI_EMS foreign key (LOCATION_SITE)
  references caerdsa.NPI_EMS (EMS_CODE);
  
 CREATE SYNONYM NPI_DOLLAR_TYPE FOR caerdsa.NPI_DOLLAR_TYPE;
 CREATE SYNONYM NPI_PNPRICE 	FOR caerdsa.NPI_PNPRICE;
 
 grant select, insert, update, delete on caerdsa.NPI_DOLLAR_TYPE to shinewave;
 grant select, insert, update, delete on caerdsa.NPI_PNPRICE to shinewave;

insert into caerdsa.NPI_DOLLAR_TYPE (DOLLAR_TYPEID, DOLLAR_TYPENAME, DESCRIPTION, UPDATE_USER, UPDATE_TIME)
values ('USD', '美金', '', 'System', to_date('17-12-2008', 'dd-mm-yyyy'));
insert into caerdsa.NPI_DOLLAR_TYPE (DOLLAR_TYPEID, DOLLAR_TYPENAME, DESCRIPTION, UPDATE_USER, UPDATE_TIME)
values ('RMB', '人民幣', '', 'System', to_date('17-12-2008', 'dd-mm-yyyy'));