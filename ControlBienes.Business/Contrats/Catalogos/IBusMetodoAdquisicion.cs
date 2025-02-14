using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Data.Contrats;
using ControlBienes.Data.Contrats.Sistema;
using ControlBienes.Entities.Catalogos.MetodoAdquisicion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Catalogos
{
	public interface IBusMetodoAdquisicion : IBusCatalogo<EntMetodoAdquisicionRequest, EntMetodoAdquisicionResponse>
	{
	}
}
