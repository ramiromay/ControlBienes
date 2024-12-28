using ControlBienes.Business.Genericos;
using ControlBienes.Entities.General.Nacionalidad;
using ControlBienes.Entities.General.Nombramiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.General
{
	public interface IBusNombramiento 
	{
		Task<EntityResponse<IEnumerable<EntNombramientoResponse>>> BObtenerTodosNombramientos();
	}
}
