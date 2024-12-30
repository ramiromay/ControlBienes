using AutoMapper;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Patrimonio.MotivoTramite;
using ControlBienes.Entities.Patrimonio.TipoTramite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.MotivoTramite
{
    public class BusMotivoTramiteMapping : Profile
    {
        public BusMotivoTramiteMapping()
        {
            CreateMap<EntMotivoTramite, EntMotivoTramiteResponse>()
              .ForMember(dest => dest.IdMotivoTramite, opt => opt.MapFrom(src => src.iIdMotivoTramite))
              .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
              .ForMember(dest => dest.IdTipoTramite, opt => opt.MapFrom(src => src.iIdTipoTramite));
        }
    }
}
