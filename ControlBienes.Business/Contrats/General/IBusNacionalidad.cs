using ControlBienes.Business.Genericos;
using ControlBienes.Entities.General.Nacionalidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.General
{
	public interface IBusNacionalidad
	{
		Task<EntityResponse<IEnumerable<EntNacionalidadResponse>>> BObtenerTodadNacionalidades();
	}
}
