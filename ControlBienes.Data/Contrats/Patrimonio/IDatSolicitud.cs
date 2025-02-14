using ControlBienes.Entities.Patrimonio.Solicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Contrats.Patrimonio
{
	public interface IDatSolicitud : IDatProyeccion<EntSolicitud>
	{
		Task<int> DCambiarEtapaAsync(EntSolicitud entity, long idEtapaSiguiente);
	}
}
