using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.General.BMS;
using ControlBienes.Entities.Patrimonio.Solicitud;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.General.Bms
{
	public class BusBms : IBusBms
	{
		private readonly IDatBms _repoBms;
		private readonly ILogger<BusBms> _logger;
		private const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkBms;
		private const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorBms;

		public BusBms(IDatBms repoBms, ILogger<BusBms> logger)
		{
			_repoBms = repoBms;
			_logger = logger;
		}

		public async Task<EntityResponse<IEnumerable<EntBMSResponse>>> BObtenerTodosBMSAsync()
		{
			var nombreMetodo = nameof(BObtenerTodosBMSAsync);
			var resultado = new EntityResponse<IEnumerable<EntBMSResponse>> ();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los bms");
			try
			{
				var responseDto = await _repoBms.DObtenerProyeccionListaAsync<EntBMSResponse>()
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle< IEnumerable <EntBMSResponse>> (
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todos los bms"
				);
			}

			return resultado;
		}
	}
}
