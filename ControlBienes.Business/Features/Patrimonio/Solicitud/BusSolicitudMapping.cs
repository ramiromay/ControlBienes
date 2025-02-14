using AutoMapper;
using ControlBienes.Entities.Almacen.EtapaMovimiento;
using ControlBienes.Entities.Patrimonio.Etapa;
using ControlBienes.Entities.Patrimonio.EtapaSolicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.Solicitud
{
	public class BusSolicitudMapping : Profile
	{
		public BusSolicitudMapping()
		{
			CreateMap<EntEtapaSolicitud, EntEtapaResponse>()
				.ForMember(dest => dest.IdEtapa, opt => opt.MapFrom(src => src.EtapaDestino.iIdEtapa))
				.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.EtapaDestino.sNombre));
		}
	}
}
