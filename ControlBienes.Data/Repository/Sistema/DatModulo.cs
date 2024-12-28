using ControlBienes.Data.Contrats.Sistema;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Sistema.Modulo;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Sistema
{
    public class DatModulo : Dat<EntModulo>, IDatModulo
    {
        public DatModulo(AppDbContext context, ILogger<Dat<EntModulo>> logger) : base(context, logger)
        {
        }
    }
}
