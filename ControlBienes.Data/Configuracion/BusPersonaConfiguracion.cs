using ControlBienes.Entities.General.Periodo;
using ControlBienes.Entities.Seguridad.Persona;
using ControlBienes.Entities.Seguridad.Persona.Persona;
using ControlBienes.Entities.Seguridad.Rol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Configuracion
{
    public class BusPersonaConfiguracion : IEntityTypeConfiguration<EntPersona>
    {
        public void Configure(EntityTypeBuilder<EntPersona> builder)
        {
            builder.HasData(
                new EntPersona()
                {
                    iIdPersona = 1,
                    sNombres = "Administrador",
                    sPrimerNombre = string.Empty,
                    sSegundoNombre = string.Empty,
                    bHombre = true,
                    dtFechaNacimiento = DateTime.Now,
                    iIdNacionalidad = 1,
                    sRfc = "RRRRRRRRRR"
                }
            );
        }
    }
}
