using AutoMapper;
using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Contrats.Seguridad;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Catalogos.Color;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.General.Periodo;
using ControlBienes.Entities.Seguridad.Persona.Persona;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ControlBienes.Business.Features.Seguridad.Persona
{
    public class BusPersona : IBusPersona
    {
        private readonly IDatPersona _repositorio;
        private readonly ILogger<BusPersona> _logger;
        private readonly IMapper _mapper;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkPersona;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorPersona;

        public BusPersona(IDatPersona repositorio, IMapper mapper, ILogger<BusPersona> logger)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<EntityResponse<IEnumerable<EntPersonaResponse>>> BObtenerTodasPersonasAsync()
        {
            var nombreMetodo = nameof(BObtenerTodasPersonasAsync);
            var resultado = new EntityResponse<IEnumerable<EntPersonaResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos las personas");
            try
            {
                var entidades = await _repositorio.DObtenerTodosAsync();
                resultado.Result = _mapper.Map<IEnumerable<EntPersonaResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntPersonaResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos las personas"
                );
            }

            return resultado;
        }
    }
}
