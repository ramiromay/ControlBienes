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
using ControlBienes.Entities.Sistema.ColumnaTabla;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ControlBienes.Business.Features.Sistema.ColumnaTabla
{
    public class BusColumnaTabla : IBusColumnaTabla
    {
        private readonly IDatColumnaTabla _repositorio;
        private readonly IDatUsuarioPermiso _repositorioUsuarioPermiso;
        private readonly IBusIdentityAccess _servicioIdentityAccess;
        private readonly ILogger<BusColumnaTabla> _logger;
        private readonly IMapper _mapper;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkColumnaTabla;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorColumnaTabla;

        public BusColumnaTabla(IDatColumnaTabla repositorio, 
            IMapper mapper, 
            ILogger<BusColumnaTabla> logger,
			IDatUsuarioPermiso repositorioUsuarioPermiso,
			IBusIdentityAccess servicioIdentityAccess)
        {
            _repositorio = repositorio;
            _repositorioUsuarioPermiso = repositorioUsuarioPermiso;
            _servicioIdentityAccess = servicioIdentityAccess;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<EntityResponse<IEnumerable<EntColumnaTablaResponse>>> BObtenerColumnasTablaCatalogoAsync(long idCatalogo)
        {
            var nombreMetodo = nameof(BObtenerColumnasTablaCatalogoAsync);
            var resultado = new EntityResponse<IEnumerable<EntColumnaTablaResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todas las columnas del catalogo");
            try
            {
                var columnasTablas = await _repositorio.DObtenerTodosAsync(null, e => e.iIdCatalogo == idCatalogo && e.bActivo);
                var result  = _mapper.Map<IEnumerable<EntColumnaTablaResponse>>(columnasTablas);
                resultado.Success(result, _code);
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntColumnaTablaResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todas las columnas del catalogo"
                );
            }

            return resultado;
        }

        public async Task<EntityResponse<IEnumerable<EntColumnaTablaResponse>>> BObtenerColumnasTablaSubModuloAsync(long idSubModulo)
        {
            var nombreMetodo = nameof(BObtenerColumnasTablaSubModuloAsync);
            var resultado = new EntityResponse<IEnumerable<EntColumnaTablaResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todas las columnas del modulo");
            try
            {
                var entidades = await _repositorio.DObtenerTodosAsync(null, e => e.iIdSubModulo == idSubModulo && e.bActivo);
                _logger.LogInformation($"{entidades}");
                resultado.Result = _mapper.Map<IEnumerable<EntColumnaTablaResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntColumnaTablaResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todas las columnas del modulo"
                );
            }

            return resultado;
        }
    }
}
