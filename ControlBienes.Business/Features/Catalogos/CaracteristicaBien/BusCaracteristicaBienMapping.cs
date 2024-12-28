using AutoMapper;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;

namespace ControlBienes.Business.Features.Catalogos.CaracteristicaBien
{
    public class BusCaracteristicaBienMapping : Profile
    {
        public BusCaracteristicaBienMapping()
        {
            CreateMap<EntCaracteristicaBien, EntCaracteristicaBienResponse>()
               .ForMember(dest => dest.IdCaracteristicaBien, opt => opt.MapFrom(src => src.iIdCaracteristicaBien))
               .ForMember(dest => dest.IdFamilia, opt => opt.MapFrom(src => src.Familia!.iIdFamilia))
               .ForMember(dest => dest.Familia, opt => opt.MapFrom(src => src.Familia!.sNombre))
               .ForMember(dest => dest.IdSubfamilia, opt => opt.MapFrom(src => src.Subfamilia!.iIdSubfamilia))
               .ForMember(dest => dest.Subfamilia, opt => opt.MapFrom(src => src.Subfamilia!.sNombre))
               .ForMember(dest => dest.Etiqueta, opt => opt.MapFrom(src => src.sEtiqueta))
               .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
               .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
               .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
               .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntCaracteristicaBienRequest, EntCaracteristicaBien>()
               .ForMember(dest => dest.iIdFamilia, opt => opt.MapFrom(src => src.IdFamilia))
               .ForMember(dest => dest.iIdSubfamilia, opt => opt.MapFrom(src => src.IdSubfamilia))
               .ForMember(dest => dest.sEtiqueta, opt => opt.MapFrom(src => src.Etiqueta))
               .ForMember(dest => dest.sDescripcion, opt => opt.MapFrom(src => src.Descripcion));
        }

    }
}
