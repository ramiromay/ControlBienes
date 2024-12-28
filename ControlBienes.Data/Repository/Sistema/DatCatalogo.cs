using ControlBienes.Data.Contrats.Sistema;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Sistema.Catalogo;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Sistema
{
    public class DatCatalogo : Dat<EntCatalogo>, IDatCatalogo
    {
        public DatCatalogo(AppDbContext context, ILogger<Dat<EntCatalogo>> logger) : base(context, logger)
        {
        }
    }
}
