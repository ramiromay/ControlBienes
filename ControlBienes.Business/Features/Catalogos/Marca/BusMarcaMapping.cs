using AutoMapper;
using ControlBienes.Entities.Catalogos.Marca;

namespace ControlBienes.Business.Features.Catalogos.Marca
{
    public class BusMarcaMapping : Profile
    {
        public BusMarcaMapping()
        {
            CreateMap<EntMarca, EntMarcaResponse>()
              .ForMember(dest => dest.IdMarca, opt => opt.MapFrom(src => src.iIdMarca))
              .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
              .ForMember(dest => dest.Observaciones, opt => opt.MapFrom(src => src.sObservaciones))
              .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
              .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
              .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntMarcaRequest, EntMarca>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.sObservaciones, opt => opt.MapFrom(src => src.Observaciones));
        }
    }
}
