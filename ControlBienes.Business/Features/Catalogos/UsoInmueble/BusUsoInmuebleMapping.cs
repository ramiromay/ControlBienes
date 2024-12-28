using AutoMapper;
using ControlBienes.Entities.Catalogos.UsoInmueble;

namespace ControlBienes.Business.Features.Catalogos.UsoInmueble
{
    internal class BusUsoInmuebleMapping : Profile
    {
        public BusUsoInmuebleMapping()
        {
            CreateMap<EntUsoInmueble, EntUsoInmuebleResponse>()
               .ForMember(dest => dest.IdUsoInmueble, opt => opt.MapFrom(src => src.iIdUsoInmueble))
               .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
               .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
               .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
               .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntUsoInmuebleRequest, EntUsoInmueble>()
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre));
        }
    }
}
