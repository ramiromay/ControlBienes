using ControlBienes.Business.Genericos;
using ControlBienes.Entities.General.Cuenta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.General
{
	public interface IBusCuenta
	{
		Task<EntityResponse<IEnumerable<EntCuentaResponse>>> ObtenerListaCuentaAsync();
	}
}
