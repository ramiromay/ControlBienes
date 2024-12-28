using ControlBienes.Entities.Catalogos.TipoBien;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.TipoBien
{
    public class BusTipoBienValidator : AbstractValidator<EntTipoBienRequest>
    {

        public BusTipoBienValidator()
        {
            RuleFor(request => request.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere el Nombre")
                .MaximumLength(255).WithMessage("El Nombre excede los 255 caracteres");
        }

    }
}
