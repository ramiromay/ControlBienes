using AutoMapper;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.General.TipoResponsable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.General.TipoResponsable
{
    public class BusTipoResponsableMapping : Profile
    {
        public BusTipoResponsableMapping()
        {
            CreateMap<EntTipoResponsable, EntTipoResponsableResponse>()
               .ForMember(dest => dest.IdTipoResponsable, opt => opt.MapFrom(src => src.iIdTipoResponsable))
               .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre));
        }
    }
}
