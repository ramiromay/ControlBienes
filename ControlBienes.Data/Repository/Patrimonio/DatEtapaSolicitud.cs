using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.EtapaSolicitud;
using ControlBienes.Entities.Patrimonio.EtapaTramite;
using ControlBienes.Entities.Patrimonio.Solicitud;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatEtapaSolicitud : DatProyeccion<EntEtapaSolicitud>, IDatEtapaSolicitud
	{
		public DatEtapaSolicitud(AppDbContext context, ILogger<Dat<EntEtapaSolicitud>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}

		public Task<bool> DValidarCambioEtapaAsync(EntSolicitud entidad, long idEtapa)
		{
			if (entidad == null) return Task.FromResult(false);
			return DExisteRegistroAsync(e =>
				e.iIdEtapaOrigen == entidad.iIdEtapa &&
				e.iIdEtapaDestino == idEtapa);
		}
	}
}
