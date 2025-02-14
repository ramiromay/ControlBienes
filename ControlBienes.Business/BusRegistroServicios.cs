using ControlBienes.Business.Contrats.Almacen;
using ControlBienes.Business.Contrats.Catalogos;
using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Contrats.Seguridad;
using ControlBienes.Business.Contrats.Sistema;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Almacen.Complemento;
using ControlBienes.Business.Features.Almacen.EntradaSalida;
using ControlBienes.Business.Features.Almacen.Inventario;
using ControlBienes.Business.Features.Almacen.MovimientoBien;
using ControlBienes.Business.Features.Catalogos.Almacen;
using ControlBienes.Business.Features.Catalogos.CaracteristicaBien;
using ControlBienes.Business.Features.Catalogos.CentroTrabajo;
using ControlBienes.Business.Features.Catalogos.CentroTrabajoTurno;
using ControlBienes.Business.Features.Catalogos.ClaseVehicular;
using ControlBienes.Business.Features.Catalogos.ClaveVehicular;
using ControlBienes.Business.Features.Catalogos.Color;
using ControlBienes.Business.Features.Catalogos.CombustibleVehicular;
using ControlBienes.Business.Features.Catalogos.ConceptoMovimiento;
using ControlBienes.Business.Features.Catalogos.Documento;
using ControlBienes.Business.Features.Catalogos.EstadoFisico;
using ControlBienes.Business.Features.Catalogos.EstadoGeneral;
using ControlBienes.Business.Features.Catalogos.Familia;
using ControlBienes.Business.Features.Catalogos.LineaVehicular;
using ControlBienes.Business.Features.Catalogos.Marca;
using ControlBienes.Business.Features.Catalogos.MetodoAdquisicion;
using ControlBienes.Business.Features.Catalogos.OrigenValor;
using ControlBienes.Business.Features.Catalogos.Resguardante;
using ControlBienes.Business.Features.Catalogos.Subfamilia;
using ControlBienes.Business.Features.Catalogos.TipoAdquisicion;
using ControlBienes.Business.Features.Catalogos.TipoAfectacion;
using ControlBienes.Business.Features.Catalogos.TipoBien;
using ControlBienes.Business.Features.Catalogos.TipoInmueble;
using ControlBienes.Business.Features.Catalogos.TipoVehiculo;
using ControlBienes.Business.Features.Catalogos.Titular;
using ControlBienes.Business.Features.Catalogos.Turno;
using ControlBienes.Business.Features.Catalogos.Ubicacion;
using ControlBienes.Business.Features.Catalogos.UsoInmueble;
using ControlBienes.Business.Features.Catalogos.VersionVehicular;
using ControlBienes.Business.Features.General.Bms;
using ControlBienes.Business.Features.General.Cuenta;
using ControlBienes.Business.Features.General.Municipio;
using ControlBienes.Business.Features.General.Nacionalidad;
using ControlBienes.Business.Features.General.Nombramiento;
using ControlBienes.Business.Features.General.Periodo;
using ControlBienes.Business.Features.General.TipoResponsable;
using ControlBienes.Business.Features.General.UnidadAdministrativa;
using ControlBienes.Business.Features.Patrimonio.Depreciacion;
using ControlBienes.Business.Features.Patrimonio.InventarioInmueble;
using ControlBienes.Business.Features.Patrimonio.InventarioMueble;
using ControlBienes.Business.Features.Patrimonio.InventarioVehiculo;
using ControlBienes.Business.Features.Patrimonio.MotivoTramite;
using ControlBienes.Business.Features.Patrimonio.ReferenciaConac;
using ControlBienes.Business.Features.Patrimonio.Solicitud;
using ControlBienes.Business.Features.Patrimonio.SolicitudInmueble;
using ControlBienes.Business.Features.Patrimonio.SolicitudMueble;
using ControlBienes.Business.Features.Patrimonio.SolicitudVehiculo;
using ControlBienes.Business.Features.Patrimonio.TipoDominio;
using ControlBienes.Business.Features.Patrimonio.TipoTramite;
using ControlBienes.Business.Features.Patrimonio.TramiteInmueble;
using ControlBienes.Business.Features.Patrimonio.TramiteInmueble.Alta;
using ControlBienes.Business.Features.Patrimonio.TramiteInmueble.Baja;
using ControlBienes.Business.Features.Patrimonio.TramiteMueble;
using ControlBienes.Business.Features.Patrimonio.TramiteMueble.Alta;
using ControlBienes.Business.Features.Patrimonio.TramiteMueble.Baja;
using ControlBienes.Business.Features.Patrimonio.TramiteMueble.Desincorporacion;
using ControlBienes.Business.Features.Patrimonio.TramiteMueble.Modificacion;
using ControlBienes.Business.Features.Patrimonio.TramiteVehiculo;
using ControlBienes.Business.Features.Patrimonio.TramiteVehiculo.Alta;
using ControlBienes.Business.Features.Patrimonio.TramiteVehiculo.Baja;
using ControlBienes.Business.Features.Patrimonio.TramiteVehiculo.Desincorporacion;
using ControlBienes.Business.Features.Patrimonio.TramiteVehiculo.Modificacion;
using ControlBienes.Business.Features.Seguridad.Autentificacion;
using ControlBienes.Business.Features.Seguridad.Empleado;
using ControlBienes.Business.Features.Seguridad.IdentityAccess;
using ControlBienes.Business.Features.Seguridad.Permiso;
using ControlBienes.Business.Features.Seguridad.Persona;
using ControlBienes.Business.Features.Seguridad.Rol;
using ControlBienes.Business.Features.Seguridad.UsuarioPermiso;
using ControlBienes.Business.Features.Sistema.Catalogo;
using ControlBienes.Business.Features.Sistema.ColumnaTabla;
using ControlBienes.Business.Features.Sistema.DatabaseHealth;
using ControlBienes.Business.Features.Sistema.Modulo;
using ControlBienes.Business.Features.Sistema.SubModulo;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats;
using ControlBienes.Data.Contrats.Almacen;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Data.Contrats.Sistema;
using ControlBienes.Data.Persistence;
using ControlBienes.Data.Repository;
using ControlBienes.Data.Repository.Almacen;
using ControlBienes.Data.Repository.Catalogos;
using ControlBienes.Data.Repository.General;
using ControlBienes.Data.Repository.Patrimonio;
using ControlBienes.Data.Repository.Seguridad;
using ControlBienes.Data.Repository.Sistema;
using ControlBienes.Entities.Almacen.MovimientoBien;
using ControlBienes.Entities.Catalogos.Almacen;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using ControlBienes.Entities.Catalogos.CentroTrabajo;
using ControlBienes.Entities.Catalogos.CentroTrabajoTurno;
using ControlBienes.Entities.Catalogos.ClaseVehicular;
using ControlBienes.Entities.Catalogos.ClaveVehicular;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Catalogos.CombustibleVehicular;
using ControlBienes.Entities.Catalogos.ConceptoMovimiento;
using ControlBienes.Entities.Catalogos.Documento;
using ControlBienes.Entities.Catalogos.EstadoFisico;
using ControlBienes.Entities.Catalogos.EstadoGeneral;
using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Catalogos.LineaVehicular;
using ControlBienes.Entities.Catalogos.Marca;
using ControlBienes.Entities.Catalogos.MetodoAdquisicion;
using ControlBienes.Entities.Catalogos.OrigenValor;
using ControlBienes.Entities.Catalogos.Resguardante;
using ControlBienes.Entities.Catalogos.Subfamilia;
using ControlBienes.Entities.Catalogos.TipoAdquisicion;
using ControlBienes.Entities.Catalogos.TipoAfectacion;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Catalogos.TipoInmueble;
using ControlBienes.Entities.Catalogos.TipoVehicular;
using ControlBienes.Entities.Catalogos.Titular;
using ControlBienes.Entities.Catalogos.Turno;
using ControlBienes.Entities.Catalogos.Ubicacion;
using ControlBienes.Entities.Catalogos.UsoInmueble;
using ControlBienes.Entities.Catalogos.VersionVehicular;
using ControlBienes.Entities.Patrimonio.DetalleAlta;
using ControlBienes.Entities.Patrimonio.DetalleBaja;
using ControlBienes.Entities.Patrimonio.DetalleDesincorporacion;
using ControlBienes.Entities.Patrimonio.DetalleModificacion;
using ControlBienes.Entities.Patrimonio.Solicitud;
using ControlBienes.Entities.Seguridad.Autentificacion;
using ControlBienes.Entities.Seguridad.Empleado;
using ControlBienes.Entities.Seguridad.Rol;
using ControlBienes.Entities.Seguridad.Usuario;
using ControlBienes.Services.Contracts;
using ControlBienes.Services.Features.Email;
using ControlBienes.Services.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using IDatPermiso = ControlBienes.Data.Contrats.Seguridad.IDatPermiso;

