using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.Depreciacion;

public partial class EntDepreciacion
{
    public long iIdDepreciacion { get; set; }

    public long iIdBien { get; set; }

    public decimal dTasa { get; set; }

    public decimal dDepreciaionAcumulada { get; set; }

    public double dValorLibros { get; set; }

    public decimal dDepreciacionFiscal { get; set; }

    public DateTime dtFecha { get; set; }
}
