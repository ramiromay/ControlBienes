using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.TipoBien;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatTipoBien : DatCatalogoGenerico<EntTipoBien>, IDatTipoBien
    {
        public DatTipoBien(AppDbContext context, ILogger<DatCatalogoGenerico<EntTipoBien>> logger) : base(context, logger)
        {
        }
    }
}
