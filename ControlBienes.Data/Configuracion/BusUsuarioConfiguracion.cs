using ControlBienes.Entities.Seguridad.Usuario;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ControlBienes.Business.Configuracion
{
    public class BusUsuarioConfiguracion : IEntityTypeConfiguration<EntUsuario>
    {
        public void Configure(EntityTypeBuilder<EntUsuario> builder)
        {
            var passwordHasher = new PasswordHasher<EntUsuario>();
               builder.HasData(
                   new EntUsuario()
                   {
                        Id = 1,
                        UserName = "administrador",
                        NormalizedUserName = "ADMINISTRADOR",
                        Email = "suppoort.sicba@gmail.com",
                        NormalizedEmail = "SUPPOORT.SICBA@GMAIL.COM",
                        PasswordHash = passwordHasher.HashPassword(null, "admin"),
                        PhoneNumber = "99999999",
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                   }
               );
        }
    }
}
