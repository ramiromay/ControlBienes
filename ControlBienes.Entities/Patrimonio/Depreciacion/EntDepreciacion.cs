using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.Depreciacion;

public partial class EntDepreciacion
{
    public long iIdDepreciacion { get; set; }

    public long iIdBien { get; set; }

    public decimal dTasa { get; set; }

    public decimal dDepreciaionAcumulada { get; set; }

    public decimal dValorLibros { get; set; }

    public decimal dDepreciacionFiscal { get; set; }

    public decimal dDepreciacion { get; set; }

    public DateTime dtFecha { get; set; }

    public bool bActivo { get; set; }

    public decimal dValorHistorico { get; set; }

    public int iAniosVida {  get; set; }
}
