using ControlBienes.Data.Contrats.General;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.General.UnidadAdministrativa;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.General
{
    public class DatUnidadAdministrativa : Dat<EntUnidadAdministrativa>, IDatUnidadAdministrativa
    {
        public DatUnidadAdministrativa(AppDbContext context, ILogger<Dat<EntUnidadAdministrativa>> logger) : base(context, logger)
        {
        }
    }
}
