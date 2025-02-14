using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Patrimonio.InventarioMueble;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.Historial;
using ControlBienes.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.InventarioInmueble
{
	public class BusInventarioInmueble : IBusInventarioInmueble
	{
		private readonly IDatBienPatrimonio _repoBien;
		private readonly IDatHistorial _repoHistorial;
		private readonly ILogger<BusInventarioInmueble> _logger;
		private const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkTramiteMueble;
		private const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorTramiteMueble;

		public BusInventarioInmueble(IDatBienPatrimonio repoBien, ILogger<BusInventarioInmueble> logger, IDatHistorial repoHistorial)
		{
			_repoBien = repoBien;
			_logger = logger;
			_repoHistorial = repoHistorial;
		}

		public async Task<EntityResponse<IEnumerable<EntBienInmuebleResponse>>> BObtenerBienesPorFiltroAsync(long? periodo, string unidadAdministrativa, bool? estadoBien, bool? busquedaPorTipoBien, long? idBusqueda, long? nivelArticulo, bool? busquedaPorFecha, DateTime? fechaInicio, DateTime? fechaFin)
		{
			var nombreMetodo = nameof(BObtenerBienesPorFiltroAsync);
			var resultado = new EntityResponse<IEnumerable<EntBienInmuebleResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar los bienes en el inventario");
			try
			{
				if (!periodo.HasValue)
					throw new BusConflictoException("Se requiere el periodo");

				if (string.IsNullOrEmpty(unidadAdministrativa) && !idBusqueda.HasValue)
					throw new BusConflictoException("Se requiere la unidad administrativa o el tipo de bien");

				var filtro = new List<Expression<Func<EntBienPatrimonio, bool>>>()
				{
					e => e.iIdPeriodo == periodo.Value
					&& e.iIdTipoBien == (long)EnumTipoBien.Inmueble
				};

				if (busquedaPorTipoBien.HasValue && busquedaPorTipoBien.Value &&
					nivelArticulo.HasValue && nivelArticulo.Value != 0)
				{

					filtro.Add(e => nivelArticulo == 1
						? e.iIdTipoBien == idBusqueda
						: nivelArticulo == 2
							? e.iIdFamilia == idBusqueda
							: e.iIdSubfamilia == idBusqueda);
				}
				else if (!string.IsNullOrEmpty(unidadAdministrativa) && !unidadAdministrativa.Equals(EntConstant.ValorRaiz))
				{
					filtro.Add(e => e.UnidadAdministrativa.sNivelCompleto.StartsWith(unidadAdministrativa));
				}

				if (busquedaPorFecha.HasValue && busquedaPorFecha.Value)
				{
					if (!estadoBien.HasValue)
						throw new BusConflictoException("Se requiere el estado del bien (Alta o Baja)");

					if (!fechaInicio.HasValue || !fechaFin.HasValue)
						throw new BusConflictoException("Se requiere la fecha de inicio y la fecha de fin");

					filtro.Add(e => e.bActivo == estadoBien.Value);
					filtro.Add(e => e.dtFechaAlta.Value.Date >= fechaInicio.Value.Date &&
					e.dtFechaAlta.Value.Date <= fechaFin.Value.Date);
				}
				var predicado = BusExpressionUtils.UCombinarExpression(filtro);
				_logger.LogInformation(predicado.ToString());
				var responseDto = await _repoBien.DObtenerProyeccionListaAsync<EntBienInmuebleResponse>(predicado: predicado)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntBienInmuebleResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar los bienes en el inventario"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<EntBienInmuebleResponse>> BObtenerBienPorIdAsync(long idBien)
		{
			var nombreMetodo = nameof(BObtenerBienPorIdAsync);
			var resultado = new EntityResponse<EntBienInmuebleResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el bien");
			try
			{
				var responseDto = await _repoBien.DObtenerProyeccionElementoAsync<EntBienInmuebleResponse>(e => e.iIdBien == idBien)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntBienInmuebleResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el bien"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<IEnumerable<EntHistorialReponse>>> BObtenerHistorialBienPorIdAsync(long idBien)
		{
			var nombreMetodo = nameof(BObtenerBienPorIdAsync);
			var resultado = new EntityResponse<IEnumerable<EntHistorialReponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el bien");
			try
			{
				var responseDto = await _repoHistorial.DObtenerProyeccionListaAsync<EntHistorialReponse>(e => e.iIdBien == idBien)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntHistorialReponse>>(
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
