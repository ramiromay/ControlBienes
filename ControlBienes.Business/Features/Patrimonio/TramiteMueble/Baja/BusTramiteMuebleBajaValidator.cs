using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.DetalleBaja;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteMueble.Baja
{
	public class BusTramiteMuebleBajaValidator : AbstractValidator<EntDetalleBajaMuebleRequest>
	{
		public BusTramiteMuebleBajaValidator()
		{
			RuleFor(x => x.IdSolicitud)
				.GreaterThanOrEqualTo(0).WithMessage("Se requiere el Id de la Solicitud");

			RuleFor(x => x.NivelUnidadAdministrativa)
				.NotEmpty().WithMessage("Se requiere la Unidad Administrativa.")
				.Must(e => Regex.IsMatch(e, EntConstant.UnidadAdministrativaEstrictoRegex)).WithMessage("La Unidad Administrativa no es valida.");

			RuleFor(x => x.FolioBien)
				.NotEmpty().WithMessage("Se requiere el Folio del Bien.");

			RuleFor(x => x.Observaciones)
				.NotEmpty().WithMessage("Se requiere la Información Complementaria.");

			RuleFor(x => x.FolioDocumento)
				.NotEmpty().WithMessage("Se requiere el Folio del Documento.")
				.MaximumLength(255).WithMessage("El Folio del Documento no debe exceder los 255 caracteres.");

			RuleFor(x => x.FechaDocumento)
				.NotNull().WithMessage("Se requiere la Fecha del Documento.");

			RuleFor(x => x.NombreSolicitante)
				.NotEmpty().WithMessage("Se requiere el Nombre del Solicitante")
				.MaximumLength(255).WithMessage("El Nombre del Solicitante no debe exceder los 255 caracteres.");

			RuleFor(x => x.LugarResguardo)
				.NotEmpty().WithMessage("Se requiere el Lugar del Resguardo")
				.MaximumLength(100).WithMessage("El Lugar del Resguardo no debe exceder los 255 caracteres.");
		}
	}
}
