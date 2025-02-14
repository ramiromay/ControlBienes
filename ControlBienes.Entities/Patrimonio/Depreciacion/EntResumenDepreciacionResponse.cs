using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.Depreciacion
{
	public class EntResumenDepreciacionResponse
	{
		public decimal MontoDepreciado { get; set; } = 0;

		public long NumeroBienesDepreciados { get; set; } = 0;

		public long NumeroBienesNoDepreciados { get; set; } = 0;

		public long TotalBienes { get; set; } = 0;

		public List<EntErrorDepreciacionResponse> Errores { get; set; } =  new List<EntErrorDepreciacionResponse>();
	}
}
