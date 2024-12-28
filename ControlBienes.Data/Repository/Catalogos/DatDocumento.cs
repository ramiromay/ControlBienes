using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.Documento;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatDocumento : DatCatalogoGenerico<EntDocumento>, IDatDocumento
    {
        public DatDocumento(AppDbContext context, ILogger<Dat<EntDocumento>> logger) : base(context, logger)
        {
        }
    }
}
