using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.DetalleAlta;
using ControlBienes.Entities.Patrimonio.TipoDominio;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TipoDominio
{
	public class BusTipoDominio : IBusTipoDominio
	{
		private readonly IDatTipoDominio _repoTipoDominio;
		private readonly ILogger<BusTipoDominio> _logger;
		private const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkTramiteMueble;
		private const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorTramiteMueble;

		public BusTipoDominio(IDatTipoDominio repoTipoDominio, ILogger<BusTipoDominio> logger)
		{
			_repoTipoDominio = repoTipoDominio;
			_logger = logger;
		}

		public async Task<EntityResponse<IEnumerable<EntTipoDominioResponse>>> BObtenerTiposDominioAsync()
		{
			var nombreMetodo = nameof(BObtenerTiposDominioAsync);
			var resultado = new EntityResponse<IEnumerable<EntTipoDominioResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar los dominios");
			try
			{
				var responseDto = await _repoTipoDominio.DObtenerProyeccionListaAsync<EntTipoDominioResponse>()
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntTipoDominioResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar los dominios"
				);
			}

			return resultado;
		}
	}
}
