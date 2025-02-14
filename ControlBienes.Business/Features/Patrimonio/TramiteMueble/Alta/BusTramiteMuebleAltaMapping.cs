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

namespace ControlBienes.Business.Features.Patrimonio.TramiteMueble.Alta
{
	public class BusTramiteVehiculoAltaMapping : Profile
	{
		public BusTramiteVehiculoAltaMapping()
		{

			CreateMap<EntDetalleSolicitud, EntDetalleSolicitudResponse>()
				.ForMember(dest => dest.IdDetalleSolicitud, opt => opt.MapFrom(src => src.iIdDetalleSolicitud))
				.ForMember(dest => dest.FolioBien, opt => opt.MapFrom(src =>
					(src.DetalleAlta.sFolioBien != null)
						? src.DetalleAlta.sFolioBien ?? string.Empty 
						: src.DetalleModificacion.sFolioBien != null
							? src.DetalleModificacion.sFolioBien ?? string.Empty 
							: src.DetalleBaja.Baja.sFolioBien != null
								? src.DetalleBaja.Baja.sFolioBien ?? string.Empty 
								: src.DetalleMovimiento.sFolioBien != null
									? src.DetalleMovimiento.sFolioBien ?? string.Empty
									: src.DetalleDestinoFinal.sFolioBien != null
										? src.DetalleDestinoFinal.sFolioBien ?? string.Empty
										: src.DetalleDesincorporacion.sFolioBien != null
											? src.DetalleDesincorporacion.sFolioBien ?? string.Empty 
											: string.Empty))
				.ForMember(dest => dest.Etapa, opt => opt.MapFrom(src => src.Etapa.sNombre))
				.ForMember(dest => dest.TipoBien, opt => opt.MapFrom(src =>
					(src.DetalleAlta.TipoBien.sNombre != null)
						? $"{src.DetalleAlta.TipoBien.iIdTipoBien}.-{src.DetalleAlta.TipoBien.sNombre}" ?? string.Empty
						: src.DetalleModificacion.TipoBien.sNombre != null
							? $"{src.DetalleModificacion.TipoBien.iIdTipoBien}.-{src.DetalleModificacion.TipoBien.sNombre}" ?? string.Empty
							: src.DetalleBaja.Baja.TipoBien.sNombre != null
								? $"{src.DetalleBaja.Baja.TipoBien.iIdTipoBien}.-{src.DetalleBaja.Baja.TipoBien.sNombre}" ?? string.Empty
								: src.DetalleMovimiento.TipoBien.sNombre != null
									? $"{src.DetalleMovimiento.TipoBien.iIdTipoBien}.-{src.DetalleMovimiento.TipoBien.sNombre}" ?? string.Empty
									: src.DetalleDestinoFinal.TipoBien.sNombre != null
										? $"{src.DetalleDestinoFinal.TipoBien.iIdTipoBien}.-{src.DetalleDestinoFinal.TipoBien.sNombre}" ?? string.Empty
										: src.DetalleDesincorporacion.TipoBien.sNombre != null
											? $"{src.DetalleDesincorporacion.TipoBien.iIdTipoBien}.-{src.DetalleDesincorporacion.TipoBien.sNombre}" ?? string.Empty
											: string.Empty))

				.ForMember(dest => dest.Familia, opt => opt.MapFrom(src =>
					(src.DetalleAlta.Familia.sNombre != null)
						? $"{src.DetalleAlta.Familia.iIdFamilia}.-{src.DetalleAlta.Familia.sNombre}" ?? string.Empty
						: src.DetalleModificacion.Familia.sNombre != null
							? $"{src.DetalleModificacion.Familia.iIdFamilia}.-{src.DetalleModificacion.Familia.sNombre}" ?? string.Empty
							: string.Empty))

				.ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src =>
					(src.DetalleAlta.sDescripcion != null)
						? src.DetalleAlta.sDescripcion ?? string.Empty
						: src.DetalleModificacion.sDescripcion != null
							? src.DetalleModificacion.sDescripcion ?? string.Empty
							: string.Empty))

