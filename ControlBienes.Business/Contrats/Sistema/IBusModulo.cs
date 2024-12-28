using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Sistema.Modulo.Modulo;

namespace ControlBienes.Business.Contrats.Sistema
{
    public interface IBusModulo
    {
        Task<EntityResponse<IEnumerable<EntModuloResponse>>> BObtenerTodosModulos();
    }
}
