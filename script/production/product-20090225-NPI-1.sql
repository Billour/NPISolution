create table caerdsa.NPI_SourcerPN_Map
(
  User_Id  nvarchar2(20) not null ,
  Company_Id  nvarchar2(100) not null ,
  Asus_PN  nvarchar2(100) not null ,
  Create_User  nvarchar2(20) not null ,
  Create_Time  date not null ,
  Update_User  nvarchar2(20),
  Update_Time  date
) TABLESPACE TP_RD;


comment on table caerdsa.NPI_SourcerPN_Map  is '採購與PN料號之群組關係';
comment on column caerdsa.NPI_SourcerPN_Map.User_Id  is 'UserId';
comment on column caerdsa.NPI_SourcerPN_Map.Company_Id  is '公司代號';
comment on column caerdsa.NPI_SourcerPN_Map.Asus_PN  is 'PN料號';
comment on column caerdsa.NPI_SourcerPN_Map.Create_User  is '新增人員';
comment on column caerdsa.NPI_SourcerPN_Map.Create_Time  is '新增時間';
comment on column caerdsa.NPI_SourcerPN_Map.Update_User  is '修改人員';
comment on column caerdsa.NPI_SourcerPN_Map.Update_Time  is '修改時間';


alter table caerdsa.NPI_SourcerPN_Map add constraint PKNPI_SourcerPN_Map primary key (User_Id,Company_Id,Asus_PN)  using index tablespace INDX_RD;

grant select, insert, update, delete on caerdsa.NPI_SourcerPN_Map to shinewave;