namespace ControlBienes.Business
{
	public static class BusRegistroServicios
	{
		private static void BInicializarRepositoriosCatalogos(IServiceCollection services)
		{
			services.AddScoped(typeof(IDatCatalogoGenerico<>), typeof(DatCatalogoGenerico<>));
			services.AddScoped<IDatColor, DatColor>();
			services.AddScoped<IDatLineaVehicular, DatLineaVehicular>();
			services.AddScoped<IDatTipoBien, DatTipoBien>();
			services.AddScoped<IDatFamilia, DatFamilia>();
			services.AddScoped<IDatSubfamilia, DatSubfamilia>();
			services.AddScoped<IDatOrigenValor, DatOrigenValor>();
			services.AddScoped<IDatMarca, DatMarca>();
			services.AddScoped<IDatEstadoFisico, DatEstadoFisico>();
			services.AddScoped<IDatEstadoGeneral, DatEstadoGeneral>();
			services.AddScoped<IDatClaveVehicular, DatClaveVehicular>();
			services.AddScoped<IDatClaseVehicular, DatClaseVehicular>();
			services.AddScoped<IDatTipoAdquisicion, DatTipoAdquisicion>();
			services.AddScoped<IDatTipoAfectacion, DatTipoAfectacion>();
			services.AddScoped<IDatCombustibleVehicular, DatCombustibleVehicular>();
			services.AddScoped<IDatVersionVehicular, DatVersionVehicular>();
			services.AddScoped<IDatTipoInmueble, DatTipoInmueble>();
			services.AddScoped<IDatTipoVehiculo, DatTipoVehiculo>();
			services.AddScoped<IDatCaracteristicaBien, DatCaracteristicaBien>();
			services.AddScoped<IDatUsoInmueble, DatUsoInmueble>();
			services.AddScoped<IDatTurno, DatTurno>();
			services.AddScoped<IDatUbicacion, DatUbicacion>();
			services.AddScoped<IDatCentroTrabajo, DatCentroTrabajo>();
			services.AddScoped<IDatCentroTrabajoTurno, DatCentroTrabajoTurno>();
			services.AddScoped<IDatResguardante, DatResguardante>();
			services.AddScoped<IDatTitular, DatTitular>();
			services.AddScoped<IDatDocumento, DatDocumento>();
		}

