create table CAERDSA.NPI_EMS
(
  EMS_CODE    NVARCHAR2(20) not null,
  EMS_NAME    NVARCHAR2(30) not null,
  EMS_COMPANY NVARCHAR2(30),
  UPDATE_USER NVARCHAR2(20) not null,
  UPDATE_TIME DATE not null
)tablespace TP_RD;
  
  
comment on table CAERDSA.NPI_EMS  is 'NPI EMS Table';  
comment on column CAERDSA.NPI_EMS.EMS_CODE  is 'EMS CODE';
comment on column CAERDSA.NPI_EMS.EMS_NAME  is 'EMS NAME';
comment on column CAERDSA.NPI_EMS.EMS_COMPANY is 'EMS COMPANY';
 
alter table CAERDSA.NPI_EMS
  add constraint PK_NPI_EMS primary key (EMS_CODE)
  using index tablespace indx_rd;

CREATE SYNONYM NPI_EMS 	FOR caerdsa.NPI_EMS;
  
grant select, insert, update, delete on caerdsa.NPI_EMS to shinewave;