using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.Solicitud
{
	public class EntSolicitudResponse
	{
		public long? IdSolicitud { get; set; } = null;

		public long? IdEmpleado { get; set; } = null;
		
		public string Empleado { get; set; } = null;

		public long? IdEtapa { get; set; } = null;

		public string Etapa { get; set; } = null;

		public long? IdPeriodo { get; set; } = null;

		public long? IdUnidadAdministrativa { get; set; } = null;

		public string UnidadAdministrativa { get; set; } = null;

		public long? IdTipoTramite { get; set; } = null;

		public string TipoTramite { get; set; } = null;

		public long? IdMotivoTramite { get; set; } = null;

		public string MotivoTramite { get; set; } = null;

		public string Observaciones { get; set; } = null;

		public DateTime? FechaCreacion { get; set; } = null;

		public DateTime? FechaModificacion { get; set; } = null;
	}
}
