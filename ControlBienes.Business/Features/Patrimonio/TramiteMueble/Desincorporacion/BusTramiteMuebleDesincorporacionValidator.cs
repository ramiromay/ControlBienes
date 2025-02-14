using ControlBienes.Entities.Patrimonio.DetalleDesincorporacion;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteMueble.Desincorporacion
{
	public class BusTramiteMuebleDesincorporacionValidator : AbstractValidator<EntDetalleDesincorporacionMuebleRequest>
	{
		public BusTramiteMuebleDesincorporacionValidator()
		{
			RuleFor(x => x.IdSolicitud)
		   .NotNull().WithMessage("Se requiere la solicitud.");

			RuleFor(x => x.NivelUnidadAdministrativa)
				.NotEmpty().WithMessage("Se requiere el nivel de unidad administrativa.");

			RuleFor(x => x.FolioBien)
				.NotEmpty().WithMessage("Se requiere el folio del bien.");

			RuleFor(x => x.Observaciones)
				.NotEmpty().WithMessage("Se requieren las observaciones.");

			RuleFor(x => x.FechaPublicacion)
				.NotNull().WithMessage("Se requiere la fecha de publicación.");

			RuleFor(x => x.NumeroPublicacion)
				.NotEmpty().WithMessage("Se requiere el número de publicación.");

			RuleFor(x => x.DescripcionDesincorporacion)
				.NotEmpty().WithMessage("Se requiere la descripción de la desincorporación.");
		}
	}
}
