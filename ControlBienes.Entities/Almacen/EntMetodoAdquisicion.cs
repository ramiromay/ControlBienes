using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Almacen;

public partial class EntMetodoAdquisicion : EntRegistroGenerico
{
    public long iIdMetodoAdquisicion { get; set; }

    public string sNombre { get; set; }

    public virtual ICollection<EntMovimiento> Movimientos { get; set; } = new List<EntMovimiento>();
}
