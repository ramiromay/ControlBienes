using AutoMapper;
using ControlBienes.Entities.Catalogos.LineaVehicular;

namespace ControlBienes.Business.Features.Catalogos.LineaVehicular
{
    public class BusTipoBienMapping : Profile
    {

        public BusTipoBienMapping()
        {

            CreateMap<EntLineaVehicular, EntLineaVehicularResponse>()
                .ForMember(dest => dest.IdLineaVehicular, opt => opt.MapFrom(src => src.iIdLineaVehicular))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
                .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
                .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));


            CreateMap<EntLineaVehicularRequest, EntLineaVehicular>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.sDescripcion, opt => opt.MapFrom(src => src.Descripcion));
        }

    }
}
