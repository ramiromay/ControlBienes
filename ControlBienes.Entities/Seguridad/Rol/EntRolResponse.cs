using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Seguridad.RolPermiso;
using ControlBienes.Entities.Seguridad.UsuarioRol;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Seguridad.Rol;

public class EntRolResponse
{
    public long? IdRol { get; set; } = null;

    public string Nombre { get; set; } = null;

    public string Descripcion { get; set; } = null;

}
