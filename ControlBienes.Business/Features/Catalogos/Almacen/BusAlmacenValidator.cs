using ControlBienes.Entities.Catalogos.Almacen;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Catalogos.Almacen
{
	public class BusAlmacenValidator : AbstractValidator<EntAlmacenRequest>
	{
		public BusAlmacenValidator()
		{
			RuleFor(x => x.IdPeriodo)
		   .NotNull().WithMessage("El campo IdPeriodo no puede ser nulo.")
		   .GreaterThan(0).WithMessage("El campo IdPeriodo debe ser mayor a 0.");

			RuleFor(x => x.Nombre)
				.NotEmpty().WithMessage("El campo Nombre no puede estar vacío.")
				.MaximumLength(100).WithMessage("El campo Nombre no puede tener más de 100 caracteres.");

			RuleFor(x => x.IdEmpleado)
				.NotNull().WithMessage("El campo IdEmpleado no puede ser nulo.")
				.GreaterThan(0).WithMessage("El campo IdEmpleado debe ser mayor a 0.");

			RuleFor(x => x.IdCuenta)
				.NotNull().WithMessage("El campo IdCuenta no puede ser nulo.")
				.GreaterThan(0).WithMessage("El campo IdCuenta debe ser mayor a 0.");

			RuleFor(x => x.IdMetodoCosteo)
				.NotNull().WithMessage("El campo IdMetodoCosteo no puede ser nulo.")
				.GreaterThan(0).WithMessage("El campo IdMetodoCosteo debe ser mayor a 0.");
		}
	}
}
