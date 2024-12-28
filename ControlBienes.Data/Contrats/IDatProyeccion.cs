using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Contrats
{
	public interface IDatProyeccion<T> : IDat<T> where T : class
	{
		Task<TDto?> DObtenerProyeccionElementoAsync<TDto>(
			   Expression<Func<T, bool>> predicado,
			   Func<IQueryable<T>, IQueryable<T>>? configuracionAdicional = null,
			   bool desactivarTracking = true);
		Task<IReadOnlyList<TDto>> DObtenerProyeccionListaAsync<TDto>(
			   Expression<Func<T, bool>> predicado = null,
			   Func<IQueryable<T>, IQueryable<T>>? configuracionAdicional = null,
			   bool desactivarTracking = true);
	}
}
