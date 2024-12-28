using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.General.UnidadAdministrativa;
using ControlBienes.Entities.Patrimonio.Afectacion;
using ControlBienes.Entities.Patrimonio.Solicitud;
using ControlBienes.Entities.Seguridad.Empleado;

namespace ControlBienes.Entities.Patrimonio.DestinoFinal;

public partial class EntDetalleDestinoFinal
{
    public long iIdDetalleDestinoFinal { get; set; }

    public long iIdUnidadAdministrativa { get; set; }

    public long iIdEmpleado { get; set; }

    public long iIdTipoBien { get; set; }

    public string sFolioBien { get; set; }

    public long iIdAfectacion { get; set; }

    public long? iIdDetalleEnagenacion { get; set; }

    public long? iIdDetalleDestruccion { get; set; }

    public string sObservaciones { get; set; }

    public virtual ICollection<EntDetalleSolicitud> DetallesSolicitudes { get; set; } = new List<EntDetalleSolicitud>();

    public virtual EntAfectacion Afectacion { get; set; }

    public virtual EntDetalleDestruccion DetalleDestruccion { get; set; }

    public virtual EntDetalleEnagenacion DetalleEnagenacion { get; set; }

    public virtual EntEmpleado Empleado { get; set; }

    public virtual EntTipoBien TipoBien { get; set; }

    public virtual EntUnidadAdministrativa UnidadAdministrativa { get; set; }
}
