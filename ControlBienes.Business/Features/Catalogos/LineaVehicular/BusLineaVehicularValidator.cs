using ControlBienes.Entities.Catalogos.LineaVehicular;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.LineaVehicular
{
    public class BusLineaVehicularValidator : AbstractValidator<EntLineaVehicularRequest>
    {

        public BusLineaVehicularValidator()
        {
            RuleFor(request => request.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere el Nombre")
                .MaximumLength(255).WithMessage("El Nombre excede los 255 caracteres");

            RuleFor(request => request.Descripcion)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere la Descripción");
        }

    }
}
