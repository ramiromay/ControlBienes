using ControlBienes.Entities.Almacen;
using ControlBienes.Entities.Almacen.Movimiento;
using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos.MetodoAdquisicion;

public partial class EntMetodoAdquisicion : EntCatalogoGenerico
{
	public long iIdMetodoAdquisicion { get; set; }

	public string sNombre { get; set; }

	public virtual ICollection<EntMovimiento> Movimientos { get; set; } = new List<EntMovimiento>();
}
