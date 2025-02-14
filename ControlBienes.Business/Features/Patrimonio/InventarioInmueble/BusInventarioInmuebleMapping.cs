using AutoMapper;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.DetalleAlta;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.InventarioInmueble
{
	public class BusInventarioInmuebleMapping : Profile
	{
		public BusInventarioInmuebleMapping()
		{
			CreateMap<EntBienPatrimonio, EntBienInmuebleResponse>()
				.ForMember(dest => dest.IdBien, opt => opt.MapFrom(src => src.iIdBien))
				.ForMember(dest => dest.IdMotivoTramite, opt => opt.MapFrom(src => src.Solicitud.iIdMotivoTramite))
				.ForMember(dest => dest.FolioBien, opt => opt.MapFrom(src => src.sFolioBien))
				.ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
				.ForMember(dest => dest.UnidadAdministrativa, opt => opt.MapFrom(src => $"{src.UnidadAdministrativa.sNivelCompleto} {src.UnidadAdministrativa.sNombre}"))
				.ForMember(dest => dest.Familia, opt => opt.MapFrom(src => $"{src.Familia.iIdFamilia} {src.Familia.sNombre}"))
				.ForMember(dest => dest.Subfamilia, opt => opt.MapFrom(src => $"{src.Subfamilia.iIdSubfamilia} {src.Subfamilia.sNombre}"))
				.ForMember(dest => dest.TipoBien, opt => opt.MapFrom(src => $"{src.TipoBien.iIdTipoBien} {src.TipoBien.sNombre}"))
				.ForMember(dest => dest.FechaAlta, opt => opt.MapFrom(src => src.dtFechaAlta))
				.ForMember(dest => dest.FechaBaja, opt => opt.MapFrom(src => src.dtFechaBaja))
				.ForMember(dest => dest.MotivoBaja, opt => opt.MapFrom(src => src.sMotivoBaja))
				.ForMember(dest => dest.ReferenciaConac, opt => opt.MapFrom(src => src.sReferenciaConac))
				.ForMember(dest => dest.IdFamilia, opt => opt.MapFrom(src => src.iIdFamilia))
				.ForMember(dest => dest.IdSubfamilia, opt => opt.MapFrom(src => src.iIdSubfamilia))
				.ForMember(dest => dest.IdMunicipio, opt => opt.MapFrom(src => src.iIdMunicipio))
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
				.ForMember(dest => dest.ObservacionInmueble, opt => opt.MapFrom(src => src.sObservacionBien))
				.ForMember(dest => dest.ObservacionSupervicion, opt => opt.MapFrom(src => src.sObservacionResponsable))
				.ForMember(dest => dest.DecretoPublicaicion, opt => opt.MapFrom(src => src.DatoInmueble.sPublicacion))
				.ForMember(dest => dest.EscrituraTitulo, opt => opt.MapFrom(src => src.DatoInmueble.sEscrituraTitulo))
				.ForMember(dest => dest.Expediente, opt => opt.MapFrom(src => src.DatoInmueble.sExpediente));
		}
	}
}
