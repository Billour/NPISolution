prompt PL/SQL Developer import file
prompt Created on 2008�~12��10�� by Wen-Bin_Tsai
set feedback off
set define off
prompt Loading NPI_DOLLAR_TYPE...
insert into NPI_DOLLAR_TYPE (DOLLAR_TYPEID, DOLLAR_TYPENAME, DESCRIPTION, UPDATE_USER, UPDATE_TIME)
values ('USD', '����', null, 'System', to_date('17-12-2008', 'dd-mm-yyyy'));
insert into NPI_DOLLAR_TYPE (DOLLAR_TYPEID, DOLLAR_TYPENAME, DESCRIPTION, UPDATE_USER, UPDATE_TIME)
values ('RMB', '�H����', null, 'System', to_date('17-12-2008', 'dd-mm-yyyy'));
commit;
prompt 2 records loaded
set feedback on
set define on
prompt Done.
