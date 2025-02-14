using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Contrats
{
	public interface IUnitOfWork : IDisposable
	{
		IDat<T> GetRepository<T>() where T : class;
		IDatProyeccion<T> GetProyeccionRepository<T>() where T : class;
		IDatCatalogoGenerico<T> GetCatalogoGenericoRepository<T>() where T : EntCatalogoGenerico;
		IDatCatalogoProyeccion<T> GetCatalogoProyeccionRepository<T>() where T : EntCatalogoGenerico;
		Task<int> CommitAsync();
		Task RollbackAsync();
	}
}
