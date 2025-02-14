using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.Modificacion;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.Licitacion;

public partial class EntLicitacion : EntRegistroGenerico
{
    public long iIdLicitacion { get; set; }

    public int? iNumeroLicitacion { get; set; }

    public DateTime? dtFecha { get; set; }

    public string sObservaciones { get; set; }

    public virtual ICollection<EntDetalleAlta> DetallesAlta { get; set; } = new List<EntDetalleAlta>();

	public virtual ICollection<EntDetalleModificacion> DetallesModificacion { get; set; } = new List<EntDetalleModificacion>();

	public virtual ICollection<EntBienPatrimonio> BienesPatrimonio { get; set; } = new List<EntBienPatrimonio>();
}
