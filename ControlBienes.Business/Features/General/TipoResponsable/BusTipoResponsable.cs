using AutoMapper;
using ControlBienes.Business.Contrats.General;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Catalogos.Color;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.General.TipoResponsable;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.General.TipoResponsable
{
    public class BusTipoResponsable : IBusTipoResponsable
    {
        private readonly IDatTipoResponsable _repositorio;
        private readonly ILogger<BusTipoResponsable> _logger;
        private readonly IMapper _mapper;
        const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkColor;
        const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorColor;

        public BusTipoResponsable(IDatTipoResponsable repositorio, IMapper mapper, ILogger<BusTipoResponsable> logger)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<EntityResponse<IEnumerable<EntTipoResponsableResponse>>> BObtenerTodosTipoResponsableAsync()
        {
            var nombreMetodo = nameof(BObtenerTodosTipoResponsableAsync);
            var resultado = new EntityResponse<IEnumerable<EntTipoResponsableResponse>>();

            _logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los tipos de responsable");
            try
            {
                var entidades = await _repositorio.DObtenerTodosAsync();
                resultado.Result = _mapper.Map<IEnumerable<EntTipoResponsableResponse>>(entidades);
                resultado.StatusCode = HttpStatusCode.OK;
                resultado.Message = EntMensajeConstant.OK;
                resultado.Code = _code;
            }
            catch (Exception ex)
            {
                resultado = BusExceptionHandler.Handle<IEnumerable<EntTipoResponsableResponse>>(
                    _logger,
                    ex,
                    _codeError,
                    nombreMetodo,
                    "Ocurrio un error al intentar consultar todos los tipos de responsable"
                );
            }

            return resultado;
        }
    }
}
