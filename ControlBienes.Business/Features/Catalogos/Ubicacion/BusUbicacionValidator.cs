using ControlBienes.Entities.Catalogos.Ubicacion;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.Ubicacion
{
    public class BusUbicacionValidator : AbstractValidator<EntUbicacionRequest>
    {
        public BusUbicacionValidator()
        {
            RuleFor(request => request.Descripcion)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Se requiere la Descripcion");
        }
    }
}
