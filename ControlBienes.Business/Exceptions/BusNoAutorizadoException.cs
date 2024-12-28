using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Exceptions
{
     public class BusNoAutorizadoException : Exception
     {
          public BusNoAutorizadoException(string mensaje) : base(mensaje)
          {
          }
     }
}
