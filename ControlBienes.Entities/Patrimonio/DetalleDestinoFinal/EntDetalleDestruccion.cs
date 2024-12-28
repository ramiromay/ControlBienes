using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.DestinoFinal;

public partial class EntDetalleDestruccion
{
    public long iIdDetalleDestruccion { get; set; }

    public string sFolio { get; set; }

    public DateTime dtFecha { get; set; }

    public string sDescripcion { get; set; }

    public virtual ICollection<EntDetalleDestinoFinal> DetallesDestinoFinales { get; set; } = new List<EntDetalleDestinoFinal>();
}
