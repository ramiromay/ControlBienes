using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Almacen;

public partial class EntProveedor
{
    public long iIdProveedor { get; set; }

    public string sNombre { get; set; }

    public DateTime dtFechaCreacion { get; set; }

    public DateTime dtFechaModificacion { get; set; }

    public virtual ICollection<EntMovimiento> Movimientos { get; set; } = new List<EntMovimiento>();
}
