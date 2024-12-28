using ControlBienes.Entities.Catalogos.CentroTrabajoTurno;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlBienes.Entities.Genericos;

namespace ControlBienes.Entities.Catalogos.Titular
{
    public class EntTitularRequest
    {
        
        public string Nombre { get; set; } = string.Empty;
        public long? IdCentroTrabajoTurno { get; set; } = 0;
    }
}
