using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.Turno;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatTurno : DatCatalogoGenerico<EntTurno>, IDatTurno
    {
        public DatTurno(AppDbContext context, ILogger<DatCatalogoGenerico<EntTurno>> logger) : base(context, logger)
        {
        }
    }
}
