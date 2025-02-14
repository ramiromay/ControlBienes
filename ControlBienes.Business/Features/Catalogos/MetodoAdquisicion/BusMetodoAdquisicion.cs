using AutoMapper;
using ControlBienes.Business.Contrats.Catalogos;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Catalogos.Almacen;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.Almacen;
using ControlBienes.Entities.Catalogos.MetodoAdquisicion;
using ControlBienes.Entities.Constants;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Catalogos.MetodoAdquisicion
{
	public class BusMetodoAdquisicion : IBusMetodoAdquisicion
	{
		private readonly IDatMetodoAdquisicion _repoMetodo;
		private readonly IMapper _mapper;
		private readonly ILogger<BusMetodoAdquisicion> _logger;
		private readonly IValidator<EntMetodoAdquisicionRequest> _validator;
		const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkCaracteristicaBien;
		const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorCaracteristicaBien;

		public BusMetodoAdquisicion(IDatMetodoAdquisicion repoMetodo, IMapper mapper, ILogger<BusMetodoAdquisicion> logger, IValidator<EntMetodoAdquisicionRequest> validator)
		{
			_repoMetodo = repoMetodo;
			_mapper = mapper;
			_logger = logger;
			_validator = validator;
		}

		private void BValidarRequest(EntMetodoAdquisicionRequest request)
		{
			var resultadoValidacion = _validator.Validate(request);
			if (resultadoValidacion.IsValid) return;
			var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
		}

		public async Task<EntityResponse<int>> BActualizarAsync(long id, EntMetodoAdquisicionRequest request)
		{
			string nombreMetodo = nameof(BActualizarAsync);
			var resultado = new EntityResponse<int>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar el metodo");
			try
			{
				BValidarRequest(request);
				var entidad = await _repoMetodo.DObtenerRegistroAsync(id)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				
				entidad.sNombre = request.Nombre;
				var response = await _repoMetodo.DActualizarAsync(entidad);
				resultado.Success(response, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar actualiza el metodo"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
		{
			string nombreMetodo = nameof(BCambiarEstatusAsync);
			var resultado = new EntityResponse<int>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus del metodo");
			try
			{
				var entidad = await _repoMetodo.DObtenerRegistroAsync(id)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				var response = await _repoMetodo.DActualizarEstatusAsync(entidad);
				resultado.Success(response, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar actualizar el estatus del metodo"
				);
			}
			return resultado;
		}

		public async Task<EntityResponse<int>> BCrearAsync(EntMetodoAdquisicionRequest request)
		{
			string nombreMetodo = nameof(BCrearAsync);
			var resultado = new EntityResponse<int>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un metodo");
			try
			{
				BValidarRequest(request);
				var entidad = _mapper.Map<EntMetodoAdquisicion>(request);
				resultado.Result = await _repoMetodo.DCrearAsync(entidad);
				resultado.StatusCode = HttpStatusCode.OK;
				resultado.Message = EntMensajeConstant.OK;
				resultado.Code = _code;
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar crear el metodo"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<EntMetodoAdquisicionResponse>> BObtenerRegistroAsync(long id)
		{
			var nombreMetodo = nameof(BObtenerTodosAsync);
			var resultado = new EntityResponse<EntMetodoAdquisicionResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el metodo");
			try
			{
				var responseDto = await _repoMetodo.DObtenerProyeccionElementoAsync<EntMetodoAdquisicionResponse>(cb => cb.iIdMetodoAdquisicion == id)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntMetodoAdquisicionResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el metodo"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<IEnumerable<EntMetodoAdquisicionResponse>>> BObtenerTodosAsync(bool? activo)
		{
			var nombreMetodo = nameof(BObtenerTodosAsync);
			var resultado = new EntityResponse<IEnumerable<EntMetodoAdquisicionResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los metodos");
			try
			{
				Expression<Func<EntMetodoAdquisicion, bool>> predicado = activo.HasValue
					? r => r.bActivo == activo.Value
					: null;


				var responseDto = await _repoMetodo.DObtenerProyeccionListaAsync<EntMetodoAdquisicionResponse>(predicado: predicado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntMetodoAdquisicionResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todos los metodos"
				);
			}

			return resultado;
		}
	}
}
