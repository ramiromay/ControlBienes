using AutoMapper;
using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.General.UnidadAdministrativa;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Net;

namespace ControlBienes.Business.Features.General.UnidadAdministrativa
{
    public class BusUnidadAdministrativa : IBusUnidadAdministrativa
    {
        private readonly IDatUnidadAdministrativa _repositorio;
        private readonly ILogger<BusUnidadAdministrativa> _logger;
        private readonly IMapper _mapper;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkUnidadAdministrativa;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorUnidadAdministrativa;

        public BusUnidadAdministrativa(IDatUnidadAdministrativa repositorio, ILogger<BusUnidadAdministrativa> logger, IMapper mapper)
        {
            _repositorio = repositorio;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<EntityResponse<IEnumerable<EntUnidadAdministrativaResponse>>> BObtenerTodosUnidadesAdministrativasAsync()
        {
            var nombreMetodo = nameof(BObtenerTodosUnidadesAdministrativasAsync);
            var resultado = new EntityResponse<IEnumerable<EntUnidadAdministrativaResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos las unidades administrativas");
            try
            {
                var includes = new List<Expression<Func<EntUnidadAdministrativa, object>>>()
                {
                    f => f.TipoNivel
                };
                var entidades = await _repositorio.DObtenerTodosAsync(includes);
                resultado.Result = _mapper.Map<IEnumerable<EntUnidadAdministrativaResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntUnidadAdministrativaResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos las unidades administrativas"
                );
            }
            return resultado;

        }
    }
}
