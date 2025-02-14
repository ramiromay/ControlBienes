using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.Solicitud;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatSolicitud : DatProyeccion<EntSolicitud>, IDatSolicitud
	{
		public DatSolicitud(AppDbContext context, ILogger<Dat<EntSolicitud>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}

		public async Task<int> DCambiarEtapaAsync(EntSolicitud entity, long idEtapaSiguiente)
		{
			entity.iIdEtapa = idEtapaSiguiente;
			return await base.DActualizarAsync(entity);
		}

	}
}
