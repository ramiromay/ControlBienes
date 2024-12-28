using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos;

public partial class EntAnaquel : EntRegistroGenerico
{
    public long iIdAnaquel { get; set; }

    public string sNombre { get; set; }

    public long iIdAlmacen { get; set; }

    public bool bActivo { get; set; }

    public virtual EntAlmacen Almacen { get; set; }
}
