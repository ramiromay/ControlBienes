using AutoMapper;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Sistema.SubModulo;
using ControlBienes.Entities.Sistema.SubModulo.SubModulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Sistema.SubModulo
{
    public class BusSubModuloMapping : Profile
    {
        public BusSubModuloMapping()
        {
            CreateMap<EntSubModulo, EntSubModuloResponse>()
              .ForMember(dest => dest.IdSubModulo, opt => opt.MapFrom(src => src.iIdSubModulo))
              .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
              .ForMember(dest => dest.Abreviacion, opt => opt.MapFrom(src => src.sAbreviacion))
              .ForMember(dest => dest.IdSeccion, opt => opt.MapFrom(src => src.iIdSeccion))
              .ForMember(dest => dest.IdModulo, opt => opt.MapFrom(src => src.iIdModulo));
        }
    }
}
