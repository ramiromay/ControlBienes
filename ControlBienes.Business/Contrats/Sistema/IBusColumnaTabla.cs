using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Sistema.ColumnaTabla;

namespace ControlBienes.Business.Contrats.Sistema
{
    public interface IBusColumnaTabla
    {
        Task<EntityResponse<IEnumerable<EntColumnaTablaResponse>>> BObtenerColumnasTablaCatalogoAsync(long idCatalogo);
        Task<EntityResponse<IEnumerable<EntColumnaTablaResponse>>> BObtenerColumnasTablaSubModuloAsync(long idSubModulo);
    }
}
