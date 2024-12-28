using AutoMapper;
using ControlBienes.Entities.Catalogos.Familia;

namespace ControlBienes.Business.Features.Catalogos.Familia
{
    public class BusFamiliaMapping : Profile
    {
        public BusFamiliaMapping()
        {
            CreateMap<EntFamilia, EntFamiliaResponse>()
               .ForMember(dest => dest.IdFamilia, opt => opt.MapFrom(src => src.iIdFamilia))
               .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
               .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
               .ForMember(dest => dest.NumeroCuenta, opt => opt.MapFrom(src => src.iNumeroCuenta))
               .ForMember(dest => dest.IdTipoBien, opt => opt.MapFrom(src => src.TipoBien!.iIdTipoBien))
               .ForMember(dest => dest.TipoBien, opt => opt.MapFrom(src => src.TipoBien!.sNombre))
               .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
               .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
               .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntFamiliaRequest, EntFamilia>()
               .ForMember(dest => dest.iIdFamilia, opt => opt.MapFrom(src => src.IdFamilia))
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.sDescripcion, opt => opt.MapFrom(src => src.Descripcion))
               .ForMember(dest => dest.iIdTipoBien, opt => opt.MapFrom(src => src.IdTipoBien));
        }
    }
}
