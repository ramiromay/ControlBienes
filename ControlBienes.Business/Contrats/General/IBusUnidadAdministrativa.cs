using ControlBienes.Business.Genericos;
using ControlBienes.Entities.General.UnidadAdministrativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.General
{
    public interface IBusUnidadAdministrativa
    {
        public Task<EntityResponse<IEnumerable<EntUnidadAdministrativaResponse>>> BObtenerTodosUnidadesAdministrativasAsync(int desdeNivel, int hastaNivel);
    }
}
