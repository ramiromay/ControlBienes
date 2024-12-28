using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Seguridad.RolPermiso;
using ControlBienes.Entities.Seguridad.UsuarioRol;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Seguridad.Rol;

public partial class EntRol : IdentityRole<long>
{
    public string sDescripcion { get; set; }

     public DateTime dtFechaCreacion { get; set; }

     public DateTime dtFechaModificacion { get; set; }

     public virtual ICollection<EntRolPermiso> RolesPermisos { get; set; } = new List<EntRolPermiso>();

	public virtual ICollection<EntUsuarioRol> UsuarioRoles { get; set; } = new List<EntUsuarioRol>();

}
