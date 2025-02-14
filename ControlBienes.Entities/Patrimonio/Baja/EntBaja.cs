using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.General.UnidadAdministrativa;
using ControlBienes.Entities.Seguridad.Empleado;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.Baja;

public partial class EntBaja
{
    public long iIdBaja { get; set; }

    public long? iIdUnidadAdministrativa { get; set; }

    public long? iIdEmpleado { get; set; }

    public long iIdTipoBien { get; set; }

    public string sFolioBien { get; set; }

    public string sObservaciones { get; set; }

    public string sFolioDocumento { get; set; }

    public string sFolioDictamen { get; set; }

    public DateTime dtFehaDocumento { get; set; }

    public string sListaDocunetario { get; set; }

    public string sNombreSolicitante { get; set; }

    public string sLugarResguardo { get; set; }

    public virtual ICollection<EntDetalleBaja> DetallesBajas { get; set; } = new List<EntDetalleBaja>();

    public virtual EntEmpleado Empleado { get; set; }

    public virtual EntTipoBien TipoBien { get; set; }

    public virtual EntUnidadAdministrativa UnidadAdministrativa { get; set; }
}
