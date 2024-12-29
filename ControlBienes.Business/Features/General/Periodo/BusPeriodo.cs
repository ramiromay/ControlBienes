using AutoMapper;
using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Catalogos.Color;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.General.Periodo;
using ControlBienes.Entities.Sistema.Catalogo.Catalogo;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ControlBienes.Business.Features.General.Periodo
{
    public class BusPeriodo : IBusPeriodo
    {
        private readonly IDatPeriodo _repositorio;
        private readonly ILogger<BusPeriodo> _logger;
        private readonly IMapper _mapper;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkPeriodo;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorPeriodo;

        public BusPeriodo(IDatPeriodo repositorio, ILogger<BusPeriodo> logger, IMapper mapper)
        {
            _repositorio = repositorio;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<EntityResponse<IEnumerable<EntPeriodoResponse>>> BObtenerPeriodosAsync()
        {
            var nombreMetodo = nameof(BObtenerPeriodosAsync);
            var resultado = new EntityResponse<IEnumerable<EntPeriodoResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los periodos");
            try
            {
                var entidades = await _repositorio.DObtenerTodosAsync();
                resultado.Result = _mapper.Map<IEnumerable<EntPeriodoResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntPeriodoResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos los periodos"
                );
            }

            return resultado;
        }
    }
}
