using AutoMapper;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Patrimonio.DetalleDestinoFinal;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Etapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteVehiculo.DestinoFinal
{
	public class BusTramiteVehiculoDestinoFinalMapping : Profile
	{
		public BusTramiteVehiculoDestinoFinalMapping()
		{
			CreateMap<EntDetalleSolicitud, EntDetalleDestinoFinalVehiculoResponse>()
				.ForMember(dest => dest.IdSolicitud, opt => opt.MapFrom(src => src.iIdSolicitud))
				.ForMember(dest => dest.FolioBien, opt => opt.MapFrom(src => src.DetalleDestinoFinal.sFolioBien))
				.ForMember(dest => dest.IdEmpleado, opt => opt.MapFrom(src => src.DetalleDestinoFinal.iIdEmpleado))

				.ForMember(dest => dest.NivelUnidadAdministrativa, opt => opt.MapFrom(src => src.DetalleDestinoFinal.UnidadAdministrativa.sNivelCompleto))

				.ForMember(dest => dest.FolioDestruccion, opt => opt.MapFrom(src => src.DetalleDestinoFinal.DetalleDestruccion.sFolio))
				.ForMember(dest => dest.FechaDestruccion, opt => opt.MapFrom(src => src.DetalleDestinoFinal.DetalleDestruccion.dtFecha))
				.ForMember(dest => dest.DescripcionDestruccion, opt => opt.MapFrom(src => src.DetalleDestinoFinal.DetalleDestruccion.sDescripcion))

				.ForMember(dest => dest.AvaluoEnajenacion, opt => opt.MapFrom(src => src.DetalleDestinoFinal.DetalleEnagenacion.sAvaluo))
				.ForMember(dest => dest.FechaEnajenacion, opt => opt.MapFrom(src => src.DetalleDestinoFinal.DetalleEnagenacion.dtFecha))
				.ForMember(dest => dest.FolioEnajenacion, opt => opt.MapFrom(src => src.DetalleDestinoFinal.DetalleEnagenacion.sFolio))
				.ForMember(dest => dest.ImporteAvaluoEnajenacion, opt => opt.MapFrom(src => src.DetalleDestinoFinal.DetalleEnagenacion.dImporteAvaluo))
				.ForMember(dest => dest.DescripcionEnajenacion, opt => opt.MapFrom(src => src.DetalleDestinoFinal.DetalleEnagenacion.sDescripcion));

			CreateMap<EntDetalleDestinoFinalVehiculoRequest, EntDetalleSolicitud>()
				.ForMember(dest => dest.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
				.ForMember(dest => dest.iIdEtapa, opt => opt.MapFrom(src => (long)EnumEtapa.CapturaInicial))
				.ForPath(dest => dest.DetalleDestinoFinal.iIdTipoBien, opt => opt.MapFrom(src => (long)EnumTipoBien.MaquinariaVehiculo))
				.ForPath(dest => dest.DetalleDestinoFinal.iIdEmpleado, opt => opt.MapFrom(src => src.IdEmpleado))

				.ForPath(dest => dest.DetalleDestinoFinal.sFolioBien, opt => opt.MapFrom(src => src.FolioBien))
				.ForPath(dest => dest.DetalleDestinoFinal.DetalleDestruccion.sFolio, opt => opt.MapFrom(src => src.FolioDestruccion))
				.ForPath(dest => dest.DetalleDestinoFinal.DetalleDestruccion.dtFecha, opt => opt.MapFrom(src => src.FechaDestruccion))
				.ForPath(dest => dest.DetalleDestinoFinal.DetalleDestruccion.sDescripcion, opt => opt.MapFrom(src => src.DescripcionDestruccion))

				.ForPath(dest => dest.DetalleDestinoFinal.DetalleEnagenacion.sAvaluo, opt => opt.MapFrom(src => src.AvaluoEnajenacion))
				.ForPath(dest => dest.DetalleDestinoFinal.DetalleEnagenacion.dtFecha, opt => opt.MapFrom(src => src.FechaEnajenacion))
				.ForPath(dest => dest.DetalleDestinoFinal.DetalleEnagenacion.sFolio, opt => opt.MapFrom(src => src.FolioEnajenacion))
				.ForPath(dest => dest.DetalleDestinoFinal.DetalleEnagenacion.dImporteAvaluo, opt => opt.MapFrom(src => src.ImporteAvaluoEnajenacion))
				.ForPath(dest => dest.DetalleDestinoFinal.DetalleEnagenacion.sDescripcion, opt => opt.MapFrom(src => src.DescripcionEnajenacion));
		}
	}
}
