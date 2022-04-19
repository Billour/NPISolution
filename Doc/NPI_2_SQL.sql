-- Create table
create table NPI_GROUP
(
  Group_Id    nvarchar2(20) not null,
  Group_Name  nvarchar2(60) not null,
  CREATE_USER NVARCHAR2(60),
  CREATE_DATE DATE not null,
  UPDATE_USER NVARCHAR2(60) not null,
  UPDATE_DATE DATE not null,
  IS_ENABLE   CHAR(1) not null
)
;
-- Add comments to the table 
comment on table NPI_GROUP
  is '群組代號';
-- Add comments to the columns 
comment on column NPI_GROUP.Group_Id
  is '群組代號';
comment on column NPI_GROUP.Group_Name
  is '群閆名稱';
comment on column NPI_GROUP.CREATE_USER
  is '建立人員';
comment on column NPI_GROUP.CREATE_DATE
  is '建立時間';
comment on column NPI_GROUP.UPDATE_USER
  is '更新人員';
comment on column NPI_GROUP.UPDATE_DATE
  is '更新時間';
comment on column NPI_GROUP.IS_ENABLE
  is '是否使用';
-- Create/Recreate primary, unique and foreign key constraints 
alter table NPI_GROUP
  add constraint PK_NPI_Group primary key (GROUP_ID);