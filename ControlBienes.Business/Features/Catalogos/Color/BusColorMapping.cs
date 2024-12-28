using AutoMapper;
using ControlBienes.Entities.Catalogos.Color;

namespace ControlBienes.Business.Features.Catalogos.Color
{
    public class BusColorMapping : Profile
    {
        public BusColorMapping()
        {
            CreateMap<EntColor, EntColorResponse>()
                .ForMember(dest => dest.IdColor, opt => opt.MapFrom(src => src.iIdColor))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
                .ForMember(dest => dest.CodigoRGB, opt => opt.MapFrom(src => src.sCodigoRGB))
                .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
                .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntColorRequest, EntColor>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.sCodigoRGB, opt => opt.MapFrom(src => src.CodigoRGB));
        }
    }
}
