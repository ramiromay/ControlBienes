using ControlBienes.Entities.Seguridad.RolPermiso;
using ControlBienes.Entities.Seguridad.UsuarioPermiso;
using ControlBienes.Entities.Sistema.Catalogo;
using ControlBienes.Entities.Sistema.Modulo;
using ControlBienes.Entities.Sistema.SubModulo;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Seguridad.Permiso;

public partial class EntPermisoResponse
{
    public long IdPermiso { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

}
