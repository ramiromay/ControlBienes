using ControlBienes.Entities.Patrimonio.Solicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Contrats
{
	public interface IDatSolicitudBase<T> : IDatProyeccion<T> where T : EntSolicitud
	{
		Task<bool> DEtapaSiguienteCorrecta(long idEtapa);


	}
}
