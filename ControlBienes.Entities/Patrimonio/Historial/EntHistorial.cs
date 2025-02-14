using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.Solicitud;
using ControlBienes.Entities.Seguridad.Usuario;
using ControlBienes.Entities.Sistema.Modulo;
using ControlBienes.Entities.Sistema.SubModulo;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.Historial;

public partial class EntHistorial : EntRegistroGenerico
{
    public long iIdHistorial { get; set; }

    public long iIdBien { get; set; }

    public long iIdModulo { get; set; }

    public long iIdSubModulo { get; set; }

    public long iIdSolicitud { get; set; }

    public long iIdUsuario { get; set; }

    public virtual EntBienPatrimonio Bien { get; set; }

    public virtual EntModulo Modulo { get; set; }

    public virtual EntSolicitud Solicitud { get; set; }

    public virtual EntSubModulo SubModulo { get; set; }

    public virtual EntUsuario Usuario { get; set; }
}
