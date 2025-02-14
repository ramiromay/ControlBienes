using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.DetalleModificacion;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteVehiculo.Modificacion
{
	public class BusTramiteVehiculoModificacionValidator : AbstractValidator<EntDetalleModificacionVehiculoRequest>
	{
		public BusTramiteVehiculoModificacionValidator()
		{
			RuleFor(request => request.IdSolicitud)
			   .Cascade(CascadeMode.Stop)
			   .Must(id => id > 0).WithMessage("Se requiere el Folio de la Solicitud");

			RuleFor(request => request.IdBienPatrimonio)
			   .Cascade(CascadeMode.Stop)
			   .Must(id => id > 0).WithMessage("Se requiere el Bien del Inventario");

			RuleFor(request => request.Descripcion)
			   .Cascade(CascadeMode.Stop)
			   .NotEmpty().WithMessage("Se requiere la Descripción");

			RuleFor(request => request.NivelUnidadAdministrativa)
			   .Cascade(CascadeMode.Stop)
			   .NotEmpty().WithMessage("Se requiere la Unidad Administrativa")
			   .Must(e => Regex.IsMatch(e, EntConstant.UnidadAdministrativaEstrictoRegex)).WithMessage("La Unidad Administrativa es invalida");

			RuleFor(request => request.IdTipoAdquisicion)
			   .Cascade(CascadeMode.Stop)
			   .Must(id => id > 0).WithMessage("Se requiere el Tipo de Adquisición");

			RuleFor(request => request.FolioAnterior)
			   .Cascade(CascadeMode.Stop)
			   .MaximumLength(10).WithMessage("El Folio Anterior excede los 10 caracteres");

			RuleFor(request => request.IdEstadoFisico)
			   .Cascade(CascadeMode.Stop)
			   .Must(id => id > 0).WithMessage("Se requiere el Estado Físico");

			RuleFor(request => request.FechaFactura)
			   .Cascade(CascadeMode.Stop)
			   .NotEmpty().WithMessage("Se requiere la Fecha de la Factura");

			RuleFor(request => request.PrecioUnitario)
			   .Cascade(CascadeMode.Stop)
			   .Must(e => e > 0.0m).WithMessage("El Precio Unitario debe ser mayor a 0.0");

			RuleFor(request => request.FechaCompra)
			   .Cascade(CascadeMode.Stop)
			   .NotNull().WithMessage("Se requiere la Fecha de la Compra");

			RuleFor(request => request)
			   .Cascade(CascadeMode.Stop)
			   .Must(e => e.FechaFactura.Value.Date >= e.FechaCompra.Value.Date).WithMessage("La Fecha de la Factura no puede ser anterior a la Fecha de la Compra");

			RuleFor(request => request.VidaUtil)
			   .Cascade(CascadeMode.Stop)
			   .Must(e => e > 0).WithMessage("La Vida Util en años debe ser mayor a 0");

			RuleFor(request => request.FechaInicioUso)
			   .Cascade(CascadeMode.Stop)
			   .NotEmpty().WithMessage("Se requiere la Fecha de Inicio de Uso");

			RuleFor(request => request.PrecioDesechable)
			   .Cascade(CascadeMode.Stop)
			   .Must(e => e > 0.00m).WithMessage("El Precio Desechable debe ser mayor a 0.0");

			RuleFor(request => request.IdUbicacion)
				.Cascade(CascadeMode.Stop)
				.Must(id => id > 0).WithMessage("Se requiere la Ubicación");

			RuleFor(request => request.IdMunicipio)
				.Cascade(CascadeMode.Stop)
				.Must(id => id > 0).WithMessage("Se requiere el Municipio");
		}
	}
}
