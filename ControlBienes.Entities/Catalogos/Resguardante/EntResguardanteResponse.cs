using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Catalogos.Resguardante
{
    public class EntResguardanteResponse
    {
        public long? IdResguardante { get; set; } = null;
        public long? IdPeriodo { get; set; } = null;
        public long? IdPersona { get; set; } = null;
        public string? Persona { get; set; } = null;
        public string? NivelUnidadAdministrativa { get; set; } = null;
        public string? UnidadAdministrativa { get; set; } = null;
        public string? Observaciones { get; set; } = null;
        public int? NoConvenio { get; set; } = null;
        public long? IdTipoResponsable { get; set; } = null;
        public string? TipoResponsable { get; set; } = null;
        public bool? Responsable { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
