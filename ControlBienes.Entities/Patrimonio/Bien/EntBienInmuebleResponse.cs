using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.Bien
{
	public class EntBienInmuebleResponse
	{
		public long? IdBien { get; set; } = null;

		public long? IdMotivoTramite { get; set; } = null;

		public string FolioBien { get; set; } = null;

		public bool? Activo { get; set; } = null;

		public DateTime? FechaAlta { get; set; } = null;

		public DateTime? FechaBaja { get; set; } = null;

		public string MotivoBaja { get; set; } = null;

		public string TipoBien { get; set; } = null;

		public string Familia { get; set; } = null;

		public string Subfamilia { get; set; } = null;

		public string UnidadAdministrativa { get; set; } = null;

		public string ReferenciaConac { get; set; }

		public long? IdFamilia { get; set; }

		public long? IdSubfamilia { get; set; }

		public string Nomenclatura { get; set; }

		public string Descripcion { get; set; }

		public long? IdTipoInmueble { get; set; }

		public long? IdUsoInmueble { get; set; }

		public long? IdTipoDominio { get; set; }

		public long? IdEstadoFisico { get; set; }

		public long? IdTipoAfectacion { get; set; }

		public string Afectante { get; set; }

		public long? IdTipoAdquisicion { get; set; }

		public string DecretoPublicaicion { get; set; }

		public string EscrituraTitulo { get; set; }

		public DateTime? FechaAdquisicion { get; set; }

		public DateTime? FechaAltaSistema { get; set; }
		public long? IdMunicipio { get; set; }

		public decimal? ValorHistorico { get; set; }

		public decimal? ValorLibros { get; set; }

		public decimal? Depreciacion { get; set; } = 0;

		public int? AniosVida { get; set; } = 0;
		//
		public string Expediente { get; set; }

		public int? FolioCatastro { get; set; }

		public string Calle { get; set; }

		public double? Superficie { get; set; }

		public decimal? ValorTerreno { get; set; }

		public string NumeroExterior { get; set; }

		public string NumeroInterior { get; set; }

		public string Cruzamiento1 { get; set; }

		public string Cruzamiento2 { get; set; }

		public double? SuperficieConstruccion { get; set; }

		public string Tablaje { get; set; }

		public decimal? ValorConstruccion { get; set; }

		public decimal? ValorInicial { get; set; }

		public decimal? CodigoPostal { get; set; }

		public long? IdOrigenValor { get; set; }

		public string Asentamiento { get; set; }

		public string Propietario { get; set; }

		public string ObservacionInmueble { get; set; }

		public string ObservacionSupervicion { get; set; }
	}
}
