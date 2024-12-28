using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.MotivoTramite
{
    public class EntMotivoTramiteResponse
    {
        public long? IdMotivoTramite { get; set; } = null;
        public string Nombre { get; set; } = null;
        public string Descripcion { get; set; } = null;
        public long? IdTipoTramite { get; set; } = null;
    }
}
