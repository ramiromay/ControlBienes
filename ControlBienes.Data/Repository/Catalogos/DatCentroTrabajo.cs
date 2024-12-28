using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.CentroTrabajo;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatCentroTrabajo : DatCatalogoGenerico<EntCentroTrabajo>, IDatCentroTrabajo
    {
        public DatCentroTrabajo(AppDbContext context, ILogger<Dat<EntCentroTrabajo>> logger) : base(context, logger)
        {
        }
    }
}
