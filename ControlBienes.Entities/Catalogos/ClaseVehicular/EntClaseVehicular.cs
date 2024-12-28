using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.DatoGeneral;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos.ClaseVehicular;

public partial class EntClaseVehicular : EntCatalogoGenerico
{
    public long iIdClaseVehicular { get; set; }

    public string sNombre { get; set; }

    public string sDescripcion { get; set; }

    public virtual ICollection<EntDatoGeneral> DatosGenerales { get; set; } = new List<EntDatoGeneral>();
}
