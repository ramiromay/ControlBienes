using AutoMapper;
using ControlBienes.Entities.Catalogos.TipoAfectacion;

namespace ControlBienes.Business.Features.Catalogos.TipoAfectacion
{
    public class BusTipoAfectacionMapping : Profile
    {
        public BusTipoAfectacionMapping()
        {
            CreateMap<EntTipoAfectacion, EntTipoAfectacionResponse>()
                .ForMember(dest => dest.IdTipoAfectacion, opt => opt.MapFrom(src => src.iIdTipoAfectacion))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
                .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
                .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntTipoAfectacionRequest, EntTipoAfectacion>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre));
        }
    }
}
