using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.BajaInmueble;
using ControlBienes.Entities.Patrimonio.DatoInmueble;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.TipoDominio;

public partial class EntTipoDominio : EntRegistroGenerico
{
    public long iIdTipoDominio { get; set; }

    public string sNombre { get; set; }

    public bool bActivo { get; set; }

    public virtual ICollection<EntBajaInmueble> BajasInmuebles { get; set; } = new List<EntBajaInmueble>();

    public virtual ICollection<EntDatoInmueble> DatosInmuebles { get; set; } = new List<EntDatoInmueble>();
}
