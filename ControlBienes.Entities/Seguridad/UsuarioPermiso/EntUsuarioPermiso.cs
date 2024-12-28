using ControlBienes.Entities.Seguridad.Permiso;
using ControlBienes.Entities.Seguridad.Usuario;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Seguridad.UsuarioPermiso;

public partial class EntUsuarioPermiso
{
    public long iIdUsuarioPermiso { get; set; }

    public long iIdUsuario { get; set; }

    public long iIdPermiso { get; set; }

    public virtual EntPermiso Permiso { get; set; }

    public virtual EntUsuario Usuario { get; set; }
}
