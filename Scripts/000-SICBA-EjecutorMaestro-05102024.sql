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
*     1    | 09/10/2024| Ramiro May Moo | Se agrego el script de carga de datos de los
*          |           |                | modulos delsistema.
*     1    | 10/09/2024| Ramiro May Moo | Se agrego el scripts que crean los triggers.
****************************************************************************************/

:r 001-SICBA-CrearBaseDatos-17072024.sql
:r 002-SICBA-CrearTriggers-17102024.sql
:r 003-SICBA-CargarDatosModulosSistema-09102024.sql
