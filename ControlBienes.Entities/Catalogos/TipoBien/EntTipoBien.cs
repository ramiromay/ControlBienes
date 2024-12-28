using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Baja;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.Desincorporacion;
using ControlBienes.Entities.Patrimonio.DestinoFinal;
using ControlBienes.Entities.Patrimonio.Modificacion;
using ControlBienes.Entities.Patrimonio.Movimiento;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos.TipoBien;

public partial class EntTipoBien : EntCatalogoGenerico
{
    public long iIdTipoBien { get; set; }

    public string sNombre { get; set; }

    public virtual ICollection<EntBaja> Bajas { get; set; } = new List<EntBaja>();

    public virtual ICollection<EntrBienPatrimonio> BienesPatrimonio { get; set; } = new List<EntrBienPatrimonio>();

    public virtual ICollection<EntDetalleAlta> DetallesAlta { get; set; } = new List<EntDetalleAlta>();

    public virtual ICollection<EntDetalleDesincorporacion> DetallesDesincorporaciones { get; set; } = new List<EntDetalleDesincorporacion>();

    public virtual ICollection<EntDetalleDestinoFinal> DetallesDestinoFinales { get; set; } = new List<EntDetalleDestinoFinal>();

    public virtual ICollection<EntDetalleModificacion> DetallesModificaciones { get; set; } = new List<EntDetalleModificacion>();

    public virtual ICollection<EntDetalleMovimiento> DetallesMovimientos { get; set; } = new List<EntDetalleMovimiento>();

    public virtual ICollection<EntFamilia> Familia { get; set; } = new List<EntFamilia>();
}
