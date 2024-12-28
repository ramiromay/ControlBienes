using AutoMapper;
using ControlBienes.Entities.Catalogos.CentroTrabajoTurno;

namespace ControlBienes.Business.Features.Catalogos.CentroTrabajoTurno
{
    public class BusCentroTrabajoTurnoMapping : Profile
    {
        public BusCentroTrabajoTurnoMapping()
        {
            CreateMap<EntCentroTrabajoTurno, EntCentroTrabajoTurnoResponse>()
               .ForMember(dest => dest.IdCentroTrabajoTurno, opt => opt.MapFrom(src => src.iIdCentroTrabajoTurno))
               .ForMember(dest => dest.IdCentroTrabajo, opt => opt.MapFrom(src => src.iIdCentroTrabajo))
               .ForMember(dest => dest.CentroTrabajo, opt => opt.MapFrom(src => src.CentroTrabajo.sNombre))
               .ForMember(dest => dest.IdTurno, opt => opt.MapFrom(src => src.iIdTurno))
               .ForMember(dest => dest.Turno, opt => opt.MapFrom(src => src.Turno.sNombre))
               .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
               .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
               .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntCentroTrabajoTurnoRequest, EntCentroTrabajoTurno>()
                .ForMember(dest => dest.iIdCentroTrabajo, opt => opt.MapFrom(src => src.IdCentroTrabajo))
                .ForMember(dest => dest.iIdTurno, opt => opt.MapFrom(src => src.IdTurno));
        }
    }
}
