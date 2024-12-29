using AutoMapper;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.General.Periodo;
using ControlBienes.Entities.Seguridad.Permiso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Seguridad.Permiso
{
	internal class BusPermisoMapping : Profile
	{
		public BusPermisoMapping()
		{
			CreateMap<EntPermiso, EntPermisoResponse>()
				.ForMember(dest => dest.IdPermiso, opt => opt.MapFrom(src => src.iIdPermiso))
				.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
				.ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion));
		}
	}
}
