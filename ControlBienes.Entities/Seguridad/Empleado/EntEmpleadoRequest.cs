using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Seguridad.Empleado
{
	public class EntEmpleadoRequest
	{

		public string Nombres { get; set; } = string.Empty;

		public string ApellidoPaterno { get; set; } = string.Empty;

		public string ApellidoMaterno { get; set; } = string.Empty;

		public bool Hombre { get; set; } = false;

		public DateTime? FechaNacimiento { get; set; } = null;

		public string Rfc { get; set; } = string.Empty;

		public long? IdNacionalidad { get; set; } = 0;

		public string Usuario { get; set; } = string.Empty;

		public string ContraseniaActual { get; set; } = string.Empty;

		public string NuevaContrasenia { get; set; } = string.Empty;

		public string NuevaContraseniaConfirmacion { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string Telefono { get; set; } = string.Empty;

		public List<long> Permisos { get; set; } = new List<long>();

		public long? IdRol { get; set; } = 0;

		public DateTime? FechaIngreso { get; set; } = null;

		public long? IdNombramiento { get; set; } = 0;


	}
}
