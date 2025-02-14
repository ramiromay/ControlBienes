using AutoMapper;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.DetalleModificacion;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Etapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteVehiculo.Modificacion
{
	public class BusTramiteVehiculoModificacionMapping : Profile
	{
		public BusTramiteVehiculoModificacionMapping()
		{
			CreateMap<EntDetalleSolicitud, EntDetalleModificacionVehiculoResponse>()
			.ForMember(dest => dest.IdSolicitud, opt => opt.MapFrom(src => src.iIdSolicitud))
			.ForMember(dest => dest.IdBienPatrimonio, opt => opt.MapFrom(src => src.DetalleModificacion.iIdBien))

			.ForMember(dest => dest.IdFamilia, opt => opt.MapFrom(src => src.DetalleModificacion.iIdFamilia))
			.ForMember(dest => dest.IdSubfamilia, opt => opt.MapFrom(src => src.DetalleModificacion.iIdSubfamilia))
			.ForMember(dest => dest.IdBms, opt => opt.MapFrom(src => src.DetalleModificacion.iIdBms))
			.ForMember(dest => dest.Partida, opt => opt.MapFrom(src => EntConstant.DefaultPartida))
			.ForMember(dest => dest.PartidaEspecifica, opt => opt.MapFrom(src => src.DetalleModificacion.sPartidaEspecifica))
			.ForMember(dest => dest.ReferenciaActivo, opt => opt.MapFrom(src => src.DetalleModificacion.sCuentaActivo))
			.ForMember(dest => dest.ReferenciaActualizacion, opt => opt.MapFrom(src => src.DetalleModificacion.sCuentaActualizacion))
			.ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.DetalleModificacion.sDescripcion))
			.ForMember(dest => dest.NivelUnidadAdministrativa, opt => opt.MapFrom(src => src.DetalleModificacion.UnidadAdministrativa.sNivelCompleto))
			.ForMember(dest => dest.NivelCentroCosto, opt => opt.MapFrom(src => src.DetalleModificacion.CentroCosto.sNivelCompleto))
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
			.ForMember(dest => dest.ObservacionResponsable, opt => opt.MapFrom(src => src.DetalleModificacion.sObservacionResponsable))

			.ForMember(src => src.CuentaPorPagar, opt => opt.MapFrom(dest => dest.DetalleModificacion.sCuentaPorPagar))
			.ForMember(src => src.SustituyeBV, opt => opt.MapFrom(dest => dest.DetalleModificacion.sSustituyeBv))
			.ForMember(src => src.AnioEmicion, opt => opt.MapFrom(dest => dest.DetalleModificacion.Factura.DatoVehicular.iAnioEmision))
			.ForMember(src => src.NumeroPlaca, opt => opt.MapFrom(dest => dest.DetalleModificacion.Factura.DatoVehicular.sNumeroPlaca))
			.ForMember(src => src.NumeroMotor, opt => opt.MapFrom(dest => dest.DetalleModificacion.Factura.DatoVehicular.iNumeroMotor))
			.ForMember(src => src.AnioModelo, opt => opt.MapFrom(dest => dest.DetalleModificacion.Factura.DatoVehicular.iAnioModelo))
			.ForMember(src => src.NumeroEconomico, opt => opt.MapFrom(dest => dest.DetalleModificacion.Factura.DatoVehicular.nNumeroEconomico))
			.ForMember(src => src.IdClave, opt => opt.MapFrom(dest => dest.DetalleModificacion.DatoGeneral.iIdClaveVehicular))
			.ForMember(src => src.IdLinea, opt => opt.MapFrom(dest => dest.DetalleModificacion.DatoGeneral.iIdLineaVehicular))
			.ForMember(src => src.IdVersion, opt => opt.MapFrom(dest => dest.DetalleModificacion.DatoGeneral.iIdVersionVehicular))
			.ForMember(src => src.IdClase, opt => opt.MapFrom(dest => dest.DetalleModificacion.DatoGeneral.iIdClaseVehicular))
			.ForMember(src => src.IdTipo, opt => opt.MapFrom(dest => dest.DetalleModificacion.DatoGeneral.iIdTipoVehicular))
			.ForMember(src => src.IdCombustible, opt => opt.MapFrom(dest => dest.DetalleModificacion.DatoGeneral.iIdCombustibleVehicular));
			;

			CreateMap<EntDetalleModificacionVehiculoRequest, EntDetalleSolicitud>()
				.ForMember(dest => dest.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
				.ForPath(dest => dest.DetalleModificacion.iIdBien, opt => opt.MapFrom(src => src.IdBienPatrimonio))
				.ForMember(dest => dest.iIdEtapa, opt => opt.MapFrom(src => (long)EnumEtapa.CapturaInicial))
				.ForPath(dest => dest.DetalleModificacion.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
				.ForPath(dest => dest.DetalleModificacion.iIdTipoBien, opt => opt.MapFrom(src => (long)EnumTipoBien.MaquinariaVehiculo))
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


				.ForPath(dest => dest.DetalleModificacion.sCuentaPorPagar, opt => opt.MapFrom(src => src.CuentaPorPagar))
				.ForPath(dest => dest.DetalleModificacion.sSustituyeBv, opt => opt.MapFrom(src => src.SustituyeBV))
				.ForPath(dest => dest.DetalleModificacion.Factura.DatoVehicular.iAnioEmision, opt => opt.MapFrom(src => src.AnioEmicion))
				.ForPath(dest => dest.DetalleModificacion.Factura.DatoVehicular.sNumeroPlaca, opt => opt.MapFrom(src => src.NumeroPlaca))
				.ForPath(dest => dest.DetalleModificacion.Factura.DatoVehicular.iNumeroMotor, opt => opt.MapFrom(src => src.NumeroMotor))
				.ForPath(dest => dest.DetalleModificacion.Factura.DatoVehicular.iAnioModelo, opt => opt.MapFrom(src => src.AnioModelo))
				.ForPath(dest => dest.DetalleModificacion.Factura.DatoVehicular.nNumeroEconomico, opt => opt.MapFrom(src => src.NumeroEconomico))

				.ForPath(dest => dest.DetalleModificacion.DatoGeneral.iIdClaveVehicular, opt => opt.MapFrom(src => src.IdClave))
				.ForPath(dest => dest.DetalleModificacion.DatoGeneral.iIdLineaVehicular, opt => opt.MapFrom(src => src.IdLinea))
				.ForPath(dest => dest.DetalleModificacion.DatoGeneral.iIdVersionVehicular, opt => opt.MapFrom(src => src.IdVersion))
				.ForPath(dest => dest.DetalleModificacion.DatoGeneral.iIdClaseVehicular, opt => opt.MapFrom(src => src.IdClase))
				.ForPath(dest => dest.DetalleModificacion.DatoGeneral.iIdTipoVehicular, opt => opt.MapFrom(src => src.IdTipo))
				.ForPath(dest => dest.DetalleModificacion.DatoGeneral.iIdCombustibleVehicular, opt => opt.MapFrom(src => src.IdCombustible));
		}
	}
}
