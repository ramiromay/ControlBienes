/****************************************************************************************
* IMASD S.A. DE C.V
=========================================================================================
* Descripción: Crea la base de datos y tablas del sistema de control de bienes
*
* Historial de cambios:
* ---------------------------------------------------------------------------------------
* Revisión | Fecha     | Desarrollador | Resumen del cambio
* ---------------------------------------------------------------------------------------
*     1    | 10/09/2024| Ramiro May Moo | Carga de datos de los modulos del sistema.
****************************************************************************************/

INSERT INTO SICBA.Sistema.Modulos ( sNombre, sAbreviacion, sDescripcion, dtFechaCreacion, dtFechaModificacion) VALUES ( N'Sistema Integral De Patrimonio', N'SIP', N'El Sistema Integral de Patrimonio se encarga de la administración de la información y los procesos necesarios para el control de todos los bienes que forman parte del patrimonio de las entidades de la administración pública.', N'2024-10-09 19:24:06.250', N'2024-10-09 19:24:06.250');
INSERT INTO SICBA.Sistema.Modulos ( sNombre, sAbreviacion, sDescripcion, dtFechaCreacion, dtFechaModificacion) VALUES ( N'Sistema Integral De Almacenes', N'SIA', N'El Sistema Integral de Almacenes se encarga de la gestión y administración de la información y los procesos necesarios para el control y seguimiento de todos los bienes almacenados en las entidades de la administración pública, garantizando un manejo eficiente y transparente de los inventarios.', N'2024-10-09 19:24:06.270', N'2024-10-09 19:24:06.270');
GO

INSERT INTO SICBA.Sistema.Secciones ( sNombre, dtFechaCreacion, dtFechaModificacion) VALUES (N'Módulos Principales', N'2024-10-09 19:47:01.117', N'2024-10-09 19:47:01.117');
INSERT INTO SICBA.Sistema.Secciones ( sNombre, dtFechaCreacion, dtFechaModificacion) VALUES (N'Catálogos', N'2024-10-09 19:47:01.120', N'2024-10-09 19:47:01.120');
GO

INSERT INTO SICBA.Sistema.SubModulos (sNombre, sAbreviacion, iIdModulo, dtFechaCreacion, dtFechaModificacion, IidSeccion) VALUES (N'Administrador de Cédulas De Bienes Muebles', N'ACBM', 1, N'2024-10-09 19:28:43.267', N'2024-10-09 19:28:43.267', 1);
INSERT INTO SICBA.Sistema.SubModulos (sNombre, sAbreviacion, iIdModulo, dtFechaCreacion, dtFechaModificacion, IidSeccion) VALUES (N'Administrador de Cédulas De Bienes Inmuebles', N'ACBI', 1, N'2024-10-09 19:28:43.277', N'2024-10-09 19:28:43.277', 1);
INSERT INTO SICBA.Sistema.SubModulos (sNombre, sAbreviacion, iIdModulo, dtFechaCreacion, dtFechaModificacion, IidSeccion) VALUES (N'Administrador de Cédulas De Bienes Vehiculares', N'ACBV', 1, N'2024-10-09 19:28:43.287', N'2024-10-09 19:28:43.287', 1);
INSERT INTO SICBA.Sistema.SubModulos (sNombre, sAbreviacion, iIdModulo, dtFechaCreacion, dtFechaModificacion, IidSeccion) VALUES (N'Inventario de Bienes Muebles', N'IBM', 1, N'2024-10-09 19:31:34.900', N'2024-10-09 19:31:34.900', 1);
INSERT INTO SICBA.Sistema.SubModulos (sNombre, sAbreviacion, iIdModulo, dtFechaCreacion, dtFechaModificacion, IidSeccion) VALUES (N'Inventario de Bienes Inmuebles', N'IBI', 1, N'2024-10-09 19:31:34.903', N'2024-10-09 19:31:34.903', 1);
INSERT INTO SICBA.Sistema.SubModulos (sNombre, sAbreviacion, iIdModulo, dtFechaCreacion, dtFechaModificacion, IidSeccion) VALUES (N'Inventario de Bienes Vehiculares', N'IBV', 1, N'2024-10-09 19:31:34.910', N'2024-10-09 19:31:34.910', 1);
INSERT INTO SICBA.Sistema.SubModulos (sNombre, sAbreviacion, iIdModulo, dtFechaCreacion, dtFechaModificacion, IidSeccion) VALUES (N'Administrador De Catálogos', N'ACP', 1, N'2024-10-09 19:44:51.090', N'2024-10-09 19:44:51.090', 2);
INSERT INTO SICBA.Sistema.SubModulos (sNombre, sAbreviacion, iIdModulo, dtFechaCreacion, dtFechaModificacion, IidSeccion) VALUES (N'Catálogo De Tipo De Bienes Inmuebles', N'CTBI', 1, N'2024-10-09 19:44:51.097', N'2024-10-09 19:44:51.097', 2);
INSERT INTO SICBA.Sistema.SubModulos (sNombre, sAbreviacion, iIdModulo, dtFechaCreacion, dtFechaModificacion, IidSeccion) VALUES ( N'Entradas Y Salidas', N'ENSAL', 2, N'2024-10-09 19:54:09.710', N'2024-10-09 19:54:09.710', 1);
INSERT INTO SICBA.Sistema.SubModulos (sNombre, sAbreviacion, iIdModulo, dtFechaCreacion, dtFechaModificacion, IidSeccion) VALUES ( N'Inventario De Almacenes', N'IA', 2, N'2024-10-09 19:54:09.713', N'2024-10-09 19:54:09.713', 1);
INSERT INTO SICBA.Sistema.SubModulos (sNombre, sAbreviacion, iIdModulo, dtFechaCreacion, dtFechaModificacion, IidSeccion) VALUES ( N'Administrador De Catálogos', N'ACA', 2, N'2024-10-09 19:54:09.720', N'2024-10-09 19:54:09.720', 2);
GO

INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Características Bienes', 1, 1, N'2024-10-09 20:05:09.937', N'2024-10-09 20:05:09.937');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Centros de Trabajo', 1, 1, N'2024-10-09 20:05:09.950', N'2024-10-09 20:05:09.950');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Clases Vehiculares', 1, 1, N'2024-10-09 20:05:09.957', N'2024-10-09 20:05:09.957');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Claves Vehiculares', 1, 1, N'2024-10-09 20:05:09.960', N'2024-10-09 20:05:09.960');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Color de Bien', 1, 1, N'2024-10-09 20:05:09.963', N'2024-10-09 20:05:09.963');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Combustibles Vehiculares', 1, 1, N'2024-10-09 20:05:09.970', N'2024-10-09 20:05:09.970');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Documentos', 1, 1, N'2024-10-09 20:05:09.977', N'2024-10-09 20:05:09.977');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Estado Físico de un Bien', 1, 1, N'2024-10-09 20:05:09.980', N'2024-10-09 20:05:09.980');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Estado General', 1, 1, N'2024-10-09 20:05:09.983', N'2024-10-09 20:05:09.983');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Familias (Lineas)', 1, 1, N'2024-10-09 20:05:09.990', N'2024-10-09 20:05:09.990');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Lineas Vehiculares', 1, 1, N'2024-10-09 20:05:09.993', N'2024-10-09 20:05:09.993');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Marcas', 1, 1, N'2024-10-09 20:05:09.997', N'2024-10-09 20:05:09.997');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Origen del Valor', 1, 1, N'2024-10-09 20:05:10.003', N'2024-10-09 20:05:10.003');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Resguardantes', 1, 1, N'2024-10-09 20:05:10.010', N'2024-10-09 20:05:10.010');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Sub Familias (Sub Lineas)', 1, 1, N'2024-10-09 20:05:10.013', N'2024-10-09 20:05:10.013');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Tipo de Asignación', 1, 1, N'2024-10-09 20:05:10.020', N'2024-10-09 20:05:10.020');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Tipo de Adquisición', 1, 1, N'2024-10-09 20:05:10.023', N'2024-10-09 20:05:10.023');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Tipo de Afectación', 1, 1, N'2024-10-09 20:05:10.030', N'2024-10-09 20:05:10.030');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Tipo de Bien', 1, 1, N'2024-10-09 20:05:10.037', N'2024-10-09 20:05:10.037');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Tipo de Inmueble', 1, 1, N'2024-10-09 20:05:10.040', N'2024-10-09 20:05:10.040');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Tipo de Uso', 1, 1, N'2024-10-09 20:05:10.047', N'2024-10-09 20:05:10.047');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Tipos Vehiculares', 1, 1, N'2024-10-09 20:05:10.050', N'2024-10-09 20:05:10.050');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Titulares', 1, 1, N'2024-10-09 20:05:10.057', N'2024-10-09 20:05:10.057');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Turnos', 1, 1, N'2024-10-09 20:05:10.063', N'2024-10-09 20:05:10.063');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Ubicación', 1, 1, N'2024-10-09 20:05:10.070', N'2024-10-09 20:05:10.070');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Uso de Inmueble', 1, 1, N'2024-10-09 20:05:10.077', N'2024-10-09 20:05:10.077');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Versiones Vehiculares', 1, 1, N'2024-10-09 20:05:10.080', N'2024-10-09 20:05:10.080');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Almacenes', 2, 1, N'2024-10-09 20:10:03.100', N'2024-10-09 20:10:03.100');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Anaqueles', 2, 1, N'2024-10-09 20:10:03.103', N'2024-10-09 20:10:03.103');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Catálogo de Zonas', 2, 1, N'2024-10-09 20:10:03.110', N'2024-10-09 20:10:03.110');
INSERT INTO SICBA.Sistema.Catalogos (sNombre, iIdModulo, bActivo, dtFechaCreacion, dtFechaModificacion) VALUES (N'Conceptos de Movimiento', 2, 1, N'2024-10-09 20:10:03.113', N'2024-10-09 20:10:03.113');
GO