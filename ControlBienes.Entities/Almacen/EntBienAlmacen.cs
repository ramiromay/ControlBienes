using ControlBienes.Entities.Catalogos;
using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Catalogos.Subfamilia;
using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Almacen;

public partial class EntBienAlmacen : EntRegistroGenerico
{
    public long iIdBien { get; set; }

    public long iIdAlmacen { get; set; }

    public string sDescripcion { get; set; }

    public decimal? nCodigoArmonizado { get; set; }

    public double iExistencia { get; set; }

    public string sUnidadMedida { get; set; }

    public long iIdFamilia { get; set; }

    public long iIdSubfamilia { get; set; }

    public virtual EntAlmacen Almacen { get; set; }

    public virtual EntFamilia Familia { get; set; }

    public virtual EntSubfamilia Subfamilia { get; set; }

    public virtual ICollection<EntMovimientoBien> MovimientosBienes { get; set; } = new List<EntMovimientoBien>();
}
