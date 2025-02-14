using AutoMapper;
using ControlBienes.Entities.Patrimonio.Bien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.Inventario
{
	internal class BusInventarioMapping : Profile
	{
		public BusInventarioMapping()
		{
			CreateMap<EntBienPatrimonio, EntBienPatrimonioResponse>()
		   .ForMember(dest => dest.IdBien, opt => opt.MapFrom(src => src.iIdBien))
		   .ForMember(dest => dest.IdMotivoTramite, opt => opt.MapFrom(src => src.Solicitud.iIdMotivoTramite))
		   .ForMember(dest => dest.IdPeriodo, opt => opt.MapFrom(src => src.iIdPeriodo))
		   .ForMember(dest => dest.IdSolicitud, opt => opt.MapFrom(src => src.iIdSolicitud))
		   .ForMember(dest => dest.IdTipoBien, opt => opt.MapFrom(src => src.iIdTipoBien))
		   .ForMember(dest => dest.FolioBien, opt => opt.MapFrom(src => src.sFolioBien))
		   .ForMember(dest => dest.IdFamilia, opt => opt.MapFrom(src => src.iIdFamilia))
		   .ForMember(dest => dest.IdSubfamilia, opt => opt.MapFrom(src => src.iIdSubfamilia))
		   .ForMember(dest => dest.IdBms, opt => opt.MapFrom(src => src.iIdBms))
		   .ForMember(dest => dest.ReferenciaConac, opt => opt.MapFrom(src => src.sReferenciaConac))
		   .ForMember(dest => dest.PartidaEspecifica, opt => opt.MapFrom(src => src.sPartidaEspecifica))
		   .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
		   .ForMember(dest => dest.NivelUnidadAdministrativa, opt => opt.MapFrom(src => src.UnidadAdministrativa.sNivelCompleto))
		   .ForMember(dest => dest.Requisicion, opt => opt.MapFrom(src => src.sRequisicion))
		   .ForMember(dest => dest.OrdenCompra, opt => opt.MapFrom(src => src.sOrdenCompra))
		   .ForMember(dest => dest.CuentaPorPagar, opt => opt.MapFrom(src => src.sCuentaPorPagar))
		   .ForMember(dest => dest.IdTipoAdquisicion, opt => opt.MapFrom(src => src.iIdTipoAdquisicion))
		   .ForMember(dest => dest.IdMunicipio, opt => opt.MapFrom(src => src.iIdMunicipio))
		   .ForMember(dest => dest.SustituyeBv, opt => opt.MapFrom(src => src.sSustituyeBv))
		   .ForMember(dest => dest.IdUbicacion, opt => opt.MapFrom(src => src.iIdUbicacion))
		   .ForMember(dest => dest.NoSeries, opt => opt.MapFrom(src => src.sNoSeries))
		   .ForMember(dest => dest.FolioAnterior, opt => opt.MapFrom(src => src.sFolioAnterior))
		   .ForMember(dest => dest.IdEstadoFisico, opt => opt.MapFrom(src => src.iIdEstadoFisico))
		   .ForMember(dest => dest.PrecioUnitario, opt => opt.MapFrom(src => src.dPrecioUnitario))
		   .ForMember(dest => dest.VidaUtil, opt => opt.MapFrom(src => src.iAniosVida))
		   .ForMember(dest => dest.DiasGarantia, opt => opt.MapFrom(src => src.Factura.iGarantiaDias))
		   .ForMember(dest => dest.FolioFactura, opt => opt.MapFrom(src => src.Factura.sFolioFactura))
		   .ForMember(dest => dest.FechaFactura, opt => opt.MapFrom(src => src.Factura.dtFecha))
		   .ForMember(dest => dest.NoLicitacion, opt => opt.MapFrom(src => src.Licitacion.iNumeroLicitacion))
		   .ForMember(dest => dest.ObservacionLicitacion, opt => opt.MapFrom(src => src.Licitacion.sObservaciones))
		   .ForMember(dest => dest.IdMarca, opt => opt.MapFrom(src => src.DatoGeneral.iIdMarca))
		   .ForMember(dest => dest.IdColor, opt => opt.MapFrom(src => src.DatoGeneral.iIdColor))
		   .ForMember(dest => dest.FechaLicitacion, opt => opt.MapFrom(src => src.Licitacion.dtFecha))
		   .ForMember(dest => dest.FechaCompra, opt => opt.MapFrom(src => src.dtFechaAdquisicion))
		   .ForMember(dest => dest.FechaInicioUso, opt => opt.MapFrom(src => src.dtFechaInicioUso))
		   .ForMember(dest => dest.PrecioDepreciado, opt => opt.MapFrom(src => src.dPrecioDepreciado))
		   .ForMember(dest => dest.PrecioDesechable, opt => opt.MapFrom(src => src.dPrecioDesechable))
		   .ForMember(dest => dest.CuentaActivo, opt => opt.MapFrom(src => src.sCuentaActivo))
		   .ForMember(dest => dest.CuentaActualizacion, opt => opt.MapFrom(src => src.sCuentaActualizacion))
		   .ForMember(dest => dest.Caracteristicas, opt => opt.MapFrom(src => src.sCaracteristicas))
		   .ForMember(dest => dest.Responsables, opt => opt.MapFrom(src => src.sResguardantes))
		   .ForMember(dest => dest.ObservacionBien, opt => opt.MapFrom(src => src.sObservacionBien))
		   .ForMember(dest => dest.ObservacionResponsable, opt => opt.MapFrom(src => src.sObservacionResponsable))

			.ForMember(dest => dest.CuentaPorPagar, opt => opt.MapFrom(src => src.sCuentaPorPagar))
			.ForMember(dest => dest.AnioEmicion, opt => opt.MapFrom(src => src.Factura.DatoVehicular.iAnioEmision))
			.ForMember(dest => dest.NumeroPlaca, opt => opt.MapFrom(src => src.Factura.DatoVehicular.sNumeroPlaca))
			.ForMember(dest => dest.NumeroMotor, opt => opt.MapFrom(src => src.Factura.DatoVehicular.iNumeroMotor))
			.ForMember(dest => dest.AnioModelo, opt => opt.MapFrom(src => src.Factura.DatoVehicular.iAnioModelo))
			.ForMember(dest => dest.NumeroEconomico, opt => opt.MapFrom(src => src.Factura.DatoVehicular.nNumeroEconomico))
			.ForMember(dest => dest.IdClave, opt => opt.MapFrom(src => src.DatoGeneral.iIdClaveVehicular))
			.ForMember(dest => dest.IdLinea, opt => opt.MapFrom(src => src.DatoGeneral.iIdLineaVehicular))
			.ForMember(dest => dest.IdVersion, opt => opt.MapFrom(src => src.DatoGeneral.iIdVersionVehicular))
			.ForMember(dest => dest.IdClase, opt => opt.MapFrom(src => src.DatoGeneral.iIdClaseVehicular))
			.ForMember(dest => dest.IdTipo, opt => opt.MapFrom(src => src.DatoGeneral.iIdTipoVehicular))
			.ForMember(dest => dest.IdCombustible, opt => opt.MapFrom(src => src.DatoGeneral.iIdCombustibleVehicular))


			.ForMember(dest => dest.ValorHistorico, opt => opt.MapFrom(src => src.DatoInmueble.dValorHistorico))
				.ForMember(dest => dest.ValorLibros, opt => opt.MapFrom(src => src.DatoInmueble.dValorLibros))
				.ForMember(dest => dest.Depreciacion, opt => opt.MapFrom(src => src.DatoInmueble.dDepreciacion))
				.ForMember(dest => dest.AniosVida, opt => opt.MapFrom(src => src.iAniosVida))
				.ForMember(dest => dest.Nomenclatura, opt => opt.MapFrom(src => src.DatoInmueble.sNomenclatura))
				.ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
				.ForMember(dest => dest.IdTipoInmueble, opt => opt.MapFrom(src => src.DatoInmueble.iIdTipoInmueble))
				.ForMember(dest => dest.IdUsoInmueble, opt => opt.MapFrom(src => src.DatoInmueble.iIdUsoInmueble))
				.ForMember(dest => dest.IdTipoDominio, opt => opt.MapFrom(src => src.DatoInmueble.iIdTipoDomninio))
				.ForMember(dest => dest.IdTipoAfectacion, opt => opt.MapFrom(src => src.DatoInmueble.iIdTipoAfectacion))
				.ForMember(dest => dest.Afectante, opt => opt.MapFrom(src => src.DatoInmueble.sAfectante))
				.ForMember(dest => dest.IdTipoAdquisicion, opt => opt.MapFrom(src => src.iIdTipoAdquisicion))
				.ForMember(dest => dest.IdEstadoFisico, opt => opt.MapFrom(src => src.iIdEstadoFisico))
				.ForMember(dest => dest.FechaAdquisicion, opt => opt.MapFrom(src => src.dtFechaAdquisicion))
				.ForMember(dest => dest.FechaAltaSistema, opt => opt.MapFrom(src => src.DatoInmueble.dtFechaAltaSistema))
				.ForMember(dest => dest.FolioCatastro, opt => opt.MapFrom(src => src.DatoInmueble.DatosRegistral.iFolioCatastro))
				.ForMember(dest => dest.Calle, opt => opt.MapFrom(src => src.DatoInmueble.DatosRegistral.sCalle))
				.ForMember(dest => dest.Superficie, opt => opt.MapFrom(src => src.DatoInmueble.DatosRegistral.dSuperficie))
				.ForMember(dest => dest.ValorTerreno, opt => opt.MapFrom(src => src.DatoInmueble.DatosRegistral.dValorTerreno))
				.ForMember(dest => dest.NumeroExterior, opt => opt.MapFrom(src => src.DatoInmueble.DatosRegistral.sNumeroExterior))
				.ForMember(dest => dest.NumeroInterior, opt => opt.MapFrom(src => src.DatoInmueble.DatosRegistral.sNumeroInterior))
				.ForMember(dest => dest.Cruzamiento1, opt => opt.MapFrom(src => src.DatoInmueble.DatosRegistral.sCruzamimiento1))
				.ForMember(dest => dest.Cruzamiento2, opt => opt.MapFrom(src => src.DatoInmueble.DatosRegistral.sCruzamimiento2))
				.ForMember(dest => dest.SuperficieConstruccion, opt => opt.MapFrom(src => src.DatoInmueble.DatosRegistral.dSuperficieContruccion))
				.ForMember(dest => dest.Tablaje, opt => opt.MapFrom(src => src.DatoInmueble.DatosRegistral.sTablaje))
				.ForMember(dest => dest.ValorConstruccion, opt => opt.MapFrom(src => src.DatoInmueble.DatosRegistral.dValorConstruccion))
				.ForMember(dest => dest.ValorInicial, opt => opt.MapFrom(src => src.DatoInmueble.DatosRegistral.dValorInicial))
				.ForMember(dest => dest.CodigoPostal, opt => opt.MapFrom(src => src.DatoInmueble.DatosRegistral.nCodigoPostal))
				.ForMember(dest => dest.IdOrigenValor, opt => opt.MapFrom(src => src.DatoInmueble.DatosRegistral.iIdOrigenValor))
				.ForMember(dest => dest.Asentamiento, opt => opt.MapFrom(src => src.DatoInmueble.DatosRegistral.sAsentamiento))
				.ForMember(dest => dest.Propietario, opt => opt.MapFrom(src => src.DatoInmueble.DatosRegistral.sPropietario))
	
				.ForMember(dest => dest.DecretoPublicaicion, opt => opt.MapFrom(src => src.DatoInmueble.sPublicacion))
				.ForMember(dest => dest.EscrituraTitulo, opt => opt.MapFrom(src => src.DatoInmueble.sEscrituraTitulo))
				.ForMember(dest => dest.Expediente, opt => opt.MapFrom(src => src.DatoInmueble.sExpediente))

			;
			// obserbacion por bien y reponsable
		}
	}
}
