using ControlBienes.Entities.Catalogos;
using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Almacen;

public partial class EntZona : EntRegistroGenerico
{
    public long iIdZona { get; set; }

    public string sNombre { get; set; }

    public long iIdAlmacen { get; set; }

    public bool bActivo { get; set; }

    public virtual EntAlmacen Almacen { get; set; }
}
