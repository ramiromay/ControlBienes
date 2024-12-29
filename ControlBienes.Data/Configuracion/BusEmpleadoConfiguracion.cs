using ControlBienes.Entities.Seguridad.Empleado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Configuracion
{
    public class BusEmpleadoConfiguracion : IEntityTypeConfiguration<EntEmpleado>
    {
        public void Configure(EntityTypeBuilder<EntEmpleado> builder)
        {
            builder.HasData(
                new EntEmpleado
                {
                    iIdEmpleado = 1,
                    iIdPersona = 1,
                    iIdUsuario = 1,
                    bActivo = true,
                    dtFechaIngreso = DateTime.Now,
                    iIdNombramiento = 6
                }
            );
        }
    }
}
