using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.Solicitud
{
	public class EntSolicitudRequest
	{
		public long IdEmpleado { get; set; } = 0;
	
		public string NivelUnidadAdministrativa { get; set; } = string.Empty;

		public long IdTipoTramite { get; set; } = 0;

		public long IdMotivoTramite { get; set; } = 0;

		public string Observaciones { get; set; } = string.Empty;
	}
}
