using ControlBienes.Entities.Catalogos.Familia;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.Familia
{
    public class BusFamiliaValidator : AbstractValidator<EntFamiliaRequest>
    {

        public BusFamiliaValidator()
        {
            RuleFor(request => request.IdFamilia)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere el ID de la familia")
                .Must(id => id > 0).WithMessage("El ID de la famialia no es valido")
                .Must(id => id.ToString().Length >= 3).WithMessage("El ID de la familia debe tener al menos 3 digitos");

            RuleFor(request => request.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere el Nombre")
                .MaximumLength(255).WithMessage("El Nombre excede los 255 caracteres");

            RuleFor(request => request.IdTipoBien)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere el Tipo de Bien")
                .Must(id => id > 0).WithMessage("El Tipo de Bien no es valido");
        }

    }
}
