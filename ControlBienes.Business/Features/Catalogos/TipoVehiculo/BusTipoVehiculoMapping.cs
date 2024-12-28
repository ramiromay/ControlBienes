using AutoMapper;
using ControlBienes.Entities.Catalogos.TipoVehicular;

namespace ControlBienes.Business.Features.Catalogos.TipoVehiculo
{
    public class BusTipoVehiculoMapping : Profile
    {
        public BusTipoVehiculoMapping()
        {
            CreateMap<EntTipoVehicular, EntTipoVehiculoResponse>()
               .ForMember(dest => dest.IdTipoVehicular, opt => opt.MapFrom(src => src.iIdTipoVehicular))
               .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
               .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
               .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
               .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
               .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntTipoVehiculoRequest, EntTipoVehicular>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.sDescripcion, opt => opt.MapFrom(src => src.Descripcion));
        }
    }
}
