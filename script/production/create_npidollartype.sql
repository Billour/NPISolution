prompt PL/SQL Developer import file
prompt Created on 2008年12月10日 by Wen-Bin_Tsai
set feedback off
set define off
prompt Loading NPI_DOLLAR_TYPE...
insert into NPI_DOLLAR_TYPE (DOLLAR_TYPEID, DOLLAR_TYPENAME, DESCRIPTION, UPDATE_USER, UPDATE_TIME)
values ('USD', '美金', null, 'System', to_date('17-12-2008', 'dd-mm-yyyy'));
insert into NPI_DOLLAR_TYPE (DOLLAR_TYPEID, DOLLAR_TYPENAME, DESCRIPTION, UPDATE_USER, UPDATE_TIME)
values ('RMB', '人民幣', null, 'System', to_date('17-12-2008', 'dd-mm-yyyy'));
commit;
prompt 2 records loaded
set feedback on
set define on
prompt Done.
