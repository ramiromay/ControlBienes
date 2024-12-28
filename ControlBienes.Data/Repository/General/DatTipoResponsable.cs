using ControlBienes.Data.Contrats.General;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.General.TipoResponsable;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.General
{
    public class DatTipoResponsable : Dat<EntTipoResponsable>, IDatTipoResponsable
    {
        public DatTipoResponsable(AppDbContext context, ILogger<Dat<EntTipoResponsable>> logger) : base(context, logger)
        {
        }
    }
}
