using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.ClaveVehicular;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatClaveVehicular : DatCatalogoGenerico<EntClaveVehicular>, IDatClaveVehicular
    {
        public DatClaveVehicular(AppDbContext context, ILogger<DatCatalogoGenerico<EntClaveVehicular>> logger) : base(context, logger)
        {
        }
    }
}
