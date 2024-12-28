using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.Subfamilia;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatSubfamilia : DatCatalogoGenerico<EntSubfamilia>, IDatSubfamilia
    {
        public DatSubfamilia(AppDbContext context, ILogger<DatCatalogoGenerico<EntSubfamilia>> logger) : base(context, logger)
        {
        }
    }
}
