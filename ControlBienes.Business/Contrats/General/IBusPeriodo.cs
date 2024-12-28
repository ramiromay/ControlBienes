using ControlBienes.Business.Genericos;
using ControlBienes.Entities.General.Periodo;
using ControlBienes.Entities.Sistema.Catalogo.Catalogo;

namespace ControlBienes.Business.Contrats.General
{
    public interface IBusPeriodo
    {
        Task<EntityResponse<IEnumerable<EntPeriodoResponse>>> BObtenerPeriodosAsync();
    }
}
