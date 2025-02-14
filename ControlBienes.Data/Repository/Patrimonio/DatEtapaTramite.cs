using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.EtapaTramite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatEtapaTramite : DatProyeccion<EntEtapaTramite>, IDatEtapaTramite
	{
		public DatEtapaTramite(AppDbContext context, ILogger<Dat<EntEtapaTramite>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}

		public Task<bool> DValidarCambioEtapaAsync(EntDetalleSolicitud entidad, long idEtapa)
		{
			if (entidad == null)
				return Task.FromResult(false);

			var solicitud = _context.Solicitudes
									.AsNoTracking()
									.FirstOrDefault(e => e.iIdSolicitud == entidad.iIdSolicitud);

			return DExisteRegistroAsync(e =>
				e.iIdTipoTramite == solicitud.iIdTipoTramite &&
				e.iIdEtapaOrigen == entidad.iIdEtapa &&
				e.iIdEtapaDestino == idEtapa);
		}
	}
}
