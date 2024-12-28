using ControlBienes.Entities.Catalogos.CombustibleVehicular;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.CombustibleVehicular
{
    public class BusCombustibleVehicularValidator : AbstractValidator<EntCombustibleVehicularRequest>
    {

        public BusCombustibleVehicularValidator()
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
