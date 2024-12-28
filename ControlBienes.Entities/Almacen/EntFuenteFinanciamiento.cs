using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Almacen;

public partial class EntFuenteFinanciamiento : EntRegistroGenerico
{
    public long iIdFuenteFinanciamiento { get; set; }

    public string sNombre { get; set; }

    public string sClaveCompleta { get; set; }

    public virtual ICollection<EntMovimiento> Movimientos { get; set; } = new List<EntMovimiento>();
}
