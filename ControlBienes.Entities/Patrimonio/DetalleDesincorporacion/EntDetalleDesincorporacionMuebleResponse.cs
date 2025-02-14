using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.DetalleDesincorporacion
{
	public class EntDetalleDesincorporacionMuebleResponse
	{

		public long? IdSolicitud { get; set; }

		public string NivelUnidadAdministrativa { get; set; }

		public long? IdEmpleado { get; set; }

		public string FolioBien { get; set; }

		public string Observaciones { get; set; }

		public DateTime? FechaPublicacion { get; set; }

		public string NumeroPublicacion { get; set; }

		public string DescripcionDesincorporacion { get; set; }
	}
}
