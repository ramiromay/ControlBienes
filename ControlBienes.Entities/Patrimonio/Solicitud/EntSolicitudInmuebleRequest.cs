using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.Solicitud
{
	public class EntSolicitudInmuebleRequest : EntSolicitudRequest
	{
		public string? DocumentoReferencia { get; set; } = string.Empty;
	}
}
