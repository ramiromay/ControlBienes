using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.Depreciacion;
using ControlBienes.Entities.Patrimonio.Historial;
using ControlBienes.Utils;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.Depreciacion
{
	public class BusDepreciacion : IBusDepreciacion
	{
		private readonly IDatDepreciacion _repoDepreciacion;
		private readonly IDatBienPatrimonio _repoBien;
		private readonly ILogger<BusDepreciacion> _logger;
		private const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkTramiteMueble;
		private const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorTramiteMueble;

		const long BienesMueblesVehiculos = 1;
		const long BienesInmuebles = 2;

		const long DepreciacionGlobal = 1;
		const long DepreciacionIndividual = 2;

		const int DiaDeDepreciacion = 30;


		public BusDepreciacion(IDatDepreciacion repoDepreciacion, IDatBienPatrimonio repoBien, ILogger<BusDepreciacion> logger)
		{
			_repoDepreciacion = repoDepreciacion;
			_repoBien = repoBien;
			_logger = logger;
		}

		private EntErrorDepreciacionResponse BObtenerMotivoNoDeprecio(EntBienPatrimonio bien)
		{
			var error = new EntErrorDepreciacionResponse();

			if (bien.dPrecioUnitario == EntConstant.PrecioNoDeprecia)
			{
				error.Descripcion = "El bien no se deprecia debido a que su valor historico es igual a $1.";
			}
			else if (bien.iIdSubfamilia == EntConstant.MuebleNoDeprecia)
			{
				error.Descripcion = "El bien no se deprecia debido a que pertence a la subfamilia 513 - BIENES ARTÍSTICOS, CULTURALES Y CIENTÍFICOS.";
			}
			else if (bien.iIdSubfamilia == EntConstant.InmuebleNoDeprecia)
			{
				error.Descripcion = "El bien no se deprecia debido a que pertence a la subfamilia 581 - TERRENOS.";
			}

			error.CentroCosto = $"{bien.UnidadAdministrativa.sNivelCompleto} {bien.UnidadAdministrativa.sNombre}";
			error.TipoBien = $"{bien.TipoBien.iIdTipoBien} {bien.TipoBien.sNombre}";
			error.FolioBien = bien.sFolioBien;
			return error;
		}

		private static EntDepreciacion BCrearDepreciacion(EntBienPatrimonio bien, EntDepreciacion depreciacionAnterior, decimal depreciacionMensual, decimal depreciacionAcumulada, decimal valorTotal, decimal tasa, bool cambioPeriodo, bool esNuevaDepreciacion = true)
		{
			decimal depreciacion = cambioPeriodo
				? depreciacionMensual
				: depreciacionAnterior.dDepreciacion + depreciacionMensual;
			decimal valorLibros = valorTotal - depreciacionAcumulada;
			DateTime fechaDepreciacion = esNuevaDepreciacion
					? DateTime.Now.Date
					: depreciacionAnterior.dtFecha;

			return new EntDepreciacion()
			{
				iIdBien = depreciacionAnterior.iIdBien,
				dDepreciacion = depreciacion,
				dDepreciaionAcumulada = depreciacionAcumulada,
				dDepreciacionFiscal = depreciacionMensual,
				dValorLibros = valorLibros,
				dTasa = tasa,
				dtFecha = fechaDepreciacion,
				bActivo = true,
				dValorHistorico = bien.dPrecioUnitario,
				iAniosVida = bien.iAniosVida
			};
		}

		public static decimal TruncarADecimales(decimal numero, int decimales)
		{
			decimal factor = (decimal)Math.Pow(10, decimales);
			return Math.Truncate(numero * factor) / factor;
		}

		private void BAjustarDepreciacionAnual(EntResumenDepreciacionResponse resumenDepreciacion, List<EntDepreciacion> depreciaciones, decimal depreciacionAnual, decimal depreciacionMensual, decimal valorTotal)
		{
			var totalMeses = depreciaciones.Count();
			if (totalMeses % 12 != 0) return;

			int anios = (int)totalMeses / 12;
			int mesesARecorer = anios * 12;
			decimal depreciacionAnualReal = decimal.Zero;

			for (int mes = 0; mes < mesesARecorer; mes++)
			{
				depreciacionAnualReal += depreciaciones.ElementAt(mes).dDepreciacionFiscal;

				if ((mes + 1) % 12 == 0)
				{
					if (depreciacionAnualReal != depreciacionAnual)
					{
						decimal valorAgregado = 0.000001m;
						decimal depreciacionFaltante = depreciacionAnual - depreciacionAnualReal;
						decimal depreciacionAcumulada = depreciacionMensual;
						decimal depreciacionValor = decimal.Zero;
						bool esPrimerAnio = mes == 11;
						int mesAEmpezar = esPrimerAnio ? mes - 10 : mes - 11;
						resumenDepreciacion.MontoDepreciado += depreciacionFaltante;


						for (int mesPorAnio = mesAEmpezar; mesPorAnio < mesesARecorer; mesPorAnio++)
						{
							if (mesPorAnio == 0)
								continue;

							if (esPrimerAnio)
							{
								var depreciacion = depreciaciones.ElementAt(mesPorAnio);
								if (depreciacion.dDepreciacionFiscal > depreciacionMensual)
								{
									depreciacionAcumulada += depreciacion.dDepreciacionFiscal;
								}
								else
								{
									depreciacionAcumulada += depreciacionMensual;

								}
								if (mesPorAnio % 2 == 1 && depreciacionFaltante != decimal.Zero)
								{
									depreciacionFaltante -= valorAgregado;
									depreciacionAcumulada += valorAgregado;
									depreciacion.dDepreciacionFiscal += valorAgregado;
								}

								depreciacion.dDepreciacion = depreciacionAcumulada;
								depreciacion.dValorLibros = valorTotal - depreciacionAcumulada;
								depreciacion.dDepreciaionAcumulada = depreciacionAcumulada;
								depreciacion.dTasa = TruncarADecimales(depreciacion.dDepreciacionFiscal * (100 / valorTotal), 6);
								if (mesPorAnio == mesesARecorer - 1 && depreciacionFaltante != decimal.Zero)
								{
									depreciacionAcumulada = depreciacionMensual;
									mesPorAnio = (mes + 1) - 12;

								}
							}
							else
							{
								var depreciacionMesAnterior = depreciaciones.ElementAt(mesPorAnio - 1);
								var depreciacion = depreciaciones.ElementAt(mesPorAnio);

								if (depreciacion.dDepreciacionFiscal > depreciacionMensual)
								{
									depreciacionAcumulada = depreciacionMesAnterior.dDepreciaionAcumulada + depreciacion.dDepreciacionFiscal;
								}
								else
								{
									depreciacionAcumulada = depreciacionMesAnterior.dDepreciaionAcumulada + depreciacionMensual;

								}


								if (mesPorAnio % 2 == 1 && depreciacionFaltante != decimal.Zero)
								{
									depreciacionFaltante -= valorAgregado;
									depreciacionAcumulada += valorAgregado;
									depreciacion.dDepreciacionFiscal += valorAgregado;
								}
								depreciacionValor += depreciacion.dDepreciacionFiscal;
								depreciacion.dDepreciacion = depreciacionValor;
								depreciacion.dValorLibros = valorTotal - depreciacionAcumulada;
								depreciacion.dDepreciaionAcumulada = depreciacionAcumulada;
								depreciacion.dTasa = TruncarADecimales(depreciacion.dDepreciacionFiscal * (100 / valorTotal), 6);
								if (mesPorAnio == mesesARecorer - 1 && depreciacionFaltante != decimal.Zero)
								{
									depreciacionAcumulada = decimal.Zero;
									depreciacionValor = depreciacionMensual;
									mesPorAnio = (mes + 1) - 12;
								}
							}
						}

					}
					depreciacionAnualReal = 0;

				}
			}
		}

		private static void BAjustarDepreciacionTotal(EntBienPatrimonio bien, IEnumerable<EntDepreciacion> depreciacionesAnteriores, IEnumerable<EntDepreciacion> nuevasDepreciaciones, EntResumenDepreciacionResponse resumenDepreciacion, decimal valorTotal, decimal montoDepreciado)
		{
			int mesesDepreciados = depreciacionesAnteriores.Where(x => x.bActivo).Count();

			foreach (var depreciacion in nuevasDepreciaciones)
			{
				
				montoDepreciado += depreciacion.dDepreciacionFiscal;
			}
			resumenDepreciacion.MontoDepreciado += montoDepreciado;
			if (mesesDepreciados % 12 == 0)
			{
				var ultimaDepreciacion = nuevasDepreciaciones.Last();
				if ((ultimaDepreciacion.iAniosVida * 12) == mesesDepreciados)
				{
					var totalDepreciado = ultimaDepreciacion.dDepreciaionAcumulada;
					if (totalDepreciado != valorTotal)
					{
						decimal montoFaltante = valorTotal - totalDepreciado;
						ultimaDepreciacion.dDepreciacionFiscal += montoFaltante;
						ultimaDepreciacion.dDepreciaionAcumulada += montoFaltante;
						ultimaDepreciacion.dValorLibros -= montoFaltante;
						ultimaDepreciacion.dDepreciacion += montoFaltante;
						ultimaDepreciacion.dTasa = TruncarADecimales(ultimaDepreciacion.dDepreciacionFiscal * (100 / valorTotal), 6);
						resumenDepreciacion.MontoDepreciado += montoFaltante;
					}
					bien.bDeprecia = false;
				}
			}
		}

		private List<EntDepreciacion> BAplicarCambioDepreciacion(IEnumerable<EntDepreciacion> depreciacionesAnteriores, EntBienPatrimonio bien, decimal depreciacionMensual, decimal valorTotal, decimal tasa, decimal depreciacionAnual)
		{
			var nuevasDepreciaciones = new List<EntDepreciacion>();
			var periodoActual = 0;
			var periodoAnterior = 0;
			var cambioAnio = false;
			var depreciacionAcumulada = 0m;

			foreach (var depreciacionAnterior in depreciacionesAnteriores)
			{
				depreciacionAcumulada += depreciacionMensual;
				depreciacionAnterior.bActivo = false;
				periodoAnterior = depreciacionAnterior.dtFecha.Year;
				cambioAnio = periodoActual != periodoAnterior;
				if (cambioAnio)
				{
					periodoActual = periodoAnterior;
				}
				var nuevaDepreciacion = BCrearDepreciacion(bien, depreciacionAnterior, depreciacionMensual, depreciacionAcumulada, valorTotal, tasa, cambioAnio, esNuevaDepreciacion: false);
				nuevasDepreciaciones.Add(nuevaDepreciacion);
			}

			var ultimaDepreciacion = nuevasDepreciaciones.Last();
			depreciacionAcumulada = ultimaDepreciacion.dDepreciaionAcumulada + depreciacionMensual;
			periodoAnterior = ultimaDepreciacion.dtFecha.Year;
			periodoActual = DateTime.Now.Year;
			cambioAnio = periodoActual != periodoAnterior;
			var depreciacionActual = BCrearDepreciacion(bien, ultimaDepreciacion, depreciacionMensual, depreciacionAcumulada, valorTotal, tasa, cambioAnio);
			var valorLibros = depreciacionActual.dValorLibros;
			bien.dPrecioDepreciado = valorLibros;
			bien.bDeprecia = valorLibros != valorTotal;
			nuevasDepreciaciones.Add(depreciacionActual);
			return nuevasDepreciaciones;
		}

		private async Task BDepreciar(EntBienPatrimonio bien, EntResumenDepreciacionResponse resumenDepreciacion)
		{
			if (!bien.bDeprecia.Value)
			{
				var motivo = BObtenerMotivoNoDeprecio(bien);
				resumenDepreciacion.Errores.Add(motivo);
				resumenDepreciacion.NumeroBienesNoDepreciados++;
				return;
			}

			var depreciacionesPorBien = await _repoDepreciacion.DObtenerTodosAsync(predicado: e => e.iIdBien == bien.iIdBien && e.bActivo, desactivarTracking: false);
			var depreciacionesAnteriores = depreciacionesPorBien.ToList();
			var valorTotal = TruncarADecimales(bien.dPrecioUnitario - bien.dPrecioDesechable, 6);
			var depreciacionMensual = TruncarADecimales(valorTotal / (12 * bien.iAniosVida), 6);
			var depreciacionAnual = TruncarADecimales(valorTotal / bien.iAniosVida, 6);
			var tasa = TruncarADecimales(depreciacionMensual * (100 / valorTotal), 6);
			var nuevasDepreciaciones = new List<EntDepreciacion>();
			decimal montoDepreciado = decimal.Zero;

			if (depreciacionesAnteriores.Count() == 0)
			{
				var depreciacionBien = new EntDepreciacion
				{
					iIdBien = bien.iIdBien,
					dDepreciacion = depreciacionMensual,
					dDepreciaionAcumulada = depreciacionMensual,
					dDepreciacionFiscal = depreciacionMensual,
					dValorLibros = valorTotal - depreciacionMensual,
					dTasa = tasa,
					dtFecha = DateTime.Now.Date,
					bActivo = true,
					dValorHistorico = bien.dPrecioUnitario,
					iAniosVida = bien.iAniosVida
				};
				nuevasDepreciaciones.Add(depreciacionBien);
				bien.dPrecioDepreciado = depreciacionBien.dValorLibros;
			}
			else
			{
				var ultimaDepreciacion = depreciacionesAnteriores.Where(x => x.bActivo).Last();
				if (ultimaDepreciacion.dValorHistorico != bien.dPrecioUnitario ||
					ultimaDepreciacion.iAniosVida != bien.iAniosVida)
				{
					nuevasDepreciaciones = BAplicarCambioDepreciacion(depreciacionesAnteriores, bien, depreciacionMensual, valorTotal, tasa, depreciacionAnual);
				}
				else
				{
					var cambioAnio = DateTime.Now.Year != ultimaDepreciacion.dtFecha.Year;
					var depreciacionAcumulada = ultimaDepreciacion.dDepreciaionAcumulada + depreciacionMensual;
					var nuevaDepreciacion = BCrearDepreciacion(bien, ultimaDepreciacion, depreciacionMensual, depreciacionAcumulada, valorTotal, tasa, cambioAnio);
					var valorLibros = nuevaDepreciacion.dValorLibros;
					bien.dPrecioDepreciado = valorLibros;
					bien.bDeprecia = valorLibros != valorTotal;
					nuevasDepreciaciones.Add(nuevaDepreciacion);
				}
			}
			resumenDepreciacion.NumeroBienesDepreciados++;
			await _repoDepreciacion.DCrearListaAsync(nuevasDepreciaciones);
			_logger.LogDebug($"{_repoDepreciacion.DObtenerEntidadesRastreadas(nuevasDepreciaciones.FirstOrDefault())}");
			depreciacionesAnteriores.AddRange(nuevasDepreciaciones);
			BAjustarDepreciacionAnual(resumenDepreciacion, depreciacionesAnteriores, depreciacionAnual, depreciacionMensual, valorTotal);
			BAjustarDepreciacionTotal(bien, depreciacionesAnteriores, nuevasDepreciaciones, resumenDepreciacion, valorTotal, montoDepreciado);
			await _repoDepreciacion.DActualizarListaAsync(depreciacionesAnteriores);
			await _repoBien.DActualizarAsync(bien);
		}

		private async Task<EntResumenDepreciacionResponse> BAplicarDepreciacion(IEnumerable<EntBienPatrimonio> bienes)
		{
			var resumenDepreciacion = new EntResumenDepreciacionResponse
			{
				TotalBienes = bienes.Count()
			};


			foreach (var bien in bienes)
			{
				await BDepreciar(bien, resumenDepreciacion);
			}

			return resumenDepreciacion;
		}

		public async Task<EntityResponse<EntResumenDepreciacionResponse>> BDepreciarBienes(long? periodo, long? mes, long? tipoBien, long? tipoDepreciacion, string unidadAdministrativa, string folioBien)
		{
			var nombreMetodo = nameof(BDepreciarBienes);
			var resultado = new EntityResponse<EntResumenDepreciacionResponse>();
			await using var transaction = await _repoDepreciacion.DBeginTransactionAsync();


			_logger.LogInformation($"{(long)_code}: Inicia la operacion para depreciar los bienes");
			try
			{
				if (!periodo.HasValue) 
					throw new BusConflictoException("Se requiere el Periodo");

				if (!mes.HasValue)
					throw new BusConflictoException("Se requiere el mes");

				if (!tipoBien.HasValue)
					throw new BusConflictoException("Se requiere el tipo de bien");

				if (!tipoDepreciacion.HasValue)
					throw new BusConflictoException("Se requiere el tipo de depreciacion");

				var fechaLimiteDepreciacion = new DateTime(year: (int)periodo + 1, month: (int)mes - 1, day: DiaDeDepreciacion);
				var filtros = new List<Expression<Func<EntBienPatrimonio, bool>>>()
				{
					e => e.bActivo.Value && 
						e.bDeprecia.Value && 
						e.iIdPeriodo == periodo &&
						e.dtFechaAlta.Value.Date <= fechaLimiteDepreciacion.Date &&
						tipoBien.Value == BienesMueblesVehiculos
						? e.iIdTipoBien == (long)EnumTipoBien.Mueble || e.iIdTipoBien == (long)EnumTipoBien.MaquinariaVehiculo
						: e.iIdTipoBien == (long)EnumTipoBien.Inmueble
				};

				EntResumenDepreciacionResponse responseDto = null;
				switch(tipoDepreciacion.Value)
				{
					case DepreciacionGlobal:
						if (string.IsNullOrEmpty(unidadAdministrativa))
							throw new BusConflictoException("Se requiere la unidad administrativa");

						filtros.Add(e => e.UnidadAdministrativa.sNivelCompleto.StartsWith(unidadAdministrativa));
						var filtroFinalGlobal = BusExpressionUtils.UCombinarExpression(filtros);
						var bienesGlobales = await _repoBien.DObtenerTodosAsync(predicado: filtroFinalGlobal)
							?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
						responseDto = await BAplicarDepreciacion(bienesGlobales);
						break;

					case DepreciacionIndividual:
						if (string.IsNullOrEmpty(folioBien))
							throw new BusConflictoException("Se requiere el folio del bien");

						var foliosBienes = folioBien.Split(',');
						filtros.Add(e => foliosBienes.Contains(e.sFolioBien));
						var filtroFinalIndividual = BusExpressionUtils.UCombinarExpression(filtros);
						var bienesIndividuales = await _repoBien.DObtenerTodosAsync(predicado: filtroFinalIndividual)
							?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
						responseDto = await BAplicarDepreciacion(bienesIndividuales);
						break;
					default: 
						break;
				}

				await transaction.CommitAsync(); 
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<EntResumenDepreciacionResponse> (
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar depreciar los bienes"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<IEnumerable<EntDepreciacionResponse>>> BObtenerDepreciacionPorBienAsync(long idBien)
		{
			var nombreMetodo = nameof(BObtenerDepreciacionPorBienAsync);
			var resultado = new EntityResponse<IEnumerable<EntDepreciacionResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar la depreciaicon del bien");
			try
			{
				var responseDto = await _repoDepreciacion.DObtenerProyeccionListaAsync<EntDepreciacionResponse>(e => e.iIdBien == idBien)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntDepreciacionResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar la depreciacion del bien"
				);
			}

			return resultado;
		}
	}
}
