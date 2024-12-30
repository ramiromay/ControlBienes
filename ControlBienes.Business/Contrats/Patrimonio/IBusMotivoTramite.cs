using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.MotivoTramite;
using ControlBienes.Entities.Sistema.SubModulo.SubModulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Patrimonio
{
    public interface IBusMotivoTramite
    {
        Task<EntityResponse<IEnumerable<EntMotivoTramiteResponse>>> BObtenerTodosMotivosTramites();
    }
}
