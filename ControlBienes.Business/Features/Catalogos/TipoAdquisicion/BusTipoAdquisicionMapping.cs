using AutoMapper;
using ControlBienes.Entities.Catalogos.TipoAdquisicion;

namespace ControlBienes.Business.Features.Catalogos.TipoAdquisicion
{
    public class BusTipoAdquisicionMapping : Profile
    {
        public BusTipoAdquisicionMapping()
        {
            CreateMap<EntTipoAdquisicion, EntTipoAdquisicionResponse>()
                .ForMember(dest => dest.IdTipoAdquisicion, opt => opt.MapFrom(src => src.iIdTipoAdquisicion))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
                .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
                .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntTipoAdquisicionRequest, EntTipoAdquisicion>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre));
        }
    }
}
