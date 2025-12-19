/*==============================================================*/
/* DBMS name:      PostgreSQL 9.x                               */
/* Created on:     18/12/2025 16:57:20                          */
/*==============================================================*/


drop table PERMISOS;

drop table ROLES;

drop table ROLPERMISO;

drop table USUARIOROL;

drop table USUARIOS;

/*==============================================================*/
/* Table: PERMISOS                                              */
/*==============================================================*/
create table PERMISOS (
   IDPERMISO            INT4                 not null,
   CODIGO               varchar(100)         null,
   DESCRIPCION          varchar(200)         null,
   ACTIVO               BOOL                 null,
   FECHACREACION        TIMESTAMP            null,
   FECHAACTUALIZACION   TIMESTAMP            null,
   constraint PK_PERMISOS primary key (IDPERMISO)
);

/*==============================================================*/
/* Table: ROLES                                                 */
/*==============================================================*/
create table ROLES (
   IDROL                INT4                 not null,
   NOMBRE               varchar(50)          null,
   DESCRIPCION          varchar(255)         null,
   ACTIVO               BOOL                 null,
   FECHACREACION        TIMESTAMP            null,
   FECHAACTUALIZACION   TIMESTAMP            null,
   constraint PK_ROLES primary key (IDROL)
);

/*==============================================================*/
/* Table: ROLPERMISO                                            */
/*==============================================================*/
create table ROLPERMISO (
   IDROL                INT4                 null,
   IDPERMISO            INT4                 null,
   constraint AK_KEY_1_ROLPERMI unique (IDROL, IDPERMISO)
);

/*==============================================================*/
/* Table: USUARIOROL                                            */
/*==============================================================*/
create table USUARIOROL (
   IDUSUARIO            INT4                 not null,
   IDROL                INT4                 not null,
   FECHAASIGNACION      TIMESTAMP            null,
   constraint PK_USUARIOROL primary key (IDUSUARIO, IDROL)
);

/*==============================================================*/
/* Table: USUARIOS                                              */
/*==============================================================*/
create table USUARIOS (
   IDUSUARIO            INT4                 not null,
   IDENTIFICACION       VARCHAR(30)          not null,
   PRIMERNOMBRE         VARCHAR(50)          not null,
   SEGUNDONOMBRE        VARCHAR(50)          null,
   PRIMERAPELLIDO       VARCHAR(50)          not null,
   SEGUNDOAPELLIDO      VARCHAR(50)          null,
   TELEFONO             VARCHAR(15)          null,
   EMAIL                VARCHAR(50)          null,
   NOMBREUSUARIO        VARCHAR(50)          not null,
   CLAVEHASH            TEXT                 not null,
   ACTIVO               BOOL                 not null,
   INTENTOSFALLIDOS     INT4                 not null,
   FECHACREACION        TIMESTAMP            not null,
   FECHAACTUALIZACION   TIMESTAMP            not null,
   BLOQUEADOHASTA       TIMESTAMP            null,
   constraint PK_USUARIOS primary key (IDUSUARIO)
);

alter table ROLPERMISO
   add constraint FK_ROLPERMI_REFERENCE_ROLES foreign key (IDROL)
      references ROLES (IDROL)
      on delete restrict on update restrict;

alter table ROLPERMISO
   add constraint FK_ROLPERMI_REFERENCE_PERMISOS foreign key (IDPERMISO)
      references PERMISOS (IDPERMISO)
      on delete restrict on update restrict;

alter table USUARIOROL
   add constraint FK_USUARIOR_REFERENCE_USUARIOS foreign key (IDUSUARIO)
      references USUARIOS (IDUSUARIO)
      on delete restrict on update restrict;

alter table USUARIOROL
   add constraint FK_USUARIOR_REFERENCE_ROLES foreign key (IDROL)
      references ROLES (IDROL)
      on delete restrict on update restrict;

