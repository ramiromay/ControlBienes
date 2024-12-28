using ControlBienes.Entities.Catalogos.Turno;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.Turno
{
    public class BusTurnoValidator : AbstractValidator<EntTurnoRequest>
    {
        public BusTurnoValidator()
        {
            RuleFor(request => request.Nombre)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Se requiere el Nombre")
               .MaximumLength(100).WithMessage("El Nombre excede los 100 caracteres");
        }
    }
}
