using ControlBienes.Data.Contrats.General;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.General.Periodo;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.General
{
    public class DatPeriodo : Dat<EntPeriodo>, IDatPeriodo
    {
        public DatPeriodo(AppDbContext context, ILogger<Dat<EntPeriodo>> logger) : base(context, logger)
        {
        }
    }
}
