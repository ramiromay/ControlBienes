using AutoMapper;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Patrimonio.DetalleAlta;
using ControlBienes.Entities.Patrimonio.DetalleDestinoFinal;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Etapa;
using ControlBienes.Entities.Patrimonio.MotivoTramite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteInmueble.Alta
{
	public class BusTramiteInmuebleAltaMapping : Profile
	{
		public BusTramiteInmuebleAltaMapping()
		{
			CreateMap<EntDetalleSolicitud, EntDetalleAltaInmuebleResponse>()
				.ForMember(dest => dest.IdSolicitud, opt => opt.MapFrom(src => src.iIdSolicitud))
				.ForMember(dest => dest.ReferenciaConac, opt => opt.MapFrom(src => src.DetalleAlta.sReferenciaConac))
				.ForMember(dest => dest.IdFamilia, opt => opt.MapFrom(src => src.DetalleAlta.iIdFamilia))
				.ForMember(dest => dest.IdSubfamilia, opt => opt.MapFrom(src => src.DetalleAlta.iIdSubfamilia))
				.ForMember(dest => dest.IdMunicipio, opt => opt.MapFrom(src => src.DetalleAlta.iIdMunicipio))
				.ForMember(dest => dest.ValorHistorico, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.dValorHistorico))
				.ForMember(dest => dest.ValorLibros, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.dValorLibros))
				.ForMember(dest => dest.Depreciacion, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.dDepreciacion))
				.ForMember(dest => dest.AniosVida, opt => opt.MapFrom(src => src.DetalleAlta.iAniosVida))
				.ForMember(dest => dest.Nomenclatura, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.sNomenclatura))
				.ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.DetalleAlta.sDescripcion))
				.ForMember(dest => dest.IdTipoInmueble, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.iIdTipoInmueble))
				.ForMember(dest => dest.IdUsoInmueble, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.iIdUsoInmueble))
				.ForMember(dest => dest.IdTipoDominio, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.iIdTipoDomninio))
				.ForMember(dest => dest.IdTipoAfectacion, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.iIdTipoAfectacion))
				.ForMember(dest => dest.Afectante, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.sAfectante))
				.ForMember(dest => dest.IdTipoAdquisicion, opt => opt.MapFrom(src => src.DetalleAlta.iIdTipoAdquisicion))
				.ForMember(dest => dest.IdEstadoFisico, opt => opt.MapFrom(src => src.DetalleAlta.iIdEstadoFisico))
				.ForMember(dest => dest.FechaAdquisicion, opt => opt.MapFrom(src => src.DetalleAlta.dtFechaAdquisicion))
				.ForMember(dest => dest.FechaAltaSistema, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.dtFechaAltaSistema))
				.ForMember(dest => dest.FolioCatastro, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.DatosRegistral.iFolioCatastro))
				.ForMember(dest => dest.Calle, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.DatosRegistral.sCalle))
				.ForMember(dest => dest.Superficie, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.DatosRegistral.dSuperficie))
				.ForMember(dest => dest.ValorTerreno, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.DatosRegistral.dValorTerreno))
				.ForMember(dest => dest.NumeroExterior, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.DatosRegistral.sNumeroExterior))
				.ForMember(dest => dest.NumeroInterior, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.DatosRegistral.sNumeroInterior))
				.ForMember(dest => dest.Cruzamiento1, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.DatosRegistral.sCruzamimiento1))
				.ForMember(dest => dest.Cruzamiento2, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.DatosRegistral.sCruzamimiento2))
				.ForMember(dest => dest.SuperficieConstruccion, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.DatosRegistral.dSuperficieContruccion))
				.ForMember(dest => dest.Tablaje, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.DatosRegistral.sTablaje))
				.ForMember(dest => dest.ValorConstruccion, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.DatosRegistral.dValorConstruccion))
				.ForMember(dest => dest.ValorInicial, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.DatosRegistral.dValorInicial))
				.ForMember(dest => dest.CodigoPostal, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.DatosRegistral.nCodigoPostal))
				.ForMember(dest => dest.IdOrigenValor, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.DatosRegistral.iIdOrigenValor))
				.ForMember(dest => dest.Asentamiento, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.DatosRegistral.sAsentamiento))
				.ForMember(dest => dest.Propietario, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.DatosRegistral.sPropietario))
				.ForMember(dest => dest.ObservacionInmueble, opt => opt.MapFrom(src => src.DetalleAlta.sObservacionBien))
				.ForMember(dest => dest.ObservacionSupervicion, opt => opt.MapFrom(src => src.DetalleAlta.sObservacionResponsable))
				.ForMember(dest => dest.DecretoPublicaicion, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.sPublicacion))
				.ForMember(dest => dest.EscrituraTitulo, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.sEscrituraTitulo))
				.ForMember(dest => dest.Expediente, opt => opt.MapFrom(src => src.DetalleAlta.DatosInmueble.sExpediente));

			CreateMap<EntDetalleAltaInmuebleRequest, EntDetalleSolicitud>()
	.ForMember(dest => dest.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
	.ForMember(dest => dest.iIdEtapa, opt => opt.MapFrom(src => (long)EnumEtapa.CapturaInicial))
	.ForPath(dest => dest.DetalleAlta.iIdTipoBien, opt => opt.MapFrom(src => (long)EnumTipoBien.Inmueble))
	.ForPath(dest => dest.DetalleAlta.sReferenciaConac, opt => opt.MapFrom(src => src.ReferenciaConac))

	.ForPath(dest => dest.DetalleAlta.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
	.ForPath(dest => dest.DetalleAlta.iIdFamilia, opt => opt.MapFrom(src => src.IdFamilia))
	.ForPath(dest => dest.DetalleAlta.iIdMunicipio, opt => opt.MapFrom(src => src.IdMunicipio))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.dValorHistorico, opt => opt.MapFrom(src => src.ValorHistorico))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.dValorLibros, opt => opt.MapFrom(src => src.ValorLibros))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.dDepreciacion, opt => opt.MapFrom(src => src.Depreciacion))
	.ForPath(dest => dest.DetalleAlta.dPrecioUnitario, opt => opt.MapFrom(src => src.ValorConstruccion + src.ValorTerreno))

	.ForPath(dest => dest.DetalleAlta.iAniosVida, opt => opt.MapFrom(src => src.AniosVida))
	.ForPath(dest => dest.DetalleAlta.iIdEstadoFisico, opt => opt.MapFrom(src => src.IdEstadoFisico))

	.ForPath(dest => dest.DetalleAlta.iIdSubfamilia, opt => opt.MapFrom(src => src.IdSubfamilia))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.sNomenclatura, opt => opt.MapFrom(src => src.Nomenclatura))
	.ForPath(dest => dest.DetalleAlta.sDescripcion, opt => opt.MapFrom(src => src.Descripcion))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.iIdTipoInmueble, opt => opt.MapFrom(src => src.IdTipoInmueble))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.iIdUsoInmueble, opt => opt.MapFrom(src => src.IdUsoInmueble))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.iIdTipoDomninio, opt => opt.MapFrom(src => src.IdTipoDominio))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.iIdTipoAfectacion, opt => opt.MapFrom(src => src.IdTipoAfectacion))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.sAfectante, opt => opt.MapFrom(src => src.Afectante))
	.ForPath(dest => dest.DetalleAlta.iIdTipoAdquisicion, opt => opt.MapFrom(src => src.IdTipoAdquisicion))

	.ForPath(dest => dest.DetalleAlta.dtFechaAdquisicion, opt => opt.MapFrom(src => src.FechaAdquisicion))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.dtFechaAltaSistema, opt => opt.MapFrom(src => src.FechaAltaSistema))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.DatosRegistral.iFolioCatastro, opt => opt.MapFrom(src => src.FolioCatastro))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.DatosRegistral.sCalle, opt => opt.MapFrom(src => src.Calle))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.DatosRegistral.dSuperficie, opt => opt.MapFrom(src => src.Superficie))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.DatosRegistral.dValorTerreno, opt => opt.MapFrom(src => src.ValorTerreno))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.DatosRegistral.sNumeroExterior, opt => opt.MapFrom(src => src.NumeroExterior))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.DatosRegistral.sNumeroInterior, opt => opt.MapFrom(src => src.NumeroInterior))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.DatosRegistral.sCruzamimiento1, opt => opt.MapFrom(src => src.Cruzamiento1))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.DatosRegistral.sCruzamimiento2, opt => opt.MapFrom(src => src.Cruzamiento2))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.DatosRegistral.dSuperficieContruccion, opt => opt.MapFrom(src => src.SuperficieConstruccion))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.DatosRegistral.sTablaje, opt => opt.MapFrom(src => src.Tablaje))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.DatosRegistral.dValorConstruccion, opt => opt.MapFrom(src => src.ValorConstruccion))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.DatosRegistral.dValorInicial, opt => opt.MapFrom(src => src.ValorConstruccion + src.ValorTerreno))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.DatosRegistral.nCodigoPostal, opt => opt.MapFrom(src => src.CodigoPostal))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.DatosRegistral.iIdOrigenValor, opt => opt.MapFrom(src => src.IdOrigenValor))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.DatosRegistral.sAsentamiento, opt => opt.MapFrom(src => src.Asentamiento))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.DatosRegistral.sPropietario, opt => opt.MapFrom(src => src.Propietario))
	.ForPath(dest => dest.DetalleAlta.sObservacionBien, opt => opt.MapFrom(src => src.ObservacionInmueble))
	.ForPath(dest => dest.DetalleAlta.sObservacionResponsable, opt => opt.MapFrom(src => src.ObservacionSupervicion))

	.ForPath(dest => dest.DetalleAlta.DatosInmueble.sPublicacion, opt => opt.MapFrom(src => src.DecretoPublicaicion))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.sExpediente, opt => opt.MapFrom(src => src.Expediente))
	.ForPath(dest => dest.DetalleAlta.DatosInmueble.sEscrituraTitulo, opt => opt.MapFrom(src => src.EscrituraTitulo));

		}
	}
}
