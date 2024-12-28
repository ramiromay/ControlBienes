using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Sistema.ColumnaTabla;
using ControlBienes.Entities.Sistema.SubModulo.SubModulo;

namespace ControlBienes.Business.Contrats.Sistema
{
    public interface IBusSubModulo
    {
        Task<EntityResponse<IEnumerable<EntSubModuloResponse>>> BObtenerTodosSubModulos();
    }
}
