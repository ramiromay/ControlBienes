using ControlBienes.Entities.Catalogos.CentroTrabajo;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.Modificacion;
using ControlBienes.Entities.Patrimonio.Movimiento;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.General.Municipio;

public partial class EntMunicipio : EntRegistroGenerico
{
    public long iIdMunicipio { get; set; }

    public string sNombre { get; set; }

    public virtual ICollection<EntBienPatrimonio> BienesPatrimonio { get; set; } = new List<EntBienPatrimonio>();

    public virtual ICollection<EntCentroTrabajo> CentrosTrabajos { get; set; } = new List<EntCentroTrabajo>();

    public virtual ICollection<EntDetalleAlta> DetallesAlta { get; set; } = new List<EntDetalleAlta>();

    public virtual ICollection<EntDetalleModificacion> DetallesModificaciones { get; set; } = new List<EntDetalleModificacion>();

    public virtual ICollection<EntDetalleMovimiento> DetallesMovimientos { get; set; } = new List<EntDetalleMovimiento>();
}
