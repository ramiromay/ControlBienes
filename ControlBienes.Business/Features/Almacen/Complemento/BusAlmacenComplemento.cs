using ControlBienes.Business.Contrats.Almacen;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Almacen;
using ControlBienes.Entities.Almacen.MetodoCosteo;
using ControlBienes.Entities.Almacen.ProgramaOperativo;
using ControlBienes.Entities.Almacen.Proveedor;
using ControlBienes.Entities.Almacen.TipoMovimiento;
using ControlBienes.Entities.Catalogos.Almacen;
using ControlBienes.Entities.Constants;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Almacen.Complemento
{
	public class BusAlmacenComplemento : IBusAlmacenComplemento
	{
		private readonly IDatMetodoCosteo _repoMetodoCosteo;
		private readonly IDatProgramaOperativo _repoProgramaOperativo;
		private readonly IDatTipoMovimiento _repoTipoMovimiento;
		private readonly IDatProveedor _repoProveedor;
		private readonly ILogger<BusAlmacenComplemento> _logger;
		const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkCaracteristicaBien;
		const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorCaracteristicaBien;

		public BusAlmacenComplemento(IDatMetodoCosteo repoMetodoCosteo, IDatProgramaOperativo repoProgramaOperativo, IDatTipoMovimiento repoTipoMovimiento, IDatProveedor repoProveedor, ILogger<BusAlmacenComplemento> logger)
		{
			_repoMetodoCosteo = repoMetodoCosteo;
			_repoProgramaOperativo = repoProgramaOperativo;
			_repoTipoMovimiento = repoTipoMovimiento;
			_repoProveedor = repoProveedor;
			_logger = logger;
		}

		public async Task<EntityResponse<IEnumerable<EntMetodoCosteoResponse>>> BObtenerMetodosCosteoAsync()
		{
			var nombreMetodo = nameof(BObtenerMetodosCosteoAsync);
			var resultado = new EntityResponse<IEnumerable<EntMetodoCosteoResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los metodos de costeo");
			try
			{
				var responseDto = await _repoMetodoCosteo.DObtenerProyeccionListaAsync<EntMetodoCosteoResponse>();
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntMetodoCosteoResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todos los metodos de costeo"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<IEnumerable<EntProgramaOperativoResponse>>> BObtenerProgramasOperativosAsync()
		{
			var nombreMetodo = nameof(BObtenerProgramasOperativosAsync);
			var resultado = new EntityResponse<IEnumerable<EntProgramaOperativoResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los metodos de costeo");
			try
			{
				var responseDto = await _repoProgramaOperativo.DObtenerProyeccionListaAsync<EntProgramaOperativoResponse>();
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntProgramaOperativoResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todos los metodos de costeo"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<IEnumerable<EntProveedorResponse>>> BObtenerProveedoresAsync()
		{
			var nombreMetodo = nameof(BObtenerProveedoresAsync);
			var resultado = new EntityResponse<IEnumerable<EntProveedorResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los proveedores");
			try
			{
				var responseDto = await _repoProveedor.DObtenerProyeccionListaAsync<EntProveedorResponse>();
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntProveedorResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todos los proveedores"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<IEnumerable<EntTipoMovimientoResponse>>> BObtenerTiposMovimientosAsync()
		{
			var nombreMetodo = nameof(BObtenerTiposMovimientosAsync);
			var resultado = new EntityResponse<IEnumerable<EntTipoMovimientoResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los tipos de movimiento");
			try
			{
				var responseDto = await _repoTipoMovimiento.DObtenerProyeccionListaAsync<EntTipoMovimientoResponse>();
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntTipoMovimientoResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todos los tipos de movimiento"
				);
			}

			return resultado;
		}
	}
}
