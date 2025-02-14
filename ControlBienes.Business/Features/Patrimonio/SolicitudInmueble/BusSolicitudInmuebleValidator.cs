using ControlBienes.Entities.Patrimonio.Solicitud;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.SolicitudInmueble
{
	public class BusSolicitudInmuebleValidator : AbstractValidator<EntSolicitudInmuebleRequest>
	{
		public BusSolicitudInmuebleValidator()
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
