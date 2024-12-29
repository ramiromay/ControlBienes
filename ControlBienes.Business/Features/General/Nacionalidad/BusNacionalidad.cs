using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.General.Nacionalidad;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.General.Nacionalidad
{
	public class BusNacionalidad : IBusNacionalidad
	{
		private readonly IDatNacionalidad _repositorio;
		private readonly ILogger<BusNacionalidad> _logger;
		const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkNacionalidad;
		const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorNacionalidad;

		public BusNacionalidad(IDatNacionalidad repositorio, ILogger<BusNacionalidad> logger)
		{
			_repositorio = repositorio;
			_logger = logger;
		}
		public async Task<EntityResponse<IEnumerable<EntNacionalidadResponse>>> BObtenerTodadNacionalidades()
		{
			var nombreMetodo = nameof(BObtenerTodadNacionalidades);
			var resultado = new EntityResponse<IEnumerable<EntNacionalidadResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos las nacionalidades");
			try
			{
				var dto = await _repositorio.DObtenerProyeccionListaAsync<EntNacionalidadResponse>();
				resultado.Success(dto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntNacionalidadResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todos las nacionalidades"
				);
			}

			return resultado;
		}
	}
}
