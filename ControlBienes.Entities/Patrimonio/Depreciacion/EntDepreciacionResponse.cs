using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.Depreciacion
{
	public class EntDepreciacionResponse
	{
		public long IdDepreciacion { get; set; }

		public decimal Tasa { get; set; }

		public decimal DepreciaionAcumulada { get; set; }

		public decimal ValorLibros { get; set; }

		public decimal DepreciacionFiscal { get; set; }

		public decimal Depreciacion { get; set; }

		public DateTime Fecha { get; set; }

		public bool Activo { get; set; }

		public decimal ValorHistorico { get; set; }

		public int AniosVida { get; set; }
	}
}
