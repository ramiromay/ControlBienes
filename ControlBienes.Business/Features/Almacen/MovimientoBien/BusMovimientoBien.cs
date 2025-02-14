using AutoMapper;
using ControlBienes.Business.Contrats.Almacen;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Almacen;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Entities.Almacen.Bien;
using ControlBienes.Entities.Almacen.Movimiento;
using ControlBienes.Entities.Almacen.MovimientoBien;
using ControlBienes.Entities.Catalogos.Almacen;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.General.BMS;
using ControlBienes.Entities.Patrimonio.Etapa;
using ControlBienes.Entities.Patrimonio.Solicitud;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Almacen.EntradaSalida
{
	public class BusMovimientoBien : IBusMovimientoBien
	{
		private readonly IDatEtapaMovimiento _repoEtapaMovimiento;
		private readonly IDatBienAlmacen _repoBienAlmacen;
		private readonly IDatBms _repoBms;
		private readonly IDatMovimiento _repoMovimiento;
		private readonly ILogger<BusMovimientoBien> _logger;
		private readonly IMapper _mapper;
		private readonly IValidator<EntMovimientoBienRequest> _validator;
		const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkCaracteristicaBien;
		const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorCaracteristicaBien;

		public BusMovimientoBien(IDatEtapaMovimiento repoEtapaMovimiento, ILogger<BusMovimientoBien> logger, IMapper mapper, IValidator<EntMovimientoBienRequest> validator, IDatMovimiento repoMovimiento, IDatBienAlmacen repoBienAlmacen, IDatBms repoBms)
		{
			_repoEtapaMovimiento = repoEtapaMovimiento;
			_repoMovimiento = repoMovimiento;
			_logger = logger;
			_mapper = mapper;
			_validator = validator;
			_repoBienAlmacen = repoBienAlmacen;
			_repoBms = repoBms;
		}

		private void BValidarRequest(EntMovimientoBienRequest request)
		{
			var resultadoValidacion = _validator.Validate(request);
			if (resultadoValidacion.IsValid) return;
			var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
		}

		public async Task<EntityResponse<int>> BActualizarMovimientoAsync(long idMovimiento, EntMovimientoBienRequest request)
		{
			string nombreMetodo = nameof(BActualizarMovimientoAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoMovimiento.DBeginTransactionAsync();


			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un movimiento");
			try
			{
				BValidarRequest(request);

				var entidad = await _repoMovimiento.DObtenerRegistroAsync(idMovimiento)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);

				if (request.IdTipoMovimiento == 2)
				{
					var articulos = request.Articulos.Split("||");
					var articulosAnteriores = entidad.sArticulos.Split("||");

					var ids = new List<long>().ToHashSet();
					foreach (var articulo in articulos)
					{
						var parametros = articulo.Split("|");
						var valueId = parametros[0].Split(":")[1].Trim('\'');
						ids.Add(long.Parse(valueId));
					}
					var bienes = await _repoBienAlmacen.DObtenerTodosAsync(predicado: e => ids.Contains(e.iIdBien));
					foreach (var bien in bienes)
					{
						var cantidaOriginal = BObtenerCantidadArticulo(bien.iIdBien, articulosAnteriores);
						var cantida = BObtenerCantidadArticulo(bien.iIdBien, articulos);
						var cantidaDescuento = cantidaOriginal - cantida;

						if (cantidaDescuento < 0)
						{
							if (bien.iExistencia < Math.Abs(cantidaDescuento))
							{
								throw new BusConflictoException($"No existe suficiente stock para el Articulo con el ID:  {bien.iIdBms}");
							}
							bien.iExistencia -= Math.Abs(cantidaDescuento);
						}
						else
						{
							bien.iExistencia += Math.Abs(cantidaDescuento);
						}
					}
					await _repoBienAlmacen.DActualizarListaAsync(bienes);
				}

				entidad.iIdAlmacen = request.IdAlmacen.Value;
				entidad.iIdTipoMovimiento = request.IdTipoMovimiento.Value;
				entidad.dtFechaResepcion = request.FechaResepcion;
				entidad.iIdFamilia = request.IdFamilia.Value;
				entidad.iIdMetodoAdquisicion = request.IdMetodoAdquisicion.Value;
				entidad.iIdProgramaOperativo = request.IdProgramaOperativo;
				entidad.iIdConceptoMovimiento = request.IdConceptoMovimiento.Value;
				entidad.iIdProveedor = request.IdProveedor;
				entidad.sNumeroFactura = request.NumeroFactura;
				entidad.sObservaciones = request.Observaciones;
				entidad.dtFechaModificacion = DateTime.Now;
				entidad.sArticulos = request.Articulos;
				entidad.dImporteTotal = BusTransformarUtils.UCalcularImporteTotal(request.Articulos);
		
				var responseActualizacionMovimento = await _repoMovimiento.DActualizarAsync(entidad);
				await transaction.CommitAsync();
				resultado.Success(responseActualizacionMovimento, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar actualiza el movimiento"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<IEnumerable<EntEtapaResponse>>> BObtenerEtapasPorMovimientoAsync(long? idMovimiento)
		{
			var nombreMetodo = nameof(BObtenerEtapasPorMovimientoAsync);
			var resultado = new EntityResponse<IEnumerable<EntEtapaResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar las etapas siguientes de la solicitud");
			try
			{
				if (idMovimiento == null || idMovimiento.Value == 0)
					throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, "Se requiere el ID de la Solicitud");

				var movimiento = await _repoMovimiento.DObtenerRegistroAsync(idMovimiento.Value)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);

				var etapasSiguientes = await _repoEtapaMovimiento.DObtenerProyeccionListaAsync<EntEtapaResponse>(e => e.iIdEtapaOrigen == movimiento.iIdEtapa);

				resultado.Success(etapasSiguientes, _code);

			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntEtapaResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar las etapas siguientes de la solicitud"
				);
			}

			return resultado;
		}

		private int BObtenerCantidadArticulo(long id, string[] articulos)
		{
			var cantidad = 0;
			foreach (var articulo in articulos)
			{
				var parametros = articulo.Split("|");
				var valueId = parametros[0].Split(":")[1].Trim('\'');
				var valueCantidad = parametros[2].Split(":")[1].Trim('\'');

				var idBms = long.Parse(valueId);
				cantidad = int.Parse(valueCantidad);
				if (idBms == id)
				{
					return cantidad;
				}
			}
			return cantidad;
		}

		private async Task BAplicarVOBO(EntMovimiento entidad)
		{
			if (entidad.iIdTipoMovimiento == 1)
			{
				var articulos = entidad.sArticulos.Split("||");
				var ids = new List<long>().ToHashSet();
				foreach (var articulo in articulos)
				{
					var parametros = articulo.Split("|");
					var valueId = parametros[0].Split(":")[1].Trim('\'');
					ids.Add(long.Parse(valueId));
				}
				var bienes = await _repoBienAlmacen.DObtenerTodosAsync(predicado: e => ids.Contains(e.iIdBms) && e.iIdAlmacen == entidad.iIdAlmacen);
				foreach (var bien in bienes)
				{
					bien.iExistencia += BObtenerCantidadArticulo(bien.iIdBms, articulos);
				}
				await _repoBienAlmacen.DActualizarListaAsync(bienes);

				var idsEncontrados = bienes.Select(b => b.iIdBms).ToHashSet();
				var idsNoEncontrados = ids.Where(id => !idsEncontrados.Contains(id)).ToList();
				var listaBms = await _repoBms.DObtenerTodosAsync(predicado: e => idsNoEncontrados.Contains(e.iIdBms));
				var nuevosBienes = new List<EntBienAlmacen>();
				foreach (var bms in listaBms)
				{
					nuevosBienes.Add(new EntBienAlmacen()
					{
						iIdBms = bms.iIdBms,
						iExistencia = BObtenerCantidadArticulo(bms.iIdBms, articulos),
						nCodigoArmonizado = bms.nCodigoArmonizado,
						iIdAlmacen = entidad.iIdAlmacen,
						iIdFamilia = entidad.iIdFamilia.Value,
						sDescripcion = bms.sNombre.ToString(),
						sUnidadMedida = bms.sUnidadMedida,
						iIdPeriodo = entidad.iIdPeriodo
					});
				}
				await _repoBienAlmacen.DCrearListaAsync(nuevosBienes);
			}
		}

		private async Task BAplicarRechazo(EntMovimiento entidad)
		{
			if (entidad.iIdTipoMovimiento == 2)
			{
				var articulos = entidad.sArticulos.Split("||");
				var ids = new List<long>().ToHashSet();
				foreach (var articulo in articulos)
				{
					var parametros = articulo.Split("|");
					var valueId = parametros[0].Split(":")[1].Trim('\'');
					ids.Add(long.Parse(valueId));
				}
				var bienes = await _repoBienAlmacen.DObtenerTodosAsync(predicado: e => ids.Contains(e.iIdBien) && e.iIdAlmacen == entidad.iIdAlmacen);
				foreach (var bien in bienes)
				{
					bien.iExistencia += BObtenerCantidadArticulo(bien.iIdBms, articulos);
				}
				await _repoBienAlmacen.DActualizarListaAsync(bienes);
			}
			
		}

		public async Task<EntityResponse<int>> BCambiarEtapaMovimientoAsync(long idMovimiento, long? etapa)
		{
			var nombreMetodo = nameof(BCambiarEtapaMovimientoAsync);
			var resultado = new EntityResponse<int>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para cambiar la etapa");
			try
			{
				if (!etapa.HasValue)
					throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, "La Etapa a la que quiere cambiar es requerida");

				var entidad = await _repoMovimiento.DObtenerRegistroAsync(idMovimiento)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				var etapaSiguienteCorrecta = await _repoEtapaMovimiento.DValidarCambioEtapaAsync(entidad, etapa.Value);

				if (!etapaSiguienteCorrecta)
					throw new BusConflictoException("No se permite avanzar a esta etapa desde la etapa actual");

				if (etapa.Value == (long)EnumEtapa.VOBO)
					await BAplicarVOBO(entidad);

				else if (etapa.Value == (long)EnumEtapa.Rechazo)
					await BAplicarRechazo(entidad);

				var result = await _repoMovimiento.DCambiarEtapaAsync(entidad, etapa.Value);
				resultado.Success(result, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar cambiar la etapa"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BCrearMovimientoAsync(EntMovimientoBienRequest request)
		{
			string nombreMetodo = nameof(BCrearMovimientoAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoMovimiento.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un movimiento");
			try
			{
				BValidarRequest(request);
				var entidad = _mapper.Map<EntMovimiento>(request);
				var responseCrearMovimiento = await _repoMovimiento.DCrearAsync(entidad);

				if (entidad.iIdTipoMovimiento == 2)
				{
					var articulos = entidad.sArticulos.Split("||");
					var ids = new List<long>().ToHashSet();
					foreach (var articulo in articulos)
					{
						var parametros = articulo.Split("|");
						var valueId = parametros[0].Split(":")[1].Trim('\'');
						ids.Add(long.Parse(valueId));
					}
					var bienes = await _repoBienAlmacen.DObtenerTodosAsync(predicado: e => ids.Contains(e.iIdBien) && e.iIdAlmacen == entidad.iIdAlmacen);
					foreach (var bien in bienes)
					{
						var cantida = BObtenerCantidadArticulo(bien.iIdBien, articulos);
						if (bien.iExistencia < cantida)
						{
							throw new BusConflictoException($"No existe suficiente stock para el Articulo con el ID:  {bien.iIdBms}");
						}
						bien.iExistencia -= cantida;
					}
					await _repoBienAlmacen.DActualizarListaAsync(bienes);
				}

				await transaction.CommitAsync();
				resultado.Success(responseCrearMovimiento, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar crear el movimiento"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<EntMovimientoBienResponse>> BObtenerMovimientoAsync(long idMovimiento)
		{
			var nombreMetodo = nameof(BObtenerMovimientoAsync);
			var resultado = new EntityResponse<EntMovimientoBienResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el movimiento");
			try
			{
				var responseDto = await _repoMovimiento.DObtenerProyeccionElementoAsync<EntMovimientoBienResponse>(cb => cb.iIdMovimiento == idMovimiento)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntMovimientoBienResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el movimiento"
				);
			}

			return resultado;
		}

		private void BValidarParametrosConsulta(
			long? periodo,
			bool busquedaPorFechaActivada,
			DateTime? fechaInicio,
			DateTime? fechaFin)
		{

			if (!periodo.HasValue)
				throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, "Se requiere el Periodo");

			if (busquedaPorFechaActivada)
			{
				if (!fechaInicio.HasValue || !fechaFin.HasValue)
					throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, "Se requiere la Fecha de Inicio y de Fin");

				if (fechaInicio.Value.Date > fechaFin.Value.Date)
					throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, "La Fecha de Inicio no puede ser mayor a la Fecha de Fin");
			}
		}

		public async Task<EntityResponse<IEnumerable<EntMovimientoBienResponse>>> BObtenerMovimientosPorFiltroAsync(long? periodo, bool? busquedaPorFecha, DateTime? fechaInicio, DateTime? fechaFin, long? almacen)
		{
			var nombreMetodo = nameof(BObtenerMovimientosPorFiltroAsync);
			var resultado = new EntityResponse<IEnumerable<EntMovimientoBienResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los movimientos");
			try
			{
				bool busquedaPorFechaActivada = busquedaPorFecha.HasValue && busquedaPorFecha.Value;
				BValidarParametrosConsulta(periodo, busquedaPorFechaActivada,
					fechaInicio, fechaFin);

				Expression<Func<EntMovimiento, bool>> filtro = e =>
					e.iIdPeriodo == periodo &&
					(almacen == 0 ||
						e.iIdAlmacen == almacen &&
					(!busquedaPorFechaActivada ||
						e.dtFechaCreacion.Date >= fechaInicio.Value.Date &&
						e.dtFechaCreacion.Date <= fechaFin.Value.Date));

				var resultListDto = await _repoMovimiento.DObtenerProyeccionListaAsync<EntMovimientoBienResponse>(filtro);
				resultado.Success(resultListDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntMovimientoBienResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todos los movimientos"
				);
			}

			return resultado;
		}
	}
}
