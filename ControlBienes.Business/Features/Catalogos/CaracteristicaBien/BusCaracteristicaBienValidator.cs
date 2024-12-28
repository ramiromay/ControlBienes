using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.CaracteristicaBien
{
    public class BusCaracteristicaBienValidator : AbstractValidator<EntCaracteristicaBienRequest>
    {
        public BusCaracteristicaBienValidator()
        {
            RuleFor(request => request.IdFamilia)
               .Cascade(CascadeMode.Stop)
               .Must(id => id != 0).WithMessage("Se requiere el ID de la familia");

            RuleFor(request => request.IdSubfamilia)
               .Cascade(CascadeMode.Stop)
               .Must(id => id != 0).WithMessage("Se requiere el ID de la subfamilia");

            RuleFor(request => request.Etiqueta)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere el La etiqueta")
                .MaximumLength(255).WithMessage("El Nombre excede los 255 caracteres");

        }
    }
}
