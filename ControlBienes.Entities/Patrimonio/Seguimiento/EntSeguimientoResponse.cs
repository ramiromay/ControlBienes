using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.Seguimiento
{
	public class EntSeguimientoResponse
	{
		public long? IdSeguimiento { get; set; } = null;

		public DateTime? FechaHora { get; set; } = null;

		public string Modulo { get; set; } = null;

		public string SubModulo { get; set; } = null;

		public string Etapa { get; set; } = null;

		public string Usuario { get; set; } = null;

	}
}
