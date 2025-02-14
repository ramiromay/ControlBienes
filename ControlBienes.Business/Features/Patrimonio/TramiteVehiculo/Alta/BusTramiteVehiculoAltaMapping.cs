using AutoMapper;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.DetalleAlta;
using ControlBienes.Entities.Patrimonio.DetalleModificacion;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Etapa;
using ControlBienes.Entities.Patrimonio.Seguimiento;
using ControlBienes.Entities.Patrimonio.TipoTramite;

namespace ControlBienes.Business.Features.Patrimonio.TramiteVehiculo.Alta
{
	public class BusTramiteVehiculoAltaMapping : Profile
	{
		public BusTramiteVehiculoAltaMapping()
		{
			CreateMap<EntDetalleSolicitud, EntDetalleAltaVehiculoResponse>()
				.ForMember(dest => dest.IdSolicitud, opt => opt.MapFrom(src => src.iIdSolicitud))
				.ForMember(dest => dest.IdFamilia, opt => opt.MapFrom(src => src.DetalleAlta.iIdFamilia))
				.ForMember(dest => dest.IdSubfamilia, opt => opt.MapFrom(src => src.DetalleAlta.iIdSubfamilia))
				.ForMember(dest => dest.IdBms, opt => opt.MapFrom(src => src.DetalleAlta.iIdBms))
				.ForMember(dest => dest.Partida, opt => opt.MapFrom(src => EntConstant.DefaultPartida))
				.ForMember(dest => dest.PartidaEspecifica, opt => opt.MapFrom(src => src.DetalleAlta.sPartidaEspecifica))
				.ForMember(dest => dest.ReferenciaActivo, opt => opt.MapFrom(src => src.DetalleAlta.sCuentaActivo))
				.ForMember(dest => dest.ReferenciaActualizacion, opt => opt.MapFrom(src => src.DetalleAlta.sCuentaActualizacion))
				.ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.DetalleAlta.sDescripcion))
				.ForMember(dest => dest.NivelUnidadAdministrativa, opt => opt.MapFrom(src => src.DetalleAlta.UnidadAdministrativa.sNivelCompleto))
				.ForMember(dest => dest.Requisicion, opt => opt.MapFrom(src => src.DetalleAlta.sRequisicion))
				.ForMember(dest => dest.OrdenCompra, opt => opt.MapFrom(src => src.DetalleAlta.sOrdenCompra))
				.ForMember(dest => dest.IdTipoAdquisicion, opt => opt.MapFrom(src => src.DetalleAlta.iIdTipoAdquisicion))
				.ForMember(dest => dest.NoSeries, opt => opt.MapFrom(src => src.DetalleAlta.sNoSeries))
				.ForMember(dest => dest.FolioAnterior, opt => opt.MapFrom(src => src.DetalleAlta.sFolioAnterior))
				.ForMember(dest => dest.NoLicitacion, opt => opt.MapFrom(src => src.DetalleAlta.Licitacion.iNumeroLicitacion))
				.ForMember(dest => dest.FechaLicitacion, opt => opt.MapFrom(src => src.DetalleAlta.Licitacion.dtFecha))
				.ForMember(dest => dest.ObservacionLicitacion, opt => opt.MapFrom(src => src.DetalleAlta.Licitacion.sObservaciones))
				.ForMember(dest => dest.IdEstadoFisico, opt => opt.MapFrom(src => src.DetalleAlta.iIdEstadoFisico))
				.ForMember(dest => dest.IdMarca, opt => opt.MapFrom(src => src.DetalleAlta.DatoGeneral.iIdMarca))
				.ForMember(dest => dest.IdColor, opt => opt.MapFrom(src => src.DetalleAlta.DatoGeneral.iIdColor))
				.ForMember(dest => dest.FolioFactura, opt => opt.MapFrom(src => src.DetalleAlta.Factura.sFolioFactura))
				.ForMember(dest => dest.FechaFactura, opt => opt.MapFrom(src => src.DetalleAlta.Factura.dtFecha))
				.ForMember(dest => dest.PrecioUnitario, opt => opt.MapFrom(src => src.DetalleAlta.dPrecioUnitario))
				.ForMember(dest => dest.FechaCompra, opt => opt.MapFrom(src => src.DetalleAlta.dtFechaAdquisicion))
				.ForMember(dest => dest.DiasGarantia, opt => opt.MapFrom(src => src.DetalleAlta.Factura.iGarantiaDias))
				.ForMember(dest => dest.VidaUtil, opt => opt.MapFrom(src => src.DetalleAlta.iAniosVida))
				.ForMember(dest => dest.FechaInicioUso, opt => opt.MapFrom(src => src.DetalleAlta.dtFechaInicioUso))
				.ForMember(dest => dest.PrecioDesechable, opt => opt.MapFrom(src => src.DetalleAlta.dPrecioDesechable))
				.ForMember(dest => dest.ObservacionBien, opt => opt.MapFrom(src => src.DetalleAlta.sObservacionBien))
				.ForMember(dest => dest.IdUbicacion, opt => opt.MapFrom(src => src.DetalleAlta.iIdUbicacion))
				.ForMember(dest => dest.IdMunicipio, opt => opt.MapFrom(src => src.DetalleAlta.iIdMunicipio))
				.ForMember(dest => dest.Caracteristicas, opt => opt.MapFrom(src => src.DetalleAlta.sCaracteristicas))
				.ForMember(dest => dest.Responsables, opt => opt.MapFrom(src => src.DetalleAlta.sResguardantes))
				.ForMember(dest => dest.ObservacionResponsable, opt => opt.MapFrom(src => src.DetalleAlta.sObservacionResponsable))

