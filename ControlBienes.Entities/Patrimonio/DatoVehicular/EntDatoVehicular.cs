using ControlBienes.Entities.Patrimonio.Factura;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.DatoVehicular;

public partial class EntDatoVehicular
{
    public long iIdDatoVehicular { get; set; }

    public int? iAnioEmision { get; set; }

    public string sNumeroPlaca { get; set; }

    public int? iNumeroMotor { get; set; }

    public int? iAnioModelo { get; set; }

    public decimal? nNumeroEconomico { get; set; }

    public virtual ICollection<EntFactura> Facturas { get; set; } = new List<EntFactura>();
}
