using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Catalogos.Almacen
{
	public class EntAlmacenResponse
	{
		public long? IdAlmacen { get; set; } = null;
		public long? IdPeriodo { get; set; } = null;
		public string Empleado { get; set; } = null;
		public string MetodoCosteo { get; set; } = null;
		public string Nombre { get; set; } = null;
		public string Direccion { get; set; } = null;
		public string Horario { get; set; } = null;
		public long? IdEmpleado { get; set; } = null;
		public long? IdCuenta { get; set; } = null;
		public long? IdMetodoCosteo { get; set; } = null;
		public string FolioEntrada { get; set; } = null;
		public string FolioSalida { get; set; } = null;
		public bool? Activo { get; set; } = null;
		public DateTime? FechaCreacion { get; set; }
		public DateTime? FechaModificacion { get; set; }
	}
}
