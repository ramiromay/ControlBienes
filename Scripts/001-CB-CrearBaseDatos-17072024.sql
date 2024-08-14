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
****************************************************************************************/

-- Creacion de la base de datos
CREATE DATABASE ControlBienesBD;
GO

USE ControlBienesBD;
GO

-- Creacion de esquemas
CREATE SCHEMA Catalogo;
CREATE SCHEMA Seguridad;
CREATE SCHEMA General;
GO

-- Creacion de tablas
CREATE TABLE General.Personas
(
    iIdPersona     INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    sNombre        NVARCHAR(250)                  NOT NULL,
    sPrimerNombre  NVARCHAR(100)                  NOT NULL,
    sSegundoNombre NVARCHAR(100)                  NOT NULL,
    sEmail         NVARCHAR(250)                  NOT NULL,
    sNumero        NVARCHAR(10),
    iIdUsuario     INT                            NOT NULL
);
--Completar
CREATE TABLE Seguridad.Usuarios
(
    iIdUsuario       INT identity (1,1) PRIMARY KEY NOT NULL,
    iIdPersona       INT                            NOT NULL,
    sUsuario         NVARCHAR(100)                  NOT NULL,
    sContraseniaHash NVARCHAR(max)                  NOT NULL,
);

ALTER TABLE General.Personas
    ADD CONSTRAINT FK_Personas_iIdUsuario
        FOREIGN KEY (iIdUsuario)
            REFERENCES Seguridad.Usuarios (iIdUsuario);

ALTER TABLE Seguridad.Usuarios
    ADD CONSTRAINT FK_Usuario_iIdPersona
        FOREIGN KEY (iIdPersona)
            REFERENCES General.Personas (iIdPersona);

CREATE TABLE Seguridad.Roles
(
    iIdRol       INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    sNombre      NVARCHAR(100)                  NOT NULL,
    sDescripcion NVARCHAR(MAX)                  NOT NULL
);

CREATE TABLE Seguridad.UsuariosRoles
(
    iIdUsuario_Rol INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    iIdUsuario     INT                            NOT NULL,
    iIdRol         INT                            NOT NULL
);

ALTER TABLE Seguridad.UsuariosRoles
    ADD CONSTRAINT FK_UsuariosRoles_iIdUsuario
        FOREIGN KEY (iIdUsuario)
            REFERENCES Seguridad.Usuarios (iIdUsuario);

ALTER TABLE Seguridad.UsuariosRoles
    ADD CONSTRAINT FK_UsuariosRoles_iIdRol
        FOREIGN KEY (iIdRol)
            REFERENCES Seguridad.Roles (iIdRol);

CREATE TABLE Seguridad.Modulos
(
    iIdModulo    INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    sNombre      NVARCHAR(250)                  NOT NULL,
    sAbreviacion NVARCHAR(20)                   NOT NULL
);

CREATE TABLE Seguridad.Permisos
(
    iIdPermiso   INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    sNombre      NVARCHAR(50)                   NOT NULL,
    sDescripcion NVARCHAR(MAX)                  NOT NULL,
    iIdModulo    INT                            NOT NULL,
);

ALTER TABLE Seguridad.Permisos
    ADD CONSTRAINT FK_Permisos_iIdModulo
        FOREIGN KEY (iIdModulo)
            REFERENCES Seguridad.Modulos (iIdModulo);

CREATE TABLE Seguridad.RolesPermisos
(
    iIdRolPermiso INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    iIdRol        INT                            NOT NULL,
    iIdPermiso    INT                            NOT NULL
);

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
    iIdUsuario        INT                               NOT NULL,
    iIdPermiso        INT                               NOT NULL
);

ALTER TABLE Seguridad.UsuariosPermisos
    ADD CONSTRAINT FK_UsuariosPermisos_iIdUsuario
        FOREIGN KEY (iIdUsuario)
            REFERENCES Seguridad.Usuarios (iIdUsuario);

ALTER TABLE Seguridad.UsuariosPermisos
    ADD CONSTRAINT FK_UsuariosPermisos_iIdPermiso
        FOREIGN KEY (iIdPermiso)
            REFERENCES Seguridad.Permisos (iIdPermiso);

-- TABLAS PATRIMONIO

