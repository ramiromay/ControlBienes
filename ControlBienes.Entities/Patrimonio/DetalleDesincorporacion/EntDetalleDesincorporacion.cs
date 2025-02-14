    using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.General.UnidadAdministrativa;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Seguridad.Empleado;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.Desincorporacion;

public partial class EntDetalleDesincorporacion
{
    public long iIdDetalleDesincorporacion { get; set; }

    public long iIdUnidadAdministrativa { get; set; }

    public long? iIdEmpleado { get; set; }

    public long iIdTipoBien { get; set; }

    public string sFolioBien { get; set; }

    public string sObservaciones { get; set; }

    public DateTime dtFechaPublicacion { get; set; }

    public string sNumeroPublicacion { get; set; }

    public string sDescripcionDesincorporacion { get; set; }

    public virtual ICollection<EntDetalleSolicitud> DetallesSolicitudes { get; set; } = new List<EntDetalleSolicitud>();

    public virtual EntEmpleado Empleado { get; set; }

    public virtual EntTipoBien TipoBien { get; set; }

    public virtual EntUnidadAdministrativa UnidadAdministrativa { get; set; }
}
