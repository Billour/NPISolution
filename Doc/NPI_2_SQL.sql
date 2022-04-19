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
  is '�s�եN��';
-- Add comments to the columns 
comment on column NPI_GROUP.Group_Id
  is '�s�եN��';
comment on column NPI_GROUP.Group_Name
  is '�s�E�W��';
comment on column NPI_GROUP.CREATE_USER
  is '�إߤH��';
comment on column NPI_GROUP.CREATE_DATE
  is '�إ߮ɶ�';
comment on column NPI_GROUP.UPDATE_USER
  is '��s�H��';
comment on column NPI_GROUP.UPDATE_DATE
  is '��s�ɶ�';
comment on column NPI_GROUP.IS_ENABLE
  is '�O�_�ϥ�';
-- Create/Recreate primary, unique and foreign key constraints 
alter table NPI_GROUP
  add constraint PK_NPI_Group primary key (GROUP_ID);