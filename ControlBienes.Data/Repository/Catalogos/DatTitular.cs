using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.Titular;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatTitular : DatCatalogoGenerico<EntTitular>, IDatTitular
    {
        public DatTitular(AppDbContext context, ILogger<Dat<EntTitular>> logger) : base(context, logger)
        {
        }
    }
}
