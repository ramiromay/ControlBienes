using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Entities.Catalogos.CentroTrabajo;
using ControlBienes.Entities.Sistema.Catalogo.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Catalogos
{
    public interface IBusCentroTrabajo : IBusCatalogo<EntCentroTrabajoRequest,EntCentroTrabajoResponse>
    {

    }
}
