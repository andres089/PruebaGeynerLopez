

CREATE TABLE TB_Factura
(
	  IdFactura NUMBER(18) not null,
	  NumeroFactura VARCHAR2 not null,
	  Fecha DATE NOT NULL,
	  TipoPago NUMBER (6) not null,
	  DocumentoCliente VARCHAR2(20),
	  NombreCliente VARCHAR2(100),
      Subtotal NUMBER(18,2),
      Descuento NUMBER(18,2),
	  Iva NUMBER(18),
	  TotalDescuento NUMBER(18,2),
	  TotalImpuesto NUMBER(18,2),
	  Total NUMBER(18, 2)NOT NULL,

  CONSTRAINT  primarykeyFactura PRIMARY KEY (IdFactura)
);

create sequence secFactura
  start with 1
  increment by 1
  maxvalue 99999
  minvalue 1;


CREATE TABLE TB_Producto
(
	  IdProducto NUMBER(18) not null,
	  Producto VARCHAR2(200) not null,
	  

  CONSTRAINT  primarykeyProducto PRIMARY KEY (IdProducto)
);

create sequence secProducto
  start with 1
  increment by 1
  maxvalue 99999
  minvalue 1;
  
  CREATE TABLE tb_FacturaProducto
(
	  IdFacturaProducto NUMBER(18) not null,
	  IdFactura NUMBER(18) not null,
	  IdProducto NUMBER(18) not null,
	  

  CONSTRAINT  primarykeyFactProd PRIMARY KEY (IdFacturaProducto)
);

create sequence secFactProduc
  start with 1
  increment by 1
  maxvalue 99999
  minvalue 1;