using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.Ubicacion;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatUbicacion : DatCatalogoGenerico<EntUbicacion>, IDatUbicacion
    {
        public DatUbicacion(AppDbContext context, ILogger<DatCatalogoGenerico<EntUbicacion>> logger) : base(context, logger)
        {
        }
    }
}
