using ControlBienes.Entities.Catalogos.CentroTrabajoTurno;
using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos.Turno;

public partial class EntTurno : EntCatalogoGenerico
{
    public long iIdTurno { get; set; }

    public string sNombre { get; set; }

    public virtual ICollection<EntCentroTrabajoTurno> CentroTrabajoTurnos { get; set; } = new List<EntCentroTrabajoTurno>();
}
