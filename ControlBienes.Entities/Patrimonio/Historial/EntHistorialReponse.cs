using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.Historial
{
	public class EntHistorialReponse
	{
		public long IdHistorial { get; set; }

		public string Modulo { get; set; }

		public string SubModulo { get; set; }

		public string TipoTramite { get; set; }

		public string MotivoTramite { get; set; }

		public string Usuario { get; set; }

		public DateTime Fecha { get; set; }
	}
}
