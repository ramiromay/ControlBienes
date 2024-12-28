using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatCaracteristicaBien : DatCatalogoGenerico<EntCaracteristicaBien>, IDatCaracteristicaBien
    {
        public DatCaracteristicaBien(AppDbContext context, ILogger<DatCatalogoGenerico<EntCaracteristicaBien>> logger) : base(context, logger)
        {
        }
    }
}
