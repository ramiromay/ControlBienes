using AutoMapper;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Patrimonio.DetalleBaja;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Etapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteInmueble.Baja
{
	public class BusTramiteInmuebleBajaMapping : Profile
	{
		public BusTramiteInmuebleBajaMapping()
		{
			CreateMap<EntDetalleBajaInmuebleRequest, EntDetalleSolicitud>()
				.ForMember(dest => dest.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
				.ForMember(dest => dest.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))

				.ForPath(dest => dest.DetalleBaja.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
				.ForPath(dest => dest.DetalleBaja.Baja.sFolioBien, opt => opt.MapFrom(src => src.FolioBien))
				.ForPath(dest => dest.DetalleBaja.Baja.iIdTipoBien, opt => opt.MapFrom(src => (long)EnumTipoBien.Inmueble))
				.ForPath(dest => dest.iIdEtapa, opt => opt.MapFrom(src => (long)EnumEtapa.CapturaInicial))
				.ForPath(dest => dest.DetalleBaja.BajaInmueble.iIdBien, opt => opt.MapFrom(src => src.IdBienPatrimonio))
				.ForPath(dest => dest.DetalleBaja.BajaInmueble.dtFechaDesincorporacion, opt => opt.MapFrom(src => src.FechaDesincorporacion))
				.ForPath(dest => dest.DetalleBaja.BajaInmueble.dtFechaBaja, opt => opt.MapFrom(src => src.FechaBaja))
				.ForPath(dest => dest.DetalleBaja.BajaInmueble.dtFechaBajaSistema, opt => opt.MapFrom(src => src.FechaBajaSistema))
				.ForPath(dest => dest.DetalleBaja.BajaInmueble.dValorBaja, opt => opt.MapFrom(src => src.ValorBaja))
				.ForPath(dest => dest.DetalleBaja.BajaInmueble.sAfavorDe, opt => opt.MapFrom(src => src.AFavor))
				.ForPath(dest => dest.DetalleBaja.BajaInmueble.sDestinoBien, opt => opt.MapFrom(src => src.DestinoBien))
				.ForPath(dest => dest.DetalleBaja.BajaInmueble.sJustificacion, opt => opt.MapFrom(src => src.JustificacionBaja))
				.ForPath(dest => dest.DetalleBaja.BajaInmueble.sEscrituraTitulo, opt => opt.MapFrom(src => src.EscrituraTitulo));


			CreateMap<EntDetalleSolicitud, EntDetalleBajaInmuebleResponse>()
	.ForMember(dest => dest.IdSolicitud, opt => opt.MapFrom(src => src.iIdSolicitud))
	.ForMember(dest => dest.FolioBien, opt => opt.MapFrom(src => src.DetalleBaja.Baja.sFolioBien))
	.ForMember(dest => dest.IdBienPatrimonio, opt => opt.MapFrom(src => src.DetalleBaja.BajaInmueble.iIdBien))
	.ForMember(dest => dest.FechaDesincorporacion, opt => opt.MapFrom(src => src.DetalleBaja.BajaInmueble.dtFechaDesincorporacion))
	.ForMember(dest => dest.FechaBaja, opt => opt.MapFrom(src => src.DetalleBaja.BajaInmueble.dtFechaBaja))
	.ForMember(dest => dest.FechaBajaSistema, opt => opt.MapFrom(src => src.DetalleBaja.BajaInmueble.dtFechaBajaSistema))
	.ForMember(dest => dest.ValorBaja, opt => opt.MapFrom(src => src.DetalleBaja.BajaInmueble.dValorBaja))
	.ForMember(dest => dest.AFavor, opt => opt.MapFrom(src => src.DetalleBaja.BajaInmueble.sAfavorDe))
	.ForMember(dest => dest.JustificacionBaja, opt => opt.MapFrom(src => src.DetalleBaja.BajaInmueble.sJustificacion))
	.ForMember(dest => dest.DestinoBien, opt => opt.MapFrom(src => src.DetalleBaja.BajaInmueble.sDestinoBien))
	.ForMember(dest => dest.EscrituraTitulo, opt => opt.MapFrom(src => src.DetalleBaja.BajaInmueble.sEscrituraTitulo));


		}
	}
}
