using ControlBienes.Entities.Catalogos.TipoAfectacion;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.TipoAfectacion
{
    public class BusTipoAfectacionValidator : AbstractValidator<EntTipoAfectacionRequest>
    {
        public BusTipoAfectacionValidator()
        {
            RuleFor(request => request.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Se requiere el Nombre")
                .MaximumLength(150).WithMessage("El Nombre excede los 150  caracteres");
        }
    }
}
