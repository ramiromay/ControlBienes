using AutoMapper;
using ControlBienes.Business.Contrats.Catalogos;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.Almacen;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
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

namespace ControlBienes.Business.Features.Catalogos.Almacen
{
	public class BusAlmacen : IBusAlmacen
	{
		private readonly IDatAlmacen _repoAlmacen;
		private readonly IMapper _mapper;
		private readonly ILogger<BusAlmacen> _logger;
		private readonly IValidator<EntAlmacenRequest> _validator;
		const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkCaracteristicaBien;
		const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorCaracteristicaBien;

		public BusAlmacen(IDatAlmacen repoAlmacen, IMapper mapper, ILogger<BusAlmacen> logger, IValidator<EntAlmacenRequest> validator)
		{
			_repoAlmacen = repoAlmacen;
			_mapper = mapper;
			_logger = logger;
			_validator = validator;
		}

		private void BValidarRequest(EntAlmacenRequest request)
		{
			var resultadoValidacion = _validator.Validate(request);
			if (resultadoValidacion.IsValid) return;
			var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
		}

		public async Task<EntityResponse<int>> BActualizarAsync(long id, EntAlmacenRequest request)
		{
			string nombreMetodo = nameof(BActualizarAsync);
			var resultado = new EntityResponse<int>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un almacen");
			try
			{
				BValidarRequest(request);
				var entidad = await _repoAlmacen.DObtenerRegistroAsync(id)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				entidad.iIdPeriodo = request.IdPeriodo.Value;
				entidad.iIdEmpleado = request.IdEmpleado.Value;
				entidad.sNombre = request.Nombre;
				entidad.sDireccion = request.Direccion;
				entidad.sHorario = request.Horario;
				entidad.iIdCuenta = request.IdCuenta.Value;
				entidad.iIdMetodoCosteo = request.IdMetodoCosteo.Value;
				entidad.sFolioEntrada = request.FolioEntrada;
				entidad.sFolioSalida = request.FolioSalida;
				var response = await _repoAlmacen.DActualizarAsync(entidad);
				resultado.Success(response, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar actualiza el almacen"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
		{
			string nombreMetodo = nameof(BCambiarEstatusAsync);
			var resultado = new EntityResponse<int>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus del almacen");
			try
			{
				var entidad = await _repoAlmacen.DObtenerRegistroAsync(id)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				var response = await _repoAlmacen.DActualizarEstatusAsync(entidad);
				resultado.Success(response, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar actualizar el estatus del almacen"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BCrearAsync(EntAlmacenRequest request)
		{
			string nombreMetodo = nameof(BCrearAsync);
			var resultado = new EntityResponse<int>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un almacen");
			try
			{
				BValidarRequest(request);
				var entidad = _mapper.Map<EntAlmacen>(request);
				resultado.Result = await _repoAlmacen.DCrearAsync(entidad);
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
					"Ocurrio un error al intentar crear el almacen"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<EntAlmacenResponse>> BObtenerRegistroAsync(long id)
		{
			var nombreMetodo = nameof(BObtenerTodosAsync);
			var resultado = new EntityResponse<EntAlmacenResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el almacen");
			try
			{
				var responseDto = await _repoAlmacen.DObtenerProyeccionElementoAsync<EntAlmacenResponse>(cb => cb.iIdAlmacen == id)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntAlmacenResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el almacen"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<IEnumerable<EntAlmacenResponse>>> BObtenerTodosAsync(bool? activo)
		{
			var nombreMetodo = nameof(BObtenerTodosAsync);
			var resultado = new EntityResponse<IEnumerable<EntAlmacenResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los almacenes");
			try
			{
				Expression<Func<EntAlmacen, bool>> predicado = activo.HasValue
					? r => r.bActivo == activo.Value
					: null;

			
				var responseDto = await _repoAlmacen.DObtenerProyeccionListaAsync<EntAlmacenResponse>( predicado: predicado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntAlmacenResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todos los almacenes"
				);
			}

			return resultado;
		}
	}
}
