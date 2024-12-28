using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Seguridad.Persona;
using ControlBienes.Entities.Seguridad.Persona.Persona;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Seguridad
{
    public class DatPersona : Dat<EntPersona>, IDatPersona
    {
        public DatPersona(AppDbContext context, ILogger<Dat<EntPersona>> logger) : base(context, logger)
        {
        }
    }
}
