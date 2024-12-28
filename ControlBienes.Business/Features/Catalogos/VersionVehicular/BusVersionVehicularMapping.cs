using AutoMapper;
using ControlBienes.Entities.Catalogos.VersionVehicular;

namespace ControlBienes.Business.Features.Catalogos.VersionVehicular
{
    public class BusVersionVehicularMapping : Profile
    {
        public BusVersionVehicularMapping()
        {
            CreateMap<EntVersionVehicular, EntVersionVehicularResponse>()
                .ForMember(dest => dest.IdVersionVehicular, opt => opt.MapFrom(src => src.iIdVersionVehicular))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
                .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
                .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntVersionVehicularRequest, EntVersionVehicular>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.sDescripcion, opt => opt.MapFrom(src => src.Descripcion));
        }
    }
}
