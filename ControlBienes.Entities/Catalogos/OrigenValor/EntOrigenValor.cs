using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.DatoRegistral;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos.OrigenValor;

public partial class EntOrigenValor : EntCatalogoGenerico
{
    public long iIdOrigenValor { get; set; }

    public string sOrigen { get; set; }

    public string sDescripcion { get; set; }

    public virtual ICollection<EntDatoRegistral> DatosRegistrales { get; set; } = new List<EntDatoRegistral>();
}
