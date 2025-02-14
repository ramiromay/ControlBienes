using ControlBienes.Entities.Almacen.MovimientoBien;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Almacen.MovimientoBien
{
	public class BusMovimientoBienValidator : AbstractValidator<EntMovimientoBienRequest>
	{
		public BusMovimientoBienValidator()
		{
			// Validación para IdTipoMovimiento
			RuleFor(x => x.IdTipoMovimiento)
				.GreaterThan(0).WithMessage("Se requiere el campo Tipo de Movimiento.");

			// Validación para IdAlmacen
			RuleFor(x => x.IdAlmacen)
				.GreaterThan(0).WithMessage("Se requiere el campo Almacén.");

			// Validación para IdMetodoAdquisicion
			RuleFor(x => x.IdMetodoAdquisicion)
				.GreaterThan(0).WithMessage("Se requiere el campo Método de Adquisición.");

			// Validación para IdConceptoMovimiento
			RuleFor(x => x.IdConceptoMovimiento)
				.GreaterThan(0).WithMessage("Se requiere el campo Concepto de Movimiento.");

			// Validación para IdFamilia
			RuleFor(x => x.IdFamilia)
				.GreaterThan(0).WithMessage("Se requiere el campo Familia.");

			// Validación para ImporteTotal
			RuleFor(x => x.ImporteTotal)
				.GreaterThanOrEqualTo(0).WithMessage("El campo Importe Total no puede ser negativo.");

			RuleFor(x => x.Articulos)
			.NotEmpty().WithMessage("Se requiere al menos un bien en la lista de Bienes.");
		}
	}
}
