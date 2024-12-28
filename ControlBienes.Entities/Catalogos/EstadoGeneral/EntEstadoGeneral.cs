using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.DatoInmueble;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos.EstadoGeneral;

public partial class EntEstadoGeneral : EntCatalogoGenerico
{
    public long iIdEstadoGeneral { get; set; }

    public string sNombre { get; set; }

    public virtual ICollection<EntDatoInmueble> DatosInmuebles { get; set; } = new List<EntDatoInmueble>();
}
