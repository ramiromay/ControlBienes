using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.DetalleBaja
{
	public class EntDetalleBajaVehiculoRequest
	{
		public long? IdSolicitud { get; set; } = 0;

		public string NivelUnidadAdministrativa { get; set; } = string.Empty;

		public long? IdEmpleado { get; set; } = 0;

		public string FolioBien { get; set; } = string.Empty;

		public string Observaciones { get; set; } = string.Empty;

		public string FolioDictamen { get; set; } = string.Empty;

		public DateTime? FechaDocumento { get; set; } = null;

		public string Documentos { get; set; } = string.Empty;
	}
}