		private static void BInicializarRepositoriosSistema(IServiceCollection services)
		{
			services.AddScoped<IDatCatalogo, DatCatalogo>();
			services.AddScoped<IDatColumnaTabla, DatColumnaTabla>();
			services.AddScoped<IDatSubModulo, DatSubModulo>();
			services.AddScoped<IDatModulo, DatModulo>();
		}

		private static void BInicializarRepositoriosGenerales(IServiceCollection services)
		{
			services.AddScoped<IDatPeriodo, DatPeriodo>();
			services.AddScoped<IDatUnidadAdministrativa, DatUnidadAdministrativa>();
			services.AddScoped<IDatMunicipio, DatMunicipio>();
			services.AddScoped<IDatTipoResponsable, DatTipoResponsable>();
			services.AddScoped<IDatNombramiento, DatNombramiento>();
			services.AddScoped<IDatNacionalidad, DatNacionalidad>();
			services.AddScoped<IDatBms, DatBms>();
			services.AddScoped<IDatCuenta, DatCuenta>();
		}

		private static void BInicializarRepositoriosSeguridad(IServiceCollection services)
		{
			services.AddScoped<IDatEmpleado, DatEmpleado>();
			services.AddScoped<IDatPersona, DatPersona>();
			services.AddScoped<IDatPermiso, DatPermiso>();
			services.AddScoped<IDatUsuario, DatUsuario>();
			services.AddScoped<IDatRol, DatRol>();
			services.AddScoped<IDatRolPermiso, DatRolPermiso>();
			services.AddScoped<IDatUsuarioPermiso, DatUsuarioPermiso>();
			services.AddScoped<IDatUsuarioRol, DatUsuarioRol>();
		}

