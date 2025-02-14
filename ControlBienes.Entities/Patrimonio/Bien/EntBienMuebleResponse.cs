using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.Bien
{
	public class EntBienMuebleResponse
	{
		public long? IdBien { get; set; } = null;

		public string FolioBien  { get; set; } = null;

		public bool? Activo { get; set; } = null;

		public DateTime? FechaAlta { get; set; } = null;

		public DateTime? FechaBaja { get; set; } = null;

		public string MotivoBaja { get; set; } = null;

		public long? IdTipoBien { get; set; } = null;

		public long? IdFamilia { get; set; } = null;

		public string TipoBien { get; set; } = null;

		public string Familia { get; set; } = null;

		public string Subfamilia  { get; set; } = null;

		public long? IdSubfamilia { get; set; } = null;

		public long? IdBms { get; set; } = null;

		public string Partida { get; set; }

		public string PartidaEspecifica { get; set; } = null;

		public string ReferenciaActivo { get; set; } = null;

		public string ReferenciaActualizacion { get; set; } = null;

		public string Descripcion { get; set; } = null;

		public string NivelUnidadAdministrativa { get; set; } = null;

		public string UnidadAdministrativa { get; set; } = null;

		public string Requisicion { get; set; } = null;

		public string OrdenCompra { get; set; } = null;

		public long? IdTipoAdquisicion { get; set; } = null;

		public string NoSeries { get; set; } = null;

		public string FolioAnterior { get; set; } = null;

		public int? NoLicitacion { get; set; } = null;

		public DateTime? FechaLicitacion { get; set; } = null;

		public string ObservacionLicitacion { get; set; } = null;

		public long? IdEstadoFisico { get; set; } = null;

		public long? IdMarca { get; set; } = null;

		public long? IdColor { get; set; } = null;

		public string FolioFactura { get; set; } = null;

		public DateTime? FechaFactura { get; set; } = null;

		public decimal? PrecioUnitario { get; set; } = null;

		public DateTime? FechaCompra { get; set; } = null;

		public int? DiasGarantia { get; set; } = null;

		public int? VidaUtil { get; set; } = null;

		public DateTime? FechaInicioUso { get; set; } = null;

		public decimal? PrecioDesechable { get; set; } = null;

		public string ObservacionBien { get; set; } = null;

		public long? IdUbicacion { get; set; } = null;

		public long? IdMunicipio { get; set; } = null;

		public string Caracteristicas { get; set; } = null;

		public string Responsables { get; set; } = null;

		public string ObservacionResponsable { get; set; } = null;
	}
}
