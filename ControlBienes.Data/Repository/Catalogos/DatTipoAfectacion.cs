using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.TipoAfectacion;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatTipoAfectacion : DatCatalogoGenerico<EntTipoAfectacion>, IDatTipoAfectacion
    {
        public DatTipoAfectacion(AppDbContext context, ILogger<DatCatalogoGenerico<EntTipoAfectacion>> logger) : base(context, logger)
        {
        }
    }
}
