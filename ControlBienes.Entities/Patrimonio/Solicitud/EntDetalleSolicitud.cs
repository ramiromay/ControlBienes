using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Baja;
using ControlBienes.Entities.Patrimonio.Desincorporacion;
using ControlBienes.Entities.Patrimonio.DestinoFinal;
using ControlBienes.Entities.Patrimonio.Etapa;
using ControlBienes.Entities.Patrimonio.Modificacion;
using ControlBienes.Entities.Patrimonio.Movimiento;
using ControlBienes.Entities.Patrimonio.Seguimiento;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.Solicitud;

public partial class EntDetalleSolicitud
{
    public long iIdDetalleSolicitud { get; set; }

    public long iIdSolicitud { get; set; }

    public long iIdEtapa { get; set; }

    public long? iIdDetalleAlta { get; set; }

    public long? iIdDetalleBaja { get; set; }

    public long? iIdDetalleMovimiento { get; set; }

    public long? iIdDetalleModificacion { get; set; }

    public long? iIdDetalleDesincorporacion { get; set; }

    public long? iIdDetalleDestinoFinal { get; set; }

    public DateTime dtFechaCreacion { get; set; }

    public DateTime dtFechaModificacion { get; set; }

    public virtual EntDetalleAlta DetalleAlta { get; set; }

    public virtual EntDetalleBaja DetalleBaja { get; set; }

    public virtual EntDetalleDesincorporacion DetalleDesincorporacion { get; set; }

    public virtual EntDetalleDestinoFinal DetalleDestinoFinal { get; set; }

    public virtual EntDetalleModificacion DetalleModificacion { get; set; }

    public virtual EntDetalleMovimiento DetalleMovimiento { get; set; }

    public virtual EntEtapa Etapa { get; set; }

    public virtual EntSolicitud Solicitud { get; set; }

    public virtual ICollection<EntSeguimiento> Seguimientos { get; set; } = new List<EntSeguimiento>();
}
