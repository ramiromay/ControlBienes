using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Catalogos.Almacen
{
	public class EntAlmacenRequest
	{
		public long? IdPeriodo { get; set; } = 0;
		public string? Nombre { get; set; } = string.Empty;
		public string? Direccion { get; set; } = string.Empty;
		public string? Horario { get; set; } = string.Empty;
		public long? IdEmpleado { get; set; } = 0;
		public long? IdCuenta { get; set; } = 0;
		public long? IdMetodoCosteo { get; set; } = 0;
		public string? FolioEntrada { get; set; } = string.Empty;
		public string? FolioSalida { get; set; } = string.Empty;

	}
}
