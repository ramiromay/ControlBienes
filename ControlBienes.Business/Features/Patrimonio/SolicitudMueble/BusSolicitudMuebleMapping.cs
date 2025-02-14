using AutoMapper;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Patrimonio.Afectacion;
using ControlBienes.Entities.Patrimonio.Etapa;
using ControlBienes.Entities.Patrimonio.Solicitud;

namespace ControlBienes.Business.Features.Patrimonio.SolicitudMueble
{
	public class BusSolicitudMuebleMapping : Profile
	{
		public BusSolicitudMuebleMapping()
		{
			CreateMap<EntSolicitud, EntSolicitudMuebleResponse>()
				.ForMember(dest => dest.IdSolicitud, opt => opt.MapFrom(src => src.iIdSolicitud))
				.ForMember(dest => dest.IdEmpleado, opt => opt.MapFrom(src => src.iIdEmpleado))
			   .ForMember(dest => dest.Empleado, opt => opt.MapFrom(src => 
			   $"{src.Empleado.Persona.sNombres} {src.Empleado.Persona.sPrimerNombre} {src.Empleado.Persona.sSegundoNombre}"))
			   .ForMember(dest => dest.IdEtapa, opt => opt.MapFrom(src => src.iIdEtapa))
			   .ForMember(dest => dest.Etapa, opt => opt.MapFrom(src => src.Etapa.sNombre))
			   .ForMember(dest => dest.IdPeriodo, opt => opt.MapFrom(src => src.iIdPeriodo))
			   .ForMember(dest => dest.IdUnidadAdministrativa, opt => opt.MapFrom(src => src.iIdUnidadAdministrativa))
			   .ForMember(dest => dest.UnidadAdministrativa, opt => opt.MapFrom(src => $"{src.UnidadAdministrativa.sNivelCompleto} {src.UnidadAdministrativa.sNombre}"))
			   .ForMember(dest => dest.IdTipoTramite, opt => opt.MapFrom(src => src.iIdTipoTramite))
			   .ForMember(dest => dest.TipoTramite, opt => opt.MapFrom(src => src.TiposTramite.sNombre))
			   .ForMember(dest => dest.IdMotivoTramite, opt => opt.MapFrom(src => src.iIdMotivoTramite))
			   .ForMember(dest => dest.MotivoTramite, opt => opt.MapFrom(src => src.MotivoTramite.sNombre))
			   .ForMember(dest => dest.Observaciones, opt => opt.MapFrom(src => src.sObservaciones))
			   .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
			   .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

			CreateMap<EntSolicitudMuebleRequest, EntSolicitud>()
				.ForMember(dest => dest.iIdEmpleado, opt => opt.MapFrom(src => src.IdEmpleado))
				.ForMember(dest => dest.iIdEtapa, opt => opt.MapFrom(src => (long) EnumEtapa.CapturaInicial))
			   .ForMember(dest => dest.iIdTipoTramite, opt => opt.MapFrom(src => src.IdTipoTramite))
			   .ForMember(dest => dest.iIdMotivoTramite, opt => opt.MapFrom(src => src.IdMotivoTramite))
			   .ForMember(dest => dest.iIdAfectacion, opt => opt.MapFrom(src => (long) EnumAfectacion.FechaActual))
			   .ForMember(dest => dest.dtFechaAfectacion, opt => opt.MapFrom(src => DateTime.Now))
			   .ForMember(dest => dest.iIdTipoBien, opt => opt.MapFrom(src => (long)EnumTipoBien.Mueble))
			   .ForMember(dest => dest.sObservaciones, opt => opt.MapFrom(src => src.Observaciones));
		}
	}
}
