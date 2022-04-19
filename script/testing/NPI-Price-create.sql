create table caerdsa.NPI_DOLLAR_TYPE
(
  DOLLAR_TYPEID   NVARCHAR2(20) not null,
  DOLLAR_TYPENAME NVARCHAR2(60) not null,
  DESCRIPTION     NVARCHAR2(300),
  UPDATE_USER     NVARCHAR2(20) not null,
  UPDATE_TIME     DATE not null
)
tablespace TP_RD;
  
comment on column caerdsa.NPI_DOLLAR_TYPE.DOLLAR_TYPEID  is '���O�N��';
comment on column caerdsa.NPI_DOLLAR_TYPE.DOLLAR_TYPENAME  is '���O�W��';
comment on column caerdsa.NPI_DOLLAR_TYPE.DESCRIPTION  is '����';
comment on column caerdsa.NPI_DOLLAR_TYPE.UPDATE_USER  is '��s�H��';
comment on column caerdsa.NPI_DOLLAR_TYPE.UPDATE_TIME  is '��s�ɶ�';
 
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
  
comment on column caerdsa.NPI_PNPRICE.PN  is '����Ƹ�';
comment on column caerdsa.NPI_PNPRICE.YEARQ  is '�~��2008Q4';
comment on column caerdsa.NPI_PNPRICE.IS_CONFIRM  is '�O�_�w�g��TipTop�T�{�L Y/N';
comment on column caerdsa.NPI_PNPRICE.IS_SEND  is '�O�_�w�g�N��ưe��eQuatation Y/N';
comment on column caerdsa.NPI_PNPRICE.DOLLAR_TYPE  is '���O';
comment on column caerdsa.NPI_PNPRICE.LOCATION_SITE  is '�Ͳ��a Ref(NPI_EMS)';
comment on column caerdsa.NPI_PNPRICE.TIPTOP_PRICE  is 'TipTopĳ�����B';
comment on column caerdsa.NPI_PNPRICE.QUATATION_PRICE  is 'eQuatation���B';
comment on column caerdsa.NPI_PNPRICE.EFFECT_DATE  is 'PN�ͮĤ�';
comment on column caerdsa.NPI_PNPRICE.DISABLE_DATE  is 'PN���Ĥ�';
comment on column caerdsa.NPI_PNPRICE.CREATE_USER  is '�إߤH��';
comment on column caerdsa.NPI_PNPRICE.CREATE_TIME  is '�إ߮ɶ�';
comment on column caerdsa.NPI_PNPRICE.CONFIRM_USER  is '�T�{�H��';
comment on column caerdsa.NPI_PNPRICE.CONFIRM_TIME  is '�T�{�ɶ�';
comment on column caerdsa.NPI_PNPRICE.SEND_USER  is '�e�ܤH��';
comment on column caerdsa.NPI_PNPRICE.SEND_TIME  is '�e�ܮɶ�';

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
values ('USD', '����', '', 'System', to_date('17-12-2008', 'dd-mm-yyyy'));
insert into caerdsa.NPI_DOLLAR_TYPE (DOLLAR_TYPEID, DOLLAR_TYPENAME, DESCRIPTION, UPDATE_USER, UPDATE_TIME)
values ('RMB', '�H����', '', 'System', to_date('17-12-2008', 'dd-mm-yyyy'));