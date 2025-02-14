using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.Etapa
{
	public enum EnumEtapa : long
	{
        CapturaInicial = 1,
        CapturaFinal = 2,
        AutorizacionJefeDepartamento = 3,
        AutorizacionJefeControlActivosOtorgante = 4,
        AutorizadoDirectorAdministrativoSolicitante = 5,
        VOBO = 6,
        Cancelacion = 7,
        Rechazo = 8
	}
}
