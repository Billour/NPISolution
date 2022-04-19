create table caerdsa.NPI_Group
(
  Group_Id  nvarchar2(20) not null ,
  System_Name  nvarchar2(60) not null ,
  System_Desc  nvarchar2(300),
  Work_Status  char(1) not null ,
  Create_User  nvarchar2(20) not null ,
  Create_Time  date not null ,
  Update_User  nvarchar2(20),
  Update_Time  date
) TABLESPACE TP_RD;


comment on table caerdsa.NPI_Group  is 'NPI 群組';
comment on column caerdsa.NPI_Group.Group_Id  is 'Group_Id';
comment on column caerdsa.NPI_Group.System_Name  is 'System_Name';
comment on column caerdsa.NPI_Group.System_Desc  is 'Project_Desc';
comment on column caerdsa.NPI_Group.Work_Status  is '目前狀態';
comment on column caerdsa.NPI_Group.Create_User  is '新增人員';
comment on column caerdsa.NPI_Group.Create_Time  is '新增時間';
comment on column caerdsa.NPI_Group.Update_User  is '修改人員';
comment on column caerdsa.NPI_Group.Update_Time  is '修改時間';


alter table caerdsa.NPI_Group add constraint PKNPI_Group primary key (Group_Id)  using index tablespace INDX_RD;




create table caerdsa.NPI_Group_Mapping
(
  Group_Id  nvarchar2(20) not null ,
  User_Id  nvarchar2(20) not null ,
  Work_Status  char(1) not null ,
  Create_User  nvarchar2(20) not null ,
  Create_Time  date not null ,
  Update_User  nvarchar2(20),
  Update_Time  date
) TABLESPACE TP_RD;


comment on table caerdsa.NPI_Group_Mapping  is 'NPI 群組 人員';
comment on column caerdsa.NPI_Group_Mapping.Group_Id  is 'Group_Id';
comment on column caerdsa.NPI_Group_Mapping.User_Id  is '員工帳號';
comment on column caerdsa.NPI_Group_Mapping.Work_Status  is '目前狀態';
comment on column caerdsa.NPI_Group_Mapping.Create_User  is '新增人員';
comment on column caerdsa.NPI_Group_Mapping.Create_Time  is '新增時間';
comment on column caerdsa.NPI_Group_Mapping.Update_User  is '修改人員';
comment on column caerdsa.NPI_Group_Mapping.Update_Time  is '修改時間';


alter table caerdsa.NPI_Group_Mapping add constraint PKNPI_Group_Mapping primary key (Group_Id,User_Id)  using index tablespace INDX_RD;


alter table caerdsa.NPI_Group_Mapping  add constraint FKNPI_Group_Mapping01 foreign key (Group_Id)  references caerdsa.NPI_Group (Group_Id);

grant select, insert, update, delete on caerdsa.NPI_Group to shinewave;
grant select, insert, update, delete on caerdsa.NPI_Group_Mapping to shinewave;
