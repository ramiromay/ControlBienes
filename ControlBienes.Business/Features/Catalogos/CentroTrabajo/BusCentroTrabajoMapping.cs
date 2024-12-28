using AutoMapper;
using ControlBienes.Entities.Catalogos.CentroTrabajo;

namespace ControlBienes.Business.Features.Catalogos.CentroTrabajo
{
	public class BusCentroTrabajoMapping : Profile
    {
        public BusCentroTrabajoMapping()
        {
            CreateMap<EntCentroTrabajo, EntCentroTrabajoResponse>()
                 .ForMember(dest => dest.IdCentroTrabajo, opt => opt.MapFrom(src => src.iIdCentroTrabajo))
                 .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
                 .ForMember(dest => dest.Clave, opt => opt.MapFrom(src => src.sClave))
                 .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.sDireccion))
                 .ForMember(dest => dest.IdPeriodo, opt => opt.MapFrom(src => src.iIdPeriodo))
                 .ForMember(dest => dest.IdUnidadAdministrativa, opt => opt.MapFrom(src => src.iIdUnidadAdministrativa))
                 .ForMember(dest => dest.UnidadAdministrativa, opt => opt.MapFrom(src => src.UnidadAdministrativa.sNombre))
                 .ForMember(dest => dest.IdMunicipio, opt => opt.MapFrom(src => src.iIdMunicipio))
                 .ForMember(dest => dest.Municipio, opt => opt.MapFrom(src => src.Municipio.sNombre))
                 .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
                 .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
                 .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

            CreateMap<EntCentroTrabajoRequest, EntCentroTrabajo>()
               .ForMember(dest => dest.iIdPeriodo, opt => opt.MapFrom(src => src.IdPeriodo))
               .ForMember(dest => dest.iIdUnidadAdministrativa, opt => opt.MapFrom(src => src.IdUnidadAdministrativa))
               .ForMember(dest => dest.iIdMunicipio, opt => opt.MapFrom(src => src.IdMunicipio))
               .ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre))
               .ForMember(dest => dest.sClave, opt => opt.MapFrom(src => src.Clave))
               .ForMember(dest => dest.sDireccion, opt => opt.MapFrom(src => src.Direccion));
        }
    }
}
