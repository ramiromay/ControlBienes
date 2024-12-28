using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Seguridad.Usuario;
using ControlBienes.Entities.Seguridad.UsuarioPermiso;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Seguridad
{
    public class DatUsuario : Dat<EntUsuario>, IDatUsuario
    {
        public DatUsuario(AppDbContext context, ILogger<Dat<EntUsuario>> logger) : base(context, logger)
        {
        }
	}
}
