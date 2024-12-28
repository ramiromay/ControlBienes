using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.Marca;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatMarca : DatCatalogoGenerico<EntMarca>, IDatMarca
    {
        public DatMarca(AppDbContext context, ILogger<DatCatalogoGenerico<EntMarca>> logger) : base(context, logger)
        {
        }
    }
}
