using ControlBienes.Entities.General.BMS;
using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Almacen;

public partial class EntMovimientoBien : EntRegistroGenerico
{
    public long iIdMovimientoBien { get; set; }

    public long iIdMovimiento { get; set; }

    public long iIdBms { get; set; }

    public long? iIdBien { get; set; }

    public virtual EntBienAlmacen Bien { get; set; }

    public virtual EntBms Bms { get; set; }

    public virtual EntMovimiento Movimiento { get; set; }
}
