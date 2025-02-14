using ControlBienes.Entities.Catalogos.ConceptoMovimiento;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Catalogos.ConceptoMovimiento
{
	public class BusConceptoMovimientoValidator : AbstractValidator<EntConceptoMovimientoRequest>
	{
		public BusConceptoMovimientoValidator()
		{
			RuleFor(x => x.Nombre)
				.NotEmpty().WithMessage("El nombre no puede estar vacío.")
				.MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");

			RuleFor(x => x.IdTipoMovimiento)
				.NotNull().WithMessage("El IdTipoMovimiento es obligatorio.")
				.GreaterThan(0).WithMessage("El IdTipoMovimiento debe ser un valor mayor a 0.");
		}
	}
}
