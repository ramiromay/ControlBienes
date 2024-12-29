using AutoMapper;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.General.UnidadAdministrativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.General.UnidadAdministrativa
{
    public class BusUnidadAdministrativaMapping : Profile
    {
        public BusUnidadAdministrativaMapping()
        {
            CreateMap<EntUnidadAdministrativa, EntUnidadAdministrativaResponse>()
              .ForMember(dest => dest.IdUnidadAdministrativa, opt => opt.MapFrom(src => src.iIdUnidadAdministrativa))
              .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
              .ForMember(dest => dest.Nivel, opt => opt.MapFrom(src => src.TipoNivel.iNivel))
              .ForMember(dest => dest.NivelCompleto, opt => opt.MapFrom(src => src.sNivelCompleto));
        }
    }
}
