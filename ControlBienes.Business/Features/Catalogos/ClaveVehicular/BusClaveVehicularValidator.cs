using ControlBienes.Entities.Catalogos.ClaveVehicular;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.ClaveVehicular
{
    public class BusClaveVehicularValidator : AbstractValidator<EntClaveVehicularRequest>
    {

        public BusClaveVehicularValidator()
        {
            RuleFor(request => request.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere el Nombre")
                .MaximumLength(150).WithMessage("El Nombre excede los 150 caracteres");
        }

    }
}
