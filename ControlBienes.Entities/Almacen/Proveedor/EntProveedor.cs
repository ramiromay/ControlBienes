using ControlBienes.Entities.Almacen.Movimiento;
using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Almacen.Proveedor;

public partial class EntProveedor : EntRegistroGenerico
{
	public long iIdProveedor { get; set; }

	public string sNombre { get; set; }

	public virtual ICollection<EntMovimiento> Movimientos { get; set; } = new List<EntMovimiento>();
}
