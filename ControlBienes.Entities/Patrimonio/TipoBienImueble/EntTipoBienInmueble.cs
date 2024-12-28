using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.TipoBienImueble;

public partial class EntTipoBienInmueble : EntRegistroGenerico
{
    public long iIdTipoBienInmueble { get; set; }

    public string sNombre { get; set; }

    public string sDescripcion { get; set; }

    public int iNivel { get; set; }

    public string sClave { get; set; }

    public string sClaveCompleta { get; set; }

    public bool bActivo { get; set; }
}
