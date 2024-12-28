using ControlBienes.Entities.Catalogos.CentroTrabajoTurno;
using FluentValidation;

namespace ControlBienes.Business.Features.Catalogos.CentroTrabajoTurno
{
    public class BusCentroTrabajoTurnoValidator : AbstractValidator<EntCentroTrabajoTurnoRequest>
    {
        public BusCentroTrabajoTurnoValidator()
        {
            RuleFor(request => request.IdCentroTrabajo)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Se requiere el Centro de Trabajo")
               .Must(x => x > 0).WithMessage("El Centro de Trabajo es invalido");

            RuleFor(request => request.IdTurno)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Se requiere el Turno")
               .Must(x => x > 0).WithMessage("El Turno es invalido");
        }
    }
}
