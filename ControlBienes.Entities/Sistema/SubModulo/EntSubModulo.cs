using ControlBienes.Entities.Catalogos.Documento;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Historial;
using ControlBienes.Entities.Patrimonio.Seguimiento;
using ControlBienes.Entities.Patrimonio.TipoTramite;
using ControlBienes.Entities.Seguridad.Permiso;
using ControlBienes.Entities.Sistema.ColumnaTabla;
using ControlBienes.Entities.Sistema.Modulo;
using ControlBienes.Entities.Sistema.Seccion;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Sistema.SubModulo;

public partial class EntSubModulo : EntRegistroGenerico
{
    public long iIdSubModulo { get; set; }

    public string sNombre { get; set; }

    public string sAbreviacion { get; set; }

    public long iIdModulo { get; set; }

    public long iIdSeccion { get; set; }

    public long iIdPermiso { get; set; }

    public virtual ICollection<EntColumnasTabla> ColumnasTablas { get; set; } = new List<EntColumnasTabla>();

    public virtual ICollection<EntDocumento> Documentos { get; set; } = new List<EntDocumento>();

    public virtual ICollection<EntHistorial> Historiales { get; set; } = new List<EntHistorial>();

    public virtual EntModulo Modulo { get; set; }

    public virtual EntPermiso Permiso { get; set; }

    public virtual EntSeccion Seccion { get; set; }

    public virtual ICollection<EntSeguimiento> Seguimientos { get; set; } = new List<EntSeguimiento>();

    public virtual ICollection<EntTipoTramite> TiposTramites { get; set; } = new List<EntTipoTramite>();
}
