using AutoMapper;
using ControlBienes.Business.Contrats.Seguridad;
using ControlBienes.Business.Contrats.Sistema;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Data.Contrats.Sistema;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Sistema.Catalogo.Catalogo;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ControlBienes.Business.Features.Sistema.Catalogo
{
    public class BusCatalogo : IBusCatalogo
    {
        private readonly IDatCatalogo _repositorio;
        private readonly IDatUsuarioPermiso _repositorioUsuarioPermiso;
        private readonly IBusIdentityAccess _servicioIdentityAccess;
        private readonly ILogger<BusCatalogo> _logger;
        private readonly IMapper _mapper;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkCatalogo;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorCatalogo;

        public BusCatalogo(IDatCatalogo repositorio, 
            ILogger<BusCatalogo> logger, 
            IMapper mapper, 
            IBusIdentityAccess servicioIdentityAccess,
			IDatUsuarioPermiso repositorioUsuarioPermiso) 
        {
            _repositorio = repositorio;
            _repositorioUsuarioPermiso = repositorioUsuarioPermiso;
            _servicioIdentityAccess = servicioIdentityAccess;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<EntityResponse<IEnumerable<EntCatalogoResponse>>> BObtenerCatalogosAsync(long id)
        {
            var nombreMetodo = nameof(this.BObtenerCatalogosAsync);
            var resultado = new EntityResponse<IEnumerable<EntCatalogoResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los catalogos");
            try
            {
                var idUsuario = _servicioIdentityAccess.BObtenerIdUsuario();
                var permisosUsuario = await _repositorioUsuarioPermiso.DObtenerTodosAsync(null, e => e.iIdUsuario == idUsuario);
				var permisosIds = permisosUsuario.Select(p => p.iIdPermiso).ToList();
				var catalogos = await _repositorio.DObtenerTodosAsync(null, e => e.bActivo.Value && e.iIdModulo == id && permisosIds.Contains(e.iIdPermiso));
                var result = _mapper.Map<IEnumerable<EntCatalogoResponse>>(catalogos);
                resultado.Success(result, _code);
			}
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntCatalogoResponse>>(
                      _logger,
                      ex,
                      _codeError,
                      nombreMetodo,
                      "Ocurrio un error al intentar consultar todos los catalogos"
                  );
            }

            return resultado;
        }

        
    }
}
