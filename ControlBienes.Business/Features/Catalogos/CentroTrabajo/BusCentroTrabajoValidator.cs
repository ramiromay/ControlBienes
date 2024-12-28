using ControlBienes.Entities.Catalogos.CentroTrabajo;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.CentroTrabajo
{
    public class BusCentroTrabajoValidator : AbstractValidator<EntCentroTrabajoRequest>
    {
        public BusCentroTrabajoValidator()
        {
            RuleFor(request => request.IdPeriodo)
             .Cascade(CascadeMode.Stop)
             .NotEmpty().WithMessage("Se requiere el Periodo")
             .Must(e => e > 0).WithMessage("El Periodo es invalido");

            RuleFor(request => request.Clave)
              .Cascade(CascadeMode.Stop)
              .NotEmpty().WithMessage("Se requiere la Clave")
              .MaximumLength(30).WithMessage("El Nombre excede los 30 caracteres");

            RuleFor(request => request.Nombre)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Se requiere el Nombre")
               .MaximumLength(255).WithMessage("El Nombre excede los 255 caracteres");

            RuleFor(request => request.Direccion)
              .Cascade(CascadeMode.Stop)
              .NotEmpty().WithMessage("Se requiere la Dirección");

            RuleFor(request => request.IdMunicipio)
             .Cascade(CascadeMode.Stop)
             .NotEmpty().WithMessage("Se requiere el Municipio")
             .Must(e => e > 0).WithMessage("El Municipio es invalido");

            RuleFor(request => request.IdUnidadAdministrativa)
             .Cascade(CascadeMode.Stop)
             .NotEmpty().WithMessage("Se requiere la Unidad Administrativa")
             .Must(e => e > 0).WithMessage("La Unidad Administrativa es invalida");
        }
    }
}
