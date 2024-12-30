using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.TipoTramite;
using ControlBienes.Entities.Sistema.SubModulo.SubModulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Patrimonio
{
    public interface IBusTipoTramite
    {
        Task<EntityResponse<IEnumerable<EntTipoTramiteResponse>>> BObtenerTodosTiposTramites();
    }
}
