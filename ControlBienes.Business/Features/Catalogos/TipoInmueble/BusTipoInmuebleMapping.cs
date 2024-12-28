using AutoMapper;
using ControlBienes.Entities.Catalogos.TipoInmueble;

namespace ControlBienes.Business.Features.Catalogos.TipoInmueble
{
    public class BusTipoInmuebleMapping : Profile
    {
        public BusTipoInmuebleMapping()
        {
            CreateMap<EntTipoInmueble, EntTipoInmuebleResponse>()
               .ForMember(dest => dest.IdTipoInmueble, opt => opt.MapFrom(src => src.iIdTipoInmueble))
               .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
               .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
               .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
               .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
               .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntTipoInmuebleRequest, EntTipoInmueble>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.sDescripcion, opt => opt.MapFrom(src => src.Descripcion));
        }
    }
}
