using AutoMapper;
using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Patrimonio.TipoTramite;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.MotivoTramite;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.MotivoTramite
{
    public class BusMotivoTramite : IBusMotivoTramite
    {
        private readonly IDatMotivoTramite _repositorio;
        private readonly ILogger<BusMotivoTramite> _logger;
        private readonly IMapper _mapper;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkMotivoTramite;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorMotivoTramite;

        public BusMotivoTramite(IDatMotivoTramite repositorio, IMapper mapper, ILogger<BusMotivoTramite> logger)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<EntityResponse<IEnumerable<EntMotivoTramiteResponse>>> BObtenerTodosMotivosTramites()
        {
            var nombreMetodo = nameof(BObtenerTodosMotivosTramites);
            var resultado = new EntityResponse<IEnumerable<EntMotivoTramiteResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los colores");
            try
            {
                var entidades = await _repositorio.DObtenerTodosAsync();
                resultado.Result = _mapper.Map<IEnumerable<EntMotivoTramiteResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntMotivoTramiteResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos los colores"
                );
            }

            return resultado;
        }
    }
}