		private static void BInicializarRepositoriosPatrimonio(IServiceCollection services)
		{
			services.AddScoped<IDatBienPatrimonio, DatBienPatrimonio>();
			services.AddScoped<IDatDepreciacion, DatDepreciacion>();
			services.AddScoped<IDatDetalleSolicitud, DatDetalleSolicitud>();
			services.AddScoped<IDatDetalleAlta, DatDetalleAlta>();
			services.AddScoped<IDatEtapa, DatEtapa>();
			services.AddScoped<IDatEtapaTramite, DatEtapaTramite>();
			services.AddScoped<IDatHistorial, DatHistorial>();
			services.AddScoped<IDatSeguimiento, DatSeguimiento>();
			services.AddScoped<IDatSolicitud, DatSolicitud>();
			services.AddScoped<IDatTipoBienInmuble, DatTipoBienInmueble>();
			services.AddScoped<IDatTipoDominio, DatTipoDominio>();
			services.AddScoped<IDatTipoTramite, DatTipoTramite>();
			services.AddScoped<IDatTipoTramite, DatTipoTramite>();
			services.AddScoped<IDatMotivoTramite, DatMotivoTramite>();
			services.AddScoped<IDatEtapaSolicitud, DatEtapaSolicitud>();
			services.AddScoped<IDatBms, DatBms>();
			services.AddScoped<IDatDetalleModificacion, DatDetalleModificacion>();
			services.AddScoped<IDatBienPatrimonio, DatBienPatrimonio>();
			services.AddScoped<IDatDetalleBaja, DatDetalleBaja>();
			services.AddScoped<IDatDocumento, DatDocumento>();
			services.AddScoped<IDatTipoDominio, DatTipoDominio>();
		}

		private static void BInicializarRepositoriosAlmacen(IServiceCollection services)
		{
			services.AddScoped<IDatAlmacen, DatAlmacen>();
			services.AddScoped<IDatConceptoMovimiento, DatConceptoMovimiento>();
			services.AddScoped<IDatMetodoAdquisicion, DatMetodoAdquisicion>();
			services.AddScoped<IDatMetodoCosteo, DatMetodoCosteo>();
			services.AddScoped<IDatTipoMovimiento, DatTipoMovimiento>();
			services.AddScoped<IDatProveedor, DatProveedor>();
			services.AddScoped<IDatProgramaOperativo, DatProgramaOperativo>();
			services.AddScoped<IDatMovimiento, DatMovimiento>();
			services.AddScoped<IDatEtapaMovimiento, DatEtapaMovimiento>();
			services.AddScoped<IDatBienAlmacen, DatBienAlmacen>();
		}

		private static void BInicializarValidatorCatalogos(IServiceCollection services)
		{
			services.AddTransient<IValidator<EntColorRequest>, BusColorValidator>();
			services.AddTransient<IValidator<EntLineaVehicularRequest>, BusLineaVehicularValidator>();
			services.AddTransient<IValidator<EntTipoBienRequest>, BusTipoBienValidator>();
			services.AddTransient<IValidator<EntFamiliaRequest>, BusFamiliaValidator>();
			services.AddTransient<IValidator<EntSubfamiliaRequest>, BusSubfamiliaValidator>();
			services.AddTransient<IValidator<EntOrigenValorRequest>, BusOrigenValorValidator>();
			services.AddTransient<IValidator<EntMarcaRequest>, BusMarcaValidator>();
			services.AddTransient<IValidator<EntEstadoFisicoRequest>, BusEstadoFisicoValidator>();
			services.AddTransient<IValidator<EntEstadoGeneralRequest>, BusEstadoGeneralValidator>();
			services.AddTransient<IValidator<EntClaveVehicularRequest>, BusClaveVehicularValidator>();
			services.AddTransient<IValidator<EntClaseVehicularRequest>, BusClaseVehicularValidator>();
			services.AddTransient<IValidator<EntTipoAdquisicionRequest>, BusTipoAdquisicionValidator>();
			services.AddTransient<IValidator<EntTipoAfectacionRequest>, BusTipoAfectacionValidator>();
			services.AddTransient<IValidator<EntCombustibleVehicularRequest>, BusCombustibleVehicularValidator>();
			services.AddTransient<IValidator<EntVersionVehicularRequest>, BusVersionVehicularValidator>();
			services.AddTransient<IValidator<EntTipoInmuebleRequest>, BusTipoInmuebleValidator>();
			services.AddTransient<IValidator<EntTipoVehiculoRequest>, BusTipoVehiculoValidator>();
			services.AddTransient<IValidator<EntCaracteristicaBienRequest>, BusCaracteristicaBienValidator>();
			services.AddTransient<IValidator<EntUsoInmuebleRequest>, BusUsoInmuebleValidator>();
			services.AddTransient<IValidator<EntTurnoRequest>, BusTurnoValidator>();
			services.AddTransient<IValidator<EntUbicacionRequest>, BusUbicacionValidator>();
			services.AddTransient<IValidator<EntCentroTrabajoRequest>, BusCentroTrabajoValidator>();
			services.AddTransient<IValidator<EntCentroTrabajoTurnoRequest>, BusCentroTrabajoTurnoValidator>();
			services.AddTransient<IValidator<EntResguardanteRequest>, BusResguardanteValidator>();
			services.AddTransient<IValidator<EntTitularRequest>, BusTitularValidator>();
			services.AddTransient<IValidator<EntDocumentoRequest>, BusDocumentoValidator>();
		}

