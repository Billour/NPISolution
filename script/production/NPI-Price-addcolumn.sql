ALTER TABLE caerdsa.NPI_PNPRICE
ADD ( 
  PN_DESC         NVARCHAR2(300),
  PN_SPEC         NVARCHAR2(300),
  BUYING_MODE     CHAR(1)
  ); 

comment on column caerdsa.NPI_PNPRICE.PN_DESC  is 'PN»¡©ú';
comment on column caerdsa.NPI_PNPRICE.PN_SPEC  is 'PN Spec';
comment on column caerdsa.NPI_PNPRICE.BUYING_MODE  is 'BuyingMode';

  


