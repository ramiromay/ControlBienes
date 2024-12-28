using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Sistema.Modulo.Modulo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlBienes.Entities.Patrimonio.TipoTramite;
using ControlBienes.Entities.Patrimonio.MotivoTramite;

namespace ControlBienes.Entities.Catalogos.Documento
{

    public class EntDocumentoResponse
    {
        public long? IdDocumento { get; set; } = null;
        public string Abreviacion { get; set; } = null;
        public string Nombre { get; set; } = null;
        public long? IdSubModulo { get; set; } = null;
        public string SubModulo { get; set; } = null;
        public long? IdTipoTramite { get; set; } = null;
        public string TipoTramite { get; set; } = null;
        public long? IdMotivoTramite { get; set; } = null;
        public string MotivoTramite { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
