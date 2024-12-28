using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;


namespace ControlBienes.Data.Contrats
{
    public interface IDat<T> where T : class
    {
        Task<int> DCrearAsync(T entidad);
		Task<int> DActualizarAsync(T entidad);
        Task<IReadOnlyList<T>> DObtenerTodosAsync(
            List<Expression<Func<T, object>>>? incluir = null,
            Expression<Func<T, bool>>? predicado = null,
            bool desactivarTracking = true
        );
        Task<T?> DObtenerRegistroAsync(
            Expression<Func<T, bool>>? predicado = null,
            List<Expression<Func<T, object>>>? incluir = null,
            bool desactivarTracking = true
        );
        Task<T?> DObtenerRegistroAsync(long id);
        Task<bool> DExisteRegistroAsync(Expression<Func<T, bool>> predicado);
		Task<IDbContextTransaction> DBeginTransactionAsync();
        Task<int> DGuardarCambiosAsync();
        bool DObtenerEntidadesRastreadas(T entidad);

	}
}