				.ForMember(src => src.CuentaPorPagar, opt => opt.MapFrom(dest => dest.DetalleAlta.sCuentaPorPagar))
				.ForMember(src => src.SustituyeBV, opt => opt.MapFrom(dest => dest.DetalleAlta.sSustituyeBv))
				.ForMember(src => src.AnioEmicion, opt => opt.MapFrom(dest =>					dest.DetalleAlta.Factura.DatoVehicular.iAnioEmision))
				.ForMember(src => src.NumeroPlaca, opt => opt.MapFrom(dest =>					dest.DetalleAlta.Factura.DatoVehicular.sNumeroPlaca))
				.ForMember(src => src.NumeroMotor, opt => opt.MapFrom(dest =>					dest.DetalleAlta.Factura.DatoVehicular.iNumeroMotor))
				.ForMember(src => src.AnioModelo, opt => opt.MapFrom(dest =>			dest.DetalleAlta.Factura.DatoVehicular.iAnioModelo))
				.ForMember(src => src.NumeroEconomico, opt => opt.MapFrom(dest =>					dest.DetalleAlta.Factura.DatoVehicular.nNumeroEconomico))
				.ForMember(src => src.IdClave, opt => opt.MapFrom(dest =>			dest.DetalleAlta.DatoGeneral.iIdClaveVehicular))
				.ForMember(src => src.IdLinea, opt => opt.MapFrom(dest =>			dest.DetalleAlta.DatoGeneral.iIdLineaVehicular))
				.ForMember(src => src.IdVersion, opt => opt.MapFrom(dest =>			dest.DetalleAlta.DatoGeneral.iIdVersionVehicular))
				.ForMember(src => src.IdClase, opt => opt.MapFrom(dest =>			dest.DetalleAlta.DatoGeneral.iIdClaseVehicular))
				.ForMember(src => src.IdTipo, opt => opt.MapFrom(dest =>	dest.DetalleAlta.DatoGeneral.iIdTipoVehicular))
				.ForMember(src => src.IdCombustible, opt => opt.MapFrom(dest => dest.DetalleAlta.DatoGeneral.iIdCombustibleVehicular));
;

