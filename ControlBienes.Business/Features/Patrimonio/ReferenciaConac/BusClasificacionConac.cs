using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.ClasificacionConac;
using ControlBienes.Entities.Patrimonio.TipoDominio;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.ReferenciaConac
{
	public class BusClasificacionConac : IBusClasificacionConac
	{
		private readonly IDatTipoBienInmuble _repoTipoBienInmueble;
		private readonly ILogger<BusClasificacionConac> _logger;
		private const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkTramiteMueble;
		private const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorTramiteMueble;

		public BusClasificacionConac(IDatTipoBienInmuble repoTipoBienInmueble, ILogger<BusClasificacionConac> logger)
		{
			_repoTipoBienInmueble = repoTipoBienInmueble;
			_logger = logger;
		}

		public async Task<EntityResponse<IEnumerable<EntClasificacionConacResponse>>> ObtenerClasificacionConacAsync()
		{
			var nombreMetodo = nameof(ObtenerClasificacionConacAsync);
			var resultado = new EntityResponse<IEnumerable<EntClasificacionConacResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar la clasificacion conac");
			try
			{
				var responseDto = await _repoTipoBienInmueble.DObtenerProyeccionListaAsync<EntClasificacionConacResponse>()
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntClasificacionConacResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar la clasificacion conac"
				);
			}

			return resultado;
		}
	}
}
