using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.LineaVehicular;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatLineaVehicular : DatCatalogoGenerico<EntLineaVehicular>, IDatLineaVehicular
    {
        public DatLineaVehicular(AppDbContext context, ILogger<DatCatalogoGenerico<EntLineaVehicular>> logger) : base(context, logger)
        {
        }
    }
}
