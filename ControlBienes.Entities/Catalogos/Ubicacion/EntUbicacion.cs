using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.Modificacion;
using ControlBienes.Entities.Patrimonio.Movimiento;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos.Ubicacion;

public partial class EntUbicacion : EntCatalogoGenerico
{
    public long iIdUbicacion { get; set; }

    public string sDescripcion { get; set; }

    public virtual ICollection<EntrBienPatrimonio> BienesPatrimonio { get; set; } = new List<EntrBienPatrimonio>();

    public virtual ICollection<EntDetalleAlta> DetallesAlta { get; set; } = new List<EntDetalleAlta>();

    public virtual ICollection<EntDetalleModificacion> DetallesModificaciones { get; set; } = new List<EntDetalleModificacion>();

    public virtual ICollection<EntDetalleMovimiento> DetallesMovimientos { get; set; } = new List<EntDetalleMovimiento>();
}
