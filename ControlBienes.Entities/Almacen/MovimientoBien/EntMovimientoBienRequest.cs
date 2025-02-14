using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Almacen.MovimientoBien
{
	public class EntMovimientoBienRequest
	{
		public long? IdTipoMovimiento { get; set; } = 0;
		public long? IdAlmacen { get; set; } = 0;
		public long? IdMetodoAdquisicion { get; set; } = 0;
		public long? IdProgramaOperativo { get; set; } = 0;
		public string NumeroFactura { get; set; } = string.Empty;
		public DateTime? FechaResepcion { get; set; } = null;
		public long? IdFuenteFinanciamiento { get; set; } = 0;
		public long? IdConceptoMovimiento { get; set; } = 0;
		public long? IdProveedor { get; set; } = 0;
		public long? IdFamilia { get; set; } = 0;
		public string Observaciones { get; set; } = string.Empty;
		public double? ImporteTotal { get; set; } = 0;
		public string Articulos { get; set; } = string.Empty;
	}
}