CREATE TABLE General.Periodos
(
    iIdPeriodo          INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iAnio               INT                            NOT NULL,
    dtFechaInicio       DATE                           NOT NULL,
    dtFechaFinal        DATE                           NOT NULL,
    bActivo             BIT                            NOT NULL,
    dtFechaCreacion     DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE General.UnidadesAdministrativas
(
    iIdUnidadAdministrativa INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdPeriodo              INT                            NOT NULL,
    iNivel                  INT                            NOT NULL,
    sDescripcion            NVARCHAR(255)                  NOT NULL,
    bActivo                 BIT                            NOT NULL,
    dtFechaCreacion         DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion     DATETIME                       NOT NULL DEFAULT GETDATE(),
);

ALTER TABLE General.UnidadesAdministrativas
    ADD CONSTRAINT FK_UnidadAdmistrativa_iIdPeriodo
        FOREIGN KEY (iIdPeriodo)
            REFERENCES General.Periodos (iIdPeriodo);

CREATE TABLE General.Municipio
(
    iIdMunicipio INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre      NVARCHAR(255)                  NOT NULL,
);

CREATE TABLE Catalogo.CentrosTrabajo
(
    iIdCentroTrabajo        INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sClave                  NVARCHAR(30)                   NOT NULL,
    sNombre                 NVARCHAR(255)                  NOT NULL,
    sDireccion              NVARCHAR(255)                  NOT NULL,
    iIdMunicipio            INT                            NOT NULL,
    iIdUnidadAdministrativa INT                            NOT NULL,
    bActivo                 BIT                            NOT NULL,
    dtFechaCreacion         DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion     DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.Turnos
(
    iIdTurno            INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(100)                  NOT NULL,
    bActivo             BIT                            NOT NULL,
    dtFechaCreacion     DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.CentroTrabajoTurnos
(
    iIdCentroTrabajoTurno INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdCentroTrabajo      INT                            NOT NULL,
    iIdTurno              INT                            NOT NULL,
    bActivo               BIT                            NOT NULL,
    dtFechaCreacion       DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion   DATETIME                       NOT NULL DEFAULT GETDATE()
);

ALTER TABLE Catalogo.CentrosTrabajo
    ADD CONSTRAINT FK_CentrosTrabajo_iIdMunicipio
        FOREIGN KEY (iIdMunicipio)
            REFERENCES General.Municipio (iIdMunicipio);

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
    iIdTitular            INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
    sNombre               NVARCHAR(150)                  NOT NULL,
    iIdCentroTrabajoTurno INT                            NOT NULL,
    iActivo               BIT                            NOT NULL,
    dtFechaCreacion       DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion   DATETIME                       NOT NULL DEFAULT GETDATE()
);

ALTER TABLE Catalogo.Titulares
    ADD CONSTRAINT FK_Titulares_iIdCentroTrabajoTurno
        FOREIGN KEY (iIdCentroTrabajoTurno)
            REFERENCES Catalogo.CentroTrabajoTurnos (iIdCentroTrabajoTurno);

CREATE TABLE Catalogo.Colores
(
    iIdColor            INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(100)                  NOT NULL,
    sCodigoRGB          NVARCHAR(15)                   NOT NULL,
    iActivo             BIT                            NOT NULL,
    dtFechaCreacion     DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.EstadosFisicos
(
    iIdEstadoFisico     INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(50)                   NOT NULL,
    sDescripcion        NVARCHAR(MAX)                  NOT NULL,
    iActivo             BIT                            NOT NULL,
    dtFechaCreacion     DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.EstadoGeneralBien
(
    iIdEstadoGeneralBien INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre              NVARCHAR(25)                   NOT NULL,
    bActivo              BIT                            NOT NULL,
    dtFechaCreacion      DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion  DATETIME                       NOT NULL DEFAULT GETDATE()
);


CREATE TABLE Catalogo.Marcas
(
    iIdMarca            INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(100)                  NOT NULL,
    sObservaciones      NVARCHAR(MAX),
    bActivo             BIT                            NOT NULL,
    dtFechaCreacion     DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.OrigenValor
(
    iIdOrigenValor      INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sOrigen             NVARCHAR(60)                   NOT NULL,
    sDescripcion        NVARCHAR(MAX)                  NOT NULL,
    bActivo             BIT                            NOT NULL,
    dtFechaCreacion     DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.TiposAsignacion
(
    iIdTiposAsignacion  INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(100)                  NOT NULL,
    bActivo             BIT                            NOT NULL,
    dtFechaCreacion     DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.TiposAdquisicion
(
    iIdTiposAdquisicion INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                  NOT NULL,
    bNoGeneraPolizas    BIT                            NOT NULL,
    bActivo             BIT                            NOT NULL,
    dtFechaCreacion     DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.TiposAfectacion
(
    iIdTiposAfectacion  INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(150)                  NOT NULL,
    bActivo             BIT                            NOT NULL,
    dtFechaCreacion     DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.TiposUsos
(
    iIdTiposUsos        INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(50)                   NOT NULL,
    bActivo             BIT                            NOT NULL,
    dtFechaCreacion     DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.Ubicacion
(
    iIdUbicacion        INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sDescripcion        NVARCHAR(MAX)                  NOT NULL,
    bActivo             BIT                            NOT NULL,
    dtFechaCreacion     DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.ClasesVehiculares
(
    iIdClasesVehiculares INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre              NVARCHAR(150)                  NOT NULL,
    sDescripcion         NVARCHAR(MAX)                  NOT NULL,
    bActivo              BIT                            NOT NULL,
    dtFechaCreacion      DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion  DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.ClasesVehiculares
(
    iIdClasesVehiculares INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre              NVARCHAR(150)                  NOT NULL,
    sDescripcion         NVARCHAR(MAX)                  NULL,
    bActivo              BIT                            NOT NULL,
    dtFechaCreacion      DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion  DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.CombustiblesVehiculares
(
    iIdCombustiblesVehiculares INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre                    NVARCHAR(100)                  NOT NULL,
    sDescripcion               NVARCHAR(MAX)                  NULL,
    bActivo                    BIT                            NOT NULL,
    dtFechaCreacion            DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion        DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.Documentos
(
    iIdDocumentos               INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre                     NVARCHAR(255)                  NOT NULL,
    iIdTipoTramiteMotivoTramite INT                            NOT NULL,
    bActivo                     BIT                            NOT NULL,
    dtFechaCreacion             DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion         DATETIME                       NOT NULL DEFAULT GETDATE()
);

ALTER TABLE Catalogo.Documentos
    ADD CONSTRAINT FK_Documentos_iIdTipoTramiteMotivoTramite
        FOREIGN KEY (iIdTipoTramiteMotivoTramite) REFERENCES TipoTramiteMotivoTramite (iIdTipoTramiteMotivoTramite);

CREATE TABLE Catalogo.LineasVehiculares
(
    iIdLineasVehiculares INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre              NVARCHAR(255)                  NOT NULL,
    sDescripcion         NVARCHAR(MAX)                  NOT NULL,
    bActivo              BIT                            NOT NULL,
    dtFechaCreacion      DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion  DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.TiposVehiculares
(
    iIdTiposVehiculares INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre             NVARCHAR(255)                  NOT NULL,
    sDescripcion        NVARCHAR(MAX)                  NOT NULL,
    bActivo             BIT                            NOT NULL,
    dtFechaCreacion     DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.VersionesVehiculares
(
    iIdVersionesVehiculares INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre                 NVARCHAR(255)                  NOT NULL,
    sDescripcion            NVARCHAR(MAX)                  NOT NULL,
    bActivo                 BIT                            NOT NULL,
    dtFechaCreacion         DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion     DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE General.TiposResponsables
(
    iIdTipoResponsable INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    sNombre            NVARCHAR(150)                  NOT NULL,
    sDescripcion       NVARCHAR(MAX)
);

CREATE TABLE Catalogo.Resguardantes
(
    iIdResguardante         INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdPeriodo              INT                            NOT NULL,
    iIdPersona              INT                            NOT NULL,
    iIdUnidadAdministrativa INT                            NOT NULL,
    sObservaciones          NVARCHAR(MAX),
    iNoConvenio             INT,
    iIdTipoResponsable      INT                            NOT NULL,
    bResponsable            BIT                            NOT NULL,
    bActivo                 BIT                            NOT NULL,
    dtFechaCreacion         DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion     DATETIME                       NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Catalogo.CaracteristicasBienes
(
    iIdCaracteristicaBien INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    iIdFamiliaSubfamilia  INT                            NOT NULL,
    sEtiqueta             NVARCHAR(255)                  NOT NULL,
    sDescripcion          NVARCHAR(MAX),
    iOrden                INT                            NOT NULL,
    bObligatorio          BIT                            NOT NULL,
    bActivo               BIT                            NOT NULL,
    dtFechaCreacion       DATETIME                       NOT NULL DEFAULT GETDATE(),
    dtFechaModificacion   DATETIME                       NOT NULL DEFAULT GETDATE()
);

ALTER TABLE Catalogo.Resguardantes
    ADD CONSTRAINT FK_Resguardantes_iIdPeriodo
        FOREIGN KEY (iIdPeriodo) REFERENCES General.Periodos (iIdPeriodo);

ALTER TABLE Catalogo.Resguardantes
    ADD CONSTRAINT FK_Resguardantes_iIdPersona
        FOREIGN KEY (iIdPersona) REFERENCES General.Personas (iIdPersona);

ALTER TABLE Catalogo.Resguardantes
    ADD CONSTRAINT FK_Resguardantes_UnidadesAdministrativas
        FOREIGN KEY (iIdUnidadAdministrativa) REFERENCES General.UnidadesAdministrativas (iIdUnidadAdministrativa);

ALTER TABLE Catalogo.Resguardantes
    ADD CONSTRAINT FK_Resguardantes_iIdTipoResponsable
        FOREIGN KEY (iIdTipoResponsable) REFERENCES General.TiposResponsables (iIdTipoResponsable);

ALTER TABLE Catalogo.CaracteristicasBienes
    ADD CONSTRAINT FK_CaracteristicasBienes_iIdFamiliaSubfamilia
        FOREIGN KEY (iIdFamiliaSubfamilia) REFERENCES Catalogo.FamiliaSubfamilia (iIdFamiliaSubfamilia);

