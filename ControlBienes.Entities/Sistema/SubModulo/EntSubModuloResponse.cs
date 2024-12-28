using ControlBienes.Entities.Sistema.Modulo.Modulo;
using ControlBienes.Entities.Sistema.Seccion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Sistema.SubModulo.SubModulo
{
    public class EntSubModuloResponse
    {
        public long? IdSubModulo { get; set; } = null;
        public string Nombre { get; set; } = null;
        public string Abreviacion { get; set; } = null;
        public long? IdModulo { get; set; } = null;
        public long? IdSeccion { get; set; } = null;
    }
}
