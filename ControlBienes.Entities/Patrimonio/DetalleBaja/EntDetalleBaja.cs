using ControlBienes.Entities.Patrimonio.BajaInmueble;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Solicitud;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.Baja;

public partial class EntDetalleBaja
{
    public long iIdDetalleBaja { get; set; }

    public long iIdSolicitud { get; set; }

    public long? iIdBaja { get; set; }

    public long? iIdBajaInmueble { get; set; }

    public virtual ICollection<EntDetalleSolicitud> DetallesSolicitudes { get; set; } = new List<EntDetalleSolicitud>();

    public virtual EntBajaInmueble BajaInmueble { get; set; }

    public virtual EntBaja Baja { get; set; }

    public virtual EntSolicitud Solicitud { get; set; }
}
