using AutoMapper;
using ControlBienes.Entities.Catalogos.MetodoAdquisicion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Catalogos.MetodoAdquisicion
{
	public class BusMetodoAdquisicionMapping : Profile
	{
		public BusMetodoAdquisicionMapping()
		{
			CreateMap<EntMetodoAdquisicion, EntMetodoAdquisicionResponse>()
			.ForMember(dest => dest.IdMetodoAdquisicion, opt => opt.MapFrom(src => src.iIdMetodoAdquisicion))
			.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
			.ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
			.ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
			.ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

			CreateMap<EntMetodoAdquisicionRequest, EntMetodoAdquisicion>()
			.ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre));
		}
	}
}
