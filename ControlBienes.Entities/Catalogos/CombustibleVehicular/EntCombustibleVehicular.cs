using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.DatoGeneral;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos.CombustibleVehicular;

public partial class EntCombustibleVehicular : EntCatalogoGenerico
{
    public long iIdCombustibleVehicular { get; set; }

    public string sNombre { get; set; }

    public string sDescripcion { get; set; }

    public virtual ICollection<EntDatoGeneral> DatosGenerales { get; set; } = new List<EntDatoGeneral>();
}
