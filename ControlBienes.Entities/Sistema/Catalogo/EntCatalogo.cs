using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Seguridad.Permiso;
using ControlBienes.Entities.Sistema.ColumnaTabla;
using ControlBienes.Entities.Sistema.Modulo;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Sistema.Catalogo;

public partial class EntCatalogo : EntRegistroGenerico
{
    public long iIdCatalogo { get; set; }

    public string sNombre { get; set; }

    public long? iIdModulo { get; set; }

    public long iIdPermiso { get; set; }

    public bool? bActivo { get; set; }

    public virtual ICollection<EntColumnasTabla> ColumnasTablas { get; set; } = new List<EntColumnasTabla>();

    public virtual EntModulo Modulo { get; set; }

    public virtual EntPermiso Permiso { get; set; }
}
