using ControlBienes.Entities.Catalogos.Resguardante;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Catalogos.Resguardante
{
    public class BusResguardanteValidator : AbstractValidator<EntResguardanteRequest>
    {
        public BusResguardanteValidator()
        {
            RuleFor(request => request.IdPeriodo)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Se requiere el Periodo")
               .Must(x => x > 0).WithMessage("El Periodo es invalido");

            RuleFor(request => request.IdPersona)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Se requiere la Persona")
               .Must(x => x > 0).WithMessage("La Persona es invalido");

            RuleFor(request => request.IdTipoResponsable)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Se requiere el Tipo de Responsable")
               .Must(x => x > 0).WithMessage("La Tipo de Responsable es invalido");

            RuleFor(request => request.NivelUnidadAdministrativa)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("La Unidad Administrativa es invalido");
        }
    }
}
