using ControlBienes.Entities.Catalogos.UsoInmueble;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.UsoInmueble
{
    public class BusUsoInmuebleValidator : AbstractValidator<EntUsoInmuebleRequest>
    {
        public BusUsoInmuebleValidator()
        {
            RuleFor(request => request.Nombre)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Se requiere el Nombre")
               .MaximumLength(255).WithMessage("El Nombre excede los 255 caracteres");
        }
    }
}
