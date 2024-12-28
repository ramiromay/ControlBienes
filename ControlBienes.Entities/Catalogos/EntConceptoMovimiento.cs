using ControlBienes.Entities.Almacen;
using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos;

public partial class EntConceptoMovimiento : EntRegistroGenerico
{
    public long iIdConceptoMovimiento { get; set; }

    public string sNombre { get; set; }

    public string sDescripcion { get; set; }

    public long iIdTipoMovimiento { get; set; }

    public bool bActivo { get; set; }

    public virtual EntTipoMovimiento TipoMovimiento { get; set; }

    public virtual ICollection<EntMovimiento> Movimientos { get; set; } = new List<EntMovimiento>();
}
