using AutoMapper;
using ControlBienes.Entities.Catalogos.ClaseVehicular;

namespace ControlBienes.Business.Features.Catalogos.ClaseVehicular
{
    public class BusClaseVehicularMapping : Profile
    {

        public BusClaseVehicularMapping()
        {
            CreateMap<EntClaseVehicular, EntClaseVehicularResponse>()
                .ForMember(dest => dest.IdClaseVehicular, opt => opt.MapFrom(src => src.iIdClaseVehicular))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
                .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
                .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntClaseVehicularRequest, EntClaseVehicular>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.sDescripcion, opt => opt.MapFrom(src => src.Descripcion));
        }
    }
}
