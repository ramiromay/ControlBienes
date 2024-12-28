using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.CombustibleVehicular;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatCombustibleVehicular : DatCatalogoGenerico<EntCombustibleVehicular>, IDatCombustibleVehicular
    {
        public DatCombustibleVehicular(AppDbContext context, ILogger<DatCatalogoGenerico<EntCombustibleVehicular>> logger) : base(context, logger)
        {
        }
    }
}
