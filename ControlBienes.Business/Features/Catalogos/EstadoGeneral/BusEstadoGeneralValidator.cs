using ControlBienes.Entities.Catalogos.EstadoGeneral;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.EstadoGeneral
{
    public class BusEstadoGeneralValidator : AbstractValidator<EntEstadoGeneralRequest>
    {
        public BusEstadoGeneralValidator()
        {
            RuleFor(request => request.Nombre)
              .Cascade(CascadeMode.Stop)
              .NotEmpty().WithMessage("Se requiere el Nombre")
              .MaximumLength(50).WithMessage("El Nombre excede los 50 caracteres");
        }
    }
}
