using ControlBienes.Data.Contrats.Sistema;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Sistema.SubModulo;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Sistema
{
    public class DatSubModulo : Dat<EntSubModulo>, IDatSubModulo
    {
        public DatSubModulo(AppDbContext context, ILogger<Dat<EntSubModulo>> logger) : base(context, logger)
        {
        }
    }
}
