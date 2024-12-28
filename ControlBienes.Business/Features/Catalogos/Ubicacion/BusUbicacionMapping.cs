using AutoMapper;
using ControlBienes.Entities.Catalogos.Ubicacion;

namespace ControlBienes.Business.Features.Catalogos.Ubicacion
{
    public class BusUbicacionMapping : Profile
    {
        public BusUbicacionMapping()
        {
            CreateMap<EntUbicacion, EntUbicacionResponse>()
               .ForMember(dest => dest.IdUbicacion, opt => opt.MapFrom(src => src.iIdUbicacion))
               .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
               .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
               .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
               .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntUbicacionRequest, EntUbicacion>()
               .ForMember(dest => dest.sDescripcion, opt => opt.MapFrom(src => src.Descripcion));
        }
    }
}
