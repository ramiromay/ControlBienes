using ControlBienes.Entities.Catalogos.OrigenValor;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.OrigenValor
{
    public class BusOrigenValorValidator : AbstractValidator<EntOrigenValorRequest>
    {
        public BusOrigenValorValidator()
        {
            RuleFor(request => request.Origen)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere el Origen")
                .MaximumLength(60).WithMessage("El Nombre excede los 60 caracteres");

            RuleFor(request => request.Descripcion)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere la Descripcion");
        }

    }
}
