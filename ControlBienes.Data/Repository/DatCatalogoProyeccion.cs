using AutoMapper;
using ControlBienes.Data.Contrats;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Genericos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository
{
	public class DatCatalogoProyeccion<T> : DatProyeccion<T>, IDatCatalogoProyeccion<T> where T : EntCatalogoGenerico
	{
		private readonly IDatCatalogoGenerico<T> _repositorio;

		public DatCatalogoProyeccion(AppDbContext context, ILogger<Dat<T>> logger, IMapper mapper, IDatCatalogoGenerico<T> repositorio) : base(context, logger, mapper)
		{
			_repositorio = repositorio;
		}

		public Task<int> DActualizarEstatusAsync(T entidad)
		{
			return _repositorio.DActualizarEstatusAsync(entidad);
		}

		public override Task<int> DCrearAsync(T entity)
		{
			entity.bActivo = true;
			return base.DCrearAsync(entity);
		}

	}
}
