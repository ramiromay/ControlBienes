using ControlBienes.Business.Genericos;
using ControlBienes.Entities.General.BMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.General
{
	public interface IBusBms
	{
		Task<EntityResponse<IEnumerable<EntBMSResponse>>> BObtenerTodosBMSAsync();

	}
}
