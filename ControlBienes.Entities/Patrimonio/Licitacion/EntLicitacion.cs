using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Alta;
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
}
