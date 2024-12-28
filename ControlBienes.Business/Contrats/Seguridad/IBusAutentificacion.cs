using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Seguridad.Autentificacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Seguridad
{
    public interface IBusAutentificacion
    {
        Task<EntityResponse<EntAutentificacionResponse>> BLogin(EntAutentificacionRequest request);
        Task<EntityResponse<EntAutentificacionResponse>> BValidateToken(string token);

	}
}
