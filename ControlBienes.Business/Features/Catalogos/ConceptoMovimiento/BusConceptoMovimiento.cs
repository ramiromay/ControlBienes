using AutoMapper;
using ControlBienes.Business.Contrats.Catalogos;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.Almacen;
using ControlBienes.Entities.Catalogos.ConceptoMovimiento;
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

namespace ControlBienes.Business.Features.Catalogos.ConceptoMovimiento
{
	public class BusConceptoMovimiento : IBusConceptoMovimiento
	{
		private readonly IDatConceptoMovimiento _reroConcepto;
		private readonly ILogger<BusConceptoMovimiento> _logger;
		private readonly IValidator<EntConceptoMovimientoRequest> _validator;
		private readonly IMapper _mapper;
		const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkCaracteristicaBien;
		const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorCaracteristicaBien;

		public BusConceptoMovimiento(IDatConceptoMovimiento reroConcepto, ILogger<BusConceptoMovimiento> logger, IMapper mapper, IValidator<EntConceptoMovimientoRequest> validator)
		{
			_reroConcepto = reroConcepto;
			_logger = logger;
			_mapper = mapper;
			_validator = validator;
		}

		private void BValidarRequest(EntConceptoMovimientoRequest request)
		{
			var resultadoValidacion = _validator.Validate(request);
			if (resultadoValidacion.IsValid) return;
			var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
		}

		public async Task<EntityResponse<int>> BActualizarAsync(long id, EntConceptoMovimientoRequest request)
		{
			string nombreMetodo = nameof(BActualizarAsync);
			var resultado = new EntityResponse<int>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un concepto");
			try
			{
				BValidarRequest(request);
				var entidad = await _reroConcepto.DObtenerRegistroAsync(id)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				entidad.iIdTipoMovimiento = request.IdTipoMovimiento.Value;
				entidad.sNombre = request.Nombre;
				entidad.sDescripcion = request.Descripcion;
			
				var response = await _reroConcepto.DActualizarAsync(entidad);
				resultado.Success(response, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar actualiza el concepto"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
		{
			string nombreMetodo = nameof(BCambiarEstatusAsync);
			var resultado = new EntityResponse<int>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus del concepto");
			try
			{
				var entidad = await _reroConcepto.DObtenerRegistroAsync(id)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				var response = await _reroConcepto.DActualizarEstatusAsync(entidad);
				resultado.Success(response, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar actualizar el estatus del concepto"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BCrearAsync(EntConceptoMovimientoRequest request)
		{
			string nombreMetodo = nameof(BCrearAsync);
			var resultado = new EntityResponse<int>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un conceto");
			try
			{
				BValidarRequest(request);
				var entidad = _mapper.Map<EntConceptoMovimiento>(request);
				resultado.Result = await _reroConcepto.DCrearAsync(entidad);
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
					"Ocurrio un error al intentar crear el concepto"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<EntConceptoMovimientoResponse>> BObtenerRegistroAsync(long id)
		{
			var nombreMetodo = nameof(BObtenerTodosAsync);
			var resultado = new EntityResponse<EntConceptoMovimientoResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el almacen");
			try
			{
				var responseDto = await _reroConcepto.DObtenerProyeccionElementoAsync<EntConceptoMovimientoResponse>(cb => cb.iIdConceptoMovimiento == id)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntConceptoMovimientoResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el almacen"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<IEnumerable<EntConceptoMovimientoResponse>>> BObtenerTodosAsync(bool? activo)
		{
			var nombreMetodo = nameof(BObtenerTodosAsync);
			var resultado = new EntityResponse<IEnumerable<EntConceptoMovimientoResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los conceptos");
			try
			{
				Expression<Func<EntConceptoMovimiento, bool>> predicado = activo.HasValue
					? r => r.bActivo == activo.Value
					: null;


				var responseDto = await _reroConcepto.DObtenerProyeccionListaAsync<EntConceptoMovimientoResponse>(predicado: predicado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntConceptoMovimientoResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todos los conceptos"
				);
			}

			return resultado;
		}
	}
}
