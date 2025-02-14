using AutoMapper;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.DetalleModificacion;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Etapa;

namespace ControlBienes.Business.Features.Patrimonio.TramiteMueble.Modificacion
{
	public class BusTramiteMuebleModificacionMapping : Profile
	{
		public BusTramiteMuebleModificacionMapping()
		{
			CreateMap<EntDetalleModificacionMuebleRequest, EntDetalleSolicitud>()
				.ForMember(dest => dest.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
				.ForMember(dest => dest.iIdEtapa, opt => opt.MapFrom(src => (long)EnumEtapa.CapturaInicial))
				.ForPath(dest => dest.DetalleModificacion.iIdBien, opt => opt.MapFrom(src => src.IdBienPatrimonio))
				.ForPath(dest => dest.DetalleModificacion.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
				.ForPath(dest => dest.DetalleModificacion.iIdTipoBien, opt => opt.MapFrom(src => (long)EnumTipoBien.Mueble))
				.ForPath(dest => dest.DetalleModificacion.iNumeroBienes, opt => opt.MapFrom(src => 1))
				.ForPath(dest => dest.DetalleModificacion.sDescripcion, opt => opt.MapFrom(src => src.Descripcion))
				.ForPath(dest => dest.DetalleModificacion.sRequisicion, opt => opt.MapFrom(src => src.Requisicion))
				.ForPath(dest => dest.DetalleModificacion.sOrdenCompra, opt => opt.MapFrom(src => src.OrdenCompra))
				.ForPath(dest => dest.DetalleModificacion.iIdTipoAdquisicion, opt => opt.MapFrom(src => src.IdTipoAdquisicion))
				.ForPath(dest => dest.DetalleModificacion.sNoSeries, opt => opt.MapFrom(src => src.NoSeries))
				.ForPath(dest => dest.DetalleModificacion.sFolioAnterior, opt => opt.MapFrom(src => src.FolioAnterior))
				.ForPath(dest => dest.DetalleModificacion.Licitacion.iNumeroLicitacion, opt => opt.MapFrom(src => src.NoLicitacion))
				.ForPath(dest => dest.DetalleModificacion.Licitacion.dtFecha, opt => opt.MapFrom(src => src.FechaLicitacion))
				.ForPath(dest => dest.DetalleModificacion.Licitacion.sObservaciones, opt => opt.MapFrom(src => src.ObservacionLicitacion))
				.ForPath(dest => dest.DetalleModificacion.iIdEstadoFisico, opt => opt.MapFrom(src => src.IdEstadoFisico))
				.ForPath(dest => dest.iIdEtapa, opt => opt.MapFrom(src => (long)EnumEtapa.CapturaInicial))
				.ForPath(dest => dest.DetalleModificacion.DatoGeneral.iIdMarca, opt => opt.MapFrom(src => src.IdMarca))
				.ForPath(dest => dest.DetalleModificacion.DatoGeneral.iIdColor, opt => opt.MapFrom(src => src.IdColor))
				.ForPath(dest => dest.DetalleModificacion.Factura.sFolioFactura, opt => opt.MapFrom(src => src.FolioFactura))
				.ForPath(dest => dest.DetalleModificacion.Factura.dtFecha, opt => opt.MapFrom(src => src.FechaFactura))
				.ForPath(dest => dest.DetalleModificacion.dPrecioUnitario, opt => opt.MapFrom(src => src.PrecioUnitario))
				.ForPath(dest => dest.DetalleModificacion.dtFechaAdquisicion, opt => opt.MapFrom(src => src.FechaCompra))
				.ForPath(dest => dest.DetalleModificacion.Factura.iGarantiaDias, opt => opt.MapFrom(src => src.DiasGarantia))
				.ForPath(dest => dest.DetalleModificacion.iAniosVida, opt => opt.MapFrom(src => src.VidaUtil))
				.ForPath(dest => dest.DetalleModificacion.dtFechaInicioUso, opt => opt.MapFrom(src => src.FechaInicioUso))
				.ForPath(dest => dest.DetalleModificacion.dPrecioDesechable, opt => opt.MapFrom(src => src.PrecioDesechable))
				.ForPath(dest => dest.DetalleModificacion.sObservacionBien, opt => opt.MapFrom(src => src.ObservacionBien))
				.ForPath(dest => dest.DetalleModificacion.iIdUbicacion, opt => opt.MapFrom(src => src.IdUbicacion))
				.ForPath(dest => dest.DetalleModificacion.iIdMunicipio, opt => opt.MapFrom(src => src.IdMunicipio))
				.ForPath(dest => dest.DetalleModificacion.sCaracteristicas, opt => opt.MapFrom(src => src.Caracteristicas))
				.ForPath(dest => dest.DetalleModificacion.sObservacionResponsable, opt => opt.MapFrom(src => src.ObservacionResponsable))
				.ForMember(dest => dest.DetalleAlta, opt => opt.Ignore());

			CreateMap<EntDetalleSolicitud, EntDetalleModificacionMuebleResponse>()
				.ForMember(dest => dest.IdSolicitud, opt => opt.MapFrom(src => src.iIdSolicitud))
				.ForMember(dest => dest.IdBienPatrimonio, opt => opt.MapFrom(src => src.DetalleModificacion.iIdBien))
				.ForMember(dest => dest.NivelCentroCosto, opt => opt.MapFrom(src => src.DetalleModificacion.CentroCosto.sNivelCompleto))
				.ForMember(dest => dest.IdFamilia, opt => opt.MapFrom(src => src.DetalleModificacion.iIdFamilia))
				.ForMember(dest => dest.IdSubfamilia, opt => opt.MapFrom(src => src.DetalleModificacion.iIdSubfamilia))
				.ForMember(dest => dest.IdBms, opt => opt.MapFrom(src => src.DetalleModificacion.iIdBms))
				.ForMember(dest => dest.Partida, opt => opt.MapFrom(src => EntConstant.DefaultPartida))
				.ForMember(dest => dest.PartidaEspecifica, opt => opt.MapFrom(src => src.DetalleModificacion.sPartidaEspecifica))
				.ForMember(dest => dest.ReferenciaActivo, opt => opt.MapFrom(src => src.DetalleModificacion.sCuentaActivo))
				.ForMember(dest => dest.ReferenciaActualizacion, opt => opt.MapFrom(src => src.DetalleModificacion.sCuentaActualizacion))
				.ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.DetalleModificacion.sDescripcion))
				.ForMember(dest => dest.NivelUnidadAdministrativa, opt => opt.MapFrom(src => src.DetalleModificacion.UnidadAdministrativa.sNivelCompleto))
				.ForMember(dest => dest.Requisicion, opt => opt.MapFrom(src => src.DetalleModificacion.sRequisicion))
				.ForMember(dest => dest.OrdenCompra, opt => opt.MapFrom(src => src.DetalleModificacion.sOrdenCompra))
				.ForMember(dest => dest.IdTipoAdquisicion, opt => opt.MapFrom(src => src.DetalleModificacion.iIdTipoAdquisicion))
				.ForMember(dest => dest.NoSeries, opt => opt.MapFrom(src => src.DetalleModificacion.sNoSeries))
				.ForMember(dest => dest.FolioAnterior, opt => opt.MapFrom(src => src.DetalleModificacion.sFolioAnterior))
				.ForMember(dest => dest.NoLicitacion, opt => opt.MapFrom(src => src.DetalleModificacion.Licitacion.iNumeroLicitacion))
				.ForMember(dest => dest.FechaLicitacion, opt => opt.MapFrom(src => src.DetalleModificacion.Licitacion.dtFecha))
				.ForMember(dest => dest.ObservacionLicitacion, opt => opt.MapFrom(src => src.DetalleModificacion.Licitacion.sObservaciones))
				.ForMember(dest => dest.IdEstadoFisico, opt => opt.MapFrom(src => src.DetalleModificacion.iIdEstadoFisico))
				.ForMember(dest => dest.IdMarca, opt => opt.MapFrom(src => src.DetalleModificacion.DatoGeneral.iIdMarca))
				.ForMember(dest => dest.IdColor, opt => opt.MapFrom(src => src.DetalleModificacion.DatoGeneral.iIdColor))
				.ForMember(dest => dest.FolioFactura, opt => opt.MapFrom(src => src.DetalleModificacion.Factura.sFolioFactura))
				.ForMember(dest => dest.FechaFactura, opt => opt.MapFrom(src => src.DetalleModificacion.Factura.dtFecha))
				.ForMember(dest => dest.PrecioUnitario, opt => opt.MapFrom(src => src.DetalleModificacion.dPrecioUnitario))
				.ForMember(dest => dest.FechaCompra, opt => opt.MapFrom(src => src.DetalleModificacion.dtFechaAdquisicion))
				.ForMember(dest => dest.DiasGarantia, opt => opt.MapFrom(src => src.DetalleModificacion.Factura.iGarantiaDias))
				.ForMember(dest => dest.VidaUtil, opt => opt.MapFrom(src => src.DetalleModificacion.iAniosVida))
				.ForMember(dest => dest.FechaInicioUso, opt => opt.MapFrom(src => src.DetalleModificacion.dtFechaInicioUso))
				.ForMember(dest => dest.PrecioDesechable, opt => opt.MapFrom(src => src.DetalleModificacion.dPrecioDesechable))
				.ForMember(dest => dest.ObservacionBien, opt => opt.MapFrom(src => src.DetalleModificacion.sObservacionBien))
				.ForMember(dest => dest.IdUbicacion, opt => opt.MapFrom(src => src.DetalleModificacion.iIdUbicacion))
				.ForMember(dest => dest.IdMunicipio, opt => opt.MapFrom(src => src.DetalleModificacion.iIdMunicipio))
				.ForMember(dest => dest.Caracteristicas, opt => opt.MapFrom(src => src.DetalleModificacion.sCaracteristicas))
				.ForMember(dest => dest.Responsables, opt => opt.MapFrom(src => src.DetalleModificacion.sResguardantes))
				.ForMember(dest => dest.ObservacionResponsable, opt => opt.MapFrom(src => src.DetalleModificacion.sObservacionResponsable));
		}
	}
}
