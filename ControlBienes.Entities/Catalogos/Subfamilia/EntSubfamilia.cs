using ControlBienes.Entities.Almacen;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.General.BMS;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.Modificacion;

namespace ControlBienes.Entities.Catalogos.Subfamilia;

public partial class EntSubfamilia : EntCatalogoGenerico
{
    public long iIdSubfamilia { get; set; }

    public long iIdFamilia { get; set; }

    public int? iNumeroCuenta { get; set; }

    public string sNombre { get; set; }

    public string sDescripcion { get; set; }

    public double dValorRecuperable { get; set; }

    public virtual ICollection<EntrBienPatrimonio> BienesPatrimonio { get; set; } = new List<EntrBienPatrimonio>();

    public virtual ICollection<EntBienAlmacen> BienesAlmacen { get; set; } = new List<EntBienAlmacen>();

    public virtual ICollection<EntBms> Bms { get; set; } = new List<EntBms>();

    public virtual ICollection<EntCaracteristicaBien> CaracteristicasBienes { get; set; } = new List<EntCaracteristicaBien>();

    public virtual ICollection<EntDetalleAlta> DetallesAlta { get; set; } = new List<EntDetalleAlta>();

    public virtual ICollection<EntDetalleModificacion> DetallesModificaciones { get; set; } = new List<EntDetalleModificacion>();

    public virtual EntFamilia Familia { get; set; }
}
