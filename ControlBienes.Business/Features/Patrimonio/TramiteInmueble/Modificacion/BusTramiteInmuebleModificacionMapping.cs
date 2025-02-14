using AutoMapper;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Patrimonio.DetalleModificacion;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Etapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteInmueble.Baja.Modificacion
{
	public class BusTramiteInmuebleModificacionMapping : Profile
	{
		public BusTramiteInmuebleModificacionMapping()
		{
			CreateMap<EntDetalleSolicitud, EntDetalleModificacionInmuebleResponse>()
				.ForMember(dest => dest.IdSolicitud, opt => opt.MapFrom(src => src.iIdSolicitud))
				.ForMember(dest => dest.IdBienPatrimonio, opt => opt.MapFrom(src => src.DetalleModificacion.iIdBien))
				.ForMember(dest => dest.ReferenciaConac, opt => opt.MapFrom(src => src.DetalleModificacion.sReferenciaConac))
				.ForMember(dest => dest.IdFamilia, opt => opt.MapFrom(src => src.DetalleModificacion.iIdFamilia))
				.ForMember(dest => dest.IdSubfamilia, opt => opt.MapFrom(src => src.DetalleModificacion.iIdSubfamilia))
				.ForMember(dest => dest.IdMunicipio, opt => opt.MapFrom(src => src.DetalleModificacion.iIdMunicipio))
				.ForMember(dest => dest.ValorHistorico, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.dValorHistorico))
				.ForMember(dest => dest.Depreciacion, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.dDepreciacion))
				.ForMember(dest => dest.ValorLibros, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.dValorLibros))

				.ForMember(dest => dest.AniosVida, opt => opt.MapFrom(src => src.DetalleModificacion.iAniosVida))
				.ForMember(dest => dest.Nomenclatura, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.sNomenclatura))
				.ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.DetalleModificacion.sDescripcion))
				.ForMember(dest => dest.IdTipoInmueble, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.iIdTipoInmueble))
				.ForMember(dest => dest.IdUsoInmueble, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.iIdUsoInmueble))
				.ForMember(dest => dest.IdTipoDominio, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.iIdTipoDomninio))
				.ForMember(dest => dest.IdTipoAfectacion, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.iIdTipoAfectacion))
				.ForMember(dest => dest.Afectante, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.sAfectante))
				.ForMember(dest => dest.IdTipoAdquisicion, opt => opt.MapFrom(src => src.DetalleModificacion.iIdTipoAdquisicion))
				.ForMember(dest => dest.IdEstadoFisico, opt => opt.MapFrom(src => src.DetalleModificacion.iIdEstadoFisico))
				.ForMember(dest => dest.FechaAdquisicion, opt => opt.MapFrom(src => src.DetalleModificacion.dtFechaAdquisicion))
				.ForMember(dest => dest.FechaAltaSistema, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.dtFechaAltaSistema))
				.ForMember(dest => dest.FolioCatastro, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.DatosRegistral.iFolioCatastro))
				.ForMember(dest => dest.Calle, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.DatosRegistral.sCalle))
				.ForMember(dest => dest.Superficie, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.DatosRegistral.dSuperficie))
				.ForMember(dest => dest.ValorTerreno, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.DatosRegistral.dValorTerreno))
				.ForMember(dest => dest.NumeroExterior, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.DatosRegistral.sNumeroExterior))
				.ForMember(dest => dest.NumeroInterior, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.DatosRegistral.sNumeroInterior))
				.ForMember(dest => dest.Cruzamiento1, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.DatosRegistral.sCruzamimiento1))
				.ForMember(dest => dest.Cruzamiento2, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.DatosRegistral.sCruzamimiento2))
				.ForMember(dest => dest.SuperficieConstruccion, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.DatosRegistral.dSuperficieContruccion))
				.ForMember(dest => dest.Tablaje, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.DatosRegistral.sTablaje))
				.ForMember(dest => dest.ValorConstruccion, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.DatosRegistral.dValorConstruccion))
				.ForMember(dest => dest.ValorInicial, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.DatosRegistral.dValorInicial))
				.ForMember(dest => dest.CodigoPostal, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.DatosRegistral.nCodigoPostal))
				.ForMember(dest => dest.IdOrigenValor, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.DatosRegistral.iIdOrigenValor))
				.ForMember(dest => dest.Asentamiento, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.DatosRegistral.sAsentamiento))
				.ForMember(dest => dest.Propietario, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.DatosRegistral.sPropietario))
				.ForMember(dest => dest.ObservacionInmueble, opt => opt.MapFrom(src => src.DetalleModificacion.sObservacionBien))
				.ForMember(dest => dest.ObservacionSupervicion, opt => opt.MapFrom(src => src.DetalleModificacion.sObservacionResponsable))
				.ForMember(dest => dest.DecretoPublicaicion, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.sPublicacion))
				.ForMember(dest => dest.EscrituraTitulo, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.sEscrituraTitulo))
				.ForMember(dest => dest.Expediente, opt => opt.MapFrom(src => src.DetalleModificacion.DatoInmueble.sExpediente));

			CreateMap<EntDetalleModificacionInmuebleRequest, EntDetalleSolicitud>()
	.ForMember(dest => dest.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
	.ForPath(dest => dest.DetalleModificacion.iIdBien, opt => opt.MapFrom(src => src.IdBienPatrimonio))
	.ForMember(dest => dest.iIdEtapa, opt => opt.MapFrom(src => (long)EnumEtapa.CapturaInicial))
	.ForPath(dest => dest.DetalleModificacion.iIdTipoBien, opt => opt.MapFrom(src => (long)EnumTipoBien.Inmueble))
	.ForPath(dest => dest.DetalleModificacion.sReferenciaConac, opt => opt.MapFrom(src => src.ReferenciaConac))

	.ForPath(dest => dest.DetalleModificacion.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
	.ForPath(dest => dest.DetalleModificacion.iIdFamilia, opt => opt.MapFrom(src => src.IdFamilia))
	.ForPath(dest => dest.DetalleModificacion.iIdMunicipio, opt => opt.MapFrom(src => src.IdMunicipio))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.dValorHistorico, opt => opt.MapFrom(src => src.ValorHistorico))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.dDepreciacion, opt => opt.MapFrom(src => src.Depreciacion))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.dValorLibros, opt => opt.MapFrom(src => src.ValorLibros))
	.ForPath(dest => dest.DetalleModificacion.iAniosVida, opt => opt.MapFrom(src => src.AniosVida))
	.ForPath(dest => dest.DetalleModificacion.iIdEstadoFisico, opt => opt.MapFrom(src => src.IdEstadoFisico))

	.ForPath(dest => dest.DetalleModificacion.iIdSubfamilia, opt => opt.MapFrom(src => src.IdSubfamilia))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.sNomenclatura, opt => opt.MapFrom(src => src.Nomenclatura))
	.ForPath(dest => dest.DetalleModificacion.sDescripcion, opt => opt.MapFrom(src => src.Descripcion))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.iIdTipoInmueble, opt => opt.MapFrom(src => src.IdTipoInmueble))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.iIdUsoInmueble, opt => opt.MapFrom(src => src.IdUsoInmueble))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.iIdTipoDomninio, opt => opt.MapFrom(src => src.IdTipoDominio))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.iIdTipoAfectacion, opt => opt.MapFrom(src => src.IdTipoAfectacion))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.sAfectante, opt => opt.MapFrom(src => src.Afectante))
	.ForPath(dest => dest.DetalleModificacion.iIdTipoAdquisicion, opt => opt.MapFrom(src => src.IdTipoAdquisicion))

	.ForPath(dest => dest.DetalleModificacion.dtFechaAdquisicion, opt => opt.MapFrom(src => src.FechaAdquisicion))

	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.dtFechaAltaSistema, opt => opt.MapFrom(src => src.FechaAltaSistema))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.DatosRegistral.iFolioCatastro, opt => opt.MapFrom(src => src.FolioCatastro))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.DatosRegistral.sCalle, opt => opt.MapFrom(src => src.Calle))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.DatosRegistral.dSuperficie, opt => opt.MapFrom(src => src.Superficie))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.DatosRegistral.dValorTerreno, opt => opt.MapFrom(src => src.ValorTerreno))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.DatosRegistral.sNumeroExterior, opt => opt.MapFrom(src => src.NumeroExterior))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.DatosRegistral.sNumeroInterior, opt => opt.MapFrom(src => src.NumeroInterior))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.DatosRegistral.sCruzamimiento1, opt => opt.MapFrom(src => src.Cruzamiento1))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.DatosRegistral.sCruzamimiento2, opt => opt.MapFrom(src => src.Cruzamiento2))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.DatosRegistral.dSuperficieContruccion, opt => opt.MapFrom(src => src.SuperficieConstruccion))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.DatosRegistral.sTablaje, opt => opt.MapFrom(src => src.Tablaje))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.DatosRegistral.dValorConstruccion, opt => opt.MapFrom(src => src.ValorConstruccion))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.DatosRegistral.dValorInicial, opt => opt.MapFrom(src => src.ValorTerreno + src.ValorConstruccion))
	.ForPath(dest => dest.DetalleModificacion.dPrecioUnitario, opt => opt.MapFrom(src => src.ValorTerreno + src.ValorConstruccion))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.DatosRegistral.nCodigoPostal, opt => opt.MapFrom(src => src.CodigoPostal))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.DatosRegistral.iIdOrigenValor, opt => opt.MapFrom(src => src.IdOrigenValor))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.DatosRegistral.sAsentamiento, opt => opt.MapFrom(src => src.Asentamiento))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.DatosRegistral.sPropietario, opt => opt.MapFrom(src => src.Propietario))
	.ForPath(dest => dest.DetalleModificacion.sObservacionBien, opt => opt.MapFrom(src => src.ObservacionInmueble))
	.ForPath(dest => dest.DetalleModificacion.sObservacionResponsable, opt => opt.MapFrom(src => src.ObservacionSupervicion))

	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.sPublicacion, opt => opt.MapFrom(src => src.DecretoPublicaicion))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.sExpediente, opt => opt.MapFrom(src => src.Expediente))
	.ForPath(dest => dest.DetalleModificacion.DatoInmueble.sEscrituraTitulo, opt => opt.MapFrom(src => src.EscrituraTitulo));
		}
	}
}