		private static void BInicializarValidatorSeguridad(IServiceCollection services)
		{
			services.AddTransient<IValidator<EntEmpleadoRequest>, BusEmpleadoValidator>();
		}

		private static void BInicializarValidatorAlmacen(IServiceCollection services)
		{
			services.AddTransient<IValidator<EntAlmacenRequest>, BusAlmacenValidator>();
			services.AddTransient<IValidator<EntConceptoMovimientoRequest>, BusConceptoMovimientoValidator>();
			services.AddTransient<IValidator<EntMetodoAdquisicionRequest>, BusMetodoAdquisicionValidator>();
			services.AddTransient<IValidator<EntMovimientoBienRequest>, BusMovimientoBienValidator>();



		}

		private static void BInicializarValidatorPatrimonio(IServiceCollection services)
		{
			services.AddTransient<IValidator<EntSolicitudMuebleRequest>, BusSolicitudMuebleValidator>();
			services.AddTransient<IValidator<EntSolicitudVehiculoRequest>, BusSolicitudVehiculoValidator>();
			services.AddTransient<IValidator<EntSolicitudInmuebleRequest>, BusSolicitudInmuebleValidator>();


			services.AddTransient<IValidator<EntDetalleAltaMuebleRequest>, BusTramiteMuebleAltaValidator>();
			services.AddTransient<IValidator<EntDetalleModificacionMuebleRequest>, BusTramiteMuebleModificacionValidator>();
			services.AddTransient<IValidator<EntDetalleBajaMuebleRequest>, BusTramiteMuebleBajaValidator>();
			services.AddTransient<IValidator<EntDetalleDesincorporacionMuebleRequest>, BusTramiteMuebleDesincorporacionValidator>();

			services.AddTransient<IValidator<EntDetalleAltaVehiculoRequest>, BusTramiteVehiculoAltaValidator>();
			services.AddTransient<IValidator<EntDetalleModificacionVehiculoRequest>, BusTramiteVehiculoModificacionValidator>();
			services.AddTransient<IValidator<EntDetalleBajaVehiculoRequest>, BusTramiteVehiculoBajaValidator>();
		services.AddTransient<IValidator<EntDetalleDesincorporacionVehiculoRequest>, BusTramiteVehiculoDesioncorporacionValidator>();

			services.AddTransient<IValidator<EntDetalleAltaInmuebleRequest>, BusTramiteInmuebleAltaValidator>();
			services.AddTransient<IValidator<EntDetalleBajaInmuebleRequest>, BusTramiteInmuebleBajaValidator>();


		}

		public static void BInicializarServiciosAlmacen(IServiceCollection services)
		{
			services.AddScoped<IBusAlmacen, BusAlmacen>();
			services.AddScoped<IBusConceptoMovimiento, BusConceptoMovimiento>();
			services.AddScoped<IBusMetodoAdquisicion, BusMetodoAdquisicion>();
			services.AddScoped<IBusAlmacenComplemento, BusAlmacenComplemento>();
			services.AddScoped<IBusMovimientoBien, BusMovimientoBien>();
			services.AddScoped<IBusInventarioAlmacen, BusInventarioAlmacen>();



		}


