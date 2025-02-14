using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.DatoVehicular;
using ControlBienes.Entities.Patrimonio.Modificacion;
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

	public virtual ICollection<EntDetalleModificacion> DetallesModificacion { get; set; } = new List<EntDetalleModificacion>();

	public virtual EntDatoVehicular DatoVehicular { get; set; }

	public virtual ICollection<EntBienPatrimonio> BienesPatrimonio { get; set; } = new List<EntBienPatrimonio>();
}
