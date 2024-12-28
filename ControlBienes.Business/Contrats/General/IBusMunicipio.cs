using ControlBienes.Business.Genericos;
using ControlBienes.Entities.General.Municipio;

namespace ControlBienes.Business.Contrats.General
{
    public interface IBusMunicipio
    {
        Task<EntityResponse<IEnumerable<EntMunicipioResponse>>> BObtenerTodosMunicipiosAsync();
    }
}
