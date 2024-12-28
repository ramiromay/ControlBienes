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

    public class EntDocumentoRequest
    {
        public string Abreviacion { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public long? IdSubModulo { get; set; } = 0;
        public long? IdTipoTramite { get; set; } = 0;
        public long? IdMotivoTramite { get; set; } = 0;
    }
}
