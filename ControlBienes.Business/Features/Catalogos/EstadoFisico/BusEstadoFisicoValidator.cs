using ControlBienes.Entities.Catalogos.EstadoFisico;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.EstadoFisico
{
    public class BusEstadoFisicoValidator : AbstractValidator<EntEstadoFisicoRequest>
    {
        public BusEstadoFisicoValidator()
        {
            RuleFor(request => request.Nombre)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Se requiere el Nombre")
               .MaximumLength(100).WithMessage("El Nombre excede los 100 caracteres");

            RuleFor(request => request.Descripcion)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere la Descripcion");
        }

    }
}
