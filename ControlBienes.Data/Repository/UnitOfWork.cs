using ControlBienes.Data.Contrats;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Genericos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository
{
	public class UnitOfWork : IUnitOfWork
	{

		private readonly AppDbContext _context;
		private readonly IServiceProvider _serviceProvider;

		public UnitOfWork(AppDbContext context,
			ILogger<UnitOfWork> logger,
			IServiceProvider serviceProvider)
		{
			_context = context;
			_serviceProvider = serviceProvider;
		}

		public IDat<T> GetRepository<T>() where T : class
		{
			return _serviceProvider.GetRequiredService<IDat<T>>();
		}

		public IDatCatalogoGenerico<T> GetCatalogoGenericoRepository<T>() where T : EntCatalogoGenerico
		{
			return _serviceProvider.GetRequiredService<IDatCatalogoGenerico<T>>();
		}

		public IDatProyeccion<T> GetProyeccionRepository<T>() where T : class
		{
			return _serviceProvider.GetRequiredService<IDatProyeccion<T>>();
		}

		public IDatCatalogoProyeccion<T> GetCatalogoProyeccionRepository<T>() where T : EntCatalogoGenerico
		{
			return _serviceProvider.GetRequiredService<IDatCatalogoProyeccion<T>>();
		}

		public async Task<int> CommitAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public async Task RollbackAsync()
		{
			foreach (var entry in _context.ChangeTracker.Entries())
			{
				switch (entry.State)
				{
					case EntityState.Added:
						entry.State = EntityState.Detached;
						break;
					case EntityState.Modified:
					case EntityState.Deleted:
						await entry.ReloadAsync();
						break;
				}
			}
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
