using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Catalogos.Subfamilia;
using ControlBienes.Entities.Genericos;

namespace ControlBienes.Entities.Catalogos.CaracteristicaBien;

public partial class EntCaracteristicaBien : EntCatalogoGenerico
{
    public long iIdCaracteristicaBien { get; set; }

    public long iIdFamilia { get; set; }

    public long iIdSubfamilia { get; set; }

    public string sEtiqueta { get; set; }

    public string sDescripcion { get; set; }

    public virtual EntFamilia Familia { get; set; }

    public virtual EntSubfamilia Subfamilia { get; set; }
}
