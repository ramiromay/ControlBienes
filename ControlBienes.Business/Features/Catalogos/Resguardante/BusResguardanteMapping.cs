using AutoMapper;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Catalogos.Resguardante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Catalogos.Resguardante
{
    public class BusResguardanteMapping : Profile
    {
        public BusResguardanteMapping()
        {
            CreateMap<EntResguardante, EntResguardanteResponse>()
                .ForMember(dest => dest.IdResguardante, opt => opt.MapFrom(src => src.iIdResguardante))
                .ForMember(dest => dest.IdPeriodo, opt => opt.MapFrom(src => src.iIdPeriodo))
                .ForMember(dest => dest.IdPersona, opt => opt.MapFrom(src => src.iIdPersona))
                .ForMember(dest => dest.Persona, opt => opt.MapFrom(src => $"{src.Persona.sNombres} {src.Persona.sPrimerNombre} {src.Persona.sSegundoNombre}" ))
                .ForMember(dest => dest.IdTipoResponsable, opt => opt.MapFrom(src => src.iIdTipoResponsable))
                .ForMember(dest => dest.TipoResponsable, opt => opt.MapFrom(src => src.TipoResponsable.sNombre))
                .ForMember(dest => dest.NivelUnidadAdministrativa, opt => opt.MapFrom(src => src.UnidadAdministrativa.sNivelCompleto))
                .ForMember(dest => dest.UnidadAdministrativa, opt => opt.MapFrom(src => src.UnidadAdministrativa.sNombre))
                .ForMember(dest => dest.NoConvenio, opt => opt.MapFrom(src => src.iNoConvenio))
                .ForMember(dest => dest.Observaciones, opt => opt.MapFrom(src => src.sObservaciones))
                .ForMember(dest => dest.Responsable, opt => opt.MapFrom(src => src.bResponsable))
                .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
                .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntResguardanteRequest, EntResguardante>()
               .ForMember(dest => dest.iIdPeriodo, opt => opt.MapFrom(src => src.IdPeriodo))
               .ForMember(dest => dest.iIdPersona, opt => opt.MapFrom(src => src.IdPersona))
               .ForMember(dest => dest.iIdTipoResponsable, opt => opt.MapFrom(src => src.IdTipoResponsable))
               .ForMember(dest => dest.iNoConvenio, opt => opt.MapFrom(src => src.NoConvenio))
               .ForMember(dest => dest.sObservaciones, opt => opt.MapFrom(src => src.Observaciones))
               .ForMember(dest => dest.bResponsable, opt => opt.MapFrom(src => src.Responsable));
        }
    }
}
