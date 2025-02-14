using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.DetalleModificacion;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.InventarioMueble
{
	public class BusInventario : IBusInventario
	{

		private readonly IDatBienPatrimonio _repoBien;
		private readonly IDatDetalleSolicitud _repoDetalleSolicitud;
		private readonly IDatTipoBien _repoTipoBien;
		private readonly IDatSubfamilia _repoSubfamilia;
		private readonly IDatFamilia _repoFamilia;
		private readonly ILogger<BusInventario> _logger;
		private const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkInventario;
		private const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorInventario;

		public BusInventario(IDatBienPatrimonio repoBien, ILogger<BusInventario> logger, IDatDetalleSolicitud repoDetalleSolicitud, IDatSubfamilia repoSubfamilia, IDatFamilia repoFamilia, IDatTipoBien repoTipoBien)
		{
			_repoBien = repoBien;
			_logger = logger;
			_repoDetalleSolicitud = repoDetalleSolicitud;
			_repoSubfamilia = repoSubfamilia;
			_repoFamilia = repoFamilia;
			_repoTipoBien = repoTipoBien;
		}

		public async Task<EntityResponse<IEnumerable<EntBienPatrimonioResponse>>> BObtenerBienesInventarioAsync(long? idTipoBien, long? idDetalleSolicitud)
		{
			var nombreMetodo = nameof(BObtenerBienesInventarioAsync);
			var resultado = new EntityResponse<IEnumerable<EntBienPatrimonioResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar los bienes en el inventario");
			try
			{
				var responseDto = new List<EntBienPatrimonioResponse>();
				if (!idTipoBien.HasValue)
					throw new Exception("Se requiere el Tipo de Bien");

				if  (idDetalleSolicitud.HasValue)
				{
					var folioBien = "";
					var incluir = new List<Expression<Func<EntDetalleSolicitud, object>>>()
					{
						e => e.DetalleAlta.DatoGeneral,
						e => e.DetalleAlta.Factura.DatoVehicular,
						e => e.DetalleAlta.Licitacion,
						e => e.DetalleModificacion.DatoGeneral,
						e => e.DetalleModificacion.Factura.DatoVehicular,
						e => e.DetalleModificacion.Licitacion,
						e => e.DetalleBaja.Baja,
						e => e.DetalleDesincorporacion,
						e => e.DetalleDestinoFinal,
						e => e.DetalleMovimiento,
						e => e.Solicitud
					};
					var detalle = await _repoDetalleSolicitud.DObtenerRegistroAsync(incluir: incluir, predicado: e => e.iIdDetalleSolicitud == idDetalleSolicitud);
					if (detalle.DetalleAlta != null)
						folioBien = detalle.DetalleAlta.sFolioBien;

					else if (detalle.DetalleModificacion != null)
						folioBien = detalle.DetalleModificacion.sFolioBien;

					else if (detalle.DetalleBaja != null)
						folioBien = detalle.DetalleBaja.Baja.sFolioBien;

					else if (detalle.DetalleDesincorporacion != null)
						folioBien = detalle.DetalleDesincorporacion.sFolioBien;

					else if (detalle.DetalleDestinoFinal != null)
						folioBien = detalle.DetalleDestinoFinal.sFolioBien;

					else if (detalle.DetalleMovimiento != null)
						folioBien = detalle.DetalleMovimiento.sFolioBien;

					var foliosArray = !string.IsNullOrWhiteSpace(folioBien)
					? folioBien.Split(',').Select(f => f.Trim()).ToArray()
					: Array.Empty<string>();

					var response = await _repoBien.DObtenerProyeccionListaAsync<EntBienPatrimonioResponse>(
					predicado: e => string.IsNullOrEmpty(folioBien)
						? (e.bActivo.Value && !e.bEnProceso.Value && e.iIdTipoBien == idTipoBien.Value)
						: (
							foliosArray.Contains(e.sFolioBien) 
							|| (e.bActivo.Value && !e.bEnProceso.Value && e.iIdTipoBien == idTipoBien.Value))
					) ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
					responseDto = response.ToList();

				}
				else
				{
					var response = await _repoBien.DObtenerProyeccionListaAsync<EntBienPatrimonioResponse>(
					predicado: e => e.bActivo.Value && !e.bEnProceso.Value && e.iIdTipoBien == idTipoBien.Value
					) ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
					responseDto = response.ToList();
				}
				
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntBienPatrimonioResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar los bienes en el inventario"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<IEnumerable<EntArticuloBienResponse>>> BObtenerArbolTiposBienesAsync(long? idTipoBien)
		{
			var nombreMetodo = nameof(BObtenerBienesInventarioAsync);
			var resultado = new EntityResponse<IEnumerable<EntArticuloBienResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el arbol de articulos");
			try
			{
				var responseDto = new List<EntArticuloBienResponse>();

				var tipoBien =  await _repoTipoBien.DObtenerRegistroAsync(predicado: e => e.iIdTipoBien == idTipoBien.Value && e.bActivo);

				var familiasPorTipoBien = await _repoFamilia.DObtenerTodosAsync(predicado: e => e.iIdTipoBien == idTipoBien.Value && e.bActivo);

				var familiasIds = familiasPorTipoBien.Select(f => f.iIdFamilia).ToList();

				var subFamiliasPorFamilia = await _repoSubfamilia
					.DObtenerTodosAsync(predicado: e => familiasIds.Contains(e.iIdFamilia) && e.bActivo);

				var idTBien =  tipoBien.iIdTipoBien;
				responseDto.Add(new EntArticuloBienResponse
				{
					Id = tipoBien.iIdTipoBien,
					Name = tipoBien.sNombre,
					NivelCompleto = idTBien.ToString()
				});

				var nivelFamilia = 1;

				foreach (var familia in familiasPorTipoBien)
				{
					responseDto.Add(new EntArticuloBienResponse
					{
						Id = familia.iIdFamilia,
						Name = familia.sNombre,
						NivelCompleto = $"{idTBien.ToString()}.{nivelFamilia}"
					});

					var subfamilias = subFamiliasPorFamilia
						.Where(sub => sub.iIdFamilia == familia.iIdFamilia)
						.ToList();

					var nivelSubfamilia = 1;
					foreach (var subfamilia in subfamilias)
					{
						responseDto.Add(new EntArticuloBienResponse
						{
							Id = subfamilia.iIdSubfamilia,
							Name = subfamilia.sNombre,
							NivelCompleto = $"{idTBien.ToString()}.{nivelFamilia}.{nivelSubfamilia++}"
						});
					}

					nivelFamilia++;
				}

				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntArticuloBienResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el arbol de articulos"
				);
			}

			return resultado;
		}



	}
}
