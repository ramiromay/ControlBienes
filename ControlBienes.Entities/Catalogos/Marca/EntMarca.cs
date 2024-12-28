using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.DatoGeneral;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos.Marca;

public partial class EntMarca : EntCatalogoGenerico
{
    public long iIdMarca { get; set; }

    public string sNombre { get; set; }

    public string sObservaciones { get; set; }

    public virtual ICollection<EntDatoGeneral> DatosGenerales { get; set; } = new List<EntDatoGeneral>();
}
