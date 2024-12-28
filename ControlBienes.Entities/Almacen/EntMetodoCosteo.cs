using ControlBienes.Entities.Catalogos;
using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Almacen;

public partial class EntMetodoCosteo : EntRegistroGenerico
{
    public long iIdMetodoCosteo { get; set; }

    public string sAbreviacion { get; set; }

    public string sNombre { get; set; }

    public virtual ICollection<EntAlmacen> Almacenes { get; set; } = new List<EntAlmacen>();
}
