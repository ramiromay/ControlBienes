using AutoMapper;
using ControlBienes.Entities.General.Cuenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.General.Cuenta
{
	public class BusCuentaMapping : Profile
	{
		public BusCuentaMapping()
		{
			CreateMap<EntCuenta, EntCuentaResponse>()
		   .ForMember(dest => dest.IdCuenta, opt => opt.MapFrom(src => src.iIdCuenta))
		   .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
		   .ForMember(dest => dest.NivelCompleto, opt => opt.MapFrom(src => src.sNivelCompleto));
		}
	}
}
