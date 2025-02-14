using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.DetalleBaja
{
	public class EntDetalleBajaMuebleResponse
	{
		public long? IdSolicitud { get; set; } = null;

		public string NivelUnidadAdministrativa { get; set; } = null;

		public string FolioBien { get; set; } = null;

		public string Observaciones { get; set; } = null;

		public string FolioDocumento { get; set; } = null;

		public string FolioDictamen { get; set; } = null;

		public DateTime? FehaDocumento { get; set; } = null;

		public string Documentos { get; set; } = null;

		public string NombreSolicitante { get; set; } = null;

		public string LugarResguardo { get; set; } = null;
	}

}
