using AutoMapper;
using ControlBienes.Data.Contrats;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Seguridad.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Linq.Expressions;

namespace ControlBienes.Data.Repository
{
    public class Dat<T> : IDat<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly ILogger<Dat<T>> _logger;

		public Dat(AppDbContext context, ILogger<Dat<T>> logger)
        {
            _context = context;
            _logger = logger;
		}

        public virtual async Task<int> DActualizarAsync(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

		public virtual async Task<int> DCrearAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.Entry(entity).State = EntityState.Added;
            return await _context.SaveChangesAsync();
        }

		public virtual async Task<int> DActualizarListaAsync(IEnumerable<T> entities)
		{
			foreach (var entity in entities)
			{
				_context.Set<T>().Attach(entity);
				_context.Entry(entity).State = EntityState.Modified;
			}

			return await _context.SaveChangesAsync();
		}

		public virtual async Task<int> DCrearListaAsync(IEnumerable<T> entities)
		{
			foreach (var entity in entities)
			{
				_context.Set<T>().Add(entity);
				_context.Entry(entity).State = EntityState.Added;
			}

			return await _context.SaveChangesAsync();
		}

		public virtual async Task<T?> DObtenerRegistroAsync(
            Expression<Func<T, bool>>? predicado = null,
            List<Expression<Func<T, object>>>? incluir = null,
            bool desactivarTracking = true
        )
        {
            IQueryable<T> consulta = _context.Set<T>();
            if (desactivarTracking) consulta = consulta.AsNoTracking();
            if (incluir != null) consulta = incluir.Aggregate(consulta, (consultaBase, include) => consultaBase.Include(include));
            if (predicado != null) consulta = consulta.Where(predicado);
            return await consulta.FirstOrDefaultAsync();
        }

        public virtual async Task<T?> DObtenerRegistroAsync(long id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<bool> DExisteRegistroAsync(Expression<Func<T, bool>> predicado)
        {
            return await _context.Set<T>().AnyAsync(predicado);
        }

        public virtual async Task<IReadOnlyList<T>> DObtenerTodosAsync(
            List<Expression<Func<T, object>>>? incluir = null,
            Expression<Func<T, bool>>? predicado = null,
            bool desactivarTracking = true)
        {
            IQueryable<T> consulta = _context.Set<T>();
            if (desactivarTracking) consulta = consulta.AsNoTracking();
            if (incluir != null) consulta = incluir.Aggregate(consulta, (consultaBase, include) => consultaBase.Include(include));
            if (predicado != null) consulta = consulta.Where(predicado);
            return await consulta.ToListAsync();
        }

		public virtual async Task<IDbContextTransaction> DBeginTransactionAsync()
		{
			return await _context.Database.BeginTransactionAsync();
		}

        public virtual async Task<int> DGuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual bool DObtenerEntidadesRastreadas(T entidad)
        {
			// Recorrer todas las entradas rastreadas en el ChangeTracker
			foreach (var entry in _context.ChangeTracker.Entries())
			{
				// Verificar si la entidad está siendo rastreada (no tiene estado Detached)
				if (entry.State != EntityState.Detached)
				{
					// Obtener el nombre de la entidad y su estado
					string nombreEntidad = entry.Entity.GetType().Name;
					string estado = entry.State.ToString();

					// Loguear la información
					_logger.LogInformation($"Entidad: {nombreEntidad}, Estado: {estado}");
				}
			}
            return true;


		}

		public async Task<bool> DExistenRegistrosAsync(IEnumerable<long> ids, Func<T, long> idSelector) 
		{
            if (ids == null || !ids.Any()) return true;
			var allEntities = await _context.Set<T>().ToListAsync();
			var existingIds = allEntities.Select(idSelector).ToHashSet();
			return ids.All(id => existingIds.Contains(id));
		}

		public void DQuitarRastreo(T entidad)
		{
			_context.Entry(entidad).State = EntityState.Detached;
		}
	}
}
