using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.MotivoTramite;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
    public class DatMotivoTramite : Dat<EntMotivoTramite>, IDatMotivoTramite
    {
        public DatMotivoTramite(AppDbContext context, ILogger<Dat<EntMotivoTramite>> logger) : base(context, logger)
        {
        }
    }
}
