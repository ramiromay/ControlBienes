using AutoMapper;
using ControlBienes.Entities.Catalogos.ClaveVehicular;

namespace ControlBienes.Business.Features.Catalogos.ClaveVehicular
{
    public class BusClaveVehicularMapping : Profile
    {
        public BusClaveVehicularMapping()
        {
            CreateMap<EntClaveVehicular, EntClaveVehicularResponse>()
               .ForMember(dest => dest.IdClaveVehicular, opt => opt.MapFrom(src => src.iIdClaveVehicular))
               .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
               .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
               .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
               .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
               .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntClaveVehicularRequest, EntClaveVehicular>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.sDescripcion, opt => opt.MapFrom(src => src.Descripcion));
        }
    }
}