		public static void BInicializarServiciosCatalogos(IServiceCollection services)
		{
			services.AddScoped<IBusColor, BusColor>();
			services.AddScoped<IBusLineaVehicular, BusLineaVehicular>();
			services.AddScoped<IBusTipoBien, BusTipoBien>();
			services.AddScoped<IBusFamilia, BusFamilia>();
			services.AddScoped<IBusSubfamilia, BusSubfamilia>();
			services.AddScoped<IBusOrigenValor, BusOrigenValor>();
			services.AddScoped<IBusMarca, BusMarca>();
			services.AddScoped<IBusEstadoFisico, BusEstadoFisico>();
			services.AddScoped<IBusEstadoGeneral, BusEstadoGeneral>();
			services.AddScoped<IBusClaveVehicular, BusClaveVehicular>();
			services.AddScoped<IBusClaseVehicular, BusClaseVehicular>();
			services.AddScoped<IBusTipoAsignacion, BusTipoAdquisicion>();
			services.AddScoped<IBusTipoAfectacion, BusTipoAfectacion>();
			services.AddScoped<IBusCombustibleVehicular, BusCombustibleVehicular>();
			services.AddScoped<IBusVersionVehicular, BusVersionVehicular>();
			services.AddScoped<IBusTipoInmueble, BusTipoInmueble>();
			services.AddScoped<IBusTipoVehiculo, BusTipoVehiculo>();
			services.AddScoped<IBusCaracteristicaBien, BusCaracteristicaBien>();
			services.AddScoped<IBusUsoInmueble, BusUsoInmueble>();
			services.AddScoped<IBusTurno, BusTurno>();
			services.AddScoped<IBusUbicacion, BusUbicacion>();
			services.AddScoped<IBusCentroTrabajo, BusCentroTrabajo>();
			services.AddScoped<IBusCentroTrabajoTurno, BusCentroTrabajoTurno>();
			services.AddScoped<IBusResguardante, BusResguardante>();
			services.AddScoped<IBusTitular, BusTitular>();
			services.AddScoped<IBusDocumento, BusDocumento>();
		}

		private static void BInicializarServiciosSistema(IServiceCollection services)
		{
			services.AddScoped<IBusCatalogo, BusCatalogo>();
			services.AddScoped<IBusColumnaTabla, BusColumnaTabla>();
			services.AddScoped<IBusSubModulo, BusSubModulo>();
			services.AddScoped<IBusModulo, BusModulo>();
		}

		private static void BInicializarServiciosGenerales(IServiceCollection services)
		{
			services.AddScoped<IBusPeriodo, BusPeriodo>();
			services.AddScoped<IBusUnidadAdministrativa, BusUnidadAdministrativa>();
			services.AddScoped<IBusMunicipio, BusMunicipio>();
			services.AddScoped<IBusTipoResponsable, BusTipoResponsable>();
			services.AddScoped<IBusNacionalidad, BusNacionalidad>();
			services.AddScoped<IBusNombramiento, BusNombramiento>();
			services.AddScoped<IBusBms, BusBms>();
			services.AddScoped<IBusCuenta, BusCuenta>();

		}

		private static void BInicializarServiciosSeguridad(IServiceCollection services)
		{
			services.AddScoped<IBusPersona, BusPersona>();
			services.AddScoped<IBusEmpleado, BusEmpleado>();
			services.AddScoped<IBusRol, BusRol>();
			services.AddScoped<IBusPermiso, BusPermiso>();
		}

