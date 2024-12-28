using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.VersionVehicular;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatVersionVehicular : DatCatalogoGenerico<EntVersionVehicular>, IDatVersionVehicular
    {
        public DatVersionVehicular(AppDbContext context, ILogger<DatCatalogoGenerico<EntVersionVehicular>> logger) : base(context, logger)
        {
        }
    }
}
