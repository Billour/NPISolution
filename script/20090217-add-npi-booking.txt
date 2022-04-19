alter table CAERDSA.npi_booking
  drop constraint PK_BOMBOOKING cascade;
alter table CAERDSA.npi_booking
  add constraint PK_BOMBOOKING primary key (user_id, bom_id, form_id)