using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Historial;
using ControlBienes.Entities.Patrimonio.Seguimiento;
using ControlBienes.Entities.Seguridad.Permiso;
using ControlBienes.Entities.Sistema.Catalogo;
using ControlBienes.Entities.Sistema.SubModulo;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Sistema.Modulo;

public partial class EntModulo : EntRegistroGenerico
{
    public long iIdModulo { get; set; }

    public string sNombre { get; set; }

    public string sAbreviacion { get; set; }

    public string sDescripcion { get; set; }

    public long iIdPermiso { get; set; }

    public virtual ICollection<EntCatalogo> Catalogos { get; set; } = new List<EntCatalogo>();

    public virtual ICollection<EntHistorial> Historiales { get; set; } = new List<EntHistorial>();

    public virtual EntPermiso Permiso { get; set; }

    public virtual ICollection<EntSeguimiento> Seguimientos { get; set; } = new List<EntSeguimiento>();

    public virtual ICollection<EntSubModulo> SubModulos { get; set; } = new List<EntSubModulo>();
}