			CreateMap<EntDetalleAltaVehiculoRequest, EntDetalleSolicitud>()
				.ForMember(dest => dest.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
				.ForMember(dest => dest.iIdEtapa, opt => opt.MapFrom(src => (long)EnumEtapa.CapturaInicial))
				.ForPath(dest => dest.DetalleAlta.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
				.ForPath(dest => dest.DetalleAlta.iIdTipoBien, opt => opt.MapFrom(src => (long)EnumTipoBien.MaquinariaVehiculo))
				.ForPath(dest => dest.DetalleAlta.iNumeroBienes, opt => opt.MapFrom(src => 1))
				.ForPath(dest => dest.DetalleAlta.iIdFamilia, opt => opt.MapFrom(src => src.IdFamilia))
				.ForPath(dest => dest.DetalleAlta.iIdSubfamilia, opt => opt.MapFrom(src => src.IdSubfamilia))
				.ForPath(dest => dest.DetalleAlta.iIdBms, opt => opt.MapFrom(src => src.IdBms))
				.ForPath(dest => dest.DetalleAlta.sDescripcion, opt => opt.MapFrom(src => src.Descripcion))
				.ForPath(dest => dest.DetalleAlta.sRequisicion, opt => opt.MapFrom(src => src.Requisicion))
				.ForPath(dest => dest.DetalleAlta.sOrdenCompra, opt => opt.MapFrom(src => src.OrdenCompra))
				.ForPath(dest => dest.DetalleAlta.iIdTipoAdquisicion, opt => opt.MapFrom(src => src.IdTipoAdquisicion))
				.ForPath(dest => dest.DetalleAlta.sNoSeries, opt => opt.MapFrom(src => src.NoSeries))
				.ForPath(dest => dest.DetalleAlta.sFolioAnterior, opt => opt.MapFrom(src => src.FolioAnterior))
				.ForPath(dest => dest.DetalleAlta.Licitacion.iNumeroLicitacion, opt => opt.MapFrom(src => src.NoLicitacion))
				.ForPath(dest => dest.DetalleAlta.Licitacion.dtFecha, opt => opt.MapFrom(src => src.FechaLicitacion))
				.ForPath(dest => dest.DetalleAlta.Licitacion.sObservaciones, opt => opt.MapFrom(src => src.ObservacionLicitacion))
				.ForPath(dest => dest.DetalleAlta.iIdEstadoFisico, opt => opt.MapFrom(src => src.IdEstadoFisico))
				.ForPath(dest => dest.iIdEtapa, opt => opt.MapFrom(src => (long)EnumEtapa.CapturaInicial))
				.ForPath(dest => dest.DetalleAlta.DatoGeneral.iIdMarca, opt => opt.MapFrom(src => src.IdMarca))
				.ForPath(dest => dest.DetalleAlta.DatoGeneral.iIdColor, opt => opt.MapFrom(src => src.IdColor))
				.ForPath(dest => dest.DetalleAlta.Factura.sFolioFactura, opt => opt.MapFrom(src => src.FolioFactura))
				.ForPath(dest => dest.DetalleAlta.Factura.dtFecha, opt => opt.MapFrom(src => src.FechaFactura))
				.ForPath(dest => dest.DetalleAlta.dPrecioUnitario, opt => opt.MapFrom(src => src.PrecioUnitario))
				.ForPath(dest => dest.DetalleAlta.dtFechaAdquisicion, opt => opt.MapFrom(src => src.FechaCompra))
				.ForPath(dest => dest.DetalleAlta.Factura.iGarantiaDias, opt => opt.MapFrom(src => src.DiasGarantia))
				.ForPath(dest => dest.DetalleAlta.iAniosVida, opt => opt.MapFrom(src => src.VidaUtil))
				.ForPath(dest => dest.DetalleAlta.dtFechaInicioUso, opt => opt.MapFrom(src => src.FechaInicioUso))
				.ForPath(dest => dest.DetalleAlta.dPrecioDesechable, opt => opt.MapFrom(src => src.PrecioDesechable))
				.ForPath(dest => dest.DetalleAlta.sObservacionBien, opt => opt.MapFrom(src => src.ObservacionBien))
				.ForPath(dest => dest.DetalleAlta.iIdUbicacion, opt => opt.MapFrom(src => src.IdUbicacion))
				.ForPath(dest => dest.DetalleAlta.iIdMunicipio, opt => opt.MapFrom(src => src.IdMunicipio))
				.ForPath(dest => dest.DetalleAlta.sCaracteristicas, opt => opt.MapFrom(src => src.Caracteristicas))
				.ForPath(dest => dest.DetalleAlta.sResguardantes, opt => opt.MapFrom(src => src.Responsables))
				.ForPath(dest => dest.DetalleAlta.sObservacionResponsable, opt => opt.MapFrom(src => src.ObservacionResponsable))


				.ForPath(dest => dest.DetalleAlta.sCuentaPorPagar, opt => opt.MapFrom(src => src.CuentaPorPagar))
				.ForPath(dest => dest.DetalleAlta.sSustituyeBv, opt => opt.MapFrom(src => src.SustituyeBV))
				.ForPath(dest => dest.DetalleAlta.Factura.DatoVehicular.iAnioEmision, opt => opt.MapFrom(src => src.AnioEmicion))
				.ForPath(dest => dest.DetalleAlta.Factura.DatoVehicular.sNumeroPlaca, opt => opt.MapFrom(src => src.NumeroPlaca))
				.ForPath(dest => dest.DetalleAlta.Factura.DatoVehicular.iNumeroMotor, opt => opt.MapFrom(src => src.NumeroMotor))
				.ForPath(dest => dest.DetalleAlta.Factura.DatoVehicular.iAnioModelo, opt => opt.MapFrom(src => src.AnioModelo))
				.ForPath(dest => dest.DetalleAlta.Factura.DatoVehicular.nNumeroEconomico, opt => opt.MapFrom(src => src.NumeroEconomico))

				.ForPath(dest => dest.DetalleAlta.DatoGeneral.iIdClaveVehicular, opt => opt.MapFrom(src => src.IdClave))
				.ForPath(dest => dest.DetalleAlta.DatoGeneral.iIdLineaVehicular, opt => opt.MapFrom(src => src.IdLinea))
				.ForPath(dest => dest.DetalleAlta.DatoGeneral.iIdVersionVehicular, opt => opt.MapFrom(src => src.IdVersion))
				.ForPath(dest => dest.DetalleAlta.DatoGeneral.iIdClaseVehicular, opt => opt.MapFrom(src => src.IdClase))
				.ForPath(dest => dest.DetalleAlta.DatoGeneral.iIdTipoVehicular, opt => opt.MapFrom(src => src.IdTipo))
				.ForPath(dest => dest.DetalleAlta.DatoGeneral.iIdCombustibleVehicular, opt => opt.MapFrom(src => src.IdCombustible));

		}
	}
}
