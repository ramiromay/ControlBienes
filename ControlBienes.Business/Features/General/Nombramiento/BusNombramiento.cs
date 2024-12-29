using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.General.Nacionalidad;
using ControlBienes.Entities.General.Nombramiento;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.General.Nombramiento
{
	public class BusNombramiento : IBusNombramiento
	{
		private readonly IDatNombramiento _repositorio;
		private readonly ILogger<BusNombramiento> _logger;
		const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkNombramiento;
		const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorNombramiento;


		public BusNombramiento(IDatNombramiento repositorio, ILogger<BusNombramiento> logger)
		{
			_repositorio = repositorio;
			_logger = logger;
		}

		public async Task<EntityResponse<IEnumerable<EntNombramientoResponse>>> BObtenerTodosNombramientos()
		{
			var nombreMetodo = nameof(BObtenerTodosNombramientos);
			var resultado = new EntityResponse<IEnumerable<EntNombramientoResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos las nombramientos");
			try
			{
				var resultDto = await _repositorio.DObtenerProyeccionListaAsync<EntNombramientoResponse>();
				resultado.Success(resultDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntNombramientoResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todos los nombramientos"
				);
			}

			return resultado;
		}
	}
}
