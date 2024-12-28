using AutoMapper;
using ControlBienes.Entities.Catalogos.TipoBien;

namespace ControlBienes.Business.Features.Catalogos.TipoBien
{
    public class BusTipoBienMapping : Profile
    {

        public BusTipoBienMapping()
        {
            CreateMap<EntTipoBien, EntTipoBienResponse>()
                .ForMember(dest => dest.IdTipoBien, opt => opt.MapFrom(src => src.iIdTipoBien))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
                .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
                .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));


            CreateMap<EntTipoBienRequest, EntTipoBien>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre));
        }

    }
}
