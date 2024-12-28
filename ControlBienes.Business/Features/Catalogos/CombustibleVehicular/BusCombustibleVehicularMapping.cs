using AutoMapper;
using ControlBienes.Entities.Catalogos.CombustibleVehicular;

namespace ControlBienes.Business.Features.Catalogos.CombustibleVehicular
{
    public class BusCombustibleVehicularMapping : Profile
    {
        public BusCombustibleVehicularMapping()
        {
            CreateMap<EntCombustibleVehicular, EntCombustibleVehicularResponse>()
              .ForMember(dest => dest.IdCombustibleVehicular, opt => opt.MapFrom(src => src.iIdCombustibleVehicular))
              .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
              .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
              .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
              .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
              .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntCombustibleVehicularRequest, EntCombustibleVehicular>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.sDescripcion, opt => opt.MapFrom(src => src.Descripcion));
        }
    }
}
