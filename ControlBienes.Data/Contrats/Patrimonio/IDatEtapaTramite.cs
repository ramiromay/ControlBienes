using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.EtapaTramite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Contrats.Patrimonio
{
	public interface IDatEtapaTramite : IDatProyeccion<EntEtapaTramite>
	{
		Task<bool> DValidarCambioEtapaAsync(EntDetalleSolicitud entidad, long idEtapa);
	}
}
