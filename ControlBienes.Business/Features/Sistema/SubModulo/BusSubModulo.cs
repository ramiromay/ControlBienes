using AutoMapper;
using ControlBienes.Business.Contrats.Seguridad;
using ControlBienes.Business.Contrats.Sistema;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Catalogos.Color;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Data.Contrats.Sistema;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Sistema.SubModulo.SubModulo;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Sistema.SubModulo
{
    public class BusSubModulo : IBusSubModulo
    {
        private readonly IDatSubModulo _repositorio;
		private readonly IDatUsuarioPermiso _repositorioUsuarioPermiso;
		private readonly IBusIdentityAccess _servicioIdentityAccess;
		private readonly ILogger<BusSubModulo> _logger;
        private readonly IMapper _mapper;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkSubModulo;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorSubModulo;

        public BusSubModulo(IDatSubModulo repositorio, IMapper mapper, ILogger<BusSubModulo> logger, IDatUsuarioPermiso repositorioUsuarioPermiso, IBusIdentityAccess servicioIdentityAccess)
        {
            _repositorio = repositorio;
            _repositorioUsuarioPermiso = repositorioUsuarioPermiso;
            _servicioIdentityAccess = servicioIdentityAccess;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<EntityResponse<IEnumerable<EntSubModuloResponse>>> BObtenerTodosSubModulos()
        {
            var nombreMetodo = nameof(BObtenerTodosSubModulos);
            var resultado = new EntityResponse<IEnumerable<EntSubModuloResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los sub modulos");
            try
            {
				var idUsuario = _servicioIdentityAccess.BObtenerIdUsuario();
				var permisosUsuario = await _repositorioUsuarioPermiso.DObtenerTodosAsync(null, e => e.iIdUsuario == idUsuario);
				var permisosIds = permisosUsuario.Select(p => p.iIdPermiso).ToList();
				var entidades = await _repositorio.DObtenerTodosAsync(null, e => permisosIds.Contains(e.iIdPermiso));
                var result = _mapper.Map<IEnumerable<EntSubModuloResponse>>(entidades);
                resultado.Success(result, _code);
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntSubModuloResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos los sub modulos"
                );
            }

            return resultado;
        }
    }
}
