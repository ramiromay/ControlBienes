using ControlBienes.Entities.Patrimonio.DetalleBaja;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteInmueble.Baja
{
	public class BusTramiteInmuebleBajaValidator : AbstractValidator<EntDetalleBajaInmuebleRequest>
	{
		public BusTramiteInmuebleBajaValidator()
		{
			RuleFor(x => x.IdSolicitud).NotNull().WithMessage("El Id Solicitud es requerido");
			RuleFor(x => x.IdBienPatrimonio).NotNull().WithMessage("El Id del Bien es requerido");
			RuleFor(x => x.FechaDesincorporacion).NotNull().WithMessage("La Fecha de Desincorporacion es requerido");
			RuleFor(x => x.FechaBaja).NotNull().WithMessage("La Fecha de Baja es requerido");
			RuleFor(x => x.FechaBajaSistema).NotNull().WithMessage("La Fecha de Baja del Sistema es requerido");
			RuleFor(x => x.ValorBaja).NotNull().WithMessage("El Valor de la Baja es requerido");
			RuleFor(x => x.JustificacionBaja).NotNull().WithMessage("La Justificacion de la Baja es requerido");
		}
	}
}
