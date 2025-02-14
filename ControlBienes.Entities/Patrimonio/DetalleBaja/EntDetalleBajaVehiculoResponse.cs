using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.DetalleBaja
{
	public class EntDetalleBajaVehiculoResponse
	{
		public long? IdSolicitud { get; set; } = null;

		public string NivelUnidadAdministrativa { get; set; } = null;

		public long? IdEmpleado { get; set; } = null;

		public string FolioBien { get; set; } = null;

		public string Observaciones { get; set; } = null;

		public string FolioDictamen { get; set; } = null;

		public DateTime? FechaDocumento { get; set; } = null;

		public string Documentos { get; set; } = null;
	}
}
