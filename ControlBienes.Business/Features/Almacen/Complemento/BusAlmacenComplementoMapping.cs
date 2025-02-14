using AutoMapper;
using ControlBienes.Entities.Almacen;
using ControlBienes.Entities.Almacen.MetodoCosteo;
using ControlBienes.Entities.Almacen.ProgramaOperativo;
using ControlBienes.Entities.Almacen.Proveedor;
using ControlBienes.Entities.Almacen.TipoMovimiento;
using ControlBienes.Entities.Catalogos.Almacen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Almacen.Complemento
{
	public class BusAlmacenComplementoMapping : Profile
	{
		public BusAlmacenComplementoMapping()
		{
			CreateMap<EntProveedor, EntProveedorResponse>()
			  .ForMember(dest => dest.IdProveedor, opt => opt.MapFrom(src => src.iIdProveedor))
			  .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre));

			CreateMap<EntProgramasOperativo, EntProgramaOperativoResponse>()
			  .ForMember(dest => dest.IdProgramaOperativo, opt => opt.MapFrom(src => src.iIdProgramaOperativo))
			  .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre));

			CreateMap<EntTipoMovimiento, EntTipoMovimientoResponse>()
			  .ForMember(dest => dest.IdTipoMovimiento, opt => opt.MapFrom(src => src.iIdTipoMovimiento))
			  .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre));

			CreateMap<EntMetodoCosteo, EntMetodoCosteoResponse>()
			  .ForMember(dest => dest.IdMetodoCosteo, opt => opt.MapFrom(src => src.iIdMetodoCosteo))
			  .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
			  .ForMember(dest => dest.Abreviacion, opt => opt.MapFrom(src => src.sAbreviacion));
		}
	}
}
