using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.DetalleSolicitud
{
	public class EntDetalleSolicitudResponse
	{
		public long? IdDetalleSolicitud { get; set; } = null;

		public string FolioBien { get; set; } = null;

		public string Etapa { get; set; } = null;

		public string TipoBien { get; set; } = null;

		public string Familia { get; set; } = null;

		public string SubFamilia { get; set; } = null;

		public string Ubicacion { get; set; } = null;

		public string Descripcion { get; set; } = null;

		public DateTime? FechaCreacion { get; set; } = null;

		public DateTime? FechaModificacion { get; set; } = null; 
	}
}
