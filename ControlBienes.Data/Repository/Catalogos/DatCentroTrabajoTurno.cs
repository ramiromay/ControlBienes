using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.CentroTrabajoTurno;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatCentroTrabajoTurno : DatCatalogoGenerico<EntCentroTrabajoTurno>, IDatCentroTrabajoTurno
    {
        public DatCentroTrabajoTurno(AppDbContext context, ILogger<Dat<EntCentroTrabajoTurno>> logger) : base(context, logger)
        {
        }
    }
}
