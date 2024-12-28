using AutoMapper;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Catalogos.Titular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Catalogos.Titular
{
    public class BusTitularMapping : Profile
    {
        public BusTitularMapping()
        {
            CreateMap<EntTitular, EntTitularResponse>()
               .ForMember(dest => dest.IdTitular, opt => opt.MapFrom(src => src.iIdTitular))
               .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
               .ForMember(dest => dest.IdCentroTrabajoTurno, opt => opt.MapFrom(src => src.iIdCentroTrabajoTurno))
               .ForMember(dest => dest.CentroTrabajo, opt => opt.MapFrom(src => src.CentroTrabajoTurno.CentroTrabajo.sNombre))
               .ForMember(dest => dest.Turno, opt => opt.MapFrom(src => src.CentroTrabajoTurno.Turno.sNombre))
               .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
               .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
               .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntTitularRequest, EntTitular>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.iIdCentroTrabajoTurno, opt => opt.MapFrom(src => src.IdCentroTrabajoTurno));
        }
    }
}
