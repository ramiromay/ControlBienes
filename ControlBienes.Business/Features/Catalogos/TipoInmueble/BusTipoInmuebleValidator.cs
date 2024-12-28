using ControlBienes.Entities.Catalogos.TipoInmueble;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.TipoInmueble
{
    public class BusTipoInmuebleValidator : AbstractValidator<EntTipoInmuebleRequest>
    {
        public BusTipoInmuebleValidator()
        {
            RuleFor(request => request.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere el Nombre")
                .MaximumLength(255).WithMessage("El Nombre excede los 255 caracteres");
        }
    }
}
