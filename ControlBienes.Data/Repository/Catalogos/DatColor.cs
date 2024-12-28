using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.Color;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatColor : DatCatalogoGenerico<EntColor>, IDatColor
    {
        public DatColor(AppDbContext context, ILogger<DatCatalogoGenerico<EntColor>> logger) : base(context, logger)
        {
        }
    }
}
