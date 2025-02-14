using AutoMapper;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.InventarioVehiculo
{
	public class BusInventarioVehiculoMapping : Profile
	{
		public BusInventarioVehiculoMapping()
		{

			CreateMap<EntBienPatrimonio, EntBienVehiculoResponse>()
				.ForMember(dest => dest.IdBien, opt => opt.MapFrom(src => src.iIdBien))
				.ForMember(dest => dest.FolioBien, opt => opt.MapFrom(src => src.sFolioBien))
			.ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
			.ForMember(dest => dest.UnidadAdministrativa, opt => opt.MapFrom(src => $"{src.UnidadAdministrativa.sNivelCompleto} {src.UnidadAdministrativa.sNombre}"))
			.ForMember(dest => dest.Familia, opt => opt.MapFrom(src => $"{src.Familia.iIdFamilia} {src.Familia.sNombre}"))
			.ForMember(dest => dest.Subfamilia, opt => opt.MapFrom(src => $"{src.Subfamilia.iIdSubfamilia} {src.Subfamilia.sNombre}"))
			.ForMember(dest => dest.TipoBien, opt => opt.MapFrom(src => $"{src.TipoBien.iIdTipoBien} {src.TipoBien.sNombre}"))
			.ForMember(dest => dest.FechaAlta, opt => opt.MapFrom(src => src.dtFechaAlta))
			.ForMember(dest => dest.FechaBaja, opt => opt.MapFrom(src => src.dtFechaBaja))
			.ForMember(dest => dest.MotivoBaja, opt => opt.MapFrom(src => src.sMotivoBaja))
				.ForMember(dest => dest.IdFamilia, opt => opt.MapFrom(src => src.iIdFamilia))
				.ForMember(dest => dest.IdSubfamilia, opt => opt.MapFrom(src => src.iIdSubfamilia))
				.ForMember(dest => dest.IdBms, opt => opt.MapFrom(src => src.iIdBms))
				.ForMember(dest => dest.Partida, opt => opt.MapFrom(src => EntConstant.DefaultPartida))
				.ForMember(dest => dest.PartidaEspecifica, opt => opt.MapFrom(src => src.sPartidaEspecifica))
				.ForMember(dest => dest.ReferenciaActivo, opt => opt.MapFrom(src => src.sCuentaActivo))
				.ForMember(dest => dest.ReferenciaActualizacion, opt => opt.MapFrom(src => src.sCuentaActualizacion))
				.ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
				.ForMember(dest => dest.NivelUnidadAdministrativa, opt => opt.MapFrom(src => src.UnidadAdministrativa.sNivelCompleto))
				.ForMember(dest => dest.Requisicion, opt => opt.MapFrom(src => src.sRequisicion))
				.ForMember(dest => dest.OrdenCompra, opt => opt.MapFrom(src => src.sOrdenCompra))
				.ForMember(dest => dest.IdTipoAdquisicion, opt => opt.MapFrom(src => src.iIdTipoAdquisicion))
				.ForMember(dest => dest.NoSeries, opt => opt.MapFrom(src => src.sNoSeries))
				.ForMember(dest => dest.FolioAnterior, opt => opt.MapFrom(src => src.sFolioAnterior))
				.ForMember(dest => dest.NoLicitacion, opt => opt.MapFrom(src => src.Licitacion.iNumeroLicitacion))
				.ForMember(dest => dest.FechaLicitacion, opt => opt.MapFrom(src => src.Licitacion.dtFecha))
				.ForMember(dest => dest.ObservacionLicitacion, opt => opt.MapFrom(src => src.Licitacion.sObservaciones))
				.ForMember(dest => dest.IdEstadoFisico, opt => opt.MapFrom(src => src.iIdEstadoFisico))
				.ForMember(dest => dest.IdMarca, opt => opt.MapFrom(src => src.DatoGeneral.iIdMarca))
				.ForMember(dest => dest.IdColor, opt => opt.MapFrom(src => src.DatoGeneral.iIdColor))
				.ForMember(dest => dest.FolioFactura, opt => opt.MapFrom(src => src.Factura.sFolioFactura))
				.ForMember(dest => dest.FechaFactura, opt => opt.MapFrom(src => src.Factura.dtFecha))
				.ForMember(dest => dest.PrecioUnitario, opt => opt.MapFrom(src => src.dPrecioUnitario))
				.ForMember(dest => dest.FechaCompra, opt => opt.MapFrom(src => src.dtFechaAdquisicion))
				.ForMember(dest => dest.DiasGarantia, opt => opt.MapFrom(src => src.Factura.iGarantiaDias))
				.ForMember(dest => dest.VidaUtil, opt => opt.MapFrom(src => src.iAniosVida))
				.ForMember(dest => dest.FechaInicioUso, opt => opt.MapFrom(src => src.dtFechaInicioUso))
				.ForMember(dest => dest.PrecioDesechable, opt => opt.MapFrom(src => src.dPrecioDesechable))
				.ForMember(dest => dest.ObservacionBien, opt => opt.MapFrom(src => src.sObservacionBien))
				.ForMember(dest => dest.IdUbicacion, opt => opt.MapFrom(src => src.iIdUbicacion))
				.ForMember(dest => dest.IdMunicipio, opt => opt.MapFrom(src => src.iIdMunicipio))
				.ForMember(dest => dest.Caracteristicas, opt => opt.MapFrom(src => src.sCaracteristicas))
				.ForMember(dest => dest.Responsables, opt => opt.MapFrom(src => src.sResguardantes))
				.ForMember(dest => dest.ObservacionResponsable, opt => opt.MapFrom(src => src.sObservacionResponsable))

				.ForMember(src => src.CuentaPorPagar, opt => opt.MapFrom(dest => dest.sCuentaPorPagar))
				.ForMember(src => src.SustituyeBV, opt => opt.MapFrom(dest => dest.sSustituyeBv))
				.ForMember(src => src.AnioEmicion, opt => opt.MapFrom(dest => dest.Factura.DatoVehicular.iAnioEmision))
				.ForMember(src => src.NumeroPlaca, opt => opt.MapFrom(dest => dest.Factura.DatoVehicular.sNumeroPlaca))
				.ForMember(src => src.NumeroMotor, opt => opt.MapFrom(dest => dest.Factura.DatoVehicular.iNumeroMotor))
				.ForMember(src => src.AnioModelo, opt => opt.MapFrom(dest => dest.Factura.DatoVehicular.iAnioModelo))
				.ForMember(src => src.NumeroEconomico, opt => opt.MapFrom(dest => dest.Factura.DatoVehicular.nNumeroEconomico))
				.ForMember(src => src.IdClave, opt => opt.MapFrom(dest => dest.DatoGeneral.iIdClaveVehicular))
				.ForMember(src => src.IdLinea, opt => opt.MapFrom(dest => dest.DatoGeneral.iIdLineaVehicular))
				.ForMember(src => src.IdVersion, opt => opt.MapFrom(dest => dest.DatoGeneral.iIdVersionVehicular))
				.ForMember(src => src.IdClase, opt => opt.MapFrom(dest => dest.DatoGeneral.iIdClaseVehicular))
				.ForMember(src => src.IdTipo, opt => opt.MapFrom(dest => dest.DatoGeneral.iIdTipoVehicular))
				.ForMember(src => src.IdCombustible, opt => opt.MapFrom(dest => dest.DatoGeneral.iIdCombustibleVehicular));
		}
	}
}
