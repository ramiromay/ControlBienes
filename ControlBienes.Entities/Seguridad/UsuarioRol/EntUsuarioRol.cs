using ControlBienes.Entities.Seguridad.Rol;
using ControlBienes.Entities.Seguridad.Usuario;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Seguridad.UsuarioRol;

public partial class EntUsuarioRol : IdentityUserRole<long>
{

    public virtual EntRol Rol { get; set; }

    public virtual EntUsuario Usuario { get; set; }
}
