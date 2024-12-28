/****************************************************************************************
* IMASD S.A. DE C.V
=========================================================================================
* Descripción: Ejecutor Maestro de la base de datos de Control de Bienes
*
* Historial de cambios:
* ---------------------------------------------------------------------------------------
* Revisión | Fecha     | Desarrollador | Resumen del cambio
* ---------------------------------------------------------------------------------------
*     1    | 05/10/2024| Ramiro May Moo | Creación.
*     2    | 09/10/2024| Ramiro May Moo | Se agrego el script de carga de datos de los
*          |           |                | modulos delsistema.
*     3    | 10/09/2024| Ramiro May Moo | Se agrego el scripts que crean los triggers.
*     4    | 06/11/2024| Ramiro May Moo | Se agrego el script que carga los datos de los
*          |           |                | catalogos.
*     5    | 01/12/2024| Ramiro May Moo | Se agrego el script que carga los datos de los
*          |           |                | generales.
*     6    | 01/12/2024| Ramiro May Moo | Se agrego el script que carga los datos de los
*          |           |                | patrimonio.
*     7    | 09/12/2024| Ramiro May Moo | Se agrego el script que carga los datos de los
*          |           |                | BMS.
****************************************************************************************/

:r 001-SICBA-CrearBaseDatos-17072024.sql
:r 002-SICBA-CrearTriggers-17102024.sql
:r 003-SICBA-CargarDatosModulosSistema-09102024.sql
:r 004-SICBA-CargaDatosCatalogos-06112024.sql
:r 005-SICBA-CargaDatosCatalogosCaracteristicasBienes-06112024.sql
:r 006-SICBA-CargaDatosCatalogosUbicaciones-06112024.sql
:r 007-SICBA-CargaDatosCatalogosMarcas-06112024.sql
:r 008-SICBA-CargaDatosCatalogosLineasVehiculares-06112024.sql
:r 009-SICBA-CargaDatosCatalogosVersionesVehiculares-06112024.sql
:r 010-SICBA-CargaDatosGenerales-01122024.sql
:r 011-SICBA-CargaDatosPatrimonio-01122024.sql
:r 012-SICBA-CargaDatosBMS-09122024.sql

