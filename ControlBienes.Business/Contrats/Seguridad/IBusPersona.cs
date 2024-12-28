using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Seguridad.Persona.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Seguridad
{
    public interface IBusPersona
    {
        public Task<EntityResponse<IEnumerable<EntPersonaResponse>>> BObtenerTodasPersonasAsync();
    }
}
