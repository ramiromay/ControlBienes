using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.OrigenValor;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatOrigenValor : DatCatalogoGenerico<EntOrigenValor>, IDatOrigenValor
    {
        public DatOrigenValor(AppDbContext context, ILogger<DatCatalogoGenerico<EntOrigenValor>> logger) : base(context, logger)
        {
        }
    }
}
