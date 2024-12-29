using AutoMapper;
using ControlBienes.Entities.Seguridad.Persona;
using ControlBienes.Entities.Seguridad.Persona.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Seguridad.Persona
{
    public class BusPersonaMapping : Profile
    {
        public BusPersonaMapping()
        {
            CreateMap<EntPersona, EntPersonaResponse>()
               .ForMember(dest => dest.IdPersona, opt => opt.MapFrom(src => src.iIdPersona))
               .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => $"{src.sNombres} {src.sPrimerNombre} {src.sSegundoNombre}".Trim()));

        }
    }
}
