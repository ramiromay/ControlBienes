using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Etapa;
using ControlBienes.Entities.Seguridad.Usuario;
using ControlBienes.Entities.Sistema.Modulo;
using ControlBienes.Entities.Sistema.SubModulo;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.Seguimiento;

public partial class EntSeguimiento : EntRegistroGenerico
{
    public long iIdSeguimiento { get; set; }

    public long iIdDetalleSolicitud { get; set; }

    public DateTime dtFechaHora { get; set; }

    public long iIdModulo { get; set; }

    public long iIdSubModulo { get; set; }

    public long iIdEtapa { get; set; }

    public long iIdUsuario { get; set; }

    public virtual EntDetalleSolicitud DetalleSolicitud { get; set; }

    public virtual EntEtapa Etapa { get; set; }

    public virtual EntModulo Modulo { get; set; }

    public virtual EntSubModulo SubModulo { get; set; }

    public virtual EntUsuario Usuario { get; set; }
}
