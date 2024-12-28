using ControlBienes.Entities.Seguridad.RolPermiso;
using ControlBienes.Entities.Seguridad.UsuarioPermiso;
using ControlBienes.Entities.Sistema.Catalogo;
using ControlBienes.Entities.Sistema.Modulo;
using ControlBienes.Entities.Sistema.SubModulo;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Seguridad.Permiso;

public partial class EntPermiso
{
    public long iIdPermiso { get; set; }

    public string sNombre { get; set; }

    public string sDescripcion { get; set; }

    public virtual ICollection<EntCatalogo> Catalogos { get; set; } = new List<EntCatalogo>();

    public virtual ICollection<EntModulo> Modulos { get; set; } = new List<EntModulo>();

    public virtual ICollection<EntRolPermiso> RolesPermisos { get; set; } = new List<EntRolPermiso>();

    public virtual ICollection<EntSubModulo> SubModulos { get; set; } = new List<EntSubModulo>();

    public virtual ICollection<EntUsuarioPermiso> UsuariosPermisos { get; set; } = new List<EntUsuarioPermiso>();
}
