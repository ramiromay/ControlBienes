using AutoMapper;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Patrimonio.Desincorporacion;
using ControlBienes.Entities.Patrimonio.DetalleDesincorporacion;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Etapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteMueble.Desincorporacion
{
	public class BusTramiteMuebleDesincorporacionMapping : Profile
	{
		public BusTramiteMuebleDesincorporacionMapping()
		{
			CreateMap<EntDetalleSolicitud, EntDetalleDesincorporacionMuebleResponse>()
		  .ForMember(dest => dest.IdSolicitud, opt => opt.MapFrom(src => src.iIdSolicitud))
		  .ForMember(dest => dest.NivelUnidadAdministrativa, opt => opt.MapFrom(src => src.DetalleDesincorporacion.UnidadAdministrativa.sNivelCompleto))
		  .ForMember(dest => dest.IdEmpleado, opt => opt.MapFrom(src => (long?)src.DetalleDesincorporacion.iIdEmpleado))
		  .ForMember(dest => dest.FolioBien, opt => opt.MapFrom(src => src.DetalleDesincorporacion.sFolioBien))
		  .ForMember(dest => dest.Observaciones, opt => opt.MapFrom(src => src.DetalleDesincorporacion.sObservaciones))
		  .ForMember(dest => dest.FechaPublicacion, opt => opt.MapFrom(src => src.DetalleDesincorporacion.dtFechaPublicacion))
		  .ForMember(dest => dest.NumeroPublicacion, opt => opt.MapFrom(src => src.DetalleDesincorporacion.sNumeroPublicacion))
		  .ForMember(dest => dest.DescripcionDesincorporacion, opt => opt.MapFrom(src => src.DetalleDesincorporacion.sDescripcionDesincorporacion));

			CreateMap<EntDetalleDesincorporacionMuebleRequest, EntDetalleSolicitud>()
		  .ForMember(dest => dest.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
		  .ForMember(dest => dest.iIdEtapa, opt => opt.MapFrom(src => (long)EnumEtapa.CapturaInicial))
		  .ForPath(dest => dest.DetalleDesincorporacion.iIdTipoBien, opt => opt.MapFrom(src => (long)EnumTipoBien.Mueble))
		  .ForPath(dest => dest.DetalleDesincorporacion.sFolioBien, opt => opt.MapFrom(src => src.FolioBien))
		  .ForPath(dest => dest.DetalleDesincorporacion.sObservaciones, opt => opt.MapFrom(src => src.Observaciones))
		  .ForPath(dest => dest.DetalleDesincorporacion.dtFechaPublicacion, opt => opt.MapFrom(src => src.FechaPublicacion)) 
		  .ForPath(dest => dest.DetalleDesincorporacion.sNumeroPublicacion, opt => opt.MapFrom(src => src.NumeroPublicacion))
		  .ForPath(dest => dest.DetalleDesincorporacion.sDescripcionDesincorporacion, opt => opt.MapFrom(src => src.DescripcionDesincorporacion));
		}
	}
}
