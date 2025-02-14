using AutoMapper;
using ControlBienes.Entities.Patrimonio.Etapa;
using ControlBienes.Entities.Patrimonio.EtapaTramite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteMueble
{
	public class BusTramiteMapping : Profile
	{
		public BusTramiteMapping()
		{
			CreateMap<EntEtapaTramite, EntEtapaResponse>()
			   .ForMember(dest => dest.IdEtapa, opt => opt.MapFrom(src => src.EtapaDestino.iIdEtapa))
			   .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.EtapaDestino.sNombre));
		}
	}
}
