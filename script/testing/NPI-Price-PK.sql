alter table NPI_PNPRICE
  drop constraint PK_NPI_PNPRICE cascade;
alter table NPI_PNPRICE
  add constraint PK_NPI_PNPRICE primary key (PN, YEARQ, LOCATION_SITE)