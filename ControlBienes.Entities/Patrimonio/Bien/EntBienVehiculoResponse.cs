using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.Bien
{
	public class EntBienVehiculoResponse
	{
		public long? IdBien { get; set; } = 0;

		public string Familia { get; set; }

		public string Subfamilia { get; set; }

		public string UnidadAdministrativa { get; set; }

		public string TipoBien { get; set; }

		public string FolioBien { get; set; } = null;

		public bool? Activo { get; set; } = null;

		public DateTime? FechaAlta { get; set; } = null;

		public DateTime? FechaBaja { get; set; } = null;

		public string MotivoBaja { get; set; } = null;

		public long? IdFamilia { get; set; } = 0;

		public long? IdSubfamilia { get; set; } = 0;

		public long? IdBms { get; set; } = 0;

		public string Descripcion { get; set; } = string.Empty;

		public string NivelUnidadAdministrativa { get; set; } = string.Empty;

		public string Requisicion { get; set; } = string.Empty;

		public string OrdenCompra { get; set; } = string.Empty;



		// numero bien
		public string CuentaPorPagar { get; set; } = string.Empty;

		public string SustituyeBV { get; set; } = string.Empty;

		public int? AnioEmicion { get; set; } = 0;

		public string NumeroPlaca { get; set; } = string.Empty;

		public int? NumeroMotor { get; set; } = 0;

		public int? AnioModelo { get; set; } = 0;

		public decimal? NumeroEconomico { get; set; } = 0;

		public long? IdClave { get; set; } = 0;

		public long? IdLinea { get; set; } = 0;

		public long? IdVersion { get; set; } = 0;

		public long? IdClase { get; set; } = 0;

		public long? IdTipo { get; set; } = 0;

		public long? IdCombustible { get; set; } = 0;



		public string Partida { get; set; } = null;

		public string PartidaEspecifica { get; set; } = null;

		public string ReferenciaActivo { get; set; } = null;

		public string ReferenciaActualizacion { get; set; } = null;

		public long? IdTipoAdquisicion { get; set; } = 0;

		public string NoSeries { get; set; } = string.Empty;

		public string FolioAnterior { get; set; } = string.Empty;

		public int? NoLicitacion { get; set; } = 0;

		public DateTime? FechaLicitacion { get; set; } = null;

		public string ObservacionLicitacion { get; set; } = string.Empty;

		public long? IdEstadoFisico { get; set; } = 0;

		public long? IdMarca { get; set; } = 0;

		public long? IdColor { get; set; } = 0;

		public string FolioFactura { get; set; } = string.Empty;

		public DateTime? FechaFactura { get; set; } = null;

		public decimal? PrecioUnitario { get; set; } = null;

		public DateTime? FechaCompra { get; set; } = null;

		public int? DiasGarantia { get; set; } = 0;

		public int? VidaUtil { get; set; } = 0;

		public DateTime? FechaInicioUso { get; set; } = null;

		public decimal? PrecioDesechable { get; set; } = null;

		public string ObservacionBien { get; set; } = string.Empty;

		public long? IdUbicacion { get; set; } = 0;

		public long? IdMunicipio { get; set; } = 0;

		public string Caracteristicas { get; set; } = string.Empty;

		public string Responsables { get; set; } = string.Empty;

		public string ObservacionResponsable { get; set; } = string.Empty;
	}
}
