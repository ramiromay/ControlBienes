using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.TipoAdquisicion;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatTipoAdquisicion : DatCatalogoGenerico<EntTipoAdquisicion>, IDatTipoAdquisicion
    {
        public DatTipoAdquisicion(AppDbContext context, ILogger<DatCatalogoGenerico<EntTipoAdquisicion>> logger) : base(context, logger)
        {
        }
    }
}
