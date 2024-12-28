using AutoMapper;
using ControlBienes.Entities.Catalogos.EstadoFisico;

namespace ControlBienes.Business.Features.Catalogos.EstadoFisico
{
    public class BusEstadoFisicoMapping : Profile
    {
        public BusEstadoFisicoMapping()
        {
            CreateMap<EntEstadoFisico, EntEstadoFisicoResponse>()
               .ForMember(dest => dest.IdEstadoFisico, opt => opt.MapFrom(src => src.iIdEstadoFisico))
               .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
               .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
               .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
               .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
               .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntEstadoFisicoRequest, EntEstadoFisico>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.sDescripcion, opt => opt.MapFrom(src => src.Descripcion));
        }

    }
}
