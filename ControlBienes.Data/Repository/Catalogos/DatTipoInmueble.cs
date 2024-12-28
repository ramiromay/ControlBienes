using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.TipoInmueble;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatTipoInmueble : DatCatalogoGenerico<EntTipoInmueble>, IDatTipoInmueble
    {
        public DatTipoInmueble(AppDbContext context, ILogger<DatCatalogoGenerico<EntTipoInmueble>> logger) : base(context, logger)
        {
        }
    }
}
