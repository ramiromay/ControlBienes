using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Sistema.Catalogo.Catalogo;

namespace ControlBienes.Business.Contrats.Sistema
{
    public interface IBusCatalogo
    {
        Task<EntityResponse<IEnumerable<EntCatalogoResponse>>> BObtenerCatalogosAsync(long id);
    }
}
