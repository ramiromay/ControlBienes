using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.EstadoGeneral;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatEstadoGeneral : DatCatalogoGenerico<EntEstadoGeneral>, IDatEstadoGeneral
    {
        public DatEstadoGeneral(AppDbContext context, ILogger<DatCatalogoGenerico<EntEstadoGeneral>> logger) : base(context, logger)
        {
        }
    }
}
