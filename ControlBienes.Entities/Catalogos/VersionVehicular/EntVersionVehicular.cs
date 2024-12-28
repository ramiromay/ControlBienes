using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.DatoGeneral;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos.VersionVehicular;

public partial class EntVersionVehicular : EntCatalogoGenerico
{
    public long iIdVersionVehicular { get; set; }

    public string sNombre { get; set; }

    public string sDescripcion { get; set; }

    public virtual ICollection<EntDatoGeneral> DatosGenerales { get; set; } = new List<EntDatoGeneral>();
}
