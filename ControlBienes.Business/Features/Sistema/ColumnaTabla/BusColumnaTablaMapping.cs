using AutoMapper;
using ControlBienes.Entities.Sistema.ColumnaTabla;

namespace ControlBienes.Business.Features.Sistema.ColumnaTabla
{
    public class BusColumnaTablaMapping : Profile
    {
        public BusColumnaTablaMapping()
        {
            CreateMap<EntColumnasTabla, EntColumnaTablaResponse>()
                .ForMember(dest => dest.Clave, opt => opt.MapFrom(src => src.sClave))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
                .ForMember(dest => dest.Tamanio, opt => opt.MapFrom(src => src.iTamanio))
                .ForMember(dest => dest.TipoDato, opt => opt.MapFrom(src => src.sTipoDato));
        }
    }
}
