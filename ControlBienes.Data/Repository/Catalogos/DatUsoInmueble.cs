using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.UsoInmueble;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatUsoInmueble : DatCatalogoGenerico<EntUsoInmueble>, IDatUsoInmueble
    {
        public DatUsoInmueble(AppDbContext context, ILogger<DatCatalogoGenerico<EntUsoInmueble>> logger) : base(context, logger)
        {
        }
    }
}
