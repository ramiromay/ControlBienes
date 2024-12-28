using ControlBienes.Entities.Catalogos.ClaseVehicular;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.ClaseVehicular
{
    public class BusClaseVehicularValidator : AbstractValidator<EntClaseVehicularRequest>
    {
        public BusClaseVehicularValidator()
        {
            RuleFor(request => request.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere el Nombre")
                .MaximumLength(150).WithMessage("El Nombre excede los 150 caracteres");

            RuleFor(request => request.Descripcion)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere la Descripcion");
        }
    }
}
