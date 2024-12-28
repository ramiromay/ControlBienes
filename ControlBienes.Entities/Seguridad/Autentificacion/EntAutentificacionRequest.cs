using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Seguridad.Autentificacion
{
     public class EntAutentificacionRequest
     {
          public string Usuario { get; set; } = null;
          public string Contrasenia { get; set; } = null;
          public bool Recordarme { get; set; } = false;
     }
}
