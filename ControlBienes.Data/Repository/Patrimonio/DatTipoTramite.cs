using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.TipoTramite;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
    public class DatTipoTramite : Dat<EntTipoTramite>, IDatTipoTramite
    {
        public DatTipoTramite(AppDbContext context, ILogger<Dat<EntTipoTramite>> logger) : base(context, logger)
        {
        }
    }
}
