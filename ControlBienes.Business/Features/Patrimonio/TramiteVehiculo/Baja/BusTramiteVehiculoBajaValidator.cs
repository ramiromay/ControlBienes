using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.DetalleBaja;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteVehiculo.Baja
{
	public class BusTramiteVehiculoBajaValidator : AbstractValidator<EntDetalleBajaVehiculoRequest>
	{
		public BusTramiteVehiculoBajaValidator()
		{
			RuleFor(x => x.IdSolicitud)
				.GreaterThanOrEqualTo(0).WithMessage("Se requiere el Id de la Solicitud");

			RuleFor(x => x.IdEmpleado)
				.GreaterThanOrEqualTo(0).WithMessage("Se requiere el Solicitante");

			RuleFor(x => x.NivelUnidadAdministrativa)
				.NotEmpty().WithMessage("Se requiere la Unidad Administrativa.")
				.Must(e => Regex.IsMatch(e, EntConstant.UnidadAdministrativaEstrictoRegex)).WithMessage("La Unidad Administrativa no es valida.");

			RuleFor(x => x.FolioBien)
				.NotEmpty().WithMessage("Se requiere el Folio del Bien.");

			RuleFor(x => x.Observaciones)
				.NotEmpty().WithMessage("Se requiere la Información Complementaria.");

			RuleFor(x => x.FolioDictamen)
				.NotEmpty().WithMessage("Se requiere el Folio del Dictamen.")
				.MaximumLength(25).WithMessage("El Folio del Dictamen no debe exceder los 25 caracteres.");

			RuleFor(x => x.FechaDocumento)
				.NotNull().WithMessage("Se requiere la Fecha del Documento.");
		}
	}
}
