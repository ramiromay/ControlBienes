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
    public class EntTitularResponse
    {
        public long? IdTitular { get; set; } = null;
        public string Nombre { get; set; } = null;
        public long? IdCentroTrabajoTurno { get; set; } = null;
        public string CentroTrabajo { get; set; } = null;
        public string Turno { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
