using ControlBienes.Entities.Catalogos.TipoAdquisicion;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.TipoAdquisicion
{
    public class BusTipoAdquisicionValidator : AbstractValidator<EntTipoAdquisicionRequest>
    {
        public BusTipoAdquisicionValidator()
        {
            RuleFor(request => request.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere el Nombre")
                .MaximumLength(255).WithMessage("El Nombre excede los 255 caracteres");
        }
    }

}
