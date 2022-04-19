create table shinewave.NPI_EMS
(
  EMS_CODE    NVARCHAR2(20) not null,
  EMS_NAME    NVARCHAR2(30) not null,
  EMS_COMPANY NVARCHAR2(30),
  UPDATE_USER NVARCHAR2(20) not null,
  UPDATE_TIME DATE not null
)tablespace TP_RD;
  
  
comment on table shinewave.NPI_EMS  is 'NPI EMS Table';  
comment on column shinewave.NPI_EMS.EMS_CODE  is 'EMS CODE';
comment on column shinewave.NPI_EMS.EMS_NAME  is 'EMS NAME';
comment on column shinewave.NPI_EMS.EMS_COMPANY is 'EMS COMPANY';
 
alter table shinewave.NPI_EMS
  add constraint PK_NPI_EMS primary key (EMS_CODE)
  using index;

CREATE SYNONYM NPI_EMS 	FOR shinewave.NPI_EMS;
  
