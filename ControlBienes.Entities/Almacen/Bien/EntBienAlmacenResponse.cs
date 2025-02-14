using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Almacen.Bien
{
	public class EntBienAlmacenResponse
	{
		public long IdBien { get; set; }

		public long IdAlmacen { get; set; }

		public long IdBms { get; set; }

		public string Almacen {  get; set; }

		public string Bien { get; set; }

		public string Familia { get; set; }

		public string Descripcion { get; set; }

		public decimal? CodigoArmonizado { get; set; }

		public double Existencia { get; set; }

		public double PrecioUnitario { get; set; }

		public string UnidadMedida { get; set; }

		public long IdFamilia { get; set; }

		public long IdSubfamilia { get; set; }
	}
}
