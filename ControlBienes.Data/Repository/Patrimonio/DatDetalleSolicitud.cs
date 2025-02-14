using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatDetalleSolicitud : DatProyeccion<EntDetalleSolicitud>, IDatDetalleSolicitud
	{
		public DatDetalleSolicitud(AppDbContext context, ILogger<Dat<EntDetalleSolicitud>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}

		public async Task<int> DCambiarEtapaAsync(long idDetalleSolicitud, long idEtapa)
		{
			var detalleSolicitud = await _context.Set<EntDetalleSolicitud>()
							  .FirstOrDefaultAsync(d => d.iIdDetalleSolicitud == idDetalleSolicitud);
			detalleSolicitud.iIdEtapa = idEtapa;
			var result = await _context.SaveChangesAsync();
			_context.Entry(detalleSolicitud).State = EntityState.Detached;
			return result;
		}
	}
}
