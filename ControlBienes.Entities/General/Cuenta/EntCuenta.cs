using ControlBienes.Entities.Catalogos.Almacen;
using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.General.Cuenta;

public partial class EntCuenta : EntRegistroGenerico
{
    public long iIdCuenta { get; set; }

    public string sNombre { get; set; }

    public string sClave { get; set; }

    public int iNivel { get; set; }

    public string sNivelCompleto { get; set; }

    public virtual ICollection<EntAlmacen> Almacenes { get; set; } = new List<EntAlmacen>();
}
