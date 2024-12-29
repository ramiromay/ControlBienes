using AutoMapper;
using ControlBienes.Entities.Sistema.Catalogo;
using ControlBienes.Entities.Sistema.Catalogo.Catalogo;

namespace ControlBienes.Business.Features.Sistema.Catalogo
{
    public class BusCatalogoMapping : Profile
    {
        public BusCatalogoMapping()
        {
            CreateMap<EntCatalogo, EntCatalogoResponse>()
               .ForMember(dest => dest.IdCatalogo, opt => opt.MapFrom(src => src.iIdCatalogo))
               .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre));
        }
    }
}
