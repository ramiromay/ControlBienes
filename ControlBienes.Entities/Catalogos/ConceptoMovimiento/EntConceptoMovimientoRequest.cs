using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Catalogos.ConceptoMovimiento
{
	public class EntConceptoMovimientoRequest
	{
		public string Nombre { get; set; } = string.Empty;

		public string Descripcion { get; set; } = string.Empty;

		public long? IdTipoMovimiento { get; set; } = 0;
	}
}
