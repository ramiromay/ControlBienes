using ControlBienes.Entities.Catalogos;
using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Almacen;

public partial class EntTipoMovimiento : EntRegistroGenerico
{
    public long iIdTipoMovimiento { get; set; }

    public string sNombre { get; set; }

    public virtual ICollection<EntConceptoMovimiento> ConceptosMovimientos { get; set; } = new List<EntConceptoMovimiento>();

    public virtual ICollection<EntMovimiento> Movimientos { get; set; } = new List<EntMovimiento>();
}
