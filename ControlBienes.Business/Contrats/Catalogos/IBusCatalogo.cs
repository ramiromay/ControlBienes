using ControlBienes.Business.Genericos;

namespace ControlBienes.Business.Contrats.Catalogs
{
    public interface IBusCatalogo<TRequest, TResponse>
        where TRequest : class
        where TResponse : class
    {
        Task<EntityResponse<int>> BCrearAsync(TRequest request);
        Task<EntityResponse<int>> BActualizarAsync(long id, TRequest request);
        Task<EntityResponse<int>> BCambiarEstatusAsync(long id);
        Task<EntityResponse<IEnumerable<TResponse>>> BObtenerTodosAsync();
        Task<EntityResponse<TResponse>> BObtenerRegistroAsync(long id);

    }
}
