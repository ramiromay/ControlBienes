using ControlBienes.Entities.Patrimonio.DetalleModificacion;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteInmueble.Baja.Modificacion
{
	public class BusTramiteInmuebleModificacionValidator : AbstractValidator<EntDetalleModificacionInmuebleRequest>
	{
		public BusTramiteInmuebleModificacionValidator()
		{
			RuleFor(request => request.IdSolicitud)
		.Cascade(CascadeMode.Stop)
		.Must(id => id.HasValue && id > 0)
		.WithMessage("Se requiere el Folio de la Solicitud");

			RuleFor(request => request.ReferenciaConac)
				.Cascade(CascadeMode.Stop)
				.NotEmpty()
				.WithMessage("Se requiere la Referencia CONAC");

			RuleFor(request => request.IdFamilia)
				.Cascade(CascadeMode.Stop)
				.Must(id => id.HasValue && id > 0)
				.WithMessage("Se requiere la Familia");

			RuleFor(request => request.IdSubfamilia)
				.Cascade(CascadeMode.Stop)
				.Must(id => id.HasValue && id > 0)
				.WithMessage("Se requiere la SubFamilia");

			RuleFor(request => request.Descripcion)
				.Cascade(CascadeMode.Stop)
				.NotEmpty()
				.WithMessage("Se requiere la Descripción");

			RuleFor(request => request.IdTipoInmueble)
				.Cascade(CascadeMode.Stop)
				.Must(id => id.HasValue && id > 0)
				.WithMessage("Se requiere el Tipo de Inmueble");

			RuleFor(request => request.IdUsoInmueble)
				.Cascade(CascadeMode.Stop)
				.Must(id => id.HasValue && id > 0)
				.WithMessage("Se requiere el Uso del Inmueble");

			RuleFor(request => request.IdTipoDominio)
				.Cascade(CascadeMode.Stop)
				.Must(id => id.HasValue && id > 0)
				.WithMessage("Se requiere el Tipo de Dominio");

			RuleFor(request => request.IdEstadoFisico)
				.Cascade(CascadeMode.Stop)
				.Must(id => id.HasValue && id > 0)
				.WithMessage("Se requiere el Estado Físico");

			RuleFor(request => request.IdTipoAfectacion)
				.Cascade(CascadeMode.Stop)
				.Must(id => id.HasValue && id > 0)
				.WithMessage("Se requiere el Tipo de Afectación");

			RuleFor(request => request.Afectante)
				.Cascade(CascadeMode.Stop)
				.NotEmpty()
				.WithMessage("Se requiere el Afectante");

			RuleFor(request => request.IdTipoAdquisicion)
				.Cascade(CascadeMode.Stop)
				.Must(id => id.HasValue && id > 0)
				.WithMessage("Se requiere el Tipo de Adquisición");


			RuleFor(request => request.FechaAdquisicion)
				.Cascade(CascadeMode.Stop)
				.NotNull()
				.WithMessage("Se requiere la Fecha de Adquisición");
		}
	}
}
