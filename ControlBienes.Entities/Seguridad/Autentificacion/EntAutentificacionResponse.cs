using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Seguridad.Autentificacion
{
     public class EntAutentificacionResponse
     {
          public long? Id { get; set; } = null;
          public string Nombre { get; set; } = null;
          public string Usuario { get; set; } = null;
          public string Token { get; set; } = null;
          public string Rol { get; set; } = null;
          public IEnumerable<long> Permisos { get; set; }
     }
}
