using Azure;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.Solicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Patrimonio
{
	public interface IBusSolicitudMueble : IBusSolicitudBase<EntSolicitudMuebleRequest, EntSolicitudMuebleResponse>
	{
	
	}
}
