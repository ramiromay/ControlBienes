using ControlBienes.Entities.Patrimonio.Historial;
using ControlBienes.Entities.Patrimonio.Seguimiento;
using ControlBienes.Entities.Seguridad.Empleado;
using ControlBienes.Entities.Seguridad.UsuarioPermiso;
using ControlBienes.Entities.Seguridad.UsuarioRol;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Seguridad.Usuario;

public partial class EntUsuario : IdentityUser<long>
{
    public DateTime dtFechaCreacion { get; set; }

    public DateTime dtFechaModificacion { get; set; }

	public virtual ICollection<EntEmpleado> Empleados { get; set; } = new List<EntEmpleado>();

	public virtual ICollection<EntHistorial> Historial { get; set; } = new List<EntHistorial>();

	public virtual ICollection<EntSeguimiento> Seguimientos { get; set; } = new List<EntSeguimiento>();

    public virtual ICollection<EntUsuarioPermiso> UsuariosPermisos { get; set; } = new List<EntUsuarioPermiso>();

	public virtual ICollection<EntUsuarioRol> UsuarioRoles { get; set; } = new List<EntUsuarioRol>();
}
