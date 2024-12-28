using ControlBienes.Data.Contrats;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Genericos;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository
{
	public class DatCatalogoGenerico<T> : Dat<T>, IDatCatalogoGenerico<T> where T : EntCatalogoGenerico
	{
		public DatCatalogoGenerico(AppDbContext context, ILogger<Dat<T>> logger) : base(context, logger)
		{
		}

		public async Task<int> DActualizarEstatusAsync(T entidad)
		{
			_context.Set<T>().Attach(entidad);
			entidad.bActivo = !entidad.bActivo;
			_context.Entry(entidad).Property(e => e.bActivo).IsModified = true;
			return await _context.SaveChangesAsync();
		}

		public override async Task<int> DCrearAsync(T entity)
		{
			entity.bActivo = true;
			return await base.DCrearAsync(entity);
		}
	}
}
