using AutoMapper;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Patrimonio.Baja;
using ControlBienes.Entities.Patrimonio.DetalleBaja;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Etapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteMueble.Baja
{
	public class BusTramiteMuebleBajaMapping : Profile
	{
		public BusTramiteMuebleBajaMapping()
		{
			CreateMap<EntDetalleSolicitud, EntDetalleBajaMuebleResponse>()
				.ForMember(dest => dest.IdSolicitud, opt => opt.MapFrom(src => src.iIdSolicitud))
				.ForMember(dest => dest.NivelUnidadAdministrativa, opt => opt.MapFrom(src => src.DetalleBaja.Baja.UnidadAdministrativa.sNivelCompleto))
				.ForMember(dest => dest.FolioBien, opt => opt.MapFrom(src => src.DetalleBaja.Baja.sFolioBien))
				.ForMember(dest => dest.Observaciones, opt => opt.MapFrom(src => src.DetalleBaja.Baja.sObservaciones))
				.ForMember(dest => dest.FolioDocumento, opt => opt.MapFrom(src => src.DetalleBaja.Baja.sFolioDocumento))
				.ForMember(dest => dest.FehaDocumento, opt => opt.MapFrom(src => src.DetalleBaja.Baja.dtFehaDocumento))
				.ForMember(dest => dest.FolioDictamen, opt => opt.MapFrom(src => src.DetalleBaja.Baja.sFolioDictamen))
				.ForMember(dest => dest.Documentos, opt => opt.MapFrom(src => src.DetalleBaja.Baja.sListaDocunetario))
				.ForMember(dest => dest.NombreSolicitante, opt => opt.MapFrom(src => src.DetalleBaja.Baja.sNombreSolicitante))
				.ForMember(dest => dest.LugarResguardo, opt => opt.MapFrom(src => src.DetalleBaja.Baja.sLugarResguardo));

			CreateMap<EntDetalleBajaMuebleRequest, EntDetalleSolicitud>()
				.ForMember(dest => dest.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
				.ForMember(dest => dest.iIdEtapa, opt => opt.MapFrom(src => (long)EnumEtapa.CapturaInicial))
				.ForPath(dest => dest.DetalleBaja.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
				.ForPath(dest => dest.DetalleBaja.Baja.iIdTipoBien, opt => opt.MapFrom(src => (long)EnumTipoBien.Mueble))
				.ForPath(dest => dest.DetalleBaja.Baja.sFolioBien, opt => opt.MapFrom(src => src.FolioBien))
				.ForPath(dest => dest.DetalleBaja.Baja.sObservaciones, opt => opt.MapFrom(src => src.Observaciones))
				.ForPath(dest => dest.DetalleBaja.Baja.sFolioDocumento, opt => opt.MapFrom(src => src.FolioDocumento))
				.ForPath(dest => dest.DetalleBaja.Baja.dtFehaDocumento, opt => opt.MapFrom(src => src.FechaDocumento))
				.ForPath(dest => dest.DetalleBaja.Baja.sListaDocunetario, opt => opt.MapFrom(src => src.Documentos))
				.ForPath(dest => dest.DetalleBaja.Baja.sNombreSolicitante, opt => opt.MapFrom(src => src.NombreSolicitante))
				.ForPath(dest => dest.DetalleBaja.Baja.sLugarResguardo, opt => opt.MapFrom(src => src.LugarResguardo));





		}
	}
}
