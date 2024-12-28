using ControlBienes.Entities.Catalogos.VersionVehicular;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.VersionVehicular
{
    public class BusVersionVehicularValidator : AbstractValidator<EntVersionVehicularRequest>
    {
        public BusVersionVehicularValidator()
        {
            RuleFor(request => request.Nombre)
              .Cascade(CascadeMode.Stop)
              .NotEmpty().WithMessage("Se requiere el Nombre")
              .MaximumLength(255).WithMessage("El Nombre excede los 255 caracteres");

            RuleFor(request => request.Descripcion)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere la Descripcion");
        }
    }
}
