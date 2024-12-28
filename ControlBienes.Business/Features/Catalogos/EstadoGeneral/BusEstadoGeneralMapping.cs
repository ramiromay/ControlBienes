using AutoMapper;
using ControlBienes.Entities.Catalogos.EstadoGeneral;

namespace ControlBienes.Business.Features.Catalogos.EstadoGeneral
{
    public class BusEstadoGeneralMapping : Profile
    {

        public BusEstadoGeneralMapping()
        {
            CreateMap<EntEstadoGeneral, EntEstadoGeneralResponse>()
              .ForMember(dest => dest.IdEstadoGeneral, opt => opt.MapFrom(src => src.iIdEstadoGeneral))
              .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
              .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
              .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
              .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntEstadoGeneralRequest, EntEstadoGeneral>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre));
        }

    }
}
