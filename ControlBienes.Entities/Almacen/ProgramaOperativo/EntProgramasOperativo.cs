using ControlBienes.Entities.Almacen.Movimiento;
using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Almacen.ProgramaOperativo;

public partial class EntProgramasOperativo : EntRegistroGenerico
{
	public long iIdProgramaOperativo { get; set; }

	public string sNombre { get; set; }

	public virtual ICollection<EntMovimiento> Movimientos { get; set; } = new List<EntMovimiento>();
}
