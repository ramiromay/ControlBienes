using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Sistema.Catalogo;
using ControlBienes.Entities.Sistema.SubModulo;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Sistema.ColumnaTabla;

public partial class EntColumnasTabla : EntRegistroGenerico
{
    public long iIdColumnaTabla { get; set; }

    public string sClave { get; set; }

    public string sNombre { get; set; }

    public int? iTamanio { get; set; }

    public string sTipoDato { get; set; }

    public long? iIdCatalogo { get; set; }

    public long? iIdSubModulo { get; set; }

    public bool bActivo { get; set; }

    public virtual EntCatalogo Catalogo { get; set; }

    public virtual EntSubModulo SubModulo { get; set; }
}
