using AutoMapper;
using ControlBienes.Entities.Patrimonio.Depreciacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.Depreciacion
{
	public class BusDepreciacionMapping : Profile
	{
		public BusDepreciacionMapping()
		{
			CreateMap<EntDepreciacion, EntDepreciacionResponse>()
		  .ForMember(dest => dest.IdDepreciacion, opt => opt.MapFrom(src => src.iIdDepreciacion))
		  .ForMember(dest => dest.Tasa, opt => opt.MapFrom(src => src.dTasa))
		  .ForMember(dest => dest.DepreciaionAcumulada, opt => opt.MapFrom(src => src.dDepreciaionAcumulada))
		  .ForMember(dest => dest.ValorLibros, opt => opt.MapFrom(src => src.dValorLibros))
		  .ForMember(dest => dest.DepreciacionFiscal, opt => opt.MapFrom(src => src.dDepreciacionFiscal))
		  .ForMember(dest => dest.Depreciacion, opt => opt.MapFrom(src => src.dDepreciacion))
		  .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.dtFecha))
		  .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
		  .ForMember(dest => dest.ValorHistorico, opt => opt.MapFrom(src => src.dValorHistorico))
		  .ForMember(dest => dest.AniosVida, opt => opt.MapFrom(src => src.iAniosVida));
		}
	}
}
