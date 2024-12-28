using ControlBienes.Entities.Seguridad.Permiso;
using ControlBienes.Entities.Seguridad.Rol;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Seguridad.RolPermiso;

public partial class EntRolPermiso
{
    public long iIdRolPermiso { get; set; }

    public long iIdRol { get; set; }

    public long iIdPermiso { get; set; }

    public virtual EntPermiso Permiso { get; set; }

    public virtual EntRol Rol { get; set; }
}
