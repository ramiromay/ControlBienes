using AutoMapper;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Patrimonio.TipoTramite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TipoTramite
{
    public class BusTipoTramiteMapping : Profile
    {
        public BusTipoTramiteMapping()
        {
            CreateMap<EntTipoTramite, EntTipoTramiteResponse>()
              .ForMember(dest => dest.IdTipoTramite, opt => opt.MapFrom(src => src.iIdTipoTramite))
              .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
              .ForMember(dest => dest.IdSubModulo, opt => opt.MapFrom(src => src.iIdSubModulo));
        }
    }
}
