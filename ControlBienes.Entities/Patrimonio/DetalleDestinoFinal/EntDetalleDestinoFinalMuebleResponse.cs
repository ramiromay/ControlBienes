using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.DetalleDestinoFinal
{
	public class EntDetalleDestinoFinalMuebleResponse
	{
		public long? IdSolicitud  { get; set; }

		public string NivelUnidadAdministrativa { get; set; }

		public string FolioBien { get; set; }

		public string FolioDestruccion { get; set; }

		public DateTime? FechaDestruccion { get; set; }

		public string DescripcionDestruccion { get; set; }

		public string FolioEnajenacion { get; set; }

		public DateTime? FechaEnajenacion { get; set; }

		public string AvaluoEnajenacion { get; set; }

		public double? ImporteAvaluoEnajenacion { get; set; }

		public double? ImporteEnajenacion { get; set; }

		public string DescripcionEnajenacion { get; set; }
	}
}
