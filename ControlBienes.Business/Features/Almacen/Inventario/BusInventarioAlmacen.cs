using ControlBienes.Business.Contrats.Almacen;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Patrimonio.InventarioInmueble;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Almacen;
using ControlBienes.Entities.Almacen.Bien;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Almacen.Inventario
{
	public class BusInventarioAlmacen : IBusInventarioAlmacen
	{
		private readonly IDatBienAlmacen _repoBienAlmacen;
		private readonly ILogger<BusInventarioAlmacen> _logger;
		private const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkTramiteMueble;
		private const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorTramiteMueble;

		public BusInventarioAlmacen(IDatBienAlmacen repoBienAlmacen, ILogger<BusInventarioAlmacen> logger)
		{
			_repoBienAlmacen = repoBienAlmacen;
			_logger = logger;
		}


		public async Task<EntityResponse<IEnumerable<EntBienAlmacenResponse>>> BObtenerBienesPorFiltroAsync(long? periodo, long? almacen, bool? busquedaPorFecha, DateTime? fechaInicio, DateTime? fechaFin)
		{
			var nombreMetodo = nameof(BObtenerBienesPorFiltroAsync);
			var resultado = new EntityResponse<IEnumerable<EntBienAlmacenResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar los bienes en el inventario");
			try
			{
				if (!periodo.HasValue)
					throw new BusConflictoException("Se requiere el periodo");

				if (!almacen.HasValue)
					throw new BusConflictoException("Se requiere el almacen");

				var filtro = new List<Expression<Func<EntBienAlmacen, bool>>>()
				{
					e => e.iIdPeriodo == periodo.Value && 
						(almacen.Value == 0 || e.iIdAlmacen == almacen.Value)
				};

				if (busquedaPorFecha.HasValue && busquedaPorFecha.Value)
				{
					if (!fechaInicio.HasValue || !fechaFin.HasValue)
						throw new BusConflictoException("Se requiere la fecha de inicio y la fecha de fin");

					filtro.Add(e => e.dtFechaCreacion.Date >= fechaInicio.Value.Date &&
					e.dtFechaCreacion.Date <= fechaFin.Value.Date);
				}
				var predicado = BusExpressionUtils.UCombinarExpression(filtro);
				var responseDto = await _repoBienAlmacen.DObtenerProyeccionListaAsync<EntBienAlmacenResponse>(predicado: predicado)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntBienAlmacenResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar los bienes en el inventario"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<EntBienAlmacenResponse>> BObtenerBienPorIdAsync(long idBien)
		{
			var nombreMetodo = nameof(BObtenerBienPorIdAsync);
			var resultado = new EntityResponse<EntBienAlmacenResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el bien");
			try
			{
				var responseDto = await _repoBienAlmacen.DObtenerProyeccionElementoAsync<EntBienAlmacenResponse>(e => e.iIdBien == idBien)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntBienAlmacenResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el bien"
				);
			}

			return resultado;
		}
	}
}
