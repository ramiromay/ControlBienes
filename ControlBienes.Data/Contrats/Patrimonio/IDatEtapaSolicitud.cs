using ControlBienes.Entities.Patrimonio.EtapaSolicitud;
using ControlBienes.Entities.Patrimonio.Solicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Contrats.Patrimonio
{
	public interface IDatEtapaSolicitud : IDatProyeccion<EntEtapaSolicitud>
	{
		Task<bool> DValidarCambioEtapaAsync(EntSolicitud entidad, long idEtapa);
	}
}
