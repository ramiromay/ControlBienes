using AutoMapper;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Seguridad.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Seguridad.Rol
{
	public class BusRolMapping : Profile
	{
		public BusRolMapping()
		{
			CreateMap<EntRol, EntRolResponse>()
				.ForMember(dest => dest.IdRol, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion));
		}
	}
}
