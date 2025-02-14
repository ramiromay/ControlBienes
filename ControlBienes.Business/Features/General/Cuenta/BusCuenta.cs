using AutoMapper;
using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Catalogos.Almacen;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Entities.Catalogos.Almacen;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.General.Cuenta;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.General.Cuenta
{
	public class BusCuenta : IBusCuenta
	{
		private readonly IDatCuenta _repoCuenta;
		private readonly IMapper _mapper;
		private readonly ILogger<BusCuenta> _logger;
		const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkCaracteristicaBien;
		const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorCaracteristicaBien;

		public BusCuenta(IDatCuenta repoAlmacen, IMapper mapper, ILogger<BusCuenta> logger)
		{
			_repoCuenta = repoAlmacen;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<EntityResponse<IEnumerable<EntCuentaResponse>>> ObtenerListaCuentaAsync()
		{
			var nombreMetodo = nameof(ObtenerListaCuentaAsync);
			var resultado = new EntityResponse<IEnumerable<EntCuentaResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todas las cuentas");
			try
			{
				var responseDto = await _repoCuenta.DObtenerProyeccionListaAsync<EntCuentaResponse>();
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntCuentaResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todas las cuentas"
				);
			}

			return resultado;
		}
	}
}
