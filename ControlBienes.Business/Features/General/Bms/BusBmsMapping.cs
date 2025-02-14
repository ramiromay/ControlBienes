using AutoMapper;
using ControlBienes.Entities.General.BMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.General.Bms
{
	public class BusBmsMapping : Profile
	{
		public BusBmsMapping()
		{
			CreateMap<EntBms, EntBMSResponse>()
				 .ForMember(dest => dest.IdBMS, opt => opt.MapFrom(src => src.iIdBms))
				.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
				.ForMember(dest => dest.IdFamilia, opt => opt.MapFrom(src => src.iIdFamilia))
				.ForMember(dest => dest.IdSubfamilia, opt => opt.MapFrom(src => src.iIdSubfamilia))
				.ForMember(dest => dest.PrecioUnitario, opt => opt.MapFrom(src => src.dPrecioUnitario))
				.ForMember(dest => dest.CodigoArmonizado, opt => opt.MapFrom(src => src.nCodigoArmonizado));
		}
	}
}
