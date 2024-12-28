using ControlBienes.Entities.Catalogos.Subfamilia;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.Subfamilia
{
    public class BusSubfamiliaValidator : AbstractValidator<EntSubfamiliaRequest>
    {
        public BusSubfamiliaValidator()
        {
            RuleFor(request => request.IdSubfamilia)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere ID de la subfamilia")
                .Must(e => e > 0).WithMessage("El ID de la subfamilia  no es valido");

            RuleFor(request => request.IdFamilia)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere la Familia")
                .Must(e => e > 0).WithMessage("La Familia no es valida");

            RuleFor(request => request.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere el Nombre")
                .MaximumLength(255).WithMessage("El Nombre excede los 255 caracteres");
        }

    }
}
