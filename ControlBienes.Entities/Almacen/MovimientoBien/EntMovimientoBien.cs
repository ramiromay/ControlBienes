using ControlBienes.Entities.Almacen.Bien;
using ControlBienes.Entities.Almacen.Movimiento;
using ControlBienes.Entities.General.BMS;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Etapa;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Almacen.MovimientoBien;

public partial class EntMovimientoBien : EntRegistroGenerico
{
	public long iIdMovimientoBien { get; set; }

	public long iIdMovimiento { get; set; }

	public long? iIdBms { get; set; }

	public int? iCantidad { get; set; }

	public double? dTotal { get; set; }

	public virtual EntBienAlmacen Bien { get; set; }

	public virtual EntBms Bms { get; set; }

	public virtual EntMovimiento Movimiento { get; set; }
}
