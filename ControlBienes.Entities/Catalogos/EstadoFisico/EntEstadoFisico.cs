using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.Modificacion;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos.EstadoFisico;

public partial class EntEstadoFisico : EntCatalogoGenerico
{
    public long iIdEstadoFisico { get; set; }

    public string sNombre { get; set; }

    public string sDescripcion { get; set; }

    public virtual ICollection<EntBienPatrimonio> BienesPatrimonio { get; set; } = new List<EntBienPatrimonio>();

    public virtual ICollection<EntDetalleAlta> DetallesAlta { get; set; } = new List<EntDetalleAlta>();

    public virtual ICollection<EntDetalleModificacion> DetallesModificaciones { get; set; } = new List<EntDetalleModificacion>();
}
