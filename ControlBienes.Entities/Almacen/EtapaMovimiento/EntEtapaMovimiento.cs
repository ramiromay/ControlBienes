using ControlBienes.Entities.Patrimonio.Etapa;

namespace ControlBienes.Entities.Almacen.EtapaMovimiento;

public partial class EntEtapaMovimiento
{
    public long iIdEtapaMovimiento { get; set; }

    public long iIdEtapaOrigen { get; set; }

    public long iIdEtapaDestino { get; set; }

    public DateTime dtFechaCreacion { get; set; }

    public DateTime dtFechaModificacion { get; set; }

    public virtual EntEtapa EtapaDestino { get; set; }

    public virtual EntEtapa EtapaOrigen { get; set; }
}