				.ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src =>
					src.Solicitud.iIdTipoTramite == (long)EnumTipoTramite.AltaDeBienesMuebles ? src.DetalleAlta.sDescripcion :
					src.Solicitud.iIdTipoTramite == (long)EnumTipoTramite.ModificacionDeBienesMuebles ? src.DetalleModificacion.sDescripcion :
					src.Solicitud.iIdTipoTramite == (long)EnumTipoTramite.BajaDeBienesMuebles ? "" :
					src.Solicitud.iIdTipoTramite == (long)EnumTipoTramite.AltaDeBienesMuebles ? src.DetalleModificacion.sDescripcion :
					string.Empty))

				.ForMember(dest => dest.SubFamilia, opt => opt.MapFrom(src =>
					(src.DetalleAlta.Subfamilia.sNombre != null)
						? $"{src.DetalleAlta.Subfamilia.iIdSubfamilia}.-{src.DetalleAlta.Subfamilia.sNombre}" ?? string.Empty
						: src.DetalleModificacion.Subfamilia.sNombre != null
							? $"{src.DetalleModificacion.Subfamilia.iIdSubfamilia}.-{src.DetalleModificacion.Subfamilia.sNombre}" ?? string.Empty
							: string.Empty))

				.ForMember(dest => dest.Ubicacion, opt => opt.MapFrom(src =>
					(src.DetalleAlta.Ubicacion.sDescripcion != null)
						? $"{src.DetalleAlta.Ubicacion.iIdUbicacion}.-{src.DetalleAlta.Ubicacion.sDescripcion}" ?? string.Empty
						: src.DetalleModificacion.Ubicacion.sDescripcion != null
							? $"{src.DetalleModificacion.Ubicacion.iIdUbicacion}.-{src.DetalleModificacion.Ubicacion.sDescripcion}" ?? string.Empty
							: string.Empty))

				.ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
				.ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));


			CreateMap<EntSeguimiento, EntSeguimientoResponse>()
				.ForMember(dest => dest.IdSeguimiento, opt => opt.MapFrom(src => src.iIdSeguimiento))
				.ForMember(dest => dest.Etapa, opt => opt.MapFrom(src => src.Etapa.sNombre))
				.ForMember(dest => dest.Modulo, opt => opt.MapFrom(src => src.Modulo.sAbreviacion))
				.ForMember(dest => dest.SubModulo, opt => opt.MapFrom(src => src.SubModulo.sAbreviacion))
				.ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario.UserName))
				.ForMember(dest => dest.FechaHora, opt => opt.MapFrom(src => src.dtFechaHora));

			CreateMap<EntDetalleSolicitud, EntDetalleAltaMuebleResponse>()
				.ForMember(dest => dest.IdSolicitud, opt => opt.MapFrom(src => src.iIdSolicitud))
				.ForMember(dest => dest.NumeroBienes, opt => opt.MapFrom(src => src.DetalleAlta.iNumeroBienes))
				.ForMember(dest => dest.IdTipoBien, opt => opt.MapFrom(src => src.DetalleAlta.iIdTipoBien))
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
				.ForMember(dest => dest.ObservacionResponsable, opt => opt.MapFrom(src => src.DetalleAlta.sObservacionResponsable));

			CreateMap<EntDetalleAltaMuebleRequest, EntDetalleSolicitud>()
				.ForMember(dest => dest.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
				.ForMember(dest => dest.iIdEtapa, opt => opt.MapFrom(src => (long)EnumEtapa.CapturaInicial))
				.ForPath(dest => dest.DetalleAlta.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
				.ForPath(dest => dest.DetalleAlta.iIdTipoBien, opt => opt.MapFrom(src => (long)EnumTipoBien.Mueble))
				.ForPath(dest => dest.DetalleAlta.iNumeroBienes, opt => opt.MapFrom(src => src.NumeroBienes))
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
				.ForPath(dest => dest.DetalleAlta.sObservacionResponsable, opt => opt.MapFrom(src => src.ObservacionResponsable));

		}
	}
}
