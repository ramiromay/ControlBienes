using AutoMapper;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Patrimonio.DetalleBaja;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Etapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteVehiculo.Baja
{
	public class BusTramiteVehiculoBajaMapping : Profile
	{
		public BusTramiteVehiculoBajaMapping()
		{
			CreateMap<EntDetalleSolicitud, EntDetalleBajaVehiculoResponse>()
				.ForMember(dest => dest.IdSolicitud, opt => opt.MapFrom(src => src.iIdSolicitud))
				.ForMember(dest => dest.NivelUnidadAdministrativa, opt => opt.MapFrom(src => src.DetalleBaja.Baja.UnidadAdministrativa.sNivelCompleto))
				.ForMember(dest => dest.FolioBien, opt => opt.MapFrom(src => src.DetalleBaja.Baja.sFolioBien))
				.ForMember(dest => dest.IdEmpleado, opt => opt.MapFrom(src => src.DetalleBaja.Baja.iIdEmpleado))
				.ForMember(dest => dest.Observaciones, opt => opt.MapFrom(src => src.DetalleBaja.Baja.sObservaciones))
				.ForMember(dest => dest.FolioDictamen, opt => opt.MapFrom(src => src.DetalleBaja.Baja.sFolioDictamen))
				.ForMember(dest => dest.FechaDocumento, opt => opt.MapFrom(src => src.DetalleBaja.Baja.dtFehaDocumento))
				.ForMember(dest => dest.FolioDictamen, opt => opt.MapFrom(src => src.DetalleBaja.Baja.sFolioDictamen))
				.ForMember(dest => dest.Documentos, opt => opt.MapFrom(src => src.DetalleBaja.Baja.sListaDocunetario));

			CreateMap<EntDetalleBajaVehiculoRequest, EntDetalleSolicitud>()
				.ForMember(dest => dest.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
				.ForMember(dest => dest.iIdEtapa, opt => opt.MapFrom(src => (long)EnumEtapa.CapturaInicial))
				.ForPath(dest => dest.DetalleBaja.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
				.ForPath(dest => dest.DetalleBaja.Baja.iIdTipoBien, opt => opt.MapFrom(src => (long)EnumTipoBien.MaquinariaVehiculo))
				.ForPath(dest => dest.DetalleBaja.Baja.iIdEmpleado, opt => opt.MapFrom(src => src.IdEmpleado))
				.ForPath(dest => dest.DetalleBaja.Baja.sFolioBien, opt => opt.MapFrom(src => src.FolioBien))
				.ForPath(dest => dest.DetalleBaja.Baja.sObservaciones, opt => opt.MapFrom(src => src.Observaciones))
				.ForPath(dest => dest.DetalleBaja.Baja.sFolioDictamen, opt => opt.MapFrom(src => src.FolioDictamen))
				.ForPath(dest => dest.DetalleBaja.Baja.dtFehaDocumento, opt => opt.MapFrom(src => src.FechaDocumento))
				.ForPath(dest => dest.DetalleBaja.Baja.sListaDocunetario, opt => opt.MapFrom(src => src.Documentos));
		}
	}
}
