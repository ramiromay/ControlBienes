using ControlBienes.Entities.Almacen;
using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Catalogos.Subfamilia;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.Modificacion;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.General.BMS;

public partial class EntBms : EntRegistroGenerico
{
    public long iIdBms { get; set; }

    public string sNombre { get; set; }

    public long iIdFamilia { get; set; }

    public long iIdSubfamilia { get; set; }

    public int iCantidad { get; set; }

    public string sUnidadMedida { get; set; }

    public double dPrecioUnitario { get; set; }

    public decimal? nCodigoArmonizado { get; set; }

    public bool bActivo { get; set; }

    public virtual ICollection<EntrBienPatrimonio> BienesPatrimonio { get; set; } = new List<EntrBienPatrimonio>();

    public virtual ICollection<EntDetalleAlta> DetallesAlta { get; set; } = new List<EntDetalleAlta>();

    public virtual ICollection<EntDetalleModificacion> DetallesModificaciones { get; set; } = new List<EntDetalleModificacion>();

    public virtual EntFamilia Familia { get; set; }

    public virtual EntSubfamilia Subfamilia { get; set; }

    public virtual ICollection<EntMovimientoBien> MovimientosBienes { get; set; } = new List<EntMovimientoBien>();
}
