using AutoMapper;
using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.General.Periodo;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.General.Municipio;
using ControlBienes.Entities.General.Periodo;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ControlBienes.Business.Features.General.Municipio
{
    public class BusMunicipio : IBusMunicipio
    {
        private readonly IDatMunicipio _repositorio;
        private readonly ILogger<BusMunicipio> _logger;
        private readonly IMapper _mapper;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkPeriodo;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorPeriodo;

        public BusMunicipio(IDatMunicipio repositorio, ILogger<BusMunicipio> logger, IMapper mapper)
        {
            _repositorio = repositorio;
            _logger = logger;
            _mapper = mapper;
        }

        
        public async Task<EntityResponse<IEnumerable<EntMunicipioResponse>>> BObtenerTodosMunicipiosAsync()
        {
            var nombreMetodo = nameof(BObtenerTodosMunicipiosAsync);
            var resultado = new EntityResponse<IEnumerable<EntMunicipioResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los municipios");
            try
            {
                var entidades = await _repositorio.DObtenerTodosAsync();
                resultado.Result = _mapper.Map<IEnumerable<EntMunicipioResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntMunicipioResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos los municipios"
                );
            }

            return resultado;
        }
    }
}
