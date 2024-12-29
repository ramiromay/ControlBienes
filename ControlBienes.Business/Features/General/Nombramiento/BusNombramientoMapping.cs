using AutoMapper;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.General.Nombramiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.General.Nombramiento
{
	public class BusNombramientoMapping : Profile
	{
		public BusNombramientoMapping()
		{
			CreateMap<EntNombramiento, EntNombramientoResponse>()
				.ForMember(dest => dest.IdNombramiento, opt => opt.MapFrom(src => src.iIdNombramiento))
				.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre));
		}
	}
}
