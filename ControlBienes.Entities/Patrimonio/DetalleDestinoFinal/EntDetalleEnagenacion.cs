using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.DestinoFinal;

public partial class EntDetalleEnagenacion
{
    public long iIdDetalleEnagenacion { get; set; }

    public string sFolio { get; set; }

    public DateTime dtFecha { get; set; }

    public string sAvaluo { get; set; }

    public double dImporteAvaluo { get; set; }

    public double dImporte { get; set; }

    public string sDescripcion { get; set; }

    public virtual ICollection<EntDetalleDestinoFinal> DetallesDestinoFinales { get; set; } = new List<EntDetalleDestinoFinal>();
}
