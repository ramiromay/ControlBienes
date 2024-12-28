using AutoMapper;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Catalogos.Color;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Catalogos.Documento;
using ControlBienes.Entities.Constants;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Catalogos.Documento
{
    public class BusDocumentoValidator : AbstractValidator<EntDocumentoRequest>
    {
       public BusDocumentoValidator()
       {
            RuleFor(request => request.Abreviacion)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Se requiere la Abreviación")
               .MaximumLength(10).WithMessage("La Abreviación excede los 10 caracteres");

            RuleFor(request => request.Nombre)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Se requiere el Nombre")
               .MaximumLength(255).WithMessage("El Nombre excede los 255 caracteres");

            RuleFor(request => request.IdSubModulo)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Se requiere el Módulo")
               .Must(e => e > 0).WithMessage("El Módulo es invalido");

            RuleFor(request => request.IdMotivoTramite)
              .Cascade(CascadeMode.Stop)
              .NotEmpty().WithMessage("Se requiere el Motivo de Trámite")
              .Must(e => e > 0).WithMessage("El Motivo de Trámite es invalido");

            RuleFor(request => request.IdTipoTramite)
              .Cascade(CascadeMode.Stop)
              .NotEmpty().WithMessage("Se requiere el Tipo Trámite")
              .Must(e => e > 0).WithMessage("El Tipo Trámite es invalido");
        }
    }
}
