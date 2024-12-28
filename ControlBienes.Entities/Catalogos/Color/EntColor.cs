using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.DatoGeneral;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos.Color;

public partial class EntColor : EntCatalogoGenerico
{
    public long iIdColor { get; set; }

    public string sNombre { get; set; }

    public string sCodigoRGB { get; set; }

    public virtual ICollection<EntDatoGeneral> DatosGenerales { get; set; } = new List<EntDatoGeneral>();
}
