/****************************************************************************************
* IMASD S.A. DE C.V
=========================================================================================
* Descripción: Crea la base de datos y tablas del sistema de control de bienes
*
* Historial de cambios:
* ---------------------------------------------------------------------------------------
* Revisión | Fecha     | Desarrollador | Resumen del cambio
* ---------------------------------------------------------------------------------------
*     1    | 17/07/2024| Ramiro May Moo | Creación
*     2    | 03/10/2024| Ramiro May Moo | Agregación de tablas y relaciones de Almacenes
*     3    | 09/10/2024| Ramiro May Moo | Agregación de tabla secciones y relacion con
           |           |                | submódulos.
****************************************************************************************/

-- Creacion de la base de datos
CREATE DATABASE SICBA;
GO

USE SICBA;
GO

-- Creacion de esquemas
CREATE SCHEMA Sistema;
GO

CREATE SCHEMA Catalogo;
GO

CREATE SCHEMA Seguridad;
GO

CREATE SCHEMA Patrimonio;
GO

CREATE SCHEMA Almacen;
GO

CREATE SCHEMA General;
GO

-- TABLAS DE SISTEMA Y SEGURIDAD
CREATE TABLE Sistema.Modulos
(
    iIdModulo           BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    sNombre             NVARCHAR(250)                     NOT NULL,
    sAbreviacion        NVARCHAR(10)                      NOT NULL,
    sDescripcion        NVARCHAR(MAX),
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Sistema.Secciones
(
    iIdSeccion          BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    sNombre             NVARCHAR(250)                     NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Sistema.SubModulos
(
    iIdSubModulo        BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    sNombre             NVARCHAR(250)                     NOT NULL,
    sAbreviacion        NVARCHAR(10)                      NOT NULL,
    iIdModulo           BIGINT                            NOT NULL,
    iIdSeccion          BIGINT                            NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

ALTER TABLE Sistema.SubModulos
    ADD CONSTRAINT FK_SubModulos_iIdSeccion
        FOREIGN KEY (iIdSeccion) REFERENCES Sistema.Secciones (iIdSeccion);

ALTER TABLE Sistema.SubModulos
    ADD CONSTRAINT FK_SubModulos_iIdModulo
        FOREIGN KEY (iIdModulo) REFERENCES Sistema.Modulos (iIdModulo);

CREATE TABLE Sistema.Catalogos
(
    iIdCatalogo         BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    iIdModulo           BIGINT,
    bActivo             BIT,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Sistema.ColumnasTablas
(
    iIdColumnaTablaCatalogo BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sClave                  NVARCHAR(255)                     NOT NULL,
    sNombre                 NVARCHAR(255)                     NOT NULL,
    sTipoDato               NVARCHAR(100)                     NOT NULL,
    iIdCatalogo             BIGINT                            NOT NULL,
    iIdSubModulo            BIGINT                            NOT NULL,
    bActivo                 BIT                               NOT NULL,
    dtFechaCreacion         DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion     DATETIME                          NOT NULL DEFAULT GETDATE()
);

ALTER TABLE Sistema.ColumnasTablas
    ADD CONSTRAINT FK_ColumnasTablas_iIdCatalogo
        FOREIGN KEY (iIdCatalogo) REFERENCES Sistema.Catalogos (iIdCatalogo);

ALTER TABLE Sistema.ColumnasTablas
    ADD CONSTRAINT FK_ColumnasTablas_iIdSubmodulo
        FOREIGN KEY (iIdSubModulo) REFERENCES Sistema.SubModulos (iIdSubModulo);

ALTER TABLE Sistema.Catalogos
    ADD CONSTRAINT FK_Catalogos_iIdModulo
        FOREIGN KEY (iIdModulo) REFERENCES Sistema.Modulos (iIdModulo);

CREATE TABLE General.Nacionalidades
(
    iIdNacionalidad     BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(50)                      NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Seguridad.Personas
(
    iIdPersona        BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    sNombres          NVARCHAR(500)                     NOT NULL,
    sPrimerNombre     NVARCHAR(100)                     NOT NULL,
    sSegundoNombre    NVARCHAR(100)                     NOT NULL,
    bHombre           BIT                               NOT NULL,
    dtFechaNacimiento DATE                              NOT NULL,
    iIdNacionalidad   BIGINT                            NOT NULL,
    sRFC              NVARCHAR(20)                      NOT NULL,
);

ALTER TABLE Seguridad.Personas
    ADD CONSTRAINT FK_Personas_iIdNacionalidad
        FOREIGN KEY (iIdNacionalidad) REFERENCES General.Nacionalidades (iIdNacionalidad);

CREATE TABLE General.Nombramientos
(
    iIdNombramiento     BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    sNombre             NVARCHAR(50)                      NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Seguridad.Empleados
(
    iIdEmpleado         BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    iIdPersona          BIGINT                            NOT NULL,
    iIdUsuario          BIGINT                            NOT NULL,
    dtFechaIngreso      DATE                              NOT NULL,
    iIdNombramiento     BIGINT                            NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Seguridad.Roles
(
    iIdRol              BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    sNombre             NVARCHAR(100)                     NOT NULL,
    sDescripcion        NVARCHAR(MAX)                     NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Seguridad.Usuarios
(
    iIdUsuario          BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    iIdEmpleado         BIGINT                            NOT NULL,
    sUsuario            NVARCHAR(100)                     NOT NULL,
    sContraseniaHash    NVARCHAR(MAX)                     NOT NULL,
    sEmail              NVARCHAR(250)                     NOT NULL,
    nNumero             NUMERIC(10),
    bEmailVerificado    BIT                               NOT NULL,
    iIdRol              BIGINT                            NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

ALTER TABLE Seguridad.Empleados
    ADD CONSTRAINT FK_Empleados_iIdPersona
        FOREIGN KEY (iIdPersona) REFERENCES Seguridad.Personas (iIdPersona);

ALTER TABLE Seguridad.Empleados
    ADD CONSTRAINT FK_Empleados_iIdNombramiento
        FOREIGN KEY (iIdNombramiento) REFERENCES General.Nombramientos (iIdNombramiento);

ALTER TABLE Seguridad.Empleados
    ADD CONSTRAINT FK_Empleados_iIdUsuario
        FOREIGN KEY (iIdUsuario)
            REFERENCES Seguridad.Usuarios (iIdUsuario);

ALTER TABLE Seguridad.Usuarios
    ADD CONSTRAINT FK_Usuario_iIdEmpleado
        FOREIGN KEY (iIdEmpleado)
            REFERENCES Seguridad.Empleados (iIdEmpleado);

ALTER TABLE Seguridad.Usuarios
    ADD CONSTRAINT FK_Usuario_iIdRol
        FOREIGN KEY (iIdRol) REFERENCES Seguridad.Roles (iIdRol);

CREATE TABLE Seguridad.Permisos
(
    iIdPermiso   BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    sNombre      NVARCHAR(50)                      NOT NULL,
    sDescripcion NVARCHAR(MAX)                     NOT NULL,
    iIdModulo    BIGINT                            NOT NULL,
);

CREATE TABLE Seguridad.RolesPermisos
(
    iIdRolPermiso BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    iIdRol        BIGINT                            NOT NULL,
    iIdPermiso    BIGINT                            NOT NULL
);

ALTER TABLE Seguridad.Permisos
    ADD CONSTRAINT FK_Permisos_iIdModulo
        FOREIGN KEY (iIdModulo)
            REFERENCES Sistema.Modulos (iIdModulo);

ALTER TABLE Seguridad.RolesPermisos
    ADD CONSTRAINT FK_RolesPermisos_iIdRol
        FOREIGN KEY (iIdRol)
            REFERENCES Seguridad.Roles (iIdRol);

ALTER TABLE Seguridad.RolesPermisos
    ADD CONSTRAINT FK_RolesPermisos_iIdPermiso
        FOREIGN KEY (iIdPermiso)
            REFERENCES Seguridad.Permisos (iIdPermiso);

CREATE TABLE Seguridad.UsuariosPermisos
(
    iIdUsuarioPermiso BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    iIdUsuario        BIGINT                            NOT NULL,
    iIdPermiso        BIGINT                            NOT NULL
);

ALTER TABLE Seguridad.UsuariosPermisos
    ADD CONSTRAINT FK_UsuariosPermisos_iIdUsuario
        FOREIGN KEY (iIdUsuario)
            REFERENCES Seguridad.Usuarios (iIdUsuario);

ALTER TABLE Seguridad.UsuariosPermisos
    ADD CONSTRAINT FK_UsuariosPermisos_iIdPermiso
        FOREIGN KEY (iIdPermiso)
            REFERENCES Seguridad.Permisos (iIdPermiso);
GO

-- TABLAS DE PATRIMONIO
CREATE TABLE General.Periodos
(
    iIdPeriodo          BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iAnio               INT                               NOT NULL,
    dtFechaInicio       DATE                              NOT NULL,
    dtFechaFinal        DATE                              NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

-- SECRETARIAS / DIRRECCION / DEPARTAMENTOS
CREATE TABLE General.TiposNiveles
(
    iIdTipoNivel        BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(100)                     NOT NULL,
    iNivel              INT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE(),
);

CREATE TABLE General.UnidadesAdministrativas
(
    iIdUnidadAdministrativa BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdPeriodo              BIGINT                            NOT NULL,
    sNombre                 NVARCHAR(255)                     NOT NULL,
    sNivelCompleto          NVARCHAR(20)                      NOT NULL,
    iIdTipoNivel            BIGINT                            NOT NULL,
    dtFechaCreacion         DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
);

ALTER TABLE General.UnidadesAdministrativas
    ADD CONSTRAINT FK_UnidadesAdministrativas_iIdTipoNivel
        FOREIGN KEY (iIdTipoNivel)
            REFERENCES General.TiposNiveles (iIdTipoNivel);

ALTER TABLE General.UnidadesAdministrativas
    ADD CONSTRAINT FK_UnidadAdmistrativa_iIdPeriodo
        FOREIGN KEY (iIdPeriodo)
            REFERENCES General.Periodos (iIdPeriodo);


CREATE TABLE General.Municipios
(
    iIdMunicipio        BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE(),
);

CREATE TABLE Catalogo.CentrosTrabajo
(
    iIdCentroTrabajo        BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdPeriodo              BIGINT                            NOT NULL,
    sClave                  NVARCHAR(30)                      NOT NULL,
    sNombre                 NVARCHAR(255)                     NOT NULL,
    sDireccion              NVARCHAR(MAX)                     NOT NULL,
    iIdMunicipio            BIGINT                            NOT NULL,
    iIdUnidadAdministrativa BIGINT                            NOT NULL,
    bActivo                 BIT                               NOT NULL,
    dtFechaCreacion         DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion     DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.Turnos
(
    iIdTurno            BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(100)                     NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.CentroTrabajoTurnos
(
    iIdCentroTrabajoTurno BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdCentroTrabajo      BIGINT                            NOT NULL,
    iIdTurno              BIGINT                            NOT NULL,
    bActivo               BIT                               NOT NULL,
    dtFechaCreacion       DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion   DATETIME                          NOT NULL DEFAULT GETDATE()
);

ALTER TABLE Catalogo.CentrosTrabajo
    ADD CONSTRAINT FK_CentrosTrabajo_iIdMunicipio
        FOREIGN KEY (iIdMunicipio)
            REFERENCES General.Municipios (iIdMunicipio);

ALTER TABLE Catalogo.CentrosTrabajo
    ADD CONSTRAINT FK_CentrosTrabajo_iIdUnidadesAdministrativas
        FOREIGN KEY (iIdUnidadAdministrativa)
            REFERENCES General.UnidadesAdministrativas (iIdUnidadAdministrativa);

ALTER TABLE Catalogo.CentroTrabajoTurnos
    ADD CONSTRAINT FK_CentroTrabajoTurnos_iIdCentrosTrabajo
        FOREIGN KEY (iIdCentroTrabajo)
            REFERENCES Catalogo.CentrosTrabajo (iIdCentroTrabajo);

ALTER TABLE Catalogo.CentroTrabajoTurnos
    ADD CONSTRAINT FK_CentroTrabajoTurnos_iIdTurno
        FOREIGN KEY (iIdTurno)
            REFERENCES Catalogo.Turnos (iIdTurno);


CREATE TABLE Catalogo.Titulares
(
    iIdTitular            BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    sNombre               NVARCHAR(150)                     NOT NULL,
    iIdCentroTrabajoTurno BIGINT                            NOT NULL,
    bActivo               BIT                               NOT NULL,
    dtFechaCreacion       DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion   DATETIME                          NOT NULL DEFAULT GETDATE()
);

ALTER TABLE Catalogo.Titulares
    ADD CONSTRAINT FK_Titulares_iIdCentroTrabajoTurno
        FOREIGN KEY (iIdCentroTrabajoTurno)
            REFERENCES Catalogo.CentroTrabajoTurnos (iIdCentroTrabajoTurno);

CREATE TABLE Catalogo.Colores
(
    iIdColor            BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(100)                     NOT NULL,
    sCodigoRGB          NVARCHAR(25)                      NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.EstadosFisicos
(
    iIdEstadoFisico     BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(50)                      NOT NULL,
    sDescripcion        NVARCHAR(MAX)                     NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.EstadosGenerales
(
    iIdEstadoGeneral    BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(25)                      NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);


CREATE TABLE Catalogo.Marcas
(
    iIdMarca            BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(100)                     NOT NULL,
    sObservaciones      NVARCHAR(MAX),
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.OrigenesValores
(
    iIdOrigenValor      BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sOrigen             NVARCHAR(60)                      NOT NULL,
    sDescripcion        NVARCHAR(MAX)                     NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.Ubicaciones
(
    iIdUbicacion        BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sDescripcion        NVARCHAR(MAX)                     NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.ClasesVehiculares
(
    iIdClaseVehicular   BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(150)                     NOT NULL,
    sDescripcion        NVARCHAR(MAX)                     NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.ClavesVehiculares
(
    iIdClaveVehicular   BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(150)                     NOT NULL,
    sDescripcion        NVARCHAR(MAX),
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.CombustiblesVehiculares
(
    iIdCombustibleVehicular BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre                 NVARCHAR(100)                     NOT NULL,
    sDescripcion            NVARCHAR(MAX)                     NULL,
    bActivo                 BIT                               NOT NULL,
    dtFechaCreacion         DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion     DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Patrimonio.TiposTramites
(
    iIdTipoTramite      BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(100)                     NOT NULL,
    sDescripcion        NVARCHAR(MAX)                     NOT NULL,
    iIdModulo           BIGINT                            NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Patrimonio.MotivosTramites
(
    iIdMotivoTramite    BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(100)                     NOT NULL,
    sDescripcion        NVARCHAR(MAX)                     NOT NULL,
    iIdTipoTramite      BIGINT                            NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.Documentos
(
    iIdDocumentos       BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sAbreviacion        NVARCHAR(10)                      NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    iIdModulo           BIGINT                            NOT NULL,
    iIdTipoTramite      BIGINT                            NOT NULL,
    iIdMotivoTramite    BIGINT                            NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

ALTER TABLE Patrimonio.TiposTramites
    ADD CONSTRAINT FK_TiposTramites_iIdModulo
        FOREIGN KEY (iIdModulo)
            REFERENCES Sistema.Modulos (iIdModulo);

ALTER TABLE Patrimonio.MotivosTramites
    ADD CONSTRAINT FK_MotivosTramites_iIdTipoTramite
        FOREIGN KEY (iIdTipoTramite)
            REFERENCES Patrimonio.TiposTramites (iIdTipoTramite);

ALTER TABLE Catalogo.Documentos
    ADD CONSTRAINT FK_Documentos_iIdModulo
        FOREIGN KEY (iIdModulo)
            REFERENCES Sistema.Modulos (iIdModulo);

ALTER TABLE Catalogo.Documentos
    ADD CONSTRAINT FK_Documentos_iIdTipoTramite
        FOREIGN KEY (iIdTipoTramite)
            REFERENCES Patrimonio.TiposTramites (iIdTipoTramite);

ALTER TABLE Catalogo.Documentos
    ADD CONSTRAINT FK_Documentos_iIdMotivoTramite
        FOREIGN KEY (iIdMotivoTramite)
            REFERENCES Patrimonio.MotivosTramites (iIdMotivoTramite);

CREATE TABLE Catalogo.LineasVehiculares
(
    iIdLineaVehicular   BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    sDescripcion        NVARCHAR(MAX)                     NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.TiposVehiculares
(
    iIdTipoVehicular    BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    sDescripcion        NVARCHAR(MAX)                     NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.VersionesVehiculares
(
    iIdVersionVehicular BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    sDescripcion        NVARCHAR(MAX)                     NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

-- INTERNO / EXTERNO
CREATE TABLE General.TiposResponsables
(
    iIdTipoResponsable  BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(150)                     NOT NULL,
    sDescripcion        NVARCHAR(MAX),
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.Resguardantes
(
    iIdResguardante         BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdPeriodo              BIGINT                            NOT NULL,
    iIdPersona              BIGINT                            NOT NULL,
    iIdUnidadAdministrativa BIGINT                            NOT NULL,
    sObservaciones          NVARCHAR(MAX),
    iNoConvenio             INT                               NOT NULL DEFAULT 0,
    iIdTipoResponsable      BIGINT                            NOT NULL,
    bResponsable            BIT                               NOT NULL,
    bActivo                 BIT                               NOT NULL,
    dtFechaCreacion         DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion     DATETIME                          NOT NULL DEFAULT GETDATE()
);

-- MUEBLES, INMUEBLES Y VEHICULOS
CREATE TABLE Catalogo.TiposBienes
(
    iIdTipoBien         BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.Familias
(
    iIdFamilia          BIGINT PRIMARY KEY NOT NULL,
    iNumeroCuenta       INT,
    sNombre             NVARCHAR(255)      NOT NULL,
    sDescripcion        NVARCHAR(MAX),
    iIdTipoBien         BIGINT,
    bActivo             BIT                NOT NULL,
    dtFechaCreacion     DATETIME           NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME           NOT NULL DEFAULT GETDATE()
);

ALTER TABLE Catalogo.Familias
    ADD CONSTRAINT FK_Familias_iIdTipoBien
        FOREIGN KEY (iIdTipoBien) REFERENCES Catalogo.TiposBienes (iIdTipoBien);

CREATE TABLE Catalogo.Subfamilias
(
    iIdSubfamilia       BIGINT PRIMARY KEY NOT NULL,
    iIdFamilia          BIGINT             NOT NULL,
    iNumeroCuenta       INT,
    sNombre             NVARCHAR(255)      NOT NULL,
    sDescripcion        NVARCHAR(MAX),
    dValorRecuperable   DOUBLE PRECISION   NOT NULL,
    bActivo             BIT                NOT NULL,
    dtFechaCreacion     DATETIME           NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME           NOT NULL DEFAULT GETDATE()
);

ALTER TABLE Catalogo.Subfamilias
    ADD CONSTRAINT FK_Subfamilias_iIdFamilia
        FOREIGN KEY (iIdFamilia) REFERENCES Catalogo.Familias (iIdFamilia);

CREATE TABLE Catalogo.CaracteristicasBienes
(
    iIdCaracteristicaBien BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdFamilia            BIGINT                            NOT NULL,
    iIdSubfamilia         BIGINT                            NOT NULL,
    sEtiqueta             NVARCHAR(255)                     NOT NULL,
    sDescripcion          NVARCHAR(MAX),
    bActivo               BIT                               NOT NULL,
    dtFechaCreacion       DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion   DATETIME                          NOT NULL DEFAULT GETDATE()
);

ALTER TABLE Catalogo.CaracteristicasBienes
    ADD CONSTRAINT FK_CaracteristicasBienes_iIdFamilia
        FOREIGN KEY (iIdFamilia) REFERENCES Catalogo.Familias (iIdFamilia);

ALTER TABLE Catalogo.CaracteristicasBienes
    ADD CONSTRAINT FK_CaracteristicasBienes_iIdSubfamilia
        FOREIGN KEY (iIdSubfamilia) REFERENCES Catalogo.Subfamilias (iIdSubfamilia);

ALTER TABLE Catalogo.Resguardantes
    ADD CONSTRAINT FK_Resguardantes_iIdPeriodo
        FOREIGN KEY (iIdPeriodo) REFERENCES General.Periodos (iIdPeriodo);

ALTER TABLE Catalogo.Resguardantes
    ADD CONSTRAINT FK_Resguardantes_iIdPersona
        FOREIGN KEY (iIdPersona) REFERENCES Seguridad.Personas (iIdPersona);

ALTER TABLE Catalogo.Resguardantes
    ADD CONSTRAINT FK_Resguardantes_UnidadesAdministrativas
        FOREIGN KEY (iIdUnidadAdministrativa) REFERENCES General.UnidadesAdministrativas (iIdUnidadAdministrativa);

ALTER TABLE Catalogo.Resguardantes
    ADD CONSTRAINT FK_Resguardantes_iIdTipoResponsable
        FOREIGN KEY (iIdTipoResponsable) REFERENCES General.TiposResponsables (iIdTipoResponsable);

CREATE TABLE Catalogo.TiposAdquisiciones
(
    iIdTipoAdquisicion  BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.TiposAfectaciones
(
    iIdTipoAfectacion   BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(150)                     NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.TiposInmuebles
(
    iIdTipoInmueble     BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    sDescripcion        NVARCHAR(MAX),
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.UsosInmuebles
(
    iIdUsoInmueble      BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE General.BMS
(
    iIdBMS              BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    iIdFamilia          BIGINT                            NOT NULL,
    iIdSubfamilia       BIGINT                            NOT NULL,
    iCantidad           INT                               NOT NULL,
    sUnidadMedida       NVARCHAR(255)                     NOT NULL,
    dPrecioUnitario     DOUBLE PRECISION                  NOT NULL,
    nCodigoArmonizado   NUMERIC(10),
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

ALTER TABLE General.BMS
    ADD CONSTRAINT FK_BMS_iIdFamilia
        FOREIGN KEY (iIdFamilia) REFERENCES Catalogo.Familias (iIdFamilia);

ALTER TABLE General.BMS
    ADD CONSTRAINT FK_BMS_iIdSubfamilia
        FOREIGN KEY (iIdSubfamilia) REFERENCES Catalogo.Subfamilias (iIdSubfamilia);

CREATE TABLE Patrimonio.Etapas
(
    iIdEtapa            BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Patrimonio.EtapasTramites
(
    iIdEtapaTramite     BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdTipoTramite      BIGINT                            NOT NULL,
    iIdEtapa            BIGINT                            NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

ALTER TABLE Patrimonio.EtapasTramites
    ADD CONSTRAINT FK_EtapasTramites_iIdTipoTramite
        FOREIGN KEY (iIdTipoTramite) REFERENCES Patrimonio.TiposTramites (iIdTipoTramite);

ALTER TABLE Patrimonio.EtapasTramites
    ADD CONSTRAINT FK_EtapasTramites_iIdEtapa
        FOREIGN KEY (iIdEtapa) REFERENCES Patrimonio.Etapas (iIdEtapa);

CREATE TABLE Patrimonio.Licitaciones
(
    iIdLicitacion       BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iNumeroLicitacion   INT,
    dtFecha             DATE,
    sObservaciones      NVARCHAR(MAX),
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Patrimonio.DatosVehiculares
(
    iIdDatoVehicular BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iAnioEmision     INT,
    sNumeroPlaca     NVARCHAR(20),
    iNumeroMotor     INT,
    iAnioModelo      INT,
    nNumeroEconomico NUMERIC(30)
);

CREATE TABLE Patrimonio.Facturas
(
    iIdFactura          BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sFolioFactura       NVARCHAR(20),
    dtFecha             DATE                              NOT NULL,
    iGarantiaDias       INT,
    iIdDatoVehicular    BIGINT,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

ALTER TABLE Patrimonio.Facturas
    ADD CONSTRAINT FK_Facturas_iIdDatoVehicular
        FOREIGN KEY (iIdDatoVehicular) REFERENCES Patrimonio.DatosVehiculares (iIdDatoVehicular);

CREATE TABLE Patrimonio.DatosGenerales
(
    iIdDatoGeneral          BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdClaveVehicular       BIGINT,
    iIdMarca                BIGINT,
    iIdLineaVehicular       BIGINT,
    iIdVersionVehicular     BIGINT,
    iIdClaseVehicular       BIGINT,
    iIdTipoVehicular        BIGINT,
    iIdColor                BIGINT,
    iIdCombustibleVehicular BIGINT
);

ALTER TABLE Patrimonio.DatosGenerales
    ADD CONSTRAINT FK_DatosGenerales_iIdClaveVehicular
        FOREIGN KEY (iIdClaveVehicular) REFERENCES Catalogo.ClavesVehiculares (iIdClaveVehicular);

ALTER TABLE Patrimonio.DatosGenerales
    ADD CONSTRAINT FK_DatosGenerales_iIdMarca
        FOREIGN KEY (iIdMarca) REFERENCES Catalogo.Marcas (iIdMarca);

ALTER TABLE Patrimonio.DatosGenerales
    ADD CONSTRAINT FK_DatosGenerales_iIdLineaVehicular
        FOREIGN KEY (iIdLineaVehicular) REFERENCES Catalogo.LineasVehiculares (iIdLineaVehicular);

ALTER TABLE Patrimonio.DatosGenerales
    ADD CONSTRAINT FK_DatosGenerales_iIdVersionVehicular
        FOREIGN KEY (iIdVersionVehicular) REFERENCES Catalogo.VersionesVehiculares (iIdVersionVehicular);

ALTER TABLE Patrimonio.DatosGenerales
    ADD CONSTRAINT FK_DatosGenerales_iIdClaseVehicular
        FOREIGN KEY (iIdClaseVehicular) REFERENCES Catalogo.ClasesVehiculares (iIdClaseVehicular);

ALTER TABLE Patrimonio.DatosGenerales
    ADD CONSTRAINT FK_DatosGenerales_iIdTipoVehicular
        FOREIGN KEY (iIdTipoVehicular) REFERENCES Catalogo.TiposVehiculares (iIdTipoVehicular);

ALTER TABLE Patrimonio.DatosGenerales
    ADD CONSTRAINT FK_DatosGenerales_iIdColor
        FOREIGN KEY (iIdColor) REFERENCES Catalogo.Colores (iIdColor);

ALTER TABLE Patrimonio.DatosGenerales
    ADD CONSTRAINT FK_DatosGenerales_iIdCombustibleVehicular
        FOREIGN KEY (iIdCombustibleVehicular) REFERENCES Catalogo.CombustiblesVehiculares (iIdCombustibleVehicular);

CREATE TABLE Patrimonio.TiposDominios
(
    iIdTipoDominio      BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Patrimonio.TiposBienesInmuebles
(
    iIdTipoBienInmueble BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    sDescripcion        NVARCHAR(MAX)                     NOT NULL,
    iNivel              INT                               NOT NULL,
    sClave              NVARCHAR(50)                      NOT NULL,
    sClaveCompleta      NVARCHAR(50)                      NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Patrimonio.DatosRegistrales
(
    iIdDatoRegistral       BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre                NVARCHAR(255)                     NOT NULL,
    iFolioElectronico      INT                               NOT NULL,
    iFolioCatastro         INT                               NOT NULL,
    sCalle                 NVARCHAR(150)                     NOT NULL,
    dSuperficie            DOUBLE PRECISION                  NOT NULL,
    dValorTerreno          DOUBLE PRECISION                  NOT NULL,
    sNumeroExterior        NVARCHAR(50),
    sNumeroInterior        NVARCHAR(50),
    sCruzamimiento1        NVARCHAR(50),
    sCruzamimiento2        NVARCHAR(50),
    dSuperficieContruccion DOUBLE PRECISION                  NOT NULL,
    sTablaje               NVARCHAR(255),
    dValorConstruccion     DOUBLE PRECISION                  NOT NULL,
    dValorInicial          DOUBLE PRECISION                  NOT NULL,
    nCodigoPostal          NUMERIC(10),
    iIdOrigenValor         BIGINT                            NOT NULL,
    sAsentamiento          NVARCHAR(255),
    sPropietario           NVARCHAR(255),
    bActivo                BIT                               NOT NULL,
    dtFechaCreacion        DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion    DATETIME                          NOT NULL DEFAULT GETDATE()
);

ALTER TABLE Patrimonio.DatosRegistrales
    ADD CONSTRAINT FK_iIdOrigenValor
        FOREIGN KEY (iIdOrigenValor) REFERENCES Catalogo.OrigenesValores (iIdOrigenValor);

CREATE TABLE Patrimonio.DatosInmuebles
(
    iIdDatoInmueble    BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNomenclatura      NVARCHAR(MAX),
    iIdTipoInmueble    BIGINT                            NOT NULL,
    iIdUsoInmueble     BIGINT                            NOT NULL,
    iIdTipoDomninio    BIGINT                            NOT NULL,
    iIdEstadoGeneral   BIGINT                            NOT NULL,
    iIdTipoAfectacion  BIGINT                            NOT NULL,
    sAfectante         NVARCHAR(300)                     NOT NULL,
    sPublicacion       NVARCHAR(255)                     NOT NULL,
    dtFechaAltaSistema DATE                              NOT NULL,
    iIdDatoRegistral   BIGINT                            NOT NULL,
);

ALTER TABLE Patrimonio.DatosInmuebles
    ADD CONSTRAINT FK_iIdTipoInmueble
        FOREIGN KEY (iIdTipoInmueble) REFERENCES Catalogo.TiposInmuebles (iIdTipoInmueble);

ALTER TABLE Patrimonio.DatosInmuebles
    ADD CONSTRAINT FK_iIdUsoInmueble
        FOREIGN KEY (iIdUsoInmueble) REFERENCES Catalogo.UsosInmuebles (iIdUsoInmueble);

ALTER TABLE Patrimonio.DatosInmuebles
    ADD CONSTRAINT FK_iIdTipoDomninio
        FOREIGN KEY (iIdTipoDomninio) REFERENCES Patrimonio.TiposDominios (iIdTipoDominio);

ALTER TABLE Patrimonio.DatosInmuebles
    ADD CONSTRAINT FK_iIdEstadoGeneral
        FOREIGN KEY (iIdEstadoGeneral) REFERENCES Catalogo.EstadosGenerales (iIdEstadoGeneral);

ALTER TABLE Patrimonio.DatosInmuebles
    ADD CONSTRAINT FK_iIdTipoAfectacion
        FOREIGN KEY (iIdTipoAfectacion) REFERENCES Catalogo.TiposAfectaciones (iIdTipoAfectacion);

ALTER TABLE Patrimonio.DatosInmuebles
    ADD CONSTRAINT FK_iIdInformacionRegistral
        FOREIGN KEY (iIdDatoRegistral) REFERENCES Patrimonio.DatosRegistrales (iIdDatoRegistral);

CREATE TABLE Patrimonio.Afectaciones
(
    iIdAfectacion       BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(50)                      NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Patrimonio.Bienes
(
    iIdBien                 BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdPeriodo              BIGINT                            NOT NULL,
    iIdTipoBien             BIGINT                            NOT NULL,
    sFolioBien              NVARCHAR(MAX),
    iIdFamilia              BIGINT                            NOT NULL,
    iIdSubfamilia           BIGINT                            NOT NULL,
    iIdBMS                  BIGINT                            NOT NULL,
    sReferenciaCONAC        NVARCHAR(50),
    sPartidaEspecifica      NVARCHAR(50),
    sDescripcion            NVARCHAR(MAX)                     NOT NULL,
    iIdUnidadAdministrativa BIGINT                            NOT NULL,
    sRequisicion            NVARCHAR(MAX),
    sOrdenCompra            NVARCHAR(MAX),
    sCuentaPorPagar         NVARCHAR(MAX),
    iIdTipoAdquisicion      BIGINT                            NOT NULL,
    iIdMunicipio            BIGINT                            NOT NULL,
    sSustituyeBV            NVARCHAR(50),
    iIdUbicacion            BIGINT                            NOT NULL,
    sNoSeries               NVARCHAR(MAX),
    sFolioAnterior          NVARCHAR(10),
    iIdEstadoFisico         BIGINT                            NOT NULL,
    dPrecioUnitario         DOUBLE PRECISION                  NOT NULL,
    iAniosVida              INT                               NOT NULL,
    dtFechaInicioUso        DATE                              NOT NULL,
    dtFechaAdquisicion      DATE                              NOT NULL,
    dPrecioDepreciado       DOUBLE PRECISION                  NOT NULL,
    dPrecioDesechable       DOUBLE PRECISION                  NOT NULL,
    sCuentaActivo           NVARCHAR(50),
    sCuentaActualizacion    NVARCHAR(50),
    sCaracteristicas        NVARCHAR(MAX),
    sResguardantes          NVARCHAR(MAX),
    sObservacionBien        NVARCHAR(MAX),
    sObservacionResponsable NVARCHAR(MAX),
    idDatoInmueble          BIGINT,
    dtFechaBaja             DATE,
    dtFechaAlta             DATE,
    sMotivoBaja             NVARCHAR(MAX),
    bDeprecia               BIT                               NOT NULL DEFAULT 1,
);

ALTER TABLE Patrimonio.Bienes
    ADD CONSTRAINT FK_Bienes_iIdPeriodo
        FOREIGN KEY (iIdPeriodo) REFERENCES General.Periodos (iIdPeriodo);

ALTER TABLE Patrimonio.Bienes
    ADD CONSTRAINT FK_Bienes_iIdTipoBien
        FOREIGN KEY (iIdTipoBien) REFERENCES Catalogo.TiposBienes (iIdTipoBien);

ALTER TABLE Patrimonio.Bienes
    ADD CONSTRAINT FK_Bienes_iIdFamilia
        FOREIGN KEY (iIdFamilia) REFERENCES Catalogo.Familias (iIdFamilia);

ALTER TABLE Patrimonio.Bienes
    ADD CONSTRAINT FK_Bienes_iIdSubfamilia
        FOREIGN KEY (iIdSubfamilia) REFERENCES Catalogo.Subfamilias (iIdSubfamilia);

ALTER TABLE Patrimonio.Bienes
    ADD CONSTRAINT FK_Bienes_iIdBMS
        FOREIGN KEY (iIdBMS) REFERENCES General.BMS (iIdBMS);

ALTER TABLE Patrimonio.Bienes
    ADD CONSTRAINT FK_Bienes_iIdUnidadAdministrativa
        FOREIGN KEY (iIdUnidadAdministrativa) REFERENCES General.UnidadesAdministrativas (iIdUnidadAdministrativa);

ALTER TABLE Patrimonio.Bienes
    ADD CONSTRAINT FK_Bienes_iIdTipoAdquisicion
        FOREIGN KEY (iIdTipoAdquisicion) REFERENCES Catalogo.TiposAdquisiciones (iIdTipoAdquisicion);

ALTER TABLE Patrimonio.Bienes
    ADD CONSTRAINT FK_Bienes_iIdMunicipio
        FOREIGN KEY (iIdMunicipio) REFERENCES General.Municipios (iIdMunicipio);

ALTER TABLE Patrimonio.Bienes
    ADD CONSTRAINT FK_Bienes_iIdUbicacion
        FOREIGN KEY (iIdUbicacion) REFERENCES Catalogo.Ubicaciones (iIdUbicacion);

ALTER TABLE Patrimonio.Bienes
    ADD CONSTRAINT FK_Bienes_iIdEstadoFisico
        FOREIGN KEY (iIdEstadoFisico) REFERENCES Catalogo.EstadosFisicos (iIdEstadoFisico);

ALTER TABLE Patrimonio.Bienes
    ADD CONSTRAINT FK_Bienes_iIdDatoInmueble
        FOREIGN KEY (idDatoInmueble) REFERENCES Patrimonio.DatosInmuebles (iIdDatoInmueble);


CREATE TABLE Patrimonio.Solicitudes
(
    iIdSolicitud            BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdEmpleado             BIGINT                            NOT NULL,
    iIdEtapa                BIGINT                            NOT NULL,
    iIdPeriodo              BIGINT                            NOT NULL,
    iIdUnidadAdministrativa BIGINT                            NOT NULL,
    iIdTipoTramite          BIGINT                            NOT NULL,
    iIdMotivoTramite        BIGINT                            NOT NULL,
    iIdAfectacion           BIGINT                            NOT NULL,
    dtFechaAfectacion       DATE                              NOT NULL,
    sDocumentoReferencia    NVARCHAR(MAX),
    sObservaciones          NVARCHAR(MAX),
    dtFechaCreacion         DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion     DATETIME                          NOT NULL DEFAULT GETDATE()
);

ALTER TABLE Patrimonio.Solicitudes
    ADD CONSTRAINT FK_Solicitudes_iIdPeriodo
        FOREIGN KEY (iIdPeriodo) REFERENCES General.Periodos (iIdPeriodo);

ALTER TABLE Patrimonio.Solicitudes
    ADD CONSTRAINT FK_Solicitudes_iIdEmpleado
        FOREIGN KEY (iIdEmpleado) REFERENCES Seguridad.Empleados (iIdEmpleado);

ALTER TABLE Patrimonio.Solicitudes
    ADD CONSTRAINT FK_Solicitudes_iIdEtapa
        FOREIGN KEY (iIdEtapa) REFERENCES Patrimonio.Etapas (iIdEtapa);

ALTER TABLE Patrimonio.Solicitudes
    ADD CONSTRAINT FK_Solicitudes_iIdUnidadAdministrativa
        FOREIGN KEY (iIdUnidadAdministrativa) REFERENCES General.UnidadesAdministrativas (iIdUnidadAdministrativa);

ALTER TABLE Patrimonio.Solicitudes
    ADD CONSTRAINT FK_Solicitudes_iIdTipoTramite
        FOREIGN KEY (iIdTipoTramite) REFERENCES Patrimonio.TiposTramites (iIdTipoTramite);

ALTER TABLE Patrimonio.Solicitudes
    ADD CONSTRAINT FK_Solicitudes_iIdMotivoTramite
        FOREIGN KEY (iIdMotivoTramite) REFERENCES Patrimonio.MotivosTramites (iIdMotivoTramite);

ALTER TABLE Patrimonio.Solicitudes
    ADD CONSTRAINT FK_Solicitudes_iIdAfectacionSolicitud
        FOREIGN KEY (iIdAfectacion) REFERENCES Patrimonio.Afectaciones (iIdAfectacion);

CREATE TABLE Patrimonio.DetallesAltas
(
    iIdDetalleAlta          BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdSolicitud            BIGINT                            NOT NULL,
    iIdEtapa                BIGINT                            NOT NULL,
    iNumeroBienes           INT                               NOT NULL,
    iIdTipoBien             BIGINT                            NOT NULL,
    sFolioBien              NVARCHAR(MAX),
    iIdFamilia              BIGINT                            NOT NULL,
    iIdSubfamilia           BIGINT                            NOT NULL,
    iIdBMS                  BIGINT                            NOT NULL,
    sReferenciaCONAC        NVARCHAR(50),
    sPartidaEspecifica      NVARCHAR(50),
    sDescripcion            NVARCHAR(MAX)                     NOT NULL,
    iIdUnidadAdministrativa BIGINT                            NOT NULL,
    sRequisicion            NVARCHAR(MAX),
    sOrdenCompra            NVARCHAR(MAX),
    sCuentaPorPagar         NVARCHAR(MAX),
    iIdTipoAdquisicion      BIGINT                            NOT NULL,
    iIdMunicipio            BIGINT                            NOT NULL,
    sSustituyeBV            NVARCHAR(50),
    iIdUbicacion            BIGINT                            NOT NULL,
    sNoSeries               NVARCHAR(MAX),
    sFolioAnterior          NVARCHAR(10),
    iIdEstadoFisico         BIGINT                            NOT NULL,
    dPrecioUnitario         DOUBLE PRECISION                  NOT NULL,
    iAniosVida              INT                               NOT NULL,
    dtFechaInicioUso        DATE                              NOT NULL,
    dtFechaAdquisicion      DATE                              NOT NULL,
    dPrecioDepreciado       DOUBLE PRECISION                  NOT NULL,
    dPrecioDesechable       DOUBLE PRECISION                  NOT NULL,
    sCuentaActivo           NVARCHAR(50),
    sCuentaActualizacion    NVARCHAR(50),
    sCaracteristicas        NVARCHAR(MAX),
    sResguardantes          NVARCHAR(MAX),
    sObservacionBien        NVARCHAR(MAX),
    sObservacionResponsable NVARCHAR(MAX),
    idDatoInmueble          BIGINT,
    iIdLicitacion           BIGINT,
    iIdFactura              BIGINT,
);

ALTER TABLE Patrimonio.DetallesAltas
    ADD CONSTRAINT FK_DetallesAltas_iIdSolicitud
        FOREIGN KEY (iIdSolicitud) REFERENCES Patrimonio.Solicitudes (iIdSolicitud);

ALTER TABLE Patrimonio.DetallesAltas
    ADD CONSTRAINT FK_DetallesAltas_iIdEtapa
        FOREIGN KEY (iIdEtapa) REFERENCES Patrimonio.Etapas (iIdEtapa);

ALTER TABLE Patrimonio.DetallesAltas
    ADD CONSTRAINT FK_DetallesAltas_iIdTipoBien
        FOREIGN KEY (iIdTipoBien) REFERENCES Catalogo.TiposBienes (iIdTipoBien);

ALTER TABLE Patrimonio.DetallesAltas
    ADD CONSTRAINT FK_DetallesAltas_iIdFamilia
        FOREIGN KEY (iIdFamilia) REFERENCES Catalogo.Familias (iIdFamilia);

ALTER TABLE Patrimonio.DetallesAltas
    ADD CONSTRAINT FK_DetallesAltas_iIdSubfamilia
        FOREIGN KEY (iIdSubfamilia) REFERENCES Catalogo.Subfamilias (iIdSubfamilia);

ALTER TABLE Patrimonio.DetallesAltas
    ADD CONSTRAINT FK_DetallesAltas_iIdBMS
        FOREIGN KEY (iIdBMS) REFERENCES General.BMS (iIdBMS);

ALTER TABLE Patrimonio.DetallesAltas
    ADD CONSTRAINT FK_DetallesAltas_iIdUnidadAdministrativa
        FOREIGN KEY (iIdUnidadAdministrativa) REFERENCES General.UnidadesAdministrativas (iIdUnidadAdministrativa);

ALTER TABLE Patrimonio.DetallesAltas
    ADD CONSTRAINT FK_DetallesAltas_iIdTipoAdquisicion
        FOREIGN KEY (iIdTipoAdquisicion) REFERENCES Catalogo.TiposAdquisiciones (iIdTipoAdquisicion);

ALTER TABLE Patrimonio.DetallesAltas
    ADD CONSTRAINT FK_DetallesAltas_iIdMunicipio
        FOREIGN KEY (iIdMunicipio) REFERENCES General.Municipios (iIdMunicipio);

ALTER TABLE Patrimonio.DetallesAltas
    ADD CONSTRAINT FK_DetallesAltas_iIdUbicacion
        FOREIGN KEY (iIdUbicacion) REFERENCES Catalogo.Ubicaciones (iIdUbicacion);

ALTER TABLE Patrimonio.DetallesAltas
    ADD CONSTRAINT FK_DetallesAltas_iIdEstadoFisico
        FOREIGN KEY (iIdEstadoFisico) REFERENCES Catalogo.EstadosFisicos (iIdEstadoFisico);

ALTER TABLE Patrimonio.DetallesAltas
    ADD CONSTRAINT FK_DetallesAltas_iIdDatosInmueblesAltas
        FOREIGN KEY (idDatoInmueble) REFERENCES Patrimonio.DatosInmuebles (iIdDatoInmueble);

ALTER TABLE Patrimonio.DetallesAltas
    ADD CONSTRAINT FK_DetallesAltas_iIdLicitacion
        FOREIGN KEY (iIdLicitacion) REFERENCES Patrimonio.Licitaciones (iIdLicitacion);

ALTER TABLE Patrimonio.DetallesAltas
    ADD CONSTRAINT FK_DetallesAltas_iIdFactura
        FOREIGN KEY (iIdFactura) REFERENCES Patrimonio.Facturas (iIdFactura);

CREATE TABLE Patrimonio.Bajas
(
    iIdBaja                 BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdUnidadAdministrativa BIGINT                            NOT NULL,
    iIdEmpleado             BIGINT                            NOT NULL,
    iIdTipoBien             BIGINT                            NOT NULL,
    sFolioBien              NVARCHAR(MAX)                     NOT NULL,
    sObservaciones          NVARCHAR(MAX),
    sFolioDictamen          NVARCHAR(25)                      NOT NULL,
    dtFehaDocumento         DATE                              NOT NULL,
    sListaDocunetario       NVARCHAR(MAX),
    sNombreSolicitante      NVARCHAR(255)                     NOT NULL,
    sLugarResguardo         NVARCHAR(255)                     NOT NULL,
);

ALTER TABLE Patrimonio.Bajas
    ADD CONSTRAINT FK_Bajas_iIdUnidadAdministrativa
        FOREIGN KEY (iIdUnidadAdministrativa) REFERENCES General.UnidadesAdministrativas (iIdUnidadAdministrativa);

ALTER TABLE Patrimonio.Bajas
    ADD CONSTRAINT FK_Bajas_iIdEmpleado
        FOREIGN KEY (iIdEmpleado) REFERENCES Seguridad.Empleados (iIdEmpleado);

ALTER TABLE Patrimonio.Bajas
    ADD CONSTRAINT FK_Bajas_iIdTipoBien
        FOREIGN KEY (iIdTipoBien) REFERENCES Catalogo.TiposBienes (iIdTipoBien);

CREATE TABLE Patrimonio.BajasInmuebles
(
    iIdBajaInmueble                 BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdBien                         BIGINT                            NOT NULL,
    iFolioElectronico               INT,
    sClaveCatastral                 NVARCHAR(50),
    dtFechaBaja                     DATE                              NOT NULL,
    dtFechaBajaSistema              DATE                              NOT NULL,
    dValorBaja                      DOUBLE PRECISION                  NOT NULL,
    sEscrituraTitulo                NVARCHAR(255),
    dtFechaDesincorporacion         DATE                              NOT NULL,
    sInmueblePermutado              NVARCHAR(255),
    sAvaluo1                        NVARCHAR(255),
    sAvaluo2                        NVARCHAR(255),
    sAFavorDe                       NVARCHAR(255)                     NOT NULL,
    sDecretoPublicacion             NVARCHAR(255)                     NOT NULL,
    sReferencaPoliza                NVARCHAR(MAX),
    sJustificacion                  NVARCHAR(MAX),
    iIdUsoInmueble                  BIGINT                            NOT NULL,
    iIdTipoInmueble                 BIGINT                            NOT NULL,
    iIdTipoDomninio                 BIGINT                            NOT NULL,
    sObservacion                    NVARCHAR(MAX)                     NOT NULL,
    sDestinoBien                    NVARCHAR(MAX),
    dValorBienPermutadoConstruccion DOUBLE PRECISION                  NOT NULL,
    dValorBienPermutadoTerreno      DOUBLE PRECISION                  NOT NULL,
    dtFechaPermuta                  DATE                              NOT NULL,
    sRepositario                    NVARCHAR(255),
    sExpedienteUnion                NVARCHAR(255),
    dtFechaUnion                    DATE,
    sDonatario                      NVARCHAR(255)                     NOT NULL,
    dtFechaDonacion                 DATE                              NOT NULL,
    sDecretoPublicacionDonacion     NVARCHAR(255)                     NOT NULL,
);

ALTER TABLE Patrimonio.BajasInmuebles
    ADD CONSTRAINT FK_BajasInmuebles_iIdBien
        FOREIGN KEY (iIdBien) REFERENCES Patrimonio.Bienes (iIdBien);

ALTER TABLE Patrimonio.BajasInmuebles
    ADD CONSTRAINT FK_BajasInmuebles_iIdTipoInmueble
        FOREIGN KEY (iIdTipoInmueble) REFERENCES Catalogo.TiposInmuebles (iIdTipoInmueble);

ALTER TABLE Patrimonio.BajasInmuebles
    ADD CONSTRAINT FK_BajasInmuebles_iIdTipoDomninio
        FOREIGN KEY (iIdTipoDomninio) REFERENCES Patrimonio.TiposDominios (iIdTipoDominio);

ALTER TABLE Patrimonio.BajasInmuebles
    ADD CONSTRAINT FK_BajasInmuebles_iIdUsoInmueble
        FOREIGN KEY (iIdUsoInmueble) REFERENCES Catalogo.UsosInmuebles (iIdUsoInmueble);


CREATE TABLE Patrimonio.DetallesBajas
(
    iIdDetalleBaja  BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdSolicitud    BIGINT                            NOT NULL,
    iIdBaja         BIGINT                            NOT NULL,
    iIdBajaInmueble BIGINT                            NOT NULL,
);

ALTER TABLE Patrimonio.DetallesBajas
    ADD CONSTRAINT FK_DetallesBajas_iIdSolicitud
        FOREIGN KEY (iIdSolicitud) REFERENCES Patrimonio.Solicitudes (iIdSolicitud);

ALTER TABLE Patrimonio.DetallesBajas
    ADD CONSTRAINT FK_DetallesBajas_iIdBaja
        FOREIGN KEY (iIdBaja) REFERENCES Patrimonio.Bajas (iIdBaja);

ALTER TABLE Patrimonio.DetallesBajas
    ADD CONSTRAINT FK_DetallesBajas_iIdBajaInmueble
        FOREIGN KEY (iIdBajaInmueble) REFERENCES Patrimonio.BajasInmuebles (iIdBajaInmueble);

CREATE TABLE Patrimonio.DetallesMovimientos
(
    iIdDetalleMovimiento         BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdTipoBien                  BIGINT                            NOT NULL,
    iIdUnidadAdministrativa      BIGINT                            NOT NULL,
    sFolioBien                   NVARCHAR(MAX)                     NOT NULL,
    iIdNuevaUnidadAdministrativa BIGINT,
    iIdMunicipio                 BIGINT                            NOT NULL,
    iIdUbicacion                 BIGINT,
    sResponsable                 NVARCHAR(MAX),
);

ALTER TABLE Patrimonio.DetallesMovimientos
    ADD CONSTRAINT FK_DetallesMovimientos_iIdTipoBien
        FOREIGN KEY (iIdTipoBien) REFERENCES Catalogo.TiposBienes (iIdTipoBien);

ALTER TABLE Patrimonio.DetallesMovimientos
    ADD CONSTRAINT FK_DetallesMovimientos_iIdUnidadAdministrativa
        FOREIGN KEY (iIdUnidadAdministrativa) REFERENCES General.UnidadesAdministrativas (iIdUnidadAdministrativa);

ALTER TABLE Patrimonio.DetallesMovimientos
    ADD CONSTRAINT FK_DetallesMovimientos_iIdMunicipio
        FOREIGN KEY (iIdMunicipio) REFERENCES General.Municipios (iIdMunicipio);

ALTER TABLE Patrimonio.DetallesMovimientos
    ADD CONSTRAINT FK_DetallesMovimientos_iIdUbicacion
        FOREIGN KEY (iIdUbicacion) REFERENCES Catalogo.Ubicaciones (iIdUbicacion);

ALTER TABLE Patrimonio.DetallesMovimientos
    ADD CONSTRAINT FK_DetallesMovimientos_iIdNuevaUnidadAdministrativa
        FOREIGN KEY (iIdNuevaUnidadAdministrativa) REFERENCES General.UnidadesAdministrativas (iIdUnidadAdministrativa);

CREATE TABLE Patrimonio.DetallesModificaciones
(
    iIdDetalleModificacion  BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdBien                 BIGINT                            NOT NULL,
    iIdSolicitud            BIGINT                            NOT NULL,
    iIdEtapa                BIGINT                            NOT NULL,
    iNumeroBienes           INT                               NOT NULL,
    iIdTipoBien             BIGINT                            NOT NULL,
    sFolioBien              NVARCHAR(MAX),
    iIdFamilia              BIGINT                            NOT NULL,
    iIdSubfamilia           BIGINT                            NOT NULL,
    iIdBMS                  BIGINT                            NOT NULL,
    sReferenciaCONAC        NVARCHAR(50),
    sPartidaEspecifica      NVARCHAR(50),
    sDescripcion            NVARCHAR(MAX)                     NOT NULL,
    iIdUnidadAdministrativa BIGINT                            NOT NULL,
    sRequisicion            NVARCHAR(MAX),
    sOrdenCompra            NVARCHAR(MAX),
    sCuentaPorPagar         NVARCHAR(MAX),
    iIdTipoAdquisicion      BIGINT                            NOT NULL,
    iIdMunicipio            BIGINT                            NOT NULL,
    sSustituyeBV            NVARCHAR(50),
    iIdUbicacion            BIGINT                            NOT NULL,
    sNoSeries               NVARCHAR(MAX),
    sFolioAnterior          NVARCHAR(10),
    iIdEstadoFisico         BIGINT                            NOT NULL,
    dPrecioUnitario         DOUBLE PRECISION                  NOT NULL,
    iAniosVida              INT                               NOT NULL,
    dtFechaInicioUso        DATE                              NOT NULL,
    dtFechaAdquisicion      DATE                              NOT NULL,
    dPrecioDepreciado       DOUBLE PRECISION                  NOT NULL,
    dPrecioDesechable       DOUBLE PRECISION                  NOT NULL,
    sCuentaActivo           NVARCHAR(50),
    sCuentaActualizacion    NVARCHAR(50),
    sCaracteristicas        NVARCHAR(MAX),
    sResguardantes          NVARCHAR(MAX),
    sObservacionBien        NVARCHAR(MAX),
    sObservacionResponsable NVARCHAR(MAX),
    iIdDatoInmueble         BIGINT,
    iIdLicitacion           BIGINT,
    iIdFactura              BIGINT,
);

ALTER TABLE Patrimonio.DetallesModificaciones
    ADD CONSTRAINT FK_DetallesModificaciones_iIdSolicitud
        FOREIGN KEY (iIdSolicitud) REFERENCES Patrimonio.Solicitudes (iIdSolicitud);

ALTER TABLE Patrimonio.DetallesModificaciones
    ADD CONSTRAINT FK_DetallesModificaciones_iIdBien
        FOREIGN KEY (iIdBien) REFERENCES Patrimonio.Bienes (iIdBien);

ALTER TABLE Patrimonio.DetallesModificaciones
    ADD CONSTRAINT FK_DetallesModificaciones_iIdEtapa
        FOREIGN KEY (iIdEtapa) REFERENCES Patrimonio.Etapas (iIdEtapa);

ALTER TABLE Patrimonio.DetallesModificaciones
    ADD CONSTRAINT FK_DetallesModificaciones_iIdTipoBien
        FOREIGN KEY (iIdTipoBien) REFERENCES Catalogo.TiposBienes (iIdTipoBien);

ALTER TABLE Patrimonio.DetallesModificaciones
    ADD CONSTRAINT FK_DetallesModificaciones_iIdFamilia
        FOREIGN KEY (iIdFamilia) REFERENCES Catalogo.Familias (iIdFamilia);

ALTER TABLE Patrimonio.DetallesModificaciones
    ADD CONSTRAINT FK_DetallesModificaciones_iIdSubfamilia
        FOREIGN KEY (iIdSubfamilia) REFERENCES Catalogo.Subfamilias (iIdSubfamilia);

ALTER TABLE Patrimonio.DetallesModificaciones
    ADD CONSTRAINT FK_DetallesModificaciones_iIdBMS
        FOREIGN KEY (iIdBMS) REFERENCES General.BMS (iIdBMS);

ALTER TABLE Patrimonio.DetallesModificaciones
    ADD CONSTRAINT FK_DetallesModificaciones_iIdUnidadAdministrativa
        FOREIGN KEY (iIdUnidadAdministrativa) REFERENCES General.UnidadesAdministrativas (iIdUnidadAdministrativa);

ALTER TABLE Patrimonio.DetallesModificaciones
    ADD CONSTRAINT FK_DetallesModificaciones_iIdTipoAdquisicion
        FOREIGN KEY (iIdTipoAdquisicion) REFERENCES Catalogo.TiposAdquisiciones (iIdTipoAdquisicion);

ALTER TABLE Patrimonio.DetallesModificaciones
    ADD CONSTRAINT FK_DetallesModificaciones_iIdMunicipio
        FOREIGN KEY (iIdMunicipio) REFERENCES General.Municipios (iIdMunicipio);

ALTER TABLE Patrimonio.DetallesModificaciones
    ADD CONSTRAINT FK_DetallesModificaciones_iIdUbicacion
        FOREIGN KEY (iIdUbicacion) REFERENCES Catalogo.Ubicaciones (iIdUbicacion);

ALTER TABLE Patrimonio.DetallesModificaciones
    ADD CONSTRAINT FK_DetallesModificaciones_iIdEstadoFisico
        FOREIGN KEY (iIdEstadoFisico) REFERENCES Catalogo.EstadosFisicos (iIdEstadoFisico);

ALTER TABLE Patrimonio.DetallesModificaciones
    ADD CONSTRAINT FK_DetallesModificaciones_iIdDatosInmueblesModificaciones
        FOREIGN KEY (iIdDatoInmueble) REFERENCES Patrimonio.DatosInmuebles (iIdDatoInmueble);

CREATE TABLE Patrimonio.DetallesDesincorporaciones
(
    iIdDetalleDesincorporacion   BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdUnidadAdministrativa      BIGINT                            NOT NULL,
    iIdEmpleado                  BIGINT                            NOT NULL,
    iIdTipoBien                  BIGINT                            NOT NULL,
    sFolioBien                   NVARCHAR(MAX)                     NOT NULL,
    sObservaciones               NVARCHAR(MAX)                     NOT NULL,
    dtFechaPublicacion           DATE                              NOT NULL,
    sNumeroPublicacion           NVARCHAR(255)                     NOT NULL,
    sDescripcionDesincorporacion NVARCHAR(MAX)                     NOT NULL,
);

ALTER TABLE Patrimonio.DetallesDesincorporaciones
    ADD CONSTRAINT FK_DetallesDesincorporaciones_iIdUnidadAdministrativa
        FOREIGN KEY (iIdUnidadAdministrativa) REFERENCES General.UnidadesAdministrativas (iIdUnidadAdministrativa);

ALTER TABLE Patrimonio.DetallesDesincorporaciones
    ADD CONSTRAINT FK_DetallesDesincorporaciones_iIdEmpleado
        FOREIGN KEY (iIdEmpleado) REFERENCES Seguridad.Empleados (iIdEmpleado);

ALTER TABLE Patrimonio.DetallesDesincorporaciones
    ADD CONSTRAINT FK_DetallesDesincorporaciones_iIdTipoBien
        FOREIGN KEY (iIdTipoBien) REFERENCES Catalogo.TiposBienes (iIdTipoBien);

CREATE TABLE Patrimonio.DetallesEnagenaciones
(
    iIdDetalleEnagenacion BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sFolio                NVARCHAR(255)                     NOT NULL,
    dtFecha               DATE                              NOT NULL,
    sAvaluo               NVARCHAR(255)                     NOT NULL,
    dImporteAvaluo        DOUBLE PRECISION                  NOT NULL,
    dImporte              DOUBLE PRECISION                  NOT NULL,
    sDescripcion          NVARCHAR(MAX)                     NOT NULL,
);

CREATE TABLE Patrimonio.DetallesDestrucciones
(
    iIdDetalleDestruccion BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sFolio                NVARCHAR(255)                     NOT NULL,
    dtFecha               DATE                              NOT NULL,
    sDescripcion          NVARCHAR(MAX)                     NOT NULL,
);

CREATE TABLE Patrimonio.DetallesDestinoFinales
(
    iIdDetalleDestinoFinal  BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdUnidadAdministrativa BIGINT                            NOT NULL,
    iIdEmpleado             BIGINT                            NOT NULL,
    iIdTipoBien             BIGINT                            NOT NULL,
    sFolioBien              NVARCHAR(MAX)                     NOT NULL,
    iIdAfectacion           BIGINT                            NOT NULL,
    iIdDetalleEnagenacion   BIGINT,
    iIdDetalleDestruccion   BIGINT,
    sObservaciones          NVARCHAR(MAX)                     NOT NULL,
);

ALTER TABLE Patrimonio.DetallesDestinoFinales
    ADD CONSTRAINT FK_DetallesDestinoFinales_iIdUnidadAdministrativa
        FOREIGN KEY (iIdUnidadAdministrativa) REFERENCES General.UnidadesAdministrativas (iIdUnidadAdministrativa);

ALTER TABLE Patrimonio.DetallesDestinoFinales
    ADD CONSTRAINT FK_DetallesDestinoFinales_iIdEmpleado
        FOREIGN KEY (iIdEmpleado) REFERENCES Seguridad.Empleados (iIdEmpleado);

ALTER TABLE Patrimonio.DetallesDestinoFinales
    ADD CONSTRAINT FK_DetallesDestinoFinales_iIdTipoBien
        FOREIGN KEY (iIdTipoBien) REFERENCES Catalogo.TiposBienes (iIdTipoBien);

ALTER TABLE Patrimonio.DetallesDestinoFinales
    ADD CONSTRAINT FK_DetallesDestinoFinales_iIdAfectacion
        FOREIGN KEY (iIdAfectacion) REFERENCES Patrimonio.Afectaciones (iIdAfectacion);

ALTER TABLE Patrimonio.DetallesDestinoFinales
    ADD CONSTRAINT FK_DetallesDestinoFinales_iIdDetalleEnagenacion
        FOREIGN KEY (iIdDetalleEnagenacion) REFERENCES Patrimonio.DetallesEnagenaciones (iIdDetalleEnagenacion);

ALTER TABLE Patrimonio.DetallesDestinoFinales
    ADD CONSTRAINT FK_DetallesDestinoFinales_iIdDetalleDestruccion
        FOREIGN KEY (iIdDetalleDestruccion) REFERENCES Patrimonio.DetallesDestrucciones (iIdDetalleDestruccion);

CREATE TABLE Patrimonio.DetallesSolicitudes
(
    iIdDetalleSolicitud        BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdSolicitud               BIGINT                            NOT NULL,
    iIdEtapa                   BIGINT                            NOT NULL,
    iIdDetalleAlta             BIGINT,
    iIdDetalleBaja             BIGINT,
    iIdDetalleMovimiento       BIGINT,
    iIdDetalleModificacion     BIGINT,
    iIdDetalleDesincorporacion BIGINT,
    iIdDetalleDestinoFinal     BIGINT,
    dtFechaCreacion            DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion        DATETIME                          NOT NULL DEFAULT GETDATE(),
);

ALTER TABLE Patrimonio.DetallesSolicitudes
    ADD CONSTRAINT FK_DetallesSolicitudes_iIdSolicitud
        FOREIGN KEY (iIdSolicitud) REFERENCES Patrimonio.Solicitudes (iIdSolicitud);

ALTER TABLE Patrimonio.DetallesSolicitudes
    ADD CONSTRAINT FK_DetallesSolicitudes_iIdEtapa
        FOREIGN KEY (iIdEtapa) REFERENCES Patrimonio.Etapas (iIdEtapa);

ALTER TABLE Patrimonio.DetallesSolicitudes
    ADD CONSTRAINT FK_DetallesSolicitudes_iIdDetalleAlta
        FOREIGN KEY (iIdDetalleAlta) REFERENCES Patrimonio.DetallesAltas (iIdDetalleAlta);

ALTER TABLE Patrimonio.DetallesSolicitudes
    ADD CONSTRAINT FK_DetallesSolicitudes_iIdDetalleBaja
        FOREIGN KEY (iIdDetalleBaja) REFERENCES Patrimonio.DetallesBajas (iIdDetalleBaja);

ALTER TABLE Patrimonio.DetallesSolicitudes
    ADD CONSTRAINT FK_DetallesSolicitudes_iIdDetalleMovimiento
        FOREIGN KEY (iIdDetalleMovimiento) REFERENCES Patrimonio.DetallesMovimientos (iIdDetalleMovimiento);

ALTER TABLE Patrimonio.DetallesSolicitudes
    ADD CONSTRAINT FK_DetallesSolicitudes_iIdDetalleModificacion
        FOREIGN KEY (iIdDetalleModificacion) REFERENCES Patrimonio.DetallesModificaciones (iIdDetalleModificacion);

ALTER TABLE Patrimonio.DetallesSolicitudes
    ADD CONSTRAINT FK_DetallesSolicitudes_iIdDetalleDesincorporacion
        FOREIGN KEY (iIdDetalleDesincorporacion) REFERENCES Patrimonio.DetallesDesincorporaciones (iIdDetalleDesincorporacion);

ALTER TABLE Patrimonio.DetallesSolicitudes
    ADD CONSTRAINT FK_DetallesSolicitudes_iIdDetalleDestinoFinal
        FOREIGN KEY (iIdDetalleDestinoFinal) REFERENCES Patrimonio.DetallesDestinoFinales (iIdDetalleDestinoFinal);

CREATE TABLE Patrimonio.Seguimientos
(
    iIdSeguimiento      BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdDetalleSolicitud BIGINT                            NOT NULL,
    dtFechaHora         DATETIME                          NOT NULL DEFAULT GETDATE(),
    iIdModulo           BIGINT                            NOT NULL,
    iIdSubModulo        BIGINT                            NOT NULL,
    iIdEtapa            BIGINT                            NOT NULL,
    iIdUsuario          BIGINT                            NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE(),
);

ALTER TABLE Patrimonio.Seguimientos
    ADD CONSTRAINT FK_Seguimientos_iIdDetalleSolicitud
        FOREIGN KEY (iIdDetalleSolicitud) REFERENCES Patrimonio.DetallesSolicitudes (iIdDetalleSolicitud);

ALTER TABLE Patrimonio.Seguimientos
    ADD CONSTRAINT FK_Seguimientos_iIdEtapa
        FOREIGN KEY (iIdEtapa) REFERENCES Patrimonio.Etapas (iIdEtapa);

ALTER TABLE Patrimonio.Seguimientos
    ADD CONSTRAINT FK_Seguimientos_iIdModulo
        FOREIGN KEY (iIdModulo) REFERENCES Sistema.Modulos (iIdModulo);

ALTER TABLE Patrimonio.Seguimientos
    ADD CONSTRAINT FK_Seguimientos_iIdSubModulo
        FOREIGN KEY (iIdSubModulo) REFERENCES Sistema.SubModulos (iIdSubModulo);

ALTER TABLE Patrimonio.Seguimientos
    ADD CONSTRAINT FK_Seguimientos_iIdUsuario
        FOREIGN KEY (iIdUsuario) REFERENCES Seguridad.Usuarios (iIdUsuario);

CREATE TABLE Patrimonio.Historiales
(
    iIdHistorial        BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdBien             BIGINT                            NOT NULL,
    iIdModulo           BIGINT                            NOT NULL,
    iIdSubModulo        BIGINT                            NOT NULL,
    iIdSolicitud        BIGINT                            NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE(),
);

ALTER TABLE Patrimonio.Historiales
    ADD CONSTRAINT FK_Historiales_iIdBien
        FOREIGN KEY (iIdBien) REFERENCES Patrimonio.Bienes (iIdBien);

ALTER TABLE Patrimonio.Historiales
    ADD CONSTRAINT FK_Historiales_iIdModulo
        FOREIGN KEY (iIdModulo) REFERENCES Sistema.Modulos (iIdModulo);

ALTER TABLE Patrimonio.Historiales
    ADD CONSTRAINT FK_Historiales_iIdSubModulo
        FOREIGN KEY (iIdSubModulo) REFERENCES Sistema.SubModulos (iIdSubModulo);

ALTER TABLE Patrimonio.Historiales
    ADD CONSTRAINT FK_Historiales_iIdSolicitud
        FOREIGN KEY (iIdSolicitud) REFERENCES Patrimonio.Solicitudes (iIdSolicitud);

CREATE TABLE Patrimonio.Depreciaciones
(
    iIdDepreciacion       BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdBien               BIGINT                            NOT NULL,
    dTasa                 DECIMAL(9, 6)                     NOT NULL,
    dDepreciaionAcumulada DECIMAL(9, 6)                     NOT NULL,
    dValorLibros          DOUBLE PRECISION                  NOT NULL,
    dDepreciacionFiscal   DECIMAL(9, 6)                     NOT NULL,
    dtFecha               DATE                              NOT NULL DEFAULT GETDATE(),
);

ALTER TABLE Patrimonio.Historiales
    ADD CONSTRAINT FK_Depreciaciones_iIdBien
        FOREIGN KEY (iIdBien) REFERENCES Patrimonio.Bienes (iIdBien);

GO

-- TABLAS DE ALMACEN
CREATE TABLE General.Cuentas
(
    iIdCuenta           BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    sClave              NVARCHAR(10)                      NOT NULL,
    iNivel              INT                               NOT NULL,
    sNivelCompleto      NVARCHAR(20)                      NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE(),
);

CREATE TABLE Almacen.MetodosCosteo
(
    iIdMetodoCosteo     BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sAbreviacion        NVARCHAR(10)                      NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE(),
);

CREATE TABLE Catalogo.Anaqueles
(
    iIdAnaquel          BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    iIdAlmacen          BIGINT                            NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE(),
);

CREATE TABLE Catalogo.Zonas
(
    iIdZona             BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    iIdAlmacen          BIGINT                            NOT NULL,
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE(),
);

-- Entrada y Salida
CREATE TABLE Almacen.TiposMovimientos
(
    iIdTipoMovimiento   BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE(),
);

CREATE TABLE Catalogo.ConceptosMovimientos
(
    iIdConceptoMovimiento BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre               NVARCHAR(255)                     NOT NULL,
    sDescripcion          NVARCHAR(MAX)                     NOT NULL,
    iIdTipoMovimiento     BIGINT                            NOT NULL,
    bActivo               BIT                               NOT NULL,
    dtFechaCreacion       DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion   DATETIME                          NOT NULL DEFAULT GETDATE(),
);

ALTER TABLE Catalogo.ConceptosMovimientos
    ADD CONSTRAINT FK_ConceptosMovimientos_iIdTipoMovimiento
        FOREIGN KEY (iIdTipoMovimiento) REFERENCES Almacen.TiposMovimientos (iIdTipoMovimiento);

CREATE TABLE Catalogo.Almacenes
(
    iIdAlmacen          BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdPeriodo          BIGINT                            NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    sDireccion          NVARCHAR(MAX)                     NOT NULL,
    sHorario            NVARCHAR(MAX)                     NOT NULL,
    iIdEmpleado         BIGINT                            NOT NULL,
    iIdCuenta           BIGINT                            NOT NULL,
    iIdMetodoCosteo     BIGINT                            NOT NULL,
    sFolioEntrada       NVARCHAR(50),
    sFolioSalida        NVARCHAR(50),
    bActivo             BIT                               NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE(),
);


ALTER TABLE Catalogo.Anaqueles
    ADD CONSTRAINT FK_Anaqueles_iIdAlmacen
        FOREIGN KEY (iIdAlmacen) REFERENCES Catalogo.Almacenes (iIdAlmacen);

ALTER TABLE Catalogo.Zonas
    ADD CONSTRAINT FK_Zonas_iIdAlmacen
        FOREIGN KEY (iIdAlmacen) REFERENCES Catalogo.Almacenes (iIdAlmacen);

ALTER TABLE Catalogo.Almacenes
    ADD CONSTRAINT FK_Almacenes_iIdPeriodo
        FOREIGN KEY (iIdPeriodo) REFERENCES General.Periodos (iIdPeriodo);

ALTER TABLE Catalogo.Almacenes
    ADD CONSTRAINT FK_Almacenes_iIdEmpleado
        FOREIGN KEY (iIdEmpleado) REFERENCES Seguridad.Empleados (iIdEmpleado);

ALTER TABLE Catalogo.Almacenes
    ADD CONSTRAINT FK_Almacenes_iIdCuenta
        FOREIGN KEY (iIdCuenta) REFERENCES General.Cuentas (iIdCuenta);

ALTER TABLE Catalogo.Almacenes
    ADD CONSTRAINT FK_Almacenes_iIdMetodoCosteo
        FOREIGN KEY (iIdMetodoCosteo) REFERENCES Almacen.MetodosCosteo (iIdMetodoCosteo);

-- Donacon y otros
CREATE TABLE Almacen.MetodosAdquisicion
(
    iIdMetodoAdquisicion BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre              NVARCHAR(255)                     NOT NULL,
    dtFechaCreacion      DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion  DATETIME                          NOT NULL DEFAULT GETDATE(),
);

CREATE TABLE Almacen.ProgramasOperativos
(
    iIdProgramaOperativo BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre              NVARCHAR(255)                     NOT NULL,
    dtFechaCreacion      DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion  DATETIME                          NOT NULL DEFAULT GETDATE(),
);

CREATE TABLE Almacen.FuentesFinanciamiento
(
    iIdFuenteFinanciamiento BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre                 NVARCHAR(255)                     NOT NULL,
    sClaveCompleta          NVARCHAR(50)                      NOT NULL,
    dtFechaCreacion         DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
);

CREATE TABLE Almacen.Proveedores
(
    iIdProveedor        BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                     NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE(),
);

CREATE TABLE Almacen.Movimientos
(
    iIdMovimiento           BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdTipoMovimiento       BIGINT                            NOT NULL,
    iIdAlmacen              BIGINT                            NOT NULL,
    iIdMetodoAdquisicion    BIGINT                            NOT NULL,
    iIdProgramaOperativo    BIGINT,
    sNumeroFactura          NVARCHAR(255),
    dtFechaResepcion        DATE,
    iIdFuenteFinanciamiento BIGINT,
    iIdConceptoMovimiento   BIGINT,
    iIdProveedor            BIGINT,
    iIdFamilia              BIGINT,
    sObservaciones          NVARCHAR(MAX),
    dImporteTotal           DOUBLE PRECISION,
    dtFechaCreacion         DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
);

ALTER TABLE Almacen.Movimientos
    ADD CONSTRAINT FK_Movimientos_iIdTipoMovimiento
        FOREIGN KEY (iIdTipoMovimiento) REFERENCES Almacen.TiposMovimientos (iIdTipoMovimiento);

ALTER TABLE Almacen.Movimientos
    ADD CONSTRAINT FK_Movimientos_iIdAlmacen
        FOREIGN KEY (iIdAlmacen) REFERENCES Catalogo.Almacenes (iIdAlmacen);

ALTER TABLE Almacen.Movimientos
    ADD CONSTRAINT FK_Movimientos_iIdMetodoAdquisicion
        FOREIGN KEY (iIdMetodoAdquisicion) REFERENCES Almacen.MetodosAdquisicion (iIdMetodoAdquisicion);

ALTER TABLE Almacen.Movimientos
    ADD CONSTRAINT FK_Movimientos_iIdProgramaOperativo
        FOREIGN KEY (iIdProgramaOperativo) REFERENCES Almacen.ProgramasOperativos (iIdProgramaOperativo);

ALTER TABLE Almacen.Movimientos
    ADD CONSTRAINT FK_Movimientos_iIdFuenteFinanciamiento
        FOREIGN KEY (iIdFuenteFinanciamiento) REFERENCES Almacen.FuentesFinanciamiento (iIdFuenteFinanciamiento);

ALTER TABLE Almacen.Movimientos
    ADD CONSTRAINT FK_Movimientos_iIdConceptoMovimiento
        FOREIGN KEY (iIdConceptoMovimiento) REFERENCES Catalogo.ConceptosMovimientos (iIdConceptoMovimiento);

ALTER TABLE Almacen.Movimientos
    ADD CONSTRAINT FK_Movimientos_iIdProveedor
        FOREIGN KEY (iIdProveedor) REFERENCES Almacen.Proveedores (iIdProveedor);

ALTER TABLE Almacen.Movimientos
    ADD CONSTRAINT FK_Movimientos_iIdFamilia
        FOREIGN KEY (iIdFamilia) REFERENCES Catalogo.Familias (iIdFamilia);

CREATE TABLE Almacen.Bienes
(
    iIdBien             BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdAlmacen          BIGINT                            NOT NULL,
    sDescripcion        NVARCHAR(MAX),
    nCodigoArmonizado   NUMERIC(10),
    iExistencia         DOUBLE PRECISION                  NOT NULL,
    sUnidadMedida       NVARCHAR(50)                      NOT NULL,
    iIdFamilia          BIGINT                            NOT NULL,
    iIdSubfamilia       BIGINT                            NOT NULL,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE(),
);

CREATE TABLE Almacen.MovimientosBienes
(
    iIdMovimientoBien   BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdMovimiento       BIGINT                            NOT NULL,
    iIdBMS              BIGINT                            NOT NULL,
    iIdBien             BIGINT,
    dtFechaCreacion     DATETIME                          NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                          NOT NULL DEFAULT GETDATE(),
);

ALTER TABLE Almacen.MovimientosBienes
    ADD CONSTRAINT FK_MovimientosBienes_iIdMovimiento
        FOREIGN KEY (iIdMovimiento) REFERENCES Almacen.Movimientos (iIdMovimiento);

ALTER TABLE Almacen.MovimientosBienes
    ADD CONSTRAINT FK_MovimientosBienes_iIdBMS
        FOREIGN KEY (iIdBMS) REFERENCES General.BMS (iIdBMS);

ALTER TABLE Almacen.MovimientosBienes
    ADD CONSTRAINT FK_MovimientosBienes_iIdBien
        FOREIGN KEY (iIdBien) REFERENCES Almacen.Bienes (iIdBien);

ALTER TABLE Almacen.Bienes
    ADD CONSTRAINT FK_AlmacenBienes_iIdAlmacen
        FOREIGN KEY (iIdAlmacen) REFERENCES Catalogo.Almacenes (iIdAlmacen);

ALTER TABLE Almacen.Bienes
    ADD CONSTRAINT FK_AlmacenBienes_iIdFamilia
        FOREIGN KEY (iIdFamilia) REFERENCES Catalogo.Familias (iIdFamilia);

ALTER TABLE Almacen.Bienes
    ADD CONSTRAINT FK_AlmacenBienes_iIdSubfamilia
        FOREIGN KEY (iIdSubfamilia) REFERENCES Catalogo.Subfamilias (iIdSubfamilia);

GO