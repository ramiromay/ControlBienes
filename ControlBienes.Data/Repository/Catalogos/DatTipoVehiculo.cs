using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.TipoVehicular;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatTipoVehiculo : DatCatalogoGenerico<EntTipoVehicular>, IDatTipoVehiculo
    {
        public DatTipoVehiculo(AppDbContext context, ILogger<DatCatalogoGenerico<EntTipoVehicular>> logger) : base(context, logger)
        {
        }
    }
}
