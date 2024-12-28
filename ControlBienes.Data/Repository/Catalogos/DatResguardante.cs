using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.Resguardante;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatResguardante : DatCatalogoGenerico<EntResguardante>, IDatResguardante
    {
        public DatResguardante(AppDbContext context, ILogger<Dat<EntResguardante>> logger) : base(context, logger)
        {
        }
    }
}
