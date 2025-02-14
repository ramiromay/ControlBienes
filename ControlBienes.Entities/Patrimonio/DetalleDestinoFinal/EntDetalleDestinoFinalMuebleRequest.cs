using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.DetalleDestinoFinal
{
	public class EntDetalleDestinoFinalMuebleRequest
	{
		public long? IdSolicitud { get; set; } = null;

		public string NivelUnidadAdministrativa { get; set; } = null;

		public string FolioBien { get; set; } = null;

		public string FolioDestruccion { get; set; } = null;

		public DateTime? FechaDestruccion { get; set; } = null;

		public string DescripcionDestruccion { get; set; } = null;

		public string FolioEnajenacion { get; set; } = null;

		public DateTime? FechaEnajenacion { get; set; } = null;

		public string AvaluoEnajenacion { get; set; } = null;

		public double? ImporteAvaluoEnajenacion { get; set; } = null;

		public string DescripcionEnajenacion { get; set; } = null;

		public long? IdMotivoTramite { get; set; } = 0;
	}
}
