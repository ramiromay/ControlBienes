using ControlBienes.Business.Genericos;
using ControlBienes.Entities.General.Periodo;
using ControlBienes.Entities.General.TipoResponsable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.General
{
    public interface IBusTipoResponsable
    {
        Task<EntityResponse<IEnumerable<EntTipoResponsableResponse>>> BObtenerTodosTipoResponsableAsync();
    }
}
