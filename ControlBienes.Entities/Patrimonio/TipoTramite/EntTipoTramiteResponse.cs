using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.TipoTramite
{
    public class EntTipoTramiteResponse
    {
        public long IdTipoTramite { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long IdSubModulo { get; set; }
    }
}
