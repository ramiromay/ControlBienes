using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Contrats.Seguridad;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Seguridad.Permiso;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Seguridad.Permiso
{
	public class BusPermiso : IBusPermiso
	{
		private readonly IDatPermiso _repositorio;
		private readonly ILogger<BusPermiso> _logger;
		const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkPermiso;
		const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorPermiso;

		public BusPermiso(IDatPermiso repositorio, ILogger<BusPermiso> logger)
		{
			_repositorio = repositorio;
			_logger = logger;
		}

		public async Task<EntityResponse<IEnumerable<EntPermisoResponse>>> BObtenerTodosPermisoAsync()
		{
			var nombreMetodo = nameof(BObtenerTodosPermisoAsync);
			var resultado = new EntityResponse<IEnumerable<EntPermisoResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los permisos");
			try
			{
				var resultDto = await _repositorio.DObtenerProyeccionListaAsync<EntPermisoResponse>();
				resultado.Success(resultDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntPermisoResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todos los permisos"
				);
			}

			return resultado;
		}
	}
}
