using ControlBienes.Entities.Catalogos.Titular;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Catalogos.Titular
{
    public class BusTitularValidator : AbstractValidator<EntTitularRequest>
    {
        public BusTitularValidator()
        {
            RuleFor(request => request.Nombre)
              .Cascade(CascadeMode.Stop)
              .NotEmpty().WithMessage("Se requiere el Nombre")
              .MaximumLength(150).WithMessage("El Nombre excede los 150 caracteres");

            RuleFor(request => request.IdCentroTrabajoTurno)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere el Código RGB")
                .Must(e => e > 0).WithMessage("El Centro de Trabajo asociado al Turno es invalido");
        }
    }
}
