using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Patrimonio.DetalleAlta;
using FluentValidation;
using System.Text.RegularExpressions;

namespace ControlBienes.Business.Features.Patrimonio.TramiteVehiculo.Alta
{
	public class BusTramiteVehiculoAltaValidator : AbstractValidator<EntDetalleAltaVehiculoRequest>
	{
		public BusTramiteVehiculoAltaValidator()
		{
			RuleFor(request => request.IdSolicitud)
			   .Cascade(CascadeMode.Stop)
			   .Must(id => id > 0).WithMessage("Se requiere el Folio de la Solicitud");

			RuleFor(request => request.IdFamilia)
			   .Cascade(CascadeMode.Stop)
			   .Must(id => id > 0).WithMessage("Se requiere la Familia");

			RuleFor(request => request.IdSubfamilia)
			   .Cascade(CascadeMode.Stop)
			   .Must(id => id > 0).WithMessage("Se requiere la SubFamilia");

			RuleFor(request => request.IdBms)
			   .Cascade(CascadeMode.Stop)
			   .Must(id => id > 0).WithMessage("Se requiere el BMS");

			RuleFor(request => request.Descripcion)
			   .Cascade(CascadeMode.Stop)
			   .NotEmpty().WithMessage("Se requiere la Descripción");

			RuleFor(request => request.NivelUnidadAdministrativa)
			   .Cascade(CascadeMode.Stop)
			   .NotEmpty().WithMessage("Se requiere el Centro de Costo")
			   .Must(e => Regex.IsMatch(e, EntConstant.UnidadAdministrativaEstrictoRegex)).WithMessage("El Centro de Costo es invalido");

			RuleFor(request => request.IdTipoAdquisicion)
			   .Cascade(CascadeMode.Stop)
			   .Must(id => id > 0).WithMessage("Se requiere el Tipo de Adquisición");

			RuleFor(request => request.SustituyeBV)
			   .Cascade(CascadeMode.Stop)
			   .NotEmpty().WithMessage("Se requiere el Sustituye a BV");

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
			   .Must(e => e > 0.00m).WithMessage("El Precio Unitario debe ser mayor a 0.0");

			RuleFor(request => request.FechaCompra)
			   .Cascade(CascadeMode.Stop)
			   .NotEmpty().WithMessage("Se requiere la Fecha de la Compra");

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
			   .Must(e => e > 0.0m).WithMessage("El Precio Desechable debe ser mayor a 0.0");

			RuleFor(request => request.IdUbicacion)
				.Cascade(CascadeMode.Stop)
				.Must(id => id > 0).WithMessage("Se requiere la Ubicación");

			RuleFor(request => request.IdMunicipio)
				.Cascade(CascadeMode.Stop)
				.Must(id => id > 0).WithMessage("Se requiere el Municipio");

			RuleFor(request => request.Responsables)
				.Cascade(CascadeMode.Stop)
				.NotEmpty().WithMessage("Se requiere los Responsables del Bien");
		}
	}
}