		private static void BInicializarServiciosPatrimonio(IServiceCollection services)
		{
			services.AddScoped<IBusTipoTramite, BusTipoTramite>();
			services.AddScoped<IBusMotivoTramite, BusMotivoTramite>();
			services.AddScoped<IBusTipoDominio, BusTipoDominio>();
			services.AddScoped<IBusSolicitud, BusSolicitud>();
			services.AddScoped<IBusTramite, BusTramite>();

			services.AddScoped<IBusSolicitudMueble, BusSolicitudMueble>();
			services.AddScoped<IBusSolicitudVehiculo, BusSolicitudVehiculo>();
			services.AddScoped<IBusSolicitudInmueble, BusSolicitudInmueble>();

			services.AddScoped<IBusTramiteMueble, BusTramiteMueble>();
			services.AddScoped<IBusTramiteVehiculo, BusTramiteVehiculo>();
			services.AddScoped<IBusTramiteInmueble, BusTramiteInmueble>();

			services.AddScoped<IBusInventario, BusInventario>();
			services.AddScoped<IBusInventarioMueble, BusInventarioMueble>();
			services.AddScoped<IBusInventarioVehiculo, BusInventarioVehiculo>();
			services.AddScoped<IBusInventarioInmueble, BusInventarioInmueble>();

			services.AddScoped<IBusClasificacionConac, BusClasificacionConac>();
			services.AddScoped<IDatTipoBienInmuble, DatTipoBienInmueble>();
			services.AddScoped<IBusDepreciacion, BusDepreciacion>();
		}

		public static IServiceCollection BRegistrarServiciosApp(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<EntJwtSettings>(configuration.GetSection("JwtSettings"));
			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
			services.AddIdentity<EntUsuario, EntRol>(options =>
			{
				// Configuración de contraseñas
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireUppercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequiredLength = 8;
				options.Password.RequiredUniqueChars = 1;
				
			})
				.AddEntityFrameworkStores<AppDbContext>()
				.AddDefaultTokenProviders();

			services.AddScoped<IBusAutentificacion, BusAutentificacion>();
			services.AddScoped<IBusIdentityAccess, BusIdentityAccess>();
			services.AddScoped<IBusUsuarioPermiso, BusUsuarioPermiso>();
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuerSigningKey = true,
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero,
					ValidIssuer = configuration["JwtSettings:Issuer"],
					ValidAudience = configuration["JwtSettings:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
				};
			});

			services.Configure<EmailSettings>(emailSettings =>
			{
				var emailSettingsSection = configuration.GetSection("EmailSettings");
				emailSettings.FromAdress = emailSettingsSection["FromAdress"];
				emailSettings.FromName = emailSettingsSection["FromName"];
				emailSettings.FromPassword = emailSettingsSection["FromPassword"];
				emailSettings.SmtpServer = emailSettingsSection["SmtpServer"];
				emailSettings.SmtpPort = int.Parse(emailSettingsSection["SmtpPort"]);
				emailSettings.WelcomeHtmlFilePath = emailSettingsSection["WelcomeHtmlFilePath"];
				emailSettings.ForgotPasswordHtmlFilePath = emailSettingsSection["ForgotPasswordHtmlFilePath"];
			});

			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.InvalidModelStateResponseFactory = context =>
				{
					var errors = context.ModelState
						.Where(x => x.Value.Errors.Count > 0)
						.ToDictionary(
							kvp => kvp.Key,
							kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
						);

					var response = new EntityResponse<object>()
					{
						Code = Entities.Constants.EnumCodigoOperacion.CodeErrorFiltroRequest,
						HasError = true,
						Message = "Se produjo un error en la solicitud. Asegúrese de que el recurso solicitado exista y que la estructura de la solicitud sea válida.",
						StatusCode = System.Net.HttpStatusCode.BadRequest
					};

					return new BadRequestObjectResult(response);
				};
			});

			services.AddScoped<IEmailService, EmailService>();
			services.AddScoped<IDatabaseHealthService, DatabaseHealthService>();

			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			services.AddScoped(typeof(IDat<>), typeof(Dat<>));

			BInicializarRepositoriosCatalogos(services);
			BInicializarRepositoriosSistema(services);
			BInicializarRepositoriosGenerales(services);
			BInicializarRepositoriosSeguridad(services);
			BInicializarRepositoriosPatrimonio(services);
			BInicializarRepositoriosAlmacen(services);

			BInicializarValidatorCatalogos(services);
			BInicializarValidatorSeguridad(services);
			BInicializarValidatorPatrimonio(services);
			BInicializarValidatorAlmacen(services);

			BInicializarServiciosCatalogos(services);
			BInicializarServiciosSistema(services);
			BInicializarServiciosGenerales(services);
			BInicializarServiciosSeguridad(services);
			BInicializarServiciosPatrimonio(services);
			BInicializarServiciosAlmacen(services);
			return services;
		}

	}
}
