using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.Bien
{
	public class EntBienPatrimonioResponse
	{
		public long? IdBien { get; set; } = null;

		public long? IdPeriodo { get; set; } = null;

		public long? IdSolicitud { get; set; } = null;

		public long? IdTipoBien { get; set; } = null;

		public string FolioBien { get; set; } = null;

		public long? IdFamilia { get; set; } = null;

		public long? IdSubfamilia { get; set; } = null;

		public long? IdBms { get; set; } = null;

		public string ReferenciaConac { get; set; } = null;

		public string PartidaEspecifica { get; set; } = null;

		public string Descripcion { get; set; } = null;

		public string NivelUnidadAdministrativa { get; set; } = null;

		public string Requisicion { get; set; } = null;

		public string OrdenCompra { get; set; } = null;

		public string CuentaPorPagar { get; set; } = null;

		public long? IdTipoAdquisicion { get; set; } = null;

		public long? IdMunicipio { get; set; } = null;

		public string SustituyeBv { get; set; } = null;

		public string FolioFactura { get; set; } = null;

		public string FechaFactura { get; set; } = null;

		public long? IdUbicacion { get; set; } = null;

		public string NoSeries { get; set; } = null;

		public string FolioAnterior { get; set; } = null;

		public int? NoLicitacion { get; set; } = null;

		public DateTime? FechaLicitacion { get; set; } = null;

		public string ObservacionLicitacion  { get; set; } = null;

		public long? IdMarca { get; set; } = null;

		public long? IdColor  { get; set; } = null;

		public long? IdEstadoFisico { get; set; } = null;

		public decimal? PrecioUnitario { get; set; } = null;

		public int? DiasGarantia { get; set; } = null;

		public int? VidaUtil { get; set; } = null;

		public DateTime? FechaInicioUso { get; set; } = null;

		public DateTime? FechaCompra { get; set; } = null;

		public decimal? PrecioDepreciado { get; set; } = null;

		public decimal? PrecioDesechable { get; set; } = null;

		public string CuentaActivo { get; set; } = null;

		public string CuentaActualizacion { get; set; } = null;

		public string Caracteristicas { get; set; } = null;

		public string Responsables { get; set; } = null;

		public string ObservacionBien { get; set; } = null;

		public string ObservacionResponsable { get; set; } = null;

		public int? AnioEmicion { get; set; } = null;
		public string NumeroPlaca { get; set; } = null;
		public int? NumeroMotor { get; set; } = null;
		public int? AnioModelo { get; set; } = null;
		public decimal? NumeroEconomico { get; set; } = 0;
		public long? IdClave { get; set; } = 0;
		public long? IdLinea { get; set; } = 0;
		public long? IdVersion { get; set; } = 0;
		public long? IdClase { get; set; } = 0;
		public long? IdTipo { get; set; } = 0;
		public long? IdCombustible { get; set; } = 0;







		public string Nomenclatura { get; set; }


		public long? IdTipoInmueble { get; set; }

		public long? IdUsoInmueble { get; set; }

		public long? IdTipoDominio { get; set; }


		public long? IdTipoAfectacion { get; set; }

		public string Afectante { get; set; }


		public string DecretoPublicaicion { get; set; }

		public string EscrituraTitulo { get; set; }

		public DateTime? FechaAdquisicion { get; set; }

		public DateTime? FechaAltaSistema { get; set; }

		public decimal? ValorHistorico { get; set; }

		public decimal? ValorLibros { get; set; } = 0;

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

		public long? IdMotivoTramite { get; set; }

	}

}
