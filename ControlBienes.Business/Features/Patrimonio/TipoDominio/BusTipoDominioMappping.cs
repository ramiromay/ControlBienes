using AutoMapper;
using ControlBienes.Entities.Patrimonio.TipoDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TipoDominio
{
	public class BusTipoDominioMappping : Profile
	{
		public BusTipoDominioMappping()
		{
			CreateMap<EntTipoDominio, EntTipoDominioResponse>()
				.ForMember(dest => dest.IdTipoDominio, opt => opt.MapFrom(src => src.iIdTipoDominio))
				.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))

				;
		}
	}
}
