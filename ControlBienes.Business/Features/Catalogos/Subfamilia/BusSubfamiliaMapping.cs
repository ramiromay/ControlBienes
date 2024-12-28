using AutoMapper;
using ControlBienes.Entities.Catalogos.Subfamilia;

namespace ControlBienes.Business.Features.Catalogos.Subfamilia
{
    public class BusSubfamiliaMapping : Profile
    {
        public BusSubfamiliaMapping()
        {
            CreateMap<EntSubfamilia, EntSubfamiliaResponse>()
                 .ForMember(dest => dest.IdSubfamilia, opt => opt.MapFrom(src => src.iIdSubfamilia))
                 .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
                 .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
                 .ForMember(dest => dest.NumeroCuenta, opt => opt.MapFrom(src => src.iNumeroCuenta))
                 .ForMember(dest => dest.IdFamilia, opt => opt.MapFrom(src => src.Familia!.iIdFamilia))
                 .ForMember(dest => dest.Familia, opt => opt.MapFrom(src => src.Familia!.sNombre))
                 .ForMember(dest => dest.ValorRecuperable, opt => opt.MapFrom(src => src.dValorRecuperable))
                 .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
                 .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
                 .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntSubfamiliaRequest, EntSubfamilia>()
                .ForMember(dest => dest.iIdSubfamilia, opt => opt.MapFrom(src => src.IdSubfamilia))
                .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.sDescripcion, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.iIdFamilia, opt => opt.MapFrom(src => src.IdFamilia))
                .ForMember(dest => dest.dValorRecuperable, opt => opt.MapFrom(src => src.ValorRecuperable));
        }

    }
}
