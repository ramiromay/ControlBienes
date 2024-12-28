using ControlBienes.Entities.Catalogos.CentroTrabajo;
using ControlBienes.Entities.Catalogos.Titular;
using ControlBienes.Entities.Catalogos.Turno;
using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos.CentroTrabajoTurno;

public partial class EntCentroTrabajoTurno : EntCatalogoGenerico
{
	public long iIdCentroTrabajoTurno { get; set; }

	public long iIdCentroTrabajo { get; set; }

	public long iIdTurno { get; set; }

	public virtual EntCentroTrabajo CentroTrabajo { get; set; }

	public virtual EntTurno Turno { get; set; }

	public virtual ICollection<EntTitular> Titulares { get; set; } = new List<EntTitular>();
}
