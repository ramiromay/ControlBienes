using ControlBienes.Entities.Catalogos.Resguardante;
using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.General.TipoResponsable;

public partial class EntTipoResponsable : EntRegistroGenerico
{
    public long iIdTipoResponsable { get; set; }

    public string sNombre { get; set; }

    public string sDescripcion { get; set; }

    public virtual ICollection<EntResguardante> Resguardantes { get; set; } = new List<EntResguardante>();
}
