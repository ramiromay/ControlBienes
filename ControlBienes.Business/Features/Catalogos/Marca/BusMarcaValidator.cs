using ControlBienes.Entities.Catalogos.Marca;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.Marca
{
    public class BusMarcaValidator : AbstractValidator<EntMarcaRequest>
    {

        public BusMarcaValidator()
        {
            RuleFor(request => request.Nombre)
              .Cascade(CascadeMode.Stop)
              .NotEmpty().WithMessage("Se requiere el Nombre")
              .MaximumLength(100).WithMessage("El Nombre excede los 100 caracteres");
        }

    }
}
