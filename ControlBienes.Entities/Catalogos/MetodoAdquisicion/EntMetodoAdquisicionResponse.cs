using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Catalogos.MetodoAdquisicion
{
	public class EntMetodoAdquisicionResponse
	{
		public long? IdMetodoAdquisicion { get; set; }

		public string Nombre { get; set; }

		public bool? Activo { get; set; }

		public DateTime? FechaCreacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

	}
}
