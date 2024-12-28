using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.ClaseVehicular;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatClaseVehicular : DatCatalogoGenerico<EntClaseVehicular>, IDatClaseVehicular
    {
        public DatClaseVehicular(AppDbContext context, ILogger<DatCatalogoGenerico<EntClaseVehicular>> logger) : base(context, logger)
        {
        }
    }
}
