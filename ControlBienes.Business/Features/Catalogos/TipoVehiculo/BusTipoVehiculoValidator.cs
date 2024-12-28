using ControlBienes.Entities.Catalogos.TipoVehicular;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.TipoVehiculo
{
    public class BusTipoVehiculoValidator : AbstractValidator<EntTipoVehiculoRequest>
    {
        public BusTipoVehiculoValidator()
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
