using ControlBienes.Data.Contrats.Sistema;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Sistema.ColumnaTabla;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Sistema
{
    public class DatColumnaTabla : Dat<EntColumnasTabla>, IDatColumnaTabla
    {
        public DatColumnaTabla(AppDbContext context, ILogger<Dat<EntColumnasTabla>> logger) : base(context, logger)
        {
        }
    }
}
