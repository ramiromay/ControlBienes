using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.DetalleBaja
{
	public class EntDetalleBajaInmuebleResponse
	{
		public long? IdSolicitud { get; set; }

		public string FolioBien { get; set; }

		public long? IdBienPatrimonio { get; set; }

		public DateTime? FechaDesincorporacion { get; set; }

		public DateTime? FechaBaja { get; set; }

		public DateTime? FechaBajaSistema { get; set; }

		public decimal? ValorBaja { get; set; }

		public string AFavor { get; set; }

		public string DestinoBien { get; set; }

		public string EscrituraTitulo { get; set; }

		public string JustificacionBaja { get; set; }
	}
}
