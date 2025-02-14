using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Catalogos.ConceptoMovimiento
{
	public class EntConceptoMovimientoResponse
	{
		public long? IdConceptoMovimiento { get; set; } = null;

		public string Nombre { get; set; } = null;

		public string Descripcion { get; set; } = null;

		public long? IdTipoMovimiento { get; set; } = null;

		public string TipoMovimiento { get; set; } = null;

		public bool? Activo { get; set; } = null;
		public DateTime? FechaCreacion { get; set; }
		public DateTime? FechaModificacion { get; set; }
	}
}
