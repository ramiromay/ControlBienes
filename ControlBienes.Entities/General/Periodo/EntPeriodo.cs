using ControlBienes.Entities.Almacen.Bien;
using ControlBienes.Entities.Almacen.Movimiento;
using ControlBienes.Entities.Catalogos.Almacen;
using ControlBienes.Entities.Catalogos.Resguardante;
using ControlBienes.Entities.General.UnidadAdministrativa;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.Solicitud;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.General.Periodo;

public partial class EntPeriodo : EntRegistroGenerico
{
    public long iIdPeriodo { get; set; }

    public DateTime dtFechaInicio { get; set; }

    public DateTime dtFechaFinal { get; set; }

    public bool bActivo { get; set; }

    public virtual ICollection<EntAlmacen> Almacenes { get; set; } = new List<EntAlmacen>();

	public virtual ICollection<EntBienAlmacen> Periodos { get; set; } = new List<EntBienAlmacen>();

	public virtual ICollection<EntMovimiento> Movimientos { get; set; } = new List<EntMovimiento>();

	public virtual ICollection<EntBienPatrimonio> BienesPatrimonio { get; set; } = new List<EntBienPatrimonio>();

    public virtual ICollection<EntResguardante> Resguardantes { get; set; } = new List<EntResguardante>();

    public virtual ICollection<EntSolicitud> Solicitudes { get; set; } = new List<EntSolicitud>();

    public virtual ICollection<EntUnidadAdministrativa> UnidadesAdministrativas { get; set; } = new List<EntUnidadAdministrativa>();
}
