using AutoMapper;
using ControlBienes.Entities.Catalogos.Turno;

namespace ControlBienes.Business.Features.Catalogos.Turno
{
    public class BusTurnoMapping : Profile
    {
        public BusTurnoMapping()
        {
            CreateMap<EntTurno, EntTurnoResponse>()
               .ForMember(dest => dest.IdTurno, opt => opt.MapFrom(src => src.iIdTurno))
               .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
               .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
               .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
               .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntTurnoRequest, EntTurno>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre));
        }
    }
}
