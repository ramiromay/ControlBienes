using ControlBienes.Entities.Catalogos.CentroTrabajoTurno;
using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos.Titular;

public partial class EntTitular : EntCatalogoGenerico
{
    public long iIdTitular { get; set; }

    public string sNombre { get; set; }

    public long iIdCentroTrabajoTurno { get; set; }

    public virtual EntCentroTrabajoTurno CentroTrabajoTurno { get; set; }
}
