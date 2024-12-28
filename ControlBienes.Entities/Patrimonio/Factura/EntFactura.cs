using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.DatoVehicular;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.Factura;

public partial class EntFactura : EntRegistroGenerico
{
    public long iIdFactura { get; set; }

    public string sFolioFactura { get; set; }

    public DateTime dtFecha { get; set; }

    public int? iGarantiaDias { get; set; }

    public long? iIdDatoVehicular { get; set; }

    public virtual ICollection<EntDetalleAlta> DetallesAlta { get; set; } = new List<EntDetalleAlta>();

    public virtual EntDatoVehicular DatoVehicular { get; set; }
}
