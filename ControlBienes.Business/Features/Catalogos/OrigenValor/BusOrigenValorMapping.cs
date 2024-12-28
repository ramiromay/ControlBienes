using AutoMapper;
using ControlBienes.Entities.Catalogos.OrigenValor;

namespace ControlBienes.Business.Features.Catalogos.OrigenValor
{
    public class BusOrigenValorMapping : Profile
    {
        public BusOrigenValorMapping()
        {
            CreateMap<EntOrigenValor, EntOrigenValorResponse>()
                .ForMember(dest => dest.IdOrigenValor, opt => opt.MapFrom(src => src.iIdOrigenValor))
                .ForMember(dest => dest.Origen, opt => opt.MapFrom(src => src.sOrigen))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
                .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
                .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntOrigenValorRequest, EntOrigenValor>()
                .ForMember(dest => dest.sOrigen, opt => opt.MapFrom(src => src.Origen))
                .ForMember(dest => dest.sDescripcion, opt => opt.MapFrom(src => src.Descripcion));
        }

    }
}
