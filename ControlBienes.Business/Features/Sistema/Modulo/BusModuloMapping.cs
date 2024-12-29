using AutoMapper;

using ControlBienes.Entities.Sistema.Modulo;
using ControlBienes.Entities.Sistema.Modulo.Modulo;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Sistema.Modulo
{
    public class BusModuloMapping : Profile
    {
        
        public BusModuloMapping()
        {
            CreateMap<EntModulo, EntModuloResponse>()
              .ForMember(dest => dest.IdModulo, opt => opt.MapFrom(src => src.iIdModulo))
              .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
              .ForMember(dest => dest.Abreviacion, opt => opt.MapFrom(src => src.sAbreviacion))
              .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion));
        }
    }
}
