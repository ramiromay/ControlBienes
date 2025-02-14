using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Patrimonio.Solicitud;
using FluentValidation;

namespace ControlBienes.Business.Features.Patrimonio.SolicitudVehiculo
{
	public class BusSolicitudVehiculoValidator : AbstractValidator<EntSolicitudVehiculoRequest>
	{
		public BusSolicitudVehiculoValidator()
		{
			
			RuleFor(request => request.IdEmpleado)
				.Cascade(CascadeMode.Stop)
				.Must(e => e > 0).WithMessage("El empleado es invalido");

			RuleFor(request => request.NivelUnidadAdministrativa)
				.Cascade(CascadeMode.Stop)
				.NotEmpty().WithMessage("La Unidad Administrativa es invalido");

			RuleFor(request => request.IdTipoTramite)
				.Cascade(CascadeMode.Stop)
				.Must(e => e > 0).WithMessage("El Tipo de Trámite es invalido");

			RuleFor(request => request.IdMotivoTramite)
				.Cascade(CascadeMode.Stop)
				.Must(e => e > 0).WithMessage("El Motivo de Trámite es invalido");
		}
	}
}
