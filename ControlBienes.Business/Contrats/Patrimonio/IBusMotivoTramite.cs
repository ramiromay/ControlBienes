using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.MotivoTramite;

namespace ControlBienes.Business.Contrats.Patrimonio
{
    public interface IBusMotivoTramite
    {
        Task<EntityResponse<IEnumerable<EntMotivoTramiteResponse>>> BObtenerTodosMotivosTramites();
    }
}
