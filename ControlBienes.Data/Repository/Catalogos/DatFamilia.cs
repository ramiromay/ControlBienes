using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.Familia;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatFamilia : DatCatalogoGenerico<EntFamilia>, IDatFamilia
    {



        public DatFamilia(AppDbContext context, ILogger<DatCatalogoGenerico<EntFamilia>> logger) : base(context, logger)
        {

        }
    }
}
