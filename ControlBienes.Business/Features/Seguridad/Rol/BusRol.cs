using ControlBienes.Business.Contrats.Seguridad;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Seguridad.Rol;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Seguridad.Rol
{
	public class BusRol : IBusRol
	{
		private readonly IDatRol _repositorio;
		private readonly ILogger<BusRol> _logger;
		const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkRol;
		const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorRol;

		public BusRol(IDatRol repositorio, ILogger<BusRol> logger)
		{
			_repositorio = repositorio;
			_logger = logger;
		}

		public async Task<EntityResponse<IEnumerable<EntRolResponse>>> BObtenerTodosRolesAsync()
		{
			var nombreMetodo = nameof(BObtenerTodosRolesAsync);
			var resultado = new EntityResponse<IEnumerable<EntRolResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los roles");
			try
			{
				var resultDto = await _repositorio.DObtenerProyeccionListaAsync<EntRolResponse>();
				resultado.Success(resultDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntRolResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todos los roles"
				);
			}

			return resultado;
		}
	}
}
