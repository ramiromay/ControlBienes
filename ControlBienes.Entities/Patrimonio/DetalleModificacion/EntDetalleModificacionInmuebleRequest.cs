using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.DetalleModificacion
{
	public class EntDetalleModificacionInmuebleRequest
	{
		public long? IdSolicitud { get; set; } = 0;

		public long? IdBienPatrimonio { get; set; } = 0;

		public string ReferenciaConac { get; set; }

		public long? IdFamilia { get; set; } = 0;

		public long? IdSubfamilia { get; set; } = 0;

		public string Nomenclatura { get; set; } = string.Empty;

		public string Descripcion { get; set; } = string.Empty;

		public long? IdTipoInmueble { get; set; } = 0;

		public long? IdUsoInmueble { get; set; } = 0;

		public long? IdTipoDominio { get; set; } = 0;

		public long? IdEstadoInmueble { get; set; } = 0;

		public long? IdEstadoFisico { get; set; } = 0;

		public long? IdTipoAfectacion { get; set; } = 0;

		public string Afectante { get; set; } = string.Empty;

		public long? IdTipoAdquisicion { get; set; } = 0;

		public string DecretoPublicaicion { get; set; } = string.Empty;

		//
		public string EscrituraTitulo { get; set; } = string.Empty;


		public DateTime? FechaAdquisicion { get; set; } = null;




		//
		public DateTime? FechaAltaSistema { get; set; } = null;

		//
		public string Expediente { get; set; } = string.Empty;

		public decimal? ValorHistorico { get; set; } = 0;
		public decimal? ValorLibros { get; set; } = 0;


		public decimal? Depreciacion { get; set; } = 0;

		public int? AniosVida { get; set; } = 0;


		public int? FolioCatastro { get; set; } = 0;

		public string Calle { get; set; } = string.Empty;

		public double? Superficie { get; set; } = 0;

		public decimal? ValorTerreno { get; set; } = 0;

		public string NumeroExterior { get; set; } = string.Empty;

		public string NumeroInterior { get; set; } = string.Empty;

		public string Cruzamiento1 { get; set; } = string.Empty;

		public string Cruzamiento2 { get; set; } = string.Empty;

		public double? SuperficieConstruccion { get; set; } = 0;

		public string Tablaje { get; set; } = string.Empty;

		public decimal? ValorConstruccion { get; set; } = 0;

		public decimal? ValorInicial { get; set; } = 0;

		public decimal? CodigoPostal { get; set; }

		public long? IdOrigenValor { get; set; } = 0;
		public long? IdMunicipio { get; set; } = 0;
		public string Asentamiento { get; set; } = string.Empty;

		public string Propietario { get; set; } = string.Empty;

		public string ObservacionInmueble { get; set; } = string.Empty;

		public string ObservacionSupervicion { get; set; } = string.Empty;
	}
}
