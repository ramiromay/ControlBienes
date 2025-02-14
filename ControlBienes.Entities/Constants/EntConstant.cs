using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Constants
{
	public class EntConstant
	{
		public const string ClaimPermiso = "IdPermiso";
		public const string UnidadAdministrativaRegex = @"^\d+(\.\d+){0,2}$";
		public const string UnidadAdministrativaEstrictoRegex = @"^\d+\.\d+\.\d+$";
		public const string ValorRaiz = "0";
		public const string DefaultPartida = "5000";
		public const string DefaultFuenteFinanciamiento = "101";
		public const decimal PrecioNoDeprecia = 1.0m;
		public const long MuebleNoDeprecia = 513;
		public const long InmuebleNoDeprecia = 581;

	}
}
