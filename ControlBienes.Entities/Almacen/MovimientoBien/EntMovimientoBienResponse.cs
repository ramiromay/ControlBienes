using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Almacen.MovimientoBien
{
	public class EntMovimientoBienResponse
	{
		public long? IdMovimiento { get; set; } = null;
		public long? IdPeriodo { get; set; } = null;
		public long? IdTipoMovimiento { get; set; } = null;
		public string TipoMovimiento { get; set; } = null;
		public long? IdAlmacen { get; set; } = null;
		public long? IdEtapa {  get; set; } = null;
		public string Etapa { get; set; } = null;
		public string Almacen { get; set; } = null;
		public string Familia { get; set; } = null;
		public string Proveedor { get; set; } = null;
		public string ConceptoMovimiento { get; set; } = null;
		public long? IdMetodoAdquisicion { get; set; } = null;
		public string MetodoAdquisicion { get; set; } = null;
		public long? IdProgramaOperativo { get; set; } = null;
		public string NumeroFactura { get; set; } = null;
		public DateTime? FechaResepcion { get; set; } = null;
		public long? IdFuenteFinanciamiento { get; set; } = null;
		public long? IdConceptoMovimiento { get; set; } = null;
		public long? IdProveedor { get; set; } = null;
		public long? IdFamilia { get; set; } = null;
		public string Observaciones { get; set; } = null;
		public double? ImporteTotal { get; set; } = null;
		public string Articulos { get; set; } = null;

	}
}
