using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.DetalleDesincorporacion
{
	public class EntDetalleDesincorporacionVehiculoRequest
	{
		public long? IdSolicitud { get; set; } = 0;

		public long? IdEmpleado { get; set; } = 0;

		public string NivelUnidadAdministrativa { get; set; } = string.Empty;

		public string FolioBien { get; set; } = string.Empty;

		public string Observaciones { get; set; } = string.Empty;

		public DateTime? FechaPublicacion { get; set; } = null;

		public string NumeroPublicacion { get; set; } = string.Empty;

		public string DescripcionDesincorporacion { get; set; } = string.Empty;
	}
}
