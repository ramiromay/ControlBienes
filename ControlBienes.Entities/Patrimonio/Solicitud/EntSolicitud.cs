using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.General.Periodo;
using ControlBienes.Entities.General.UnidadAdministrativa;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Afectacion;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Baja;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Etapa;
using ControlBienes.Entities.Patrimonio.Historial;
using ControlBienes.Entities.Patrimonio.Modificacion;
using ControlBienes.Entities.Patrimonio.MotivoTramite;
using ControlBienes.Entities.Patrimonio.TipoTramite;
using ControlBienes.Entities.Seguridad.Empleado;

namespace ControlBienes.Entities.Patrimonio.Solicitud;

public partial class EntSolicitud : EntRegistroGenerico
{
    public long iIdSolicitud { get; set; }

    public long iIdEmpleado { get; set; }

    public long iIdEtapa { get; set; }

    public long iIdPeriodo { get; set; }

    public long iIdUnidadAdministrativa { get; set; }

    public long iIdTipoTramite { get; set; }

    public long iIdMotivoTramite { get; set; }

    public long iIdAfectacion { get; set; }

    public long iIdTipoBien { get; set; }

    public DateTime dtFechaAfectacion { get; set; }

    public string sDocumentoReferencia { get; set; }

    public string sObservaciones { get; set; }

    public virtual ICollection<EntDetalleAlta> DetallesAlta { get; set; } = new List<EntDetalleAlta>();

    public virtual ICollection<EntDetalleBaja> DetallesBajas { get; set; } = new List<EntDetalleBaja>();

    public virtual ICollection<EntDetalleModificacion> DetallesModificaciones { get; set; } = new List<EntDetalleModificacion>();

    public virtual ICollection<EntDetalleSolicitud> DetallesSolicitudes { get; set; } = new List<EntDetalleSolicitud>();

    public virtual ICollection<EntHistorial> Historiales { get; set; } = new List<EntHistorial>();

	public virtual ICollection<EntBienPatrimonio> BienesPatrimonio { get; set; } = new List<EntBienPatrimonio>();

	public virtual EntAfectacion Afectacion { get; set; }

    public virtual EntEmpleado Empleado { get; set; }

    public virtual EntEtapa Etapa { get; set; }

    public virtual EntMotivoTramite MotivoTramite { get; set; }

    public virtual EntPeriodo Periodo { get; set; }

    public virtual EntTipoTramite TiposTramite { get; set; }

    public virtual EntUnidadAdministrativa UnidadAdministrativa { get; set; }

    public virtual EntTipoBien TipoBien { get; set; }

}
