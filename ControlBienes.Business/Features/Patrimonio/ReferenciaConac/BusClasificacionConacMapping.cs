using AutoMapper;
using ControlBienes.Entities.Patrimonio.ClasificacionConac;
using ControlBienes.Entities.Patrimonio.TipoBienImueble;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.ReferenciaConac
{
	public class BusClasificacionConacMapping : Profile
	{
		public BusClasificacionConacMapping()
		{
			CreateMap<EntTipoBienInmueble, EntClasificacionConacResponse>()
				.ForMember(dest => dest.NivelCompleto, opt => opt.MapFrom(src => src.sClaveCompleta))
				.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre));
		}
	}
}
