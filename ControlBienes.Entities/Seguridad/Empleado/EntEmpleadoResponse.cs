using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Seguridad.Empleado
{
	public class EntEmpleadoResponse
	{
		public long? IdEmpleado { get; set; } = null;

		public string Nombres { get; set; } = null;

		public string ApellidoPaterno { get; set; } = null;

		public string ApellidoMaterno { get; set; } = null;

		public bool? Hombre { get; set; } = null;

		public DateTime? FechaNacimiento { get; set; } = null;

		public string Rfc { get; set; } = null;

		public long? IdNacionalidad { get; set; } = null;

		public string Nacionalidad { get; set; } = null;

		public string Usuario { get; set; } = null;

		public string Email { get; set; } = null;

		public string Telefono { get; set; } = null;

		public long? IdRol { get; set; } = null;

		public string Rol { get; set; } = null;

		public List<long> Permisos { get; set; } = null;

		public DateTime? FechaIngreso { get; set; } = null;

		public long? IdNombramiento { get; set; } = null;

		public string Nombramiento { get; set; } = null;

		public bool? Activo { get; set; } = null;

		public DateTime? FechaCreacion { get; set; } = null;

		public DateTime? FechaModificacion { get; set; } = null;


	}
}
