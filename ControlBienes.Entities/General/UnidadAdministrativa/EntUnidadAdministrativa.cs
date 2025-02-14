using ControlBienes.Entities.Catalogos.CentroTrabajo;
using ControlBienes.Entities.Catalogos.Resguardante;
using ControlBienes.Entities.General.Periodo;
using ControlBienes.Entities.General.TipoNivel;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Baja;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.Desincorporacion;
using ControlBienes.Entities.Patrimonio.DestinoFinal;
using ControlBienes.Entities.Patrimonio.Modificacion;
using ControlBienes.Entities.Patrimonio.Movimiento;
using ControlBienes.Entities.Patrimonio.Solicitud;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.General.UnidadAdministrativa;

public partial class EntUnidadAdministrativa : EntRegistroGenerico
{
    public long iIdUnidadAdministrativa { get; set; }

    public long iIdPeriodo { get; set; }

    public string sNombre { get; set; }

    public string sNivelCompleto { get; set; }

    public long iIdTipoNivel { get; set; }

    public virtual ICollection<EntBaja> Bajas { get; set; } = new List<EntBaja>();

    public virtual ICollection<EntBienPatrimonio> BienesPatrimonio { get; set; } = new List<EntBienPatrimonio>();

    public virtual ICollection<EntCentroTrabajo> CentrosTrabajos { get; set; } = new List<EntCentroTrabajo>();

    public virtual ICollection<EntDetalleAlta> DetallesAlta { get; set; } = new List<EntDetalleAlta>();

    public virtual ICollection<EntDetalleDesincorporacion> DetallesDesincorporaciones { get; set; } = new List<EntDetalleDesincorporacion>();

    public virtual ICollection<EntDetalleDestinoFinal> DetallesDestinoFinales { get; set; } = new List<EntDetalleDestinoFinal>();

    public virtual ICollection<EntDetalleModificacion> DetallesModificaciones { get; set; } = new List<EntDetalleModificacion>();

	public virtual ICollection<EntDetalleModificacion> DetallesModificacionesCentroCosto { get; set; } = new List<EntDetalleModificacion>();

	public virtual ICollection<EntDetalleMovimiento> DetallesMovimientoIIdNuevaUnidadAdministrativaNavigations { get; set; } = new List<EntDetalleMovimiento>();

    public virtual ICollection<EntDetalleMovimiento> DetallesMovimientoIIdUnidadAdministrativaNavigations { get; set; } = new List<EntDetalleMovimiento>();

    public virtual EntPeriodo Periodo { get; set; }

    public virtual EntTipoNivel TipoNivel { get; set; }

    public virtual ICollection<EntResguardante> Resguardantes { get; set; } = new List<EntResguardante>();

    public virtual ICollection<EntSolicitud> Solicitudes { get; set; } = new List<EntSolicitud>();
}
