using AutoMapper;
using ControlBienes.Data.Contrats;
using ControlBienes.Data.Persistence;
using ControlBienes.Data.Repository.Catalogos;
using ControlBienes.Entities.Genericos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository
{
	public class DatProyeccion<T> : Dat<T>, IDatProyeccion<T> where T : class
	{

		private readonly IMapper _mapper;

		public DatProyeccion(AppDbContext context, ILogger<Dat<T>> logger, IMapper mapper) : base(context, logger)
		{
			_mapper = mapper;
		}

		public virtual async Task<TDto?> DObtenerProyeccionElementoAsync<TDto>(
			Expression<Func<T, bool>> predicado,
			Func<IQueryable<T>, IQueryable<T>>? configuracionAdicional = null,
			bool desactivarTracking = true)
		{
			IQueryable<T> consulta = _context.Set<T>();

			if (desactivarTracking)
			{
				consulta = consulta.AsNoTracking();
			}

			if (configuracionAdicional != null)
			{
				consulta = configuracionAdicional(consulta);
			}

			consulta = consulta.Where(predicado);

			return await _mapper.ProjectTo<TDto>(consulta).FirstOrDefaultAsync();
		}

		public virtual async  Task<IReadOnlyList<TDto>> DObtenerProyeccionListaAsync<TDto>(
			Expression<Func<T, bool>> predicado = null, 
			Func<IQueryable<T>, 
			IQueryable<T>> configuracionAdicional = null, 
			bool desactivarTracking = true)
		{
			IQueryable<T> consulta = _context.Set<T>();

			if (desactivarTracking)
			{
				consulta = consulta.AsNoTracking();
			}

			if (predicado != null)
			{
				consulta = consulta.Where(predicado);
			}

			if (configuracionAdicional != null)
			{
				consulta = configuracionAdicional(consulta);
			}

			return await _mapper.ProjectTo<TDto>(consulta).ToListAsync();
		}
	}
}
