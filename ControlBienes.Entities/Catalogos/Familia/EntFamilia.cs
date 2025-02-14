using ControlBienes.Entities.Almacen.Bien;
using ControlBienes.Entities.Almacen.Movimiento;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using ControlBienes.Entities.Catalogos.Subfamilia;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.General.BMS;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.Modificacion;

namespace ControlBienes.Entities.Catalogos.Familia;

public partial class EntFamilia : EntCatalogoGenerico
{
    public long iIdFamilia { get; set; }

    public int? iNumeroCuenta { get; set; }

    public string sNombre { get; set; }

    public string sDescripcion { get; set; }

    public long? iIdTipoBien { get; set; }

    public virtual ICollection<EntBienPatrimonio> BienesPatrimonio { get; set; } = new List<EntBienPatrimonio>();

    public virtual ICollection<EntBienAlmacen> BienesAlmacen { get; set; } = new List<EntBienAlmacen>();

    public virtual ICollection<EntBms> Bms { get; set; } = new List<EntBms>();

    public virtual ICollection<EntCaracteristicaBien> CaracteristicasBienes { get; set; } = new List<EntCaracteristicaBien>();

    public virtual ICollection<EntDetalleAlta> DetallesAlta { get; set; } = new List<EntDetalleAlta>();

    public virtual ICollection<EntDetalleModificacion> DetallesModificaciones { get; set; } = new List<EntDetalleModificacion>();

    public virtual EntTipoBien TipoBien { get; set; }

    public virtual ICollection<EntMovimiento> Movimientos { get; set; } = new List<EntMovimiento>();

    public virtual ICollection<EntSubfamilia> Subfamilia { get; set; } = new List<EntSubfamilia>();
}
