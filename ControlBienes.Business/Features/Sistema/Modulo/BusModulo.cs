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
using ControlBienes.Entities.Sistema.Modulo.Modulo;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Sistema.Modulo
{
    public class BusModulo : IBusModulo
    {
        private readonly IDatModulo _repositorio;
		private readonly IDatUsuarioPermiso _repositorioUsuarioPermiso;
		private readonly IBusIdentityAccess _servicioIdentityAccess;
		private readonly ILogger<BusModulo> _logger;
        private readonly IMapper _mapper;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkColor;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorColor;

        public BusModulo(IDatModulo repositorio, 
            IMapper mapper, 
            ILogger<BusModulo> logger,
            IBusIdentityAccess servicioIdentityAccess,
			IDatUsuarioPermiso repositorioUsuarioPermiso)
        {
            _repositorio = repositorio;
            _repositorioUsuarioPermiso = repositorioUsuarioPermiso;
            _servicioIdentityAccess = servicioIdentityAccess;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<EntityResponse<IEnumerable<EntModuloResponse>>> BObtenerTodosModulos()
        {
            var nombreMetodo = nameof(BObtenerTodosModulos);
            var resultado = new EntityResponse<IEnumerable<EntModuloResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los modulos");
            try
            {
				var idUsuario = _servicioIdentityAccess.BObtenerIdUsuario();
				var permisosUsuario = await _repositorioUsuarioPermiso.DObtenerTodosAsync(null, e => e.iIdUsuario == idUsuario);
				var permisosIds = permisosUsuario.Select(p => p.iIdPermiso).ToList();
				var modulos = await _repositorio.DObtenerTodosAsync(null, e => permisosIds.Contains(e.iIdPermiso));
                var result = _mapper.Map<IEnumerable<EntModuloResponse>>(modulos);
                resultado.Success(result, _code);
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntModuloResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos los modulos"
                );
            }

            return resultado;
        }
    }
}
