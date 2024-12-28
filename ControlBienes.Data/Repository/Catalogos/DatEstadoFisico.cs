using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.EstadoFisico;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatEstadoFisico : DatCatalogoGenerico<EntEstadoFisico>, IDatEstadoFisico
    {
        public DatEstadoFisico(AppDbContext context, ILogger<DatCatalogoGenerico<EntEstadoFisico>> logger) : base(context, logger)
        {
        }
    }
}
