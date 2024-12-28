using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.Modificacion;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos.TipoAdquisicion;

public partial class EntTipoAdquisicion : EntCatalogoGenerico
{
    public long iIdTipoAdquisicion { get; set; }

    public string sNombre { get; set; }

    public virtual ICollection<EntrBienPatrimonio> BienesPatrimonio { get; set; } = new List<EntrBienPatrimonio>();

    public virtual ICollection<EntDetalleAlta> DetallesAlta { get; set; } = new List<EntDetalleAlta>();

    public virtual ICollection<EntDetalleModificacion> DetallesModificaciones { get; set; } = new List<EntDetalleModificacion>();
}
