using AutoMapper;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Patrimonio.DetalleMovimiento;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Etapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteVehiculo.Movimiento
{
	public class BusTramiteVehiculoMovimientoMapping : Profile
	{
		public BusTramiteVehiculoMovimientoMapping()
		{
			CreateMap<EntDetalleSolicitud, EntDetalleMovimientoVehiculoResponse>()
				.ForMember(dest => dest.IdSolicitud, opt => opt.MapFrom(src => src.iIdSolicitud))
				.ForMember(dest => dest.IdMunicipio, opt => opt.MapFrom(src => src.DetalleMovimiento.iIdMunicipio))
				.ForMember(dest => dest.IdUbicacion, opt => opt.MapFrom(src => src.DetalleMovimiento.iIdUbicacion))
				.ForMember(dest => dest.FolioBien, opt => opt.MapFrom(src => src.DetalleMovimiento.sFolioBien))
				.ForMember(dest => dest.NivelUnidadAdministrativa, opt => opt.MapFrom(src => src.DetalleMovimiento.UnidadAdministrativa.sNivelCompleto))
				.ForMember(dest => dest.NivelNuevaUnidadAdministrativa, opt => opt.MapFrom(src => src.DetalleMovimiento.NuevaUnidadAdministrativa.sNivelCompleto))
				.ForMember(dest => dest.Responsable, opt => opt.MapFrom(src => src.DetalleMovimiento.sResponsable));

			CreateMap<EntDetalleMovimientoVehiculoRequest, EntDetalleSolicitud>()
				.ForMember(dest => dest.iIdSolicitud, opt => opt.MapFrom(src => src.IdSolicitud))
				.ForMember(dest => dest.iIdEtapa, opt => opt.MapFrom(src => (long)EnumEtapa.CapturaInicial))
				.ForPath(dest => dest.DetalleMovimiento.iIdTipoBien, opt => opt.MapFrom(src => (long)EnumTipoBien.MaquinariaVehiculo))
				.ForPath(dest => dest.DetalleMovimiento.iIdMunicipio, opt => opt.MapFrom(src => src.IdMunicipio))
				.ForPath(dest => dest.DetalleMovimiento.iIdUbicacion, opt => opt.MapFrom(src => src.IdUbicacion))
				.ForPath(dest => dest.DetalleMovimiento.sFolioBien, opt => opt.MapFrom(src => src.FolioBien))
				.ForPath(dest => dest.DetalleMovimiento.sResponsable, opt => opt.MapFrom(src => src.Responsable));
		}
	}
}
