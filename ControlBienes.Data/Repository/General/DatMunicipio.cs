using ControlBienes.Data.Contrats.General;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.General.Municipio;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.General
{
    public class DatMunicipio : Dat<EntMunicipio>, IDatMunicipio
    {
        public DatMunicipio(AppDbContext context, ILogger<Dat<EntMunicipio>> logger) : base(context, logger)
        {
        }
    }
}
