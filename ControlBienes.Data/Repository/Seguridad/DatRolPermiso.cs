using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Seguridad.RolPermiso;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Seguridad
{
    public class DatRolPermiso : Dat<EntRolPermiso>, IDatRolPermiso
    {
        public DatRolPermiso(AppDbContext context, ILogger<Dat<EntRolPermiso>> logger) : base(context, logger)
        {
        }
    }
}
