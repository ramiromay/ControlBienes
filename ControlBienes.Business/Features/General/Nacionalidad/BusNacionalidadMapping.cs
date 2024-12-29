using AutoMapper;
using ControlBienes.Entities.General.Nacionalidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.General.Nacionalidad
{
	public class BusNacionalidadMapping : Profile
	{
		public BusNacionalidadMapping()
		{
			CreateMap<EntNacionalidad, EntNacionalidadResponse>()
				.ForMember(dest => dest.IdNacionalidad, opt => opt.MapFrom(src => src.iIdNacionalidad))
				.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre));
		}
	}
}
