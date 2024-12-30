using AutoMapper;
using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Catalogos.Color;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.TipoTramite;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TipoTramite
{
    public class BusTipoTramite : IBusTipoTramite
    {
        private readonly IDatTipoTramite _repositorio;
        private readonly ILogger<BusTipoTramite> _logger;
        private readonly IMapper _mapper;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkTipoTramite;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorTipoTramite;

        public BusTipoTramite(IDatTipoTramite repositorio, IMapper mapper, ILogger<BusTipoTramite> logger)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<EntityResponse<IEnumerable<EntTipoTramiteResponse>>> BObtenerTodosTiposTramites()
        {
            var nombreMetodo = nameof(BObtenerTodosTiposTramites);
            var resultado = new EntityResponse<IEnumerable<EntTipoTramiteResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los tipos de tramite");
            try
            {
                var entidades = await _repositorio.DObtenerTodosAsync();
                resultado.Result = _mapper.Map<IEnumerable<EntTipoTramiteResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntTipoTramiteResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos los tipos de tramites"
                );
            }

            return resultado;
        }
    }
}
