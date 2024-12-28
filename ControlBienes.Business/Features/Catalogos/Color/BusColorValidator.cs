using ControlBienes.Entities.Catalogos.Color;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.Color
{
    public class BusColorValidator : AbstractValidator<EntColorRequest>
    {
        public BusColorValidator()
        {
            RuleFor(request => request.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere el Nombre")
                .MaximumLength(100).WithMessage("El Nombre excede los 100 caracteres");

            RuleFor(request => request.CodigoRGB)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere el Código RGB")
                .MaximumLength(25).WithMessage("El Código RBG excede los 25 caracteres");
        }
    }
}

