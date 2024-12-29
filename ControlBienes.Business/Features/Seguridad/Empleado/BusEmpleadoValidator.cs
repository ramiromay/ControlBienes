using ControlBienes.Entities.Seguridad.Empleado;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Seguridad.Empleado
{
	public class BusEmpleadoValidator : AbstractValidator<EntEmpleadoRequest>
	{
		public BusEmpleadoValidator()
		{
			RuleFor(request => request.Nombres)
			  .Cascade(CascadeMode.Stop)
			  .NotEmpty().WithMessage("Se requiere el Nombre")
			  .MaximumLength(500).WithMessage("El Nombre excede los 500 caracteres");

			RuleFor(request => request.ApellidoPaterno)
			  .Cascade(CascadeMode.Stop)
			  .NotEmpty().WithMessage("Se requiere el Apellido Paterno")
			  .MaximumLength(500).WithMessage("El Apellido Paterno excede los 500 caracteres");

			RuleFor(request => request.ApellidoMaterno)
			  .Cascade(CascadeMode.Stop)
			  .NotEmpty().WithMessage("Se requiere el Apellido Materno")
			  .MaximumLength(500).WithMessage("El Apellido Materno excede los 500 caracteres");

			RuleFor(request => request.FechaNacimiento)
			  .Cascade(CascadeMode.Stop)
			  .NotNull().WithMessage("Se requiere la Fecha de Nacimiento");

			RuleFor(request => request.IdNacionalidad)
			  .Cascade(CascadeMode.Stop)
			  .Must(x => x > 0).WithMessage("Se requiere la Nacionalidad");

			RuleFor(request => request.Rfc)
			  .Cascade(CascadeMode.Stop)
			  .NotEmpty().WithMessage("Se requiere el Rfc")
			  .MaximumLength(20).WithMessage("El Rfc excede los 20 caracteres");

			RuleFor(request => request.Usuario)
			  .Cascade(CascadeMode.Stop)
			  .NotEmpty().WithMessage("Se requiere el Usuario")
			  .MaximumLength(500).WithMessage("El Apellido Materno excede los 500 caracteres");

			RuleFor(request => request.Email)
			  .Cascade(CascadeMode.Stop)
			  .NotEmpty().WithMessage("Se requiere el Email")
			  .MaximumLength(250).WithMessage("El Email excede los 250 caracteres");

			RuleFor(request => request.Telefono)
			  .Cascade(CascadeMode.Stop)
			  .NotEmpty().WithMessage("Se requiere el Telefono")
			  .MaximumLength(10).WithMessage("El Telefono excede los 10 caracteres");

			RuleFor(request => request.IdRol)
			  .Cascade(CascadeMode.Stop)
			  .Must(x => x > 0).WithMessage("Se requiere el Rol");

			RuleFor(request => request.FechaIngreso)
			  .Cascade(CascadeMode.Stop)
			  .NotNull().WithMessage("Se requiere la Fecha de Ingreso");

			RuleFor(request => request.IdNombramiento)
			  .Cascade(CascadeMode.Stop)
			  .Must(x => x > 0).WithMessage("Se requiere el Nombramiento");

		}
	}
}
