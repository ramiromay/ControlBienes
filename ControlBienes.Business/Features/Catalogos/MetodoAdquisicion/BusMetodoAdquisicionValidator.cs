using ControlBienes.Entities.Catalogos.MetodoAdquisicion;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Catalogos.MetodoAdquisicion
{
	public class BusMetodoAdquisicionValidator : AbstractValidator<EntMetodoAdquisicionRequest>
	{
		public BusMetodoAdquisicionValidator()
		{
			RuleFor(x => x.Nombre)
		  .NotEmpty().WithMessage("El nombre no puede estar vacío.")
		  .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.");
		}
	}
}
